using SabzFara.Entities.Context;
using SabzFara.Entities.Repositories;
using SabzFara.Entities.Tables;
using SabzFara.Entities.Validations;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace SabzFara.Entities.DataAccess
{
    public class StokDAL : EntityRepositoryBase<SabzFaraContext, Stok, StokValidator>
    {
        public object GetAllJoin(SabzFaraContext context)
        {
            var tablo = context.Stoklar.GroupJoin(context.StokHareketleri, s => s.StokKodu, sh => sh.StokKodu, (Stoklar, StokHarekeleri) => new
            {
                Stoklar.Id,
                Stoklar.Durumu,
                Stoklar.StokKodu,
                Stoklar.StokAdi,
                Stoklar.Barkod,
                Stoklar.BarkodTuru,
                Stoklar.Birimi,
                Stoklar.StokGrubu,
                Stoklar.StokAltGrubu,
                Stoklar.Marka,
                Stoklar.Modeli,
                Stoklar.OzelKod1,
                Stoklar.OzelKod2,
                Stoklar.OzelKod3,
                Stoklar.OzelKod4,
                Stoklar.GarantiSuresi,
                Stoklar.UreticiKodu,
                Stoklar.AlisKdv,
                Stoklar.SatisKdv,
                Stoklar.AlisFiyati1,
                Stoklar.AlisFiyati2,
                Stoklar.AlisFiyati3,
                Stoklar.SatisFiyati1,
                Stoklar.SatisFiyati2,
                Stoklar.SatisFiyati3,
                Stoklar.MinStokMiktari,
                Stoklar.MaxStokMiktari,
                Stoklar.Aciklama,
                StokGiris = StokHarekeleri.Where(s => s.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) ?? 0,
                StokCikis = StokHarekeleri.Where(s => s.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0,
                MevcutStok = StokHarekeleri.Where(s => s.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) - StokHarekeleri.Where(s => s.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0
            }).ToList();

            return tablo;
        }

        public object GetGenelStok(SabzFaraContext context, string stokKodu)
        {
            var result = (from c in context.StokHareketleri.Where(c => c.StokKodu == stokKodu)
                          group c by new { c.Hareket } into g
                          select new
                          {
                              Bilgi = g.Key.Hareket,
                              KayitSayisi = g.Count(),
                              Toplam = g.Sum(c => c.Miktar)
                          }).ToList();

            return result;
        }

        public object GetDepoStok(SabzFaraContext context, string stokKodu)
        {
            var result = context.Depolar.GroupJoin(context.StokHareketleri.Where(sh => sh.StokKodu == stokKodu), d => d.DepoKodu, sh => sh.DepoKodu, (depolar, stokhareketleri) => new
            {
                depolar.DepoKodu,
                depolar.DepoAdi,
                StokGiris = stokhareketleri.Where(sh => sh.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) ?? 0,
                StokCikis = stokhareketleri.Where(sh => sh.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0,
                MevcutStok = stokhareketleri.Where(sh => sh.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) ?? 0 - stokhareketleri.Where(sh => sh.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0
            }).ToList();

            return result;
        }
    }
}
