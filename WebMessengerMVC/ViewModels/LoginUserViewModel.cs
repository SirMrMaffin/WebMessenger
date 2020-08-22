using System.ComponentModel.DataAnnotations;

namespace WebMessengerMVC.ViewModels
{
    public class LoginUserViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Repeated password doesn't match, type again !")]
        public string RepeatedPassword { get; set; }
    }
}
