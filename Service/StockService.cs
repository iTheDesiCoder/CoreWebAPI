using Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Dto;
using Common;
using Service.Interface;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Linq.Dynamic.Core;

namespace Service
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IValidatorService<StockMainDTO> _validatorService;

        public StockService(IStockRepository stockRepository, IValidatorService<StockMainDTO> validatorService)
        {
            _stockRepository = stockRepository;
            _validatorService = validatorService;
        }
        public async Task<Response<List<StockMainDTO>>> GetAll()
        {
            return await _stockRepository.GetStock();
        }

        public async Task<Response<StockMainDTO>> SaveStock(StockMainDTO stockMainDto)
        {
            var failedRules = await _validatorService.Validate(stockMainDto);
            if (failedRules.Count > 0)
            {
                return new Response<StockMainDTO>
                {
                    Data = null,
                    Message = "Validation Failed",
                    Success = false
                };
            }
            else
            {
                return await _stockRepository.SaveStock(stockMainDto);
            }
        }
    }
}
