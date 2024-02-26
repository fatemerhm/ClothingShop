using ClothingShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Core.Contracts
{
    public interface IOrderRepository
    {
        void Save(Order order);
        void SetOrderToken(int orderId, string token);
        void PaymentDone(string token, string tId);
    }
}
