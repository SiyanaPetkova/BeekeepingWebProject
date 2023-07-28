using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class RemoveYearOfBeeQueenBirthFromInspection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeeQueenYearOfBirth",
                table: "Inspections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeeQueenYearOfBirth",
                table: "Inspections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
