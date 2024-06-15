using Shop.Application.Contract.Dtos.Products;

namespace Shop.Application.Contract.IServices;
public interface IProductService
{
    List<ProductDto> GetProducts();
    ProductDto GetProduct(int id);
}
