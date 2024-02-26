using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;
using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProdctFacade prodctFacade;
        private readonly Cart cart;
        public CategoryController(IProdctFacade prodctFacade, Cart cart)
        {
            this.prodctFacade = prodctFacade;
            this.cart = cart;

        }
        public IActionResult GetCloth(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = prodctFacade.GetCategory(1, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
        public IActionResult GetAccs(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = prodctFacade.GetCategory(3, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
        public IActionResult GetBag(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = prodctFacade.GetCategory(2, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
        public IActionResult GetBeau(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = prodctFacade.GetCategory(4, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
    }
}
