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
  public  class KasaDAL : EntityRepositoryBase<NetSatisContext, Kasa,KasaValidator>
    {
        public object KasaListele(NetSatisContext context)
        {
            var result = context.Kasalar.GroupJoin(context.KasaHareketleri, k => k.KasaKodu, kh => kh.KasaKodu, (kasa, kasahareket) => new
            {
                kasa.Id,
                kasa.KasaKodu,
                kasa.KasaAdi,
                kasa.YetkiliKodu,
                kasa.YetkiliAdi,
                kasa.Aciklama,
                KasaGiris = (kasahareket.Where(k => k.KasaKodu == kasa.KasaKodu && k.Hareket == "Kasa Giriş").Sum(k => k.Tutar) ?? 0),
                KasaCikis= (kasahareket.Where(k => k.KasaKodu == kasa.KasaKodu && k.Hareket == "Kasa Çıkış").Sum(k => k.Tutar) ?? 0),
                Bakiye = (kasahareket.Where(k => k.KasaKodu == kasa.KasaKodu && k.Hareket == "Kasa Giriş").Sum(k => k.Tutar) ?? 0)- (kasahareket.Where(k => k.KasaKodu == kasa.KasaKodu && k.Hareket == "Kasa Çıkış").Sum(k => k.Tutar) ?? 0)
            }).ToList();

            return result;
        }

        public object OdemeTuruToplamListele(NetSatisContext context, string kasaKodu)
        {
            var result = (from c in context.KasaHareketleri.Where(c => c.KasaKodu == kasaKodu)
                          group c by new { c.OdemeTuruAdi } into grp
                          select new
                          {
                              grp.Key.OdemeTuruAdi,
                              KasaGiris = (grp.Where(c => c.OdemeTuruAdi == grp.Key.OdemeTuruAdi && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0),
                              KasaCikis = (grp.Where(c => c.OdemeTuruAdi == grp.Key.OdemeTuruAdi && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0),
                              Bakiye = (grp.Where(c => c.OdemeTuruAdi == grp.Key.OdemeTuruAdi && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0) -
                              (grp.Where(c => c.OdemeTuruAdi == grp.Key.OdemeTuruAdi && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0)
                          }).ToList();

            return result;
        }

        public object GenelToplamListele(NetSatisContext context, string kasaKodu)
        {
            decimal KasaGiris = context.KasaHareketleri.Where(c => c.KasaKodu == kasaKodu && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0;
            int KasaGirisKayitSayisi = context.KasaHareketleri.Where(c => c.KasaKodu == kasaKodu && c.Hareket == "Kasa Giriş").Count();
            decimal KasaCikis = context.KasaHareketleri.Where(c => c.KasaKodu == kasaKodu && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0;
            int KasaCikisKayitSayisi = context.KasaHareketleri.Where(c => c.KasaKodu == kasaKodu && c.Hareket == "Kasa Çıkış").Count();

            List<GenelToplam> genelToplamlar = new List<GenelToplam>()
            {
               new GenelToplam
               {
                   Bilgi="Kasa Giriş",
                   KayitSayisi=KasaGirisKayitSayisi,
                   Tutar=KasaGiris,
               },
               new GenelToplam
               {
                   Bilgi="Kasa Çıkış",
                   KayitSayisi=KasaCikisKayitSayisi,
                   Tutar=KasaCikis
               },
                new GenelToplam
               {
                   Bilgi="Bakiye",
                   KayitSayisi=KasaGirisKayitSayisi+KasaCikisKayitSayisi,
                   Tutar=KasaGiris-KasaCikis
               },
            };

            return genelToplamlar;
        }
    }
}
