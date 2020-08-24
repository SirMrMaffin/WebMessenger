using Microsoft.AspNetCore.Mvc;
using System;
using WebMessengerMVC.Data;
using WebMessengerMVC.Encoders;
using WebMessengerMVC.Models;
using WebMessengerMVC.ViewModels;

namespace WebMessengerMVC.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly MessengerContext _context;
        private readonly PasswordHasher _hasher;

        public RegistrationController(MessengerContext context, PasswordHasher hasher)
        {
            _context = context;
            _hasher = hasher;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(RegisterUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hashedPassword = _hasher.Encode(model.Password);

                    _context.Users.Add(new User
                    {
                        Login = model.Login,
                        Password = hashedPassword,
                        Name = model.Name,
                        Surname = model.Surname,
                        DateOfBirth = model.DateOfBirth
                    });
                    _context.SaveChanges();

                    return View("SuccessfulRegistration");
                }
                else
                {
                    return View(model);
                }
                
            } catch
            {
                return View("FailedRegistration");
            }
        }
    }
}
