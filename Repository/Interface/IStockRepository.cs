﻿using Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.EFCore;

namespace Repository.Interface
{
    public interface IStockRepository : IGenericRepository<StockMain>
    {

    }
}
