using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations.Ecommerce
{
    public partial class CreateEcommerceTables : Migration
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
                    AverageAnualBiling = table.Column<int>(type: "int", nullable: true),
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
                values: new object[] { 1, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2Njc3NTM2NjksImV4cCI6MTY2Nzc5Njg2OSwiaWF0IjoxNjY3NzUzNjY5fQ.EcKzl5wEKukGulGinbFgGAJ-2jWJPbKdtlO8FdTUYUo", new DateTime(2022, 11, 7, 4, 54, 29, 0, DateTimeKind.Utc), "51982505194", null, null, "05105784030", new DateTime(2022, 11, 6, 6, 54, 29, 935, DateTimeKind.Local).AddTicks(682), 1, "angelopiletti@gmail.com", "Angelo", false, true, "Schuler Piletti", "2dEUZqWXAnWWrNdsauA13gQ0P0AtU43ElCDceARc2C0=", "5134732749", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjY5LCJleHAiOjE2Njc5MjY0NjksImlhdCI6MTY2Nzc1MzY2OX0.daHLMURqrgw3eEVbxY7RSBLqIJF3vcIpdYzrHOchjpI", new DateTime(2022, 11, 8, 16, 54, 29, 0, DateTimeKind.Utc), new byte[] { 251, 150, 143, 28, 141, 152, 121, 32, 79, 252, 150, 200, 134, 140, 16, 140, 60, 51, 131, 0, 196, 89, 91, 114, 5, 209, 227, 26, 246, 50, 245, 90, 106, 243, 252, 242, 227, 238, 194, 148 }, new DateTime(2022, 11, 6, 6, 54, 29, 935, DateTimeKind.Local).AddTicks(719), "angeloManager" });

            migrationBuilder.InsertData(
                table: "EcommerceManagers",
                columns: new[] { "Id", "AccessToken", "AccessTokenExpiry", "Cellphone", "ConfirmationToken", "ConfirmationTokenExpiry", "Cpf", "CreatedAt", "EcommerceId", "Email", "FirstName", "IsDeleted", "IsEmailConfirmed", "LastName", "Password", "Phone", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt", "Username" },
                values: new object[] { 2, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjY5LCJleHAiOjE2Njc3OTY4NjksImlhdCI6MTY2Nzc1MzY2OX0._qabhQfXUeqXRHBooQ0sA0AgGyeacAYmTztCg4F2gVs", new DateTime(2022, 11, 7, 4, 54, 29, 0, DateTimeKind.Utc), "51982505194", null, null, "05105784030", new DateTime(2022, 11, 6, 6, 54, 29, 976, DateTimeKind.Local).AddTicks(7249), 2, "bruna.fusiger@gmail.com", "Bruna", false, true, "Fusiger", "cGRom+5rCg86YgjSu1QO31gZCM2IgZ3/ByGIogPHuG0=", "5134732749", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2Njc3NTM2NjksImV4cCI6MTY2NzkyNjQ2OSwiaWF0IjoxNjY3NzUzNjY5fQ.1cY4N_r5TJmc97APX30T-CZ7Nyu-JxIAdjIQRqQUi64", new DateTime(2022, 11, 8, 16, 54, 29, 0, DateTimeKind.Utc), new byte[] { 181, 33, 139, 219, 137, 32, 165, 64, 148, 15, 110, 39, 18, 99, 163, 72, 115, 217, 5, 90, 201, 100, 143, 241, 126, 12, 121, 195, 113, 54, 245, 107, 76, 159, 9, 225, 170, 19, 196, 151 }, new DateTime(2022, 11, 6, 6, 54, 29, 976, DateTimeKind.Local).AddTicks(7253), "brunaManager" });

            migrationBuilder.InsertData(
                table: "EcommerceManagers",
                columns: new[] { "Id", "AccessToken", "AccessTokenExpiry", "Cellphone", "ConfirmationToken", "ConfirmationTokenExpiry", "Cpf", "CreatedAt", "EcommerceId", "Email", "FirstName", "IsDeleted", "IsEmailConfirmed", "LastName", "Password", "Phone", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt", "Username" },
                values: new object[] { 3, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzc1MzY3MCwiZXhwIjoxNjY3Nzk2ODcwLCJpYXQiOjE2Njc3NTM2NzB9.Wd10HMKT6OCadWZT9EcEn3S8toafdKd2fPkyfKuHiHA", new DateTime(2022, 11, 7, 4, 54, 30, 0, DateTimeKind.Utc), "51982505194", null, null, "05105784030", new DateTime(2022, 11, 6, 6, 54, 30, 17, DateTimeKind.Local).AddTicks(2631), 3, "lucasoliveira.contatonline@gmail.com", "Lucas", false, true, "Oliveira", "kcomEk8tf+sfiE4OdD/KvqEc66/LmmdxvxCH27Mh4jY=", "5134732749", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjcwLCJleHAiOjE2Njc5MjY0NzAsImlhdCI6MTY2Nzc1MzY3MH0.hJGYfEfkIBG_ob-6LvNdFSpOEk5jZBpiNLPoZYFHeVc", new DateTime(2022, 11, 8, 16, 54, 30, 0, DateTimeKind.Utc), new byte[] { 88, 16, 194, 200, 201, 168, 19, 232, 192, 135, 232, 250, 144, 223, 175, 19, 0, 8, 238, 33, 117, 51, 98, 41, 162, 11, 42, 161, 247, 146, 194, 215, 104, 223, 93, 254, 75, 71, 209, 164 }, new DateTime(2022, 11, 6, 6, 54, 30, 17, DateTimeKind.Local).AddTicks(2636), "lucasManager" });

            migrationBuilder.InsertData(
                table: "Ecommerces",
                columns: new[] { "Id", "AverageAnualBiling", "AverageTotalEmployees", "Cep", "Cnpj", "ConfirmationToken", "ConfirmationTokenExpiry", "CreatedAt", "Email", "FantasyName", "IsDeleted", "IsEmailConfirmed", "ManagerId", "Phone", "SocialReason", "UpdatedAt", "Website" },
                values: new object[] { 1, 10000000, 100, "93270420", "74544297000192", null, null, new DateTime(2022, 11, 6, 6, 54, 29, 968, DateTimeKind.Local).AddTicks(8151), "angelopiletti@gmail.com", "TEST Nome Fantasia", false, true, 1, "5134732749", "TEST S.A", new DateTime(2022, 11, 6, 6, 54, 29, 968, DateTimeKind.Local).AddTicks(8155), "https://google.com" });

            migrationBuilder.InsertData(
                table: "Ecommerces",
                columns: new[] { "Id", "AverageAnualBiling", "AverageTotalEmployees", "Cep", "Cnpj", "ConfirmationToken", "ConfirmationTokenExpiry", "CreatedAt", "Email", "FantasyName", "IsDeleted", "IsEmailConfirmed", "ManagerId", "Phone", "SocialReason", "UpdatedAt", "Website" },
                values: new object[] { 2, 10000000, 100, "93270420", "74544297000192", null, null, new DateTime(2022, 11, 6, 6, 54, 30, 9, DateTimeKind.Local).AddTicks(4779), "bruna.fusiger@gmail.com", "TEST Nome Fantasia", false, true, 2, "5134732749", "TEST S.A", new DateTime(2022, 11, 6, 6, 54, 30, 9, DateTimeKind.Local).AddTicks(4783), "https://google.com" });

            migrationBuilder.InsertData(
                table: "Ecommerces",
                columns: new[] { "Id", "AverageAnualBiling", "AverageTotalEmployees", "Cep", "Cnpj", "ConfirmationToken", "ConfirmationTokenExpiry", "CreatedAt", "Email", "FantasyName", "IsDeleted", "IsEmailConfirmed", "ManagerId", "Phone", "SocialReason", "UpdatedAt", "Website" },
                values: new object[] { 3, 10000000, 100, "93270420", "74544297000192", null, null, new DateTime(2022, 11, 6, 6, 54, 30, 47, DateTimeKind.Local).AddTicks(5690), "lucasoliveira.contatonline@gmail.com", "TEST Nome Fantasia", false, true, 3, "5134732749", "TEST S.A", new DateTime(2022, 11, 6, 6, 54, 30, 47, DateTimeKind.Local).AddTicks(5692), "https://google.com" });

            migrationBuilder.InsertData(
                table: "ApiCredentials",
                columns: new[] { "Id", "AccessToken", "AccessTokenExpiry", "CreatedAt", "CreatedBy", "Description", "EcommerceId", "Name", "UpdatedAt", "UpdatedBy", "ValidityInDays" },
                values: new object[,]
                {
                    { 1, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjY5LCJleHAiOjE2Njk0ODE2NjksImlhdCI6MTY2Nzc1MzY2OX0.a22eO9zUjfUG7KXAS82SwjyLLvu_n_2gKWKI31hW1nY", new DateTime(2022, 11, 26, 16, 54, 29, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 29, 968, DateTimeKind.Local).AddTicks(8166), "SYSTEM SEED", "Esse aqui é um api credencial criado automaticamente como teste", 1, "TESTE Credencial", new DateTime(2022, 11, 6, 6, 54, 29, 968, DateTimeKind.Local).AddTicks(8168), "SYSTEM SEED", 20 },
                    { 2, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjcwLCJleHAiOjE2Njk0ODE2NzAsImlhdCI6MTY2Nzc1MzY3MH0.gaY8YSN7zhJQxrSI_eKpj1XjslzzM-Vejqfmfkli2Ks", new DateTime(2022, 11, 26, 16, 54, 30, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 30, 9, DateTimeKind.Local).AddTicks(4792), "SYSTEM SEED", "Esse aqui é um api credencial criado automaticamente como teste", 2, "TESTE Credencial", new DateTime(2022, 11, 6, 6, 54, 30, 9, DateTimeKind.Local).AddTicks(4794), "SYSTEM SEED", 20 },
                    { 3, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzc1MzY3MCwiZXhwIjoxNjY5NDgxNjcwLCJpYXQiOjE2Njc3NTM2NzB9.lvOrWOWfMgpIG1oosHYtv43dRzltqNWmyrgLl64m4u4", new DateTime(2022, 11, 26, 16, 54, 30, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 30, 47, DateTimeKind.Local).AddTicks(5701), "SYSTEM SEED", "Esse aqui é um api credencial criado automaticamente como teste", 3, "TESTE Credencial", new DateTime(2022, 11, 6, 6, 54, 30, 47, DateTimeKind.Local).AddTicks(5702), "SYSTEM SEED", 20 }
                });

            migrationBuilder.InsertData(
                table: "EcommerceAdmins",
                columns: new[] { "Id", "AccessToken", "AccessTokenExpiry", "ConfirmationToken", "ConfirmationTokenExpiry", "CreatedAt", "CreatedBy", "EcommerceId", "Email", "FirstName", "IsDeleted", "IsEmailConfirmed", "LastName", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt", "UpdatedBy", "Username" },
                values: new object[,]
                {
                    { 1, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY2Nzc1MzY2OSwiZXhwIjoxNjY3Nzk2ODY5LCJpYXQiOjE2Njc3NTM2Njl9.8hf20Qs0j9MktyzhLOyAOTlaIlp7O8Fb-TKz0h_dKkY", new DateTime(2022, 11, 7, 4, 54, 29, 0, DateTimeKind.Utc), null, null, new DateTime(2022, 11, 6, 6, 54, 29, 951, DateTimeKind.Local).AddTicks(8435), "SYSTEM SEED", 1, "angelopiletti@gmail.com", "Angelo", false, true, "Schuler Piletti", "r81PijBAoTAPZ4BZAaO35pIlP4BaXb157yeBrD8qZ0w=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzc1MzY2OSwiZXhwIjoxNjY3OTI2NDY5LCJpYXQiOjE2Njc3NTM2Njl9.BG8YxT2ZhsL-zv77rT3l3GqGP96v9HDlJaBSUL5er2w", new DateTime(2022, 11, 8, 16, 54, 29, 0, DateTimeKind.Utc), new byte[] { 117, 78, 252, 120, 206, 189, 210, 166, 21, 136, 174, 153, 111, 233, 99, 222, 159, 117, 253, 15, 34, 62, 24, 51, 206, 155, 85, 162, 38, 227, 240, 21, 233, 102, 156, 179, 131, 203, 120, 90 }, new DateTime(2022, 11, 6, 6, 54, 29, 951, DateTimeKind.Local).AddTicks(8438), "SYSTEM SEED", "angeloAdmin" },
                    { 2, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2Njc3NTM2NzAsImV4cCI6MTY2Nzc5Njg3MCwiaWF0IjoxNjY3NzUzNjcwfQ.-CuETKjaYeEhdSwf25S6yzpjJEDWn_FV1nTMekeZdLE", new DateTime(2022, 11, 7, 4, 54, 30, 0, DateTimeKind.Utc), null, null, new DateTime(2022, 11, 6, 6, 54, 29, 993, DateTimeKind.Local).AddTicks(1746), "SYSTEM SEED", 2, "bruna.fusiger@gmail.com", "Bruna", false, true, "Fusiger", "n7UMJuYz92m4s9qib+q4x35ijaTtTgc6jeyQ1uc6SnA=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjcwLCJleHAiOjE2Njc5MjY0NzAsImlhdCI6MTY2Nzc1MzY3MH0.qRfJlrJE7tixUIQWNgRpHOCR2SRvCE4qAhOVduFWadw", new DateTime(2022, 11, 8, 16, 54, 30, 0, DateTimeKind.Utc), new byte[] { 56, 76, 38, 58, 219, 170, 128, 145, 111, 251, 241, 53, 160, 31, 16, 212, 117, 32, 149, 92, 36, 32, 85, 254, 216, 140, 187, 150, 186, 52, 248, 62, 19, 115, 1, 55, 225, 141, 73, 235 }, new DateTime(2022, 11, 6, 6, 54, 29, 993, DateTimeKind.Local).AddTicks(1749), "SYSTEM SEED", "brunaAdmin" },
                    { 3, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjY3NzUzNjcwLCJleHAiOjE2Njc3OTY4NzAsImlhdCI6MTY2Nzc1MzY3MH0.8LrIQNkf1bCnqAf6Ena2lzHonXWZRf-GXwKIQIiOwKI", new DateTime(2022, 11, 7, 4, 54, 30, 0, DateTimeKind.Utc), null, null, new DateTime(2022, 11, 6, 6, 54, 30, 32, DateTimeKind.Local).AddTicks(8397), "SYSTEM SEED", 3, "lucasoliveira.contatonline@gmail.com", "Lucas", false, true, "Oliveira", "6trvQ+D4HDHNQCiXT9xLxZH/bfiInQjdhtUJlBzZdDk=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzc1MzY3MCwiZXhwIjoxNjY3OTI2NDcwLCJpYXQiOjE2Njc3NTM2NzB9.h7EQZhlp2_ptC3P2lEcJOmt8I_Vi-rKzQrNs4tMg4n0", new DateTime(2022, 11, 8, 16, 54, 30, 0, DateTimeKind.Utc), new byte[] { 142, 253, 172, 162, 201, 73, 152, 243, 70, 100, 115, 89, 111, 215, 171, 92, 178, 35, 27, 154, 220, 65, 19, 170, 250, 64, 182, 176, 160, 148, 74, 202, 64, 178, 251, 158, 238, 76, 127, 51 }, new DateTime(2022, 11, 6, 6, 54, 30, 32, DateTimeKind.Local).AddTicks(8400), "SYSTEM SEED", "lucasAdmin" }
                });

            migrationBuilder.InsertData(
                table: "EtherWallets",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "EcommerceId", "IsDeleted", "Name", "PrivateKey", "PublicKey", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "0x83596d3984C65c48D9f167ada9698BECFa709571", new DateTime(2022, 11, 6, 6, 54, 29, 976, DateTimeKind.Local).AddTicks(6912), "SYSTEM SEED", 1, false, "TEST Wallet", "0x879b22729079d26717c15544e85f3692229b481368ea4b5a65ca289a5c26db53", "0489249214e77e5d07d2de2e63b82f5e2029e4d0d739a341a166e6363db1c338e749f11823ded16954ba15070dd496f109a9655c7b9cd08417538ed5ac8d1216b2", new DateTime(2022, 11, 6, 6, 54, 29, 976, DateTimeKind.Local).AddTicks(6942), "SYSTEM SEED" },
                    { 2, "0xd49B964c84132F43e3d1Ed3A7b67B57304Cb6fB3", new DateTime(2022, 11, 6, 6, 54, 30, 17, DateTimeKind.Local).AddTicks(2332), "SYSTEM SEED", 2, false, "TEST Wallet", "0x830226e76d7cb5d86d6b2754a4626984cfffbfc8cb477e3665877d753da9111f", "045a0df1485dd7614bc5eb51b5612638040d5f835d1c310320ad73a051eb0391f5f953aa3c701b3e6ec8efaee2217adbfb32fb78f27eaef8203b9d6e5417f1f129", new DateTime(2022, 11, 6, 6, 54, 30, 17, DateTimeKind.Local).AddTicks(2354), "SYSTEM SEED" },
                    { 3, "0xecE385e3Fd686DA0959e375E155B036C3eb34774", new DateTime(2022, 11, 6, 6, 54, 30, 59, DateTimeKind.Local).AddTicks(844), "SYSTEM SEED", 3, false, "TEST Wallet", "0x5178945d19f0a66cfaa52cb4b03a139d402bb682a13aaf94e75ba74bb26f55e5", "04c8867096480458cfdebf46cef3132bb0f17ab94a53de0192ff8ef25994ce19960c7cdd0a1f1d5513e270be4898cb5c0c20e6b5044f0dd49c1844e519d331e921", new DateTime(2022, 11, 6, 6, 54, 30, 59, DateTimeKind.Local).AddTicks(874), "SYSTEM SEED" }
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
                name: "RoleBond");

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
