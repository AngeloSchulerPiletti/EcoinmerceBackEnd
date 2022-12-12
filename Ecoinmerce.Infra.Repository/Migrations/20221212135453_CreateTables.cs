using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EcommerceManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Cellphone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ConfirmationToken = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    ConfirmationTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    AccessTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(100)", maxLength: 100, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EcommerceId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcommerceManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckOverCounter = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseChecks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEventFails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    BlockHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEventFails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountPaidInEther = table.Column<decimal>(type: "decimal(28,18)", precision: 28, scale: 18, nullable: false),
                    PurchaseIdentifier = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ecommerces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FantasyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SocialReason = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AverageTotalEmployees = table.Column<int>(type: "int", nullable: true),
                    AverageAnnualBilling = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ConfirmationToken = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    ConfirmationTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecommerces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ecommerces_EcommerceManagers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "EcommerceManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApiCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AccessTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidityInDays = table.Column<int>(type: "int", nullable: false),
                    EcommerceId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiCredentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApiCredentials_Ecommerces_EcommerceId",
                        column: x => x.EcommerceId,
                        principalTable: "Ecommerces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcommerceAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Salt = table.Column<byte[]>(type: "varbinary(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConfirmationToken = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    ConfirmationTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    AccessTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EcommerceId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcommerceAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcommerceAdmins_Ecommerces_EcommerceId",
                        column: x => x.EcommerceId,
                        principalTable: "Ecommerces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtherWallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublicKey = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PrivateKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EcommerceId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtherWallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtherWallets_Ecommerces_EcommerceId",
                        column: x => x.EcommerceId,
                        principalTable: "Ecommerces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Failed = table.Column<bool>(type: "bit", nullable: false),
                    BlockHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TransactionHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EcommerceWalletAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    CostumerWalletAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    PurchaseCheckId = table.Column<int>(type: "int", nullable: false),
                    PurchaseEventId = table.Column<int>(type: "int", nullable: false),
                    PurchaseEventFailId = table.Column<int>(type: "int", nullable: false),
                    EcommerceId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Ecommerces_EcommerceId",
                        column: x => x.EcommerceId,
                        principalTable: "Ecommerces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_PurchaseChecks_PurchaseCheckId",
                        column: x => x.PurchaseCheckId,
                        principalTable: "PurchaseChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_PurchaseEventFails_PurchaseEventFailId",
                        column: x => x.PurchaseEventFailId,
                        principalTable: "PurchaseEventFails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_PurchaseEvents_PurchaseEventId",
                        column: x => x.PurchaseEventId,
                        principalTable: "PurchaseEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleBond",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EcommerceAdminId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleBond", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleBond_EcommerceAdmins_EcommerceAdminId",
                        column: x => x.EcommerceAdminId,
                        principalTable: "EcommerceAdmins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleBond_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EcommerceManagers",
                columns: new[] { "Id", "AccessToken", "AccessTokenExpiry", "Cellphone", "ConfirmationToken", "ConfirmationTokenExpiry", "Cpf", "CreatedAt", "EcommerceId", "Email", "FirstName", "IsDeleted", "IsEmailConfirmed", "LastName", "Password", "Phone", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt", "Username" },
                values: new object[] { 1, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2NzA4NTMyOTMsImV4cCI6MTY3MDg5NjQ5MywiaWF0IjoxNjcwODUzMjkzfQ.8xmsHHB-B4y83duvNMqk6eFiHQKE5L3jezUxCqIglHs", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), "51982505194", null, null, "05105784030", new DateTime(2022, 12, 12, 10, 54, 53, 577, DateTimeKind.Local).AddTicks(9856), 1, "angelopiletti@gmail.com", "Angelo", false, true, "Schuler Piletti", "YGxibG14v0NEgdJhE65juqalP4Zm7OpP6QMhmhLh/YM=", "5134732749", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzEwMjYwOTMsImlhdCI6MTY3MDg1MzI5M30.IyBQ40SoYhCzjU8t0FhAXdrsKK5w-sUyq33hXWtZasw", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 170, 97, 123, 14, 227, 155, 68, 216, 124, 179, 247, 254, 104, 68, 162, 169, 218, 166, 139, 162, 1, 78, 53, 92, 139, 210, 248, 200, 154, 197, 137, 6, 219, 75, 4, 133, 215, 104, 122, 239 }, new DateTime(2022, 12, 12, 10, 54, 53, 577, DateTimeKind.Local).AddTicks(9866), "angeloManager" });

            migrationBuilder.InsertData(
                table: "EcommerceManagers",
                columns: new[] { "Id", "AccessToken", "AccessTokenExpiry", "Cellphone", "ConfirmationToken", "ConfirmationTokenExpiry", "Cpf", "CreatedAt", "EcommerceId", "Email", "FirstName", "IsDeleted", "IsEmailConfirmed", "LastName", "Password", "Phone", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt", "Username" },
                values: new object[] { 2, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzA4OTY0OTMsImlhdCI6MTY3MDg1MzI5M30.VKFA-09In7EgfFbACo_G_pIpZOl7OSduULSyAPa9hHA", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), "51982505194", null, null, "05105784030", new DateTime(2022, 12, 12, 10, 54, 53, 611, DateTimeKind.Local).AddTicks(8933), 2, "bruna.fusiger@gmail.com", "Bruna", false, true, "Fusiger", "eGXp9kjqj6x9Y41b5fKeUYKzyH6ZnEvGnPntXFV8jek=", "5134732749", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2NzA4NTMyOTMsImV4cCI6MTY3MTAyNjA5MywiaWF0IjoxNjcwODUzMjkzfQ.OGxlQWzfynPgOXEoNo0azircNxpie-WKW95R4Lr6XCI", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 36, 108, 162, 66, 25, 162, 194, 20, 127, 249, 115, 36, 159, 176, 120, 104, 236, 236, 166, 242, 96, 22, 250, 175, 16, 91, 228, 21, 226, 157, 119, 0, 117, 123, 29, 228, 240, 237, 0, 236 }, new DateTime(2022, 12, 12, 10, 54, 53, 611, DateTimeKind.Local).AddTicks(8935), "brunaManager" });

            migrationBuilder.InsertData(
                table: "EcommerceManagers",
                columns: new[] { "Id", "AccessToken", "AccessTokenExpiry", "Cellphone", "ConfirmationToken", "ConfirmationTokenExpiry", "Cpf", "CreatedAt", "EcommerceId", "Email", "FirstName", "IsDeleted", "IsEmailConfirmed", "LastName", "Password", "Phone", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt", "Username" },
                values: new object[] { 3, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MDg1MzI5MywiZXhwIjoxNjcwODk2NDkzLCJpYXQiOjE2NzA4NTMyOTN9.S4ZuF1PULDavKLQ3VgussYbkgugOze4RVDjKkKFOjhc", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), "51982505194", null, null, "05105784030", new DateTime(2022, 12, 12, 10, 54, 53, 639, DateTimeKind.Local).AddTicks(8028), 3, "lucasoliveira.contatonline@gmail.com", "Lucas", false, true, "Oliveira", "IrLj+/MOgxn9mShHoNWQl7yOBBOOY0Pn3GpW49S5l98=", "5134732749", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzEwMjYwOTMsImlhdCI6MTY3MDg1MzI5M30.ENaeAFQCxPzql7P6Sp11FvTD2N96YMsg6Q52C-py_XU", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 83, 1, 144, 168, 22, 98, 66, 52, 31, 40, 101, 169, 67, 112, 118, 104, 138, 231, 187, 161, 225, 247, 76, 67, 231, 40, 182, 42, 98, 47, 203, 188, 195, 37, 210, 110, 78, 15, 115, 20 }, new DateTime(2022, 12, 12, 10, 54, 53, 639, DateTimeKind.Local).AddTicks(8029), "lucasManager" });

            migrationBuilder.InsertData(
                table: "Ecommerces",
                columns: new[] { "Id", "AverageAnnualBilling", "AverageTotalEmployees", "Cep", "Cnpj", "ConfirmationToken", "ConfirmationTokenExpiry", "CreatedAt", "Email", "FantasyName", "IsDeleted", "IsEmailConfirmed", "ManagerId", "Phone", "SocialReason", "UpdatedAt", "Website" },
                values: new object[] { 1, 10000000m, 100, "93270420", "74544297000192", null, null, new DateTime(2022, 12, 12, 10, 54, 53, 606, DateTimeKind.Local).AddTicks(937), "angelopiletti@gmail.com", "TEST Nome Fantasia", false, true, 1, "5134732749", "TEST S.A", new DateTime(2022, 12, 12, 10, 54, 53, 606, DateTimeKind.Local).AddTicks(939), "https://google.com" });

            migrationBuilder.InsertData(
                table: "Ecommerces",
                columns: new[] { "Id", "AverageAnnualBilling", "AverageTotalEmployees", "Cep", "Cnpj", "ConfirmationToken", "ConfirmationTokenExpiry", "CreatedAt", "Email", "FantasyName", "IsDeleted", "IsEmailConfirmed", "ManagerId", "Phone", "SocialReason", "UpdatedAt", "Website" },
                values: new object[] { 2, 10000000m, 100, "93270420", "74544297000192", null, null, new DateTime(2022, 12, 12, 10, 54, 53, 633, DateTimeKind.Local).AddTicks(7310), "bruna.fusiger@gmail.com", "TEST Nome Fantasia", false, true, 2, "5134732749", "TEST S.A", new DateTime(2022, 12, 12, 10, 54, 53, 633, DateTimeKind.Local).AddTicks(7312), "https://google.com" });

            migrationBuilder.InsertData(
                table: "Ecommerces",
                columns: new[] { "Id", "AverageAnnualBilling", "AverageTotalEmployees", "Cep", "Cnpj", "ConfirmationToken", "ConfirmationTokenExpiry", "CreatedAt", "Email", "FantasyName", "IsDeleted", "IsEmailConfirmed", "ManagerId", "Phone", "SocialReason", "UpdatedAt", "Website" },
                values: new object[] { 3, 10000000m, 100, "93270420", "74544297000192", null, null, new DateTime(2022, 12, 12, 10, 54, 53, 664, DateTimeKind.Local).AddTicks(630), "lucasoliveira.contatonline@gmail.com", "TEST Nome Fantasia", false, true, 3, "5134732749", "TEST S.A", new DateTime(2022, 12, 12, 10, 54, 53, 664, DateTimeKind.Local).AddTicks(631), "https://google.com" });

            migrationBuilder.InsertData(
                table: "ApiCredentials",
                columns: new[] { "Id", "AccessToken", "AccessTokenExpiry", "CreatedAt", "CreatedBy", "Description", "EcommerceId", "Name", "UpdatedAt", "UpdatedBy", "ValidityInDays" },
                values: new object[,]
                {
                    { 1, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzI1ODEyOTMsImlhdCI6MTY3MDg1MzI5M30.CKmQgLLRJtsOZoLgByR80KR7tdOK2u1Xx33-O8cQg88", new DateTime(2023, 1, 1, 13, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 606, DateTimeKind.Local).AddTicks(947), "SYSTEM SEED", "Esse aqui é um api credencial criado automaticamente como teste", 1, "TESTE Credencial", new DateTime(2022, 12, 12, 10, 54, 53, 606, DateTimeKind.Local).AddTicks(948), "SYSTEM SEED", 20 },
                    { 2, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzI1ODEyOTMsImlhdCI6MTY3MDg1MzI5M30.dHEQUkET3_l2f2yeAB5G-Z51ZN4J0JuucUkCfWWILuM", new DateTime(2023, 1, 1, 13, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 633, DateTimeKind.Local).AddTicks(7316), "SYSTEM SEED", "Esse aqui é um api credencial criado automaticamente como teste", 2, "TESTE Credencial", new DateTime(2022, 12, 12, 10, 54, 53, 633, DateTimeKind.Local).AddTicks(7317), "SYSTEM SEED", 20 },
                    { 3, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MDg1MzI5MywiZXhwIjoxNjcyNTgxMjkzLCJpYXQiOjE2NzA4NTMyOTN9.3UM0mrWGCcPUhmrHW4EAWk1wvSmFyU5kQ8obAvou_Wo", new DateTime(2023, 1, 1, 13, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 664, DateTimeKind.Local).AddTicks(638), "SYSTEM SEED", "Esse aqui é um api credencial criado automaticamente como teste", 3, "TESTE Credencial", new DateTime(2022, 12, 12, 10, 54, 53, 664, DateTimeKind.Local).AddTicks(639), "SYSTEM SEED", 20 }
                });

            migrationBuilder.InsertData(
                table: "EcommerceAdmins",
                columns: new[] { "Id", "AccessToken", "AccessTokenExpiry", "ConfirmationToken", "ConfirmationTokenExpiry", "CreatedAt", "CreatedBy", "EcommerceId", "Email", "FirstName", "IsDeleted", "IsEmailConfirmed", "LastName", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { 1, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY3MDg1MzI5MywiZXhwIjoxNjcwODk2NDkzLCJpYXQiOjE2NzA4NTMyOTN9.xVJUCJ851AwF7gkQy8fEPAjajistPygVWW3Nm2UDToc", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), null, null, new DateTime(2022, 12, 12, 10, 54, 53, 592, DateTimeKind.Local).AddTicks(9503), "SYSTEM SEED", 1, "angelopiletti@gmail.com", "Angelo", false, true, "Schuler Piletti", "mkPSkMD1Dartaem+Uhf9G56Xo+8PZhgM1srbUqTIiWQ=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY3MDg1MzI5MywiZXhwIjoxNjcxMDI2MDkzLCJpYXQiOjE2NzA4NTMyOTN9.0DyRh6HqChG25u0nIG0rMLMkM9-HXtjjHNxAF2LiqwM", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 233, 66, 57, 164, 194, 167, 188, 65, 30, 87, 254, 158, 2, 124, 125, 233, 16, 253, 223, 52, 19, 160, 155, 1, 216, 95, 249, 227, 7, 57, 238, 147, 130, 22, 75, 25, 137, 13, 233, 251 }, new DateTime(2022, 12, 12, 10, 54, 53, 592, DateTimeKind.Local).AddTicks(9504), "SYSTEM SEED", "angeloAdmin" },
                    { 2, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2NzA4NTMyOTMsImV4cCI6MTY3MDg5NjQ5MywiaWF0IjoxNjcwODUzMjkzfQ.1QiOP8naSjd82O0FanhoZ6kbbU52hddfrXeWQP4JVt8", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), null, null, new DateTime(2022, 12, 12, 10, 54, 53, 623, DateTimeKind.Local).AddTicks(3468), "SYSTEM SEED", 2, "bruna.fusiger@gmail.com", "Bruna", false, true, "Fusiger", "Qjsx2NEZEEtrR6GD73HrPrbc45lmiB+91tXE2oqBJXc=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzEwMjYwOTMsImlhdCI6MTY3MDg1MzI5M30.54ptDcKgKzJdXtgXJmBSCoppC37wrB5SVlDrBq6U9EE", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 211, 54, 170, 190, 91, 7, 113, 224, 201, 214, 165, 138, 135, 17, 187, 68, 201, 244, 197, 203, 70, 86, 227, 54, 236, 240, 101, 76, 173, 108, 103, 177, 147, 236, 105, 7, 149, 79, 201, 119 }, new DateTime(2022, 12, 12, 10, 54, 53, 623, DateTimeKind.Local).AddTicks(3468), "SYSTEM SEED", "brunaAdmin" },
                    { 3, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzA4OTY0OTMsImlhdCI6MTY3MDg1MzI5M30.2T3Qhjkg9J9gojVQoHY0XdNhdR_-V9xkkKaQAsY_u1g", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), null, null, new DateTime(2022, 12, 12, 10, 54, 53, 650, DateTimeKind.Local).AddTicks(201), "SYSTEM SEED", 3, "lucasoliveira.contatonline@gmail.com", "Lucas", false, true, "Oliveira", "37Za6AoyjLcbN4U7eaBgUPEfid9rLC4raV53ZVdqxKY=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MDg1MzI5MywiZXhwIjoxNjcxMDI2MDkzLCJpYXQiOjE2NzA4NTMyOTN9.wH9wgVoy83eQVCORdVytFpA2xnyd8O2LAkb0ae8ToyQ", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 147, 139, 221, 56, 159, 246, 227, 201, 96, 157, 178, 23, 17, 64, 252, 132, 71, 187, 175, 167, 110, 51, 51, 171, 139, 131, 43, 81, 196, 193, 20, 249, 178, 209, 37, 248, 57, 109, 141, 203 }, new DateTime(2022, 12, 12, 10, 54, 53, 650, DateTimeKind.Local).AddTicks(202), "SYSTEM SEED", "lucasAdmin" }
                });

            migrationBuilder.InsertData(
                table: "EtherWallets",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "EcommerceId", "IsDeleted", "Name", "PrivateKey", "PublicKey", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "0x83596d3984C65c48D9f167ada9698BECFa709571", new DateTime(2022, 12, 12, 10, 54, 53, 611, DateTimeKind.Local).AddTicks(8659), "SYSTEM SEED", 1, false, "TEST Wallet", "0x879b22729079d26717c15544e85f3692229b481368ea4b5a65ca289a5c26db53", "0489249214e77e5d07d2de2e63b82f5e2029e4d0d739a341a166e6363db1c338e749f11823ded16954ba15070dd496f109a9655c7b9cd08417538ed5ac8d1216b2", new DateTime(2022, 12, 12, 10, 54, 53, 611, DateTimeKind.Local).AddTicks(8671), "SYSTEM SEED" },
                    { 2, "0xd49B964c84132F43e3d1Ed3A7b67B57304Cb6fB3", new DateTime(2022, 12, 12, 10, 54, 53, 639, DateTimeKind.Local).AddTicks(7843), "SYSTEM SEED", 2, false, "TEST Wallet", "0x830226e76d7cb5d86d6b2754a4626984cfffbfc8cb477e3665877d753da9111f", "045a0df1485dd7614bc5eb51b5612638040d5f835d1c310320ad73a051eb0391f5f953aa3c701b3e6ec8efaee2217adbfb32fb78f27eaef8203b9d6e5417f1f129", new DateTime(2022, 12, 12, 10, 54, 53, 639, DateTimeKind.Local).AddTicks(7847), "SYSTEM SEED" },
                    { 3, "0xecE385e3Fd686DA0959e375E155B036C3eb34774", new DateTime(2022, 12, 12, 10, 54, 53, 671, DateTimeKind.Local).AddTicks(7455), "SYSTEM SEED", 3, false, "TEST Wallet", "0x5178945d19f0a66cfaa52cb4b03a139d402bb682a13aaf94e75ba74bb26f55e5", "04c8867096480458cfdebf46cef3132bb0f17ab94a53de0192ff8ef25994ce19960c7cdd0a1f1d5513e270be4898cb5c0c20e6b5044f0dd49c1844e519d331e921", new DateTime(2022, 12, 12, 10, 54, 53, 671, DateTimeKind.Local).AddTicks(7466), "SYSTEM SEED" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiCredentials_EcommerceId",
                table: "ApiCredentials",
                column: "EcommerceId");

            migrationBuilder.CreateIndex(
                name: "IX_EcommerceAdmins_EcommerceId",
                table: "EcommerceAdmins",
                column: "EcommerceId");

            migrationBuilder.CreateIndex(
                name: "IX_EcommerceAdmins_Username",
                table: "EcommerceAdmins",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EcommerceManagers_Username",
                table: "EcommerceManagers",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ecommerces_Cnpj_Email",
                table: "Ecommerces",
                columns: new[] { "Cnpj", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ecommerces_ManagerId",
                table: "Ecommerces",
                column: "ManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EtherWallets_EcommerceId",
                table: "EtherWallets",
                column: "EcommerceId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_EcommerceId",
                table: "Purchases",
                column: "EcommerceId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseCheckId",
                table: "Purchases",
                column: "PurchaseCheckId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseEventFailId",
                table: "Purchases",
                column: "PurchaseEventFailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseEventId",
                table: "Purchases",
                column: "PurchaseEventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleBond_EcommerceAdminId",
                table: "RoleBond",
                column: "EcommerceAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleBond_RoleId",
                table: "RoleBond",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiCredentials");

            migrationBuilder.DropTable(
                name: "EtherWallets");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "RoleBond");

            migrationBuilder.DropTable(
                name: "PurchaseChecks");

            migrationBuilder.DropTable(
                name: "PurchaseEventFails");

            migrationBuilder.DropTable(
                name: "PurchaseEvents");

            migrationBuilder.DropTable(
                name: "EcommerceAdmins");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Ecommerces");

            migrationBuilder.DropTable(
                name: "EcommerceManagers");
        }
    }
}
