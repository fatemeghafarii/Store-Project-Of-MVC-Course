using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Contract.Dtos.Products;
using Shop.Application.Contract.IServices;

namespace Shop.EndPoint.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService productService;
        public List<ProductDto> products = new();
        public IndexModel(IProductService productService)
        {
            this.productService = productService;
        }

        public PageResult OnGet()
        {
            products = productService.GetProducts();
            return Page();
        }
    }
}
