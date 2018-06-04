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

namespace SabzFara.BackOffice.Personel
{
    public partial class FrmPersonelHareketleri : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        PersonelDAL personelDAL = new PersonelDAL();
        FisDAL fisDAL = new FisDAL();
        private string _personelKodu;
        public FrmPersonelHareketleri(string personelKodu,string personelAdi)
        {
            InitializeComponent();
            _personelKodu = personelKodu;
            lblBaslik.Text = personelKodu + "-" + personelAdi;
        }

        private void FrmPersonelHareketleri_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            gridContPersonelHareket .DataSource = fisDAL.GetAll(context, c => c.PlasiyerKodu == _personelKodu);
            gridContFisToplam.DataSource = personelDAL.PersonelFisToplam(context, _personelKodu);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            gridPersonelHareket.OptionsView.ShowAutoFilterRow = true ? gridPersonelHareket.OptionsView.ShowAutoFilterRow == false : gridPersonelHareket.OptionsView.ShowAutoFilterRow == true;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}