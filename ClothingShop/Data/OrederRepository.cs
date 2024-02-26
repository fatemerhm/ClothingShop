using ClothingShop.Core.Contracts;
using ClothingShop.Core.Domain;

namespace ClothingShop.Data
{
    public class OrederRepository: IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrederRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void PaymentDone(string token, string tId)
        {
            try
            {
                var order = context.Orders.Where(c => c.paymentToken == token.ToString()).First();
                order.PaymentDate = DateTime.Now;
                order.PaymentId = tId.ToString();

                context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Save(Order order)
        {
            context.AttachRange(order.Lines.Select(a => a.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }

        public void SetOrderToken(int orderId, string token)
        {
            try
            {
                var order = context.Orders.Find(orderId);
                order.paymentToken = token;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
