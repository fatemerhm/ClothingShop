namespace ClothingShop.Models
{
    public class FailedRequestRespons
    {
        public bool sucess { get => false; }
        public int error_code { get; set; }

        public string error_message { get; set; }
    }
}
