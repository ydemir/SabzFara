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

namespace SabzFara.BackOffice.Personel
{
    public partial class FrmPersonel : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        PersonelDAL personelDAL = new PersonelDAL();

        private string secilen = null;
        public FrmPersonel()
        {
            InitializeComponent();
        }

        private void Listele()
        {
            gridContPersonel.DataSource = personelDAL.PersonelListele(context);
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
        }

        private void btnFiltreKapat_Click(object sender, EventArgs e)
        {
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            secilen = gridPersonel.GetFocusedRowCellValue(colPersonelKodu).ToString();
            if (MessageBox.Show("Seçili olan kaydı silmek istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                personelDAL.Delete(context, c => c.PersonelKodu == secilen);
                personelDAL.Save(context);
                Listele();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmPersonelIslem frm = new FrmPersonelIslem(new Entities.Tables.Personel());
            frm.ShowDialog();
            if (frm.saved)
            {
                Listele();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            secilen = gridPersonel.GetFocusedRowCellValue(colPersonelKodu).ToString();
            FrmPersonelIslem frm = new FrmPersonelIslem(personelDAL.GetByFilter(context, s => s.PersonelKodu == secilen));
            frm.ShowDialog();
            if (frm.saved)
            {
                Listele();
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnCariHareket_Click(object sender, EventArgs e)
        {
            secilen = gridPersonel.GetFocusedRowCellValue(colPersonelKodu).ToString();
            FrmPersonelHareketleri frm = new FrmPersonelHareketleri(secilen, gridPersonel.GetFocusedRowCellValue(colPersonelAdi).ToString());
            frm.ShowDialog();
        }
    }
}