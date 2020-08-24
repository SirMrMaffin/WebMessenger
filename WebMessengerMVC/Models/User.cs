using System;
using System.ComponentModel.DataAnnotations;

namespace WebMessengerMVC.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(8), MaxLength(18)]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
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
