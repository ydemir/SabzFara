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
using SabzFara.BackOffice.Kasa;
using SabzFara.Entities.Tables.OtherTables;

namespace SabzFara.BackOffice.Fis
{
    public partial class FrmFisIslem : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        FisDAL fisDAL = new FisDAL();
        StokHareketDAL stokHareketDal = new StokHareketDAL();
        FisAyarlari ayarlar = new FisAyarlari();
        KasaHareketDAL kasaHareketDal = new KasaHareketDAL();
        CariDAL cariDAL = new CariDAL();
        Entities.Tables.Fis _fisEntity = new Entities.Tables.Fis();
        CariBakiye entityBakiye = new CariBakiye();
        public FrmFisIslem(string fisKodu = null, string fisTuru = null)
        {
            InitializeComponent();
            if (fisKodu != null)
            {
                _fisEntity = context.Fisler.Where(c => c.FisKodu == fisKodu).SingleOrDefault();
                context.StokHareketleri.Where(c => c.FisKodu == fisKodu).Load();
                context.KasaHareketleri.Where(c => c.FisKodu == fisKodu).Load();

                toggleBakiyeTuru.IsOn = context.KasaHareketleri.Count(c => c.FisKodu == fisKodu && c.Hareket == "Kasa Giriş") == 0;

                if (_fisEntity.CariKodu != null)
                {
                    entityBakiye = this.cariDAL.CariBakiyesi(context, _fisEntity.CariKodu);
                    lblAlacak.Text = entityBakiye.Alacak.ToString("C2");
                    lblBorc.Text = entityBakiye.Borc.ToString("C2");
                    lblBakiye.Text = entityBakiye.Bakiye.ToString("C2");
                }



            }
            else
            {
                _fisEntity.FisTuru = fisTuru;
                _fisEntity.Tarih = DateTime.Now;
            }




            txtFisKodu.DataBindings.Add("Text", _fisEntity, "FisKodu", false, DataSourceUpdateMode.OnPropertyChanged);
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


            FisAyar();

            Toplamlar();
            OdenenTutarGuncelle();

            ButonlariYukle();
            
        }
        private void ButonlariYukle()
        {
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

            var PersonelSecimIptal = new CheckButton
            {
                Name = "Yok",
                Text = "Yok",
                GroupIndex = 1,
                Height = 48,
                Width = 125,
                Checked = _fisEntity.PlasiyerKodu==null
            };

            PersonelSecimIptal.Click += PersonelYukle_Click;
            flowPersonel.Controls.Add(PersonelSecimIptal);
            foreach (var item in context.Personeller.ToList())
            {
                var buton = new CheckButton
                {
                    Name = item.PersonelKodu,
                    Text = item.PersonelAdi,
                    GroupIndex = 1,
                    Height = 48,
                    Width = 125,
                    Checked=item.PersonelKodu==_fisEntity.PlasiyerKodu
                };

                buton.Click += PersonelYukle_Click;
                flowPersonel.Controls.Add(buton);
            }
        }

