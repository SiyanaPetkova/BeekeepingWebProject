using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class AddingCreatorForFeedingAndTreatment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "HiveTreatments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "HiveFeeding",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "HiveTreatments");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "HiveFeeding");
        }
    }
}
