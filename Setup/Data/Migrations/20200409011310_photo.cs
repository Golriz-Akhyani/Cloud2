using Microsoft.EntityFrameworkCore.Migrations;

namespace Setup.Data.Migrations
{
    public partial class photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_Photo_PhotoID",
                table: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Place_PhotoID",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "PhotoID",
                table: "Place");

            migrationBuilder.AddColumn<int>(
                name: "PlaceID",
                table: "Photo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PlaceID",
                table: "Photo",
                column: "PlaceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Place_PlaceID",
                table: "Photo",
                column: "PlaceID",
                principalTable: "Place",
                principalColumn: "PlaceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Place_PlaceID",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_PlaceID",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "PlaceID",
                table: "Photo");

            migrationBuilder.AddColumn<int>(
                name: "PhotoID",
                table: "Place",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Place_PhotoID",
                table: "Place",
                column: "PhotoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Place_Photo_PhotoID",
                table: "Place",
                column: "PhotoID",
                principalTable: "Photo",
                principalColumn: "PhotoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