        private void PersonelYukle_Click(object sender, EventArgs e)
        {

            var buton = sender as SimpleButton;
            if (buton.Name == "Yok")
            {
                _fisEntity.PlasiyerKodu = buton.Name;
                _fisEntity.PlasiyerAdi = buton.Text;
            }
            else
            {
                _fisEntity.PlasiyerKodu = null;
                _fisEntity.PlasiyerAdi = null;
            }


        }
        private void FisAyar()
        {

            switch (_fisEntity.FisTuru)
            {
                case "Alış Faturası":
                    ayarlar.StokHareketi = "Stok Giriş";
                    ayarlar.KasaHareketi = "Kasa Çıkış";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = true;
                    lblBaslik.Appearance.ImageIndex = 0;
                    break;

                case "Perakende Satış Faturası":
                    ayarlar.StokHareketi = "Stok Çıkış";
                    ayarlar.KasaHareketi = "Kasa Giriş";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = true;
                    lblBaslik.Appearance.ImageIndex = 1;
                    break;
                case "Toptan Satış Faturası":
                    ayarlar.StokHareketi = "Stok Çıkış";
                    ayarlar.KasaHareketi = "Kasa Giriş";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = true;
                    lblBaslik.Appearance.ImageIndex = 2;
                    break;
                case "Alış İade Faturası":
                    ayarlar.StokHareketi = "Stok Çıkış";
                    ayarlar.KasaHareketi = "Kasa Giriş";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = true;
                    lblBaslik.Appearance.ImageIndex = 3;
                    break;
                case "Satış İade Satış Faturası":
                    ayarlar.StokHareketi = "Stok Giriş";
                    ayarlar.KasaHareketi = "Kasa Çıkış";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = true;
                    lblBaslik.Appearance.ImageIndex = 4;
                    break;
                case "Sayım Fazlası Fişi":
                    ayarlar.StokHareketi = "Stok Giriş";
                    lblBaslik.Appearance.ImageIndex = 5;
                    ayarlar.OdemeEkrani = false;
                    panelOdeme.Visible = false;
                    ayarlar.SatisEkrani = true;
                    navCariBilgi.Dispose();
                    NavOdemeEkrani.Dispose();
                    break;
                case "Sayım Eksiği Fişi":
                    ayarlar.StokHareketi = "Stok Çıkış";
                    panelOdeme.Visible = false;
                    ayarlar.OdemeEkrani = false;
                    ayarlar.SatisEkrani = true;
                    navCariBilgi.Dispose();
                    NavOdemeEkrani.Dispose();
                    lblBaslik.Appearance.ImageIndex = 6;
                    break;
                case "Stok Devir Fişi":
                    ayarlar.StokHareketi = "Stok Giriş";
                    panelOdeme.Visible = false;
                    ayarlar.OdemeEkrani = false;
                    ayarlar.SatisEkrani = true;
                    navCariBilgi.Dispose();
                    NavOdemeEkrani.Dispose();
                    lblBaslik.Appearance.ImageIndex = 7;
                    break;

                case "Tahsilat Fişi":
                    ayarlar.KasaHareketi = "Kasa Giriş";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = false;
                    NavSatisEkrani.Dispose();
                    panelOdeme.Visible = false;
                    PanelIskonto.Visible = false;
                    grpToplamlar.Height = 60;
                    panelToplam.Top = 20;
                    panelKDV.Visible = false;
                    navigationPane2.SelectedPage = NavOdemeEkrani;
                    break;
                case "Ödeme Fişi":
                    ayarlar.KasaHareketi = "Kasa Çıkış";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = false;
                    panelOdeme.Visible = false;
                    PanelIskonto.Visible = false;
                    panelKDV.Visible = false;
                    grpToplamlar.Height = 60;
                    panelToplam.Top = 20;
                    NavSatisEkrani.Dispose();
                    navigationPane2.SelectedPage = NavOdemeEkrani;
                    break;

                //Bu bölüme daha sonra bakılacak
                case "Cari Devir Fişi":
                    ayarlar.KasaHareketi = "Kasa Giriş";
                    ayarlar.OdemeEkrani = true;
                    ayarlar.SatisEkrani = false;
                    panelOdeme.Visible = false;
                    PanelIskonto.Visible = false;
                    panelKDV.Visible = false;
                    grpToplamlar.Height = 60;
                    panelToplam.Top = 20;
                    panelCariDevir.Visible = true;
                    txtFisKodu.Width = 175;
                    NavSatisEkrani.Dispose();
                    break;

            }
        }



        private void OdemeEkle_Click(object sender, EventArgs e)
        {
            var buton = (sender as SimpleButton);
            if (ayarlar.SatisEkrani == false)
            {
                FrmOdemeEkrani frm = new FrmOdemeEkrani(buton.Text, buton.Name);
                frm.ShowDialog();
                if (frm.entity != null)
                {
                    kasaHareketDal.AddOrUpdate(context, frm.entity);
                    OdenenTutarGuncelle();
                }

            }
            else
            {
                if (txtOdenmesiGereken.Value <= 0)
                {
                    MessageBox.Show("Ödenmesi gereken tutar zaten ödenmiş durumdadır.");
                }
                else
                {

                    Entities.Tables.KasaHareket entityKasaHareket = new KasaHareket
                    {
                        OdemeTuruKodu = buton.Name,
                        OdemeTuruAdi = buton.Text,
                        Tutar = txtOdenmesiGereken.Value
                    };
                    kasaHareketDal.AddOrUpdate(context, entityKasaHareket);
                    OdenenTutarGuncelle();
                }
            }



        }

        private void OdenenTutarGuncelle()
        {
            gridKasaHareket.UpdateSummary();
            if (ayarlar.SatisEkrani)
            {
                txtOdenenTutar.Value = Convert.ToDecimal(colTutar.SummaryItem.SummaryValue);
                txtOdenmesiGereken.Value = txtToplam.Value - txtOdenenTutar.Value;
            }
            else
            {
                txtToplam.Value = Convert.ToDecimal(colTutar.SummaryItem.SummaryValue);
            }
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

            barFiyat1.Tag = txtFisTuru.Text == "Alış Faturası" ? fiyatEntity.AlisFiyati1 ?? 0 : fiyatEntity.SatisFiyati1 ?? 0;
            barFiyat2.Tag = txtFisTuru.Text == "Alış Faturası" ? fiyatEntity.AlisFiyati2 ?? 0 : fiyatEntity.SatisFiyati2 ?? 0;
            barFiyat3.Tag = txtFisTuru.Text == "Alış Faturası" ? fiyatEntity.AlisFiyati3 ?? 0 : fiyatEntity.SatisFiyati3 ?? 0;

            barFiyat1.Caption = string.Format("{0:C2}", barFiyat1.Tag);
            barFiyat2.Caption = string.Format("{0:C2}", barFiyat2.Tag);
            barFiyat3.Caption = string.Format("{0:C2}", barFiyat3.Tag);

            radialFiyat.ShowPopup(MousePosition);
        }

