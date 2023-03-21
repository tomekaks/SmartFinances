using AutoMapper;
using SmartFinances.Application.Dto.Users;
using SmartFinances.Application.Interfaces.Services;
using SmartFinances.Interfaces;
using SmartFinances.Models.Administration;

namespace SmartFinances.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public AdminService(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        public async Task<UsersVM> GetAllUsers()
        {
            var users = await _usersService.GetAllUsersAsync();

            return new UsersVM { Users = users };
        }

        public async Task<UserDetailsVM> GetUserDetails(string userId)
        {
            var user = await _usersService.GetUserWithAccountsAsync(userId);

            return _mapper.Map<UserDetailsVM>(user);
        }

        public async Task<SuspendUserVM> GetUser(string userId)
        {
            var user = await _usersService.GetPersonalDataAsync(userId);

            return _mapper.Map<SuspendUserVM>(user);
        }

        public async Task SuspendUser(SuspendUserVM model)
        {
            var user = _mapper.Map<UsersStatusDto>(model);
            user.IsSuspended = true;
            await _usersService.UpdateUsersStatusAsync(user);
        }
    }
}
