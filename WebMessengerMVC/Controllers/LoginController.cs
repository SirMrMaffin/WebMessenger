using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hashedPassword = new ASCIIEncoder().Encode(model.Password);
                    var user = _context.Users.Single(x => x.Login == model.Login);

                    if (new PasswordValidator(hashedPassword, user.Password).Validate())
                    {
                        await Authenticate(model.Login); // аутентификация
                        ViewBag.UserName = user.Name;

                        return RedirectToAction("Index", "Home");
                    }
                }

                return View(model);
            }
            catch (Exception e)
            {
                return View("FailedLogin" + e.Message);
            }
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
