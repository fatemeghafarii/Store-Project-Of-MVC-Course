using Shop.Application.Contract.Dtos;
using Shop.Application.Contract.Dtos.Products.Panels;

namespace Shop.Application.Contract.IServices;

public interface IProductPanelService
{
    List<ProductPanelDto> GetProducts();
    ProductPanelDto GetProductById(int id);
    ProductEditDto GetProductForEdit(int id);
    List<KeyValueDto> GetTShirtSize();
    int Add(ProductAddDto product);
    int Edit(ProductEditDto product);
}
