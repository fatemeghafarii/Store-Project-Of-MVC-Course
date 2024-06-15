using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Contract.Dtos.Products.Panels;
using Shop.Application.Contract.IServices;

namespace Shop.EndPoint.Razor.Pages.Panels
{
    public class CreateModel : PageModel
    {
        private readonly IProductPanelService productService;

        public CreateModel(IProductPanelService productService)
        {
            this.productService = productService;
        }

        public ProductAddDto Product  { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost([FromForm] ProductAddDto dto)
        {
            this.Product = dto;
            if (ModelState.IsValid)
            {
                var rowAffected = productService.Add(dto);
                if (rowAffected > 0)
                    return RedirectToPage("Index");
                else
                    throw new Exception();
            }
            else
                return Page();
        }
    }
}
