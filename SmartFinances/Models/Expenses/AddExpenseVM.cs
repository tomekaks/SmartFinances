using SmartFinances.Application.Dto.Enums;

namespace SmartFinances.Models.Expenses
{
    public class AddExpenseVM
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseTypeDto Type { get; set; }
    }
}
