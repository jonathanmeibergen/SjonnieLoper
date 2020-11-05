using Microsoft.EntityFrameworkCore.Migrations;

namespace SjonieLoper.Services.Migrations
{
    public partial class AppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a12c608-957a-4fed-8407-4cc0c28e8d7e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46aa1e64-dfb6-4bd1-a14b-df4058e0dc2f", 0, "dc56781e-b16d-4520-8f3b-c53b5d90df47", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMQb722GBuptKqjjlc8a6xXik82GEIs4MIwTTBoYelUo6R6xzZn2Yp19ThBUfHmFSA==", null, false, "08d922f3-61da-4a0e-af3e-f012924072e2", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "Role", "Admin", "46aa1e64-dfb6-4bd1-a14b-df4058e0dc2f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46aa1e64-dfb6-4bd1-a14b-df4058e0dc2f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a12c608-957a-4fed-8407-4cc0c28e8d7e", 0, "e5dff816-6d3f-4ce4-a7d7-1c1c48623c62", "admin@admin.com", true, true, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEErTabIjSvZ6QPniz820FwI4DreekdLlMxswi4H6JE9vF3IIa+biCm8J0U29T/Ruyg==", null, false, "d71f17ac-800d-4ec2-b92f-148ebd8cda21", false, "admin@admin.com" });
        }
    }
}
