using API.Controllers.Interface;
using AutoMapper;
using Common.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.EFCore;
using Service.Interface;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMainController : ControllerBase, IStockMainController
    {
        
        private readonly IStockService _stockService;
        public StockMainController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet(Name = "GetStockMain")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _stockService.GetAll());
        }

        [HttpPost(Name = "SaveStock")]
        public async Task<IActionResult> SaveStock(StockMainDTO stockDto)
        {
           return Ok(await _stockService.SaveStock(stockDto));
        }
    }
}
