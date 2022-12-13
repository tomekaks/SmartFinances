using Microsoft.AspNetCore.Mvc;
using SmartFinances.Models.Overview;

namespace SmartFinances.Controllers
{
    public class OverviewController : Controller
    {
        public IActionResult Index()
        {
            var model = new OverviewVM();
            return View(model);
        }

        public IActionResult AddBalance()
        {
            var model = new AddBalanceVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBalance(AddBalanceVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //TODO

            return RedirectToAction(nameof(Index));
        }
    }
}
