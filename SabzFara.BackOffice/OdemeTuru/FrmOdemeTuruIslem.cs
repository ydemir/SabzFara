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

namespace SabzFara.BackOffice.OdemeTuru
{
    public partial class FrmOdemeTuruIslem : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        OdemeTuruDAL odemeTuruDAL = new OdemeTuruDAL();
        private Entities.Tables.OdemeTuru _entity;
        public FrmOdemeTuruIslem(Entities.Tables.OdemeTuru entity)
        {
            InitializeComponent();
            _entity = entity;
            txtOdemeKodu.DataBindings.Add("Text", _entity, "OdemeTuruKodu");
            txtOdemeAdi.DataBindings.Add("Text", _entity, "OdemeTuruAdi");
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama");
        }

        private void FrmOdemeTuruIslem_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (odemeTuruDAL.AddOrUpdate(context,_entity))
            {
                odemeTuruDAL.Save(context);
                this.Close();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}