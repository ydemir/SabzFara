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


namespace SabzFara.BackOffice.Stok
{
    public partial class FrmStok : DevExpress.XtraEditors.XtraForm
    {
        SabzFaraContext context = new SabzFaraContext();
        StokDAL _stokDAL = new StokDAL();
        string secilen;
        public FrmStok()
        {
            InitializeComponent();
        }

        private void FrmStok_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {

           gridControl1.DataSource= _stokDAL.GetAllJoin(context);
            
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                 secilen = gridView1.GetFocusedRowCellValue(colStokKodu).ToString();
                _stokDAL.Delete(context, s => s.StokKodu == secilen);
                _stokDAL.Save(context);
                GetAll();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmStokIslem frm = new FrmStokIslem(new Entities.Tables.Stok());
            frm.ShowDialog();
            if (frm.saved)
            {
                GetAll();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
             secilen = gridView1.GetFocusedRowCellValue(colStokKodu).ToString();
            FrmStokIslem frm = new FrmStokIslem(_stokDAL.GetByFilter(context, s => s.StokKodu == secilen));
            frm.ShowDialog();
            if (frm.saved)
            {
                GetAll();
            }
        }

        private void btnKopyala_Click(object sender, EventArgs e)
        {
             secilen = gridView1.GetFocusedRowCellValue(colStokKodu).ToString();
            Entities.Tables.Stok _stokEntity = new Entities.Tables.Stok();
            
            _stokEntity = _stokDAL.GetByFilter(context, s => s.StokKodu == secilen);
            _stokEntity.Id = -1;

            _stokEntity.StokKodu = null;
            FrmStokIslem frm = new FrmStokIslem(_stokEntity);
            frm.ShowDialog();
            if (frm.saved)
            {
                GetAll();
            }
        }

        private void btnStokHareket_Click(object sender, EventArgs e)
        {
            secilen = gridView1.GetFocusedRowCellValue(colStokKodu).ToString();
           string secilenAd = gridView1.GetFocusedRowCellValue(colStokAdi).ToString();
            FrmStokHareket frm = new FrmStokHareket(secilen,secilenAd);
            frm.ShowDialog();
        }
    }
}