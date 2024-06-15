using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Shop.Infrastructure.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        public ShopContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ShopContext>();
            builder.UseSqlServer("data source =.; initial catalog = Shop236; integrated security = true");
            return new ShopContext(builder.Options);
        }
    }
}
