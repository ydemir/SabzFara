using SabzFara.Entities.Context;
using SabzFara.Entities.DataAccess;
using SabzFara.Entities.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SabzFara.BackOffice
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();

            using (var context = new SabzFaraContext())
            {
                context.Database.CreateIfNotExists();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SabzFaraContext context = new SabzFaraContext();
            CariDAL cariDAL = new CariDAL();
            Cari entity = new Cari
            {
                CariKodu="12345678",
                CariAdi="Yusuf Demir",
                YetkiliKisi="Yusuf",
                FaturaUnvani="Demir"
            };

            cariDAL.AddOrUpdate(context, entity);
            cariDAL.Save(context);
        }
    }
}
