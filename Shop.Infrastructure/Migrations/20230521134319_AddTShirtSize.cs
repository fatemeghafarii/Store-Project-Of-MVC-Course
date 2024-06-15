using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class AddTShirtSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TShirtSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "NVarChar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TShirtSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTShirtSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TShirtSizeId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTShirtSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTShirtSize_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTShirtSize_TShirtSize_TShirtSizeId",
                        column: x => x.TShirtSizeId,
                        principalTable: "TShirtSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTShirtSize_ProductId",
                table: "ProductTShirtSize",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTShirtSize_TShirtSizeId",
                table: "ProductTShirtSize",
                column: "TShirtSizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTShirtSize");

            migrationBuilder.DropTable(
                name: "TShirtSize");
        }
    }
}
