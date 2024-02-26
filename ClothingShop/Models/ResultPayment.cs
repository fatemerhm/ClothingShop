namespace ClothingShop.Models
{
    public class ResultPayment
    {
        public int status { get; set; }
        public string track_id { get; set; }
        public string id { get; set; }
        public string order_id { get; set; }
        public decimal amount { get; set; }
        public string card_no { get; set; }
        public string hashed_card_no { get; set; }
        public double date { get; set; }


        public bool IsOK
        {
            get
            {
                return status == 10;
            }
        }
        public string Message
        {
            get
            {
                return GetStatus(status);
            }
        }
        private static string GetStatus(int status)
        {
            switch (status)
            {
                case 1: return "پرداخت انجام نشده است";
                case 2: return "پرداخت ناموفق بوده است";
                case 3: return "خطا رخ داده است";
                case 4: return "بلوکه شده";
                case 5: return "برگشت به پرداخت کننده";
                case 6: return "برگشت خورده سیستمی";
                case 10: return "در انتظار تایید پرداخت";
                case 100: return "پرداخت تایید شده است";
                case 101: return "پرداخت قبلا تایید شده است";
                case 200: return "به دریافت کننده واریز شد";
                default: return "";
            }
        }
    }
}
