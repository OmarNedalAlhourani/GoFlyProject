using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoFly.EF.Migrations
{
    /// <inheritdoc />
    public partial class Omateokd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "TodayFlights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "TodayFlights",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
