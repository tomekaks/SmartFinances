using Microsoft.AspNetCore.Mvc;
using SmartFinances.Interfaces;
using SmartFinances.Models.Overview;

namespace SmartFinances.Controllers
{
    public class OverviewController : Controller
    {
        private readonly IOverviewService _overviewService;

        public OverviewController(IOverviewService overviewService)
        {
            _overviewService = overviewService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _overviewService.GenerateOverviewAsync();
            return View(model);
        }

        public async Task<IActionResult> UpdateBalance()
        {
            var model = await _overviewService.GetAccountAsync();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBalance(UpdateBalanceVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _overviewService.UpdateBalanceAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
