using Shop.Model.Models;

namespace Shop.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Get();
        Product GetById(int id);
        int Add(Product product);
        int Update(Product product);
        void Delete(Product product);
    }
}