        private void FiyatSec(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridStokHareket.SetFocusedRowCellValue(colBirimFiyati, Convert.ToDecimal(e.Item.Tag));
        }


        private void repoSeriNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string veri = Convert.ToString(gridStokHareket.GetFocusedRowCellValue(colSeriNo));
            FrmSeriNoGir frm = new FrmSeriNoGir(veri);
            frm.ShowDialog();

            gridStokHareket.SetFocusedRowCellValue(colSeriNo, frm.veriSeriNo);
        }

        private void repoSil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridStokHareket.DeleteSelectedRows();
            }
            Toplamlar();
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
            if (toggleBakiyeTuru.IsOn)
            {
                ayarlar.KasaHareketi = "Kasa Çıkış";

            }
            else
            {
                ayarlar.KasaHareketi = "Kasa Giriş";
            }

            int StokHata = context.StokHareketleri.Local.Where(c => c.DepoKodu == null).Count();
            int KasaHata = context.StokHareketleri.Local.Where(c => c.DepoKodu == null).Count();

            string message = null;
            int hata = 0;

            if (gridStokHareket.RowCount == 0 && ayarlar.SatisEkrani)
            {
                message += "Satış Ekranında eklenmiş ürün bulunamadı." + System.Environment.NewLine;
                hata++;
            }
            if (string.IsNullOrEmpty(_fisEntity.CariKodu) && ayarlar.SatisEkrani == false)
            {
                message += txtFisTuru.Text + " türünde cari seçimi zorunludur.  " + System.Environment.NewLine;
                hata++;
            }
            if (gridKasaHareket.RowCount == 0 && ayarlar.SatisEkrani == false)
            {
                message += txtFisTuru.Text + " herhangi bir ödeme bulunamadı.  " + System.Environment.NewLine;
                hata++;
            }
            if (txtFisKodu.Text == string.Empty)
            {
                message += "Fiş kodu alanı boş geçilemez" + System.Environment.NewLine;
                hata++;
            }
            if (txtOdenmesiGereken.Value != 0 && ayarlar.OdemeEkrani)
            {
                message += "Ödenmesi gereken tutar ödenmemiş gözüküyor." + System.Environment.NewLine;
                hata++;
            }

            if (StokHata != 0)
            {
                message += "Satış ekranındaki ürünlerin depo seçimlerinde eksiklikler var" + System.Environment.NewLine;
                hata++;
            }
            if (KasaHata != 0)
            {
                message += "Ödeme ekranındaki ürünlerin Kasa seçimlerinde eksiklikler var";
                hata++;
            }

            if (hata != 0)
            {
                MessageBox.Show(message);
                return;
            }




            foreach (var stokVeri in context.StokHareketleri.Local.ToList())
            {
                stokVeri.Tarih = cmbTarih.DateTime;
                stokVeri.FisKodu = txtFisKodu.Text;
                stokVeri.Hareket = ayarlar.StokHareketi;
            }


            if (ayarlar.OdemeEkrani)
            {
                foreach (var kasaVeri in context.KasaHareketleri.Local.ToList())
                {
                    kasaVeri.Tarih = kasaVeri.Tarih == null ? cmbTarih.DateTime : kasaVeri.Tarih;
                    kasaVeri.FisKodu = txtFisKodu.Text;
                    kasaVeri.Hareket = ayarlar.KasaHareketi;
                    kasaVeri.CariKodu = lblCariKodu.Text;
                    kasaVeri.CariAdi = lblCariAdi.Text;
                }
            }

            _fisEntity.ToplamTutar = txtToplam.Value;
            _fisEntity.IskontoOrani = txtIskontoOrani.Value;
            _fisEntity.IskontoTutar = txtIskontoTutar.Value;
            fisDAL.AddOrUpdate(context, _fisEntity);
            context.SaveChanges();

            this.Close();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridStokHareket.RowCount != 0)
            {
                if (MessageBox.Show("Satış Ekranına eklenmiş ürünler var Bu işlemi iptal edip formu kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }

            }
            else
            {
                this.Close();
            }

        }

     
    }
}