using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class AddCoordinatesToApiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Apiaries",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Apiaries",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Apiaries");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Apiaries");
        }
    }
}
