using System;
using Microsoft.EntityFrameworkCore;
namespace SecretSanta.Data
{
    public class SecretSantaContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Gift> Gifts => Set<Gift>();

        public SecretSantaContext() :base(new DbContextOptionsBuilder<SecretSantaContext>()
            .EnableSensitiveDataLogging().UseSqlite("Data Source=main.db").Options)
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if(modelBuilder is null)
            {
                throw new ArgumentException(nameof(modelBuilder));
            }
            modelBuilder.Entity<User>().HasData((DbInitializer.Users()));
            modelBuilder.Entity<Group>().HasData(DbInitializer.Groups());
            modelBuilder.Entity<Gift>().HasData(DbInitializer.Gifts());
        }
    }
}