using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Interfaces;
using SmartFinances.Models.Administration;

namespace SmartFinances.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {
        private readonly IAdminService _adminService;

        public AdministrationController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _adminService.GetAllUsers();

            return View(model);
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            var model = await _adminService.GetUserDetails(id);

            return View(model);
        }


        public async Task<IActionResult> SuspendUser(string id)
        {
            var model = await _adminService.GetUser(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuspendUser(SuspendUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _adminService.SuspendUser(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnSuspendUser(string id)
        {

            await _adminService.UnSuspendUser(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
