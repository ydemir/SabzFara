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
    public partial class FrmKasaSec : DevExpress.XtraEditors.XtraForm
    {
        KasaDAL kasaDAL = new KasaDAL();
        SabzFaraContext context = new SabzFaraContext();
        public Entities.Tables.Kasa entity = new Entities.Tables.Kasa();
        public FrmKasaSec()
        {
            InitializeComponent();
        }

        private void FrmKasaSec_Load(object sender, EventArgs e)
        {
            gridContSecim.DataSource = kasaDAL.KasaListele(context);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            string kasaKodu = gridView1.GetFocusedRowCellValue(colKasaKodu).ToString();
          entity=  context.Kasalar.SingleOrDefault(c => c.KasaKodu == kasaKodu);
            this.Close();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}