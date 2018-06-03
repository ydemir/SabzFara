﻿using SabzFara.Entities.Mapping;
using SabzFara.Entities.Tables;
using System.Data.Entity;

namespace SabzFara.Entities.Context
{
    public class NetSatisContext : DbContext
    {
        public DbSet<Stok> Stoklar { get; set; }
        public DbSet<Cari> Cariler { get; set; }
        public DbSet<Fis> Fisler { get; set; }
        public DbSet<StokHareket> StokHareketleri { get; set; }
        public DbSet<KasaHareket> KasaHareketleri { get; set; }
        public DbSet<Depo> Depolar { get; set; }
        public DbSet<Kasa> Kasalar { get; set; }
        public DbSet<OdemeTuru> OdemeTurleri { get; set; }
        public DbSet<Tanim> Tanimlar { get; set; }
        public DbSet<Personel> Personeller { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StokMap());
            modelBuilder.Configurations.Add(new CariMap());
            modelBuilder.Configurations.Add(new FisMap());
            modelBuilder.Configurations.Add(new StokHareketMap());
            modelBuilder.Configurations.Add(new KasaHareketMap());
            modelBuilder.Configurations.Add(new DepoMap());
            modelBuilder.Configurations.Add(new KasaMap());
            modelBuilder.Configurations.Add(new OdemeTuruMap());
            modelBuilder.Configurations.Add(new TanimMap());
            modelBuilder.Configurations.Add(new PersonelMap());
        }
    }
}
