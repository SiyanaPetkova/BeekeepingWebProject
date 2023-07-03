using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class ChangeBeeQueenTypeAndMakeOneToOneRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeeQueens_BeeColonies_BeeColonyId",
                table: "BeeQueens");

            migrationBuilder.DropIndex(
                name: "IX_BeeQueens_BeeColonyId",
                table: "BeeQueens");

            migrationBuilder.DropColumn(
                name: "BeeColonyId",
                table: "BeeQueens");

            migrationBuilder.AlterColumn<string>(
                name: "BeeQueenType",
                table: "BeeQueens",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeeQueenId",
                table: "BeeColonies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BeeColonies_BeeQueenId",
                table: "BeeColonies",
                column: "BeeQueenId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BeeColonies_BeeQueens_BeeQueenId",
                table: "BeeColonies",
                column: "BeeQueenId",
                principalTable: "BeeQueens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeeColonies_BeeQueens_BeeQueenId",
                table: "BeeColonies");

            migrationBuilder.DropIndex(
                name: "IX_BeeColonies_BeeQueenId",
                table: "BeeColonies");

            migrationBuilder.DropColumn(
                name: "BeeQueenId",
                table: "BeeColonies");

            migrationBuilder.AlterColumn<int>(
                name: "BeeQueenType",
                table: "BeeQueens",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BeeColonyId",
                table: "BeeQueens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BeeQueens_BeeColonyId",
                table: "BeeQueens",
                column: "BeeColonyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeeQueens_BeeColonies_BeeColonyId",
                table: "BeeQueens",
                column: "BeeColonyId",
                principalTable: "BeeColonies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
