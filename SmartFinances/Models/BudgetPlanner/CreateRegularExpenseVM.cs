using SmartFinances.Application.Dto.Enums;

namespace SmartFinances.Models.BudgetPlanner
{
    public class CreateRegularExpenseVM
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseTypeDto Type { get; set; }
    }
}
