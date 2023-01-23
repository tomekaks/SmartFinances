using AutoMapper;
using SmartFinances.Application.Dto.Users;
using SmartFinances.Models.Users;
using SmartFinances.Models.BudgetPlanner;
using SmartFinances.Models.Overview;
using SmartFinances.Application.Dto.ExpenseDtos;
using SmartFinances.Application.Dto.AccountDtos;
using SmartFinances.Application.Dto.RegularExpenseDtos;
using SmartFinances.Application.Dto.TransferDtos;
using SmartFinances.Models.Transfers;

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
            CreateMap<ExpenseDto, EditExpenseVM>().ReverseMap();
            CreateMap<EditExpenseDto, EditExpenseVM>().ReverseMap();

            CreateMap<RegularExpenseDto, CreateRegularExpenseVM>().ReverseMap();
            CreateMap<RegularExpenseDto, EditExpenseVM>().ReverseMap();
            CreateMap<RegularExpenseDto, ExpenseDto>()
                .ForMember(src => src.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<RegisterDto, RegisterVM>().ReverseMap();

            CreateMap<LoginDto, LoginVM>().ReverseMap();

            CreateMap<OutgoingTransferDto, NewTransferVM>().ReverseMap();
        }
    }
}
