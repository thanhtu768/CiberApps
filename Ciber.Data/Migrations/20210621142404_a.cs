using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciber.Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductID",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A1,A2,A3,A4", "Paper" },
                    { 2, "pencil", "Pencil" }
                });

            migrationBuilder.InsertData(
                table: "Cutomers",
                columns: new[] { "ID", "Address", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "HaNoi", "Thanh Tu", "123" },
                    { 2, "HaNoi", "Tuan Tu", "123" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 1, 1, "A4 Canon Description", "A4 Canon", 10000m, 100 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 2, 1, "A4 Casio Description", "A4 Casio", 14000m, 10 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 3, 2, "Pencil Description", "Pencil 1", 15000m, 100 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Amount", "CustomerID", "OrderDate", "ProductID" },
                values: new object[] { 1, 2, 1, new DateTime(2021, 6, 21, 21, 24, 4, 51, DateTimeKind.Local).AddTicks(9064), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Amount", "CustomerID", "OrderDate", "ProductID" },
                values: new object[] { 2, 32, 1, new DateTime(2021, 6, 21, 21, 24, 4, 52, DateTimeKind.Local).AddTicks(5932), 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "Amount", "CustomerID", "OrderDate", "ProductID" },
                values: new object[] { 3, 11, 2, new DateTime(2021, 6, 21, 21, 24, 4, 52, DateTimeKind.Local).AddTicks(5954), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductID",
                table: "Orders",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductID",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cutomers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cutomers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductID",
                table: "Orders",
                column: "ProductID",
                unique: true);
        }
    }
}
