using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class RemoveGalleryFromDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pictures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });
        }
    }
}
