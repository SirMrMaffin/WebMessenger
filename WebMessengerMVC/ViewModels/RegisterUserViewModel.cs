using System;
using System.ComponentModel.DataAnnotations;

namespace WebMessengerMVC.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [MinLength(8), MaxLength(18)]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Repeated password doesn't match provided password. Please, type again!")]
        public string RepeatedPassword { get; set; }
        [Required]
        [MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MinLength(2), MaxLength(75)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}