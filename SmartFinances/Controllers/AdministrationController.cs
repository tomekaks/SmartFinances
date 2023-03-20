using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Interfaces;

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
    }
}
