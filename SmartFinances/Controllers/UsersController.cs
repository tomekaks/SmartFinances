using Microsoft.AspNetCore.Mvc;
using SmartFinances.Interfaces;
using SmartFinances.Models.Users;

namespace SmartFinances.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _usersService = usersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _usersService.Register(model);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _usersService.Login(model);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {

            await _usersService.Logout();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> PersonalData()
        {
            var model = await _usersService.GetPersonalDataAsync(UserId);
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new ChangePasswordVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _usersService.ChangePasswordAsync(model, UserId);

            return RedirectToAction("Index", "Home");
        }
    }
}
