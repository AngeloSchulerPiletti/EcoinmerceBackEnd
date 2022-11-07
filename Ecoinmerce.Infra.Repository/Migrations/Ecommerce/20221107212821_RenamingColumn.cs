using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations.Ecommerce
{
    public partial class RenamingColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AverageAnualBiling",
                table: "Ecommerces",
                newName: "AverageAnnualBilling");

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjY3ODU2NTAwLCJleHAiOjE2Njk1ODQ1MDAsImlhdCI6MTY2Nzg1NjUwMH0.IcL_QkUCdhxn9eeAzjapGCRmogxXIVrPg3K8vDXNzR0", new DateTime(2022, 11, 27, 21, 28, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 28, 20, 472, DateTimeKind.Local).AddTicks(1821), new DateTime(2022, 11, 7, 18, 28, 20, 472, DateTimeKind.Local).AddTicks(1822) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3ODU2NTAwLCJleHAiOjE2Njk1ODQ1MDAsImlhdCI6MTY2Nzg1NjUwMH0.TW__Mmr-zecDyZ6fxYFn0yMGBAA_QU8RO27teh84-xA", new DateTime(2022, 11, 27, 21, 28, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 28, 20, 516, DateTimeKind.Local).AddTicks(3321), new DateTime(2022, 11, 7, 18, 28, 20, 516, DateTimeKind.Local).AddTicks(3322) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzg1NjUwMCwiZXhwIjoxNjY5NTg0NTAwLCJpYXQiOjE2Njc4NTY1MDB9.0_ftabRbezStHa-fBJHhpxBP-qSkSyclwodvQ6ex6Kc", new DateTime(2022, 11, 27, 21, 28, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 28, 20, 559, DateTimeKind.Local).AddTicks(3388), new DateTime(2022, 11, 7, 18, 28, 20, 559, DateTimeKind.Local).AddTicks(3389) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY2Nzg1NjUwMCwiZXhwIjoxNjY3ODk5NzAwLCJpYXQiOjE2Njc4NTY1MDB9.yXcnMxm0bxpHMb21URkAOZld3B7b7L99m3TwqLl44ik", new DateTime(2022, 11, 8, 9, 28, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 28, 20, 454, DateTimeKind.Local).AddTicks(1457), "WJaFWuhBA9kOEI/epFxS+clS5xPMEaXmlFipfoqagz8=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzg1NjUwMCwiZXhwIjoxNjY4MDI5MzAwLCJpYXQiOjE2Njc4NTY1MDB9.GIk70Tq_etZKfizDrCSXQRvFSSo7Yx4smWDEhoTGa8I", new DateTime(2022, 11, 9, 21, 28, 20, 0, DateTimeKind.Utc), new byte[] { 185, 158, 193, 254, 220, 60, 175, 108, 185, 86, 123, 18, 56, 124, 225, 80, 217, 240, 193, 244, 246, 190, 99, 13, 46, 64, 132, 140, 162, 56, 190, 44, 227, 252, 60, 57, 142, 244, 218, 246 }, new DateTime(2022, 11, 7, 18, 28, 20, 454, DateTimeKind.Local).AddTicks(1459) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2Njc4NTY1MDAsImV4cCI6MTY2Nzg5OTcwMCwiaWF0IjoxNjY3ODU2NTAwfQ.0ZFJ_4ezOhIXs6an0JWy2R7kXHp5HmiOteKNBBYRsRo", new DateTime(2022, 11, 8, 9, 28, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 28, 20, 498, DateTimeKind.Local).AddTicks(3053), "zDT85REBe+ch95neSWO0o5avJEQ+oruDj4baDQ2LoTU=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3ODU2NTAwLCJleHAiOjE2NjgwMjkzMDAsImlhdCI6MTY2Nzg1NjUwMH0.Mmvkx78IL9hrT4YDTPgrx1FnXImBoHZsPfcSPpA8YHc", new DateTime(2022, 11, 9, 21, 28, 20, 0, DateTimeKind.Utc), new byte[] { 207, 132, 102, 229, 140, 123, 243, 13, 80, 254, 92, 216, 239, 76, 70, 207, 24, 255, 46, 177, 167, 110, 38, 27, 23, 72, 105, 229, 220, 27, 113, 16, 233, 175, 71, 17, 154, 155, 172, 172 }, new DateTime(2022, 11, 7, 18, 28, 20, 498, DateTimeKind.Local).AddTicks(3054) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjY3ODU2NTAwLCJleHAiOjE2Njc4OTk3MDAsImlhdCI6MTY2Nzg1NjUwMH0.OctLmNDeo1wf9_uCTklzY7a_HylOFVIZfQ2TMGQ0Euk", new DateTime(2022, 11, 8, 9, 28, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 28, 20, 542, DateTimeKind.Local).AddTicks(1916), "j1l16bp52ZXx3sQltxKrYQPG9BZXSi54AnZWGPiMINM=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzg1NjUwMCwiZXhwIjoxNjY4MDI5MzAwLCJpYXQiOjE2Njc4NTY1MDB9.yhjtFT-TEHR8fuQKkyAXlIvP-z0Cif4TmCB2pBu8b6U", new DateTime(2022, 11, 9, 21, 28, 20, 0, DateTimeKind.Utc), new byte[] { 165, 242, 9, 82, 43, 172, 190, 17, 196, 75, 72, 28, 17, 124, 190, 166, 94, 52, 144, 205, 139, 28, 58, 195, 45, 4, 19, 194, 36, 158, 8, 154, 168, 41, 125, 222, 36, 135, 218, 221 }, new DateTime(2022, 11, 7, 18, 28, 20, 542, DateTimeKind.Local).AddTicks(1918) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2Njc4NTY1MDAsImV4cCI6MTY2Nzg5OTcwMCwiaWF0IjoxNjY3ODU2NTAwfQ.bsDJXT__C5ljuqHuwzSy2dIRTPT_BvEHS0TMgRbYRGk", new DateTime(2022, 11, 8, 9, 28, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 28, 20, 435, DateTimeKind.Local).AddTicks(9647), "3i27FfmGMT02QRztTDx4NTCmPLxW6siYSWdbbywWARM=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjY3ODU2NTAwLCJleHAiOjE2NjgwMjkzMDAsImlhdCI6MTY2Nzg1NjUwMH0.ioZtPffDPjL7NLwIxiv2l63wjayFBu6lHj2fx9ptrrM", new DateTime(2022, 11, 9, 21, 28, 20, 0, DateTimeKind.Utc), new byte[] { 93, 226, 103, 219, 180, 231, 246, 79, 8, 77, 245, 62, 169, 2, 29, 156, 158, 197, 130, 105, 184, 214, 109, 251, 9, 74, 222, 246, 254, 133, 83, 32, 157, 5, 146, 245, 202, 213, 196, 244 }, new DateTime(2022, 11, 7, 18, 28, 20, 435, DateTimeKind.Local).AddTicks(9663) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3ODU2NTAwLCJleHAiOjE2Njc4OTk3MDAsImlhdCI6MTY2Nzg1NjUwMH0.QcnbUr6yV3yQcaupRfwRdQjTxDgOO5oZpjdXMcmlGM4", new DateTime(2022, 11, 8, 9, 28, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 28, 20, 480, DateTimeKind.Local).AddTicks(3326), "4oLm1Clfv1Bktfk+aEjfWH6Mlr/Hqgmh1lWnTqXq9XA=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2Njc4NTY1MDAsImV4cCI6MTY2ODAyOTMwMCwiaWF0IjoxNjY3ODU2NTAwfQ.tJYji6n-RD2WoE9Q4DFJrE3-4tjeNwXWOqI9849jWgk", new DateTime(2022, 11, 9, 21, 28, 20, 0, DateTimeKind.Utc), new byte[] { 58, 182, 25, 149, 205, 205, 115, 3, 212, 253, 192, 74, 116, 20, 121, 87, 34, 5, 241, 50, 143, 4, 176, 11, 221, 192, 249, 2, 193, 230, 36, 63, 142, 186, 247, 6, 211, 177, 184, 130 }, new DateTime(2022, 11, 7, 18, 28, 20, 480, DateTimeKind.Local).AddTicks(3329) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzg1NjUwMCwiZXhwIjoxNjY3ODk5NzAwLCJpYXQiOjE2Njc4NTY1MDB9.wOKnxnE74o_jIKvmlbSOTECIuF0RUdjjgvgrWUtBm3k", new DateTime(2022, 11, 8, 9, 28, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 28, 20, 524, DateTimeKind.Local).AddTicks(4463), "2EjA5GhFt0GB66p9STxM4PHd4kd9A93BCNPqtBOyDaQ=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjY3ODU2NTAwLCJleHAiOjE2NjgwMjkzMDAsImlhdCI6MTY2Nzg1NjUwMH0.p-eGWxUgVNJX2uDmWvGWhR1qI4b9wFUzdmXvVgR9ohw", new DateTime(2022, 11, 9, 21, 28, 20, 0, DateTimeKind.Utc), new byte[] { 36, 112, 198, 36, 174, 72, 40, 254, 29, 187, 160, 72, 224, 36, 109, 5, 188, 82, 42, 84, 92, 191, 99, 215, 137, 29, 198, 48, 40, 233, 158, 102, 63, 245, 117, 215, 84, 115, 46, 226 }, new DateTime(2022, 11, 7, 18, 28, 20, 524, DateTimeKind.Local).AddTicks(4467) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 7, 18, 28, 20, 472, DateTimeKind.Local).AddTicks(1807), new DateTime(2022, 11, 7, 18, 28, 20, 472, DateTimeKind.Local).AddTicks(1811) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 7, 18, 28, 20, 516, DateTimeKind.Local).AddTicks(3306), new DateTime(2022, 11, 7, 18, 28, 20, 516, DateTimeKind.Local).AddTicks(3309) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 7, 18, 28, 20, 559, DateTimeKind.Local).AddTicks(3373), new DateTime(2022, 11, 7, 18, 28, 20, 559, DateTimeKind.Local).AddTicks(3377) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 7, 18, 28, 20, 480, DateTimeKind.Local).AddTicks(2953), new DateTime(2022, 11, 7, 18, 28, 20, 480, DateTimeKind.Local).AddTicks(2964) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 7, 18, 28, 20, 524, DateTimeKind.Local).AddTicks(4108), new DateTime(2022, 11, 7, 18, 28, 20, 524, DateTimeKind.Local).AddTicks(4115) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 7, 18, 28, 20, 567, DateTimeKind.Local).AddTicks(784), new DateTime(2022, 11, 7, 18, 28, 20, 567, DateTimeKind.Local).AddTicks(798) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AverageAnnualBilling",
                table: "Ecommerces",
                newName: "AverageAnualBiling");

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjY5LCJleHAiOjE2Njk0ODE2NjksImlhdCI6MTY2Nzc1MzY2OX0.a22eO9zUjfUG7KXAS82SwjyLLvu_n_2gKWKI31hW1nY", new DateTime(2022, 11, 26, 16, 54, 29, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 29, 968, DateTimeKind.Local).AddTicks(8166), new DateTime(2022, 11, 6, 6, 54, 29, 968, DateTimeKind.Local).AddTicks(8168) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjcwLCJleHAiOjE2Njk0ODE2NzAsImlhdCI6MTY2Nzc1MzY3MH0.gaY8YSN7zhJQxrSI_eKpj1XjslzzM-Vejqfmfkli2Ks", new DateTime(2022, 11, 26, 16, 54, 30, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 30, 9, DateTimeKind.Local).AddTicks(4792), new DateTime(2022, 11, 6, 6, 54, 30, 9, DateTimeKind.Local).AddTicks(4794) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzc1MzY3MCwiZXhwIjoxNjY5NDgxNjcwLCJpYXQiOjE2Njc3NTM2NzB9.lvOrWOWfMgpIG1oosHYtv43dRzltqNWmyrgLl64m4u4", new DateTime(2022, 11, 26, 16, 54, 30, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 30, 47, DateTimeKind.Local).AddTicks(5701), new DateTime(2022, 11, 6, 6, 54, 30, 47, DateTimeKind.Local).AddTicks(5702) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY2Nzc1MzY2OSwiZXhwIjoxNjY3Nzk2ODY5LCJpYXQiOjE2Njc3NTM2Njl9.8hf20Qs0j9MktyzhLOyAOTlaIlp7O8Fb-TKz0h_dKkY", new DateTime(2022, 11, 7, 4, 54, 29, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 29, 951, DateTimeKind.Local).AddTicks(8435), "r81PijBAoTAPZ4BZAaO35pIlP4BaXb157yeBrD8qZ0w=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzc1MzY2OSwiZXhwIjoxNjY3OTI2NDY5LCJpYXQiOjE2Njc3NTM2Njl9.BG8YxT2ZhsL-zv77rT3l3GqGP96v9HDlJaBSUL5er2w", new DateTime(2022, 11, 8, 16, 54, 29, 0, DateTimeKind.Utc), new byte[] { 117, 78, 252, 120, 206, 189, 210, 166, 21, 136, 174, 153, 111, 233, 99, 222, 159, 117, 253, 15, 34, 62, 24, 51, 206, 155, 85, 162, 38, 227, 240, 21, 233, 102, 156, 179, 131, 203, 120, 90 }, new DateTime(2022, 11, 6, 6, 54, 29, 951, DateTimeKind.Local).AddTicks(8438) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2Njc3NTM2NzAsImV4cCI6MTY2Nzc5Njg3MCwiaWF0IjoxNjY3NzUzNjcwfQ.-CuETKjaYeEhdSwf25S6yzpjJEDWn_FV1nTMekeZdLE", new DateTime(2022, 11, 7, 4, 54, 30, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 29, 993, DateTimeKind.Local).AddTicks(1746), "n7UMJuYz92m4s9qib+q4x35ijaTtTgc6jeyQ1uc6SnA=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjcwLCJleHAiOjE2Njc5MjY0NzAsImlhdCI6MTY2Nzc1MzY3MH0.qRfJlrJE7tixUIQWNgRpHOCR2SRvCE4qAhOVduFWadw", new DateTime(2022, 11, 8, 16, 54, 30, 0, DateTimeKind.Utc), new byte[] { 56, 76, 38, 58, 219, 170, 128, 145, 111, 251, 241, 53, 160, 31, 16, 212, 117, 32, 149, 92, 36, 32, 85, 254, 216, 140, 187, 150, 186, 52, 248, 62, 19, 115, 1, 55, 225, 141, 73, 235 }, new DateTime(2022, 11, 6, 6, 54, 29, 993, DateTimeKind.Local).AddTicks(1749) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjY3NzUzNjcwLCJleHAiOjE2Njc3OTY4NzAsImlhdCI6MTY2Nzc1MzY3MH0.8LrIQNkf1bCnqAf6Ena2lzHonXWZRf-GXwKIQIiOwKI", new DateTime(2022, 11, 7, 4, 54, 30, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 30, 32, DateTimeKind.Local).AddTicks(8397), "6trvQ+D4HDHNQCiXT9xLxZH/bfiInQjdhtUJlBzZdDk=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzc1MzY3MCwiZXhwIjoxNjY3OTI2NDcwLCJpYXQiOjE2Njc3NTM2NzB9.h7EQZhlp2_ptC3P2lEcJOmt8I_Vi-rKzQrNs4tMg4n0", new DateTime(2022, 11, 8, 16, 54, 30, 0, DateTimeKind.Utc), new byte[] { 142, 253, 172, 162, 201, 73, 152, 243, 70, 100, 115, 89, 111, 215, 171, 92, 178, 35, 27, 154, 220, 65, 19, 170, 250, 64, 182, 176, 160, 148, 74, 202, 64, 178, 251, 158, 238, 76, 127, 51 }, new DateTime(2022, 11, 6, 6, 54, 30, 32, DateTimeKind.Local).AddTicks(8400) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2Njc3NTM2NjksImV4cCI6MTY2Nzc5Njg2OSwiaWF0IjoxNjY3NzUzNjY5fQ.EcKzl5wEKukGulGinbFgGAJ-2jWJPbKdtlO8FdTUYUo", new DateTime(2022, 11, 7, 4, 54, 29, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 29, 935, DateTimeKind.Local).AddTicks(682), "2dEUZqWXAnWWrNdsauA13gQ0P0AtU43ElCDceARc2C0=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjY5LCJleHAiOjE2Njc5MjY0NjksImlhdCI6MTY2Nzc1MzY2OX0.daHLMURqrgw3eEVbxY7RSBLqIJF3vcIpdYzrHOchjpI", new DateTime(2022, 11, 8, 16, 54, 29, 0, DateTimeKind.Utc), new byte[] { 251, 150, 143, 28, 141, 152, 121, 32, 79, 252, 150, 200, 134, 140, 16, 140, 60, 51, 131, 0, 196, 89, 91, 114, 5, 209, 227, 26, 246, 50, 245, 90, 106, 243, 252, 242, 227, 238, 194, 148 }, new DateTime(2022, 11, 6, 6, 54, 29, 935, DateTimeKind.Local).AddTicks(719) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjY5LCJleHAiOjE2Njc3OTY4NjksImlhdCI6MTY2Nzc1MzY2OX0._qabhQfXUeqXRHBooQ0sA0AgGyeacAYmTztCg4F2gVs", new DateTime(2022, 11, 7, 4, 54, 29, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 29, 976, DateTimeKind.Local).AddTicks(7249), "cGRom+5rCg86YgjSu1QO31gZCM2IgZ3/ByGIogPHuG0=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2Njc3NTM2NjksImV4cCI6MTY2NzkyNjQ2OSwiaWF0IjoxNjY3NzUzNjY5fQ.1cY4N_r5TJmc97APX30T-CZ7Nyu-JxIAdjIQRqQUi64", new DateTime(2022, 11, 8, 16, 54, 29, 0, DateTimeKind.Utc), new byte[] { 181, 33, 139, 219, 137, 32, 165, 64, 148, 15, 110, 39, 18, 99, 163, 72, 115, 217, 5, 90, 201, 100, 143, 241, 126, 12, 121, 195, 113, 54, 245, 107, 76, 159, 9, 225, 170, 19, 196, 151 }, new DateTime(2022, 11, 6, 6, 54, 29, 976, DateTimeKind.Local).AddTicks(7253) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzc1MzY3MCwiZXhwIjoxNjY3Nzk2ODcwLCJpYXQiOjE2Njc3NTM2NzB9.Wd10HMKT6OCadWZT9EcEn3S8toafdKd2fPkyfKuHiHA", new DateTime(2022, 11, 7, 4, 54, 30, 0, DateTimeKind.Utc), new DateTime(2022, 11, 6, 6, 54, 30, 17, DateTimeKind.Local).AddTicks(2631), "kcomEk8tf+sfiE4OdD/KvqEc66/LmmdxvxCH27Mh4jY=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjY3NzUzNjcwLCJleHAiOjE2Njc5MjY0NzAsImlhdCI6MTY2Nzc1MzY3MH0.hJGYfEfkIBG_ob-6LvNdFSpOEk5jZBpiNLPoZYFHeVc", new DateTime(2022, 11, 8, 16, 54, 30, 0, DateTimeKind.Utc), new byte[] { 88, 16, 194, 200, 201, 168, 19, 232, 192, 135, 232, 250, 144, 223, 175, 19, 0, 8, 238, 33, 117, 51, 98, 41, 162, 11, 42, 161, 247, 146, 194, 215, 104, 223, 93, 254, 75, 71, 209, 164 }, new DateTime(2022, 11, 6, 6, 54, 30, 17, DateTimeKind.Local).AddTicks(2636) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 6, 6, 54, 29, 968, DateTimeKind.Local).AddTicks(8151), new DateTime(2022, 11, 6, 6, 54, 29, 968, DateTimeKind.Local).AddTicks(8155) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 6, 6, 54, 30, 9, DateTimeKind.Local).AddTicks(4779), new DateTime(2022, 11, 6, 6, 54, 30, 9, DateTimeKind.Local).AddTicks(4783) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 6, 6, 54, 30, 47, DateTimeKind.Local).AddTicks(5690), new DateTime(2022, 11, 6, 6, 54, 30, 47, DateTimeKind.Local).AddTicks(5692) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 6, 6, 54, 29, 976, DateTimeKind.Local).AddTicks(6912), new DateTime(2022, 11, 6, 6, 54, 29, 976, DateTimeKind.Local).AddTicks(6942) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 6, 6, 54, 30, 17, DateTimeKind.Local).AddTicks(2332), new DateTime(2022, 11, 6, 6, 54, 30, 17, DateTimeKind.Local).AddTicks(2354) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 6, 6, 54, 30, 59, DateTimeKind.Local).AddTicks(844), new DateTime(2022, 11, 6, 6, 54, 30, 59, DateTimeKind.Local).AddTicks(874) });
        }
    }
}
