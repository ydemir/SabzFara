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
using SabzFara.Entities.Tables;

namespace SabzFara.BackOffice.Cari
{
    public partial class FrmCariSec : DevExpress.XtraEditors.XtraForm
    {
        CariDAL _cariDal = new CariDAL();
        SabzFaraContext _context = new SabzFaraContext();
        public List<Entities.Tables.Cari> _secilen = new List<Entities.Tables.Cari>();
        public bool secildi = false;
        public List<CariBakiye> secilenCariBakiye = new List<CariBakiye>();
        public FrmCariSec(bool cokluSecim = false)
        {
            InitializeComponent();
            if (cokluSecim)
            {
                lblUyari.Visible = true;
                gridView1.OptionsSelection.MultiSelect = true;

            }
        }

        private void FrmCariSec_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _cariDal.GetCariler(_context);
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (gridView1.GetSelectedRows().Length != 0)
            {
                foreach (var row in gridView1.GetSelectedRows())
                {
                    string cariKodu = gridView1.GetRowCellValue(row, colCariKodu).ToString();
                    _secilen.Add(_context.Cariler.SingleOrDefault(c => c.CariKodu == cariKodu));
                    secilenCariBakiye.Add(new CariBakiye
                    {
                        CariKodu= gridView1.GetRowCellValue(row, colCariKodu).ToString(),
                    Alacak = Convert.ToDecimal(gridView1.GetRowCellValue(row, colAlacak)),
                        Borc = Convert.ToDecimal(gridView1.GetRowCellValue(row, colBorc)),
                        Bakiye= Convert.ToDecimal(gridView1.GetRowCellValue(row, colBakiye))
                    });
                }
                secildi = true;
                this.Close();

            }
            else
            {
                MessageBox.Show("Seçilen bir cari bulunamadı.");
            }

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}