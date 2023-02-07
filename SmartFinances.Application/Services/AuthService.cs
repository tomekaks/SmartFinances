using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartFinances.Application.CQRS.Account.Requests.Commands;
using SmartFinances.Application.Dto.Users;
using SmartFinances.Application.Interfaces.Services;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuthService(UserManager<ApplicationUser> userManager, IMapper mapper,
                           SignInManager<ApplicationUser> signInManager, IMediator mediator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _mediator = mediator;
        }

        public async Task ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId);

            await _userManager.ChangePasswordAsync(applicationUser, oldPassword, newPassword);
        }

        public async Task<UserDto> GetPersonalDataAsync(string userId)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId);

            return _mapper.Map<UserDto>(applicationUser);
        }

        public async Task Login(LoginDto loginDto)
        {
            await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            var user = _mapper.Map<ApplicationUser>(registerDto);
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return false;
            }

            await _userManager.AddToRoleAsync(user, "User");

            await _mediator.Send(new CreateAccountCommand { UserId = user.Id, AccountName = registerDto.UserName });    
            return true;
        }

    }
}
