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
  public  class KasaDAL : EntityRepositoryBase<SabzFaraContext, Kasa,KasaValidator>
    {
        public object KasaListele(SabzFaraContext context)
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
    }
}
