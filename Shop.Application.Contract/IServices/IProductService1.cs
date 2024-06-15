using Shop.Application.Contract.Dtos.Products;

namespace Shop.Application.Contract.IServices
{
    public interface IProductService1
    {
        List<ProductDto> GetProducts();
    }
}