using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class IncreaseMaxLengthWalletKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PublicKey",
                table: "EtherWallets",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrivateKey",
                table: "EtherWallets",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PublicKey",
                table: "EtherWallets",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(65)",
                oldMaxLength: 65,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrivateKey",
                table: "EtherWallets",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(65)",
                oldMaxLength: 65,
                oldNullable: true);
        }
    }
}
