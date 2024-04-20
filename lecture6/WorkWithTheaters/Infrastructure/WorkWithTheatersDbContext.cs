using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Configuration;
using Microsoft.Identity.Client.AppConfig;

namespace Infrastructure
{
    public class WorkWithTheatersDbContext : DbContext
    {
        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WorkWithTheaters;Trusted_Connection=false;");
        }
        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ActorConfiguretion());
            modelBuilder.ApplyConfiguration(new PlayConfiguration());
            modelBuilder.ApplyConfiguration(new TheaterConfiguration());
        }
    }
}
