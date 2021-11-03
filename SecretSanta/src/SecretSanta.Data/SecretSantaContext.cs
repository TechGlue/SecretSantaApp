using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Data
{
    public class SecretSantaContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Group> Groups => Set<Group>();

        public SecretSantaContext()
        {
        }
        public SecretSantaContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Fall back");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            // modelBuilder.Entity<User>().HasData((DbInitializer.Users()));
            // modelBuilder.Entity<Group>().HasData(DbInitializer.Groups());
        }
    }
}
