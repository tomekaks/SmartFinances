using SmartFinances.Application.Dto;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Interfaces.Factories
{
    public interface IAccountFactory
    {
        Account CreateAccount(AccountDto accountDto);
        AccountDto CreateAccountDto(Account account);
        Account MapToModel(AccountDto accountDto, Account model);
    }
}
