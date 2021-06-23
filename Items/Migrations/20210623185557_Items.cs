using Microsoft.EntityFrameworkCore.Migrations;

namespace Items.Migrations
{
    public partial class Items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,4)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 1, "Sport" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 2, "Elegant" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 3, "Casual" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "CategoryId", "Color", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 1, "Nike", 1, "Black", "Nike sport shoes for man", "https://img01.ztat.net/article/spp-media-p1/ccd66a56f6c439c7a4a87f9d365ff8f8/45a85d86e84641a8aeb332255c4353aa.jpg", 239.99m, "Blizzard" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "CategoryId", "Color", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 2, "Bytom", 2, "White", "Adidas sport shoes for man", "https://www.bytom.com.pl/files/sc_staging_images/product/normal_img_43791.jpg", 499.99m, "Melvin" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "CategoryId", "Color", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 3, "Kso Evo", 2, "Blue", "Walking shoes", "https://img01.ztat.net/article/spp-media-p1/7915e22f5a323fed81631f9f87aee165/3493cf55c5b1422cbd8614c7c4184af6.jpg?imwidth=1800&filter=packshot", 439.99m, "Kso walking" });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
