using SmartFinances.Application.Dto.ExpenseDtos;

namespace SmartFinances.Models.BudgetPlanner
{
    public class ExpensesVM
    {
        public List<ExpenseDto> Expenses { get; set; }
        public decimal Budget { get; set; }
    }
}
