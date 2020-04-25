using Microsoft.EntityFrameworkCore.Migrations;

namespace Setup.Migrations
{
    public partial class complex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Place_PlaceID",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_PlaceID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PlaceID",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Place",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Place_AccountID",
                table: "Place",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Place_Account_AccountID",
                table: "Place",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_Account_AccountID",
                table: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Place_AccountID",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Place");

            migrationBuilder.AddColumn<int>(
                name: "PlaceID",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_PlaceID",
                table: "Account",
                column: "PlaceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Place_PlaceID",
                table: "Account",
                column: "PlaceID",
                principalTable: "Place",
                principalColumn: "PlaceID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
