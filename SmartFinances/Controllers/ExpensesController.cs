﻿using Microsoft.AspNetCore.Mvc;
using SmartFinances.Interfaces;
using SmartFinances.Models.Expenses;

namespace SmartFinances.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _expensesService.GetExpensesListAsync();
            return View(model);
        }

        public IActionResult AddExpense()
        {
            var model = new AddExpenseVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExpense(AddExpenseVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _expensesService.AddExpenseAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}