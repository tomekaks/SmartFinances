using AutoMapper;
using SmartFinances.Application.Dto.Account;
using SmartFinances.Application.Interfaces.Services;
using SmartFinances.Interfaces;
using SmartFinances.Models.Account;

namespace SmartFinances.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AccountService(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        public async Task Login(LoginVM loginVM)
        {
            var user = _mapper.Map<LoginDto>(loginVM);
            await _authService.Login(user);
        }

        public async Task Logout()
        {
            await _authService.Logout();
        }

        public async Task Register(RegisterVM registerVM)
        {
            var newUser = _mapper.Map<RegisterDto>(registerVM);
            await _authService.Register(newUser);
        }
    }
}
