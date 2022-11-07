using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations.Ecommerce
{
    public partial class RenamingColumn2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AverageAnnualBilling",
                table: "Ecommerces",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjY3ODU3MTYwLCJleHAiOjE2Njk1ODUxNjAsImlhdCI6MTY2Nzg1NzE2MH0.Fv4i6GNbLahXUnrXjqU-DLIY0zjh8FP2nb2B8eFo9UI", new DateTime(2022, 11, 27, 21, 39, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 39, 20, 587, DateTimeKind.Local).AddTicks(5213), new DateTime(2022, 11, 7, 18, 39, 20, 587, DateTimeKind.Local).AddTicks(5214) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3ODU3MTYwLCJleHAiOjE2Njk1ODUxNjAsImlhdCI6MTY2Nzg1NzE2MH0.NTekKKEU8radERnuf_Cft1WpmJKjF5xL80K4rAkgnes", new DateTime(2022, 11, 27, 21, 39, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 39, 20, 634, DateTimeKind.Local).AddTicks(4164), new DateTime(2022, 11, 7, 18, 39, 20, 634, DateTimeKind.Local).AddTicks(4165) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzg1NzE2MCwiZXhwIjoxNjY5NTg1MTYwLCJpYXQiOjE2Njc4NTcxNjB9.pKJ172XxxpBawxiz1rnSubspGXwxgXmYDI8dSD08CbE", new DateTime(2022, 11, 27, 21, 39, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 39, 20, 676, DateTimeKind.Local).AddTicks(3466), new DateTime(2022, 11, 7, 18, 39, 20, 676, DateTimeKind.Local).AddTicks(3467) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY2Nzg1NzE2MCwiZXhwIjoxNjY3OTAwMzYwLCJpYXQiOjE2Njc4NTcxNjB9.P1mq1gx1Lno3zMQBNwpOTW8qZkqa6Md-VtFY2daOeRY", new DateTime(2022, 11, 8, 9, 39, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 39, 20, 568, DateTimeKind.Local).AddTicks(7847), "46ZCSI4QuqMs3b12gJs9NVuGuAXChcjfyWhs6nr2Hh4=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzg1NzE2MCwiZXhwIjoxNjY4MDI5OTYwLCJpYXQiOjE2Njc4NTcxNjB9.s-9RXQid_n2ti0gcHNP6uR14oPFoCus4OKDRq5cgNeI", new DateTime(2022, 11, 9, 21, 39, 20, 0, DateTimeKind.Utc), new byte[] { 106, 87, 197, 184, 110, 227, 228, 51, 36, 101, 4, 71, 180, 83, 167, 96, 6, 72, 172, 219, 31, 144, 90, 115, 8, 75, 207, 212, 38, 199, 9, 149, 205, 111, 197, 238, 114, 138, 221, 128 }, new DateTime(2022, 11, 7, 18, 39, 20, 568, DateTimeKind.Local).AddTicks(7848) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2Njc4NTcxNjAsImV4cCI6MTY2NzkwMDM2MCwiaWF0IjoxNjY3ODU3MTYwfQ.IfB9PA1d7R-Hp_NqoPDSlRT3TAfb1rGxDGzHP8osQiU", new DateTime(2022, 11, 8, 9, 39, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 39, 20, 615, DateTimeKind.Local).AddTicks(7470), "NtIghf1mIw+0i29NFwleOApjM00dE+GgXNDL6fSQmfU=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3ODU3MTYwLCJleHAiOjE2NjgwMjk5NjAsImlhdCI6MTY2Nzg1NzE2MH0.dRfkX4qfDhRFOiMBcToXQk5aKaY9faWIXvedTa4TVug", new DateTime(2022, 11, 9, 21, 39, 20, 0, DateTimeKind.Utc), new byte[] { 7, 10, 49, 111, 23, 53, 118, 232, 6, 164, 99, 96, 109, 158, 167, 250, 42, 33, 250, 108, 101, 77, 70, 51, 35, 147, 185, 22, 183, 62, 221, 47, 22, 164, 112, 94, 160, 210, 11, 120 }, new DateTime(2022, 11, 7, 18, 39, 20, 615, DateTimeKind.Local).AddTicks(7471) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjY3ODU3MTYwLCJleHAiOjE2Njc5MDAzNjAsImlhdCI6MTY2Nzg1NzE2MH0.tSo7v4h-Ji0e3uWzvqTXijZI4lsF3Mo5Ihpsl7-nhyQ", new DateTime(2022, 11, 8, 9, 39, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 39, 20, 659, DateTimeKind.Local).AddTicks(8984), "AR3kMeqGAh2SSCHTRSi9A6EzPV98IHn1fmYiug9oEME=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzg1NzE2MCwiZXhwIjoxNjY4MDI5OTYwLCJpYXQiOjE2Njc4NTcxNjB9.-K5h4kNXEB0EuQa6kGQ0aJDOHNix1lZNDdWHCBnXLVA", new DateTime(2022, 11, 9, 21, 39, 20, 0, DateTimeKind.Utc), new byte[] { 25, 144, 82, 27, 204, 19, 156, 42, 239, 82, 169, 179, 61, 226, 201, 13, 120, 145, 40, 233, 166, 213, 46, 166, 83, 9, 245, 127, 205, 236, 33, 226, 73, 176, 31, 154, 4, 170, 170, 253 }, new DateTime(2022, 11, 7, 18, 39, 20, 659, DateTimeKind.Local).AddTicks(8985) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2Njc4NTcxNjAsImV4cCI6MTY2NzkwMDM2MCwiaWF0IjoxNjY3ODU3MTYwfQ.E3Z_-KiF5bqyv9qE9PxIogabpzI8EFsAwAVouQD2Q1c", new DateTime(2022, 11, 8, 9, 39, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 39, 20, 550, DateTimeKind.Local).AddTicks(7052), "PS28arxVGLVt8CkVJ2jfvvoHpcSh6HlRCy9M27B6Dq4=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjY3ODU3MTYwLCJleHAiOjE2NjgwMjk5NjAsImlhdCI6MTY2Nzg1NzE2MH0.EAEwKoJiA4IQ9BqdKzSu29vVwcsgIC7sR0xX0yKswN8", new DateTime(2022, 11, 9, 21, 39, 20, 0, DateTimeKind.Utc), new byte[] { 18, 192, 52, 47, 153, 132, 93, 177, 251, 38, 134, 192, 130, 17, 163, 66, 249, 65, 168, 142, 112, 1, 18, 244, 243, 81, 244, 21, 219, 135, 123, 111, 56, 16, 197, 69, 199, 113, 224, 99 }, new DateTime(2022, 11, 7, 18, 39, 20, 550, DateTimeKind.Local).AddTicks(7068) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjY3ODU3MTYwLCJleHAiOjE2Njc5MDAzNjAsImlhdCI6MTY2Nzg1NzE2MH0.-BZB3e1wQiiPU7hQ4nqboL6PPUUG7On5ehDg11GDrgI", new DateTime(2022, 11, 8, 9, 39, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 39, 20, 596, DateTimeKind.Local).AddTicks(8349), "QLwK/2NXXycALpgkzoDtQ4JWRTEdMlyFb+pXFfmfaT8=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2Njc4NTcxNjAsImV4cCI6MTY2ODAyOTk2MCwiaWF0IjoxNjY3ODU3MTYwfQ.xNixrukxyjaepdWsvmsPIHJ71upmU4rVLY6800gPYqk", new DateTime(2022, 11, 9, 21, 39, 20, 0, DateTimeKind.Utc), new byte[] { 110, 142, 37, 239, 12, 152, 229, 86, 53, 140, 45, 106, 212, 247, 207, 73, 112, 205, 198, 129, 41, 248, 119, 34, 117, 26, 246, 139, 123, 236, 183, 35, 210, 254, 85, 13, 98, 48, 48, 243 }, new DateTime(2022, 11, 7, 18, 39, 20, 596, DateTimeKind.Local).AddTicks(8353) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY2Nzg1NzE2MCwiZXhwIjoxNjY3OTAwMzYwLCJpYXQiOjE2Njc4NTcxNjB9.a1nMPgJcnQxGsR5RImoFIPtahBSSy30n5P7q1w-R_0U", new DateTime(2022, 11, 8, 9, 39, 20, 0, DateTimeKind.Utc), new DateTime(2022, 11, 7, 18, 39, 20, 642, DateTimeKind.Local).AddTicks(8776), "7xks0sJ6X51nQXF9mq1BIqqLQUzcD4iMRLaYAOzxr2U=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjY3ODU3MTYwLCJleHAiOjE2NjgwMjk5NjAsImlhdCI6MTY2Nzg1NzE2MH0.n_cFjZW8dQ9YWPaq-LMRw39KpDxUS6vBoColcFk5Bjg", new DateTime(2022, 11, 9, 21, 39, 20, 0, DateTimeKind.Utc), new byte[] { 54, 199, 29, 52, 39, 25, 234, 239, 171, 173, 119, 83, 159, 171, 155, 83, 76, 143, 46, 37, 165, 118, 145, 11, 170, 17, 176, 148, 86, 233, 13, 83, 35, 140, 159, 87, 146, 6, 113, 136 }, new DateTime(2022, 11, 7, 18, 39, 20, 642, DateTimeKind.Local).AddTicks(8779) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AverageAnnualBilling", "CreatedAt", "UpdatedAt" },
                values: new object[] { 10000000m, new DateTime(2022, 11, 7, 18, 39, 20, 587, DateTimeKind.Local).AddTicks(5197), new DateTime(2022, 11, 7, 18, 39, 20, 587, DateTimeKind.Local).AddTicks(5201) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageAnnualBilling", "CreatedAt", "UpdatedAt" },
                values: new object[] { 10000000m, new DateTime(2022, 11, 7, 18, 39, 20, 634, DateTimeKind.Local).AddTicks(4149), new DateTime(2022, 11, 7, 18, 39, 20, 634, DateTimeKind.Local).AddTicks(4152) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AverageAnnualBilling", "CreatedAt", "UpdatedAt" },
                values: new object[] { 10000000m, new DateTime(2022, 11, 7, 18, 39, 20, 676, DateTimeKind.Local).AddTicks(3449), new DateTime(2022, 11, 7, 18, 39, 20, 676, DateTimeKind.Local).AddTicks(3452) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 7, 18, 39, 20, 596, DateTimeKind.Local).AddTicks(7892), new DateTime(2022, 11, 7, 18, 39, 20, 596, DateTimeKind.Local).AddTicks(7914) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 7, 18, 39, 20, 642, DateTimeKind.Local).AddTicks(8406), new DateTime(2022, 11, 7, 18, 39, 20, 642, DateTimeKind.Local).AddTicks(8414) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 11, 7, 18, 39, 20, 684, DateTimeKind.Local).AddTicks(4298), new DateTime(2022, 11, 7, 18, 39, 20, 684, DateTimeKind.Local).AddTicks(4321) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AverageAnnualBilling",
                table: "Ecommerces",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2,
                oldNullable: true);

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
                columns: new[] { "AverageAnnualBilling", "CreatedAt", "UpdatedAt" },
                values: new object[] { 10000000, new DateTime(2022, 11, 7, 18, 28, 20, 472, DateTimeKind.Local).AddTicks(1807), new DateTime(2022, 11, 7, 18, 28, 20, 472, DateTimeKind.Local).AddTicks(1811) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageAnnualBilling", "CreatedAt", "UpdatedAt" },
                values: new object[] { 10000000, new DateTime(2022, 11, 7, 18, 28, 20, 516, DateTimeKind.Local).AddTicks(3306), new DateTime(2022, 11, 7, 18, 28, 20, 516, DateTimeKind.Local).AddTicks(3309) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AverageAnnualBilling", "CreatedAt", "UpdatedAt" },
                values: new object[] { 10000000, new DateTime(2022, 11, 7, 18, 28, 20, 559, DateTimeKind.Local).AddTicks(3373), new DateTime(2022, 11, 7, 18, 28, 20, 559, DateTimeKind.Local).AddTicks(3377) });

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
    }
}
