using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class FixPasswordLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "EcommerceManagers",
                type: "varbinary(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "EcommerceManagers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "EcommerceAdmins",
                type: "varbinary(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "EcommerceAdmins",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(260)",
                oldMaxLength: 260);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "EcommerceManagers",
                type: "varbinary(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "EcommerceManagers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Salt",
                table: "EcommerceAdmins",
                type: "varbinary(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "EcommerceAdmins",
                type: "nvarchar(260)",
                maxLength: 260,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
