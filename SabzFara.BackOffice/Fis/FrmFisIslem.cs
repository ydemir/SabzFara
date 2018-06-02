﻿using System;
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
using SabzFara.BackOffice.Kasa;

namespace SabzFara.BackOffice.Fis
{
    public partial class FrmFisIslem : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        FisDAL fisDAL = new FisDAL();
        StokHareketDAL stokHareketDal = new StokHareketDAL();
        KasaHareketDAL kasaHareketDal = new KasaHareketDAL();
        CariDAL cariDAL = new CariDAL();
        Entities.Tables.Fis _fisEntity = new Entities.Tables.Fis();
        CariBakiye entityBakiye = new CariBakiye();
        public FrmFisIslem(string fisKodu=null)
        {
            InitializeComponent();
            if (fisKodu!=null)
            {
                _fisEntity = context.Fisler.Where(c => c.FisKodu == fisKodu).SingleOrDefault();
                context.StokHareketleri.Where(c => c.FisKodu == fisKodu).Load();
                context.KasaHareketleri.Where(c => c.FisKodu == fisKodu).Load();

                entityBakiye = this.cariDAL.CariBakiyesi(context, _fisEntity.CariKodu);

                lblAlacak.Text = entityBakiye.Alacak.ToString("C2");
                lblBorc.Text = entityBakiye.Borc.ToString("C2");
                lblBakiye.Text = entityBakiye.Bakiye.ToString("C2");
            }
           

            _fisEntity.FisTuru = "Alış Faturası";

            txtFisKodu.DataBindings.Add("Text", _fisEntity, "FisKodu",false,DataSourceUpdateMode.OnPropertyChanged);
            txtFisTuru.DataBindings.Add("Text", _fisEntity, "FisTuru", false, DataSourceUpdateMode.OnPropertyChanged);
            cmbTarih.DataBindings.Add("EditValue", _fisEntity, "Tarih", false, DataSourceUpdateMode.OnPropertyChanged);
            txtBelgeNo.DataBindings.Add("Text", _fisEntity, "BelgeNo", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAciklama.DataBindings.Add("Text", _fisEntity, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);
            lblCariKodu.DataBindings.Add("Text", _fisEntity, "CariKodu", false, DataSourceUpdateMode.OnPropertyChanged);
            lblCariAdi.DataBindings.Add("Text", _fisEntity, "CariAdi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtFaturaUnvani.DataBindings.Add("Text", _fisEntity, "FaturaUnvani", false, DataSourceUpdateMode.OnPropertyChanged);
            txtCepTel.DataBindings.Add("Text", _fisEntity, "CepTelefonu", false, DataSourceUpdateMode.OnPropertyChanged);
            txtIl.DataBindings.Add("Text", _fisEntity, "Il", false, DataSourceUpdateMode.OnPropertyChanged);
            txtIlce.DataBindings.Add("Text", _fisEntity, "Ilce", false, DataSourceUpdateMode.OnPropertyChanged);
            txtVergiDairesi.DataBindings.Add("Text", _fisEntity, "VergiDairesi", false, DataSourceUpdateMode.OnPropertyChanged);
            txtVergiNo.DataBindings.Add("Text", _fisEntity, "VergiNo", false, DataSourceUpdateMode.OnPropertyChanged);
            gridcontStokHareket.DataSource = context.StokHareketleri.Local.ToBindingList();
            gridcontKasaHareket.DataSource = context.KasaHareketleri.Local.ToBindingList();

            Toplamlar();
            OdenenTutarGuncelle();


            foreach (var item in context.OdemeTurleri.ToList())
            {
                var buton = new SimpleButton
                {
                    Name = item.OdemeTuruKodu,
                    Text = item.OdemeTuruAdi,
                    Height = 48,
                    Width = 125
                };

                buton.Click += OdemeEkle_Click;
                flowOdemeTurleri.Controls.Add(buton);
            }

        }

        private void OdemeEkle_Click (object sender,EventArgs e)
        {
            var buton = (sender as SimpleButton);
            Entities.Tables.KasaHareket entityKasaHareket = new KasaHareket
            {
                OdemeTuruKodu = buton.Name,
                OdemeTuruAdi = buton.Text,
                Tutar = txtOdenmesiGereken.Value
            };
            if (txtOdenmesiGereken.Value<=0)
            {
                MessageBox.Show("Ödenmesi gereken tutar zaten ödenmiş durumdadır.");
            }
            else
            {
                kasaHareketDal.AddOrUpdate(context, entityKasaHareket);
                OdenenTutarGuncelle();
            }
           
        }

        private void OdenenTutarGuncelle()
        {
            gridKasaHareket.UpdateSummary();
            txtOdenenTutar.Value = Convert.ToDecimal(colTutar.SummaryItem.SummaryValue);
            txtOdenmesiGereken.Value = txtToplam.Value - txtOdenenTutar.Value;
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
            stokHareket.BirimFiyati = txtFisTuru.Text == "Alış Faturası" ? entity.AlisFiyati1 : entity.SatisFiyati1;
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
                txtCepTel.Text = entity.CepTelefonu;
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
            txtOdenmesiGereken.Value = txtToplam.Value - txtOdenenTutar.Value;

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

        private void repoBirimFiyat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string fiyatSecilen = gridStokHareket.GetFocusedRowCellValue(colStokKodu).ToString();
            Entities.Tables.Stok fiyatEntity = context.Stoklar.Where(c => c.StokKodu == fiyatSecilen).SingleOrDefault();

            barFiyat1.Tag = txtFisTuru.Text=="Alış Faturası" ? fiyatEntity.AlisFiyati1 ?? 0: fiyatEntity.SatisFiyati1 ?? 0;
            barFiyat2.Tag = txtFisTuru.Text == "Alış Faturası" ? fiyatEntity.AlisFiyati2 ?? 0 : fiyatEntity.SatisFiyati2 ?? 0;
            barFiyat3.Tag = txtFisTuru.Text == "Alış Faturası" ? fiyatEntity.AlisFiyati3 ?? 0 : fiyatEntity.SatisFiyati3 ?? 0;

            barFiyat1.Caption = string.Format("{0:C2}", barFiyat1.Tag);
            barFiyat2.Caption = string.Format("{0:C2}", barFiyat2.Tag);
            barFiyat3.Caption = string.Format("{0:C2}", barFiyat3.Tag);

            radialFiyat.ShowPopup(MousePosition);
        }

        private void FiyatSec(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridStokHareket.SetFocusedRowCellValue(colBirimFiyati,Convert.ToDecimal(e.Item.Tag));
        }

       
        private void repoSeriNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string veri = Convert.ToString(gridStokHareket.GetFocusedRowCellValue(colSeriNo));
            FrmSeriNoGir frm = new FrmSeriNoGir(veri);
            frm.ShowDialog();

            gridStokHareket.SetFocusedRowCellValue(colSeriNo,frm.veriSeriNo);
        }

        private void repoSil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridStokHareket.DeleteSelectedRows();
            }
        }

        private void repoKasa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmKasaSec frm = new FrmKasaSec();
            frm.ShowDialog();
            if (frm.secildi)
            {
                gridKasaHareket.SetFocusedRowCellValue(colKasaKodu, frm.entity.KasaKodu);
                gridKasaHareket.SetFocusedRowCellValue(colKasaAdi, frm.entity.KasaAdi);
            }
        }

        private void repoKhSil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridKasaHareket.DeleteSelectedRows();
            }

            OdenenTutarGuncelle();
        }

        private void btnSatisBitir_Click(object sender, EventArgs e)
        {

            int StokHata = context.StokHareketleri.Local.Where(c => c.DepoKodu == null).Count();
            int KasaHata = context.StokHareketleri.Local.Where(c => c.DepoKodu == null).Count();

            if (StokHata==0 && KasaHata==0)
            {
                foreach (var stokVeri in context.StokHareketleri.Local.ToList())
                {
                    stokVeri.Tarih = cmbTarih.DateTime;
                    stokVeri.FisKodu = txtFisKodu.Text;
                    stokVeri.Hareket = _fisEntity.FisTuru == "Alış Faturası" ? "Stok Giriş" : "Stok Çıkış";
                }

                foreach (var kasaVeri in context.KasaHareketleri.Local.ToList())
                {
                    kasaVeri.Tarih = kasaVeri.Tarih == null ? cmbTarih.DateTime : kasaVeri.Tarih;
                    kasaVeri.FisKodu = txtFisKodu.Text;
                    kasaVeri.Hareket = _fisEntity.FisTuru == "Alış Faturası" ? "Kasa Çıkış" : "Kasa Giriş";
                    kasaVeri.CariKodu = lblCariKodu.Text;
                    kasaVeri.CariAdi = lblCariAdi.Text;
                }

                _fisEntity.ToplamTutar = txtToplam.Value;
                _fisEntity.IskontoOrani = txtIskontoOrani.Value;
                _fisEntity.IskontoTutar = txtIskontoTutar.Value;
                fisDAL.AddOrUpdate(context, _fisEntity);
                context.SaveChanges();
            }
            
            
        }
    }
}