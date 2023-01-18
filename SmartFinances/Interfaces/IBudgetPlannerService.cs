using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Models.BudgetPlanner;

namespace SmartFinances.Interfaces
{
    public interface IBudgetPlannerService
    {
        Task<ExpensesVM> GetExpensesListAsync(string userId);
        Task AddExpenseAsync(AddExpenseVM model, string userId);
        Task<AccountDto> GetAccountDtoAsync(string userId);
        Task<EditExpenseVM> GenerateEditExpenseVMAsync(int id);
        Task EditExpenseAsync(EditExpenseVM model, string userId);
        Task DeleteExpenseAsync(int id);
        Task<RegularExpensesVM> GetRegularExpensesListAsync(string userId);
        Task CreateRegularExpenseAsync(CreateRegularExpenseVM model, string userId);
        Task<EditExpenseVM> GenerateEditRegularExpenseVMAsync(int id);
        Task EditRegularExpenseAsync(EditExpenseVM model);
        Task DeleteRegularExpenseAsync(int id);
        Task AddRegularExpenseAsync(int id);
        Task<SetBudgetVM> GetBudgetAsync(string userId);
        Task SetBudget(SetBudgetVM model, string userId);
    }
}
