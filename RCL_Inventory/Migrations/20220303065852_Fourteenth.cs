using Microsoft.EntityFrameworkCore.Migrations;

namespace RCL_Inventory.Migrations
{
    public partial class Fourteenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "PostalCode", "Province", "Street" },
                values: new object[] { 1, "Toronto", "Canada", "N2K 3P4", "Ontario", "32 Dundas Street" });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "AccountNumber", "AddressId", "Name", "Telephone" },
                values: new object[] { 1, "121314151", 1, "Samsung", "544222333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);
        }
    }
}
