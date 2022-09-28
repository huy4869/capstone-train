using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Migrations
{
    public partial class DBinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "char(52)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    continent = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    region = table.Column<string>(type: "char(26)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    surfaceArea = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    indepYear = table.Column<short>(type: "smallint", nullable: true),
                    population = table.Column<int>(type: "int", nullable: true),
                    lifeExpectancy = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    GNP = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    GNPOld = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    localName = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    governmentForm = table.Column<string>(type: "char(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    headOfState = table.Column<string>(type: "char(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    capital = table.Column<int>(type: "int", nullable: true),
                    code2 = table.Column<string>(type: "char(2)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCode", x => x.Code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "char(35)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    countryCode = table.Column<string>(type: "char(3)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    district = table.Column<string>(type: "char(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.Id);
                    table.ForeignKey(
                        name: "FK_city_country",
                        column: x => x.countryCode,
                        principalTable: "country",
                        principalColumn: "Code");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "Idx_FirstName",
                table: "city",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "IX_city_countryCode",
                table: "city",
                column: "countryCode");

            migrationBuilder.CreateIndex(
                name: "Idx_Name",
                table: "country",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
