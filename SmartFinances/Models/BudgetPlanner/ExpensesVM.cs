using SmartFinances.Application.Dto.ExpenseDtos;

namespace SmartFinances.Models.BudgetPlanner
{
    public class ExpensesVM
    {
        public ExpensesVM(List<ExpenseDto> expenses, decimal budget)
        {
            Expenses = expenses;
            Budget = budget;
            GetTotalAmount();
        }

        public List<ExpenseDto> Expenses { get; set; }
        public decimal Budget { get; set; }
        public decimal TotalAmount { get; set; }

        private void GetTotalAmount()
        {
            foreach (var item in Expenses)
            {
                TotalAmount += item.Amount;
            }
        }
    }
}
