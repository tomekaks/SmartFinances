﻿using MediatR;
using SmartFinances.Application.Dto.AccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.CQRS.Account.Requests.Commands
{
    public class UpdateAccountCommand : IRequest
    {
        public UpdateAccountDto AccountDto { get; set; }
    }
}
