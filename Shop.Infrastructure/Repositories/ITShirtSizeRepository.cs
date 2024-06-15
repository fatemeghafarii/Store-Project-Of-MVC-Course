using Shop.Model.Models;

namespace Shop.Infrastructure.Repositories
{
    public interface ITShirtSizeRepository
    {
        IQueryable<TShirtSize> Get();
       
    }
}
