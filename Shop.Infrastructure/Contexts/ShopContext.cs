using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Mappings;
using Shop.Model.Models;

namespace Shop.Infrastructure.Contexts
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<TShirtSize> TShirtSize { get; set; }
        public DbSet<ProductTShirtSize> ProductTShirtSize { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TShirtSizeEntityTypeConfiguration());
            modelBuilder.Entity<TShirtSize>().HasData(
                new TShirtSize { Id = 1, Name = "SM" },
                new TShirtSize { Id = 2, Name = "MD" },
                new TShirtSize { Id = 3, Name = "LG" },
                new TShirtSize { Id = 4, Name = "XL" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
