using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class FixingBlockHashLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BlockHash",
                table: "Purchases",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjczMDUyODQxLCJleHAiOjE2NzQ3ODA4NDEsImlhdCI6MTY3MzA1Mjg0MX0.HI58Fg6YsP3MCAhMMlG3SMf5m6b63qA7rFwcQh_pSkQ", new DateTime(2023, 1, 27, 0, 54, 1, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 54, 1, 697, DateTimeKind.Local).AddTicks(9214), new DateTime(2023, 1, 6, 21, 54, 1, 697, DateTimeKind.Local).AddTicks(9215) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMDUyODQxLCJleHAiOjE2NzQ3ODA4NDEsImlhdCI6MTY3MzA1Mjg0MX0.ChpendLYoTlL7QpUn_EOM_x6rQGGm8l7KNEW6CwCtH8", new DateTime(2023, 1, 27, 0, 54, 1, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 54, 1, 723, DateTimeKind.Local).AddTicks(9382), new DateTime(2023, 1, 6, 21, 54, 1, 723, DateTimeKind.Local).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1Mjg0MSwiZXhwIjoxNjc0NzgwODQxLCJpYXQiOjE2NzMwNTI4NDF9.BqAtR3ZXepP6yf9wyxwgyZPQX_HDOHdbBOnUCa_nKyM", new DateTime(2023, 1, 27, 0, 54, 1, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 54, 1, 757, DateTimeKind.Local).AddTicks(1414), new DateTime(2023, 1, 6, 21, 54, 1, 757, DateTimeKind.Local).AddTicks(1415) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY3MzA1Mjg0MSwiZXhwIjoxNjczMDk2MDQxLCJpYXQiOjE2NzMwNTI4NDF9.Kyue3nXZ3gyJgUZNljUx5Auf4DoI3khEOcT4Y5Ev9nU", new DateTime(2023, 1, 7, 12, 54, 1, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 54, 1, 687, DateTimeKind.Local).AddTicks(7128), "oA8rYPbC8Mg0sUiGPSaoqFWQ07BmOCTWOQHR4ndM9qM=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1Mjg0MSwiZXhwIjoxNjczMjI1NjQxLCJpYXQiOjE2NzMwNTI4NDF9.AbPvS-6gwldmpsd2rNa2-74JITenYrZikRVB-Bhaxa4", new DateTime(2023, 1, 9, 0, 54, 1, 0, DateTimeKind.Utc), new byte[] { 185, 50, 66, 160, 221, 197, 63, 166, 199, 112, 129, 247, 120, 148, 239, 145, 21, 27, 130, 248, 248, 110, 243, 16, 132, 236, 199, 117, 109, 115, 191, 20, 183, 65, 12, 73, 43, 178, 172, 223 }, new DateTime(2023, 1, 6, 21, 54, 1, 687, DateTimeKind.Local).AddTicks(7129) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2NzMwNTI4NDEsImV4cCI6MTY3MzA5NjA0MSwiaWF0IjoxNjczMDUyODQxfQ.S5te8LYfAYmcVGMsgZbyddutzfMgiDU79UtYLr6PbA8", new DateTime(2023, 1, 7, 12, 54, 1, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 54, 1, 713, DateTimeKind.Local).AddTicks(2901), "17O6O81GEXyDCssTGD4SLaRvLiLRwBEEgFuqem5gnrk=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMDUyODQxLCJleHAiOjE2NzMyMjU2NDEsImlhdCI6MTY3MzA1Mjg0MX0.5ufYxv6IxTZd1h37doBxxx-e0daZWI4CxAk1eL7RVSo", new DateTime(2023, 1, 9, 0, 54, 1, 0, DateTimeKind.Utc), new byte[] { 238, 253, 230, 32, 147, 145, 160, 59, 5, 236, 171, 83, 55, 96, 77, 206, 170, 183, 235, 132, 248, 13, 176, 55, 93, 218, 23, 52, 222, 121, 221, 148, 217, 101, 120, 202, 88, 176, 224, 233 }, new DateTime(2023, 1, 6, 21, 54, 1, 713, DateTimeKind.Local).AddTicks(2902) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjczMDUyODQxLCJleHAiOjE2NzMwOTYwNDEsImlhdCI6MTY3MzA1Mjg0MX0.1HIevvXD5XwySUGtCXcTQyAEhbuUYum1vUyaimBdTNU", new DateTime(2023, 1, 7, 12, 54, 1, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 54, 1, 739, DateTimeKind.Local).AddTicks(1095), "YCsUfdt28RKfnhTKpCbZFo8eVZVEwv+Zl0dpjYLYhVE=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1Mjg0MSwiZXhwIjoxNjczMjI1NjQxLCJpYXQiOjE2NzMwNTI4NDF9.BqZx6nNXCXaIgS13J_Adgf07S_hDTe4YlyE94NJKxDc", new DateTime(2023, 1, 9, 0, 54, 1, 0, DateTimeKind.Utc), new byte[] { 171, 108, 83, 26, 201, 242, 12, 86, 166, 206, 195, 63, 191, 119, 142, 187, 187, 75, 191, 202, 87, 122, 50, 239, 193, 176, 91, 176, 16, 195, 20, 230, 9, 15, 22, 94, 152, 135, 131, 80 }, new DateTime(2023, 1, 6, 21, 54, 1, 739, DateTimeKind.Local).AddTicks(1095) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2NzMwNTI4NDEsImV4cCI6MTY3MzA5NjA0MSwiaWF0IjoxNjczMDUyODQxfQ.KRduO2el28OgJyQswhSOGD95c2nT7oQ1BsLviB3oOas", new DateTime(2023, 1, 7, 12, 54, 1, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 54, 1, 677, DateTimeKind.Local).AddTicks(4780), "TJuovWeCJ/BBS6EG55fczfprOwxv9qzTxQtAdk/DhXM=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjczMDUyODQxLCJleHAiOjE2NzMyMjU2NDEsImlhdCI6MTY3MzA1Mjg0MX0.gxjjWvK9p_e4apcBhPwqWxxipfuSQ7pH-xdE7T1gdAQ", new DateTime(2023, 1, 9, 0, 54, 1, 0, DateTimeKind.Utc), new byte[] { 11, 63, 126, 125, 8, 42, 68, 74, 144, 65, 237, 203, 200, 20, 145, 98, 163, 65, 138, 172, 132, 183, 235, 197, 207, 96, 167, 127, 107, 242, 49, 203, 26, 35, 167, 205, 150, 206, 28, 200 }, new DateTime(2023, 1, 6, 21, 54, 1, 677, DateTimeKind.Local).AddTicks(4790) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjczMDUyODQxLCJleHAiOjE2NzMwOTYwNDEsImlhdCI6MTY3MzA1Mjg0MX0.uy2mwm5iZp-GUN5cxQ3T2Z_NuBbkm7djAkrnMl5cBjY", new DateTime(2023, 1, 7, 12, 54, 1, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 54, 1, 702, DateTimeKind.Local).AddTicks(6446), "b/ot1tTQ9Gj30kr11LUx3533ybk0kE81PoVOdLgTSiM=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2NzMwNTI4NDEsImV4cCI6MTY3MzIyNTY0MSwiaWF0IjoxNjczMDUyODQxfQ.-KwspJo9EUHeh_Psl8SXHnYWt1Xaae9Ik5QJId7dWwg", new DateTime(2023, 1, 9, 0, 54, 1, 0, DateTimeKind.Utc), new byte[] { 132, 222, 50, 182, 135, 147, 23, 231, 190, 110, 241, 8, 160, 67, 234, 178, 85, 55, 226, 212, 52, 133, 71, 135, 154, 142, 13, 46, 171, 83, 111, 166, 172, 47, 117, 251, 249, 152, 16, 74 }, new DateTime(2023, 1, 6, 21, 54, 1, 702, DateTimeKind.Local).AddTicks(6448) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MzA1Mjg0MSwiZXhwIjoxNjczMDk2MDQxLCJpYXQiOjE2NzMwNTI4NDF9.5g4g0SP3PkAdPI0aq9_sijOa8Yon13-zyP2KSfhPuoY", new DateTime(2023, 1, 7, 12, 54, 1, 0, DateTimeKind.Utc), new DateTime(2023, 1, 6, 21, 54, 1, 728, DateTimeKind.Local).AddTicks(7773), "FwZBcLhKUoyvPAuY1DinV66Tl0al5B+eQhzcymfYV1w=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjczMDUyODQxLCJleHAiOjE2NzMyMjU2NDEsImlhdCI6MTY3MzA1Mjg0MX0.VD_rHppevjr5fgDNA02ViOC8quywWIuLgFfQmwKrvk8", new DateTime(2023, 1, 9, 0, 54, 1, 0, DateTimeKind.Utc), new byte[] { 171, 236, 54, 73, 190, 51, 216, 137, 120, 39, 78, 208, 88, 86, 11, 47, 110, 223, 28, 87, 42, 207, 98, 144, 95, 69, 240, 93, 242, 197, 3, 2, 178, 109, 126, 96, 1, 67, 73, 43 }, new DateTime(2023, 1, 6, 21, 54, 1, 728, DateTimeKind.Local).AddTicks(7774) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 54, 1, 697, DateTimeKind.Local).AddTicks(9208), new DateTime(2023, 1, 6, 21, 54, 1, 697, DateTimeKind.Local).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 54, 1, 723, DateTimeKind.Local).AddTicks(9373), new DateTime(2023, 1, 6, 21, 54, 1, 723, DateTimeKind.Local).AddTicks(9374) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 54, 1, 757, DateTimeKind.Local).AddTicks(1404), new DateTime(2023, 1, 6, 21, 54, 1, 757, DateTimeKind.Local).AddTicks(1406) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 54, 1, 702, DateTimeKind.Local).AddTicks(6190), new DateTime(2023, 1, 6, 21, 54, 1, 702, DateTimeKind.Local).AddTicks(6198) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 54, 1, 728, DateTimeKind.Local).AddTicks(7500), new DateTime(2023, 1, 6, 21, 54, 1, 728, DateTimeKind.Local).AddTicks(7510) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 6, 21, 54, 1, 765, DateTimeKind.Local).AddTicks(5017), new DateTime(2023, 1, 6, 21, 54, 1, 765, DateTimeKind.Local).AddTicks(5034) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BlockHash",
                table: "Purchases",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjcyNzk0MjI1LCJleHAiOjE2NzQ1MjIyMjUsImlhdCI6MTY3Mjc5NDIyNX0._hIyBbryerNccvs6KeTfMWGdYwnADitTsRBkUexky7E", new DateTime(2023, 1, 24, 1, 3, 45, 0, DateTimeKind.Utc), new DateTime(2023, 1, 3, 22, 3, 45, 778, DateTimeKind.Local).AddTicks(3358), new DateTime(2023, 1, 3, 22, 3, 45, 778, DateTimeKind.Local).AddTicks(3359) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjcyNzk0MjI1LCJleHAiOjE2NzQ1MjIyMjUsImlhdCI6MTY3Mjc5NDIyNX0.0cq3HtWckOyidHiRKN4RxqB8xsfsKvSEyrxl-LIGZLg", new DateTime(2023, 1, 24, 1, 3, 45, 0, DateTimeKind.Utc), new DateTime(2023, 1, 3, 22, 3, 45, 811, DateTimeKind.Local).AddTicks(4832), new DateTime(2023, 1, 3, 22, 3, 45, 811, DateTimeKind.Local).AddTicks(4833) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3Mjc5NDIyNSwiZXhwIjoxNjc0NTIyMjI1LCJpYXQiOjE2NzI3OTQyMjV9.wO_dVYNusRtCdgNepK1vd9GRTH_AM2qDmhnlb516uL8", new DateTime(2023, 1, 24, 1, 3, 45, 0, DateTimeKind.Utc), new DateTime(2023, 1, 3, 22, 3, 45, 843, DateTimeKind.Local).AddTicks(8452), new DateTime(2023, 1, 3, 22, 3, 45, 843, DateTimeKind.Local).AddTicks(8452) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY3Mjc5NDIyNSwiZXhwIjoxNjcyODM3NDI1LCJpYXQiOjE2NzI3OTQyMjV9.dQ-oWJlXTNLcYhOjJag0RU4jrv761um9LOoVl638neo", new DateTime(2023, 1, 4, 13, 3, 45, 0, DateTimeKind.Utc), new DateTime(2023, 1, 3, 22, 3, 45, 764, DateTimeKind.Local).AddTicks(6585), "Q3xAz0vrIVUokh5lAvwQtx5w+zZnD5PhA2xW4Zrg+94=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY3Mjc5NDIyNSwiZXhwIjoxNjcyOTY3MDI1LCJpYXQiOjE2NzI3OTQyMjV9.zVDEVfEwfQg88wILFKRSls5CxwQdUplHTYDQYvYZwVM", new DateTime(2023, 1, 6, 1, 3, 45, 0, DateTimeKind.Utc), new byte[] { 221, 152, 8, 190, 66, 77, 82, 83, 236, 175, 31, 92, 172, 99, 233, 176, 24, 70, 194, 80, 214, 198, 116, 76, 12, 49, 142, 212, 183, 133, 140, 175, 219, 215, 178, 195, 215, 102, 76, 94 }, new DateTime(2023, 1, 3, 22, 3, 45, 764, DateTimeKind.Local).AddTicks(6586) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2NzI3OTQyMjUsImV4cCI6MTY3MjgzNzQyNSwiaWF0IjoxNjcyNzk0MjI1fQ.e4QZmiEHjYKC6T5iZqAEYZc_ZvTwWejmzQir9Gkxz8c", new DateTime(2023, 1, 4, 13, 3, 45, 0, DateTimeKind.Utc), new DateTime(2023, 1, 3, 22, 3, 45, 799, DateTimeKind.Local).AddTicks(3103), "givs83oyBl24pEbKYLrB6hTJM8CwCs3Ky/uLE67LDhU=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjcyNzk0MjI1LCJleHAiOjE2NzI5NjcwMjUsImlhdCI6MTY3Mjc5NDIyNX0.ebXnKM9RdPIF3mv_Cl5E_zjuh2fhIs2PTY9T-Vrq9K0", new DateTime(2023, 1, 6, 1, 3, 45, 0, DateTimeKind.Utc), new byte[] { 44, 166, 139, 54, 52, 249, 124, 67, 84, 208, 243, 136, 57, 18, 49, 224, 146, 238, 34, 245, 55, 148, 18, 195, 73, 162, 52, 255, 30, 74, 60, 93, 255, 86, 188, 209, 249, 59, 66, 70 }, new DateTime(2023, 1, 3, 22, 3, 45, 799, DateTimeKind.Local).AddTicks(3104) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjcyNzk0MjI1LCJleHAiOjE2NzI4Mzc0MjUsImlhdCI6MTY3Mjc5NDIyNX0.SoAUlSkL9gOyjZ3biR9W2lV6B78ZP5nKrWrNZxsPaXc", new DateTime(2023, 1, 4, 13, 3, 45, 0, DateTimeKind.Utc), new DateTime(2023, 1, 3, 22, 3, 45, 830, DateTimeKind.Local).AddTicks(343), "5CpqRCPNwr5UBVkYp/+WsD3MjZRmKgNom3o0wLaSlh4=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3Mjc5NDIyNSwiZXhwIjoxNjcyOTY3MDI1LCJpYXQiOjE2NzI3OTQyMjV9.FF04AcxcXlT7JukjoredtxqN8Qu51rtaiIHM-aDcmcY", new DateTime(2023, 1, 6, 1, 3, 45, 0, DateTimeKind.Utc), new byte[] { 4, 128, 243, 208, 145, 249, 116, 0, 115, 141, 206, 43, 246, 82, 26, 90, 220, 148, 96, 5, 99, 98, 197, 180, 98, 231, 107, 173, 109, 85, 145, 145, 60, 79, 52, 123, 45, 89, 77, 199 }, new DateTime(2023, 1, 3, 22, 3, 45, 830, DateTimeKind.Local).AddTicks(344) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2NzI3OTQyMjUsImV4cCI6MTY3MjgzNzQyNSwiaWF0IjoxNjcyNzk0MjI1fQ.M8owVp7QudFICqj1JG6IUOHiQpCYaKNnkBid6ftRggo", new DateTime(2023, 1, 4, 13, 3, 45, 0, DateTimeKind.Utc), new DateTime(2023, 1, 3, 22, 3, 45, 748, DateTimeKind.Local).AddTicks(3019), "4QQHPwMI8e4fE4yrsW72YViEbMlq6p/aP/UT/ntOSG8=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjcyNzk0MjI1LCJleHAiOjE2NzI5NjcwMjUsImlhdCI6MTY3Mjc5NDIyNX0._6YsVhwyhy-W-dhiFaRI_yN-8Q2Tw6KJayMmOTW2fjs", new DateTime(2023, 1, 6, 1, 3, 45, 0, DateTimeKind.Utc), new byte[] { 198, 193, 164, 232, 61, 117, 222, 117, 186, 35, 212, 230, 54, 182, 95, 106, 28, 91, 214, 127, 131, 121, 219, 132, 81, 33, 230, 19, 29, 238, 39, 230, 28, 108, 29, 236, 142, 219, 1, 242 }, new DateTime(2023, 1, 3, 22, 3, 45, 748, DateTimeKind.Local).AddTicks(3037) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjcyNzk0MjI1LCJleHAiOjE2NzI4Mzc0MjUsImlhdCI6MTY3Mjc5NDIyNX0.0tT4sxTriZfwTTM5A4-XvXplHJNU7X_alRe96-wsXaY", new DateTime(2023, 1, 4, 13, 3, 45, 0, DateTimeKind.Utc), new DateTime(2023, 1, 3, 22, 3, 45, 786, DateTimeKind.Local).AddTicks(5836), "rUS2jdVG/B016YsN/YapDCcLiPH3+9Fnq4ZbAYdHGno=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2NzI3OTQyMjUsImV4cCI6MTY3Mjk2NzAyNSwiaWF0IjoxNjcyNzk0MjI1fQ.umNF6uwSaQYzoBBcXmBTySvbEuAUf6DpnzMZRML3Nyc", new DateTime(2023, 1, 6, 1, 3, 45, 0, DateTimeKind.Utc), new byte[] { 12, 29, 112, 143, 148, 174, 138, 243, 220, 58, 153, 143, 162, 89, 34, 156, 242, 253, 60, 200, 143, 125, 120, 66, 193, 5, 95, 206, 90, 31, 188, 56, 120, 172, 168, 179, 67, 56, 101, 238 }, new DateTime(2023, 1, 3, 22, 3, 45, 786, DateTimeKind.Local).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3Mjc5NDIyNSwiZXhwIjoxNjcyODM3NDI1LCJpYXQiOjE2NzI3OTQyMjV9.Ff4NEygaSjkXEQ6nSPUZ6ODt4GRw58ut1IT2GkhcQ8o", new DateTime(2023, 1, 4, 13, 3, 45, 0, DateTimeKind.Utc), new DateTime(2023, 1, 3, 22, 3, 45, 817, DateTimeKind.Local).AddTicks(3305), "NebGnuSO/JJXHgdvI+7J+iwcXqPog5gNj6BUi4ti1q4=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjcyNzk0MjI1LCJleHAiOjE2NzI5NjcwMjUsImlhdCI6MTY3Mjc5NDIyNX0.o2PzQTdhlxPAEdv4nCQI5CUs_UH7kilbVCj99vgWTp8", new DateTime(2023, 1, 6, 1, 3, 45, 0, DateTimeKind.Utc), new byte[] { 144, 91, 76, 54, 93, 2, 30, 112, 252, 135, 9, 126, 224, 170, 27, 211, 237, 229, 179, 14, 122, 136, 38, 99, 31, 192, 159, 53, 147, 42, 249, 98, 214, 13, 126, 137, 121, 112, 219, 146 }, new DateTime(2023, 1, 3, 22, 3, 45, 817, DateTimeKind.Local).AddTicks(3306) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 3, 22, 3, 45, 778, DateTimeKind.Local).AddTicks(3350), new DateTime(2023, 1, 3, 22, 3, 45, 778, DateTimeKind.Local).AddTicks(3351) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 3, 22, 3, 45, 811, DateTimeKind.Local).AddTicks(4823), new DateTime(2023, 1, 3, 22, 3, 45, 811, DateTimeKind.Local).AddTicks(4825) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 3, 22, 3, 45, 843, DateTimeKind.Local).AddTicks(8442), new DateTime(2023, 1, 3, 22, 3, 45, 843, DateTimeKind.Local).AddTicks(8444) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 3, 22, 3, 45, 786, DateTimeKind.Local).AddTicks(5486), new DateTime(2023, 1, 3, 22, 3, 45, 786, DateTimeKind.Local).AddTicks(5504) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 3, 22, 3, 45, 817, DateTimeKind.Local).AddTicks(2994), new DateTime(2023, 1, 3, 22, 3, 45, 817, DateTimeKind.Local).AddTicks(3005) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 1, 3, 22, 3, 45, 849, DateTimeKind.Local).AddTicks(8527), new DateTime(2023, 1, 3, 22, 3, 45, 849, DateTimeKind.Local).AddTicks(8540) });
        }
    }
}
