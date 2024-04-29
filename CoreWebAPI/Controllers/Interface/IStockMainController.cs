using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Interface
{
    public interface IStockMainController
    {
        Task<IActionResult> Get();
        Task<IActionResult> SaveStock(StockMainDTO stockDto);
    }
}
