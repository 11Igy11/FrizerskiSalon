using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrizerskiSalon1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reservations",
                newName: "ReservationDate");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ReservationDate",
                table: "Reservations",
                newName: "Date");
        }
    }
}
