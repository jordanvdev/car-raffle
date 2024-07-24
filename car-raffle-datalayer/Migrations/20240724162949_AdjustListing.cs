using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace car_raffle_datalayer.Migrations
{
    /// <inheritdoc />
    public partial class AdjustListing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TicketPrice",
                table: "Listings",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Listings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Listings");

            migrationBuilder.AlterColumn<int>(
                name: "TicketPrice",
                table: "Listings",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
