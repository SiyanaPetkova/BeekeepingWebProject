using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class SeedInspections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1b2d449-7eda-411d-bef1-d8ea8de4f1f3", "AQAAAAEAACcQAAAAEAlfRfmo4BOgM7yoLQo2EQ2K6Mj2xt1HPgWHL05mT2Dv4OkAQ3h8pMHvtzGbsclc6A==", "74818AAEA38F784BB8966FF7AA70B756" });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "Id", "BeeColonyId", "DayOfInspection", "Description", "NumberOfBroodFrames", "NumberOfFrames", "Strenght", "Temperament" },
                values: new object[,]
                {
                    { 100000, 10001, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 1, 5, 4, 8 },
                    { 100001, 10001, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 2, 6, 5, 8 },
                    { 100002, 10001, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 3, 7, 6, 8 },
                    { 100003, 10001, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 4, 8, 7, 8 },
                    { 100004, 10001, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 5, 9, 8, 8 },
                    { 100005, 10001, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 6, 10, 9, 8 },
                    { 100006, 10002, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 1, 5, 4, 8 },
                    { 100007, 10002, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 2, 6, 5, 8 },
                    { 100008, 10002, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 3, 7, 6, 8 },
                    { 100009, 10002, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 4, 8, 7, 8 },
                    { 100010, 10002, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 5, 9, 8, 8 },
                    { 100011, 10002, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 6, 10, 9, 8 },
                    { 100012, 10003, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 1, 5, 4, 8 },
                    { 100013, 10003, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 2, 6, 5, 8 },
                    { 100014, 10003, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 3, 7, 6, 8 },
                    { 100015, 10003, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 4, 8, 7, 8 },
                    { 100016, 10003, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 5, 9, 8, 8 },
                    { 100017, 10003, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 6, 10, 9, 8 },
                    { 100018, 10004, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 1, 5, 4, 8 },
                    { 100019, 10004, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 2, 6, 5, 8 },
                    { 100020, 10004, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 3, 7, 6, 8 },
                    { 100021, 10004, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 4, 8, 7, 8 },
                    { 100022, 10004, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 5, 9, 8, 8 },
                    { 100023, 10004, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 6, 10, 9, 8 },
                    { 100024, 10005, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 1, 5, 4, 8 },
                    { 100025, 10005, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 2, 6, 5, 8 },
                    { 100026, 10005, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 3, 7, 6, 8 },
                    { 100027, 10005, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 4, 8, 7, 8 },
                    { 100028, 10005, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 5, 9, 8, 8 },
                    { 100029, 10005, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 6, 10, 9, 8 },
                    { 100030, 10006, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 1, 5, 4, 8 },
                    { 100031, 10006, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 2, 6, 5, 8 },
                    { 100032, 10006, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 3, 7, 6, 8 },
                    { 100033, 10006, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 4, 8, 7, 8 },
                    { 100034, 10006, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 5, 9, 8, 8 },
                    { 100035, 10006, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 6, 10, 9, 8 },
                    { 100036, 10007, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 1, 5, 4, 8 },
                    { 100037, 10007, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 2, 6, 5, 8 },
                    { 100038, 10007, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 3, 7, 6, 8 },
                    { 100039, 10007, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 4, 8, 7, 8 },
                    { 100040, 10007, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 5, 9, 8, 8 }
                });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "Id", "BeeColonyId", "DayOfInspection", "Description", "NumberOfBroodFrames", "NumberOfFrames", "Strenght", "Temperament" },
                values: new object[,]
                {
                    { 100041, 10007, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 6, 10, 9, 8 },
                    { 100042, 10008, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 1, 5, 4, 8 },
                    { 100043, 10008, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 2, 6, 5, 8 },
                    { 100044, 10008, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 3, 7, 6, 8 },
                    { 100045, 10008, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 4, 8, 7, 8 },
                    { 100046, 10008, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 5, 9, 8, 8 },
                    { 100047, 10008, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 6, 10, 9, 8 },
                    { 100048, 10009, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 1, 5, 4, 8 },
                    { 100049, 10009, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 2, 6, 5, 8 },
                    { 100050, 10009, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 3, 7, 6, 8 },
                    { 100051, 10009, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 4, 8, 7, 8 },
                    { 100052, 10009, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 5, 9, 8, 8 },
                    { 100053, 10009, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 6, 10, 9, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100000);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100001);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100002);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100003);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100004);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100005);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100006);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100007);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100008);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100009);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100010);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100011);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100012);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100013);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100014);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100015);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100016);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100017);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100018);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100019);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100020);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100021);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100022);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100023);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100024);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100025);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100026);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100027);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100028);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100029);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100030);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100031);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100032);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100033);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100034);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100035);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100036);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100037);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100038);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100039);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100040);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100041);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100042);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100043);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100044);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100045);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100046);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100047);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100048);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100049);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100050);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100051);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100052);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 100053);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5af8a06-dd09-49ed-b9c6-5fecf7bb6f2c", "AQAAAAEAACcQAAAAECOgb9K9WQeYB5Q2NfLj2s8D9TeLtiHj7l87daft28daDQvV9UT0ERNWBQnPiKTLKw==", "FF209E985B208944AE0E653F7BAF1026" });
        }
    }
}
