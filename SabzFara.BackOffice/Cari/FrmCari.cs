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

namespace SabzFara.BackOffice.Cari
{
    public partial class FrmCari : DevExpress.XtraEditors.XtraForm
    {
        SabzFaraContext _context = new SabzFaraContext();
        CariDAL _caridal = new CariDAL();
        string secilen;
        public FrmCari()
        {
            InitializeComponent();
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

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            filterControl1.ApplyFilter();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void FrmCari_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            gridControl1.DataSource = _caridal.GetCariler(_context);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                 secilen = gridView1.GetFocusedRowCellValue(colCariKodu).ToString();
                _caridal.Delete(_context, s => s.CariKodu == secilen);
                _caridal.Save(_context);
                GetAll();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmCariIslem frm = new FrmCariIslem(new Entities.Tables.Cari());
            frm.ShowDialog();

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            secilen = gridView1.GetFocusedRowCellValue(colCariKodu).ToString();
            FrmCariIslem frm = new FrmCariIslem(_caridal.GetByFilter(_context, s => s.CariKodu == secilen));
            frm.ShowDialog();
        }

        private void btnKopyala_Click(object sender, EventArgs e)
        {
            secilen = gridView1.GetFocusedRowCellValue(colCariKodu).ToString();
            Entities.Tables.Cari __cariEntity = new Entities.Tables.Cari();

            __cariEntity = _caridal.GetByFilter(_context, s => s.CariKodu == secilen);
            __cariEntity.Id = -1;

            __cariEntity.CariKodu = null;
            FrmCariIslem frm = new FrmCariIslem(__cariEntity);
            frm.ShowDialog();
        }
    }
}