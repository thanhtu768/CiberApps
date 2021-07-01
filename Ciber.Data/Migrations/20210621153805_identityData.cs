using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ciber.Data.Migrations
{
    public partial class identityData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cutomers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Cutomers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Cutomers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("334d0ec7-5f04-4c52-8bf6-3957e82466d9"), 0, "84646d49-8782-4473-a9c6-6cdfde3152de", "thanhtu@gmail.com", true, false, null, "thanhtu@gmail.com", "customer", "AQAAAAEAACcQAAAAEAV5gRSobjiohONJJhUAXIW3bZNZ/NAl3ZPcdRBrGPom3hP/AjvV6H5lh8T6gXhOkQ==", null, false, "", false, "Thanh Tu" });

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
                columns: new[] { "CustomerID", "OrderDate" },
                values: new object[] { 1, new DateTime(2021, 6, 21, 22, 38, 4, 420, DateTimeKind.Local).AddTicks(2632) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("d177a779-b8cb-460f-999f-efa33e38ae30"), "8c8a7773-090e-44fb-b26f-eb9f9588abeb", "Customer Role", "customer", "customer" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d177a779-b8cb-460f-999f-efa33e38ae30"), new Guid("334d0ec7-5f04-4c52-8bf6-3957e82466d9") });

            migrationBuilder.UpdateData(
                table: "Cutomers",
                keyColumn: "ID",
                keyValue: 1,
                column: "UserID",
                value: new Guid("334d0ec7-5f04-4c52-8bf6-3957e82466d9"));

            migrationBuilder.CreateIndex(
                name: "IX_Cutomers_UserID",
                table: "Cutomers",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cutomers_AppUsers_UserID",
                table: "Cutomers",
                column: "UserID",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cutomers_AppUsers_UserID",
                table: "Cutomers");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropIndex(
                name: "IX_Cutomers_UserID",
                table: "Cutomers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Cutomers");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Cutomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cutomers",
                keyColumn: "ID",
                keyValue: 1,
                column: "Password",
                value: "123");

            migrationBuilder.InsertData(
                table: "Cutomers",
                columns: new[] { "ID", "Address", "Name", "Password" },
                values: new object[] { 2, "HaNoi", "Tuan Tu", "123" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 6, 21, 21, 24, 4, 51, DateTimeKind.Local).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2021, 6, 21, 21, 24, 4, 52, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CustomerID", "OrderDate" },
                values: new object[] { 2, new DateTime(2021, 6, 21, 21, 24, 4, 52, DateTimeKind.Local).AddTicks(5954) });
        }
    }
}
