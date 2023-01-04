using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class IsInternalCustodyField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInternalCustody",
                table: "EtherWallets",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInternalCustody",
                table: "EtherWallets");

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzI1ODEyOTMsImlhdCI6MTY3MDg1MzI5M30.CKmQgLLRJtsOZoLgByR80KR7tdOK2u1Xx33-O8cQg88", new DateTime(2023, 1, 1, 13, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 606, DateTimeKind.Local).AddTicks(947), new DateTime(2022, 12, 12, 10, 54, 53, 606, DateTimeKind.Local).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzI1ODEyOTMsImlhdCI6MTY3MDg1MzI5M30.dHEQUkET3_l2f2yeAB5G-Z51ZN4J0JuucUkCfWWILuM", new DateTime(2023, 1, 1, 13, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 633, DateTimeKind.Local).AddTicks(7316), new DateTime(2022, 12, 12, 10, 54, 53, 633, DateTimeKind.Local).AddTicks(7317) });

            migrationBuilder.UpdateData(
                table: "ApiCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MDg1MzI5MywiZXhwIjoxNjcyNTgxMjkzLCJpYXQiOjE2NzA4NTMyOTN9.3UM0mrWGCcPUhmrHW4EAWk1wvSmFyU5kQ8obAvou_Wo", new DateTime(2023, 1, 1, 13, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 664, DateTimeKind.Local).AddTicks(638), new DateTime(2022, 12, 12, 10, 54, 53, 664, DateTimeKind.Local).AddTicks(639) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvQWRtaW4iLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwicm9sZSI6IiIsIm5iZiI6MTY3MDg1MzI5MywiZXhwIjoxNjcwODk2NDkzLCJpYXQiOjE2NzA4NTMyOTN9.xVJUCJ851AwF7gkQy8fEPAjajistPygVWW3Nm2UDToc", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 592, DateTimeKind.Local).AddTicks(9503), "mkPSkMD1Dartaem+Uhf9G56Xo+8PZhgM1srbUqTIiWQ=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb0FkbWluIiwiZW1haWwiOiJhbmdlbG9waWxldHRpQGdtYWlsLmNvbSIsIm5iZiI6MTY3MDg1MzI5MywiZXhwIjoxNjcxMDI2MDkzLCJpYXQiOjE2NzA4NTMyOTN9.0DyRh6HqChG25u0nIG0rMLMkM9-HXtjjHNxAF2LiqwM", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 233, 66, 57, 164, 194, 167, 188, 65, 30, 87, 254, 158, 2, 124, 125, 233, 16, 253, 223, 52, 19, 160, 155, 1, 216, 95, 249, 227, 7, 57, 238, 147, 130, 22, 75, 25, 137, 13, 233, 251 }, new DateTime(2022, 12, 12, 10, 54, 53, 592, DateTimeKind.Local).AddTicks(9504) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYUFkbWluIiwiZW1haWwiOiJicnVuYS5mdXNpZ2VyQGdtYWlsLmNvbSIsInJvbGUiOiIiLCJuYmYiOjE2NzA4NTMyOTMsImV4cCI6MTY3MDg5NjQ5MywiaWF0IjoxNjcwODUzMjkzfQ.1QiOP8naSjd82O0FanhoZ6kbbU52hddfrXeWQP4JVt8", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 623, DateTimeKind.Local).AddTicks(3468), "Qjsx2NEZEEtrR6GD73HrPrbc45lmiB+91tXE2oqBJXc=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hQWRtaW4iLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzEwMjYwOTMsImlhdCI6MTY3MDg1MzI5M30.54ptDcKgKzJdXtgXJmBSCoppC37wrB5SVlDrBq6U9EE", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 211, 54, 170, 190, 91, 7, 113, 224, 201, 214, 165, 138, 135, 17, 187, 68, 201, 244, 197, 203, 70, 86, 227, 54, 236, 240, 101, 76, 173, 108, 103, 177, 147, 236, 105, 7, 149, 79, 201, 119 }, new DateTime(2022, 12, 12, 10, 54, 53, 623, DateTimeKind.Local).AddTicks(3468) });

            migrationBuilder.UpdateData(
                table: "EcommerceAdmins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc0FkbWluIiwiZW1haWwiOiJsdWNhc29saXZlaXJhLmNvbnRhdG9ubGluZUBnbWFpbC5jb20iLCJyb2xlIjoiIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzA4OTY0OTMsImlhdCI6MTY3MDg1MzI5M30.2T3Qhjkg9J9gojVQoHY0XdNhdR_-V9xkkKaQAsY_u1g", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 650, DateTimeKind.Local).AddTicks(201), "37Za6AoyjLcbN4U7eaBgUPEfid9rLC4raV53ZVdqxKY=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzQWRtaW4iLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MDg1MzI5MywiZXhwIjoxNjcxMDI2MDkzLCJpYXQiOjE2NzA4NTMyOTN9.wH9wgVoy83eQVCORdVytFpA2xnyd8O2LAkb0ae8ToyQ", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 147, 139, 221, 56, 159, 246, 227, 201, 96, 157, 178, 23, 17, 64, 252, 132, 71, 187, 175, 167, 110, 51, 51, 171, 139, 131, 43, 81, 196, 193, 20, 249, 178, 209, 37, 248, 57, 109, 141, 203 }, new DateTime(2022, 12, 12, 10, 54, 53, 650, DateTimeKind.Local).AddTicks(202) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFuZ2VsbyIsIlVzZXJuYW1lIjoiYW5nZWxvTWFuYWdlciIsImVtYWlsIjoiYW5nZWxvcGlsZXR0aUBnbWFpbC5jb20iLCJuYmYiOjE2NzA4NTMyOTMsImV4cCI6MTY3MDg5NjQ5MywiaWF0IjoxNjcwODUzMjkzfQ.8xmsHHB-B4y83duvNMqk6eFiHQKE5L3jezUxCqIglHs", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 577, DateTimeKind.Local).AddTicks(9856), "YGxibG14v0NEgdJhE65juqalP4Zm7OpP6QMhmhLh/YM=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFuZ2Vsb01hbmFnZXIiLCJlbWFpbCI6ImFuZ2Vsb3BpbGV0dGlAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzEwMjYwOTMsImlhdCI6MTY3MDg1MzI5M30.IyBQ40SoYhCzjU8t0FhAXdrsKK5w-sUyq33hXWtZasw", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 170, 97, 123, 14, 227, 155, 68, 216, 124, 179, 247, 254, 104, 68, 162, 169, 218, 166, 139, 162, 1, 78, 53, 92, 139, 210, 248, 200, 154, 197, 137, 6, 219, 75, 4, 133, 215, 104, 122, 239 }, new DateTime(2022, 12, 12, 10, 54, 53, 577, DateTimeKind.Local).AddTicks(9866) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJydW5hIiwiVXNlcm5hbWUiOiJicnVuYU1hbmFnZXIiLCJlbWFpbCI6ImJydW5hLmZ1c2lnZXJAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzA4OTY0OTMsImlhdCI6MTY3MDg1MzI5M30.VKFA-09In7EgfFbACo_G_pIpZOl7OSduULSyAPa9hHA", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 611, DateTimeKind.Local).AddTicks(8933), "eGXp9kjqj6x9Y41b5fKeUYKzyH6ZnEvGnPntXFV8jek=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImJydW5hTWFuYWdlciIsImVtYWlsIjoiYnJ1bmEuZnVzaWdlckBnbWFpbC5jb20iLCJuYmYiOjE2NzA4NTMyOTMsImV4cCI6MTY3MTAyNjA5MywiaWF0IjoxNjcwODUzMjkzfQ.OGxlQWzfynPgOXEoNo0azircNxpie-WKW95R4Lr6XCI", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 36, 108, 162, 66, 25, 162, 194, 20, 127, 249, 115, 36, 159, 176, 120, 104, 236, 236, 166, 242, 96, 22, 250, 175, 16, 91, 228, 21, 226, 157, 119, 0, 117, 123, 29, 228, 240, 237, 0, 236 }, new DateTime(2022, 12, 12, 10, 54, 53, 611, DateTimeKind.Local).AddTicks(8935) });

            migrationBuilder.UpdateData(
                table: "EcommerceManagers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AccessToken", "AccessTokenExpiry", "CreatedAt", "Password", "RefreshToken", "RefreshTokenExpiry", "Salt", "UpdatedAt" },
                values: new object[] { "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ikx1Y2FzIiwiVXNlcm5hbWUiOiJsdWNhc01hbmFnZXIiLCJlbWFpbCI6Imx1Y2Fzb2xpdmVpcmEuY29udGF0b25saW5lQGdtYWlsLmNvbSIsIm5iZiI6MTY3MDg1MzI5MywiZXhwIjoxNjcwODk2NDkzLCJpYXQiOjE2NzA4NTMyOTN9.S4ZuF1PULDavKLQ3VgussYbkgugOze4RVDjKkKFOjhc", new DateTime(2022, 12, 13, 1, 54, 53, 0, DateTimeKind.Utc), new DateTime(2022, 12, 12, 10, 54, 53, 639, DateTimeKind.Local).AddTicks(8028), "IrLj+/MOgxn9mShHoNWQl7yOBBOOY0Pn3GpW49S5l98=", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6Imx1Y2FzTWFuYWdlciIsImVtYWlsIjoibHVjYXNvbGl2ZWlyYS5jb250YXRvbmxpbmVAZ21haWwuY29tIiwibmJmIjoxNjcwODUzMjkzLCJleHAiOjE2NzEwMjYwOTMsImlhdCI6MTY3MDg1MzI5M30.ENaeAFQCxPzql7P6Sp11FvTD2N96YMsg6Q52C-py_XU", new DateTime(2022, 12, 14, 13, 54, 53, 0, DateTimeKind.Utc), new byte[] { 83, 1, 144, 168, 22, 98, 66, 52, 31, 40, 101, 169, 67, 112, 118, 104, 138, 231, 187, 161, 225, 247, 76, 67, 231, 40, 182, 42, 98, 47, 203, 188, 195, 37, 210, 110, 78, 15, 115, 20 }, new DateTime(2022, 12, 12, 10, 54, 53, 639, DateTimeKind.Local).AddTicks(8029) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 54, 53, 606, DateTimeKind.Local).AddTicks(937), new DateTime(2022, 12, 12, 10, 54, 53, 606, DateTimeKind.Local).AddTicks(939) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 54, 53, 633, DateTimeKind.Local).AddTicks(7310), new DateTime(2022, 12, 12, 10, 54, 53, 633, DateTimeKind.Local).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "Ecommerces",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 54, 53, 664, DateTimeKind.Local).AddTicks(630), new DateTime(2022, 12, 12, 10, 54, 53, 664, DateTimeKind.Local).AddTicks(631) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 54, 53, 611, DateTimeKind.Local).AddTicks(8659), new DateTime(2022, 12, 12, 10, 54, 53, 611, DateTimeKind.Local).AddTicks(8671) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 54, 53, 639, DateTimeKind.Local).AddTicks(7843), new DateTime(2022, 12, 12, 10, 54, 53, 639, DateTimeKind.Local).AddTicks(7847) });

            migrationBuilder.UpdateData(
                table: "EtherWallets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 54, 53, 671, DateTimeKind.Local).AddTicks(7455), new DateTime(2022, 12, 12, 10, 54, 53, 671, DateTimeKind.Local).AddTicks(7466) });
        }
    }
}
