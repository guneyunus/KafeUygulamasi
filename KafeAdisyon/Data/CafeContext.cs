using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using KafeAdisyon.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace KafeAdisyon.Data
{
    public class CafeContext :DbContext
    {
        public CafeContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"
Data Source=DESKTOP-30MHEAF\SQLEXPRESS;Initial Catalog=Kafe4DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiparisDetay>()
                .HasKey(x => new {x.UrunID, x.SiparisId});
            modelBuilder.Entity<Kategori>()
                .Property(x => x.Fotograf).HasMaxLength(100000);
            modelBuilder.Entity<Urun>()
                .Property(x => x.Fiyat)
                .HasPrecision(10, 2);



            modelBuilder.Entity<SiparisDetay>()
                .Property(x => x.Fiyat)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SiparisDetay>()
                .Property(x => x.AraToplam)
                .HasPrecision(10, 2);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<KafeBilgi> KafeBilgiler { get; set; }
        public DbSet<Kat> Katlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Masa> Masalar { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylar { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }
        
    }

}
