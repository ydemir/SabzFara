using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SabzFara.Entities.Context;
using SabzFara.Entities.DataAccess;
using System.Data.Entity;
using SabzFara.BackOffice.Stok;
using SabzFara.Entities.Tables;

namespace SabzFara.BackOffice.İndirim
{
    public partial class FrmIndirimIslem : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        IndirimDAL indirimDAL = new IndirimDAL();
        public FrmIndirimIslem()
        {
            InitializeComponent();
            gridContIndirim.DataSource = context.Indirimler.Local.ToBindingList();
        }

        private Indirim StokEkle(Entities.Tables.Stok entity)
        {
            Indirim _entity = new Indirim();
            _entity.StokKodu = entity.StokKodu;
            _entity.Barkod = entity.Barkod;
            _entity.StokAdi = entity.StokAdi;
            return _entity;
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmStokSec frm = new FrmStokSec(true);
            frm.ShowDialog();

            if (frm.Secildi)
            {
                foreach (var itemStok in frm._secilen)
                {
                    Indirim _entity = new Indirim();
                    _entity = StokEkle(itemStok);

                    var count = context.Indirimler.Count(c => c.StokKodu == itemStok.StokKodu);
                    if (count != 0)
                    {
                        if (MessageBox.Show("Seçili olan stoğa daha önceden eklenmiş bir indirim bulunmaktadır. Var olan indirimi güncellemek ister misiniz ? ", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            var secilenId = context.Indirimler.SingleOrDefault(c => c.StokKodu == itemStok.StokKodu);
                            _entity.Id = secilenId.Id;
                            indirimDAL.AddOrUpdate(context, _entity);
                        }
                    }
                    else
                    {
                        indirimDAL.AddOrUpdate(context, _entity);
                    }
                }


            }

        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            foreach (var itemIndirim in context.Indirimler.Local.ToList())
            {
                itemIndirim.Durumu = true;
                if (btnSuresiz.Checked)
                {
                    itemIndirim.IndirimTuru = "Süresiz";
                }
                itemIndirim.BaslangicTarihi = dateBaslangic.DateTime;
                itemIndirim.BitisTarihi = dateBitis.DateTime;
                itemIndirim.IndirimTuru = "Belirli Tarihler Arasında";


            }
            indirimDAL.Save(context);
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi listeden çıkartmak istediğinize emin misiniz?","Uyarı",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
 var secilenStokKodu = gridIndirim.GetFocusedRowCellValue(colStokKodu).ToString();
            var secilen = indirimDAL.GetByFilter(context, c => c.StokKodu == secilenStokKodu);
            context.Entry(secilen).State = EntityState.Detached;
            }
           
        }
    }
}