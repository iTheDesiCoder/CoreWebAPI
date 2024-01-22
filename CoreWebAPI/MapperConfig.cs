using AutoMapper;
using Entity;
using Repository.EFCore;

namespace CoreWebAPI
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<StockMain, StockMainDTO>().ReverseMap();
        }
    }
}
