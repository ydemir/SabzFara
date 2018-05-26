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

namespace SabzFara.BackOffice.Cari
{
    public partial class FrmCariHareket : DevExpress.XtraEditors.XtraForm
    {
        CariDAL _cariDal = new CariDAL();
        SabzFaraContext _context = new SabzFaraContext();

        private string _cariKodu = null;
        public FrmCariHareket(string cariKodu,string cariAdi)
        {
            InitializeComponent();
            _cariKodu = cariKodu;
            lblBaslik.Text = _cariKodu + " - " + cariAdi + " Hareketleri";
        }

        private void FrmCariHareket_Load(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void Guncelle()
        {
            gridContFisToplam.DataSource = _cariDal.CariFisGenelToplam(_context, _cariKodu);
            gridContBakiye.DataSource = _cariDal.CariGenelToplam(_context, _cariKodu);
            gridContCariHareket.DataSource= _cariDal.CariFisAyrinti(_context, _cariKodu);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (gridCariHareket.OptionsView.ShowAutoFilterRow == true)
            {
                gridCariHareket.OptionsView.ShowAutoFilterRow = false;
            }
            else
            {
                gridCariHareket.OptionsView.ShowAutoFilterRow = true;
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}