using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SjonnieLoper.Services.Migrations
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Whiskeys_WhiskeyTypes_WhiskeyTypeId",
                table: "Whiskeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Whiskeys",
                table: "Whiskeys");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46aa1e64-dfb6-4bd1-a14b-df4058e0dc2f");

            migrationBuilder.DropColumn(
                name: "WhiskeyId",
                table: "Whiskeys");

            migrationBuilder.AlterColumn<int>(
                name: "WhiskeyTypeId",
                table: "Whiskeys",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Origin",
                table: "Whiskeys",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Whiskeys",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Whiskeys",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Whiskeys",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Whiskeys",
                table: "Whiskeys",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orderdate = table.Column<DateTime>(nullable: false),
                    Customer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_Customer",
                        column: x => x.Customer,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    whiskeyId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storage_Whiskeys_whiskeyId",
                        column: x => x.whiskeyId,
                        principalTable: "Whiskeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "481a37b8-df10-4d48-9889-4b8db7cb2699", 0, "86792b02-72d2-4a2f-a4b4-89a7730fef42", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMIAQedLrs3aIWFdoAg6OdRkG/AauYB1et3mdvw+Fd1MyVMrEoI+v3wdrtT9F44z7A==", null, false, "608ab47b-3712-42a4-95f3-5d6e2b2cece1", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "Role", "Admin", "481a37b8-df10-4d48-9889-4b8db7cb2699" });

            migrationBuilder.CreateIndex(
                name: "IX_Whiskeys_ReservationId",
                table: "Whiskeys",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Customer",
                table: "Reservations",
                column: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_whiskeyId",
                table: "Storage",
                column: "whiskeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Whiskeys_Reservations_ReservationId",
                table: "Whiskeys",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Whiskeys_WhiskeyTypes_WhiskeyTypeId",
                table: "Whiskeys",
                column: "WhiskeyTypeId",
                principalTable: "WhiskeyTypes",
                principalColumn: "WhiskeyTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Whiskeys_Reservations_ReservationId",
                table: "Whiskeys");

            migrationBuilder.DropForeignKey(
                name: "FK_Whiskeys_WhiskeyTypes_WhiskeyTypeId",
                table: "Whiskeys");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Whiskeys",
                table: "Whiskeys");

            migrationBuilder.DropIndex(
                name: "IX_Whiskeys_ReservationId",
                table: "Whiskeys");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "481a37b8-df10-4d48-9889-4b8db7cb2699");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Whiskeys");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Whiskeys");

            migrationBuilder.AlterColumn<int>(
                name: "WhiskeyTypeId",
                table: "Whiskeys",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Origin",
                table: "Whiskeys",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Whiskeys",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "WhiskeyId",
                table: "Whiskeys",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Whiskeys",
                table: "Whiskeys",
                column: "WhiskeyId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46aa1e64-dfb6-4bd1-a14b-df4058e0dc2f", 0, "dc56781e-b16d-4520-8f3b-c53b5d90df47", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMQb722GBuptKqjjlc8a6xXik82GEIs4MIwTTBoYelUo6R6xzZn2Yp19ThBUfHmFSA==", null, false, "08d922f3-61da-4a0e-af3e-f012924072e2", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "Role", "Admin", "46aa1e64-dfb6-4bd1-a14b-df4058e0dc2f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Whiskeys_WhiskeyTypes_WhiskeyTypeId",
                table: "Whiskeys",
                column: "WhiskeyTypeId",
                principalTable: "WhiskeyTypes",
                principalColumn: "WhiskeyTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
