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
   public class OdemeTuruDAL: EntityRepositoryBase<SabzFaraContext, OdemeTuru,OdemeTuruValidator>
    {
        public object OdemeTuruListele(SabzFaraContext context)
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
    }
}
