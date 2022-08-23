using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Messager.Customers.Infrastructure.Data.Migrations
{
    public partial class AddIconIdToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconImageSrc",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "IconId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "IconImageSrc",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
