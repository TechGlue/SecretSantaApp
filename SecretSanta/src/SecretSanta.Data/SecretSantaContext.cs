using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Data
{
    public class SecretSantaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupAssignment> GroupAssignments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source = main.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.Entity<Assignment>()
                    .HasAlternateKey(a => new {a.Giver_Receiver});
            }

            modelBuilder.Entity<User>().HasData((DbInitializer.Users()));
            modelBuilder.Entity<Group>().HasData(DbInitializer.Groups());
        }
    }
}
