﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Interfaces;
using SmartFinances.Models.Overview;

namespace SmartFinances.Controllers
{
    [Authorize]
    public class OverviewController : BaseController
    {
        private readonly IOverviewService _overviewService;

        public OverviewController(IOverviewService overviewService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _overviewService = overviewService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _overviewService.GenerateOverviewAsync(UserId);
            return View(model);
        }

        public async Task<IActionResult> AddFunds()
        {
            //var model = await _overviewService.GetAccountAsync(UserId);
            var model = new AddFundsVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFunds(AddFundsVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _overviewService.AddFundsAsync(model, UserId);

            return RedirectToAction(nameof(Index));
        }
    }
}
