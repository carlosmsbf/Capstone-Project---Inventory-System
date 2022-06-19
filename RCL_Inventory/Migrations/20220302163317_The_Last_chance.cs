using Microsoft.EntityFrameworkCore.Migrations;

namespace RCL_Inventory.Migrations
{
    public partial class The_Last_chance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transaction_SupplierId",
                table: "Transaction",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Suppliers_SupplierId",
                table: "Transaction",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Suppliers_SupplierId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_SupplierId",
                table: "Transaction");
        }
    }
}
