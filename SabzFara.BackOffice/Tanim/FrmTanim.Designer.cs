namespace SabzFara.BackOffice.Tanim
{
    partial class FrmTanim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTanim));
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSec = new DevExpress.XtraEditors.SimpleButton();
            this.btnDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.grpMenu = new DevExpress.XtraEditors.GroupControl();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.gridContTanim = new DevExpress.XtraGrid.GridControl();
            this.gridTanim = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.txtTanim = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.colTanimi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grpMenu)).BeginInit();
            this.grpMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.navigationPage1.SuspendLayout();
            this.navigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContTanim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTanim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTanim.Properties)).BeginInit();
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
            this.lblBaslik.Size = new System.Drawing.Size(638, 47);
            this.lblBaslik.TabIndex = 7;
            this.lblBaslik.Text = "Tanımlar";
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "add.png");
            this.ımageList1.Images.SetKeyName(1, "checkbox.png");
            this.ımageList1.Images.SetKeyName(2, "delete.png");
            this.ımageList1.Images.SetKeyName(3, "floppy_disk.png");
            this.ımageList1.Images.SetKeyName(4, "floppy_disk_delete.png");
            this.ımageList1.Images.SetKeyName(5, "folder_out.png");
            this.ımageList1.Images.SetKeyName(6, "pencil.png");
            // 
            // btnEkle
            // 
            this.btnEkle.ImageOptions.ImageIndex = 0;
            this.btnEkle.ImageOptions.ImageList = this.ımageList1;
            this.btnEkle.Location = new System.Drawing.Point(100, 26);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(83, 44);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSec
            // 
            this.btnSec.ImageOptions.ImageIndex = 1;
            this.btnSec.ImageOptions.ImageList = this.ımageList1;
            this.btnSec.Location = new System.Drawing.Point(11, 25);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(83, 44);
            this.btnSec.TabIndex = 0;
            this.btnSec.Text = "Seç";
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.ImageOptions.ImageIndex = 6;
            this.btnDuzenle.ImageOptions.ImageList = this.ımageList1;
            this.btnDuzenle.Location = new System.Drawing.Point(189, 26);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(83, 44);
            this.btnDuzenle.TabIndex = 0;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.ImageOptions.ImageIndex = 2;
            this.btnSil.ImageOptions.ImageList = this.ımageList1;
            this.btnSil.Location = new System.Drawing.Point(278, 26);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(83, 44);
            this.btnSil.TabIndex = 0;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.ImageOptions.ImageIndex = 3;
            this.btnKaydet.ImageOptions.ImageList = this.ımageList1;
            this.btnKaydet.Location = new System.Drawing.Point(367, 26);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(83, 44);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.ImageOptions.ImageIndex = 4;
            this.btnVazgec.ImageOptions.ImageList = this.ımageList1;
            this.btnVazgec.Location = new System.Drawing.Point(456, 25);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(83, 44);
            this.btnVazgec.TabIndex = 0;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.ImageOptions.ImageIndex = 5;
            this.btnKapat.ImageOptions.ImageList = this.ımageList1;
            this.btnKapat.Location = new System.Drawing.Point(545, 24);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(83, 44);
            this.btnKapat.TabIndex = 0;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // grpMenu
            // 
            this.grpMenu.Controls.Add(this.btnKapat);
            this.grpMenu.Controls.Add(this.btnVazgec);
            this.grpMenu.Controls.Add(this.btnKaydet);
            this.grpMenu.Controls.Add(this.btnSil);
            this.grpMenu.Controls.Add(this.btnDuzenle);
            this.grpMenu.Controls.Add(this.btnSec);
            this.grpMenu.Controls.Add(this.btnEkle);
            this.grpMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpMenu.Location = new System.Drawing.Point(0, 427);
            this.grpMenu.Name = "grpMenu";
            this.grpMenu.Size = new System.Drawing.Size(638, 75);
            this.grpMenu.TabIndex = 8;
            this.grpMenu.Text = "Menü";
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPage1);
            this.navigationFrame1.Controls.Add(this.navigationPage2);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(0, 47);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1,
            this.navigationPage2});
            this.navigationFrame1.SelectedPage = this.navigationPage2;
            this.navigationFrame1.Size = new System.Drawing.Size(638, 380);
            this.navigationFrame1.TabIndex = 9;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage1
            // 
            this.navigationPage1.Controls.Add(this.groupControl1);
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(638, 380);
            // 
            // navigationPage2
            // 
            this.navigationPage2.Controls.Add(this.gridContTanim);
            this.navigationPage2.Name = "navigationPage2";
            this.navigationPage2.Size = new System.Drawing.Size(638, 380);
            // 
            // gridContTanim
            // 
            this.gridContTanim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContTanim.Location = new System.Drawing.Point(0, 0);
            this.gridContTanim.MainView = this.gridTanim;
            this.gridContTanim.Name = "gridContTanim";
            this.gridContTanim.Size = new System.Drawing.Size(638, 380);
            this.gridContTanim.TabIndex = 2;
            this.gridContTanim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridTanim});
            // 
            // gridTanim
            // 
            this.gridTanim.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colTanimi,
            this.colAciklama});
            this.gridTanim.GridControl = this.gridContTanim;
            this.gridTanim.Name = "gridTanim";
            this.gridTanim.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtAciklama);
            this.groupControl1.Controls.Add(this.txtTanim);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(638, 380);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Tanim Bilgileri";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(117, 63);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(516, 306);
            this.txtAciklama.TabIndex = 7;
            // 
            // txtTanim
            // 
            this.txtTanim.Location = new System.Drawing.Point(112, 38);
            this.txtTanim.Name = "txtTanim";
            this.txtTanim.Size = new System.Drawing.Size(250, 20);
            this.txtTanim.TabIndex = 10;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl10.Appearance.Options.UseBorderColor = true;
            this.labelControl10.Appearance.Options.UseTextOptions = true;
            this.labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl10.Location = new System.Drawing.Point(17, 64);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(87, 310);
            this.labelControl10.TabIndex = 8;
            this.labelControl10.Text = "Açıklama :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl6.Appearance.Options.UseBorderColor = true;
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl6.Location = new System.Drawing.Point(12, 37);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(92, 21);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "Tanimi";
            // 
            // colTanimi
            // 
            this.colTanimi.Caption = "Tanımı";
            this.colTanimi.FieldName = "Tanimi";
            this.colTanimi.Name = "colTanimi";
            this.colTanimi.Visible = true;
            this.colTanimi.VisibleIndex = 0;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Aciklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 1;
            // 
            // FrmTanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 502);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.grpMenu);
            this.Controls.Add(this.lblBaslik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTanim";
            this.Text = "Tanımlar";
            this.Load += new System.EventHandler(this.FrmTanim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMenu)).EndInit();
            this.grpMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.navigationPage1.ResumeLayout(false);
            this.navigationPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContTanim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTanim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTanim.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private System.Windows.Forms.ImageList ımageList1;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraEditors.SimpleButton btnSec;
        private DevExpress.XtraEditors.SimpleButton btnDuzenle;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.GroupControl grpMenu;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        private DevExpress.XtraGrid.GridControl gridContTanim;
        private DevExpress.XtraGrid.Views.Grid.GridView gridTanim;
        private DevExpress.XtraEditors.MemoEdit txtAciklama;
        private DevExpress.XtraEditors.TextEdit txtTanim;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTanimi;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
    }
}