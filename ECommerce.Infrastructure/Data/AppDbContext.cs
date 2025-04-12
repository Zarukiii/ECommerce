using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Common;
using ECommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ParentCategory)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.ParentCategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.SubCategory)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.SubCategoryId);
        }
    }
}
