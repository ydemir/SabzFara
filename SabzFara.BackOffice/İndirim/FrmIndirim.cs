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

namespace SabzFara.BackOffice.İndirim
{
    public partial class FrmIndirim : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        IndirimDAL indirimDAL = new IndirimDAL();
        public FrmIndirim()
        {
            InitializeComponent();
        }

        private void FrmIndirim_Load(object sender, EventArgs e)
        {
            Listele();
        }
        private void Listele()
        {
            NetSatisContext context = new NetSatisContext();
            gridContIndirim.DataSource = indirimDAL.GetAll(context);
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmIndirimIslem frm = new FrmIndirimIslem();
            frm.ShowDialog();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                var secilen = gridIndirim.GetFocusedRowCellValue(colStokKodu).ToString();
                indirimDAL.Delete(context, c => c.StokKodu == secilen);
                indirimDAL.Save(context);
            }
        }

        private void gridIndirim_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }

        private void btnDurumu_Click(object sender, EventArgs e)
        {
            var secilenStokKodu = gridIndirim.GetFocusedRowCellValue(colStokKodu).ToString();
            var secilen = indirimDAL.GetByFilter(context, c => c.StokKodu == secilenStokKodu);
            if (Convert.ToBoolean(gridIndirim.GetFocusedRowCellValue(colDurumu)))
            {

                secilen.Durumu = false;
                btnDurumu.Text = "Pasif Yap";
                gridIndirim.SetFocusedRowCellValue(colDurumu, false);
                btnDurumu.ImageIndex = 14;
                indirimDAL.Save(context);
            }
            else
            {
                secilen.Durumu = true;
                btnDurumu.Text = "Aktif Yap";
                gridIndirim.SetFocusedRowCellValue(colDurumu, true);
                btnDurumu.ImageIndex = 13;
                indirimDAL.Save(context);
            }
            
        }

        private void gridIndirim_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (Convert.ToBoolean(gridIndirim.GetFocusedRowCellValue(colDurumu)))
            {
                btnDurumu.Text = "Pasif Yap";
                btnDurumu.ImageIndex = 14;
                

            }
            else
            {
                btnDurumu.Text = "Aktif Yap";
                btnDurumu.ImageIndex = 13;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            gridIndirim.OptionsView.ShowAutoFilterRow = true ? gridIndirim.OptionsView.ShowAutoFilterRow == false : gridIndirim.OptionsView.ShowAutoFilterRow == true;
        }
    }
}