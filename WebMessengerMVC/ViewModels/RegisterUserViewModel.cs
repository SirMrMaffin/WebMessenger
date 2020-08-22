﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebMessengerMVC.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Repeated password doesn't match, type again !")]
        public string RepeatedPassword { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}