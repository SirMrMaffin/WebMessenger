using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebMessengerMVC.Data;
using WebMessengerMVC.Encoders;
using WebMessengerMVC.Validators;
using WebMessengerMVC.ViewModels;

namespace WebMessengerMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly MessengerContext _context;
        public LoginController(MessengerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hashedPassword = new ASCIIEncoder().Encode(model.Password);
                    var user = _context.Users.Single(x => x.Login == model.Login);

                    if (new PasswordValidator(hashedPassword, user.Password).Validate())
                    {
                        ViewBag.UserName = user.Name;
                        return View("SuccessfulLogin");
                    }
                    else
                    {
                        return View("FailedLogin");
                    }
                }
                else
                {
                    return View(model);
                }
            } catch (Exception e)
            {
                return View("FailedLogin" + e.Message);
            }
        }
    }
}
