using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Core.ApplicationService
{
    public class ProductFacade : IProdctFacade
    {
        private readonly IProductRepository productRepository;

        public ProductFacade(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Product Get(int ProductId)
        {
            return productRepository.Get(ProductId);
        }

        public (List<Product>, int Count) GetAll(int pageNumber, int PageSize)
        {
            return productRepository.GetAll(pageNumber, PageSize);
        }

        public List<Product> GetChippestProduct()
        {
            return productRepository.GetChippestProduct()
               .Take(4).ToList();
        }
        public List<Product> GetNewestProduct()
        {
            return productRepository.GetNewstProduct();
        }

        public (List<Product>, int) ProductSearch(string q, string category, int pageNumber, int PageSize)
        {
            return productRepository.GetFilterProducts(q, category, pageNumber, PageSize);
        }
        public (List<Product>, int) GetCategory(int Categoryid, int pageNumber, int PageSize)
        {
            return productRepository.GetCategory(Categoryid, pageNumber, PageSize);
        }
    }
}
