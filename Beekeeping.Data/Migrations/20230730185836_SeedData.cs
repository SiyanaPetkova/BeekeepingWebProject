using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dea88a7-b403-431b-9293-d9d30c46a67a", "AQAAAAEAACcQAAAAEFSHS9ZSwCSGrqB9XrkhwDjG3JtXWK/ksKAqh/CX8pzfexOujGgeDX3esJKyUzmOSw==", "9770BE08532FD14F9F5D2D5751803D54" });

            migrationBuilder.InsertData(
                table: "Costs",
                columns: new[] { "Id", "CostValue", "CreatorId", "DayOfTheCost", "TypeOfCost" },
                values: new object[,]
                {
                    { 50001, 100m, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Третиране" },
                    { 50002, 120m, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Хранене" },
                    { 50003, 40m, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Третиране" },
                    { 50004, 80m, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Хранене" },
                    { 50005, 100m, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Третиране" },
                    { 50006, 120m, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Хранене" },
                    { 50007, 40m, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Третиране" },
                    { 50008, 200m, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Транспорт" },
                    { 50009, 150m, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пчеларски инвентар" }
                });

            migrationBuilder.InsertData(
                table: "Incomes",
                columns: new[] { "Id", "CreatorId", "DayOfTheIncome", "IncomeValue", "TypeOfIncome" },
                values: new object[,]
                {
                    { 60001, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 950m, "Продаден прашец" },
                    { 60002, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 120m, "Продаден мед" },
                    { 60003, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 250m, "Продаден мед" },
                    { 60004, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 240m, "Продаден прашец" },
                    { 60005, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 110m, "Продаден прополис" },
                    { 60006, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1350m, "Продаден мед" },
                    { 60007, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 290m, "Продаден мед" }
                });

            migrationBuilder.InsertData(
                table: "NoteToDos",
                columns: new[] { "Id", "CreatorId", "DateToBeDone", "Description", "Finished" },
                values: new object[,]
                {
                    { 20001, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Третиране против акар", false },
                    { 20002, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пролетно подхранване", true },
                    { 20003, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Поставяне на магазини", true },
                    { 20004, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Третиране против нозематоза", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 50001);

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 50002);

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 50003);

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 50004);

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 50005);

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 50006);

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 50007);

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 50008);

            migrationBuilder.DeleteData(
                table: "Costs",
                keyColumn: "Id",
                keyValue: 50009);

            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 60001);

            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 60002);

            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 60003);

            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 60004);

            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 60005);

            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 60006);

            migrationBuilder.DeleteData(
                table: "Incomes",
                keyColumn: "Id",
                keyValue: 60007);

            migrationBuilder.DeleteData(
                table: "NoteToDos",
                keyColumn: "Id",
                keyValue: 20001);

            migrationBuilder.DeleteData(
                table: "NoteToDos",
                keyColumn: "Id",
                keyValue: 20002);

            migrationBuilder.DeleteData(
                table: "NoteToDos",
                keyColumn: "Id",
                keyValue: 20003);

            migrationBuilder.DeleteData(
                table: "NoteToDos",
                keyColumn: "Id",
                keyValue: 20004);

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
                    { 30005, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сироп", 10, 80m },
                    { 30006, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Питка", 10, 120m },
                    { 30007, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сироп", 10, 80m },
                    { 30008, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Питка", 10, 120m },
                    { 30009, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сироп", 10, 80m },
                    { 30010, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Питка", 10, 120m }
                });
        }
    }
}
