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
    public partial class FrmCariIslem : DevExpress.XtraEditors.XtraForm
    {
        private Entities.Tables.Cari _entity;
        private CariDAL _cariDal = new CariDAL();
        private SabzFaraContext _context = new SabzFaraContext();
        public FrmCariIslem(Entities.Tables.Cari entity)
        {
            InitializeComponent();
            _entity = entity;


            toggleDurumu.DataBindings.Add("EditValue", _entity, "Durumu");
            txtCariKodu.DataBindings.Add("Text", _entity, "CariKodu");
            txtCariAdi.DataBindings.Add("Text", _entity, "CariAdi");
            cbmCariTuru.DataBindings.Add("Text", _entity, "CariTuru");
            txtYetkiliKisi.DataBindings.Add("Text", _entity, "YetkiliKisi");
            txtFaturaUnvani.DataBindings.Add("Text", _entity, "FaturaUnvani");
            txtVergiDairesi.DataBindings.Add("Text", _entity, "VergiDairesi");
            txtVergiNo.DataBindings.Add("Text", _entity, "VergiNo");
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama");
            txtCepTel.DataBindings.Add("Text", _entity, "CepTelefonu");
            txtSabitTelefon.DataBindings.Add("Text", _entity, "Telefon");
            txtFax.DataBindings.Add("Text", _entity, "Fax");
            txtEmail.DataBindings.Add("Text", _entity, "Email");
            txtWeb.DataBindings.Add("Text", _entity, "Web");
            txtIl.DataBindings.Add("Text", _entity, "Il");
            txtIlce.DataBindings.Add("Text", _entity, "Ilce");
            txtSemt.DataBindings.Add("Text", _entity, "Semt");
            txtAdres.DataBindings.Add("Text", _entity, "Adres");
            btnCariGrubu.DataBindings.Add("Text", _entity, "CariGrubu");
            btnCariAltGrubu.DataBindings.Add("Text", _entity, "CariAltGrubu");
            btnOzelKod1.DataBindings.Add("Text", _entity, "OzelKod1");
            btnOzelKod2.DataBindings.Add("Text", _entity, "OzelKod2");
            btnOzelKod3.DataBindings.Add("Text", _entity, "OzelKod3");
            btnOzelKod4.DataBindings.Add("Text", _entity, "OzelKod4");
            cmbAlisOzelFiyati.DataBindings.Add("Text", _entity, "AlisOzelFiyat");
            cmbSatisOzelFiyati.DataBindings.Add("Text", _entity, "SatisOzelFiyat");

            txtIskontoOrani.DataBindings.Add("Text", _entity, "IskontoOrani");
            txtIskontoOrani.DataBindings[0].FormattingEnabled = true;
            txtIskontoOrani.DataBindings[0].FormatString = "'%'0";

            txtRiskLimiti.DataBindings.Add("Text", _entity, "RiskLimiti");
            txtRiskLimiti.DataBindings[0].FormattingEnabled = true;
            txtRiskLimiti.DataBindings[0].FormatString = "C2";
            txtRiskLimiti.DataBindings[0].DataSourceNullValue = "0";

        }

        private void FrmCariIslem_Load(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_cariDal.AddOrUpdate(_context,_entity))
            {
                _cariDal.Save(_context);
                this.Close();
            }
        }
    }
}