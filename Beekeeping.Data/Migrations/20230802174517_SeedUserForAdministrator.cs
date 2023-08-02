using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class SeedUserForAdministrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Apiaries",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Apiaries",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95274b41-99f2-48dd-85af-a3800c1dbe3c", "AQAAAAEAACcQAAAAEBPobu9f5OdgzHI2ex+l3yRKVDJ8k4zNzQ4XFSRmlrpVOk7mZC+RlbQzafAMxYge9Q==", "FCB9E6CC2B6DA749BE2C0B538112615A" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d23c4f40-0178-4622-b307-b482a79aa316"), 0, "77cc69d2-6987-43e7-a3d4-94efd0a34d2a", "testAdmin@gmail.com", false, false, null, null, "TESTADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEGBBPUCNgj9s2+rONpqX8QENnkMcPogdCr1pE1EdWOeRMRyLnw6Hl/qHedr2gfkI5g==", null, false, "12F0B38F71BEA342B8A18608A5217CF6", false, "testAdmin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d23c4f40-0178-4622-b307-b482a79aa316"));

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Apiaries",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Apiaries",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dea88a7-b403-431b-9293-d9d30c46a67a", "AQAAAAEAACcQAAAAEFSHS9ZSwCSGrqB9XrkhwDjG3JtXWK/ksKAqh/CX8pzfexOujGgeDX3esJKyUzmOSw==", "9770BE08532FD14F9F5D2D5751803D54" });
        }
    }
}
