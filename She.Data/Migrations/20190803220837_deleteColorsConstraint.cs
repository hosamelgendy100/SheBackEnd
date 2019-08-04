using Microsoft.EntityFrameworkCore.Migrations;

namespace She.Data.Migrations
{
    public partial class deleteColorsConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    AvailableColorId = table.Column<int>(nullable: false),
                    ProductColorCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => new { x.ProductId, x.AvailableColorId });
                    table.ForeignKey(
                        name: "FK_ProductColors_AvailableColors_AvailableColorId",
                        column: x => x.AvailableColorId,
                        principalTable: "AvailableColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductColors_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_AvailableColorId",
                table: "ProductColors",
                column: "AvailableColorId");
        }
    }
}
