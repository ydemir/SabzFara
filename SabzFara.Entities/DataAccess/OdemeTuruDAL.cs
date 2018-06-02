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
   public class OdemeTuruDAL: EntityRepositoryBase<NetSatisContext, OdemeTuru,OdemeTuruValidator>
    {
        public object OdemeTuruListele(NetSatisContext context)
        {
            var result = context.OdemeTurleri.GroupJoin(context.KasaHareketleri, k => k.OdemeTuruKodu, kh => kh.OdemeTuruKodu, (odemeTuru, kasahareket) => new
            {
                odemeTuru.Id,
                odemeTuru.OdemeTuruKodu,
                odemeTuru.OdemeTuruAdi,
                odemeTuru.Aciklama,
                KasaGiris = (kasahareket.Where(k => k.OdemeTuruKodu == odemeTuru.OdemeTuruKodu && k.Hareket == "Kasa Giriş").Sum(k => k.Tutar) ?? 0),
                KasaCikis = (kasahareket.Where(k => k.OdemeTuruKodu == odemeTuru.OdemeTuruKodu && k.Hareket == "Kasa Çıkış").Sum(k => k.Tutar) ?? 0),
                Bakiye = (kasahareket.Where(k => k.OdemeTuruKodu == odemeTuru.OdemeTuruKodu && k.Hareket == "Kasa Giriş").Sum(k => k.Tutar) ?? 0) -
                (kasahareket.Where(k => k.OdemeTuruKodu == odemeTuru.OdemeTuruKodu && k.Hareket == "Kasa Çıkış").Sum(k => k.Tutar) ?? 0)
            }).ToList();

            return result;
        }

        public object KasaToplamListele(NetSatisContext context, string odemeTuruKodu)
        {
            var result = (from c in context.KasaHareketleri.Where(c => c.OdemeTuruKodu == odemeTuruKodu)
                          group c by new { c.KasaKodu,c.KasaAdi } into grp
                          select new
                          {
                              grp.Key.KasaKodu,
                              grp.Key.KasaAdi,
                              KasaGiris = (grp.Where(c => c.KasaKodu == grp.Key.KasaKodu && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0),
                              KasaCikis = (grp.Where(c => c.KasaKodu == grp.Key.KasaKodu && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0),
                              Bakiye = (grp.Where(c => c.KasaKodu == grp.Key.KasaKodu && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0) -
                              (grp.Where(c => c.KasaKodu == grp.Key.KasaKodu && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0)
                          }).ToList();

            return result;
        }

        public object GenelToplamListele(NetSatisContext context, string odemeTuruKodu)
        {
            decimal KasaGiris = context.KasaHareketleri.Where(c => c.OdemeTuruKodu == odemeTuruKodu && c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0;
            int KasaGirisKayitSayisi = context.KasaHareketleri.Where(c => c.OdemeTuruKodu == odemeTuruKodu && c.Hareket == "Kasa Giriş").Count();
            decimal KasaCikis = context.KasaHareketleri.Where(c => c.OdemeTuruKodu == odemeTuruKodu && c.Hareket == "Kasa Çıkış").Sum(c => c.Tutar) ?? 0;
            int KasaCikisKayitSayisi = context.KasaHareketleri.Where(c => c.OdemeTuruKodu == odemeTuruKodu && c.Hareket == "Kasa Çıkış").Count();

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
