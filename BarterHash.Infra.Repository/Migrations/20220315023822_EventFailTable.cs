using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarterHash.Infra.Repository.Migrations
{
    public partial class EventFailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseEventFails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogAddress = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: false),
                    BlockHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TransactionHash = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEventFails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseEventFails");
        }
    }
}
