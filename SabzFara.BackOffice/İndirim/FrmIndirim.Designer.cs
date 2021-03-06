﻿namespace SabzFara.BackOffice.İndirim
{
    partial class FrmIndirim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIndirim));
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.gridContIndirim = new DevExpress.XtraGrid.GridControl();
            this.ındirimBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridIndirim = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurumu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarkod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndirimTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaslangicTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBitisTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndirimOrani = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpMenu = new DevExpress.XtraEditors.GroupControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAra = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnDurumu = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridContIndirim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ındirimBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIndirim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMenu)).BeginInit();
            this.grpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaslik.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblBaslik.Appearance.Image")));
            this.lblBaslik.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseImage = true;
            this.lblBaslik.Appearance.Options.UseImageAlign = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(1325, 47);
            this.lblBaslik.TabIndex = 7;
            this.lblBaslik.Text = "İndirimler";
            // 
            // gridContIndirim
            // 
            this.gridContIndirim.DataSource = this.ındirimBindingSource;
            this.gridContIndirim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContIndirim.Location = new System.Drawing.Point(0, 47);
            this.gridContIndirim.MainView = this.gridIndirim;
            this.gridContIndirim.Name = "gridContIndirim";
            this.gridContIndirim.Size = new System.Drawing.Size(1325, 534);
            this.gridContIndirim.TabIndex = 8;
            this.gridContIndirim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridIndirim});
            // 
            // ındirimBindingSource
            // 
            this.ındirimBindingSource.DataSource = typeof(SabzFara.Entities.Tables.Indirim);
            // 
            // gridIndirim
            // 
            this.gridIndirim.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colDurumu,
            this.colStokKodu,
            this.colBarkod,
            this.colStokAdi,
            this.colIndirimTuru,
            this.colBaslangicTarihi,
            this.colBitisTarihi,
            this.colIndirimOrani,
            this.colAciklama});
            this.gridIndirim.GridControl = this.gridContIndirim;
            this.gridIndirim.Name = "gridIndirim";
            this.gridIndirim.OptionsView.ShowGroupPanel = false;
            this.gridIndirim.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridIndirim_SelectionChanged);
            this.gridIndirim.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridIndirim_FocusedRowChanged);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colDurumu
            // 
            this.colDurumu.FieldName = "Durumu";
            this.colDurumu.Name = "colDurumu";
            this.colDurumu.OptionsColumn.AllowEdit = false;
            this.colDurumu.Visible = true;
            this.colDurumu.VisibleIndex = 0;
            // 
            // colStokKodu
            // 
            this.colStokKodu.FieldName = "StokKodu";
            this.colStokKodu.Name = "colStokKodu";
            this.colStokKodu.OptionsColumn.AllowEdit = false;
            this.colStokKodu.Visible = true;
            this.colStokKodu.VisibleIndex = 1;
            // 
            // colBarkod
            // 
            this.colBarkod.FieldName = "Barkod";
            this.colBarkod.Name = "colBarkod";
            this.colBarkod.OptionsColumn.AllowEdit = false;
            this.colBarkod.Visible = true;
            this.colBarkod.VisibleIndex = 2;
            // 
            // colStokAdi
            // 
            this.colStokAdi.FieldName = "StokAdi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.OptionsColumn.AllowEdit = false;
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 3;
            // 
            // colIndirimTuru
            // 
            this.colIndirimTuru.FieldName = "IndirimTuru";
            this.colIndirimTuru.Name = "colIndirimTuru";
            this.colIndirimTuru.OptionsColumn.AllowEdit = false;
            this.colIndirimTuru.Visible = true;
            this.colIndirimTuru.VisibleIndex = 4;
            // 
            // colBaslangicTarihi
            // 
            this.colBaslangicTarihi.FieldName = "BaslangicTarihi";
            this.colBaslangicTarihi.Name = "colBaslangicTarihi";
            this.colBaslangicTarihi.OptionsColumn.AllowEdit = false;
            this.colBaslangicTarihi.Visible = true;
            this.colBaslangicTarihi.VisibleIndex = 5;
            // 
            // colBitisTarihi
            // 
            this.colBitisTarihi.FieldName = "BitisTarihi";
            this.colBitisTarihi.Name = "colBitisTarihi";
            this.colBitisTarihi.OptionsColumn.AllowEdit = false;
            this.colBitisTarihi.Visible = true;
            this.colBitisTarihi.VisibleIndex = 6;
            // 
            // colIndirimOrani
            // 
            this.colIndirimOrani.FieldName = "IndirimOrani";
            this.colIndirimOrani.Name = "colIndirimOrani";
            this.colIndirimOrani.OptionsColumn.AllowEdit = false;
            this.colIndirimOrani.Visible = true;
            this.colIndirimOrani.VisibleIndex = 7;
            // 
            // colAciklama
            // 
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 8;
            // 
            // grpMenu
            // 
            this.grpMenu.Controls.Add(this.btnKapat);
            this.grpMenu.Controls.Add(this.btnAra);
            this.grpMenu.Controls.Add(this.btnGuncelle);
            this.grpMenu.Controls.Add(this.btnSil);
            this.grpMenu.Controls.Add(this.btnDurumu);
            this.grpMenu.Controls.Add(this.btnEkle);
            this.grpMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpMenu.Location = new System.Drawing.Point(0, 581);
            this.grpMenu.Name = "grpMenu";
            this.grpMenu.Size = new System.Drawing.Size(1325, 74);
            this.grpMenu.TabIndex = 9;
            this.grpMenu.Text = "Menü";
            // 
            // btnKapat
            // 
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKapat.ImageOptions.ImageIndex = 5;
            this.btnKapat.ImageOptions.ImageList = this.ımageList1;
            this.btnKapat.Location = new System.Drawing.Point(1240, 20);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(83, 52);
            this.btnKapat.TabIndex = 0;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "add.png");
            this.ımageList1.Images.SetKeyName(1, "clock_run.png");
            this.ımageList1.Images.SetKeyName(2, "delete.png");
            this.ımageList1.Images.SetKeyName(3, "düzenle.png");
            this.ımageList1.Images.SetKeyName(4, "ekle.png");
            this.ımageList1.Images.SetKeyName(5, "folder_out.png");
            this.ımageList1.Images.SetKeyName(6, "pencil.png");
            this.ımageList1.Images.SetKeyName(7, "remotecontrol2.png");
            this.ımageList1.Images.SetKeyName(8, "replace2.png");
            this.ımageList1.Images.SetKeyName(9, "sil.png");
            this.ımageList1.Images.SetKeyName(10, "sort_descending.png");
            this.ımageList1.Images.SetKeyName(11, "stopwatch_run.png");
            this.ımageList1.Images.SetKeyName(12, "view.png");
            this.ımageList1.Images.SetKeyName(13, "download.png");
            this.ımageList1.Images.SetKeyName(14, "download (1).png");
            this.ımageList1.Images.SetKeyName(15, "checkbox-checked-md.png");
            // 
            // btnAra
            // 
            this.btnAra.ImageOptions.ImageIndex = 12;
            this.btnAra.ImageOptions.ImageList = this.ımageList1;
            this.btnAra.Location = new System.Drawing.Point(387, 26);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(88, 44);
            this.btnAra.TabIndex = 0;
            this.btnAra.Text = "Ara";
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.ImageOptions.ImageIndex = 8;
            this.btnGuncelle.ImageOptions.ImageList = this.ımageList1;
            this.btnGuncelle.Location = new System.Drawing.Point(293, 26);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(88, 44);
            this.btnGuncelle.TabIndex = 0;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.ImageOptions.ImageIndex = 9;
            this.btnSil.ImageOptions.ImageList = this.ımageList1;
            this.btnSil.Location = new System.Drawing.Point(199, 26);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(88, 44);
            this.btnSil.TabIndex = 0;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnDurumu
            // 
            this.btnDurumu.ImageOptions.ImageIndex = 15;
            this.btnDurumu.ImageOptions.ImageList = this.ımageList1;
            this.btnDurumu.Location = new System.Drawing.Point(105, 26);
            this.btnDurumu.Name = "btnDurumu";
            this.btnDurumu.Size = new System.Drawing.Size(88, 44);
            this.btnDurumu.TabIndex = 0;
            this.btnDurumu.Text = "Pasif Yap";
            this.btnDurumu.Click += new System.EventHandler(this.btnDurumu_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.ImageOptions.ImageIndex = 4;
            this.btnEkle.ImageOptions.ImageList = this.ımageList1;
            this.btnEkle.Location = new System.Drawing.Point(12, 26);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(87, 44);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // FrmIndirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 655);
            this.Controls.Add(this.gridContIndirim);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.grpMenu);
            this.Name = "FrmIndirim";
            this.Text = "FrmIndirim";
            this.Load += new System.EventHandler(this.FrmIndirim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridContIndirim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ındirimBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIndirim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMenu)).EndInit();
            this.grpMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraGrid.GridControl gridContIndirim;
        private DevExpress.XtraGrid.Views.Grid.GridView gridIndirim;
        private DevExpress.XtraEditors.GroupControl grpMenu;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private System.Windows.Forms.ImageList ımageList1;
        private DevExpress.XtraEditors.SimpleButton btnAra;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnDurumu;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private System.Windows.Forms.BindingSource ındirimBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDurumu;
        private DevExpress.XtraGrid.Columns.GridColumn colStokKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colBarkod;
        private DevExpress.XtraGrid.Columns.GridColumn colStokAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colIndirimTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colBaslangicTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colBitisTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colIndirimOrani;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
    }
}