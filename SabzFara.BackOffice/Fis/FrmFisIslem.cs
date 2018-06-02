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

namespace SabzFara.BackOffice.Fis
{
    public partial class FrmFisIslem : DevExpress.XtraEditors.XtraForm
    {
        SabzFaraContext context = new SabzFaraContext();
        FisDAL fisDAL = new FisDAL();
        StokHareketDAL stokHareketDal = new StokHareketDAL();
        KasaHareketDAL kasaHareketDal = new KasaHareketDAL();
        Entities.Tables.Fis _fisEntity = new Entities.Tables.Fis();
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

            return stokHareket;
        }

        private void btnStokSec_Click(object sender, EventArgs e)
        {
            FrmStokSec frm = new FrmStokSec();
            frm.ShowDialog();
            if (frm.Secildi)
            {
                stokHareketDal.AddOrUpdate(context, StokSec(frm._secilen.First()));
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
                CariBakiye bakiye = frm.secilenCariBakiye.FirstOrDefault();

                lblCariKodu.Text = entity.CariKodu;
                lblCariAdi.Text = entity.CariAdi;
                txtFaturaUnvani.Text = entity.FaturaUnvani;
                txtVergiDairesi.Text = entity.VergiDairesi;
                txtVergiNo.Text = entity.VergiNo;
                txtIl.Text = entity.Il;
                txtIlce.Text = entity.Ilce;
                txtSemt.Text = entity.Semt;
                txtAdres.Text = entity.Adres;
                lblAlacak.Text = bakiye.Alacak.ToString("C2");
                lblBorc.Text = bakiye.Borc.ToString("C2");
                lblBakiye.Text = bakiye.Bakiye.ToString("C2");

               
            }

        }
    }
}