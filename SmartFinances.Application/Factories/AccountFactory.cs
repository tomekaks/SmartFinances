using AutoMapper;
using SmartFinances.Application.Dto;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Factories
{
    public class AccountFactory : IAccountFactory
    {
        private readonly IMapper _mapper;

        public AccountFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Account CreateAccount(AccountDto accountDto)
        {
            return _mapper.Map<Account>(accountDto); 
        }

        public AccountDto CreateAccountDto(Account account)
        {
            return _mapper.Map<AccountDto>(account);
        }

        public Account MapToModel(AccountDto accountDto, Account model)
        {
           return _mapper.Map(accountDto, model);
        }
    }
}
