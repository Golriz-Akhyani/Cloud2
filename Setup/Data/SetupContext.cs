using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Setup.Data
{
    public class SetupContext : IdentityDbContext
    {
        public SetupContext(DbContextOptions<SetupContext> options)
            : base(options)
        {
        }
    }
}
