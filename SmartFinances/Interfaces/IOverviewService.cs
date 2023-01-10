
using SmartFinances.Models.Overview;

namespace SmartFinances.Interfaces
{
    public interface IOverviewService
    {
        Task<OverviewVM> GenerateOverviewAsync(string userId);
        Task UpdateBalanceAsync(UpdateBalanceVM model);
        Task<UpdateBalanceVM> GetAccountAsync(string userId);
    }
}
