using SmartFinances.Models.Account;

namespace SmartFinances.Interfaces
{
    public interface IAccountService
    {
        Task Login(LoginVM loginVM);
        Task Register(RegisterVM registerVM);
    }
}
