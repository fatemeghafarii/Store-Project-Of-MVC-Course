using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contract.Dtos.Products;
using Shop.Application.Contract.IServices;

namespace Shop.EndPoint.MVC.Components
{
    [ViewComponent(Name = "MultiSelectViewComponent")]
    public class MultiSelectViewComponent : ViewComponent
    {
        private readonly IProductPanelService productService;

        public MultiSelectViewComponent(IProductPanelService productService)
        {
            this.productService = productService;
        }

        public IViewComponentResult Invoke(List<int> selectedCheckBoxesDto)
        {
            var multiSelectViewDto = new MultiSelectViewDto
            {
                KeyValues = productService.GetTShirtSize(),
                SelectedCheckBoxes = selectedCheckBoxesDto
            };

            return View(multiSelectViewDto);
        }
    }
}
