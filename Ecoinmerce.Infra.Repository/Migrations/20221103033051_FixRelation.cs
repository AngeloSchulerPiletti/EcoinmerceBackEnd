using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class FixRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcommerceManagers_Ecommerces_EcommerceId",
                table: "EcommerceManagers");

            migrationBuilder.DropIndex(
                name: "IX_EcommerceManagers_EcommerceId",
                table: "EcommerceManagers");

            migrationBuilder.CreateIndex(
                name: "IX_Ecommerces_ManagerId",
                table: "Ecommerces",
                column: "ManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ecommerces_EcommerceManagers_ManagerId",
                table: "Ecommerces",
                column: "ManagerId",
                principalTable: "EcommerceManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ecommerces_EcommerceManagers_ManagerId",
                table: "Ecommerces");

            migrationBuilder.DropIndex(
                name: "IX_Ecommerces_ManagerId",
                table: "Ecommerces");

            migrationBuilder.CreateIndex(
                name: "IX_EcommerceManagers_EcommerceId",
                table: "EcommerceManagers",
                column: "EcommerceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EcommerceManagers_Ecommerces_EcommerceId",
                table: "EcommerceManagers",
                column: "EcommerceId",
                principalTable: "Ecommerces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
