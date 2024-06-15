using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Contract.Dtos.Products.Panels
{
    public record ProductEditDto
    {
        public ProductEditDto()
        {
            SelectedTShirtSizes = new List<int>();
        }

        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "فیلد نام نمیتواند خالی باشد"), StringLength(512)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public IFormFile? Image { get; set; }

        public ICollection<int> SelectedTShirtSizes { get; set; }

        private string viewImagePath = "";
        public string ViewImagePath
        {
            get { return Path.Combine(Images.HttpImagePath, viewImagePath); }

        }

        public string ImagePath
        {
            get
            {
                return viewImagePath;
            }
            set { viewImagePath = value; }
        }
    }
}
