using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingIdentityUserRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "caf823cd-03d5-4f7c-bd2f-ea9d9997ba08", "26924a17-e743-4448-b470-25d2bc56f1e9" },
                    { "2cb604f2-c562-4237-8fb7-76561a77d9bf", "4dd8f193-e496-48aa-b667-285df6493294" },
                    { "a40ecab9-5e65-4682-94da-20094bd75d4c", "fd7b6988-559b-4acf-b8e0-7c6284cbd6a9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "caf823cd-03d5-4f7c-bd2f-ea9d9997ba08", "26924a17-e743-4448-b470-25d2bc56f1e9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2cb604f2-c562-4237-8fb7-76561a77d9bf", "4dd8f193-e496-48aa-b667-285df6493294" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a40ecab9-5e65-4682-94da-20094bd75d4c", "fd7b6988-559b-4acf-b8e0-7c6284cbd6a9" });
        }
    }
}
