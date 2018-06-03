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

namespace SabzFara.BackOffice.Tanim
{
    public partial class FrmTanim : DevExpress.XtraEditors.XtraForm
    {
        NetSatisContext context = new NetSatisContext();
        TanimDAL tanimDAL = new TanimDAL();
        private TanimTuru _tanimTuru;
        public Entities.Tables.Tanim _entity = new Entities.Tables.Tanim();
        public bool Secildi = false;
        public FrmTanim(TanimTuru tanimTuru)
      
        {
            InitializeComponent();
            _tanimTuru = tanimTuru;
            txtTanim.DataBindings.Add("Text", _entity, "Tanimi");
            txtAciklama.DataBindings.Add("Text", _entity, "Aciklama");
        }

        public enum TanimTuru
        {
            CariGrubu,
            CariAltGrubu,
            CariOzelKod1,
            CariOzelKod2,
            CariOzelKod3,
            CariOzelKod4,
            PersonelUnvan
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
           
            _entity = new Entities.Tables.Tanim();
            KayitAc();
        }

        private void FrmTanim_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void KayitAc()
        {
            btnSec.Enabled = false;
            btnEkle.Enabled = false;
            btnDuzenle.Enabled = false;
            btnSil.Enabled = false;
            btnKaydet.Enabled = true;
            btnVazgec.Enabled = true;

            navigationFrame1.SelectedPage = navigationPage1;
        

        }
        void KayitKapat()
        {
            btnSec.Enabled = true;
            btnEkle.Enabled = true;
            btnDuzenle.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            btnVazgec.Enabled = false;
            navigationFrame1.SelectedPage = navigationPage2;
        }

        void Listele()
        {
            gridContTanim.DataSource = tanimDAL.GetAll(context, c => c.Turu == _tanimTuru.ToString());
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
           
            int secilen = (int)gridTanim.GetFocusedRowCellValue(colId);
            _entity = context.Tanimlar.Where(c => c.Id == secilen).Single();
            KayitAc();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili olan veriyi silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var secilen = (int)gridTanim.GetFocusedRowCellValue(colId);
                tanimDAL.Delete(context, s => s.Id == secilen);
                tanimDAL.Save(context);
                Listele();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            _entity.Tanimi = txtTanim.Text;
            _entity.Turu = _tanimTuru.ToString();
            if (tanimDAL.AddOrUpdate(context, _entity))
            {
                tanimDAL.Save(context);
                KayitKapat();
                Listele();
            }
          
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            KayitKapat();
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            int secilen = (int)gridTanim.GetFocusedRowCellValue(colId);
            _entity = context.Tanimlar.Where(c => c.Id == secilen).SingleOrDefault();
            Secildi = true;
            this.Close();
        }
    }
}