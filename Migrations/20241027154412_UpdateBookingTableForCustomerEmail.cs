using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantBookingApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingTableForCustomerEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Bookings");
        }
    }
}
