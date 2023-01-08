using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SmartFinances.Application.Dto.Account;
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

        public AuthService(UserManager<ApplicationUser> userManager, IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(loginDto);
            await _signInManager.SignInAsync(applicationUser, isPersistent: false);

            return _mapper.Map<UserDto>(applicationUser);
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            var user = _mapper.Map<ApplicationUser>(registerDto);
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return false;
            }
                
            return true;
        }
    }
}
