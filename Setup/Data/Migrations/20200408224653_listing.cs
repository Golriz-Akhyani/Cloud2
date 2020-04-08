using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Setup.Data.Migrations
{
    public partial class listing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListingID",
                table: "Place",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotoID",
                table: "Place",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingID",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    PhotoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotoName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.PhotoID);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_Transaction_TransactionID",
                        column: x => x.TransactionID,
                        principalTable: "Transaction",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    ListingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListingDate = table.Column<DateTime>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    BookingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.ListingID);
                    table.ForeignKey(
                        name: "FK_Listing_Booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    TimeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ListingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.TimeID);
                    table.ForeignKey(
                        name: "FK_Time_Listing_ListingID",
                        column: x => x.ListingID,
                        principalTable: "Listing",
                        principalColumn: "ListingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Place_ListingID",
                table: "Place",
                column: "ListingID");

            migrationBuilder.CreateIndex(
                name: "IX_Place_PhotoID",
                table: "Place",
                column: "PhotoID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_BookingID",
                table: "Account",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TransactionID",
                table: "Booking",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_BookingID",
                table: "Listing",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_Time_ListingID",
                table: "Time",
                column: "ListingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Booking_BookingID",
                table: "Account",
                column: "BookingID",
                principalTable: "Booking",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Place_Listing_ListingID",
                table: "Place",
                column: "ListingID",
                principalTable: "Listing",
                principalColumn: "ListingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Place_Photo_PhotoID",
                table: "Place",
                column: "PhotoID",
                principalTable: "Photo",
                principalColumn: "PhotoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Booking_BookingID",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Place_Listing_ListingID",
                table: "Place");

            migrationBuilder.DropForeignKey(
                name: "FK_Place_Photo_PhotoID",
                table: "Place");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "Listing");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Place_ListingID",
                table: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Place_PhotoID",
                table: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Account_BookingID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ListingID",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "PhotoID",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "Account");
        }
    }
}
