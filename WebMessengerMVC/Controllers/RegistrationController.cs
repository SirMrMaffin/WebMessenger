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
        private readonly PasswordHasher _encoder;

        public RegistrationController(MessengerContext context, PasswordHasher encoder)
        {
            _context = context;
            _encoder = encoder;
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
                    var hashedPassword = _encoder.Encode(model.Password);

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
