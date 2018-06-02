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

namespace SabzFara.BackOffice.OdemeTuru
{
    public partial class FrmOdemeTuruHareket : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        OdemeTuruDAL odemeTuruDAL = new OdemeTuruDAL();
        private string _odemeTuruKodu;
        public FrmOdemeTuruHareket(string odemeTuruKodu,string odemeTuruAdi)
        {
            InitializeComponent();
            _odemeTuruKodu = odemeTuruKodu;
            lblBaslik.Text = odemeTuruKodu + "-" + odemeTuruAdi + "Hareketleri";
        }

        private void FrmOdemeTuruHareket_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            gridContKasaHareket.DataSource = odemeTuruDAL.GetAll(context, c => c.OdemeTuruKodu==_odemeTuruKodu);
            gridContKasaBakiye.DataSource = odemeTuruDAL.KasaToplamListele(context, _odemeTuruKodu);
            gridContGenelToplam.DataSource = odemeTuruDAL.GenelToplamListele(context, _odemeTuruKodu);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            gridKasaHareket.OptionsView.ShowAutoFilterRow = false ? true : false;
            
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}