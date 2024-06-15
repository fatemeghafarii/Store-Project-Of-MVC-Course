using Shop.Infrastructure.Contexts;
using Shop.Model.Models;

namespace Shop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext context;
        public ProductRepository(ShopContext context)
        {
            this.context = context;
        }

        public IQueryable<Product> Get()
        {
            return context.Product;
        }

        public Product GetById(int id)
        {
            return context.Product.FirstOrDefault(x => x.Id == id);
        }

        public int Add(Product product)
        {
            context.Product.Add(product);

          
            return context.SaveChanges();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public int Update(Product product)
        {
            context.Product.Update(product);
            //var state2 = context.Entry<Product>(product).State;
            return context.SaveChanges();
        }
    }
}
