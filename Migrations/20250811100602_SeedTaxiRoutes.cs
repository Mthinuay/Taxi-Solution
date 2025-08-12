using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Adingisa.Migrations
{
    /// <inheritdoc />
    public partial class SeedTaxiRoutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaxiRoutes",
                columns: new[] { "TaxiRouteId", "EndLocation", "Fare", "PickupLocation", "StartLocation", "TaxiLocationId" },
                values: new object[,]
                {
                    { 1, "Pretoria", 60m, "MTN Rank Stand 2", "MTN Noord Rank", null },
                    { 2, "Rustenburg", 210m, "Bosman Station Stand 5", "Bosman Station", null },
                    { 3, "Randburg", 18m, "Noord Rank Stand 10", "Noord Rank Stand 10", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaxiRoutes",
                keyColumn: "TaxiRouteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxiRoutes",
                keyColumn: "TaxiRouteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaxiRoutes",
                keyColumn: "TaxiRouteId",
                keyValue: 3);
        }
    }
}
