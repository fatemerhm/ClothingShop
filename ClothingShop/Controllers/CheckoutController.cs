using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly Cart cart;
        private readonly IOrderFacade orderFacade;

        public CheckoutController(Cart cart, IOrderFacade orderFacade)
        {
            this.cart = cart;
            this.orderFacade = orderFacade;
        }
       // [Authorize(Roles = "admin")]
       // [Authorize(Roles = "guest")]
        public IActionResult Index()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            ViewBag.cart = cart;
            return View(new Order());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(Order order)
        {
            var totalPice = cart.GetTotalPrice();
            if (cart.CartLines.Count() == 0)
            {
                ModelState.AddModelError("", "سفارشی موجود نیست");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.CartLines.ToList();
                orderFacade.SaveOrder(order);
                cart.Clear();
                return RedirectToAction("Pay", "Payment", new { orderId = order.OrderID, totalPrice = totalPice });
            }
            return View(order);
        }
    }
}
