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



    public virtual DbSet<RuleEngineCategory> RuleEngineCategories { get; set; }

    public virtual DbSet<RuleEngineRule> RuleEngineRules { get; set; }

    public virtual DbSet<StockDetail> StockDetails { get; set; }


    public virtual DbSet<StockMain> StockMains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=RAKESH;Initial Catalog=TESTDB;Persist Security Info=True;User ID=sa;Password=admin123;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<RuleEngineCategory>(entity =>
        {
            entity.HasKey(e => e.RuleCatId).HasName("PK__RuleEngi__70201CF7BDADA468");

            entity.ToTable("RuleEngineCategory");

            entity.Property(e => e.RuleCatId).HasColumnName("RuleCatID");
            entity.Property(e => e.RuleCatAppId)
                .HasMaxLength(10)
                .HasColumnName("RuleCatAppID");
            entity.Property(e => e.RuleCatDesc).HasMaxLength(1000);
            entity.Property(e => e.RuleCatName).HasMaxLength(100);
        });

        modelBuilder.Entity<RuleEngineRule>(entity =>
        {
            entity.HasKey(e => e.RuleId).HasName("PK__RuleEngi__110458C2F0DC487F");

            entity.Property(e => e.RuleId).HasColumnName("RuleID");
            entity.Property(e => e.ErrorMessage).HasMaxLength(255);
            entity.Property(e => e.RuleCatId).HasColumnName("RuleCatID");
            entity.Property(e => e.RuleName).HasMaxLength(100);

            entity.HasOne(d => d.RuleCat).WithMany(p => p.RuleEngineRules)
                .HasForeignKey(d => d.RuleCatId)
                .HasConstraintName("FK__RuleEngin__RuleC__7755B73D");
        });

        modelBuilder.Entity<StockDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stock_Detail");

            entity.Property(e => e.AdjClose)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("Adj Close");
            entity.Property(e => e.Close).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.High).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.Low).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.Open).HasColumnType("decimal(18, 8)");
            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });


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
