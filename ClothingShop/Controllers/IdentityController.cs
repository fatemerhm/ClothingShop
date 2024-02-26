using ClothingShop.Core.Domain;
using ClothingShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClothingShop.Controllers
{
    public class IdentityController : Controller
    {
       
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly Cart cart;

        public IdentityController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, Cart cart)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.cart = cart;
        }
        public IActionResult Register()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            if (ModelState.IsValid)
            {
                IdentityUser appUser = new IdentityUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    EmailConfirmed = true,

                };

                IdentityResult result = await userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "guest");
                    return RedirectToAction("Index", "home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }


            }
            return View(model);
        }
        public IActionResult Login(string ReturnUrl)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            LoginViewModel model = new LoginViewModel();
            //model.ReturnUrl = ReturnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, true, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("index", "home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username Not Found");
                }


            }

            return View();

            
        }
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        public IActionResult AccessDenied()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
