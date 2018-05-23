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

namespace SabzFara.BackOffice.Cari
{
    public partial class FrmCari : DevExpress.XtraEditors.XtraForm
    {
        SabzFaraContext _context = SabzFaraContext();
        CariDAL _caridal = new CariDAL();
        public FrmCari()
        {
            InitializeComponent();
        }

        private void btnFiltreKapat_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }

        private void btnFiltreIptal_Click(object sender, EventArgs e)
        {
            filterControl1.FilterString = null;
            filterControl1.ApplyFilter();
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            filterControl1.ApplyFilter();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void FrmCari_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            gridControl1.DataSource = _caridal.GetCariler(_context);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              string  secilen = gridView1.GetFocusedRowCellValue(colCariKodu).ToString();
                _caridal.Delete(_context, s => s.CariKodu == secilen);
                _caridal.Save(_context);
                GetAll();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}