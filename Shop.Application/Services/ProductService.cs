using Microsoft.EntityFrameworkCore;
using Shop.Application.Contract.Dtos.Products;
using Shop.Application.Contract.IServices;
using Shop.Infrastructure.Repositories;

namespace Shop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ProductDto GetProduct(int id)
        {
            var product = productRepository.GetById(id);

            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Description = product.Description,
                ImagePath = product.ImagePath,
                //Sizes = string.Join(',', x.ProductTShirtSizes.Select(s => s.TShirtSize.Name))
            };
        }

        public List<ProductDto> GetProducts()
        {

            //string[] array = { "a", "b", "c" };
            //var res = string.Join(',', array);


            return productRepository.Get().Include(ps => ps.ProductTShirtSizes).ThenInclude(s => s.TShirtSize).Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Description = x.Description,
                ImagePath = x.ImagePath,
                Sizes = string.Join(',', x.ProductTShirtSizes.Select(s => s.TShirtSize.Name))
            }).ToList();
        }
    }
}
