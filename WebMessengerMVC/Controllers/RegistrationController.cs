using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == model.Login);

            if (user == null)
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

                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect password");
                }
            }

            return View(model);
        }
    }
}
