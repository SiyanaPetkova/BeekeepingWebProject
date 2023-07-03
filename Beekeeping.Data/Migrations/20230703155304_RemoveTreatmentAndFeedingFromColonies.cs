using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class RemoveTreatmentAndFeedingFromColonies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeeColonies_HiveFeeding_FeedingId",
                table: "BeeColonies");

            migrationBuilder.DropForeignKey(
                name: "FK_BeeColonies_HiveTreatments_TreatmentId",
                table: "BeeColonies");

            migrationBuilder.DropIndex(
                name: "IX_BeeColonies_FeedingId",
                table: "BeeColonies");

            migrationBuilder.DropIndex(
                name: "IX_BeeColonies_TreatmentId",
                table: "BeeColonies");

            migrationBuilder.DropColumn(
                name: "FeedingId",
                table: "BeeColonies");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "BeeColonies");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTreatedColonies",
                table: "HiveTreatments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DayOfFeeding",
                table: "HiveFeeding",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBeeHives",
                table: "HiveFeeding",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfTreatedColonies",
                table: "HiveTreatments");

            migrationBuilder.DropColumn(
                name: "DayOfFeeding",
                table: "HiveFeeding");

            migrationBuilder.DropColumn(
                name: "NumberOfBeeHives",
                table: "HiveFeeding");

            migrationBuilder.AddColumn<int>(
                name: "FeedingId",
                table: "BeeColonies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "BeeColonies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BeeColonies_FeedingId",
                table: "BeeColonies",
                column: "FeedingId");

            migrationBuilder.CreateIndex(
                name: "IX_BeeColonies_TreatmentId",
                table: "BeeColonies",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeeColonies_HiveFeeding_FeedingId",
                table: "BeeColonies",
                column: "FeedingId",
                principalTable: "HiveFeeding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BeeColonies_HiveTreatments_TreatmentId",
                table: "BeeColonies",
                column: "TreatmentId",
                principalTable: "HiveTreatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
