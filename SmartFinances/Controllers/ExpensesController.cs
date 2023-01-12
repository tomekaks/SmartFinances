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

        public async Task<IActionResult> EditExpense(int id)
        {
            var model = await _expensesService.GenerateEditExpenseVMAsync(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExpense(EditExpenseVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _expensesService.EditExpenseAsync(model, UserId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExpense(int id)
        {
 
            await _expensesService.DeleteExpenseAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
