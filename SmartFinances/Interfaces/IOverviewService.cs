
using SmartFinances.Models.Overview;

namespace SmartFinances.Interfaces
{
    public interface IOverviewService
    {
        Task<OverviewVM> GenerateOverviewAsync();
        Task UpdateBalanceAsync(UpdateBalanceVM model);
        Task<UpdateBalanceVM> GetAccountAsync();
    }
}
