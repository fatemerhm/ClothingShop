using ClothingShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Core.Contracts
{
    public interface IProductRepository
    {
        Product Get(int ProductId);
        (List<Product>, int Count) GetCategory(int Categoryid, int pageNumber, int PageSize);
        (List<Product>, int Count) GetAll(int pageNumber, int PageSize);
        (List<Product>, int Count) GetFilterProducts(string search, string category, int pageNumber, int PageSize);
        List<Product> GetProducts();
        List<Product> GetChippestProduct();
        List<Product> GetNewstProduct();
        int Create(Product product);
        Product Update(Product product);
        void Delete(int id);
    }
}
