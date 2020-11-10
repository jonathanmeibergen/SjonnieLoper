using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SjonnieLoper.Services.Migrations
{
    public partial class initmigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Whiskeys_WhiskeyTypes_WhiskeyTypeId",
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
                name: "Name",
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

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Whiskeys",
                nullable: true);

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
                    WhiskeyId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storage_Whiskeys_WhiskeyId",
                        column: x => x.WhiskeyId,
                        principalTable: "Whiskeys",
                        principalColumn: "WhiskeyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ad3ade46-6936-4030-8c87-fb0c2aaa0f1d", 0, "a337688c-87d6-4e47-8e80-bf43e8133855", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEEzv+WLypqP9fyqbsCOgszXVOCSQxxHcwpeUnOLRC/FpZd4hRqIzhqp8F+VhMT02ag==", null, false, "c39d26ca-18b1-425c-ab01-519a6fcd16e1", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "Role", "Admin", "ad3ade46-6936-4030-8c87-fb0c2aaa0f1d" });

            migrationBuilder.CreateIndex(
                name: "IX_Whiskeys_ReservationId",
                table: "Whiskeys",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Customer",
                table: "Reservations",
                column: "Customer");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_WhiskeyId",
                table: "Storage",
                column: "WhiskeyId");

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
                keyValue: "ad3ade46-6936-4030-8c87-fb0c2aaa0f1d");

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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Whiskeys",
                type: "nvarchar(max)",
                nullable: true);

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
