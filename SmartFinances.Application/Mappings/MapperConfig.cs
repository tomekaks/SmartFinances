using AutoMapper;
using SmartFinances.Application.Dto;
using SmartFinances.Application.Dto.Users;
using SmartFinances.Application.Dto.Enums;
using SmartFinances.Core.Data;
using SmartFinances.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>()
                .ForMember(src => src.Number, opt => opt.Ignore());

            CreateMap<ExpenseType, ExpenseTypeDto>().ReverseMap();

            CreateMap<Expense, ExpenseDto>().ReverseMap();

            CreateMap<ApplicationUser, RegisterDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();

        }
    }
}
