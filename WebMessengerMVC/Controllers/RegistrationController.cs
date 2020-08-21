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
        public RegistrationController(MessengerContext context)
        {
            _context = context;
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
                    var hashedPassword = new ASCIIEncoder().Encode(model.Password);

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
                
            } catch (Exception e)
            {
                return View("FailedRegistration" + e.Message);
            }
        }
    }
}
