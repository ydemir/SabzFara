using SabzFara.Entities.Context;
using SabzFara.Entities.Repositories;
using SabzFara.Entities.Tables;
using SabzFara.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzFara.Entities.DataAccess
{
   public class StokHareketDAL : EntityRepositoryBase<NetSatisContext, StokHareket,StokHareketValidator>
    {
        public object GetGenelStok(NetSatisContext context, string stokKodu)
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

        public object GetDepoStok(NetSatisContext context, string stokKodu)
        {
            var result = context.Depolar.GroupJoin(context.StokHareketleri.Where(sh => sh.StokKodu == stokKodu), d => d.DepoKodu, sh => sh.DepoKodu, (depolar, stokhareketleri) => new
            {
                depolar.DepoKodu,
                depolar.DepoAdi,
                StokGiris = stokhareketleri.Where(sh => sh.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) ?? 0,
                StokCikis = stokhareketleri.Where(sh => sh.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0,
                MevcutStok = (stokhareketleri.Where(sh => sh.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) ?? 0) - (stokhareketleri.Where(sh => sh.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0)
            }).ToList();

            return result;
        }

        public object DepoStokListele(NetSatisContext context,string depoKodu)
        {
            var tablo = context.Stoklar.GroupJoin(context.StokHareketleri.Where(c=>c.DepoKodu==depoKodu), s => s.StokKodu, sh => sh.StokKodu, (Stoklar, StokHarekeleri) => new
            {
             
    
                Stoklar.StokAdi,
                Stoklar.Barkod,
                
                StokGiris = StokHarekeleri.Where(s => s.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) ?? 0,
                StokCikis = StokHarekeleri.Where(s => s.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0,
                MevcutStok = StokHarekeleri.Where(s => s.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) - StokHarekeleri.Where(s => s.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0
            }).ToList();

            return tablo;
        }

        public object DepoIstatistikListele(NetSatisContext _context, string depoKodu)
        {
            

            List<GenelToplam> genelToplamlar = new List<GenelToplam>()
            {
               new GenelToplam
               {
                   Bilgi="Stok Giriş",
                   KayitSayisi=_context.StokHareketleri.Where(c=>c.DepoKodu==depoKodu && c.Hareket=="Stok Giriş").Count(),
                   Tutar=_context.StokHareketleri.Where(c=>c.DepoKodu==depoKodu && c.Hareket=="Stok Giriş").Sum(c=>c.Miktar)?? 0
               },
               new GenelToplam
               {
                   Bilgi="Stok Giriş",
                   KayitSayisi=_context.StokHareketleri.Where(c=>c.DepoKodu==depoKodu && c.Hareket=="Stok Çıkış").Count(),
                   Tutar=_context.StokHareketleri.Where(c=>c.DepoKodu==depoKodu && c.Hareket=="Stok Çıkış").Sum(c=>c.Miktar)?? 0
               }
            };

            return genelToplamlar;
        }
    }
}
