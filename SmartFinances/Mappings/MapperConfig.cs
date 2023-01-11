using AutoMapper;
using SmartFinances.Application.Dto;
using SmartFinances.Application.Dto.Users;
using SmartFinances.Models.Users;
using SmartFinances.Models.Expenses;
using SmartFinances.Models.Overview;

namespace SmartFinances.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AccountDto, OverviewVM>()
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Number)).ReverseMap();
            CreateMap<AccountDto, AddFundsVM>().ReverseMap();

            CreateMap<ExpenseDto, AddExpenseVM>().ReverseMap();

            CreateMap<RegisterDto, RegisterVM>().ReverseMap();

            CreateMap<LoginDto, LoginVM>().ReverseMap();
        }
    }
}
