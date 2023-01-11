using SmartFinances.Application.Dto;
using SmartFinances.Models.Expenses;

namespace SmartFinances.Interfaces
{
    public interface IExpensesService
    {
        Task<ExpensesVM> GetExpensesListAsync(string userId);
        Task AddExpenseAsync(AddExpenseVM model, string userId);
        Task<AccountDto> GetAccountDtoAsync(string userId);
    }
}
