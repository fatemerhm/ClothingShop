using ClothingShop.Core.Domain;

namespace ClothingShop.Models
{
    public class AdminViewModel
    {
        public List<Product> Product { get; set; }
        public List<Media> Media { get; set; }
        public List<Category> Category { get; set; }
    }
}
