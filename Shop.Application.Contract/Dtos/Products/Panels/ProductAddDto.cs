using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Contract.Dtos.Products.Panels
{
    public record ProductAddDto
    {
        public ProductAddDto()
        {
            SelectedTShirtSizes = new List<int>();
        }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "فیلد نام نمیتواند خالی باشد"), StringLength(512)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public IFormFile Image { get; set; }

        public ICollection<int> SelectedTShirtSizes { get; set; }
    }
}
