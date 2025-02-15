using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyWalletApi.Models;

public partial class TompkinsContext : DbContext
{
    public TompkinsContext()
    {
    }

    public TompkinsContext(DbContextOptions<TompkinsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Payee> Payees { get; set; }

    public virtual DbSet<Trx> Trxes { get; set; }

    public virtual DbSet<TrxImport> TrxImports { get; set; }

    public virtual DbSet<TrxSplit> TrxSplits { get; set; }

    public virtual DbSet<VwIncome> VwIncomes { get; set; }

    public virtual DbSet<VwSpending> VwSpendings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:tompkinssqlserver.database.windows.net,1433;Initial Catalog=Tompkins;Persist Security Info=False;User ID=tompkinsadmin;Password=Porch.10.Leash;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK_Account_AccountID");

            entity.ToTable("Account", "Wallet");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.ImportFilePath)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_Category_TransactionCategoryID");

            entity.ToTable("Category", "Wallet");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryParentId).HasColumnName("CategoryParentID");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Payee>(entity =>
        {
            entity.HasKey(e => e.PayeeId).HasName("PK_Payee_PayeeID");

            entity.ToTable("Payee", "Wallet");

            entity.HasIndex(e => e.Name, "UQ_Payee_Name").IsUnique();

            entity.Property(e => e.PayeeId).HasColumnName("PayeeID");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PayeeParentId).HasColumnName("PayeeParentID");
        });

        modelBuilder.Entity<Trx>(entity =>
        {
            entity.HasKey(e => e.TrxId).HasName("PK_Trx_TrxID");

            entity.ToTable("Trx", "Wallet");

            entity.Property(e => e.TrxId).HasColumnName("TrxID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Amount).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.PayeeId).HasColumnName("PayeeID");
            entity.Property(e => e.PostDate).HasColumnType("datetime");
            entity.Property(e => e.TrxDate).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TrxImport>(entity =>
        {
            entity.HasKey(e => e.TrxId).HasName("PK_TrxImport_TrxID");

            entity.ToTable("TrxImport", "Wallet");

            entity.Property(e => e.TrxId).HasColumnName("TrxID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Amount).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.PayeeId).HasColumnName("PayeeID");
            entity.Property(e => e.PostDate).HasColumnType("datetime");
            entity.Property(e => e.TrxDate).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.RecordDate).HasColumnType("datetime");
            entity.Property(e => e.ProcessedDate).HasColumnType("datetime");
            entity.Property(e => e.Imported).HasColumnName("Imported");
        });

        modelBuilder.Entity<TrxSplit>(entity =>
        {
            entity.HasKey(e => e.SplitId).HasName("PK_TrxSplit_SplitID");

            entity.ToTable("TrxSplit", "Wallet");

            entity.Property(e => e.SplitId).HasColumnName("SplitID");
            entity.Property(e => e.Amount).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Memo)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TrxId).HasColumnName("TrxID");
        });

        modelBuilder.Entity<VwIncome>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwIncome", "Wallet");

            entity.Property(e => e.Account)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Amount).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Category)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategorySub)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.CategorySubId).HasColumnName("CategorySubID");
            entity.Property(e => e.Memo)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Payee)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PayeeId).HasColumnName("PayeeID");
            entity.Property(e => e.TrxDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwSpending>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwSpending", "Wallet");

            entity.Property(e => e.Account)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Amount).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategorySubName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.CategoryFullName)
                .HasMaxLength(128)
                .IsUnicode(false);
            //entity.Property(e => e.CategorySubId).HasColumnName("CategorySubID");
            entity.Property(e => e.CategoryParentId).HasColumnName("CategoryParentID");
            entity.Property(e => e.Memo)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Payee)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PayeeId).HasColumnName("PayeeID");
            entity.Property(e => e.TrxDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
