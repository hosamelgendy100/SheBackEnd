using Microsoft.EntityFrameworkCore.Migrations;

namespace She.Data.Migrations
{
    public partial class addCountToColorAndSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductSizeCount",
                table: "ProductSizes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductColorCount",
                table: "ProductColors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductSizeCount",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "ProductColorCount",
                table: "ProductColors");
        }
    }
}
