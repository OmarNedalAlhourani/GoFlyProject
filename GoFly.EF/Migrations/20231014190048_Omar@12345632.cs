using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoFly.EF.Migrations
{
    /// <inheritdoc />
    public partial class Omar12345632 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripFlights");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TripFlights",
                columns: table => new
                {
                    TripFlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDleted = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripFlights", x => x.TripFlightId);
                });
        }
    }
}
