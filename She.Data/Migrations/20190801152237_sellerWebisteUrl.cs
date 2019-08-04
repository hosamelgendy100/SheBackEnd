using Microsoft.EntityFrameworkCore.Migrations;

namespace She.Data.Migrations
{
    public partial class sellerWebisteUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebSiteUrl",
                table: "Sellers",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebSiteUrl",
                table: "Sellers");
        }
    }
}
