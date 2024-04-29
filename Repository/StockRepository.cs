using Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Dto;
using Repository.EFCore;
using Repository.Interface;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace Repository
{
    public class StockRepository : GenericRepository<StockMain>, IStockRepository
    {
        private readonly IMapper _mapper;

        public StockRepository(TestdbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<Response<List<StockMainDTO>>> GetStock()
        {
           var StockMainDTOList =   _mapper.Map<IEnumerable<StockMainDTO>>(await GetAll()).ToList();
           return new Response<List<StockMainDTO>> { Data = StockMainDTOList };
        }


        public async Task<Response<StockMainDTO>> SaveStock(StockMainDTO StockDto)
        {
            return new Response<StockMainDTO>();
        }
    }
}
