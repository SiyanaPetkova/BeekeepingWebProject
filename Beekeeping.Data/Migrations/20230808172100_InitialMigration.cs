using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beekeeping.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeeQueens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Breeder = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BeeQueenType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BeeQueenYearOfBirth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeeQueens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfCost = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DayOfTheCost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HiveFeeding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedingType = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    DayOfFeeding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfBeeHives = table.Column<int>(type: "int", nullable: false),
                    PriceOfFeeding = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiveFeeding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HiveTreatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActiveIngredient = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ResultAndCommentAboutTheTreatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceOfTheTreatment = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TreatmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfTreatedColonies = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiveTreatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfIncome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DayOfTheIncome = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IncomeValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoteToDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateToBeDone = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteToDos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NumberOfHives = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apiaries_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeeColonies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdditionalComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfBroodBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Super = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfSupers = table.Column<int>(type: "int", nullable: true),
                    SecondBroodBox = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfAdditionalBoxes = table.Column<int>(type: "int", nullable: true),
                    MatedBeeQueen = table.Column<bool>(type: "bit", nullable: false),
                    OwnerOfTheApiary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiaryId = table.Column<int>(type: "int", nullable: false),
                    BeeQueenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeeColonies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeeColonies_Apiaries_ApiaryId",
                        column: x => x.ApiaryId,
                        principalTable: "Apiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeeColonies_BeeQueens_BeeQueenId",
                        column: x => x.BeeQueenId,
                        principalTable: "BeeQueens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfInspection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    NumberOfFrames = table.Column<int>(type: "int", nullable: false),
                    NumberOfBroodFrames = table.Column<int>(type: "int", nullable: true),
                    Strenght = table.Column<int>(type: "int", nullable: false),
                    Temperament = table.Column<int>(type: "int", nullable: false),
                    BeeColonyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspections_BeeColonies_BeeColonyId",
                        column: x => x.BeeColonyId,
                        principalTable: "BeeColonies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Apiaries",
                columns: new[] { "Id", "ApplicationUserId", "Latitude", "Location", "Longitude", "Name", "NumberOfHives", "OwnerId", "RegistrationNumber" },
                values: new object[,]
                {
                    { 9150, null, 43.346221999999997, "Село Климентово, Варна", 27.946314999999998, "Климентово", 0, "44C36B39-AD0A-4260-B448-45BB03158888", "9150-0015" },
                    { 9156, null, 43.330429000000002, "Село Зорница, Варна", 27.734943999999999, "Зорница", 0, "44C36B39-AD0A-4260-B448-45BB03158888", "9156-0017" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("44c36b39-ad0a-4260-b448-45bb03158888"), 0, "380df87e-6a98-4d5c-a230-dcd5a1669e40", "demouser@gmail.com", false, false, null, "DEMOUSER@GMAIL.COM", "DEMOUSER@GMAIL.COM", "AQAAAAEAACcQAAAAEJp9GNcM7PLTyL4VkOnrYAA/fKyiLsaIVbdmjQq/QdxdNgR1sElKfDW13I6LoOkIUw==", null, false, "F3FD287EE012AC4B86A11617B420DE12", false, "demouser@gmail.com" },
                    { new Guid("d23c4f40-0178-4622-b307-b482a79aa316"), 0, "af67d029-862a-4f27-aaf8-9e580c2017b0", "testAdmin@gmail.com", false, false, null, "TESTADMIN@GMAIL.COM", "TESTADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEEP1P42uRh5xq+Q9ALCZf8FnEsRwRnxcrig/nJ8bIDQ+JpF49p+dZx/4d+IQE+pqNw==", null, false, "E6676B67DC69284A95A1DB7429F51B79", false, "testAdmin@gmail.com" }
                });

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
                table: "HiveFeeding",
                columns: new[] { "Id", "CreatorId", "DayOfFeeding", "FeedingType", "NumberOfBeeHives", "PriceOfFeeding" },
                values: new object[,]
                {
                    { 30001, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сироп", 10, 80m },
                    { 30002, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Питка", 10, 120m },
                    { 30003, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Сироп", 10, 80m },
                    { 30004, "44C36B39-AD0A-4260-B448-45BB03158888", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Питка", 10, 120m }
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
                    { 100040, 10007, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 5, 9, 8, 8 },
                    { 100041, 10007, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Общ преглед", 6, 10, 9, 8 }
                });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "Id", "BeeColonyId", "DayOfInspection", "Description", "NumberOfBroodFrames", "NumberOfFrames", "Strenght", "Temperament" },
                values: new object[,]
                {
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

            migrationBuilder.CreateIndex(
                name: "IX_Apiaries_ApplicationUserId",
                table: "Apiaries",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BeeColonies_ApiaryId",
                table: "BeeColonies",
                column: "ApiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_BeeColonies_BeeQueenId",
                table: "BeeColonies",
                column: "BeeQueenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_BeeColonyId",
                table: "Inspections",
                column: "BeeColonyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "HiveFeeding");

            migrationBuilder.DropTable(
                name: "HiveTreatments");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "NoteToDos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BeeColonies");

            migrationBuilder.DropTable(
                name: "Apiaries");

            migrationBuilder.DropTable(
                name: "BeeQueens");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
