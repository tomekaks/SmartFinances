using SmartFinances.Models.Transfers;

namespace SmartFinances.Interfaces
{
    public interface ITransfersService
    {
        Task<TransfersVM> GetTransfers();
    }
}
