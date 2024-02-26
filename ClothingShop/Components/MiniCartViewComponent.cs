using ClothingShop.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Components
{
    public class MiniCartViewComponent : ViewComponent
    {
        private readonly Cart cart;
        public MiniCartViewComponent(Cart cart)
        {
            this.cart = cart;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(cart);
        }
    }
}
