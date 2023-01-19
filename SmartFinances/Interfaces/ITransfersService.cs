using SmartFinances.Models.Transfers;

namespace SmartFinances.Interfaces
{
    public interface ITransfersService
    {
        Task<TransfersVM> GetTransfers(string userId);
        Task CreateNewTransfer(NewTransferVM model, string userId);
    }
}
