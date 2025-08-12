using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adingisa.Migrations
{
    /// <inheritdoc />
    public partial class AddFareAndPickupToTaxiRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Fare",
                table: "TaxiRoutes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PickupLocation",
                table: "TaxiRoutes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fare",
                table: "TaxiRoutes");

            migrationBuilder.DropColumn(
                name: "PickupLocation",
                table: "TaxiRoutes");
        }
    }
}
