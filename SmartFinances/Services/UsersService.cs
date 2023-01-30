using AutoMapper;
using SmartFinances.Application.Dto.Users;
using SmartFinances.Application.Interfaces.Services;
using SmartFinances.Interfaces;
using SmartFinances.Models.Users;
using System.Security.Claims;

namespace SmartFinances.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public UsersService(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        public async Task ChangePasswordAsync(ChangePasswordVM model, string userId)
        {
            await _authService.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);
        }

        public async Task<PersonalDataVM> GetPersonalDataAsync(string userId)
        {
            var userDto = await _authService.GetPersonalDataAsync(userId);
            return _mapper.Map<PersonalDataVM>(userDto);
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
