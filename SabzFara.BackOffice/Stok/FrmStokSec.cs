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
    public partial class FrmStokSec : DevExpress.XtraEditors.XtraForm
    {
        StokDAL _stokDal = new StokDAL();
        NetSatisContext _context = new NetSatisContext();
        public List<Entities.Tables.Stok> _secilen = new List<Entities.Tables.Stok>();
        public bool Secildi = false;
        public FrmStokSec(bool cokluSecim = false)
        {
            InitializeComponent();
            if (cokluSecim)
            {
                lblUyari.Visible = true;
                gridStoklar.OptionsSelection.MultiSelect = true;

            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStokSec_Load(object sender, EventArgs e)
        {
            gridContStoklar.DataSource = _stokDal.GetAllJoin(_context);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (gridStoklar.GetSelectedRows().Length != 0)
            {
                foreach (var row in gridStoklar.GetSelectedRows())
                {
                    string stokKodu = gridStoklar.GetRowCellValue(row, colStokKodu).ToString();
                    _secilen.Add(_context.Stoklar.SingleOrDefault(c => c.StokKodu == stokKodu));
                }

                Secildi = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seçilen bir ürün bulunamadı.");
            }

        }
    }
}