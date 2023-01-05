using Microsoft.AspNetCore.Mvc;
using SmartFinances.Models.Account;

namespace SmartFinances.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new RegisterVM();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var model = new LoginVM();
            return View(model);
        }
    }
}
