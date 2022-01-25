using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WDPR.Models;

    public class MyContext : IdentityDbContext
    {
        public MyContext (DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<WDPR.Models.Hulpverlener> Hulpverlener { get; set; }

        public DbSet<WDPR.Models.Client> Client { get; set; }

        public DbSet<WDPR.Models.Ouder> Ouder { get; set; }
    }
