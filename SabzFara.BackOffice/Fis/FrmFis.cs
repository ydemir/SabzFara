﻿using System;
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

namespace SabzFara.BackOffice.Fis
{
    public partial class FrmFis : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        FisDAL fisDAL = new FisDAL();
        KasaHareketDAL kasaHareketDAL = new KasaHareketDAL();
        StokHareketDAL stokHareketDAL = new StokHareketDAL();
        public FrmFis()
        {
            InitializeComponent();
        }

        private void FrmFis_Load(object sender, EventArgs e)
        {
            Listele();
        }
       void Listele()
        {
            context = new NetSatisContext();
            gridControl1.DataSource = fisDAL.GetAll(context);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void btnFiltreKapat_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            filterControl1.ApplyFilter();
        }

        private void btnFiltreIptal_Click(object sender, EventArgs e)
        {
            filterControl1.FilterString = null;
            filterControl1.ApplyFilter();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string secilen = gridView1.GetFocusedRowCellValue(colFisKodu).ToString();
                fisDAL.Delete(context, s => s.FisKodu == secilen);
                kasaHareketDAL.Delete(context, c => c.FisKodu == secilen);
                stokHareketDAL.Delete(context, c => c.FisKodu == secilen);
                fisDAL.Save(context);
                Listele();
            }
        }

    

        private void FisIslem_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFisIslem frm = new FrmFisIslem(null, e.Item.Caption);
            frm.ShowDialog();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
           string secilen = gridView1.GetFocusedRowCellValue(colFisKodu).ToString();
            Entities.Tables.Fis __fisEntity = new Entities.Tables.Fis();

            __fisEntity = fisDAL.GetByFilter(context, s => s.FisKodu == secilen);
            __fisEntity.Id = -1;

            __fisEntity.CariKodu = null;
            FrmFisIslem frm = new FrmFisIslem(__fisEntity.FisKodu);
            frm.ShowDialog();
            Listele();
        }
    }
}