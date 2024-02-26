using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Core.Domain
{
    public class Order
    {
        public int OrderID { get; set; }

        public List<CartLine> Lines { get; set; }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PaymentNote { get; set; }
        public string ZipCode { get; set; }

        public string paymentToken { get; set; }
        public string PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
