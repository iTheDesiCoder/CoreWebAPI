using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common;
using Repository.EFCore;

namespace Service.Interface
{
    public interface IStockService
    {
        Task<Response<StockMainDTO>> SaveStock(StockMainDTO stockMainDto);

        Task<Response<List<StockMainDTO>>> GetAll();
    }
}
