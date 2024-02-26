using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;
using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Components
{
    public class SearchViewComponent : ViewComponent
    {
        private readonly IProductRepository productRepository;

        public SearchViewComponent(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, string category = "All", string q = "")
        {
            var data = productRepository.GetFilterProducts(q, category, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(data.Item1, page, 8, data.Item2);
            ViewBag.category = category;
            ViewBag.q = q;
            return View(pageList);
        }

     }
}
