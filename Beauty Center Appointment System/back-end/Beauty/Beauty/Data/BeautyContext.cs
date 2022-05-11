using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Beauty.Data
{
    public partial class BeautyContext : DbContext
    {
        public BeautyContext()
        {
        }

        public BeautyContext(DbContextOptions<BeautyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calisan> Calisans { get; set; } = null!;
        public virtual DbSet<Hizmet> Hizmets { get; set; } = null!;
        public virtual DbSet<Randevu> Randevus { get; set; } = null!;
        public virtual DbSet<Uye> Uyes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
                optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_unicode_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Calisan>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PRIMARY");

                entity.ToTable("calisan");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("cid");

                entity.Property(e => e.Ad)
                    .HasMaxLength(20)
                    .HasColumnName("ad");

                entity.Property(e => e.Adres)
                    .HasMaxLength(100)
                    .HasColumnName("adres");

                entity.Property(e => e.Cinsiyet)
                    .HasMaxLength(1)
                    .HasColumnName("cinsiyet");

                entity.Property(e => e.Dgunu)
                    .HasColumnType("datetime")
                    .HasColumnName("dgunu");

                entity.Property(e => e.Maas).HasColumnName("maas");

                entity.Property(e => e.Soyad)
                    .HasMaxLength(20)
                    .HasColumnName("soyad");
            });

            modelBuilder.Entity<Hizmet>(entity =>
            {
                entity.HasKey(e => e.Hno)
                    .HasName("PRIMARY");

                entity.ToTable("hizmet");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Hno)
                    .ValueGeneratedNever()
                    .HasColumnName("hno");

                entity.Property(e => e.Fiyat).HasColumnName("fiyat");

                entity.Property(e => e.Had)
                    .HasMaxLength(50)
                    .HasColumnName("had");
            });

            modelBuilder.Entity<Randevu>(entity =>
            {
                entity.HasKey(e => e.id)
                    .HasName("PRIMARY");

                entity.ToTable("randevu");

                entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Uid, "key1");

                entity.HasIndex(e => e.Hno, "key2");

                entity.HasIndex(e => e.Cid, "key3");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Hno).HasColumnName("hno");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("key3");

                entity.HasOne(d => d.HnoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Hno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("key2");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("key1");
            });

            modelBuilder.Entity<Uye>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("uye");

                entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("uid");

                entity.Property(e => e.Ad)
                    .HasMaxLength(20)
                    .HasColumnName("ad");

                entity.Property(e => e.Cinsiyet)
                    .HasMaxLength(1)
                    .HasColumnName("cinsiyet");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Sifre)
                    .HasMaxLength(20)
                    .HasColumnName("sifre");

                entity.Property(e => e.Soyad)
                    .HasMaxLength(20)
                    .HasColumnName("soyad");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(10)
                    .HasColumnName("telefon");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
