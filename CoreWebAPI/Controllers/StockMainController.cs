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

        public StockMainController(IStockRepository stockMainRepository)
        {
            _stockMainRepository = stockMainRepository;
        }

        [HttpGet(Name = "GetStockMain")]
        public async Task<IEnumerable<StockMain>> Get()
        {
            return await _stockMainRepository.GetAll();
        }
    }
}
