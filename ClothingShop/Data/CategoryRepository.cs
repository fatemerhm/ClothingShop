using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;

namespace ClothingShop.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<Category> GetCategory()
        {
            return context.Categories.ToList();
        }
    }
}
