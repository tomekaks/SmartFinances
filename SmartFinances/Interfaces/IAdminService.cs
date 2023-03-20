﻿using SmartFinances.Application.Dto.Users;
using SmartFinances.Models.Administration;

namespace SmartFinances.Interfaces
{
    public interface IAdminService
    {
        Task<UsersVM> GetAllUsers();
        Task<UserDetailsVM> GetUserDetails(string userId);
        Task SuspendUser(string userId);

    }
}
