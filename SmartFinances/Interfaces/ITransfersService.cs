using SmartFinances.Models.Transfers;

namespace SmartFinances.Interfaces
{
    public interface ITransfersService
    {
        Task<TransfersVM> GetTransfers(string userId);
        Task CreateNewTransfer(NewTransferVM model, string userId);
        Task<ContactsVM> GetContactList(string userId);
        Task CreateNewContact(NewContactVM model, string userId);
        Task<NewTransferVM> UseContact(int id);
        Task<EditContactVM> GetContact(int id);
        Task EditContact(EditContactVM model);
        Task DeleteContact(int id);
    }
}
