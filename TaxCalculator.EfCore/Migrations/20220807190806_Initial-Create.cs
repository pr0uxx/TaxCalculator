using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxCalculator.EfCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxYears",
                columns: table => new
                {
                    Year = table.Column<int>(type: "int", nullable: false),
                    IsoCountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxYears", x => new { x.IsoCountryCode, x.Year });
                });

            migrationBuilder.CreateTable(
                name: "TaxBands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RangeLowerBound = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RangeUpperBound = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PercentRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxYear = table.Column<int>(type: "int", nullable: false),
                    IsoCountryCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxBands_TaxYears_IsoCountryCode_TaxYear",
                        columns: x => new { x.IsoCountryCode, x.TaxYear },
                        principalTable: "TaxYears",
                        principalColumns: new[] { "IsoCountryCode", "Year" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxBands_IsoCountryCode_TaxYear",
                table: "TaxBands",
                columns: new[] { "IsoCountryCode", "TaxYear" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxBands");

            migrationBuilder.DropTable(
                name: "TaxYears");
        }
    }
}
