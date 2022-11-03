using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EtherWallets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Ecommerces",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "EcommerceAdmins",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "ValidityInDays",
                table: "ApiCredentials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ecommerces_Cnpj_Email",
                table: "Ecommerces",
                columns: new[] { "Cnpj", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EcommerceManagers_Username",
                table: "EcommerceManagers",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ecommerces_Cnpj_Email",
                table: "Ecommerces");

            migrationBuilder.DropIndex(
                name: "IX_EcommerceManagers_Username",
                table: "EcommerceManagers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EtherWallets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Ecommerces");

            migrationBuilder.DropColumn(
                name: "ValidityInDays",
                table: "ApiCredentials");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "EcommerceAdmins",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
