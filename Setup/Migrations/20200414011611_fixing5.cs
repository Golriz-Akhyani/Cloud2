using Microsoft.EntityFrameworkCore.Migrations;

namespace Setup.Migrations
{
    public partial class fixing5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Liscence",
                table: "Place",
                newName: "License");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "License",
                table: "Place",
                newName: "Liscence");
        }
    }
}
