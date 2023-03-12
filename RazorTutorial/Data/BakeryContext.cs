using RazorTutorial.Models;

using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace RazorTutorial.Data
{
    public class BakeryContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public BakeryContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source=Bakery.db");
       
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration()).Seed();
        }
    }
}
