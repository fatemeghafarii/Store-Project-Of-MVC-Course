using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contract.IServices;

namespace Shop.EndPoint.MVC.Controllers
{
   // [Route("[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var product = productService.GetProducts();
            return View(product);
        }

        [HttpGet("ProductDetail/{id}")]
        public IActionResult ProductDetail(int id)
        {
            var product = productService.GetProduct(id);
            return View(product);
        }
    }
}
