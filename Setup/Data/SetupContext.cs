using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Setup.Model;
using Setup.Models;

namespace Setup.Data
{
    public class SetupContext : DbContext
    {
        public SetupContext(DbContextOptions<SetupContext> options)
            : base(options)
        {
        }
        public DbSet<Setup.Models.Account> Account { get; set; }
        public DbSet<Setup.Models.Place> Place { get; set; }
        public DbSet<Setup.Models.Booking> Booking { get; set; }
        public DbSet<Setup.Models.Listing> Listing { get; set; }
        public DbSet<Setup.Models.Photo> Photo { get; set; }
        public DbSet<Setup.Models.Time> Time { get; set; }
        public DbSet<Setup.Models.Transaction> Transaction { get; set; }
        public DbSet<Setup.Models.PlaceAssign> PlaceAssign { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Place>().ToTable("Place");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Listing>().ToTable("Listing");
            modelBuilder.Entity<Photo>().ToTable("Photo");
            modelBuilder.Entity<Time>().ToTable("Time");
            modelBuilder.Entity<PlaceAssign>().ToTable("PlaceAssign");

            modelBuilder.Entity<PlaceAssign>()
                .HasKey(c => new { c.AccountID, c.PlaceID });
        }
    }
}
