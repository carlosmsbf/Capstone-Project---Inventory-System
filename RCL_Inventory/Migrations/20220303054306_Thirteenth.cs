using Microsoft.EntityFrameworkCore.Migrations;

namespace RCL_Inventory.Migrations
{
    public partial class Thirteenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Cellphone");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "TV");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Laptop");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 4, "Gaming Console" },
                    { 5, "Tablet" },
                    { 6, "Home Appliances" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 2, "55 inch 4K OLED Smart TV", "LG OLED TV" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 2, "75 inch 8K QLED Smart TV", "Samsung QLED TV" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "65 inch 4K Smart TV", "Samsung Smart TV" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 2, "75 inch 4K HDR LED Smart TV", "Sony X80J TV" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 13, 3, "8-Core CPU, 32GB RAM, 500GB SSD, 1TB HD, GPU 14-core, 16 inch display", "Apple MacBook Pro" },
                    { 11, 3, "8-Core CPU, 16GB RAM, 250GB SSD, 500GB HD, GPU 14-core, 14 inch display", "Apple MacBook Pro" },
                    { 10, 3, "CPU Intel i7-7700M, 16GB RAM, 500GB SSD, 1TB HDD, GPU GeForce 3060RTX, 17.3 inch display", "MSI Laptop" },
                    { 9, 1, "6.43 inch display, 1080x2400 pixels, 50MP Camera, 6GB RAM, 256GB, Android 11", "Xiaomi Redmi Note 11" },
                    { 8, 1, "6.1 inch display, 1170x2532 pixels, 12MP Camera, 4GB RAM, 128GB, iOS 15", "Iphone 13" },
                    { 7, 1, "6.7 inch display, 1284x2778 pixels, 12MP Camera, 6GB RAM, 512GB, iOS 15", "Iphone 13 Pro Max" },
                    { 6, 1, "6.4 inch display, 1080x2400 pixels, 12MP Camera, 8GB RAM, 500GB, Android 12", "Samsung Galaxy S21" },
                    { 5, 1, "6.1 inch display, 1080x2340 pixels, 50MP Camera, 8GB RAM, 250GB, Android 12", "Samsung Galaxy S22" },
                    { 12, 3, "CPU Intel i9-9500M, 32GB RAM, 500GB SSD, 1TB HDD, GPU GeForce 3090RTX, 17.3 inch display", "AlienWare Laptop" }
                });

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "TransactionTypeId",
                keyValue: 3,
                column: "Name",
                value: "Loss");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 14, 4, "Xbox Series X gaming console, with 2 wireless controllers", "Xbox Series X" },
                    { 15, 4, "PlayStation 5 gaming console, with 1 wireless controller", "PlayStation 5" },
                    { 16, 5, "Ipad 10.2 display, 6GB RAM, 500GB, 12MP Camera, iOS 15", "Apple Ipad" },
                    { 17, 5, "8.7 inch display, 32GB, Android 12", "Samsung Galaxy Tab A7" },
                    { 18, 6, "1.5cu, Countertop Microwave with Smart Inverter and EasyClean", "LG Microwave NeoChef" },
                    { 19, 6, "1.7cu, Over-the-Range Microwave Oven with EasyClean", "LG Microwave OTR" },
                    { 20, 6, "4.8L capacity, Stainless Steel, Hot air, 60 minutes timer", "Insignia Air Fryer" },
                    { 21, 6, "2-Slice toaster in chrome, high-lift boost toast function, Extra-wide slots", "Hamilton Beach Toaster" },
                    { 22, 6, "Nespresso Vertuo Coffee & Espresso Machine by DeLonghi w/ Aeroccino Milk Frother, Black", "Nespresso Vertuo Coffee" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Name",
                value: "Furniture");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "Name",
                value: "Office Equipment");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Repairs and Maintenance");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 1, "", "Table" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 3, "", "Pencil" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "Pen" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 3, "", "Pencil" });

            migrationBuilder.UpdateData(
                table: "TransactionTypes",
                keyColumn: "TransactionTypeId",
                keyValue: 3,
                column: "Name",
                value: "Lose");
        }
    }
}
