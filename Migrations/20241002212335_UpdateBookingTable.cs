using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantBookingApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "Bookings",
                newName: "StartBookingDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndBookingDateTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndBookingDateTime",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "StartBookingDateTime",
                table: "Bookings",
                newName: "BookingDate");
        }
    }
}
