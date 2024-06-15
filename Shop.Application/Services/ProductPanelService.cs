using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Contract.Dtos;
using Shop.Application.Contract.Dtos.Products.Panels;
using Shop.Application.Contract.IServices;
using Shop.Infrastructure.Repositories;
using Shop.Model.Models;

namespace Shop.Application.Services
{
    public class ProductPanelService : IProductPanelService
    {
        private readonly IProductRepository productRepository;
        private readonly ITShirtSizeRepository tShirtSizeRepository;

        public ProductPanelService(IProductRepository productRepository, ITShirtSizeRepository tShirtSizeRepository)
        {
            this.productRepository = productRepository;
            this.tShirtSizeRepository = tShirtSizeRepository;
        }

        public List<ProductPanelDto> GetProducts()
        {
            var products = productRepository.Get().OrderByDescending(x => x.Id).Take(9).ToList();

            var result = products.Select(x => new ProductPanelDto { Id = x.Id, Name = x.Name, Quantity = x.Quantity, Description = x.Description }).ToList();

            return result;
        }

        public ProductPanelDto GetProductById(int id)
        {
            var product = productRepository.GetById(id);

            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Description = product.Description,
                ImagePath = product.ImagePath
            };
        }

        public ProductEditDto GetProductForEdit(int id)
        {
            var product = productRepository.Get().Include(x => x.ProductTShirtSizes).First(x => x.Id == id);

            return new()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Description = product.Description,
                ImagePath = product.ImagePath,
                SelectedTShirtSizes = product.ProductTShirtSizes.Select(x => x.TShirtSizeId).ToList()
            };
        }

        public int Add(ProductAddDto dto)
        {
            var imagePath = SaveImage(dto.Image);
            var product = MapToProduct(dto, imagePath);
            return productRepository.Add(product);
        }

        public List<KeyValueDto> GetTShirtSize()
        {
            return tShirtSizeRepository.Get()
                .Select(x => new KeyValueDto { Key = x.Name, Value = x.Id }).ToList();
        }

        private static string SaveImage(IFormFile file)
        {
            try
            {
                var extension = Path.GetExtension(file.FileName);
                string imageId = Guid.NewGuid().ToString();
                using Stream stream = file.OpenReadStream();
                using MemoryStream memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                var bytes = memoryStream.ToArray();

                //var root = Directory.GetCurrentDirectory();
                var path = Path.Combine("wwwroot\\Images\\products\\", imageId + extension);

                File.WriteAllBytes(path, bytes);
                return imageId + extension;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int Edit(ProductEditDto dto)
        {
            var product = productRepository.Get().Include(x => x.ProductTShirtSizes).First(x => x.Id == dto.Id);
            if (dto.Image != null)
                dto.ImagePath = SaveImage(dto.Image);

            MapToProduct(product, dto);

            return productRepository.Update(product);
        }

        private static Product MapToProduct(ProductAddDto dto, string imagePath)
        {
            return new Product
            {
                Name = dto.Name,
                Quantity = dto.Quantity,
                Description = dto.Description,
                ImagePath = imagePath,
                ProductTShirtSizes = dto.SelectedTShirtSizes.Select(x => new ProductTShirtSize
                {
                    TShirtSizeId = x
                }).ToList()
            };
        }

        private static void MapToProduct(Product product, ProductEditDto dto)
        {
            product.Name = dto.Name;
            product.Quantity = dto.Quantity;
            product.Description = dto.Description;
            product.ImagePath = string.IsNullOrEmpty(dto.ImagePath) ? product.ImagePath : dto.ImagePath;
            product.ProductTShirtSizes = dto.SelectedTShirtSizes.Select(x => new ProductTShirtSize
            {
                TShirtSizeId = x
            }).ToList();
        }
    }
}
