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
            await _mediator.Send(new CreateAccountCommand { UserId = user.Id });    
            return true;
        }
        private string GenerateAccountNumber()
        {
            var rand = new Random();
            var firstNumbers = rand.Next(10, 99).ToString();
            var secondNumbers = rand.Next(100000, 999999).ToString();
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var chars = new char[4];

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = alphabet[rand.Next(0, alphabet.Length - 1)];
            }

            string letters = new string(chars);

            return firstNumbers + letters + secondNumbers;
        }
    }
}
