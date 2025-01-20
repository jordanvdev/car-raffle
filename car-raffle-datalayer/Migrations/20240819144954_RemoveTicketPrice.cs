﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_raffle_datalayer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTicketPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
