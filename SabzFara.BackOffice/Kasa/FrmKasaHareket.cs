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
using SabzFara.Entities.DataAccess;
using SabzFara.Entities.Context;

namespace SabzFara.BackOffice.Kasa
{
    public partial class FrmKasaHareket : DevExpress.XtraEditors.XtraForm
    {
        KasaDAL kasaDAL = new KasaDAL();
        NetSatisContext context = new NetSatisContext();
        private string _kasaKodu;
        public FrmKasaHareket(string kasaKodu, string kasaAdi)
        {
            InitializeComponent();
            _kasaKodu = kasaKodu;
            lblBaslik.Text = kasaKodu + " - " + kasaKodu + "Hareketleri";
        }

        private void FrmKasaHareket_Load(object sender, EventArgs e)
        {

        }
        public void Guncelle()
        {
            gridContKasaHareket.DataSource = kasaDAL.GetAll(context,k=>k.KasaKodu==_kasaKodu);
            gridContOdemeToplam.DataSource = kasaDAL.OdemeTuruToplamListele(context, _kasaKodu);
            gridContGenelToplam.DataSource = kasaDAL.GenelToplamListele(context, _kasaKodu);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (gridKasaHareket.OptionsView.ShowAutoFilterRow == true)
            {
                gridKasaHareket.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                gridKasaHareket.OptionsView.ShowAutoFilterRow = true;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

   
}