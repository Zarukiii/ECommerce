using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Common;
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
                .HasOne(p => p.Category)
                .WithMany(c => c.CategoryProducts)
                .HasForeignKey(p => p.Category.Id)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.SubCategory)
                .WithMany(c => c.SubCategoryProducts)
                .HasForeignKey(p => p.SubCategory.Id)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .Property(p => p.Status)
                .HasConversion<string>();

            //modelBuilder.Entity<Product>()
            //    .Property(p => p.ParentCategory)
            //    .HasConversion<string>();

            //modelBuilder.Entity<Product>()
            //    .Property(p => p.SubCategory)
            //    .HasConversion<string>();
        }
    }
}
