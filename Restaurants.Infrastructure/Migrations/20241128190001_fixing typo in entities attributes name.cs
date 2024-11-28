using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixingtypoinentitiesattributesname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriotion",
                table: "Restaurants",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Descritopn",
                table: "Dishes",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Restaurants",
                newName: "Descriotion");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Dishes",
                newName: "Descritopn");
        }
    }
}
