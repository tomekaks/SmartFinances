using SmartFinances.Application.Dto.Enums;
using System.ComponentModel;

namespace SmartFinances.Models.BudgetPlanner
{
    public class AddExpenseVM
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public ExpenseTypeDto Type { get; set; }
        [DisplayName("Regular expense")]
        public bool IsRegular { get; set; }
    }
}
