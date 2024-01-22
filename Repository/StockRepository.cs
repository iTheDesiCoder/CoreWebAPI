using Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.EFCore;
using Repository.Interface;
using Microsoft.Extensions.Logging;

namespace Repository
{
    public class StockRepository : GenericRepository<StockMain>, IStockRepository
    {
        public StockRepository(TestdbContext context) : base(context)
        {
        }
    }
}
