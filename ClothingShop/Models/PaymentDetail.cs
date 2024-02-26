namespace ClothingShop.Models
{
    public class PaymentDetail
    {
        public string track_id { get; set; }
        public decimal amount { get; set; }
        public string card_no { get; set; }
        public string hashed_card_no { get; set; }
        public double date { get; set; }
    }
}
