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
   public class StokHareketDAL : EntityRepositoryBase<SabzFaraContext, StokHareket,StokHareketValidator>
    {
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
                MevcutStok = (stokhareketleri.Where(sh => sh.Hareket == "Stok Giriş").Sum(sh => sh.Miktar) ?? 0) - (stokhareketleri.Where(sh => sh.Hareket == "Stok Çıkış").Sum(sh => sh.Miktar) ?? 0)
            }).ToList();

            return result;
        }
    }
}
