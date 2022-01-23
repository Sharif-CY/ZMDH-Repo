using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WDPR.Models;
using System.Reflection;
using System.Text;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}