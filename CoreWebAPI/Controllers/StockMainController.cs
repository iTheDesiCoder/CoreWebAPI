using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.EFCore;
using Repository.Interface;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMainController : ControllerBase
    {
        
        private readonly IStockRepository _stockMainRepository;
        private readonly IMapper _mapper;

        public StockMainController(IStockRepository stockMainRepository,IMapper mapper)
        {
            _stockMainRepository = stockMainRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetStockMain")]
        public async Task<IEnumerable<StockMainDTO>> Get()
        {
            throw new Exception("Testing");
            return  _mapper.Map<IEnumerable<StockMainDTO>>(await _stockMainRepository.GetAll());
        }
    }
}
