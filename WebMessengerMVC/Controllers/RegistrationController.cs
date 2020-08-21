using Microsoft.AspNetCore.Mvc;
using System;
using WebMessengerMVC.Data;
using WebMessengerMVC.Encoders;
using WebMessengerMVC.Models;
using WebMessengerMVC.Validators;

namespace WebMessengerMVC.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly MessengerContext _context;
        public RegistrationController(MessengerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public string Index(string login, string password, string repeatedPassword, string name, string surname, DateTime dateOfBirth)
        {
            try
            {
                var hashedPassword = new ASCIIEncoder().Encode(password);
                var hashedRepeatPassword = new ASCIIEncoder().Encode(repeatedPassword);

                if (new PasswordValidator(hashedPassword, hashedRepeatPassword).Validate())
                {
                    _context.Users.Add(new User
                    {
                        Login = login,
                        Password = hashedPassword,
                        Name = name,
                        Surname = surname,
                        DateOfBirth = dateOfBirth
                    });
                    _context.SaveChanges();

                    return "Successfull registration";
                }
                else
                {
                    return "Failed registration\nCheck provided information";
                }
            } catch (Exception e)
            {
                return "An error occurred:\n" + e.Message;
            }
        }
    }
}
