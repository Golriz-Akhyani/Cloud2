using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Setup.Migrations
{
    public partial class P : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoBytes",
                table: "Photo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoBytes",
                table: "Photo");
        }
    }
}
