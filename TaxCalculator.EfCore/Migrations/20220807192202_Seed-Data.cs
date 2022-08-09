using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxCalculator.EfCore.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaxYears",
                columns: new[] { "IsoCountryCode", "Year" },
                values: new object[] { "GBR", 2022 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "IsoCountryCode", "PercentRate", "RangeLowerBound", "RangeUpperBound", "TaxYear" },
                values: new object[] { 1, "GBR", 0m, 0m, 5000m, 2022 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "IsoCountryCode", "PercentRate", "RangeLowerBound", "RangeUpperBound", "TaxYear" },
                values: new object[] { 2, "GBR", 20m, 5000m, 20000m, 2022 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "IsoCountryCode", "PercentRate", "RangeLowerBound", "RangeUpperBound", "TaxYear" },
                values: new object[] { 3, "GBR", 40m, 20000m, 0m, 2022 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaxYears",
                keyColumns: new[] { "IsoCountryCode", "Year" },
                keyValues: new object[] { "GBR", 2022 });
        }
    }
}
