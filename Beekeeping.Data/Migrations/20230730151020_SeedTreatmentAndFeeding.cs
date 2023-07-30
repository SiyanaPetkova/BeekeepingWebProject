using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class SeedTreatmentAndFeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a409e9bf-e7cc-4de5-864e-e29ce5ec3015", "AQAAAAEAACcQAAAAEHIGxbXGun9p3vj00b5QcZHW+rYYdDlVr+VtlGujUP8bSIAdXnNJxTc4xBApYlFlSA==", "1A27660979840847AB7694C4E2E57FA6" });

            migrationBuilder.InsertData(
                table: "HiveFeeding",
                columns: new[] { "Id", "CreatorId", "DayOfFeeding", "FeedingType", "NumberOfBeeHives", "PriceOfFeeding" },
                values: new object[,]
                {
                    { 30001, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сироп", 10, 80m },
                    { 30002, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Питка", 10, 120m },
                    { 30003, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сироп", 10, 80m },
                    { 30004, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Питка", 10, 120m },
                    { 30005, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сироп", 10, 80m },
                    { 30006, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Питка", 10, 120m },
                    { 30007, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сироп", 10, 80m },
                    { 30008, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Питка", 10, 120m },
                    { 30009, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сироп", 10, 80m },
                    { 30010, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Питка", 10, 120m }
                });

            migrationBuilder.InsertData(
                table: "HiveTreatments",
                columns: new[] { "Id", "ActiveIngredient", "CreatorId", "MedicationName", "NumberOfTreatedColonies", "PriceOfTheTreatment", "ResultAndCommentAboutTheTreatment", "TreatmentDate" },
                values: new object[,]
                {
                    { 40001, "Амитраз", "44C36B39-AD0A-4260-B448-45BB03158888", "Апивар", 10, 100m, "Опаразитеност около 1%", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40002, "Оксалова киселина", "44C36B39-AD0A-4260-B448-45BB03158888", "Оксалова киселина", 10, 40m, "Опаразитеност около 2%", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40003, "Амитраз", "44C36B39-AD0A-4260-B448-45BB03158888", "Апивар", 10, 100m, "Опаразитеност около 3%", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40004, "Оксалова киселина", "44C36B39-AD0A-4260-B448-45BB03158888", "Оксалова киселина", 10, 40m, "Опаразитеност около 4%", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HiveFeeding",
                keyColumn: "Id",
                keyValue: 30001);

            migrationBuilder.DeleteData(
                table: "HiveFeeding",
                keyColumn: "Id",
                keyValue: 30002);

            migrationBuilder.DeleteData(
                table: "HiveFeeding",
                keyColumn: "Id",
                keyValue: 30003);

            migrationBuilder.DeleteData(
                table: "HiveFeeding",
                keyColumn: "Id",
                keyValue: 30004);

            migrationBuilder.DeleteData(
                table: "HiveFeeding",
                keyColumn: "Id",
                keyValue: 30005);

            migrationBuilder.DeleteData(
                table: "HiveFeeding",
                keyColumn: "Id",
                keyValue: 30006);

            migrationBuilder.DeleteData(
                table: "HiveFeeding",
                keyColumn: "Id",
                keyValue: 30007);

            migrationBuilder.DeleteData(
                table: "HiveFeeding",
                keyColumn: "Id",
                keyValue: 30008);

            migrationBuilder.DeleteData(
                table: "HiveFeeding",
                keyColumn: "Id",
                keyValue: 30009);

            migrationBuilder.DeleteData(
                table: "HiveFeeding",
                keyColumn: "Id",
                keyValue: 30010);

            migrationBuilder.DeleteData(
                table: "HiveTreatments",
                keyColumn: "Id",
                keyValue: 40001);

            migrationBuilder.DeleteData(
                table: "HiveTreatments",
                keyColumn: "Id",
                keyValue: 40002);

            migrationBuilder.DeleteData(
                table: "HiveTreatments",
                keyColumn: "Id",
                keyValue: 40003);

            migrationBuilder.DeleteData(
                table: "HiveTreatments",
                keyColumn: "Id",
                keyValue: 40004);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1b2d449-7eda-411d-bef1-d8ea8de4f1f3", "AQAAAAEAACcQAAAAEAlfRfmo4BOgM7yoLQo2EQ2K6Mj2xt1HPgWHL05mT2Dv4OkAQ3h8pMHvtzGbsclc6A==", "74818AAEA38F784BB8966FF7AA70B756" });
        }
    }
}
