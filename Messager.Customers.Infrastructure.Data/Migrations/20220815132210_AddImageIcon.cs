using Microsoft.EntityFrameworkCore.Migrations;

namespace Messager.Customers.Infrastructure.Data.Migrations
{
    public partial class AddImageIcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconImageSrc",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconImageSrc",
                table: "Customers");
        }
    }
}
