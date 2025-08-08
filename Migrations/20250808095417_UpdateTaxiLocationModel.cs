using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adingisa.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTaxiLocationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPSCoordinates",
                table: "TaxiLocations");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TaxiLocations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TaxiLocations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "TaxiLocations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "TaxiLocations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TaxiLocations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TaxiLocations");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TaxiLocations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TaxiLocations");

            migrationBuilder.AddColumn<string>(
                name: "GPSCoordinates",
                table: "TaxiLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
