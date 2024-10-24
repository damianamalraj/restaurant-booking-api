using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantBookingApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "MenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "MenuItems");
        }
    }
}
