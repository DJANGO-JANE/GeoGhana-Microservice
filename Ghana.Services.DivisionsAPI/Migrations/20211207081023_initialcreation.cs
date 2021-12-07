using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghana.Services.DivisionsAPI.Migrations
{
    public partial class initialcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CapitalCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionCode);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityCode = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegionCode = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityCode);
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
                    ConstID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LocalityCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    RegionCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    CityCode = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Localities_Regions_RegionCode",
                        column: x => x.RegionCode,
                        principalTable: "Regions",
                        principalColumn: "RegionCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionCode",
                table: "Cities",
                column: "RegionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_CityCode",
                table: "Localities",
                column: "CityCode");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_RegionCode",
                table: "Localities",
                column: "RegionCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
