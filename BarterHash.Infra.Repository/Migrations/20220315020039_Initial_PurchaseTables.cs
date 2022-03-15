using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarterHash.Infra.Repository.Migrations
{
    public partial class Initial_PurchaseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseChecks",
                columns: table => new
                {
                    PurchaseCheckId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckOverCounter = table.Column<int>(type: "int", nullable: false),
                    LastCheckTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstCheckDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseChecks", x => x.PurchaseCheckId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEvents",
                columns: table => new
                {
                    PurchaseEventId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimePurchasePayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseAmountPaidInEther = table.Column<decimal>(type: "decimal(28,18)", precision: 28, scale: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEvents", x => x.PurchaseEventId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseNotices",
                columns: table => new
                {
                    PurchaseNoticeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimePurchaseNotice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseAmountInPrimaryCurrency = table.Column<decimal>(type: "decimal(38,8)", precision: 38, scale: 8, nullable: false),
                    PrimaryCurrency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseNotices", x => x.PurchaseNoticeId);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseIdentifier = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PurchaseCheckId = table.Column<long>(type: "bigint", nullable: false),
                    PurchaseEventId = table.Column<long>(type: "bigint", nullable: true),
                    PurchaseNoticeId = table.Column<long>(type: "bigint", nullable: true),
                    EcommerceWalletAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    CostumerWalletAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_PurchaseChecks_PurchaseCheckId",
                        column: x => x.PurchaseCheckId,
                        principalTable: "PurchaseChecks",
                        principalColumn: "PurchaseCheckId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_PurchaseEvents_PurchaseEventId",
                        column: x => x.PurchaseEventId,
                        principalTable: "PurchaseEvents",
                        principalColumn: "PurchaseEventId");
                    table.ForeignKey(
                        name: "FK_Purchases_PurchaseNotices_PurchaseNoticeId",
                        column: x => x.PurchaseNoticeId,
                        principalTable: "PurchaseNotices",
                        principalColumn: "PurchaseNoticeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseCheckId",
                table: "Purchases",
                column: "PurchaseCheckId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseEventId",
                table: "Purchases",
                column: "PurchaseEventId",
                unique: true,
                filter: "[PurchaseEventId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_PurchaseNoticeId",
                table: "Purchases",
                column: "PurchaseNoticeId",
                unique: true,
                filter: "[PurchaseNoticeId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "PurchaseChecks");

            migrationBuilder.DropTable(
                name: "PurchaseEvents");

            migrationBuilder.DropTable(
                name: "PurchaseNotices");
        }
    }
}
