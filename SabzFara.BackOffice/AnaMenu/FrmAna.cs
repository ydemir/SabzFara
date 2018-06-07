using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SabzFara.BackOffice.Stok;
using SabzFara.BackOffice.Cari;
using SabzFara.BackOffice.Tanim;
using SabzFara.BackOffice.Fis;
using SabzFara.BackOffice.StokHareketleri;
using SabzFara.BackOffice.Kasa_Hareketleri;
using SabzFara.BackOffice.Personel;
using SabzFara.BackOffice.Fiyat_Degistir;

namespace SabzFara.BackOffice.AnaMenu
{
    public partial class FrmAna : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmAna()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmStok frm = new FrmStok();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barCari_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCari frm = new FrmCari();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmFis frm = new FrmFis();
            frm.MdiParent = this;
            frm.Show();

        }

        private void FrmAna_Load(object sender, EventArgs e)
        {
            FrmAnaMenuBilgi frm = new FrmAnaMenuBilgi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnStokHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmStokHareketleri frm = new FrmStokHareketleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barKasaHareket_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmKasaHareketleri frm = new FrmKasaHareketleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnPersoneller_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPersonel frm = new FrmPersonel();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FisIslem_Click(object sender, ItemClickEventArgs e)
        {
            FrmFisIslem frm = new FrmFisIslem(null, e.Item.Caption);
            frm.ShowDialog();
        }

        private void barTopluFiyatDegisikligi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTopluFiyat frm = new FrmTopluFiyat();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}