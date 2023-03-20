﻿using SmartFinances.Application.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task Login(LoginDto loginDto);
        Task<bool> Register(RegisterDto registerDto);
        Task Logout();
        
    }
}
