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
using SabzFara.BackOffice.Kasa;
using SabzFara.Entities.Tables;

namespace SabzFara.BackOffice.Fis
{
    public partial class FrmOdemeEkrani : DevExpress.XtraEditors.XtraForm
    {
        public KasaHareket entity;
        private string _odemeTuruKodu;
        public FrmOdemeEkrani(string odemeTuru,string odemeTuruKodu)
        {
            InitializeComponent();
            txtOdemeTuru.Text = odemeTuru;
            _odemeTuruKodu = odemeTuruKodu;

        }

        private void FrmOdemeEkrani_Load(object sender, EventArgs e)
        {

        }

        private void btnKasaSec_Click(object sender, EventArgs e)
        {
            FrmKasaSec frm = new FrmKasaSec();
            frm.ShowDialog();
            if (frm.secildi)
            {
                txtKasaKodu.Text = frm.entity.KasaKodu;
                txtKasaAdi.Text = frm.entity.KasaAdi;
            }
         
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string message = null;
            int error = 0;
            if (txtKasaAdi.Text=="")
            {
                message += "Kasa bilgileri boş bırakılamaz." + System.Environment.NewLine;
                error++;

            }
            if (txtTutar.Value<=0)
            {
                message += "Tutar 0 değerine eşit ve 0 değerinden küçük olamaz." + System.Environment.NewLine;
                error++;
            }
            if (error!=0)
            {
                MessageBox.Show(message);
                return;
            }
            entity = new KasaHareket();
            entity.OdemeTuruKodu = _odemeTuruKodu;
            entity.OdemeTuruAdi = txtOdemeTuru.Text;
            entity.KasaKodu = txtKasaKodu.Text;
            entity.KasaAdi = txtKasaAdi.Text;
            entity.Tutar = txtTutar.Value;
            entity.Aciklama = txtAciklama.Text;
            this.Close();
            
        }
    }
}