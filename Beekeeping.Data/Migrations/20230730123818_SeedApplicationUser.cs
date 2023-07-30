using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class SeedApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158223"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("44c36b39-ad0a-4260-b448-45bb03158888"), 0, "b7d32be6-3d17-412c-b3e1-d02db16a52d6", "demouser@gmail.com", false, false, null, null, "DEMOUSER@GMAIL.COM", "AQAAAAEAACcQAAAAEKIw9S3W2o6lM5hVPJz0HNXDRv/IFh/toMeWo25fdIZOUsrrjebSB1J+rSVNZj2kuQ==", null, false, "BDD3A29305F35F4FB638E496EE901859", false, "demouser@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("44c36b39-ad0a-4260-b448-45bb03158888"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("44c36b39-ad0a-4260-b448-45bb03158223"), 0, "e0751fa3-9e27-4ebe-9ea1-fbfdd330abe0", "demouser@gmail.com", false, false, null, null, "DEMOUSER@GMAIL.COM", "AQAAAAEAACcQAAAAEJbpELYc6KbPZsuaovvzuN2PGZAgVYtX10zp3TgR1vIjIDe/0zgMJUljAtPe1ynRnw==", null, false, "E7938C4EC8535A448B366C0CD6CDF1BB", false, "demouser@gmail.com" });
        }
    }
}
