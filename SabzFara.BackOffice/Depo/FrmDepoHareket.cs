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

namespace SabzFara.BackOffice.Depo
{
    public partial class FrmDepoHareket : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        StokHareketDAL stokHareketDAL = new StokHareketDAL();
       private string _depoKodu;

        public FrmDepoHareket(string depoKodu, string depoAdi)
        {
            InitializeComponent();
            _depoKodu = depoKodu;
            lblBaslik.Text = depoKodu + " - " + depoAdi + "Hareketleri";
        }

        private void FrmDepoHareket_Load(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void Guncelle()
        {
            gridContHareket.DataSource = stokHareketDAL.GetAll(context, c => c.DepoKodu == _depoKodu);
            gridContDepoStok.DataSource = stokHareketDAL.DepoStokListele(context,_depoKodu);
            gridContIstatistik.DataSource = stokHareketDAL.DepoIstatistikListele(context, _depoKodu);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (gridHareket.OptionsView.ShowAutoFilterRow == true)
            {
                gridHareket.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                gridHareket.OptionsView.ShowAutoFilterRow = true;
            }
        }
    }
}