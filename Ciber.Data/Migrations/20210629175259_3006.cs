using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciber.Data.Migrations
{
    public partial class _3006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("334d0ec7-5f04-4c52-8bf6-3957e82466d9"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "b9e755de-1b14-42b9-828c-5bb592fd5e5c", "THANHTU", "AQAAAAEAACcQAAAAELzVrm7tToUfKotB6o9XM/Q5nhLPhRw117m9JVLrniog4db9hGoAyd9dUY9wL06a6g==", "TULT" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 6, 30, 0, 52, 59, 289, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 6, 30, 0, 52, 59, 290, DateTimeKind.Local).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2021, 6, 30, 0, 52, 59, 290, DateTimeKind.Local).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d177a779-b8cb-460f-999f-efa33e38ae30"),
                column: "ConcurrencyStamp",
                value: "eb625fe3-48d9-40fd-bfd8-617838d46974");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("334d0ec7-5f04-4c52-8bf6-3957e82466d9"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "84646d49-8782-4473-a9c6-6cdfde3152de", "customer", "AQAAAAEAACcQAAAAEAV5gRSobjiohONJJhUAXIW3bZNZ/NAl3ZPcdRBrGPom3hP/AjvV6H5lh8T6gXhOkQ==", "Thanh Tu" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 6, 21, 22, 38, 4, 419, DateTimeKind.Local).AddTicks(5706));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 6, 21, 22, 38, 4, 420, DateTimeKind.Local).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2021, 6, 21, 22, 38, 4, 420, DateTimeKind.Local).AddTicks(2632));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d177a779-b8cb-460f-999f-efa33e38ae30"),
                column: "ConcurrencyStamp",
                value: "8c8a7773-090e-44fb-b26f-eb9f9588abeb");
        }
    }
}
