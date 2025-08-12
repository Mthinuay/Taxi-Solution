using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.EntityFrameworkCore;
using CsvHelper.Configuration.Attributes;
using Adingisa.Models;

namespace Adingisa.Data
{
    // Custom converter to handle currency symbols in the CSV file
    public class CustomDecimalConverter : DecimalConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0m; // Default to 0 for empty values
            }

            text = text.Trim();
            if (text.StartsWith("R", StringComparison.OrdinalIgnoreCase))
            {
                text = text.Substring(1).Trim();
            }

            try
            {
                return base.ConvertFromString(text, row, memberMapData);
            }
            catch (FormatException ex)
            {
                throw new FormatException($"Invalid decimal format in CSV for value '{text}' at row {row.Context.Parser.Row}", ex);
            }
        }
    }

    // DTO class for CSV mapping
    public class TaxiRouteCsv
    {
        [Name("StartLocation")]
        public string? StartLocation { get; set; }
        [Name("EndLocation")]
        public string? EndLocation { get; set; }
        [Name("Fare")]
        [TypeConverter(typeof(CustomDecimalConverter))]
        public decimal Fare { get; set; }
        [Name("PickupLocation")]
        [Optional] // Mark as optional to avoid errors if header is missing
        public string? PickupLocation { get; set; }
    }

    public static class TaxiRouteSeeder
    {
        public static async Task SeedFromCsvAsync(AppDbContext context, string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                Console.WriteLine($"CSV file not found at: {csvFilePath}");
                return;
            }

            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null, // Ignore missing fields
                TrimOptions = TrimOptions.Trim,
                IgnoreBlankLines = true,
                BadDataFound = args => Console.WriteLine($"Bad data: {args.RawRecord}")
            };

            int rowNumber = -1;
            try
            {
                using var reader = new StreamReader(csvFilePath);
                using var csv = new CsvReader(reader, csvConfig);
                var records = csv.GetRecords<TaxiRouteCsv>().ToList();

                if (!records.Any())
                {
                    Console.WriteLine("No records found in the CSV file.");
                    return;
                }

                int addedRecords = 0;
                foreach (var record in records)
                {
                    rowNumber = csv.Context.Parser.Row;
                    if (string.IsNullOrWhiteSpace(record.StartLocation) || string.IsNullOrWhiteSpace(record.EndLocation))
                    {
                        Console.WriteLine($"Skipping invalid record at row {rowNumber}: StartLocation or EndLocation is empty.");
                        continue;
                    }

                    if (!context.TaxiRoutes.Any(tr =>
                        tr.StartLocation == record.StartLocation &&
                        tr.EndLocation == record.EndLocation))
                    {
                        context.TaxiRoutes.Add(new TaxiRoute
                        {
                            StartLocation = record.StartLocation,
                            EndLocation = record.EndLocation,
                            Fare = record.Fare,
                            PickupLocation = record.PickupLocation // Will be null if not in CSV
                        });
                        addedRecords++;
                    }
                }

                if (addedRecords > 0)
                {
                    await context.SaveChangesAsync();
                    Console.WriteLine($"Successfully seeded {addedRecords} taxi routes from CSV.");
                }
                else
                {
                    Console.WriteLine("No new taxi routes were added (all records already exist).");
                }
            }
            catch (CsvHelper.ReaderException ex)
            {
                Console.WriteLine($"Error reading CSV file at line {rowNumber}: {ex.Message}");
                Console.WriteLine("Please check your CSV file for formatting errors.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during seeding at line {rowNumber}: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
            }
        }
    }
}