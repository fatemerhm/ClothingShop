using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop.Data
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Product Get(int ProductId)
        {
            return context.Products.Include(a => a.Medias).First(a => a.ProductId == ProductId);
        }

        public (List<Product>, int Count) GetAll(int pageNumber, int PageSize)
        {
            var query = context.Products.Include(a => a.Medias).ToList();
            var lengthQuery = query.ToList().Count;
            return (query.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList(), lengthQuery);
        }

        public List<Product> GetChippestProduct()
        {
            List<Product> result = new List<Product>();
            foreach (var category in context.Categories.ToList())
            {
                int minPrice = context.Products.Include(a => a.Category).Where(a => a.Category == category)
                    .Min(a => a.Price);
                result.Add(context.Products.Include(a => a.Medias).First(a => a.Price == minPrice));

            }
            return result;
        }

        public (List<Product>, int Count) GetFilterProducts(string search, string category, int pageNumber, int PageSize)
        {
            IQueryable<Product> query = context.Products.Include(a => a.Category).Include(a => a.Medias);
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.Name.Contains(search) || a.Description.Contains(search));
            }
            if (category != "All")
            {
                query = query.Where(a => a.Category.CategoryName == category);

            }

            var lengthQuery = query.ToList().Count;

            return (query.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList(), lengthQuery);
        }

        public List<Product> GetNewstProduct()
        {
            return context.Products.Include(a => a.Medias)
               .OrderByDescending(a => a.InsertTime).ToList();
        }
        public (List<Product>, int Count) GetCategory(int Categoryid, int pageNumber, int PageSize)
        {
            var query = context.Products.Include(a => a.Medias).Where(a => a.Category.CategoryId == Categoryid).ToList();
            var lengthQuery = query.ToList().Count;
            return (query.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList(), lengthQuery);
        }
        public List<Product> GetProducts()
        {
            return context.Products.Include(a => a.Medias).ToList();
        }
        public int Create(Product product)
        {
            context.Products.Add(product);
            //context.SaveChanges();
            return product.ProductId;
        }
        public Product Update(Product product)
        {
            Product existingProduct = context.Products.Find(product.ProductId);
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.InsertTime = product.InsertTime;
            context.SaveChanges();
            return existingProduct;
        }
        public void Delete(int id)
        {
            var a = context.Products.Find(id);
            context.Products.Remove(a);
            context.SaveChanges();
        }

    }
}
