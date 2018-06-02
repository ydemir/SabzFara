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
    public partial class FrmDepoSec : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        DepoDAL depoDAL = new DepoDAL();
        public Entities.Tables.Depo entity = new Entities.Tables.Depo();
        private string _stokKodu;
        public bool secildi = false;

        public FrmDepoSec(string stokKodu)
        {
            InitializeComponent();
            _stokKodu = stokKodu;
        }

        private void FrmDepoSec_Load(object sender, EventArgs e)
        {
            gridContDepolar.DataSource = depoDAL.DepoBazindaStokListele(context, _stokKodu);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (gridDepolar.SelectedRowsCount!=0)
            {
                string depoKodu = gridDepolar.GetFocusedRowCellValue(colDepoKodu).ToString();
                entity = context.Depolar.SingleOrDefault(c => c.DepoKodu == depoKodu);
                secildi = true;
                this.Close();
            }
           
        }
    }
}