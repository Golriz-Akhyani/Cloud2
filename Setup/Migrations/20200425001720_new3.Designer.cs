﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Setup.Data;

namespace Setup.Migrations
{
    [DbContext(typeof(SetupContext))]
    [Migration("20200425001720_new3")]
    partial class new3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Setup.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookingID");

                    b.Property<string>("City");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .HasMaxLength(30);

                    b.Property<string>("Province");

                    b.Property<string>("Street");

                    b.Property<string>("Telephone");

                    b.Property<string>("UserName");

                    b.Property<string>("ZipCode");

                    b.HasKey("AccountID");

                    b.HasIndex("BookingID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Setup.Models.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TransactionID");

                    b.HasKey("BookingID");

                    b.HasIndex("TransactionID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Setup.Models.Listing", b =>
                {
                    b.Property<int>("ListingID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookingID");

                    b.Property<int>("Capacity");

                    b.Property<DateTime>("ListingDate");

                    b.HasKey("ListingID");

                    b.HasIndex("BookingID");

                    b.ToTable("Listing");
                });

            modelBuilder.Entity("Setup.Models.Photo", b =>
                {
                    b.Property<int>("PhotoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PhotoBytes");

                    b.Property<string>("PhotoName");

                    b.Property<int>("PlaceID");

                    b.HasKey("PhotoID");

                    b.HasIndex("PlaceID");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Setup.Models.Place", b =>
                {
                    b.Property<int>("PlaceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountID");

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<string>("License")
                        .HasMaxLength(8);

                    b.Property<int?>("ListingID");

                    b.Property<bool>("ParkingLot");

                    b.Property<string>("PlaceName")
                        .HasMaxLength(50);

                    b.Property<bool>("Washroom");

                    b.Property<bool>("Whiteboard");

                    b.Property<bool>("Wifi");

                    b.HasKey("PlaceID");

                    b.HasIndex("AccountID");

                    b.HasIndex("ListingID");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("Setup.Models.PlaceAssign", b =>
                {
                    b.Property<int>("AccountID");

                    b.Property<int>("PlaceID");

                    b.HasKey("AccountID", "PlaceID");

                    b.HasIndex("PlaceID");

                    b.ToTable("PlaceAssign");
                });

            modelBuilder.Entity("Setup.Models.Time", b =>
                {
                    b.Property<int>("TimeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("ListingID");

                    b.Property<DateTime>("Timeset");

                    b.HasKey("TimeID");

                    b.HasIndex("ListingID");

                    b.ToTable("Time");
                });

            modelBuilder.Entity("Setup.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Price");

                    b.Property<DateTime>("TransactionDate");

                    b.HasKey("TransactionID");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("Setup.Models.Account", b =>
                {
                    b.HasOne("Setup.Models.Booking")
                        .WithMany("Account")
                        .HasForeignKey("BookingID");
                });

            modelBuilder.Entity("Setup.Models.Booking", b =>
                {
                    b.HasOne("Setup.Models.Transaction")
                        .WithMany("Booking")
                        .HasForeignKey("TransactionID");
                });

            modelBuilder.Entity("Setup.Models.Listing", b =>
                {
                    b.HasOne("Setup.Models.Booking")
                        .WithMany("Listing")
                        .HasForeignKey("BookingID");
                });

            modelBuilder.Entity("Setup.Models.Photo", b =>
                {
                    b.HasOne("Setup.Models.Place")
                        .WithMany("PhotoID")
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Setup.Models.Place", b =>
                {
                    b.HasOne("Setup.Models.Account", "Administrator")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("Setup.Models.Listing")
                        .WithMany("Place")
                        .HasForeignKey("ListingID");
                });

            modelBuilder.Entity("Setup.Models.PlaceAssign", b =>
                {
                    b.HasOne("Setup.Models.Account", "Account")
                        .WithMany("PlaceAssign")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Setup.Models.Place", "Place")
                        .WithMany("PlaceAssigns")
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Setup.Models.Time", b =>
                {
                    b.HasOne("Setup.Models.Listing")
                        .WithMany("Time")
                        .HasForeignKey("ListingID");
                });
#pragma warning restore 612, 618
        }
    }
}
