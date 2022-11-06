using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecoinmerce.Infra.Repository.Migrations
{
    public partial class CreatePurchaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckOverCounter = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseChecks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEventFails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    BlockHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEventFails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaidAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountPaidInEther = table.Column<decimal>(type: "decimal(28,18)", precision: 28, scale: 18, nullable: false),
                    PurchaseIdentifier = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Failed = table.Column<bool>(type: "bit", nullable: false),
                    BlockHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TransactionHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    EcommerceWalletAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    CostumerWalletAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    PurchaseCheckId = table.Column<int>(type: "int", nullable: false),
                    PurchaseEventId = table.Column<int>(type: "int", nullable: false),
                    PurchaseEventFailId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_PurchaseChecks_PurchaseCheckId",
                        column: x => x.PurchaseCheckId,
                        principalTable: "PurchaseChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_PurchaseEventFails_PurchaseEventFailId",
                        column: x => x.PurchaseEventFailId,
                        principalTable: "PurchaseEventFails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_PurchaseEvents_PurchaseEventId",
                        column: x => x.PurchaseEventId,
                        principalTable: "PurchaseEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseCheckId",
                table: "Purchases",
                column: "PurchaseCheckId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseEventFailId",
                table: "Purchases",
                column: "PurchaseEventFailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseEventId",
                table: "Purchases",
                column: "PurchaseEventId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "PurchaseChecks");

            migrationBuilder.DropTable(
                name: "PurchaseEventFails");

            migrationBuilder.DropTable(
                name: "PurchaseEvents");
        }
    }
}
