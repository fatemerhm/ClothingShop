using ClothingShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Core.Contracts
{
    public interface IProdctFacade
    {
        Product Get(int ProductId);
        (List<Product>, int Count) GetCategory(int Categoryid, int pageNumber, int PageSize);
        (List<Product>, int Count) GetAll(int pageNumber, int PageSize);
        (List<Product>, int) ProductSearch(string q, string category, int pageNumber, int PageSize);

        List<Product> GetChippestProduct();
        List<Product> GetNewestProduct();
    }
}
