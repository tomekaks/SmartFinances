﻿using SmartFinances.Models.Users;

namespace SmartFinances.Interfaces
{
    public interface IManageUserService
    {
        Task Login(LoginVM loginVM);
        Task Register(RegisterVM registerVM);
        Task Logout();
        Task<PersonalDataVM> GetPersonalDataAsync(string userId);
        Task ChangePasswordAsync(ChangePasswordVM model, string userId);
    }
}
