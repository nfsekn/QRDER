using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project__.Models.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminGirisi> AdminGirisis { get; set; }

    public virtual DbSet<AnaYemek> AnaYemeks { get; set; }

    public virtual DbSet<AraYemek> AraYemeks { get; set; }

    public virtual DbSet<Icecekler> Iceceklers { get; set; }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    public virtual DbSet<QrVerisi> QrVerisis { get; set; }

    public virtual DbSet<Tatlilar> Tatlilars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:sqlqrder.database.windows.net,1433;Initial Catalog=QRDER;Persist Security Info=False;User ID=G10;Password=QrDeR_123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Turkish_CI_AS");

        modelBuilder.Entity<AdminGirisi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Admin_Girisi");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.KullaniciAdi)
                .HasMaxLength(20)
                .HasColumnName("Kullanici_Adi");
            entity.Property(e => e.Sifre)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<AnaYemek>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Ana_Yemek");

            entity.Property(e => e.AnaYemek1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Ana_Yemek");
            entity.Property(e => e.AnaYemekFiyat)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Ana_Yemek_Fiyat");
            entity.Property(e => e.AnaYemekGorsel).HasColumnName("Ana_Yemek_Gorsel");
            entity.Property(e => e.AnaYemekId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Ana_Yemek_ID");
        });

        modelBuilder.Entity<AraYemek>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Ara_Yemek");

            entity.Property(e => e.AraYemek1)
                .HasMaxLength(50)
                .HasColumnName("Ara_Yemek");
            entity.Property(e => e.AraYemekFiyat)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Ara_Yemek_Fiyat");
            entity.Property(e => e.AraYemekGorsel).HasColumnName("Ara_Yemek_Gorsel");
            entity.Property(e => e.AraYemekId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Ara_Yemek_ID");
        });

        modelBuilder.Entity<Icecekler>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Icecekler");

            entity.Property(e => e.Icecekler1)
                .HasMaxLength(50)
                .HasColumnName("Icecekler");
            entity.Property(e => e.IceceklerFiyat)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Icecekler_Fiyat");
            entity.Property(e => e.IceceklerGorsel).HasColumnName("Icecekler_Gorsel");
            entity.Property(e => e.İcecekId)
                .ValueGeneratedOnAdd()
                .HasColumnName("İcecek_ID");
        });

        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriId);

            entity.ToTable("Kategoriler");

            entity.Property(e => e.KategoriId).HasColumnName("Kategori_ID");
            entity.Property(e => e.KategoriAdi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Kategori_Adi");
            entity.Property(e => e.KategoriGorsel).HasColumnName("Kategori_Gorsel");
        });

        modelBuilder.Entity<QrVerisi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_QRVerisi");

            entity.ToTable("Qr_Verisi");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Numara)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Qrresim).HasColumnName("QRResim");
        });

        modelBuilder.Entity<Tatlilar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tatlilar");

            entity.Property(e => e.Tatlilar1)
                .HasMaxLength(50)
                .HasColumnName("Tatlilar");
            entity.Property(e => e.TatlilarFiyat)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Tatlilar_Fiyat");
            entity.Property(e => e.TatlilarGorsel).HasColumnName("Tatlilar_Gorsel");
            entity.Property(e => e.TatlilarId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Tatlilar_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
