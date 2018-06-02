using SabzFara.Entities.Context;
using SabzFara.Entities.DataAccess;
using System;
using System.Windows.Forms;

namespace SabzFara.BackOffice.Stok
{
    public partial class FrmStokIslem : Form
    {

        private Entities.Tables.Stok _entity;
        private StokDAL _stokDal = new StokDAL();
        private NetSatisContext _context = new NetSatisContext();
        public bool saved = false;
        public FrmStokIslem(Entities.Tables.Stok entity)
        {
            InitializeComponent();

            //Inject ettiğimiz entity ile kontrolleri veri kaynağına bağladık.
            _entity = entity;
            toggleDurumu.DataBindings.Add("EditValue", _entity, "Durumu");
            txtStokKodu.DataBindings.Add("Text", _entity, "StokKodu");
            txtBarkod.DataBindings.Add("Text", _entity, "Barkod");
            cbmBarkodTuru.DataBindings.Add("Text", _entity, "BarkodTuru");
            txtStokAdi.DataBindings.Add("Text", _entity, "StokAdi");
            btnBirimi.DataBindings.Add("Text", _entity, "Birimi");
            txtUreticiKodu.DataBindings.Add("Text", _entity, "UreticiKodu");
            txtGarantiSuresi.DataBindings.Add("Text", _entity, "GarantiSuresi");
            calcMaxStokMiktari.DataBindings.Add("Text", _entity, "MaxStokMiktari");
            calcMaxStokMiktari.DataBindings[0].FormattingEnabled = true;
            calcMaxStokMiktari.DataBindings[0].FormatString = "N3";

            calcMinStokMiktari.DataBindings.Add("Text", _entity, "MinStokMiktari");
            calcMinStokMiktari.DataBindings[0].FormattingEnabled = true;
            calcMinStokMiktari.DataBindings[0].FormatString = "N3";

            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama");
            btnStokGrubu.DataBindings.Add("Text", _entity, "StokGrubu");
            btnStokAltGrubu.DataBindings.Add("Text", _entity, "StokAltGrubu");
            btnMarka.DataBindings.Add("Text", _entity, "Marka");
            btnModel.DataBindings.Add("Text", _entity, "Modeli");
            btnOzelKod1.DataBindings.Add("Text", _entity, "OzelKod1");
            btnOzelKod2.DataBindings.Add("Text", _entity, "OzelKod2");
            btnOzelKod3.DataBindings.Add("Text", _entity, "OzelKod3");
            btnOzelKod4.DataBindings.Add("Text", _entity, "OzelKod4");

            calcAlisKdv.DataBindings.Add("Text", _entity, "AlisKdv");
            calcAlisKdv.DataBindings[0].FormattingEnabled = true;
            calcAlisKdv.DataBindings[0].FormatString = "'%'0";
            calcAlisKdv.DataBindings[0].DataSourceNullValue = "0";

            calcSatisKdv.DataBindings.Add("Text", _entity, "SatisKdv");
            calcSatisKdv.DataBindings[0].FormattingEnabled = true;
            calcSatisKdv.DataBindings[0].FormatString = "'%'0";

            calcAlisFiyat1.DataBindings.Add("Text", _entity, "AlisFiyati1");
            calcAlisFiyat1.DataBindings[0].FormattingEnabled = true;
            calcAlisFiyat1.DataBindings[0].FormatString = "C2";

            calcAlisFiyat2.DataBindings.Add("Text", _entity, "AlisFiyati2");
            calcAlisFiyat2.DataBindings[0].FormattingEnabled = true;
            calcAlisFiyat2.DataBindings[0].FormatString = "C2";

            calcAlisFiyat3.DataBindings.Add("Text", _entity, "AlisFiyati3");
            calcAlisFiyat3.DataBindings[0].FormattingEnabled = true;
            calcAlisFiyat3.DataBindings[0].FormatString = "C2";

            calcSatisFiyat1.DataBindings.Add("Text", _entity, "SatisFiyati1");
            calcSatisFiyat1.DataBindings[0].FormattingEnabled = true;
            calcSatisFiyat1.DataBindings[0].FormatString = "C2";

            calcSatisFiyat2.DataBindings.Add("Text", _entity, "SatisFiyati2");
            calcSatisFiyat2.DataBindings[0].FormattingEnabled = true;
            calcSatisFiyat2.DataBindings[0].FormatString = "C2";

            calcSatisFiyat3.DataBindings.Add("Text", _entity, "SatisFiyati3");
            calcSatisFiyat3.DataBindings[0].FormattingEnabled = true;
            calcSatisFiyat3.DataBindings[0].FormatString = "C2";
        }

        private void FrmStokIslem_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_stokDal.AddOrUpdate(_context, _entity))
            {
                _stokDal.Save(_context);
                this.Close();

            }
            
            
            
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
