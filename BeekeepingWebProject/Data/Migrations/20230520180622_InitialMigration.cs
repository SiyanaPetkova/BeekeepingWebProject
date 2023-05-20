using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeekeepingWebProject.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NumberOfHives = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apiaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HiveTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActiveIngredient = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    TreatmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiveTreatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeeHives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<int>(type: "int", nullable: false),
                    NumberOfFrames = table.Column<int>(type: "int", nullable: false),
                    NumberOfBroodFrames = table.Column<int>(type: "int", nullable: false),
                    AdditionalComмent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiaryId = table.Column<int>(type: "int", nullable: false),
                    TreatmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeeHives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeeHives_Apiaries_ApiaryId",
                        column: x => x.ApiaryId,
                        principalTable: "Apiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeeHives_HiveTreatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "HiveTreatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeeQueens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Breeder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeeQueenType = table.Column<int>(type: "int", nullable: true),
                    BeeQueenYearOfBirth = table.Column<int>(type: "int", nullable: false),
                    BeeHiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeeQueens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeeQueens_BeeHives_BeeHiveId",
                        column: x => x.BeeHiveId,
                        principalTable: "BeeHives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeeHives_ApiaryId",
                table: "BeeHives",
                column: "ApiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_BeeHives_TreatmentId",
                table: "BeeHives",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BeeQueens_BeeHiveId",
                table: "BeeQueens",
                column: "BeeHiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeeQueens");

            migrationBuilder.DropTable(
                name: "BeeHives");

            migrationBuilder.DropTable(
                name: "Apiaries");

            migrationBuilder.DropTable(
                name: "HiveTreatments");
        }
    }
}
