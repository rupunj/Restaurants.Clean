using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Clean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addkilocal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "KilloCal",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KilloCal",
                table: "Dishes");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Description", "Name", "Price", "RestaurantId" },
                values: new object[] { 1, "Pizza with tomato sauce", "Pizza", 10m, 1 });
        }
    }
}
