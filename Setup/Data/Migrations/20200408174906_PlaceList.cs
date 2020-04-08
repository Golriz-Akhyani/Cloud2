using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Setup.Data.Migrations
{
    public partial class PlaceList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceID",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaceName = table.Column<string>(nullable: true),
                    Liscence = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Wifi = table.Column<bool>(nullable: false),
                    Whiteboard = table.Column<bool>(nullable: false),
                    ParkingLot = table.Column<bool>(nullable: false),
                    Washroom = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Place_PlaceID",
                table: "Account");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Account_PlaceID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PlaceID",
                table: "Account");
        }
    }
}
