using SmartFinances.Application.Dto.AccountDtos;

namespace SmartFinances.Models.Administration
{
    public class UserDetailsVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<AccountDto> Accounts { get; set; }
    }
}
