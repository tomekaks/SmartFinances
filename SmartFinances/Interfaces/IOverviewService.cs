using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Models.Overview;

namespace SmartFinances.Interfaces
{
    public interface IOverviewService
    {
        Task<OverviewVM> GenerateOverviewAsync(string userId);
        Task<AddFundsVM> GenerateAddFundsViewAsync(string userId);
        Task AddFundsAsync(AddFundsVM model, string userId);
        Task<AccountDto> GetAccountAsync(string userId);
    }
}
