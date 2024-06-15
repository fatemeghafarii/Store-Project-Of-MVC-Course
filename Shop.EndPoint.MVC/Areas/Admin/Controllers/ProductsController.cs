using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shop.Application.Contract.Dtos;
using Shop.Application.Contract.Dtos.Products.Panels;
using Shop.Application.Contract.IServices;

namespace Shop.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductPanelService productService;

        public ProductsController(IProductPanelService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var product = productService.GetProducts();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProductAddDto());
        }

        [HttpPost]
        public IActionResult Create([FromForm] ProductAddDto dto)
        {
            if (ModelState.IsValid)
            {
                var rowAffected = productService.Add(dto);
                if (rowAffected > 0)
                    return RedirectToAction("Index", "Products");
                else
                    throw new Exception();
            }
            else
                return View(dto);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var dto = productService.GetProductForEdit(id);
            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] ProductEditDto dto)
        {
            if (ModelState.IsValid)
            {
                var rowAffected = productService.Edit(dto);
                if (rowAffected > 0)
                    return RedirectToAction("Index", "Products");
                else
                    throw new Exception();
            }
            else
                return View(dto);
        }
    }
}
