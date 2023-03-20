using Microsoft.AspNetCore.Mvc;
using SmartFinances.Interfaces;
using SmartFinances.Models.Users;

namespace SmartFinances.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IManageUserService _manageUserService;

        public UsersController(IManageUserService usersService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _manageUserService = usersService;
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

            await _manageUserService.Register(model);

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

            await _manageUserService.Login(model);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {

            await _manageUserService.Logout();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> PersonalData()
        {
            var model = await _manageUserService.GetPersonalDataAsync(UserId);
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

            await _manageUserService.ChangePasswordAsync(model, UserId);

            return RedirectToAction("Index", "Home");
        }
    }
}
