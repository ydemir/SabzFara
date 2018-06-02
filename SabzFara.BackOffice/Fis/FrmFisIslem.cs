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
using SabzFara.Entities.Tables;
using SabzFara.BackOffice.Stok;
using SabzFara.BackOffice.Cari;
using SabzFara.BackOffice.Depo;

namespace SabzFara.BackOffice.Fis
{
    public partial class FrmFisIslem : DevExpress.XtraEditors.XtraForm
    {
        SabzFaraContext context = new SabzFaraContext();
        FisDAL fisDAL = new FisDAL();
        StokHareketDAL stokHareketDal = new StokHareketDAL();
        KasaHareketDAL kasaHareketDal = new KasaHareketDAL();
        CariDAL cariDAL = new CariDAL();
        Entities.Tables.Fis _fisEntity = new Entities.Tables.Fis();
        CariBakiye entityBakiye = new CariBakiye();
        public FrmFisIslem()
        {
            InitializeComponent();
            txtFisTuru.DataBindings.Add("Text", _fisEntity, "FisTuru");
            cmbTarih.DataBindings.Add("EditValue", _fisEntity, "Tarih");
            txtBelgeNo.DataBindings.Add("Text", _fisEntity, "BelgeNo");
            txtAciklama.DataBindings.Add("Text", _fisEntity, "Aciklama");
            lblCariKodu.DataBindings.Add("Text", _fisEntity, "CariKodu");
            lblCariAdi.DataBindings.Add("Text", _fisEntity, "CariAdi");
            gridcontStokHareket.DataSource = context.StokHareketleri.Local.ToBindingList();
            gridcontKasaHareket.DataSource = context.KasaHareketleri.Local.ToBindingList();

        }

        private void FrmFisIslem_Load(object sender, EventArgs e)
        {

        }

        private StokHareket StokSec(Entities.Tables.Stok entity)
        {
            StokHareket stokHareket = new StokHareket();
            stokHareket.StokKodu = entity.StokKodu;
            stokHareket.StokAdi = entity.StokAdi;
            stokHareket.Barkod = entity.Barkod;
            stokHareket.BarkodTuru = entity.BarkodTuru;
            stokHareket.BirimFiyati = entity.SatisFiyati1;
            stokHareket.Birimi = entity.Birimi;
            stokHareket.Miktar = txtMiktar.Value;
            stokHareket.Kdv = entity.SatisKdv;
            stokHareket.IndirimOrani = 0;

            return stokHareket;
        }

        private void btnStokSec_Click(object sender, EventArgs e)
        {
            FrmStokSec frm = new FrmStokSec();
            frm.ShowDialog();
            if (frm.Secildi)
            {
                stokHareketDal.AddOrUpdate(context, StokSec(frm._secilen.First()));
                Toplamlar();
            }

        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Entities.Tables.Stok entity;
                entity = context.Stoklar.Where(c => c.Barkod == txtBarkod.Text).SingleOrDefault();
                if (entity != null)
                {
                    stokHareketDal.AddOrUpdate(context, StokSec(entity));
                    Toplamlar();
                }
                else
                {
                    MessageBox.Show("Aradığınız barkod numarası ürünler arasında bulunamadı.");
                }
                txtBarkod.Text = null;

            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            FrmCariSec frm = new FrmCariSec();
            frm.ShowDialog();
            if (frm.secildi)
            {
                Entities.Tables.Cari entity = frm._secilen.FirstOrDefault();
                entityBakiye = this.cariDAL.CariBakiyesi(context, entity.CariKodu);

                lblCariKodu.Text = entity.CariKodu;
                lblCariAdi.Text = entity.CariAdi;
                txtFaturaUnvani.Text = entity.FaturaUnvani;
                txtVergiDairesi.Text = entity.VergiDairesi;
                txtVergiNo.Text = entity.VergiNo;
                txtIl.Text = entity.Il;
                txtIlce.Text = entity.Ilce;
                txtSemt.Text = entity.Semt;
                txtAdres.Text = entity.Adres;
                lblAlacak.Text = entityBakiye.Alacak.ToString("C2");
                lblBorc.Text = entityBakiye.Borc.ToString("C2");
                lblBakiye.Text = entityBakiye.Bakiye.ToString("C2");


            }

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

            lblCariKodu.Text = null;
            lblCariAdi.Text = null;
            txtFaturaUnvani.Text = null;
            txtVergiDairesi.Text = null;
            txtVergiNo.Text = null;
            txtIl.Text = null;
            txtIlce.Text = null;
            txtSemt.Text = null;
            txtAdres.Text = null; ;
            lblAlacak.Text = "Görüntülenemiyor";
            lblBorc.Text = "Görüntülenemiyor";
            lblBakiye.Text = "Görüntülenemiyor";
        }

        private void gridStokHareket_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            Toplamlar();


        }

        private void Toplamlar()
        {
            gridStokHareket.UpdateSummary();
            txtIskontoTutar.Value = Convert.ToDecimal(colToplamTutar.SummaryItem.SummaryValue) / 100 * txtIskontoOrani.Value;
            txtToplam.Value = Convert.ToDecimal(colToplamTutar.SummaryItem.SummaryValue) - txtIskontoOrani.Value;
            txtKdvToplam.Value = Convert.ToDecimal(colKDVToplam.SummaryItem.SummaryValue);
            txtIndirimToplam.Value = Convert.ToDecimal(colIndirimTutar.SummaryItem.SummaryValue);

        }



        private void txtIskontoOrani_Validated(object sender, EventArgs e)
        {
            Toplamlar();
        }



        private void repoDepo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                FrmDepoSec frm = new FrmDepoSec(gridStokHareket.GetFocusedRowCellValue(colStokKodu).ToString());
                frm.ShowDialog();
                if (frm.secildi)
                {
                    gridStokHareket.SetFocusedRowCellValue(colDepoKodu, frm.entity.DepoKodu);
                    gridStokHareket.SetFocusedRowCellValue(colDepoAdi, frm.entity.DepoAdi);
                }
            }


        }
    }
}