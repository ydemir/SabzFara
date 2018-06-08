namespace SabzFara.BackOffice.Fiyat_Degistir
{
    partial class FrmFiyatDegistir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFiyatDegistir));
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.grpMenu = new DevExpress.XtraEditors.GroupControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFiyatTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKolonAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDegistir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoDegistir = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.colDegisimTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoDegisimTuru = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colDegisimYonu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoDegisimYonu = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colDegeri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoDegisimMiktari = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMenu)).BeginInit();
            this.grpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDegistir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDegisimTuru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDegisimYonu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDegisimMiktari)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaslik.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblBaslik.Appearance.Image")));
            this.lblBaslik.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaslik.Appearance.ImageIndex = 2;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseImage = true;
            this.lblBaslik.Appearance.Options.UseImageAlign = true;
            this.lblBaslik.Appearance.Options.UseImageIndex = true;
            this.lblBaslik.Appearance.Options.UseTextOptions = true;
            this.lblBaslik.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(588, 47);
            this.lblBaslik.TabIndex = 4;
            this.lblBaslik.Text = "Toplu Fiyat Değiştir";
            // 
            // grpMenu
            // 
            this.grpMenu.Controls.Add(this.btnKapat);
            this.grpMenu.Controls.Add(this.btnKaydet);
            this.grpMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpMenu.Location = new System.Drawing.Point(0, 377);
            this.grpMenu.Name = "grpMenu";
            this.grpMenu.Size = new System.Drawing.Size(588, 74);
            this.grpMenu.TabIndex = 5;
            this.grpMenu.Text = "Menü";
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.ImageOptions.ImageIndex = 1;
            this.btnKapat.ImageOptions.ImageList = this.ımageList1;
            this.btnKapat.Location = new System.Drawing.Point(505, 25);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(83, 44);
            this.btnKapat.TabIndex = 0;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "floppy_disk.png");
            this.ımageList1.Images.SetKeyName(1, "folder_out.png");
            this.ımageList1.Images.SetKeyName(2, "money2_edit.png");
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.ImageOptions.ImageIndex = 0;
            this.btnKaydet.ImageOptions.ImageList = this.ımageList1;
            this.btnKaydet.Location = new System.Drawing.Point(414, 25);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(83, 44);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 47);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoDegistir,
            this.repoDegisimTuru,
            this.repoDegisimYonu,
            this.repoDegisimMiktari});
            this.gridControl1.Size = new System.Drawing.Size(588, 330);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFiyatTuru,
            this.colKolonAdi,
            this.colDegistir,
            this.colDegisimTuru,
            this.colDegisimYonu,
            this.colDegeri});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colFiyatTuru
            // 
            this.colFiyatTuru.Caption = "Fiyat Türü";
            this.colFiyatTuru.FieldName = "FiyatTuru";
            this.colFiyatTuru.Name = "colFiyatTuru";
            this.colFiyatTuru.OptionsColumn.AllowEdit = false;
            this.colFiyatTuru.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colFiyatTuru.Visible = true;
            this.colFiyatTuru.VisibleIndex = 0;
            // 
            // colKolonAdi
            // 
            this.colKolonAdi.Caption = "Kolon Adı";
            this.colKolonAdi.FieldName = "KolonAdi";
            this.colKolonAdi.Name = "colKolonAdi";
            this.colKolonAdi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colKolonAdi.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colDegistir
            // 
            this.colDegistir.Caption = "Fiyat Değiştirilecek Mi?";
            this.colDegistir.ColumnEdit = this.repoDegistir;
            this.colDegistir.FieldName = "Degistir";
            this.colDegistir.Name = "colDegistir";
            this.colDegistir.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDegistir.Visible = true;
            this.colDegistir.VisibleIndex = 1;
            // 
            // repoDegistir
            // 
            this.repoDegistir.AutoHeight = false;
            this.repoDegistir.Name = "repoDegistir";
            this.repoDegistir.OffText = "Off";
            this.repoDegistir.OnText = "On";
            // 
            // colDegisimTuru
            // 
            this.colDegisimTuru.Caption = "Değişim Türü";
            this.colDegisimTuru.ColumnEdit = this.repoDegisimTuru;
            this.colDegisimTuru.FieldName = "DegisimTuru";
            this.colDegisimTuru.Name = "colDegisimTuru";
            this.colDegisimTuru.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDegisimTuru.Visible = true;
            this.colDegisimTuru.VisibleIndex = 4;
            // 
            // repoDegisimTuru
            // 
            this.repoDegisimTuru.AutoHeight = false;
            this.repoDegisimTuru.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoDegisimTuru.Items.AddRange(new object[] {
            "Yüzde",
            "Tutar"});
            this.repoDegisimTuru.Name = "repoDegisimTuru";
            this.repoDegisimTuru.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colDegisimYonu
            // 
            this.colDegisimYonu.Caption = "Değişim Yönü";
            this.colDegisimYonu.ColumnEdit = this.repoDegisimYonu;
            this.colDegisimYonu.FieldName = "DegisimYonu";
            this.colDegisimYonu.Name = "colDegisimYonu";
            this.colDegisimYonu.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDegisimYonu.Visible = true;
            this.colDegisimYonu.VisibleIndex = 2;
            // 
            // repoDegisimYonu
            // 
            this.repoDegisimYonu.AutoHeight = false;
            this.repoDegisimYonu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoDegisimYonu.Items.AddRange(new object[] {
            "Arttır",
            "Azalt"});
            this.repoDegisimYonu.Name = "repoDegisimYonu";
            this.repoDegisimYonu.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colDegeri
            // 
            this.colDegeri.Caption = "Değişim Miktarı";
            this.colDegeri.ColumnEdit = this.repoDegisimMiktari;
            this.colDegeri.FieldName = "Degeri";
            this.colDegeri.Name = "colDegeri";
            this.colDegeri.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDegeri.Visible = true;
            this.colDegeri.VisibleIndex = 3;
            // 
            // repoDegisimMiktari
            // 
            this.repoDegisimMiktari.AutoHeight = false;
            this.repoDegisimMiktari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoDegisimMiktari.DisplayFormat.FormatString = "N2";
            this.repoDegisimMiktari.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repoDegisimMiktari.Name = "repoDegisimMiktari";
            // 
            // FrmFiyatDegistir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 451);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.grpMenu);
            this.Controls.Add(this.lblBaslik);
            this.Name = "FrmFiyatDegistir";
            this.Text = "FrmFiyatDegistir";
            this.Load += new System.EventHandler(this.FrmFiyatDegistir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMenu)).EndInit();
            this.grpMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDegistir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDegisimTuru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDegisimYonu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDegisimMiktari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.GroupControl grpMenu;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private System.Windows.Forms.ImageList ımageList1;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFiyatTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colKolonAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colDegistir;
        private DevExpress.XtraGrid.Columns.GridColumn colDegisimTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colDegisimYonu;
        private DevExpress.XtraGrid.Columns.GridColumn colDegeri;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repoDegistir;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repoDegisimTuru;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repoDegisimYonu;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repoDegisimMiktari;
    }
}