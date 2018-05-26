using SabzFara.Entities.Context;
using SabzFara.Entities.Interfaces;
using SabzFara.Entities.Repositories;
using SabzFara.Entities.Tables;
using SabzFara.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SabzFara.Entities.DataAccess
{
    public class CariDAL : EntityRepositoryBase<SabzFaraContext, Cari, CariValidator>
    {
        public object GetCariler(SabzFaraContext _context)
        {
            var result = _context.Cariler.GroupJoin(_context.Fisler, c => c.CariKodu, f => f.CariKodu, (cariler, fisler) => new
            {
                cariler.Id,
                cariler.Durumu,
                cariler.CariKodu,
                cariler.CariAdi,
                cariler.CariTuru,
                cariler.YetkiliKisi,
                cariler.FaturaUnvani,
                cariler.CepTelefonu,
                cariler.Telefon,
                cariler.Fax,
                cariler.EMail,
                cariler.Web,
                cariler.Il,
                cariler.Ilce,
                cariler.Semt,
                cariler.Adres,
                cariler.CariGrubu,
                cariler.CariAltGrubu,
                cariler.OzelKod1,
                cariler.OzelKod2,
                cariler.OzelKod3,
                cariler.OzelKod4,
                cariler.VergiNo,
                cariler.VergiDairesi,
                cariler.IskontoOrani,
                cariler.RiskLimiti,
                cariler.AlisOzelFiyati,
                cariler.SatisOzelFiyati,
                cariler.Aciklama,
                AlisToplam = fisler.Where(f => f.FisTuru == "Alış Faturası").Sum(f => f.ToplamTutar) ?? 0,
                SatisToplam = fisler.Where(f => f.FisTuru == "Perakende Satış Faturası").Sum(f => f.ToplamTutar) ?? 0,
            }).GroupJoin(_context.KasaHareketleri, c => c.CariKodu, c => c.CariKodu, (cariler, kasahareket) => new
            {
                cariler.Id,
                cariler.Durumu,
                cariler.CariKodu,
                cariler.CariAdi,
                cariler.CariTuru,
                cariler.YetkiliKisi,
                cariler.FaturaUnvani,
                cariler.CepTelefonu,
                cariler.Telefon,
                cariler.Fax,
                cariler.EMail,
                cariler.Web,
                cariler.Il,
                cariler.Ilce,
                cariler.Semt,
                cariler.Adres,
                cariler.CariGrubu,
                cariler.CariAltGrubu,
                cariler.OzelKod1,
                cariler.OzelKod2,
                cariler.OzelKod3,
                cariler.OzelKod4,
                cariler.VergiNo,
                cariler.VergiDairesi,
                cariler.IskontoOrani,
                cariler.RiskLimiti,
                cariler.AlisOzelFiyati,
                cariler.SatisOzelFiyati,
                cariler.Aciklama,
                Alacak = cariler.AlisToplam + (kasahareket.Where(c => c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0),
                Borc = cariler.SatisToplam + (kasahareket.Where(c => c.Hareket == "Çıkış Giriş").Sum(c => c.Tutar) ?? 0),
                Bakiye = (cariler.AlisToplam + (kasahareket.Where(c => c.Hareket == "Kasa Giriş").Sum(c => c.Tutar) ?? 0)) - (cariler.SatisToplam + (kasahareket.Where(c => c.Hareket == "Çıkış Giriş").Sum(c => c.Tutar) ?? 0))
            }).ToList();

            return result;
        }

        public object CariFisAyrinti(SabzFaraContext _context, string cariKodu)
        {
            var result = _context.Fisler.Where(f => f.CariKodu == cariKodu)
            .GroupJoin(_context.KasaHareketleri.Where(kh => kh.CariKodu == cariKodu), f => f.CariKodu, kh => kh.CariKodu, (fisler, kasaHareket) => new
            {
                fisler.FisKodu,
                fisler.FisTuru,
                fisler.PlasiyerAdi,
                fisler.PlasiyerKodu,
                fisler.BelgeNo,
                fisler.Tarih,
                fisler.IskontoOrani,
                fisler.IskontoTutar,
                fisler.Aciklama,
                fisler.ToplamTutar,
                Odenen=_context.KasaHareketleri.Where(f=>f.FisKodu==fisler.FisKodu).Sum(kh=>kh.Tutar) ??0,
                KalanOdeme=fisler.ToplamTutar - _context.KasaHareketleri.Where(f => f.FisKodu == fisler.FisKodu).Sum(kh => kh.Tutar) ?? 0
            }).ToList();

            return result;
        }

        public object CariFisGenelToplam(SabzFaraContext _context,string cariKodu)
        {
            var result = (from f in _context.Fisler.Where(f => f.CariKodu == cariKodu) group f by new { f.FisTuru } into grp
                          select new
                          {
                              Bilgi = grp.Key.FisTuru,
                              KayitSayisi = grp.Count(),
                              Tutar=grp.Sum(f=>f.ToplamTutar)
                          }).ToList();
            return result;
        }

        public object CariGenelToplam(SabzFaraContext _context,string cariKodu)
        {
            decimal alacak = (_context.Fisler.Where(f => f.CariKodu == cariKodu && f.FisTuru == "Aliş Faturası").Sum(f => f.ToplamTutar) ?? 0) +
                (_context.KasaHareketleri.Where(f => f.CariKodu == cariKodu && f.Hareket == "Kasa Giriş").Sum(f => f.Tutar) ?? 0);

            decimal borc = (_context.Fisler.Where(f => f.CariKodu == cariKodu && f.FisTuru == "Perakende Satış Faturası").Sum(f => f.ToplamTutar) ?? 0) +
               (_context.KasaHareketleri.Where(f => f.CariKodu == cariKodu && f.Hareket == "Kasa Çıkış").Sum(f => f.Tutar) ?? 0);

            List<GenelToplam> genelToplamlar = new List<GenelToplam>()
            {
               new GenelToplam
               {
                   Bilgi="Alacak",
                   Tutar=alacak,
               },
               new GenelToplam
               {
                   Bilgi="Borç",
                   Tutar=borc
               },
                new GenelToplam
               {
                   Bilgi="Bakiye",
                   Tutar=alacak-borc
               },
            };

            return genelToplamlar;
        }
    }
}
