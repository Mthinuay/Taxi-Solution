using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Adingisa.Migrations
{
    /// <inheritdoc />
    public partial class ImportTaxiRoutesFromCsv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_TaxiRoutes_TaxiRouteId",
                table: "Comments");

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

            migrationBuilder.AlterColumn<string>(
                name: "StartLocation",
                table: "TaxiRoutes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PickupLocation",
                table: "TaxiRoutes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Fare",
                table: "TaxiRoutes",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "EndLocation",
                table: "TaxiRoutes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_TaxiRoutes_TaxiRouteId",
                table: "Comments",
                column: "TaxiRouteId",
                principalTable: "TaxiRoutes",
                principalColumn: "TaxiRouteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_TaxiRoutes_TaxiRouteId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "StartLocation",
                table: "TaxiRoutes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PickupLocation",
                table: "TaxiRoutes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Fare",
                table: "TaxiRoutes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "EndLocation",
                table: "TaxiRoutes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.InsertData(
                table: "TaxiRoutes",
                columns: new[] { "TaxiRouteId", "EndLocation", "Fare", "PickupLocation", "StartLocation", "TaxiLocationId" },
                values: new object[,]
                {
                    { 1, "Pretoria", 60m, "MTN Rank Stand 2", "MTN Noord Rank", null },
                    { 2, "Rustenburg", 210m, "Bosman Station Stand 5", "Bosman Station", null },
                    { 3, "Randburg", 18m, "Noord Rank Stand 10", "Noord Rank Stand 10", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_TaxiRoutes_TaxiRouteId",
                table: "Comments",
                column: "TaxiRouteId",
                principalTable: "TaxiRoutes",
                principalColumn: "TaxiRouteId");
        }
    }
}
