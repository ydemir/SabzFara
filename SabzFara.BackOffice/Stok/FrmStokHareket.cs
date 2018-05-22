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

namespace SabzFara.BackOffice.Stok
{
    public partial class FrmStokHareket : DevExpress.XtraEditors.XtraForm
    {
        StokDAL _stokDAL = new StokDAL();
        StokHareketDAL _stokHareketDAL = new StokHareketDAL();
        SabzFaraContext _context = new SabzFaraContext();
        private string _stokKodu;
        public FrmStokHareket(string stokKodu,string stokAdi)
        {
            InitializeComponent();
            _stokKodu = stokKodu;
            lblBaslik.Text = _stokKodu + " - " + stokAdi + " Hareketleri";

        }

        private void FrmStokHareket_Load(object sender, EventArgs e)
        {
            Guncelle();
        }
        private void Guncelle()
        {
            gridContStokHareket.DataSource = _stokHareketDAL.GetAll(_context, c => c.StokKodu == _stokKodu);
            gridContGenelStok.DataSource = _stokDAL.GetGenelStok(_context, _stokKodu);
            gridContDepoStok.DataSource = _stokDAL.GetDepoStok(_context, _stokKodu);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (gridStokHareket.OptionsView.ShowAutoFilterRow == true)
            {
                gridStokHareket.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                gridStokHareket.OptionsView.ShowAutoFilterRow = true;
            }
            


        }
    }
}