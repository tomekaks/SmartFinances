using AutoMapper;
using SmartFinances.Application.Dto.Users;
using SmartFinances.Application.Interfaces.Services;
using SmartFinances.Interfaces;
using SmartFinances.Models.Users;
using System.Security.Claims;

namespace SmartFinances.Services
{
    public class ManageUserService : IManageUserService
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IUsersService _usersService;

        public ManageUserService(IMapper mapper, IAuthService authService, IUsersService usersService)
        {
            _mapper = mapper;
            _authService = authService;
            _usersService = usersService;
        }

        public async Task ChangePasswordAsync(ChangePasswordVM model, string userId)
        {
            await _usersService.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);
        }

        public async Task<PersonalDataVM> GetPersonalDataAsync(string userId)
        {
            var userDto = await _usersService.GetPersonalDataAsync(userId);
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
