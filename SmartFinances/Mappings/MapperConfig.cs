using AutoMapper;
using SmartFinances.Application.Dto;
using SmartFinances.Models.Overview;

namespace SmartFinances.Mappings
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AccountDto, OverviewVM>()
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Number)).ReverseMap();
            CreateMap<AccountDto, AddBalanceVM>().ReverseMap();
        }
    }
}
