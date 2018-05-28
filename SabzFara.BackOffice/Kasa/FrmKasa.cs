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
using SabzFara.Entities.DataAccess;
using SabzFara.Entities.Context;

namespace SabzFara.BackOffice.Kasa
{
    public partial class FrmKasa : DevExpress.XtraEditors.XtraForm
    {
        KasaDAL kasaDAL = new KasaDAL();
        SabzFaraContext context = new SabzFaraContext();
        public FrmKasa()
        {
            InitializeComponent();
        }

        public void Guncelle()
        {
           gridContKasalar.DataSource= kasaDAL.KasaListele(context);
        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
            Guncelle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            filterControl1.ApplyFilter();
        }

        private void btnFiltreIptal_Click(object sender, EventArgs e)
        {
            filterControl1.FilterString = null;
            filterControl1.ApplyFilter();
        }

        private void btnFiltreKapat_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmKasaIslem frm = new FrmKasaIslem(new Entities.Tables.Kasa());
            frm.ShowDialog();
            if (frm.kaydedildi)
            {
                Guncelle();
            }

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
          string  secilen = layoutView1.GetFocusedRowCellValue(colKasaKodu).ToString();
            FrmKasaIslem frm = new FrmKasaIslem(kasaDAL.GetByFilter(context, s => s.KasaKodu == secilen));
            frm.ShowDialog();
            if (frm.kaydedildi)
            {
                Guncelle();
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              string  secilen = layoutView1.GetFocusedRowCellValue(colKasaKodu).ToString();
                kasaDAL.Delete(context, s => s.KasaKodu == secilen);
                kasaDAL.Save(context);
                Guncelle();
            }
        }
    }
}