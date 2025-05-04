using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QRDER.Models.Entity
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnaYemek> AnaYemeks { get; set; }
        public virtual DbSet<AraYemek> AraYemeks { get; set; }
        public virtual DbSet<Kategoriler> Kategorilers { get; set; }
        public virtual DbSet<Qrverisi> Qrverisis { get; set; }
        public virtual DbSet<Tatlılar> Tatlılars { get; set; }
        public virtual DbSet<Tercihler> Tercihlers { get; set; }
        public virtual DbSet<İçecekler> İçeceklers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:sqlqrder.database.windows.net,1433;Initial Catalog=QRDER;Persist Security Info=False;User ID=G10;Password=QrDeR_123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnaYemek>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ana_Yemek");

                entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MenuKategori).HasColumnName("Menu_Kategori");

                entity.Property(e => e.TercihAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AraYemek>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ara_Yemek");

                entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.KategoriId).HasColumnName("Kategori_ID");

                entity.Property(e => e.MenuKategoriId).HasColumnName("Menu_Kategori_ID");

                entity.Property(e => e.TercihAdi)
                    .HasMaxLength(50)
                    .HasColumnName("Tercih_Adi");
            });

            modelBuilder.Entity<Kategoriler>(entity =>
            {
                entity.ToTable("Kategoriler");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KategoriAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Qrverisi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("QRVerisi");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Numara)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qrresim).HasColumnName("QRResim");
            });

            modelBuilder.Entity<Tatlılar>(entity =>
            {
                entity.HasKey(e => e.IdMenuKategori);

                entity.ToTable("Tatlılar");

                entity.Property(e => e.IdMenuKategori)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Menu_Kategori");

                entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IdKategori).HasColumnName("ID_Kategori");

                entity.Property(e => e.TercihAdi)
                    .HasMaxLength(50)
                    .HasColumnName("Tercih_Adi");
            });

            modelBuilder.Entity<Tercihler>(entity =>
            {
                entity.ToTable("Tercihler");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.MenuAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Tercihlers)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK__Menuler__Kategor__173876EA");
            });

            modelBuilder.Entity<İçecekler>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("İçecekler");

                entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IdKategori).HasColumnName("ID_Kategori");

                entity.Property(e => e.IdMenuKategori).HasColumnName("ID_Menu_Kategori");

                entity.Property(e => e.Tercihler).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
