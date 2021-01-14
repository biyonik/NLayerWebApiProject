using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Data.Configurations;
using NLayerWebApiProject.Data.Seeds;

namespace NLayerWebApiProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSeed(new[] {1, 2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new[] {1, 2}));
            base.OnModelCreating(modelBuilder);
        }
    }
}