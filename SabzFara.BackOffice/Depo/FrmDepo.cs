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

namespace SabzFara.BackOffice.Depo
{
    public partial class FrmDepo : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        DepoDAL depoDAL = new DepoDAL();
        string secilen = null;
        public FrmDepo()
        {
            InitializeComponent();
        }

        private void FrmDepo_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public void Listele()
        {
            gridContDepolar.DataSource = depoDAL.GetAll(context);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            filterControl1.ApplyFilter();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void btnFiltreKapat_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }

        private void btnFiltreIptal_Click(object sender, EventArgs e)
        {
            filterControl1.FilterString = null;
            filterControl1.ApplyFilter();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            secilen = gridDepolar.GetFocusedRowCellValue(colDepoKodu).ToString();
            FrmDepoIslem frm = new FrmDepoIslem(depoDAL.GetByFilter(context, s => s.DepoKodu == secilen));
            frm.ShowDialog();
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              string  secilen = gridDepolar.GetFocusedRowCellValue(colDepoKodu).ToString();
                depoDAL.Delete(context, s => s.DepoKodu == secilen);
                depoDAL.Save(context);
                Listele();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmDepoIslem frm = new FrmDepoIslem(new Entities.Tables.Depo());
            frm.ShowDialog();
            if (frm.kaydedildi)
            {
                Listele();
            }
        }
    }
}