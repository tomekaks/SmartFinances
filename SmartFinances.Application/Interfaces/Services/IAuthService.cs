using SmartFinances.Application.Dto.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserDto> Login(LoginDto loginDto);
        Task<bool> Register(RegisterDto registerDto);
    }
}
