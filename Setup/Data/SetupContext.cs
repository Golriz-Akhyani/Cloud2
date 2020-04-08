using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Setup.Models;

namespace Setup.Data
{
    public class SetupContext : IdentityDbContext
    {
        public SetupContext(DbContextOptions<SetupContext> options)
            : base(options)
        {
        }
        public DbSet<Setup.Models.Account> Account { get; set; }
        public DbSet<Setup.Models.Place> Place { get; set; }
    }
}
