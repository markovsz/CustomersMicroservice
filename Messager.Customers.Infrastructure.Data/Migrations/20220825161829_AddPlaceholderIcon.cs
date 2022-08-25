using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Messager.Customers.Infrastructure.Data.Migrations
{
    public partial class AddPlaceholderIcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Icons",
                column: "Id",
                value: new Guid("00000000-0000-0000-0000-000000000001"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Icons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));
        }
    }
}
