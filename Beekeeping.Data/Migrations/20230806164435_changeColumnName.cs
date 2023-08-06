using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class changeColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65852af5-21ed-4a29-b2e9-5e0b9ec995c9", "AQAAAAEAACcQAAAAEOXRcnBd/Q5gM/5T1KEuWRITEVoTA+bylHZpH0fRv9YMiFOOWrkDPeVUBsVBAHhZ1A==", "419322EA15136C4FA4C944C26CA1BDA2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d23c4f40-0178-4622-b307-b482a79aa316"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a3e3517-ecd3-412f-b4ad-a34c8a86443a", "AQAAAAEAACcQAAAAEMKtgJM/21rp6R+qtG4q6vjRV8ffGtI79PNtpcbDCl+igZkNQkZbS+e9wJO30h3D7w==", "DA21D14439120340B1FA3D7CCDCEB40E" });

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10001,
                column: "AdditionalComment",
                value: "Основно семейство");

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10002,
                column: "AdditionalComment",
                value: "Основно семейство");

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10003,
                column: "AdditionalComment",
                value: "Отводка");

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10004,
                column: "AdditionalComment",
                value: "Основно семейство");

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10005,
                column: "AdditionalComment",
                value: "Основно семейство");

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10006,
                column: "AdditionalComment",
                value: "Отводка");

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10007,
                column: "AdditionalComment",
                value: "Отводка");

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10008,
                column: "AdditionalComment",
                value: "Отводка");

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10009,
                column: "AdditionalComment",
                value: "Отводка");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1af61d00-1630-4f0f-b5bf-01732378eb5a", "AQAAAAEAACcQAAAAEPdES3KkZmg/kgkpfuupLREFIjpt3lDcUBMMlkvGVSt1OKlF0wG+mGfK2GcXfD0KyQ==", "D518A5A26EC29D4D82B60C37A4EEE622" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d23c4f40-0178-4622-b307-b482a79aa316"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f72299d-57b0-4124-b3ce-d1f9f6bc6b78", "AQAAAAEAACcQAAAAECZ+YZg5fjEngEFZ8iEaa8KjlMu1jU9Ld9UwOTTlqvd/ew4Ek45+Gfcwum9tRDob7w==", "E950335E89BE4942A5DF15F74835206C" });

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10001,
                column: "AdditionalComment",
                value: null);

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10002,
                column: "AdditionalComment",
                value: null);

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10003,
                column: "AdditionalComment",
                value: null);

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10004,
                column: "AdditionalComment",
                value: null);

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10005,
                column: "AdditionalComment",
                value: null);

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10006,
                column: "AdditionalComment",
                value: null);

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10007,
                column: "AdditionalComment",
                value: null);

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10008,
                column: "AdditionalComment",
                value: null);

            migrationBuilder.UpdateData(
                table: "BeeColonies",
                keyColumn: "Id",
                keyValue: 10009,
                column: "AdditionalComment",
                value: null);
        }
    }
}
