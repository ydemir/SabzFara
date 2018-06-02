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

namespace SabzFara.BackOffice.OdemeTuru
{
    public partial class FrmOdemeTuru : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        OdemeTuruDAL odemeTuruDAL = new OdemeTuruDAL();

        public FrmOdemeTuru()
        {
            InitializeComponent();
        }

        private void FrmOdemeTuru_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            gridContOdemeTuru.DataSource = odemeTuruDAL.OdemeTuruListele(context);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
             string   secilen = gridOdemeTuru.GetFocusedRowCellValue(colOdemeTuruKodu).ToString();
                odemeTuruDAL.Delete(context, s => s.OdemeTuruKodu == secilen);
                odemeTuruDAL.Save(context);
                Listele();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmOdemeTuruIslem frm = new FrmOdemeTuruIslem(new Entities.Tables.OdemeTuru());
            frm.ShowDialog();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            string secilen = gridOdemeTuru.GetFocusedRowCellValue(colOdemeTuruKodu).ToString();
            FrmOdemeTuruIslem frm = new FrmOdemeTuruIslem(odemeTuruDAL.GetByFilter(context,c=>c.OdemeTuruKodu==secilen));
            frm.ShowDialog();
        }
    }
}