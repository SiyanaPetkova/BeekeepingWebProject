using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class SeedApiaryBeeColonyAndBeedQueen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apiaries",
                columns: new[] { "Id", "ApplicationUserId", "Latitude", "Location", "Longitude", "Name", "NumberOfHives", "OwnerId", "RegistrationNumber" },
                values: new object[,]
                {
                    { 9150, null, 43.346221999999997, "Село Климентово, Варна", 27.946314999999998, "Климентово", 0, "44C36B39-AD0A-4260-B448-45BB03158888", "9150-0015" },
                    { 9156, null, 43.330429000000002, "Село Зорница, Варна", 27.734943999999999, "Зорница", 0, "44C36B39-AD0A-4260-B448-45BB03158888", "9156-0017" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5af8a06-dd09-49ed-b9c6-5fecf7bb6f2c", "AQAAAAEAACcQAAAAECOgb9K9WQeYB5Q2NfLj2s8D9TeLtiHj7l87daft28daDQvV9UT0ERNWBQnPiKTLKw==", "FF209E985B208944AE0E653F7BAF1026" });

            migrationBuilder.InsertData(
                table: "BeeQueens",
                columns: new[] { "Id", "BeeQueenType", "BeeQueenYearOfBirth", "Breeder" },
                values: new object[,]
                {
                    { 10001, "Карника", 2023, "Собствено производство" },
                    { 10002, "Карника", 2023, "Собствено производство" },
                    { 10003, "Неизвестна", 2023, "Роева" },
                    { 10004, "Карника", 2023, "Собствено производство" },
                    { 10005, "БМП", 2023, "Собствено производство" },
                    { 10006, "БМП", 2022, "Собствено производство" },
                    { 10007, "Карника", 2023, "Собствено производство" },
                    { 10008, "Неизвестна", 2023, "Роева" },
                    { 10009, "Карника", 2022, "Собствено производство" }
                });

            migrationBuilder.InsertData(
                table: "BeeColonies",
                columns: new[] { "Id", "AdditionalComment", "ApiaryId", "BeeQueenId", "MatedBeeQueen", "NumberOfAdditionalBoxes", "NumberOfSupers", "OwnerOfTheApiary", "PlateNumber", "SecondBroodBox", "Super", "TypeOfBroodBox" },
                values: new object[,]
                {
                    { 10001, "Основно семейство", 9150, 10001, true, 1, 1, "44C36B39-AD0A-4260-B448-45BB03158888", "100-4447", true, true, "Многокорпусен" },
                    { 10002, "Основно семейство", 9150, 10002, true, 0, 1, "44C36B39-AD0A-4260-B448-45BB03158888", "100-4448", false, true, "Многокорпусен" },
                    { 10003, "Отводка", 9150, 10003, true, 0, 0, "44C36B39-AD0A-4260-B448-45BB03158888", "100-4449", false, false, "Многокорпусен" },
                    { 10004, "Основно семейство", 9150, 10004, true, 0, 1, "44C36B39-AD0A-4260-B448-45BB03158888", "100-4450", false, true, "Многокорпусен" },
                    { 10005, "Основно семейство", 9150, 10005, true, 0, 1, "44C36B39-AD0A-4260-B448-45BB03158888", "100-4451", false, true, "Многокорпусен" },
                    { 10006, "Отводка", 9150, 10006, true, 0, 1, "44C36B39-AD0A-4260-B448-45BB03158888", "100-4452", false, true, "Многокорпусен" },
                    { 10007, "Отводка", 9156, 10007, true, 0, 1, "44C36B39-AD0A-4260-B448-45BB03158888", "100-4453", false, true, "Многокорпусен" },
                    { 10008, "Отводка", 9156, 10008, true, 0, 1, "44C36B39-AD0A-4260-B448-45BB03158888", "100-4454", false, true, "Многокорпусен" },
                    { 10009, "Отводка", 9156, 10009, true, 0, 1, "44C36B39-AD0A-4260-B448-45BB03158888", "100-4455", false, true, "Многокорпусен" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10001);

            migrationBuilder.DeleteData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10002);

            migrationBuilder.DeleteData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10003);

            migrationBuilder.DeleteData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10004);

            migrationBuilder.DeleteData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10005);

            migrationBuilder.DeleteData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10006);

            migrationBuilder.DeleteData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10007);

            migrationBuilder.DeleteData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10008);

            migrationBuilder.DeleteData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10009);

            migrationBuilder.DeleteData(
                table: "Apiaries",
                keyColumn: "Id",
                keyValue: 9150);

            migrationBuilder.DeleteData(
                table: "Apiaries",
                keyColumn: "Id",
                keyValue: 9156);

            migrationBuilder.DeleteData(
                table: "BeeQueens",
                keyColumn: "Id",
                keyValue: 10001);

            migrationBuilder.DeleteData(
                table: "BeeQueens",
                keyColumn: "Id",
                keyValue: 10002);

            migrationBuilder.DeleteData(
                table: "BeeQueens",
                keyColumn: "Id",
                keyValue: 10003);

            migrationBuilder.DeleteData(
                table: "BeeQueens",
                keyColumn: "Id",
                keyValue: 10004);

            migrationBuilder.DeleteData(
                table: "BeeQueens",
                keyColumn: "Id",
                keyValue: 10005);

            migrationBuilder.DeleteData(
                table: "BeeQueens",
                keyColumn: "Id",
                keyValue: 10006);

            migrationBuilder.DeleteData(
                table: "BeeQueens",
                keyColumn: "Id",
                keyValue: 10007);

            migrationBuilder.DeleteData(
                table: "BeeQueens",
                keyColumn: "Id",
                keyValue: 10008);

            migrationBuilder.DeleteData(
                table: "BeeQueens",
                keyColumn: "Id",
                keyValue: 10009);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7d32be6-3d17-412c-b3e1-d02db16a52d6", "AQAAAAEAACcQAAAAEKIw9S3W2o6lM5hVPJz0HNXDRv/IFh/toMeWo25fdIZOUsrrjebSB1J+rSVNZj2kuQ==", "BDD3A29305F35F4FB638E496EE901859" });
        }
    }
}
