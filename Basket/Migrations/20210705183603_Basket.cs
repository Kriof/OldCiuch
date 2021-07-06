using Microsoft.EntityFrameworkCore.Migrations;

namespace Basket.Migrations
{
    public partial class Basket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    BasketId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.BasketId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Basket_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Basket",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Basket",
                columns: new[] { "BasketId", "Count", "Price", "Username" },
                values: new object[] { "bf03304c-9abf-4b0a-b749-a7e94c7d2530", 1, 239.99m, "Test" });

            migrationBuilder.CreateIndex(
                name: "IX_Item_BasketId",
                table: "Item",
                column: "BasketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Basket");
        }
    }
}
