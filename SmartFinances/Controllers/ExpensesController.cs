using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Interfaces;
using SmartFinances.Models.Expenses;

namespace SmartFinances.Controllers
{
    [Authorize]
    public class ExpensesController : BaseController
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _expensesService = expensesService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _expensesService.GetExpensesListAsync(UserId);
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

            await _expensesService.AddExpenseAsync(model, UserId);

            return RedirectToAction(nameof(Index));
        }
    }
}
