using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class PurchaseRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseEvents");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaidInEther",
                table: "Purchases",
                type: "decimal(28,18)",
                precision: 28,
                scale: 18,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidAt",
                table: "Purchases",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseIdentifier",
                table: "Purchases",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjczMTI1NDc2LCJleHAiOjE2NzQ4NTM0NzYsImlhdCI6MTY3MzEyNTQ3Nn0.S0rDt3kv0CZEetZZ0Sc-DntQTBsoI8uwQWpO6g-vwsk", new DateTime(2023, 1, 27, 21, 4, 36, 0, DateTimeKind.Utc), new DateTime(2023, 1, 7, 18, 4, 36, 272, DateTimeKind.Local).AddTicks(7010), new DateTime(2023, 1, 7, 18, 4, 36, 272, DateTimeKind.Local).AddTicks(7010) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMTI1NDc2LCJleHAiOjE2NzQ4NTM0NzYsImlhdCI6MTY3MzEyNTQ3Nn0.SKrH4vh5O7rbQXo8LwkQ4nhC94ynmNJj0ip4OH8Dxn0", new DateTime(2023, 1, 27, 21, 4, 36, 0, DateTimeKind.Utc), new DateTime(2023, 1, 7, 18, 4, 36, 312, DateTimeKind.Local).AddTicks(3948), new DateTime(2023, 1, 7, 18, 4, 36, 312, DateTimeKind.Local).AddTicks(3950) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzEyNTQ3NiwiZXhwIjoxNjc0ODUzNDc2LCJpYXQiOjE2NzMxMjU0NzZ9.naQRF-TKHJ62nbzhyjgppMklhr3_CiMyfc_vFC29ncg", new DateTime(2023, 1, 27, 21, 4, 36, 0, DateTimeKind.Utc), new DateTime(2023, 1, 7, 18, 4, 36, 347, DateTimeKind.Local).AddTicks(183), new DateTime(2023, 1, 7, 18, 4, 36, 347, DateTimeKind.Local).AddTicks(184) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY3MzEyNTQ3NiwiZXhwIjoxNjczMTY4Njc2LCJpYXQiOjE2NzMxMjU0NzZ9.PMGpWyJF_cD-siSX2ahtasGRN9pCQQ4j1qa0ZwO9acQ", new DateTime(2023, 1, 8, 9, 4, 36, 0, DateTimeKind.Utc), new DateTime(2023, 1, 7, 18, 4, 36, 258, DateTimeKind.Local).AddTicks(6688), "UjXhMCQR0FOat0V4bDsFhl5oTNYGGGKwlbnpgGh4gnA=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzEyNTQ3NiwiZXhwIjoxNjczMjk4Mjc2LCJpYXQiOjE2NzMxMjU0NzZ9.1S59r7m0QWWl2QsZoqKWxxGB3kU5SSojLsBtXqMwXtE", new DateTime(2023, 1, 9, 21, 4, 36, 0, DateTimeKind.Utc), new byte[] { 142, 78, 214, 67, 182, 180, 206, 186, 5, 19, 130, 106, 149, 159, 50, 240, 250, 190, 254, 19, 129, 134, 74, 88, 41, 159, 29, 8, 12, 90, 5, 13, 187, 40, 176, 55, 76, 112, 227, 152 }, new DateTime(2023, 1, 7, 18, 4, 36, 258, DateTimeKind.Local).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2NzMxMjU0NzYsImV4cCI6MTY3MzE2ODY3NiwiaWF0IjoxNjczMTI1NDc2fQ.xNZeEDiTvSd_8GQyypMkXmEA9E-ni31MYmP1P1dLdCA", new DateTime(2023, 1, 8, 9, 4, 36, 0, DateTimeKind.Utc), new DateTime(2023, 1, 7, 18, 4, 36, 296, DateTimeKind.Local).AddTicks(5420), "fJbRpo/uPWtPEfPZ/PCCT1Azdx3KlNVFx71xzIB9LRE=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMTI1NDc2LCJleHAiOjE2NzMyOTgyNzYsImlhdCI6MTY3MzEyNTQ3Nn0.aZoH6o1tDOr3TLoC3bxjrxO9l-uprD5iU9f_vxmQvKI", new DateTime(2023, 1, 9, 21, 4, 36, 0, DateTimeKind.Utc), new byte[] { 201, 96, 89, 125, 79, 88, 120, 54, 170, 89, 55, 224, 51, 113, 92, 99, 159, 57, 236, 125, 209, 70, 96, 68, 201, 72, 122, 223, 3, 60, 91, 48, 146, 28, 221, 134, 64, 132, 225, 16 }, new DateTime(2023, 1, 7, 18, 4, 36, 296, DateTimeKind.Local).AddTicks(5421) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjczMTI1NDc2LCJleHAiOjE2NzMxNjg2NzYsImlhdCI6MTY3MzEyNTQ3Nn0._uSi6rjNtz2_UZVJMRi1ORHEFyqOVFQ5viz9j0_18xI", new DateTime(2023, 1, 8, 9, 4, 36, 0, DateTimeKind.Utc), new DateTime(2023, 1, 7, 18, 4, 36, 331, DateTimeKind.Local).AddTicks(8580), "ah97so7RKtGcsHZm838xrnLqLl0YNHqPb7N941CpcB0=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzEyNTQ3NiwiZXhwIjoxNjczMjk4Mjc2LCJpYXQiOjE2NzMxMjU0NzZ9.iPom03h3yebmkf_jb0iXVLw4bhSqaFqTO6ZA_LrYV4Q", new DateTime(2023, 1, 9, 21, 4, 36, 0, DateTimeKind.Utc), new byte[] { 171, 146, 116, 186, 25, 137, 167, 185, 60, 69, 189, 213, 200, 51, 239, 62, 5, 97, 247, 192, 37, 33, 254, 227, 196, 142, 63, 191, 106, 167, 21, 82, 211, 17, 73, 82, 91, 155, 20, 88 }, new DateTime(2023, 1, 7, 18, 4, 36, 331, DateTimeKind.Local).AddTicks(8581) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2NzMxMjU0NzYsImV4cCI6MTY3MzE2ODY3NiwiaWF0IjoxNjczMTI1NDc2fQ.XpGGQqJS_dH0Z005OHw4T6bqEtZhPDVPY6BHEo4RS44", new DateTime(2023, 1, 8, 9, 4, 36, 0, DateTimeKind.Utc), new DateTime(2023, 1, 7, 18, 4, 36, 239, DateTimeKind.Local).AddTicks(9577), "teqnenBAtxj+VXFcQIr+id4jM6ofMqzdU7cXinqMAzY=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjczMTI1NDc2LCJleHAiOjE2NzMyOTgyNzYsImlhdCI6MTY3MzEyNTQ3Nn0.SmfaLWBtv4lrbmx1T14PSoZyT7tGHugdp3KFtJ3zNlI", new DateTime(2023, 1, 9, 21, 4, 36, 0, DateTimeKind.Utc), new byte[] { 89, 150, 237, 192, 240, 3, 164, 186, 71, 230, 28, 238, 74, 27, 80, 136, 121, 46, 23, 148, 130, 183, 27, 90, 213, 100, 83, 100, 186, 84, 218, 203, 232, 172, 80, 207, 99, 72, 0, 251 }, new DateTime(2023, 1, 7, 18, 4, 36, 239, DateTimeKind.Local).AddTicks(9633) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMTI1NDc2LCJleHAiOjE2NzMxNjg2NzYsImlhdCI6MTY3MzEyNTQ3Nn0.4MHFNz7RKdLoflNEoLwB77X4sdRZcaB8K3muyf7dhUA", new DateTime(2023, 1, 8, 9, 4, 36, 0, DateTimeKind.Utc), new DateTime(2023, 1, 7, 18, 4, 36, 282, DateTimeKind.Local).AddTicks(5856), "JjG12b+cB45aw3cTGWCWpbstBzigmp7596AtRw1q8EA=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2NzMxMjU0NzYsImV4cCI6MTY3MzI5ODI3NiwiaWF0IjoxNjczMTI1NDc2fQ.WRjKMr363ElQvNzxPXIBsycyhagGnfs7xaC2_dAieEw", new DateTime(2023, 1, 9, 21, 4, 36, 0, DateTimeKind.Utc), new byte[] { 71, 114, 166, 40, 92, 238, 234, 16, 114, 175, 137, 42, 9, 226, 241, 29, 79, 41, 148, 118, 178, 227, 252, 67, 8, 251, 50, 58, 179, 100, 28, 84, 40, 4, 173, 100, 244, 250, 233, 203 }, new DateTime(2023, 1, 7, 18, 4, 36, 282, DateTimeKind.Local).AddTicks(5858) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzEyNTQ3NiwiZXhwIjoxNjczMTY4Njc2LCJpYXQiOjE2NzMxMjU0NzZ9.CRMpeHh7A1ifd7m4AyIQ2UZMC2ZQ2F4IxR70IvFsEVk", new DateTime(2023, 1, 8, 9, 4, 36, 0, DateTimeKind.Utc), new DateTime(2023, 1, 7, 18, 4, 36, 319, DateTimeKind.Local).AddTicks(3548), "6iQZTypdqZMiORVepE/zC/tF9+3cChawcCEBFrgbDB4=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjczMTI1NDc2LCJleHAiOjE2NzMyOTgyNzYsImlhdCI6MTY3MzEyNTQ3Nn0.c_Zwttct2d1XJ1uiZDpkgqD3HJKOXwlNCceiHCQydls", new DateTime(2023, 1, 9, 21, 4, 36, 0, DateTimeKind.Utc), new byte[] { 33, 166, 85, 63, 187, 176, 201, 158, 117, 101, 47, 120, 48, 2, 202, 133, 253, 41, 120, 190, 4, 56, 77, 80, 145, 203, 207, 229, 218, 66, 224, 218, 133, 39, 100, 101, 123, 168, 59, 64 }, new DateTime(2023, 1, 7, 18, 4, 36, 319, DateTimeKind.Local).AddTicks(3549) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 7, 18, 4, 36, 272, DateTimeKind.Local).AddTicks(6999), new DateTime(2023, 1, 7, 18, 4, 36, 272, DateTimeKind.Local).AddTicks(7002) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 7, 18, 4, 36, 312, DateTimeKind.Local).AddTicks(3936), new DateTime(2023, 1, 7, 18, 4, 36, 312, DateTimeKind.Local).AddTicks(3938) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 7, 18, 4, 36, 347, DateTimeKind.Local).AddTicks(177), new DateTime(2023, 1, 7, 18, 4, 36, 347, DateTimeKind.Local).AddTicks(178) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 7, 18, 4, 36, 282, DateTimeKind.Local).AddTicks(5569), new DateTime(2023, 1, 7, 18, 4, 36, 282, DateTimeKind.Local).AddTicks(5581) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 7, 18, 4, 36, 319, DateTimeKind.Local).AddTicks(3277), new DateTime(2023, 1, 7, 18, 4, 36, 319, DateTimeKind.Local).AddTicks(3287) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 7, 18, 4, 36, 353, DateTimeKind.Local).AddTicks(6078), new DateTime(2023, 1, 7, 18, 4, 36, 353, DateTimeKind.Local).AddTicks(6087) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountPaidInEther",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PaidAt",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchaseIdentifier",
                table: "Purchases");

            migrationBuilder.CreateTable(
                name: "PurchaseEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    AmountPaidInEther = table.Column<decimal>(type: "decimal(28,18)", precision: 28, scale: 18, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseIdentifier = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseEvents_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjczMDU0MTk3LCJleHAiOjE2NzQ3ODIxOTcsImlhdCI6MTY3MzA1NDE5N30.mIe71fi6QsGDR5vsf839MRXho7CtPSzYKxEI-symCp8", new DateTime(2023, 1, 27, 1, 16, 37, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 22, 16, 37, 929, DateTimeKind.Local).AddTicks(8107), new DateTime(2023, 1, 6, 22, 16, 37, 929, DateTimeKind.Local).AddTicks(8108) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMDU0MTk3LCJleHAiOjE2NzQ3ODIxOTcsImlhdCI6MTY3MzA1NDE5N30.E-Fy5NdBSTqE5HlyOUOz5CyWv_1HJkuwkm6aLp2Lltg", new DateTime(2023, 1, 27, 1, 16, 37, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 22, 16, 37, 961, DateTimeKind.Local).AddTicks(9547), new DateTime(2023, 1, 6, 22, 16, 37, 961, DateTimeKind.Local).AddTicks(9547) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1NDE5NywiZXhwIjoxNjc0NzgyMTk3LCJpYXQiOjE2NzMwNTQxOTd9.7SgyI54EJR4avutzEgVol9TXbzK6k9X-aw3pMBdHDSA", new DateTime(2023, 1, 27, 1, 16, 37, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 22, 16, 37, 994, DateTimeKind.Local).AddTicks(9889), new DateTime(2023, 1, 6, 22, 16, 37, 994, DateTimeKind.Local).AddTicks(9889) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY3MzA1NDE5NywiZXhwIjoxNjczMDk3Mzk3LCJpYXQiOjE2NzMwNTQxOTd9.qdHUrNoqtI-bZ2Sg_4XrZOPE7lIs2eR_RpSHCja2i3E", new DateTime(2023, 1, 7, 13, 16, 37, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 22, 16, 37, 919, DateTimeKind.Local).AddTicks(1651), "Za769ROzBS33ARjuwFB9yCuMxhpxpdPpsMFmSQ84gqM=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1NDE5NywiZXhwIjoxNjczMjI2OTk3LCJpYXQiOjE2NzMwNTQxOTd9.xq0iSRzmrTV2XZJST6ryV_Z85pPKoWuF4BzM69wdTfE", new DateTime(2023, 1, 9, 1, 16, 37, 0, DateTimeKind.Utc), new byte[] { 221, 53, 44, 3, 45, 175, 116, 223, 74, 239, 132, 25, 181, 205, 57, 111, 82, 129, 154, 120, 234, 246, 164, 51, 81, 51, 111, 40, 183, 126, 151, 121, 72, 60, 194, 166, 41, 46, 147, 115 }, new DateTime(2023, 1, 6, 22, 16, 37, 919, DateTimeKind.Local).AddTicks(1652) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2NzMwNTQxOTcsImV4cCI6MTY3MzA5NzM5NywiaWF0IjoxNjczMDU0MTk3fQ.rlLTU7ETFvvj89rP5USAgACfO6fW_206763gxjcuWyM", new DateTime(2023, 1, 7, 13, 16, 37, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 22, 16, 37, 950, DateTimeKind.Local).AddTicks(7436), "nefKTrlXO/uNRQ3tUyI751HOjBlaOIInMSBAbflwQEM=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMDU0MTk3LCJleHAiOjE2NzMyMjY5OTcsImlhdCI6MTY3MzA1NDE5N30.c27FouapgFKyM2QiPVaCpAnkwNR4crdiZxPhHStXz-A", new DateTime(2023, 1, 9, 1, 16, 37, 0, DateTimeKind.Utc), new byte[] { 249, 166, 195, 27, 192, 105, 122, 154, 249, 69, 150, 206, 112, 105, 243, 222, 165, 214, 126, 199, 169, 62, 144, 8, 193, 181, 5, 113, 190, 206, 37, 117, 45, 162, 183, 201, 18, 120, 12, 246 }, new DateTime(2023, 1, 6, 22, 16, 37, 950, DateTimeKind.Local).AddTicks(7438) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjczMDU0MTk3LCJleHAiOjE2NzMwOTczOTcsImlhdCI6MTY3MzA1NDE5N30.AGzA33yuelb6vgEj4tHxuoxuuma8RjMIJmDqmbyQRYE", new DateTime(2023, 1, 7, 13, 16, 37, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 22, 16, 37, 983, DateTimeKind.Local).AddTicks(8856), "RuJjjMI8vhcllIWBoSYBjYumTs9JDFlOtnVNQiB9FIU=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1NDE5NywiZXhwIjoxNjczMjI2OTk3LCJpYXQiOjE2NzMwNTQxOTd9.3fX1GRZavjhHNvLhC51L5ZRa8cSpzYkxULtt1f0lrEU", new DateTime(2023, 1, 9, 1, 16, 37, 0, DateTimeKind.Utc), new byte[] { 69, 144, 109, 252, 208, 190, 105, 4, 202, 250, 31, 162, 121, 198, 70, 23, 65, 234, 167, 55, 164, 45, 161, 172, 147, 120, 208, 222, 6, 19, 177, 237, 160, 30, 217, 204, 112, 29, 107, 12 }, new DateTime(2023, 1, 6, 22, 16, 37, 983, DateTimeKind.Local).AddTicks(8857) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2NzMwNTQxOTcsImV4cCI6MTY3MzA5NzM5NywiaWF0IjoxNjczMDU0MTk3fQ.-NohvYYM6uQLEwqnkQ7CPgumZfLmxZn5AdJfe-BqWrI", new DateTime(2023, 1, 7, 13, 16, 37, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 22, 16, 37, 908, DateTimeKind.Local).AddTicks(2818), "5wgG2ideuyfOcPhsYvgcAneQJZg55pgpOy7iB+gNlWs=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjczMDU0MTk3LCJleHAiOjE2NzMyMjY5OTcsImlhdCI6MTY3MzA1NDE5N30.KdBhaYN5JyQ90q7rraoWmgUzJnE0RPlHueKlH1ceLk0", new DateTime(2023, 1, 9, 1, 16, 37, 0, DateTimeKind.Utc), new byte[] { 81, 78, 24, 253, 231, 222, 186, 200, 180, 64, 76, 90, 66, 251, 12, 56, 7, 69, 33, 21, 78, 38, 161, 31, 71, 32, 149, 73, 147, 230, 134, 70, 171, 63, 45, 55, 24, 246, 54, 225 }, new DateTime(2023, 1, 6, 22, 16, 37, 908, DateTimeKind.Local).AddTicks(2828) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMDU0MTk3LCJleHAiOjE2NzMwOTczOTcsImlhdCI6MTY3MzA1NDE5N30.tJ_jLVvgBBy3j635wDeHyJSS_GOVHge15532XGWTbHg", new DateTime(2023, 1, 7, 13, 16, 37, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 22, 16, 37, 939, DateTimeKind.Local).AddTicks(2546), "vUX4oAE2Wp4y5lV9WYRoetmZOgpp2DVOdLFJcpT8DV8=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2NzMwNTQxOTcsImV4cCI6MTY3MzIyNjk5NywiaWF0IjoxNjczMDU0MTk3fQ.texwyJWytm7VokClyYpsy2fFXv8MYnJ9gN0MKHGtnIQ", new DateTime(2023, 1, 9, 1, 16, 37, 0, DateTimeKind.Utc), new byte[] { 39, 96, 36, 141, 106, 3, 69, 30, 103, 105, 35, 75, 120, 184, 14, 6, 137, 141, 22, 125, 37, 15, 207, 119, 6, 37, 197, 24, 109, 2, 255, 131, 211, 149, 172, 246, 67, 74, 53, 119 }, new DateTime(2023, 1, 6, 22, 16, 37, 939, DateTimeKind.Local).AddTicks(2552) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1NDE5NywiZXhwIjoxNjczMDk3Mzk3LCJpYXQiOjE2NzMwNTQxOTd9.wfGIhYTz5eWyQBvAxgbLcgUUrh7zGwu-gEh2GOfslqQ", new DateTime(2023, 1, 7, 13, 16, 37, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 22, 16, 37, 973, DateTimeKind.Local).AddTicks(89), "YQp7Hax0U8fOMUB+3047j0Ft55kfO0b4slwHA5wkres=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjczMDU0MTk3LCJleHAiOjE2NzMyMjY5OTcsImlhdCI6MTY3MzA1NDE5N30.zQBmUrj09WfVwhKoKa-vxpOtAbqeiaWQuKIVHByTXkY", new DateTime(2023, 1, 9, 1, 16, 37, 0, DateTimeKind.Utc), new byte[] { 202, 32, 47, 97, 77, 74, 116, 119, 188, 64, 117, 108, 238, 17, 107, 132, 239, 213, 133, 106, 152, 126, 174, 160, 16, 218, 192, 201, 16, 225, 167, 86, 144, 255, 237, 234, 5, 190, 64, 158 }, new DateTime(2023, 1, 6, 22, 16, 37, 973, DateTimeKind.Local).AddTicks(91) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 22, 16, 37, 929, DateTimeKind.Local).AddTicks(8097), new DateTime(2023, 1, 6, 22, 16, 37, 929, DateTimeKind.Local).AddTicks(8099) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 22, 16, 37, 961, DateTimeKind.Local).AddTicks(9537), new DateTime(2023, 1, 6, 22, 16, 37, 961, DateTimeKind.Local).AddTicks(9539) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 22, 16, 37, 994, DateTimeKind.Local).AddTicks(9872), new DateTime(2023, 1, 6, 22, 16, 37, 994, DateTimeKind.Local).AddTicks(9874) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 22, 16, 37, 939, DateTimeKind.Local).AddTicks(2271), new DateTime(2023, 1, 6, 22, 16, 37, 939, DateTimeKind.Local).AddTicks(2281) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 22, 16, 37, 972, DateTimeKind.Local).AddTicks(9776), new DateTime(2023, 1, 6, 22, 16, 37, 972, DateTimeKind.Local).AddTicks(9785) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 22, 16, 38, 5, DateTimeKind.Local).AddTicks(3397), new DateTime(2023, 1, 6, 22, 16, 38, 5, DateTimeKind.Local).AddTicks(3409) });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseEvents_PurchaseId",
                table: "PurchaseEvents",
                column: "PurchaseId",
                unique: true);
        }
    }
}
