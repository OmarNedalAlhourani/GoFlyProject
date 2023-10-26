using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoFly.EF.Migrations
{
    /// <inheritdoc />
    public partial class OmatOMar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirLine",
                table: "TodayFlights");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TodayFlights");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "TodayFlights");

            migrationBuilder.DropColumn(
                name: "Prise",
                table: "TodayFlights");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "TravelBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TripFlights",
                columns: table => new
                {
                    TripFlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripFlights", x => x.TripFlightId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripFlights");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "TravelBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirLine",
                table: "TodayFlights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "TodayFlights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TodayFlights",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prise",
                table: "TodayFlights",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
