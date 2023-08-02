using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class SeedUserForAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d14ea38-1d12-4cda-b3a8-6d491d0b75c0", "AQAAAAEAACcQAAAAEKqHANRi88jNrV5WemfgI5mPZvOyiZp+xCynDpJb4ea031775jq8cXPrjnKnaqB3aA==", "66E8D8339EBDE045A3E73275684530A6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d23c4f40-0178-4622-b307-b482a79aa316"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "738638f8-c421-4f83-85ff-f6a326467a4e", "AQAAAAEAACcQAAAAENVuxGrGkNxVoiHXgs7jXfln/Y25ITSSMdbmW/u4QLJGSj+wq1o9AMsOaTz3p24r7A==", "BDB7C99BDCCCAC4180319C669772258B" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95274b41-99f2-48dd-85af-a3800c1dbe3c", "AQAAAAEAACcQAAAAEBPobu9f5OdgzHI2ex+l3yRKVDJ8k4zNzQ4XFSRmlrpVOk7mZC+RlbQzafAMxYge9Q==", "FCB9E6CC2B6DA749BE2C0B538112615A" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d23c4f40-0178-4622-b307-b482a79aa316"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77cc69d2-6987-43e7-a3d4-94efd0a34d2a", "AQAAAAEAACcQAAAAEGBBPUCNgj9s2+rONpqX8QENnkMcPogdCr1pE1EdWOeRMRyLnw6Hl/qHedr2gfkI5g==", "12F0B38F71BEA342B8A18608A5217CF6" });
        }
    }
}
