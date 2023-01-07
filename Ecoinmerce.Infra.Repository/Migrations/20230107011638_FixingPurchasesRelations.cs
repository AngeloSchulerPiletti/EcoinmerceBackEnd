using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class FixingPurchasesRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchaseChecks_PurchaseCheckId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchaseEventFails_PurchaseEventFailId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_PurchaseEvents_PurchaseEventId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PurchaseCheckId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PurchaseEventFailId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_PurchaseEventId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchaseCheckId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchaseEventFailId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchaseEventId",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "PurchaseEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "PurchaseEventFails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseId",
                table: "PurchaseChecks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseEventFails_PurchaseId",
                table: "PurchaseEventFails",
                column: "PurchaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseChecks_PurchaseId",
                table: "PurchaseChecks",
                column: "PurchaseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseChecks_Purchases_PurchaseId",
                table: "PurchaseChecks",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseEventFails_Purchases_PurchaseId",
                table: "PurchaseEventFails",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseEvents_Purchases_PurchaseId",
                table: "PurchaseEvents",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseChecks_Purchases_PurchaseId",
                table: "PurchaseChecks");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseEventFails_Purchases_PurchaseId",
                table: "PurchaseEventFails");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseEvents_Purchases_PurchaseId",
                table: "PurchaseEvents");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseEvents_PurchaseId",
                table: "PurchaseEvents");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseEventFails_PurchaseId",
                table: "PurchaseEventFails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseChecks_PurchaseId",
                table: "PurchaseChecks");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "PurchaseEvents");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "PurchaseEventFails");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "PurchaseChecks");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseCheckId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseEventFailId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseEventId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjczMDUzMDMzLCJleHAiOjE2NzQ3ODEwMzMsImlhdCI6MTY3MzA1MzAzM30.0CiYRwfyZ4RCEaF53SF5Ii7BfV2MDf8vrAS93pgBVrc", new DateTime(2023, 1, 27, 0, 57, 13, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 57, 13, 158, DateTimeKind.Local).AddTicks(1526), new DateTime(2023, 1, 6, 21, 57, 13, 158, DateTimeKind.Local).AddTicks(1527) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMDUzMDMzLCJleHAiOjE2NzQ3ODEwMzMsImlhdCI6MTY3MzA1MzAzM30.wgBtqMPlYaJkCT14v9RqsNKUy4YyX-m_SdR3KC53qeg", new DateTime(2023, 1, 27, 0, 57, 13, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 57, 13, 183, DateTimeKind.Local).AddTicks(7357), new DateTime(2023, 1, 6, 21, 57, 13, 183, DateTimeKind.Local).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1MzAzMywiZXhwIjoxNjc0NzgxMDMzLCJpYXQiOjE2NzMwNTMwMzN9.QL4JYL6323k3274MQ05hA3GsVoSvnvBR7eVgrRG5dYg", new DateTime(2023, 1, 27, 0, 57, 13, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 57, 13, 209, DateTimeKind.Local).AddTicks(6656), new DateTime(2023, 1, 6, 21, 57, 13, 209, DateTimeKind.Local).AddTicks(6656) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY3MzA1MzAzMywiZXhwIjoxNjczMDk2MjMzLCJpYXQiOjE2NzMwNTMwMzN9.LqYc7MJxoA6t8z17sQ5fxyGGMoDsUq7ZLKw7kybrxKg", new DateTime(2023, 1, 7, 12, 57, 13, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 57, 13, 148, DateTimeKind.Local).AddTicks(198), "jqoTkBb6fK9ioMGwVAlvUIroGsQeXjh/ilCVqzXpspU=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1MzAzMywiZXhwIjoxNjczMjI1ODMzLCJpYXQiOjE2NzMwNTMwMzN9.b8glZhkHaUDgULxxct2FQm6L9gVIruEsjyVTJeVB6yQ", new DateTime(2023, 1, 9, 0, 57, 13, 0, DateTimeKind.Utc), new byte[] { 224, 56, 78, 201, 209, 147, 236, 10, 245, 181, 102, 2, 107, 226, 211, 204, 92, 109, 161, 253, 246, 119, 213, 74, 39, 43, 86, 138, 214, 64, 50, 198, 97, 45, 176, 102, 91, 46, 224, 192 }, new DateTime(2023, 1, 6, 21, 57, 13, 148, DateTimeKind.Local).AddTicks(202) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2NzMwNTMwMzMsImV4cCI6MTY3MzA5NjIzMywiaWF0IjoxNjczMDUzMDMzfQ.Ur2tfPSxd66H6eIGK9QMPiD2hJxo1oNx3CWVHGaENUo", new DateTime(2023, 1, 7, 12, 57, 13, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 57, 13, 173, DateTimeKind.Local).AddTicks(4154), "B7Z/2Hgwg2zVaN2XOo0N0QPFoB6EIqAGNv7Eed3k/r8=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMDUzMDMzLCJleHAiOjE2NzMyMjU4MzMsImlhdCI6MTY3MzA1MzAzM30.oJPPmxvHgrnl5JpYgM-VglIbo8nO8k1shrAV9r42sL4", new DateTime(2023, 1, 9, 0, 57, 13, 0, DateTimeKind.Utc), new byte[] { 76, 90, 135, 198, 141, 233, 160, 100, 191, 0, 135, 91, 150, 79, 80, 97, 197, 215, 250, 125, 179, 140, 5, 161, 168, 239, 214, 17, 180, 221, 184, 133, 115, 146, 51, 86, 156, 26, 133, 1 }, new DateTime(2023, 1, 6, 21, 57, 13, 173, DateTimeKind.Local).AddTicks(4155) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjczMDUzMDMzLCJleHAiOjE2NzMwOTYyMzMsImlhdCI6MTY3MzA1MzAzM30.V6jP__MJlSNIyVoQWi9U3xNZh-Cvw0E0usgmoHP5lJU", new DateTime(2023, 1, 7, 12, 57, 13, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 57, 13, 198, DateTimeKind.Local).AddTicks(8705), "CljyfCl1aYsf8jxtYhewu0tTZEtA3Muop/8H/PAWQWs=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1MzAzMywiZXhwIjoxNjczMjI1ODMzLCJpYXQiOjE2NzMwNTMwMzN9.ec6oCg-4VxAvA5ggzTMEIXwSpdVOfkyFzaPDnMfu_0s", new DateTime(2023, 1, 9, 0, 57, 13, 0, DateTimeKind.Utc), new byte[] { 176, 56, 163, 16, 77, 18, 194, 222, 203, 0, 38, 209, 182, 138, 144, 210, 58, 181, 23, 213, 183, 142, 108, 131, 234, 188, 118, 130, 223, 137, 46, 70, 248, 41, 250, 186, 138, 7, 108, 107 }, new DateTime(2023, 1, 6, 21, 57, 13, 198, DateTimeKind.Local).AddTicks(8706) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2NzMwNTMwMzMsImV4cCI6MTY3MzA5NjIzMywiaWF0IjoxNjczMDUzMDMzfQ.ZRoA1oZ8WK2Ch759I0kolWMnKPHKNh2GFE6ZZ3BKdE4", new DateTime(2023, 1, 7, 12, 57, 13, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 57, 13, 137, DateTimeKind.Local).AddTicks(1905), "h3je7yvZ7Db+O+za36f7CUcXIvkwrM05RJVTFmNaSgg=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjczMDUzMDMzLCJleHAiOjE2NzMyMjU4MzMsImlhdCI6MTY3MzA1MzAzM30.m_819zSBkSdVrL7sQJNCQbGxbs0E0WpfYrpP3z6Texo", new DateTime(2023, 1, 9, 0, 57, 13, 0, DateTimeKind.Utc), new byte[] { 20, 141, 212, 61, 121, 44, 150, 51, 185, 210, 148, 78, 64, 254, 61, 187, 33, 1, 131, 53, 79, 121, 104, 89, 8, 17, 107, 186, 169, 154, 177, 23, 6, 255, 189, 114, 129, 68, 52, 41 }, new DateTime(2023, 1, 6, 21, 57, 13, 137, DateTimeKind.Local).AddTicks(1914) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMDUzMDMzLCJleHAiOjE2NzMwOTYyMzMsImlhdCI6MTY3MzA1MzAzM30.YY0a0TAHWVUG2Wecdl59Iso8IjhxGNH3yxX4yxRvFns", new DateTime(2023, 1, 7, 12, 57, 13, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 57, 13, 163, DateTimeKind.Local).AddTicks(1804), "dMMHvNHubwJLfcTKPSbRatI0mCEFo7pjjoJ7W4tBsSk=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2NzMwNTMwMzMsImV4cCI6MTY3MzIyNTgzMywiaWF0IjoxNjczMDUzMDMzfQ.UfBlOjihCG-fzIXgDP2kjvLjNqbBteAXE8TR4xxiywE", new DateTime(2023, 1, 9, 0, 57, 13, 0, DateTimeKind.Utc), new byte[] { 221, 206, 24, 254, 111, 163, 165, 26, 123, 136, 47, 238, 205, 160, 152, 225, 12, 254, 77, 196, 203, 42, 88, 255, 30, 255, 182, 194, 39, 113, 125, 84, 225, 194, 232, 132, 62, 185, 195, 202 }, new DateTime(2023, 1, 6, 21, 57, 13, 163, DateTimeKind.Local).AddTicks(1805) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1MzAzMywiZXhwIjoxNjczMDk2MjMzLCJpYXQiOjE2NzMwNTMwMzN9.wBPE5RqWnOgzAEeXShItSSIAr0iRU8Utu0qkmoHrl-U", new DateTime(2023, 1, 7, 12, 57, 13, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 57, 13, 188, DateTimeKind.Local).AddTicks(4654), "+oW0N6bdRqaXG/bo30OpXEXJatogS7wzfAhjZLDGNY4=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjczMDUzMDMzLCJleHAiOjE2NzMyMjU4MzMsImlhdCI6MTY3MzA1MzAzM30.8YcWQG-SAsMnuFkyPNjyhjVs4lXWx24Jqf3wPTyYbcQ", new DateTime(2023, 1, 9, 0, 57, 13, 0, DateTimeKind.Utc), new byte[] { 139, 159, 74, 205, 41, 135, 246, 81, 252, 64, 154, 172, 192, 152, 128, 128, 217, 43, 98, 185, 22, 193, 83, 54, 85, 202, 132, 106, 179, 231, 234, 163, 49, 105, 144, 207, 182, 83, 56, 38 }, new DateTime(2023, 1, 6, 21, 57, 13, 188, DateTimeKind.Local).AddTicks(4656) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 57, 13, 158, DateTimeKind.Local).AddTicks(1518), new DateTime(2023, 1, 6, 21, 57, 13, 158, DateTimeKind.Local).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 57, 13, 183, DateTimeKind.Local).AddTicks(7345), new DateTime(2023, 1, 6, 21, 57, 13, 183, DateTimeKind.Local).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 57, 13, 209, DateTimeKind.Local).AddTicks(6648), new DateTime(2023, 1, 6, 21, 57, 13, 209, DateTimeKind.Local).AddTicks(6649) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 57, 13, 163, DateTimeKind.Local).AddTicks(1546), new DateTime(2023, 1, 6, 21, 57, 13, 163, DateTimeKind.Local).AddTicks(1557) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 57, 13, 188, DateTimeKind.Local).AddTicks(4402), new DateTime(2023, 1, 6, 21, 57, 13, 188, DateTimeKind.Local).AddTicks(4405) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 57, 13, 214, DateTimeKind.Local).AddTicks(4737), new DateTime(2023, 1, 6, 21, 57, 13, 214, DateTimeKind.Local).AddTicks(4742) });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchaseChecks_PurchaseCheckId",
                table: "Purchases",
                column: "PurchaseCheckId",
                principalTable: "PurchaseChecks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchaseEventFails_PurchaseEventFailId",
                table: "Purchases",
                column: "PurchaseEventFailId",
                principalTable: "PurchaseEventFails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_PurchaseEvents_PurchaseEventId",
                table: "Purchases",
                column: "PurchaseEventId",
                principalTable: "PurchaseEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
