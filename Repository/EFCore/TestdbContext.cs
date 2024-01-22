using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.EFCore;

public partial class TestdbContext : DbContext
{
    public TestdbContext()
    {
    }

    public TestdbContext(DbContextOptions<TestdbContext> options)
        : base(options)
    {
    }

   

    public virtual DbSet<StockMain> StockMains { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<StockMain>(entity =>
        {
            entity.HasKey(e => e.Symbol).HasName("PK__StockMai__B7CC3F007C0C3333");

            entity.ToTable("StockMain");

            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CqsSymbol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CQS_Symbol");
            entity.Property(e => e.Etf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ETF");
            entity.Property(e => e.FinancialStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Financial_Status");
            entity.Property(e => e.ListingExchange)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Listing_Exchange");
            entity.Property(e => e.MarketCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Market_Category");
            entity.Property(e => e.NasdaqSymbol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NASDAQ_Symbol");
            entity.Property(e => e.NasdaqTraded)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Nasdaq_Traded");
            entity.Property(e => e.NextShares)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoundLotSize).HasColumnName("Round_Lot_Size");
            entity.Property(e => e.SecurityName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("Security_Name");
            entity.Property(e => e.TestIssue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Test_Issue");
        });
        modelBuilder.HasSequence("BATCH_JOB_EXECUTION_SEQ")
            .StartsAt(0L)
            .HasMin(0L);
        modelBuilder.HasSequence("BATCH_JOB_SEQ")
            .StartsAt(0L)
            .HasMin(0L);
        modelBuilder.HasSequence("BATCH_STEP_EXECUTION_SEQ")
            .StartsAt(0L)
            .HasMin(0L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
