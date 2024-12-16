namespace HRM.formRoleNhanVien
{
    partial class formNhanVienTangCa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formNhanVienTangCa));
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.label18 = new System.Windows.Forms.Label();
            this.gridControlTangCa = new DevExpress.XtraGrid.GridControl();
            this.gridViewTangCa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LOAICA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOGIO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GHICHU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DATE_TANGCA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_GiaHanHopDong = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintLoolList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBoxMaKyCong = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.bar6 = new DevExpress.XtraBars.Bar();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnFix = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTangCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTangCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            this.SuspendLayout();
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(1254, 51);
            this.barDockControl1.Manager = null;
            this.barDockControl1.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl1.Size = new System.Drawing.Size(0, 388);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(438, 125);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(292, 24);
            this.label18.TabIndex = 27;
            this.label18.Text = "CHI TIẾT TĂNG CA CỦA BẠN";
            // 
            // gridControlTangCa
            // 
            this.gridControlTangCa.Location = new System.Drawing.Point(0, 3);
            this.gridControlTangCa.MainView = this.gridViewTangCa;
            this.gridControlTangCa.Name = "gridControlTangCa";
            this.gridControlTangCa.Size = new System.Drawing.Size(1260, 299);
            this.gridControlTangCa.TabIndex = 0;
            this.gridControlTangCa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTangCa});
            // 
            // gridViewTangCa
            // 
            this.gridViewTangCa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.LOAICA,
            this.SOGIO,
            this.SOTIEN,
            this.GHICHU,
            this.DATE_TANGCA});
            this.gridViewTangCa.GridControl = this.gridControlTangCa;
            this.gridViewTangCa.Name = "gridViewTangCa";
            this.gridViewTangCa.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.MinWidth = 25;
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 36;
            // 
            // LOAICA
            // 
            this.LOAICA.Caption = "Loại Ca";
            this.LOAICA.FieldName = "TENLOAICA";
            this.LOAICA.MinWidth = 25;
            this.LOAICA.Name = "LOAICA";
            this.LOAICA.Visible = true;
            this.LOAICA.VisibleIndex = 3;
            this.LOAICA.Width = 222;
            // 
            // SOGIO
            // 
            this.SOGIO.Caption = "Số Giờ";
            this.SOGIO.FieldName = "SOGIO";
            this.SOGIO.MinWidth = 100;
            this.SOGIO.Name = "SOGIO";
            this.SOGIO.Visible = true;
            this.SOGIO.VisibleIndex = 4;
            this.SOGIO.Width = 100;
            // 
            // SOTIEN
            // 
            this.SOTIEN.Caption = "Số Tiền Tăng Ca";
            this.SOTIEN.DisplayFormat.FormatString = "{0:n0} VNĐ";
            this.SOTIEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.SOTIEN.FieldName = "TienTangCa";
            this.SOTIEN.MinWidth = 80;
            this.SOTIEN.Name = "SOTIEN";
            this.SOTIEN.Visible = true;
            this.SOTIEN.VisibleIndex = 2;
            this.SOTIEN.Width = 80;
            // 
            // GHICHU
            // 
            this.GHICHU.Caption = "Ghi Chú";
            this.GHICHU.FieldName = "GHICHU";
            this.GHICHU.MinWidth = 25;
            this.GHICHU.Name = "GHICHU";
            this.GHICHU.Visible = true;
            this.GHICHU.VisibleIndex = 5;
            this.GHICHU.Width = 247;
            // 
            // DATE_TANGCA
            // 
            this.DATE_TANGCA.Caption = "Ngày Tăng Ca";
            this.DATE_TANGCA.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.DATE_TANGCA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.DATE_TANGCA.FieldName = "DATE_TANGCA";
            this.DATE_TANGCA.MinWidth = 25;
            this.DATE_TANGCA.Name = "DATE_TANGCA";
            this.DATE_TANGCA.Visible = true;
            this.DATE_TANGCA.VisibleIndex = 1;
            this.DATE_TANGCA.Width = 99;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Sửa";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Lưu";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem4.ImageOptions.SvgImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Xóa";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Hủy";
            this.barButtonItem5.Id = 4;
            this.barButtonItem5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem5.ImageOptions.SvgImage")));
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "In chi tiết";
            this.barButtonItem6.Id = 5;
            this.barButtonItem6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem6.ImageOptions.SvgImage")));
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBtn_GiaHanHopDong
            // 
            this.barBtn_GiaHanHopDong.Caption = "Gian Hạn Hợp Đồng";
            this.barBtn_GiaHanHopDong.Id = 8;
            this.barBtn_GiaHanHopDong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtn_GiaHanHopDong.ImageOptions.SvgImage")));
            this.barBtn_GiaHanHopDong.Name = "barBtn_GiaHanHopDong";
            this.barBtn_GiaHanHopDong.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnPrintLoolList
            // 
            this.btnPrintLoolList.Caption = "In danh sách đang hiển thị";
            this.btnPrintLoolList.Id = 11;
            this.btnPrintLoolList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintLoolList.ImageOptions.SvgImage")));
            this.btnPrintLoolList.Name = "btnPrintLoolList";
            this.btnPrintLoolList.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Đóng";
            this.barButtonItem7.Id = 6;
            this.barButtonItem7.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem7.ImageOptions.SvgImage")));
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 51);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxMaKyCong);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label18);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControlTangCa);
            this.splitContainer1.Size = new System.Drawing.Size(1254, 388);
            this.splitContainer1.SplitterDistance = 91;
            this.splitContainer1.TabIndex = 16;
            // 
            // comboBoxMaKyCong
            // 
            this.comboBoxMaKyCong.FormattingEnabled = true;
            this.comboBoxMaKyCong.Location = new System.Drawing.Point(597, 55);
            this.comboBoxMaKyCong.Name = "comboBoxMaKyCong";
            this.comboBoxMaKyCong.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMaKyCong.TabIndex = 56;
            this.comboBoxMaKyCong.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaKyCong_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(449, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 21);
            this.label1.TabIndex = 55;
            this.label1.Text = "Chọn Kỳ Công";
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar4,
            this.bar5,
            this.bar6});
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.DockControls.Add(this.barDockControl5);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnFix,
            this.btnXoa,
            this.btnSave,
            this.btnHuy,
            this.btnPrint,
            this.btnClose});
            this.barManager2.MainMenu = this.bar5;
            this.barManager2.MaxItemId = 7;
            this.barManager2.StatusBar = this.bar6;
            // 
            // bar4
            // 
            this.bar4.BarName = "Tools";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 1;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.Text = "Tools";
            // 
            // bar5
            // 
            this.bar5.BarName = "Main menu";
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar5.FloatLocation = new System.Drawing.Point(550, 321);
            this.bar5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar5.OptionsBar.MultiLine = true;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Main menu";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Id = 6;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // bar6
            // 
            this.bar6.BarName = "Status bar";
            this.bar6.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar6.DockCol = 0;
            this.bar6.DockRow = 0;
            this.bar6.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar6.OptionsBar.AllowQuickCustomization = false;
            this.bar6.OptionsBar.DrawDragBorder = false;
            this.bar6.OptionsBar.UseWholeRow = true;
            this.bar6.Text = "Status bar";
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl2.Location = new System.Drawing.Point(0, 0);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl2.Size = new System.Drawing.Size(1254, 51);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl3.Location = new System.Drawing.Point(0, 439);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl3.Size = new System.Drawing.Size(1254, 20);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl4.Location = new System.Drawing.Point(0, 51);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl4.Size = new System.Drawing.Size(0, 388);
            // 
            // barDockControl5
            // 
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl5.Location = new System.Drawing.Point(1254, 51);
            this.barDockControl5.Manager = this.barManager2;
            this.barDockControl5.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl5.Size = new System.Drawing.Size(0, 388);
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnFix
            // 
            this.btnFix.Caption = "Sửa";
            this.btnFix.Id = 1;
            this.btnFix.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFix.ImageOptions.SvgImage")));
            this.btnFix.Name = "btnFix";
            this.btnFix.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 3;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy";
            this.btnHuy.Id = 4;
            this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 5;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // formNhanVienTangCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 459);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl5);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl2);
            this.Name = "formNhanVienTangCa";
            this.Text = "Xem công tăng ca ";
            this.Load += new System.EventHandler(this.formNhanVienTangCa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTangCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTangCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private System.Windows.Forms.Label label18;
        private DevExpress.XtraGrid.GridControl gridControlTangCa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTangCa;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn LOAICA;
        private DevExpress.XtraGrid.Columns.GridColumn SOGIO;
        private DevExpress.XtraGrid.Columns.GridColumn SOTIEN;
        private DevExpress.XtraGrid.Columns.GridColumn GHICHU;
        private DevExpress.XtraGrid.Columns.GridColumn DATE_TANGCA;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barBtn_GiaHanHopDong;
        private DevExpress.XtraBars.BarButtonItem btnPrintLoolList;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnFix;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.Bar bar6;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl5;
        private System.Windows.Forms.ComboBox comboBoxMaKyCong;
        private System.Windows.Forms.Label label1;
    }
}