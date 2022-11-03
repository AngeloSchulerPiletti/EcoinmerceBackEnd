using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class IConfirmableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsEmailConfirmed",
                table: "Ecommerces",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmationToken",
                table: "Ecommerces",
                type: "nvarchar(260)",
                maxLength: 260,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationTokenExpiry",
                table: "Ecommerces",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsEmailConfirmed",
                table: "EcommerceManagers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEmailConfirmed",
                table: "EcommerceAdmins",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmationToken",
                table: "Ecommerces");

            migrationBuilder.DropColumn(
                name: "ConfirmationTokenExpiry",
                table: "Ecommerces");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEmailConfirmed",
                table: "Ecommerces",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsEmailConfirmed",
                table: "EcommerceManagers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsEmailConfirmed",
                table: "EcommerceAdmins",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
