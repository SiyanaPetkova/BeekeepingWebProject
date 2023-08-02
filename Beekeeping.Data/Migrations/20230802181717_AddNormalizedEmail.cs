using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class AddNormalizedEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1af61d00-1630-4f0f-b5bf-01732378eb5a", "DEMOUSER@GMAIL.COM", "AQAAAAEAACcQAAAAEPdES3KkZmg/kgkpfuupLREFIjpt3lDcUBMMlkvGVSt1OKlF0wG+mGfK2GcXfD0KyQ==", "D518A5A26EC29D4D82B60C37A4EEE622" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d23c4f40-0178-4622-b307-b482a79aa316"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f72299d-57b0-4124-b3ce-d1f9f6bc6b78", "TESTADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAECZ+YZg5fjEngEFZ8iEaa8KjlMu1jU9Ld9UwOTTlqvd/ew4Ek45+Gfcwum9tRDob7w==", "E950335E89BE4942A5DF15F74835206C" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d14ea38-1d12-4cda-b3a8-6d491d0b75c0", null, "AQAAAAEAACcQAAAAEKqHANRi88jNrV5WemfgI5mPZvOyiZp+xCynDpJb4ea031775jq8cXPrjnKnaqB3aA==", "66E8D8339EBDE045A3E73275684530A6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d23c4f40-0178-4622-b307-b482a79aa316"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "738638f8-c421-4f83-85ff-f6a326467a4e", null, "AQAAAAEAACcQAAAAENVuxGrGkNxVoiHXgs7jXfln/Y25ITSSMdbmW/u4QLJGSj+wq1o9AMsOaTz3p24r7A==", "BDB7C99BDCCCAC4180319C669772258B" });
        }
    }
}
