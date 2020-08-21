using Microsoft.AspNetCore.Mvc;

namespace WebMessengerMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
