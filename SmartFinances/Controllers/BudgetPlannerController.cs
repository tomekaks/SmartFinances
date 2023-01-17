using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartFinances.Interfaces;
using SmartFinances.Models.BudgetPlanner;

namespace SmartFinances.Controllers
{
    [Authorize]
    public class BudgetPlannerController : BaseController
    {
        private readonly IBudgetPlannerService _budgetPlannerService;

        public BudgetPlannerController(IBudgetPlannerService budgetPlannerService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _budgetPlannerService = budgetPlannerService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _budgetPlannerService.GetExpensesListAsync(UserId);
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

            await _budgetPlannerService.AddExpenseAsync(model, UserId);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditExpense(int id)
        {
            var model = await _budgetPlannerService.GenerateEditExpenseVMAsync(id);
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

            await _budgetPlannerService.EditExpenseAsync(model, UserId);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExpense(int id)
        {
 
            await _budgetPlannerService.DeleteExpenseAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ViewRegularExpenses()
        {
            var model = await _budgetPlannerService.GetRegularExpensesListAsync(UserId);
            return View(model);
        }

        public IActionResult CreateRegularExpense()
        {
            var model = new CreateRegularExpenseVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRegularExpense(CreateRegularExpenseVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _budgetPlannerService.CreateRegularExpenseAsync(model, UserId);

            return RedirectToAction(nameof(ViewRegularExpenses));
        }

        public async Task<IActionResult> EditRegularExpense(int id)
        {
            var model = await _budgetPlannerService.GenerateEditRegularExpenseVMAsync(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRegularExpense(EditExpenseVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _budgetPlannerService.EditRegularExpenseAsync(model);

            return RedirectToAction(nameof(ViewRegularExpenses));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRegularExpense(int id)
        {
            await _budgetPlannerService.DeleteRegularExpenseAsync(id);

            return RedirectToAction(nameof(ViewRegularExpenses));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRegularExpense(int id)
        {
            await _budgetPlannerService.AddRegularExpenseAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SetBudget()
        {
            var model = new SetBudgetVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetBudget(SetBudgetVM model)
        {
            await _budgetPlannerService.SetBudget(model, UserId);

            return RedirectToAction(nameof(Index));
        }
    }
}
