using System.ComponentModel.DataAnnotations;

namespace src.Models.Users 
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "username is required")]
        public string User { get; set; }
        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }
    }
}