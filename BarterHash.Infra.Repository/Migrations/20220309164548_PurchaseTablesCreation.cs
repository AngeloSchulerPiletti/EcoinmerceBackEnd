using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarterHash.Infra.Repository.Migrations
{
    public partial class PurchaseTablesCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseIdentifier = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PurchaseAmountInEther = table.Column<long>(type: "bigint", nullable: false),
                    EcommerceWalletAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    CostumerWalletAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    DateTimePurchaseNotice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimePurchasePayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseChecks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckOverCounter = table.Column<int>(type: "int", nullable: false),
                    PurchaseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseChecks_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseChecks_PurchaseId",
                table: "PurchaseChecks",
                column: "PurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseChecks");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}
