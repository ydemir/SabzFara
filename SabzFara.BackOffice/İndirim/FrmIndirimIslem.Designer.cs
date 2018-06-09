namespace SabzFara.BackOffice.İndirim
{
    partial class FrmIndirimIslem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIndirimIslem));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTarih = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.checkButton2 = new DevExpress.XtraEditors.CheckButton();
            this.checkButton1 = new DevExpress.XtraEditors.CheckButton();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.gridContKasaHareket = new DevExpress.XtraGrid.GridControl();
            this.gridKasaHareket = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.imgMenu = new System.Windows.Forms.ImageList(this.components);
            this.grpMenu = new DevExpress.XtraEditors.GroupControl();
            this.btnAra = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnCikar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTarih.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTarih.Properties)).BeginInit();
            this.wizardPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContKasaHareket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKasaHareket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMenu)).BeginInit();
            this.grpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "clock_run.png");
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "Kapat";
            this.wizardControl1.Controls.Add(this.welcomeWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage1);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.wizardPage2);
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&İleri >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< &Geri";
            this.wizardControl1.Size = new System.Drawing.Size(1157, 708);
            this.wizardControl1.Text = "İndirim Sihirbazı";
            this.wizardControl1.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(1097, 540);
            this.welcomeWizardPage1.Text = "İndirim Sihirbazına Hoşgeldiniz.";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.groupControl2);
            this.wizardPage1.Controls.Add(this.groupControl1);
            this.wizardPage1.Controls.Add(this.checkButton2);
            this.wizardPage1.Controls.Add(this.checkButton1);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(1097, 540);
            this.wizardPage1.Text = "İndirim Türünü Seçin";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtAciklama);
            this.groupControl2.Location = new System.Drawing.Point(549, 335);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(545, 205);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAciklama.Location = new System.Drawing.Point(2, 20);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(541, 183);
            this.txtAciklama.TabIndex = 45;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateEdit1);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.cmbTarih);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(3, 335);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(545, 205);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Tarih Bilgisi";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(5, 146);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.dateEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.dateEdit1.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.dateEdit1.Properties.ContextImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.dateEdit1.Properties.DisplayFormat.FormatString = "";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.dateEdit1.Size = new System.Drawing.Size(535, 20);
            this.dateEdit1.TabIndex = 46;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseBorderColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl1.Location = new System.Drawing.Point(5, 119);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(535, 21);
            this.labelControl1.TabIndex = 45;
            this.labelControl1.Text = "Bitiş Tarihi";
            // 
            // cmbTarih
            // 
            this.cmbTarih.EditValue = null;
            this.cmbTarih.Location = new System.Drawing.Point(5, 62);
            this.cmbTarih.Name = "cmbTarih";
            this.cmbTarih.Properties.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            editorButtonImageOptions1.ImageIndex = 0;
            editorButtonImageOptions1.ImageList = this.ımageList1;
            this.cmbTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.cmbTarih.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cmbTarih.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.False;
            this.cmbTarih.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTarih.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.cmbTarih.Properties.ContextImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.cmbTarih.Properties.DisplayFormat.FormatString = "";
            this.cmbTarih.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.cmbTarih.Size = new System.Drawing.Size(535, 22);
            this.cmbTarih.TabIndex = 46;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseBorderColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl2.Location = new System.Drawing.Point(5, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(535, 21);
            this.labelControl2.TabIndex = 45;
            this.labelControl2.Text = "Başlangıç Tarihi";
            // 
            // checkButton2
            // 
            this.checkButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkButton2.Appearance.Options.UseFont = true;
            this.checkButton2.GroupIndex = 1;
            this.checkButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("checkButton2.ImageOptions.Image")));
            this.checkButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.checkButton2.Location = new System.Drawing.Point(549, 82);
            this.checkButton2.Name = "checkButton2";
            this.checkButton2.Size = new System.Drawing.Size(270, 230);
            this.checkButton2.TabIndex = 0;
            this.checkButton2.TabStop = false;
            this.checkButton2.Text = "Belirli Tarihler Arasında";
            // 
            // checkButton1
            // 
            this.checkButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkButton1.Appearance.Options.UseFont = true;
            this.checkButton1.GroupIndex = 1;
            this.checkButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("checkButton1.ImageOptions.Image")));
            this.checkButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.checkButton1.Location = new System.Drawing.Point(278, 82);
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.Size = new System.Drawing.Size(270, 230);
            this.checkButton1.TabIndex = 0;
            this.checkButton1.TabStop = false;
            this.checkButton1.Text = "Süresiz";
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.Size = new System.Drawing.Size(1097, 540);
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.gridContKasaHareket);
            this.wizardPage2.Controls.Add(this.grpMenu);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(1097, 540);
            this.wizardPage2.Text = "Lütfen İndirim Yapacağınız Ürünleri Seçin";
            // 
            // gridContKasaHareket
            // 
            this.gridContKasaHareket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContKasaHareket.Location = new System.Drawing.Point(0, 0);
            this.gridContKasaHareket.MainView = this.gridKasaHareket;
            this.gridContKasaHareket.Name = "gridContKasaHareket";
            this.gridContKasaHareket.Size = new System.Drawing.Size(1097, 466);
            this.gridContKasaHareket.TabIndex = 9;
            this.gridContKasaHareket.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridKasaHareket});
            // 
            // gridKasaHareket
            // 
            this.gridKasaHareket.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridKasaHareket.GridControl = this.gridContKasaHareket;
            this.gridKasaHareket.Name = "gridKasaHareket";
            this.gridKasaHareket.OptionsView.ShowGroupPanel = false;
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
            this.colDurumu.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colStokKodu
            // 
            this.colStokKodu.FieldName = "StokKodu";
            this.colStokKodu.Name = "colStokKodu";
            this.colStokKodu.OptionsColumn.AllowEdit = false;
            this.colStokKodu.Visible = true;
            this.colStokKodu.VisibleIndex = 0;
            this.colStokKodu.Width = 149;
            // 
            // colBarkod
            // 
            this.colBarkod.FieldName = "Barkod";
            this.colBarkod.Name = "colBarkod";
            this.colBarkod.OptionsColumn.AllowEdit = false;
            this.colBarkod.Visible = true;
            this.colBarkod.VisibleIndex = 1;
            this.colBarkod.Width = 220;
            // 
            // colStokAdi
            // 
            this.colStokAdi.FieldName = "StokAdi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.OptionsColumn.AllowEdit = false;
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 2;
            this.colStokAdi.Width = 539;
            // 
            // colIndirimTuru
            // 
            this.colIndirimTuru.FieldName = "IndirimTuru";
            this.colIndirimTuru.Name = "colIndirimTuru";
            this.colIndirimTuru.OptionsColumn.AllowEdit = false;
            this.colIndirimTuru.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colBaslangicTarihi
            // 
            this.colBaslangicTarihi.FieldName = "BaslangicTarihi";
            this.colBaslangicTarihi.Name = "colBaslangicTarihi";
            this.colBaslangicTarihi.OptionsColumn.AllowEdit = false;
            this.colBaslangicTarihi.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colBitisTarihi
            // 
            this.colBitisTarihi.FieldName = "BitisTarihi";
            this.colBitisTarihi.Name = "colBitisTarihi";
            this.colBitisTarihi.OptionsColumn.AllowEdit = false;
            this.colBitisTarihi.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colIndirimOrani
            // 
            this.colIndirimOrani.FieldName = "IndirimOrani";
            this.colIndirimOrani.Name = "colIndirimOrani";
            this.colIndirimOrani.OptionsColumn.AllowEdit = false;
            this.colIndirimOrani.Visible = true;
            this.colIndirimOrani.VisibleIndex = 3;
            this.colIndirimOrani.Width = 171;
            // 
            // colAciklama
            // 
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // imgMenu
            // 
            this.imgMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMenu.ImageStream")));
            this.imgMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMenu.Images.SetKeyName(0, "floppy_disk.png");
            this.imgMenu.Images.SetKeyName(1, "folder_out.png");
            this.imgMenu.Images.SetKeyName(2, "money2_edit.png");
            this.imgMenu.Images.SetKeyName(3, "navigate_minus.png");
            this.imgMenu.Images.SetKeyName(4, "package.png");
            this.imgMenu.Images.SetKeyName(5, "refresh.png");
            this.imgMenu.Images.SetKeyName(6, "stok çıkar.png");
            this.imgMenu.Images.SetKeyName(7, "Stok Ekle.png");
            this.imgMenu.Images.SetKeyName(8, "view.png");
            // 
            // grpMenu
            // 
            this.grpMenu.Controls.Add(this.btnAra);
            this.grpMenu.Controls.Add(this.btnGuncelle);
            this.grpMenu.Controls.Add(this.btnCikar);
            this.grpMenu.Controls.Add(this.btnEkle);
            this.grpMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpMenu.Location = new System.Drawing.Point(0, 466);
            this.grpMenu.Name = "grpMenu";
            this.grpMenu.Size = new System.Drawing.Size(1097, 74);
            this.grpMenu.TabIndex = 10;
            this.grpMenu.Text = "Menü";
            // 
            // btnAra
            // 
            this.btnAra.ImageOptions.ImageIndex = 8;
            this.btnAra.ImageOptions.ImageList = this.imgMenu;
            this.btnAra.Location = new System.Drawing.Point(279, 26);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(83, 44);
            this.btnAra.TabIndex = 0;
            this.btnAra.Text = "Ara";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.ImageOptions.ImageIndex = 5;
            this.btnGuncelle.ImageOptions.ImageList = this.imgMenu;
            this.btnGuncelle.Location = new System.Drawing.Point(190, 25);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(83, 44);
            this.btnGuncelle.TabIndex = 0;
            this.btnGuncelle.Text = "Güncelle";
            // 
            // btnCikar
            // 
            this.btnCikar.ImageOptions.ImageIndex = 6;
            this.btnCikar.ImageOptions.ImageList = this.imgMenu;
            this.btnCikar.Location = new System.Drawing.Point(101, 26);
            this.btnCikar.Name = "btnCikar";
            this.btnCikar.Size = new System.Drawing.Size(83, 44);
            this.btnCikar.TabIndex = 0;
            this.btnCikar.Text = "Çıkar";
            // 
            // btnEkle
            // 
            this.btnEkle.ImageOptions.ImageIndex = 7;
            this.btnEkle.ImageOptions.ImageList = this.imgMenu;
            this.btnEkle.Location = new System.Drawing.Point(12, 26);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(83, 44);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            // 
            // FrmIndirimIslem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 708);
            this.ControlBox = false;
            this.Controls.Add(this.wizardControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmIndirimIslem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTarih.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTarih.Properties)).EndInit();
            this.wizardPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContKasaHareket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKasaHareket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMenu)).EndInit();
            this.grpMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckButton checkButton2;
        private DevExpress.XtraEditors.CheckButton checkButton1;
        private DevExpress.XtraEditors.DateEdit cmbTarih;
        private System.Windows.Forms.ImageList ımageList1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtAciklama;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraGrid.GridControl gridContKasaHareket;
        private DevExpress.XtraGrid.Views.Grid.GridView gridKasaHareket;
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
        private DevExpress.XtraEditors.GroupControl grpMenu;
        private DevExpress.XtraEditors.SimpleButton btnAra;
        private System.Windows.Forms.ImageList imgMenu;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnCikar;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
    }
}