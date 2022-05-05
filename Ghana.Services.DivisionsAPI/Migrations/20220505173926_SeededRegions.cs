using Microsoft.EntityFrameworkCore.Migrations;

namespace Ghana.Services.DivisionsAPI.Migrations
{
    public partial class SeededRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionCode", "CapitalCity", "Name" },
                values: new object[,]
                {
                    { "ASX", "Kumasi", "Ashanti" },
                    { "GRX", "Accra", "Greater Accra" },
                    { "BNX", "Sunyani", "Bono Region" },
                    { "BEX", "Techiman", "Bono East Region" },
                    { "HAX", "Goaso", "Ahafo Region" },
                    { "CNX", "Cape Coast", "Central" },
                    { "EAX", "Koforidua", "Eastern" },
                    { "NRX", "Tamale", "Northern" },
                    { "SVX", "Damongo", "Savannah" },
                    { "NEX", "Nalerigu", "North East" },
                    { "UWX", "Wa", "Upper West" },
                    { "UEX", "Bolgatanga", "Upper East" },
                    { "VLX", "Ho", "Volta Region" },
                    { "OTX", "Dambai", "Oti" },
                    { "WSX", "Takoradi", "Western Region" },
                    { "WNX", "Wiawso", "Western North" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "ASX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "BEX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "BNX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "CNX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "EAX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "GRX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "HAX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "NEX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "NRX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "OTX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "SVX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "UEX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "UWX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "VLX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "WNX");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionCode",
                keyValue: "WSX");
        }
    }
}
