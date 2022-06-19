using Microsoft.EntityFrameworkCore.Migrations;

namespace RCL_Inventory.Migrations
{
    public partial class twelveth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolerRoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roler",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roler", x => x.RoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolerRoleId",
                table: "Users",
                column: "RolerRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roler_RolerRoleId",
                table: "Users",
                column: "RolerRoleId",
                principalTable: "Roler",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roler_RolerRoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roler");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolerRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RolerRoleId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
