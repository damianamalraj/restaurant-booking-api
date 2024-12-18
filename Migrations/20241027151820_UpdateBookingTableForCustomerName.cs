﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantBookingApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingTableForCustomerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Bookings");
        }
    }
}
