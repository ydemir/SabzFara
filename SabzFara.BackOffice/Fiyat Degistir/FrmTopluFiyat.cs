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
using SabzFara.BackOffice.Stok;
using SabzFara.Entities.Context;
using SabzFara.Entities.DataAccess;
using System.Data.Entity;

namespace SabzFara.BackOffice.Fiyat_Degistir
{
    public partial class FrmTopluFiyat : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        StokDAL stokDAL = new StokDAL();
        public FrmTopluFiyat()
        {
            InitializeComponent();
            Listele();
        }
        private void Listele()
        {
            gridControl1.DataSource = context.Stoklar.Local.ToBindingList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmStokSec frm = new FrmStokSec(true);
            frm.ShowDialog();
            if (frm.Secildi)
            {
                foreach (var itemStok in frm._secilen)
                {
                    stokDAL.AddOrUpdate(context, itemStok);
                }
            }
        }

        private void btnDegisiklikKaydet_Click(object sender, EventArgs e)
        {
            stokDAL.Save(context);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            var secilen = gridView1.GetFocusedRowCellValue(colStokKodu).ToString();
            var result = stokDAL.GetByFilter(context, c => c.StokKodu == secilen);

            context.Entry(result).State = EntityState.Detached;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            gridView1.OptionsView.ShowAutoFilterRow = true ? gridView1.OptionsView.ShowAutoFilterRow == false : gridView1.OptionsView.ShowAutoFilterRow == true;
        }

        private void btnFiyatDegistir_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount==0)
            {
                MessageBox.Show("Seçilen bir stok bulunamadı");
                return;
            }
            FrmFiyatDegistir frm = new FrmFiyatDegistir();
            frm.ShowDialog();
            if (frm.secildi)
            {
                foreach (var itemDegistir in frm.list)
                {
                    if (itemDegistir.Degistir)
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            decimal kolonDeger = 0;
                            decimal degisen = 0;
                            kolonDeger = Convert.ToDecimal(gridView1.GetRowCellValue(i, itemDegistir.KolonAdi));
                            if (itemDegistir.DegisimTuru=="Yüzde")
                            {
                                degisen =itemDegistir.DegisimYonu=="Arttır" 
                                    ? kolonDeger + kolonDeger / 100 * itemDegistir.Degeri
                                    : kolonDeger - kolonDeger / 100 * itemDegistir.Degeri;
                            }
                            else
                            {
                                degisen = itemDegistir.DegisimYonu == "Arttır"
                                    ? kolonDeger +itemDegistir.Degeri
                                    : kolonDeger -  itemDegistir.Degeri;
                            }
                            gridView1.SetRowCellValue(i, itemDegistir.KolonAdi, degisen);
                        }
                    }
                }
            }
        }
    }
}