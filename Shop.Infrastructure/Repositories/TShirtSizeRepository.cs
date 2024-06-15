using Shop.Infrastructure.Contexts;
using Shop.Model.Models;

namespace Shop.Infrastructure.Repositories
{
    public class TShirtSizeRepository : ITShirtSizeRepository
    {
        private readonly ShopContext context;

        public TShirtSizeRepository(ShopContext context)
        {
            this.context = context;
        }

        public IQueryable<TShirtSize> Get()
        {
            return context.TShirtSize;
        }
    }
}
