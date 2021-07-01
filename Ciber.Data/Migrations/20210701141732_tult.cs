using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciber.Data.Migrations
{
    public partial class tult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("334d0ec7-5f04-4c52-8bf6-3957e82466d9"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "UserName" },
                values: new object[] { "6fe61d3e-950a-4e1b-8489-178e7558218b", "admin", "AQAAAAEAACcQAAAAEDziU+7isIqci8ZO66bY1rvmNadpMPuWGcx1Cedzf5xXMEvIMN7JRFU7cgGU4aRF9g==", "0941079795", true, "admin" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 7, 1, 21, 17, 32, 89, DateTimeKind.Local).AddTicks(2133));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 7, 1, 21, 17, 32, 89, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2021, 7, 1, 21, 17, 32, 89, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d177a779-b8cb-460f-999f-efa33e38ae30"),
                column: "ConcurrencyStamp",
                value: "8ccdfe93-a318-4bd6-a231-6b62bb96809f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("334d0ec7-5f04-4c52-8bf6-3957e82466d9"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "UserName" },
                values: new object[] { "b9e755de-1b14-42b9-828c-5bb592fd5e5c", "THANHTU", "AQAAAAEAACcQAAAAELzVrm7tToUfKotB6o9XM/Q5nhLPhRw117m9JVLrniog4db9hGoAyd9dUY9wL06a6g==", null, false, "TULT" });

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
    }
}
