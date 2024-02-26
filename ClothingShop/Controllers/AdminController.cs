using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;
using ClothingShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMediaRepository mediaRepository;
        public AdminController(IProductRepository productRepository, ICategoryRepository categoryRepository, IMediaRepository mediaRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.mediaRepository = mediaRepository;

        }
        public IActionResult ShowProduct()
        {
            AdminViewModel viewModel = new AdminViewModel();
            viewModel.Product = productRepository.GetProducts();
            viewModel.Media = mediaRepository.GetMedias();
            viewModel.Category = categoryRepository.GetCategory();
            return View(viewModel);
        }
        public IActionResult AddProduct(Product product)
        {
            productRepository.Create(product);
            return View();
        }
        public IActionResult ShowOrder()
        {
            return View();
        }
        public IActionResult Medias()
        {
            return View();
        }
        public IActionResult Categorys()
        {
            return View();
        }
        public IActionResult ShowUsers(UserViewModel userView)
        {
            return View();
        }
    }
}
