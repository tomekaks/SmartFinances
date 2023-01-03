using SmartFinances.Models.Expenses;

namespace SmartFinances.Interfaces
{
    public interface IExpensesService
    {
        Task<ExpensesVM> GetExpensesListAsync();
        Task AddExpenseAsync(AddExpenseVM model);
    }
}
