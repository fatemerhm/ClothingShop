namespace ClothingShop.Models
{
    public class PaymentRequestModel
    {
        private string OrderID;
        public string order_id
        {
            get
            {
                return OrderID;
            }
        }
        public decimal amount { get; set; }

        public string callback
        {
            get
            {
                return "http://localhost:59373/Payment/Verify";
            }
        }

        public PaymentRequestModel(string _OrderID)
        {
            if (string.IsNullOrEmpty(_OrderID))
                OrderID = Guid.NewGuid().ToString();
            else
                OrderID = _OrderID;
        }
    }
}
