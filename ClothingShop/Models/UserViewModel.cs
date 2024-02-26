using System.ComponentModel.DataAnnotations;

namespace ClothingShop.Models
{
    public class UserViewModel
    {
        //public string Id { get; set; }
       
        public string Name { get; set; }
       
        public string Lastname { get; set; }
      
        public string Email { get; set; }
      
        public string Username { get; set; }
      
        public string Password { get; set; }

        public string Repassword { get; set; }
    }
}
