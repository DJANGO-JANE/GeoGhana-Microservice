using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghana.Services.PopulationAPI.Migrations
{
    public partial class ExtendedDivisionsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Population",
                table: "Population");

            migrationBuilder.AlterColumn<string>(
                name: "DivisionCode",
                table: "Population",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "PopulationId",
                table: "Population",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Population",
                table: "Population",
                column: "PopulationId");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CapitalCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PopulationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionCode);
                    table.ForeignKey(
                        name: "FK_Regions_Population_PopulationId",
                        column: x => x.PopulationId,
                        principalTable: "Population",
                        principalColumn: "PopulationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityCode = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegionCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    PopulationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityCode);
                    table.ForeignKey(
                        name: "FK_Cities_Population_PopulationId",
                        column: x => x.PopulationId,
                        principalTable: "Population",
                        principalColumn: "PopulationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionCode",
                        column: x => x.RegionCode,
                        principalTable: "Regions",
                        principalColumn: "RegionCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    ConstID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LocalityCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    RegionCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    CityCode = table.Column<int>(type: "int", nullable: false),
                    PopulationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.ConstID);
                    table.ForeignKey(
                        name: "FK_Localities_Cities_CityCode",
                        column: x => x.CityCode,
                        principalTable: "Cities",
                        principalColumn: "CityCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Localities_Population_PopulationId",
                        column: x => x.PopulationId,
                        principalTable: "Population",
                        principalColumn: "PopulationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Localities_Regions_RegionCode",
                        column: x => x.RegionCode,
                        principalTable: "Regions",
                        principalColumn: "RegionCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_PopulationId",
                table: "Cities",
                column: "PopulationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionCode",
                table: "Cities",
                column: "RegionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_CityCode",
                table: "Localities",
                column: "CityCode");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_PopulationId",
                table: "Localities",
                column: "PopulationId");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_RegionCode",
                table: "Localities",
                column: "RegionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_PopulationId",
                table: "Regions",
                column: "PopulationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Population",
                table: "Population");

            migrationBuilder.DropColumn(
                name: "PopulationId",
                table: "Population");

            migrationBuilder.AlterColumn<string>(
                name: "DivisionCode",
                table: "Population",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Population",
                table: "Population",
                column: "DivisionCode");
        }
    }
}
