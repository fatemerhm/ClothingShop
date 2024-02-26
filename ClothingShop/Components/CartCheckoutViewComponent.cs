using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Components
{
    public class CartCheckoutViewComponent : ViewComponent
    {

        private readonly Cart cart;
        public CartCheckoutViewComponent(Cart cart)
        {
            this.cart = cart;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        { 
            return View(cart);
        }
    }
}
