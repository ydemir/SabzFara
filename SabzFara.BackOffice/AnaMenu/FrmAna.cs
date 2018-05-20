using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using SabzFara.BackOffice.Stok;

namespace SabzFara.BackOffice.AnaMenu
{
    public partial class FrmAna : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmAna()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmStok frm = new FrmStok();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}