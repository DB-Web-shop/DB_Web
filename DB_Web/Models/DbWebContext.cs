using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB_Web.Models;

public partial class DbWebContext : DbContext
{
    public DbWebContext()
    {
    }

    public DbWebContext(DbContextOptions<DbWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookStatus> BookStatuses { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Configsweb> Configswebs { get; set; }

    public virtual DbSet<Discounttt> Discounttts { get; set; }

    public virtual DbSet<HistoryWeb> HistoryWebs { get; set; }

    public virtual DbSet<Methodpayment> Methodpayments { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Ordercart> Ordercarts { get; set; }

    public virtual DbSet<Roleu> Roleus { get; set; }

    public virtual DbSet<Tacgia> Tacgia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-MS5T3O4\\SQLEXPRESS;Initial Catalog=db_web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_account_ID");

            entity.ToTable("account", "db_web");

            entity.HasIndex(e => e.RoleId, "RoleID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Diachi).HasMaxLength(1000);
            entity.Property(e => e.Email).HasMaxLength(1000);
            entity.Property(e => e.Hoten).HasMaxLength(1000);
            entity.Property(e => e.Img).HasMaxLength(1000);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .HasColumnName("RoleID");
            entity.Property(e => e.TimeSignup).HasColumnType("date");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("account$account_ibfk_1");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_book_ID");

            entity.ToTable("book", "db_web");

            entity.HasIndex(e => e.CategoryId, "CategoryID");

            entity.HasIndex(e => e.StatusId, "statusID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Dinhdang).HasMaxLength(1000);
            entity.Property(e => e.Idtacgia).HasColumnName("IDTacgia");
            entity.Property(e => e.Image).HasMaxLength(1000);
            entity.Property(e => e.Mota).HasMaxLength(2000);
            entity.Property(e => e.Ngaythem).HasPrecision(0);
            entity.Property(e => e.StatusId).HasColumnName("statusID");
            entity.Property(e => e.Tensach).HasMaxLength(1000);

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("book$book_ibfk_1");

            entity.HasOne(d => d.IdtacgiaNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Idtacgia)
                .HasConstraintName("FK__book__IDTacgia__0E6E26BF");

            entity.HasOne(d => d.Status).WithMany(p => p.Books)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("book$book_ibfk_2");
        });

        modelBuilder.Entity<BookStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_book_status_ID");

            entity.ToTable("book_status", "db_web");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Mota).HasMaxLength(1000);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK_carts_AccountID");

            entity.ToTable("carts", "db_web");

            entity.HasIndex(e => e.AccountId, "AccountID_idx");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");
            entity.Property(e => e.Spvsl).HasColumnType("text");

            entity.HasOne(d => d.Account).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carts$AccountID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_category_ID");

            entity.ToTable("category", "db_web");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tenloai).HasMaxLength(1000);
        });

        modelBuilder.Entity<Configsweb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_configsweb_ID");

            entity.ToTable("configsweb", "db_web");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Banner1).HasMaxLength(1000);
            entity.Property(e => e.Banner2).HasMaxLength(1000);
            entity.Property(e => e.Banner3).HasMaxLength(1000);
            entity.Property(e => e.Banner4).HasMaxLength(1000);
            entity.Property(e => e.DiachiDuong).HasMaxLength(450);
            entity.Property(e => e.DiachiThanhpho).HasMaxLength(450);
            entity.Property(e => e.Email).HasMaxLength(450);
            entity.Property(e => e.Facebook).HasMaxLength(450);
            entity.Property(e => e.Instagram).HasMaxLength(450);
            entity.Property(e => e.Phone).HasMaxLength(14);
            entity.Property(e => e.Tenweb).HasMaxLength(405);
            entity.Property(e => e.Zalo).HasMaxLength(450);
        });

        modelBuilder.Entity<Discounttt>(entity =>
        {
            entity.HasKey(e => e.Magg).HasName("PK_discounttt_Magg");

            entity.ToTable("discounttt", "db_web");

            entity.Property(e => e.Magg).HasMaxLength(1000);
        });

        modelBuilder.Entity<HistoryWeb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_history_web_ID");

            entity.ToTable("history_web", "db_web");

            entity.HasIndex(e => e.AccountId, "AccountID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.ActionHis).HasMaxLength(1000);
            entity.Property(e => e.TimeHis).HasPrecision(0);

            entity.HasOne(d => d.Account).WithMany(p => p.HistoryWebs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("history_web$history_web_ibfk_1");
        });

        modelBuilder.Entity<Methodpayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_methodpayment_ID");

            entity.ToTable("methodpayment", "db_web");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NameMethod).HasMaxLength(450);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_order_detail_ID");

            entity.ToTable("order_detail", "db_web");

            entity.HasIndex(e => e.OrderId, "OrderID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.SachId).HasColumnName("SachID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("order_detail$order_detail_ibfk_1");

            entity.HasOne(d => d.Sach).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.SachId)
                .HasConstraintName("FK__order_det__SachI__14270015");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_order_status_ID");

            entity.ToTable("order_status", "db_web");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DesStatus)
                .HasMaxLength(1000)
                .HasColumnName("des_status");
        });

        modelBuilder.Entity<Ordercart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ordercart_ID");

            entity.ToTable("ordercart", "db_web");

            entity.HasIndex(e => e.AccountId, "AccountID");

            entity.HasIndex(e => e.Method, "Method_idx");

            entity.HasIndex(e => e.Stt, "Stt_idx");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Diachi).HasMaxLength(1000);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Hoten).HasMaxLength(450);
            entity.Property(e => e.Magg).HasMaxLength(1000);
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.Thoigian).HasPrecision(0);

            entity.HasOne(d => d.Account).WithMany(p => p.Ordercarts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ordercart$ordercart_ibfk_1");

            entity.HasOne(d => d.MaggNavigation).WithMany(p => p.Ordercarts)
                .HasForeignKey(d => d.Magg)
                .HasConstraintName("FK__ordercart__Magg__151B244E");

            entity.HasOne(d => d.MethodNavigation).WithMany(p => p.Ordercarts)
                .HasForeignKey(d => d.Method)
                .HasConstraintName("ordercart$Method");

            entity.HasOne(d => d.SttNavigation).WithMany(p => p.Ordercarts)
                .HasForeignKey(d => d.Stt)
                .HasConstraintName("ordercart$Stt");
        });

        modelBuilder.Entity<Roleu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_roleus_ID");

            entity.ToTable("roleus", "db_web");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("ID");
            entity.Property(e => e.Mota).HasMaxLength(1000);
            entity.Property(e => e.Rolename).HasMaxLength(1000);
        });

        modelBuilder.Entity<Tacgia>(entity =>
        {
            entity.ToTable("tacgia");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Mota).HasMaxLength(2000);
            entity.Property(e => e.TenTacGia).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
