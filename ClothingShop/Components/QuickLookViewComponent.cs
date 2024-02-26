using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Components
{
    public class QuickLookViewComponent : ViewComponent
    {
        private readonly IProductRepository productRepository;

        public QuickLookViewComponent(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            Product product = productRepository.Get(id);
            return View(product);
        }
    }
}
