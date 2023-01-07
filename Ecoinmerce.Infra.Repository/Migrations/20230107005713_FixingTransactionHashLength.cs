using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class FixingTransactionHashLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransactionHash",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransactionHash",
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
    }
}
