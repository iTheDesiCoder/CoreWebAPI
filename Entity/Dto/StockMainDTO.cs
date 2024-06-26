﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class StockMainDTO
    {
        public string? NasdaqTraded { get; set; }

        public string Symbol { get; set; } = null!;

        public string? SecurityName { get; set; }

        public string? ListingExchange { get; set; }

        public string? MarketCategory { get; set; }

        public string? Etf { get; set; }

        public int? RoundLotSize { get; set; }

        public string? TestIssue { get; set; }

        public string? FinancialStatus { get; set; }

        public string? CqsSymbol { get; set; }

        public string? NasdaqSymbol { get; set; }

        public string? NextShares { get; set; }

        public StockMainSub StockMainSub { get; set; }
    }

    public class StockMainSub
    {
        public int Price { get; set; }
        public List<string> Names { get; set; }
    }
}
