using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantBookingApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingTableForTableNumberColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableNumber",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableNumber",
                table: "Bookings");
        }
    }
}
