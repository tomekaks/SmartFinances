using SmartFinances.Models.Users;

namespace SmartFinances.Interfaces
{
    public interface IUsersService
    {
        Task Login(LoginVM loginVM);
        Task Register(RegisterVM registerVM);
        Task Logout();
    }
}
