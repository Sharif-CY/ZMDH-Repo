using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WDPR.Models;

namespace WDPR.Data {
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext (DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<WDPR.Models.Hulpverlener> Hulpverlener { get; set; }
    }
}