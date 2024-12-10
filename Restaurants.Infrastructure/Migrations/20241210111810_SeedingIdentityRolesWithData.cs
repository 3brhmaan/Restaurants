using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingIdentityRolesWithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cb604f2-c562-4237-8fb7-76561a77d9bf", null, "Admin", null },
                    { "33452fcb-c946-4b29-89ef-7e4435147756", null, "User", null },
                    { "9e3e8524-eda9-4d1c-b9cc-9ba4cac96f86", null, "Owner", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cb604f2-c562-4237-8fb7-76561a77d9bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33452fcb-c946-4b29-89ef-7e4435147756");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e3e8524-eda9-4d1c-b9cc-9ba4cac96f86");
        }
    }
}
