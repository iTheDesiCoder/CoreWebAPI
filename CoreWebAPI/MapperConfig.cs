using AutoMapper;
using Common.Dto;
using Repository.EFCore;

namespace API
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<StockMain, StockMainDTO>().ReverseMap();
            CreateMap<RuleEngineRule, RulesDto>().ReverseMap();
        }
    }
}
