using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;
using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ClothingShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdctFacade prodctFacade;
        private readonly Cart cart;
        private List<CartLine> lines = new List<CartLine>();
        public HomeController(IProdctFacade prodctFacade, Cart cart)
        {
            this.prodctFacade = prodctFacade;
            this.cart = cart;
         

        }
        public IActionResult Index()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            return View();
        }

        public IActionResult SingelProduct(int id)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            Product product = prodctFacade.Get(id);
            return View(product);
        }

        public IActionResult Search(int page = 1, string category = "All", string q = "")
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var data = prodctFacade.ProductSearch(q, category, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(data.Item1, page, 8, data.Item2);
            ViewBag.category = category;
            ViewBag.q = q;
            return View(pageList);
        }
        public IActionResult Store(int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var data = prodctFacade.GetAll(page, 12);
            PagedList<Product> pageList = new PagedList<Product>(data.Item1, page, 12, data.Item2);
            return View(pageList);
        }
        public IActionResult AboutUs()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            return View();
        }

        public IActionResult Wishlist()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}