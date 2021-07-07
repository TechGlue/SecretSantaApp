using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.Data
{
    public class SecretSantaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source = main.db");
        
    }
}
