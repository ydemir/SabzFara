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
   public class DepoDAL:EntityRepositoryBase<SabzFaraContext, Depo,DepoValidator>
    {
        public object DepoBazindaStokListele(SabzFaraContext context,string stokKodu)
        {
            var result = context.Depolar.GroupJoin(context.StokHareketleri.Where(sh => sh.StokKodu == stokKodu), d => d.DepoKodu, sh => sh.DepoKodu, (depolar, stokhareketleri) => new
            {
                depolar.Id,
                depolar.DepoKodu,
                depolar.DepoAdi,
                depolar.YetkiliKodu,
                depolar.YetkiliAdi,
                depolar.Telefon,
                depolar.Il,
                depolar.Ilce,
                depolar.Semt,
                depolar.Adres,
                depolar.Aciklama,
                StokGiris = stokhareketleri.Where(sh => sh.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) ?? 0,
                StokCikis = stokhareketleri.Where(sh => sh.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0,
                MevcutStok = (stokhareketleri.Where(sh => sh.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) ?? 0) - (stokhareketleri.Where(sh => sh.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0)
            }).ToList();

            return result;
        }
    }
}
