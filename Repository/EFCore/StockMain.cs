using System;
using System.Collections.Generic;

namespace Repository.EFCore;

public  class StockMain
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
}
