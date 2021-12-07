using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghana.Services.PopulationAPI.Migrations
{
    public partial class AddPopulationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Population",
                columns: table => new
                {
                    DivisionCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Citizens = table.Column<int>(type: "int", nullable: false),
                    Male = table.Column<int>(type: "int", nullable: false),
                    Female = table.Column<int>(type: "int", nullable: false),
                    ElderlyMale = table.Column<int>(type: "int", nullable: false),
                    ElderlyFemale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Population", x => x.DivisionCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Population");
        }
    }
}
