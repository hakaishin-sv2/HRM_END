using System;

namespace HRM
{
    partial class formKyLuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formKyLuat));
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnFix = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.bar6 = new DevExpress.XtraBars.Bar();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_GiaHanHopDong = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintLoolList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.TextBoxNoiDung = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSoTien = new System.Windows.Forms.TextBox();
            this.TextBoxLyDo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchLookUpEditTimNhanVien = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MANV_HD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HOTEN_HD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.gridControlKyLuat = new DevExpress.XtraGrid.GridControl();
            this.gridViewKyLuat = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOQUYETDINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TUNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DENNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LYDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOIDUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTienString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditTimNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKyLuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKyLuat)).BeginInit();
            this.SuspendLayout();
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl4.Location = new System.Drawing.Point(0, 51);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl4.Size = new System.Drawing.Size(0, 347);
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFix),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHuy),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar5.OptionsBar.MultiLine = true;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnFix
            // 
            this.btnFix.Caption = "Sửa";
            this.btnFix.Id = 1;
            this.btnFix.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFix.ImageOptions.SvgImage")));
            this.btnFix.Name = "btnFix";
            this.btnFix.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnFix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFix_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 3;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy";
            this.btnHuy.Id = 4;
            this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnHuy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHuy_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 5;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
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
            this.barDockControl2.Size = new System.Drawing.Size(1215, 51);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl3.Location = new System.Drawing.Point(0, 398);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl3.Size = new System.Drawing.Size(1215, 20);
            // 
            // barDockControl5
            // 
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl5.Location = new System.Drawing.Point(1215, 51);
            this.barDockControl5.Manager = this.barManager2;
            this.barDockControl5.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl5.Size = new System.Drawing.Size(0, 347);
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
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(1215, 51);
            this.barDockControl1.Manager = null;
            this.barDockControl1.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl1.Size = new System.Drawing.Size(0, 347);
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
            // TextBoxNoiDung
            // 
            this.TextBoxNoiDung.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNoiDung.Location = new System.Drawing.Point(232, 122);
            this.TextBoxNoiDung.Name = "TextBoxNoiDung";
            this.TextBoxNoiDung.Size = new System.Drawing.Size(493, 28);
            this.TextBoxNoiDung.TabIndex = 53;
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
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxSoTien);
            this.splitContainer1.Panel1.Controls.Add(this.TextBoxNoiDung);
            this.splitContainer1.Panel1.Controls.Add(this.TextBoxLyDo);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.searchLookUpEditTimNhanVien);
            this.splitContainer1.Panel1.Controls.Add(this.label18);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControlKyLuat);
            this.splitContainer1.Size = new System.Drawing.Size(1215, 347);
            this.splitContainer1.SplitterDistance = 141;
            this.splitContainer1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(486, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 21);
            this.label3.TabIndex = 57;
            this.label3.Text = "Số Tiền";
            // 
            // textBoxSoTien
            // 
            this.textBoxSoTien.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoTien.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxSoTien.Location = new System.Drawing.Point(557, 27);
            this.textBoxSoTien.Name = "textBoxSoTien";
            this.textBoxSoTien.Size = new System.Drawing.Size(192, 28);
            this.textBoxSoTien.TabIndex = 56;
            this.textBoxSoTien.TextChanged += new System.EventHandler(this.textBoxSoTien_TextChanged);
            // 
            // TextBoxLyDo
            // 
            this.TextBoxLyDo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxLyDo.Location = new System.Drawing.Point(232, 74);
            this.TextBoxLyDo.Name = "TextBoxLyDo";
            this.TextBoxLyDo.Size = new System.Drawing.Size(493, 28);
            this.TextBoxLyDo.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 51;
            this.label2.Text = "Nội dung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 50;
            this.label1.Text = "Lý Do";
            // 
            // searchLookUpEditTimNhanVien
            // 
            this.searchLookUpEditTimNhanVien.EditValue = "";
            this.searchLookUpEditTimNhanVien.Location = new System.Drawing.Point(232, 27);
            this.searchLookUpEditTimNhanVien.Name = "searchLookUpEditTimNhanVien";
            this.searchLookUpEditTimNhanVien.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLookUpEditTimNhanVien.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpEditTimNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditTimNhanVien.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEditTimNhanVien.Size = new System.Drawing.Size(210, 28);
            this.searchLookUpEditTimNhanVien.TabIndex = 49;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MANV_HD,
            this.HOTEN_HD});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // MANV_HD
            // 
            this.MANV_HD.Caption = "Mã NV";
            this.MANV_HD.FieldName = "MANV";
            this.MANV_HD.MaxWidth = 50;
            this.MANV_HD.MinWidth = 50;
            this.MANV_HD.Name = "MANV_HD";
            this.MANV_HD.Visible = true;
            this.MANV_HD.VisibleIndex = 0;
            this.MANV_HD.Width = 50;
            // 
            // HOTEN_HD
            // 
            this.HOTEN_HD.Caption = "Họ Tên";
            this.HOTEN_HD.FieldName = "HOTEN";
            this.HOTEN_HD.MaxWidth = 250;
            this.HOTEN_HD.MinWidth = 250;
            this.HOTEN_HD.Name = "HOTEN_HD";
            this.HOTEN_HD.Visible = true;
            this.HOTEN_HD.VisibleIndex = 1;
            this.HOTEN_HD.Width = 250;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(107, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 21);
            this.label18.TabIndex = 27;
            this.label18.Text = "Nhân Viên";
            // 
            // gridControlKyLuat
            // 
            this.gridControlKyLuat.Location = new System.Drawing.Point(0, 3);
            this.gridControlKyLuat.MainView = this.gridViewKyLuat;
            this.gridControlKyLuat.Name = "gridControlKyLuat";
            this.gridControlKyLuat.Size = new System.Drawing.Size(1215, 189);
            this.gridControlKyLuat.TabIndex = 0;
            this.gridControlKyLuat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewKyLuat});
            // 
            // gridViewKyLuat
            // 
            this.gridViewKyLuat.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDKT,
            this.SOQUYETDINH,
            this.MANV,
            this.HOTEN,
            this.TUNGAY,
            this.DENNGAY,
            this.LYDO,
            this.NOIDUNG,
            this.SoTienString});
            this.gridViewKyLuat.GridControl = this.gridControlKyLuat;
            this.gridViewKyLuat.Name = "gridViewKyLuat";
            this.gridViewKyLuat.OptionsView.ShowGroupPanel = false;
            this.gridViewKyLuat.Click += new System.EventHandler(this.gridViewKyLuat_Click);
            // 
            // IDKT
            // 
            this.IDKT.Caption = "ID";
            this.IDKT.FieldName = "ID";
            this.IDKT.MaxWidth = 40;
            this.IDKT.MinWidth = 40;
            this.IDKT.Name = "IDKT";
            this.IDKT.Visible = true;
            this.IDKT.VisibleIndex = 0;
            this.IDKT.Width = 40;
            // 
            // SOQUYETDINH
            // 
            this.SOQUYETDINH.Caption = "Số KT";
            this.SOQUYETDINH.FieldName = "SOQUYETDINH";
            this.SOQUYETDINH.MinWidth = 25;
            this.SOQUYETDINH.Name = "SOQUYETDINH";
            this.SOQUYETDINH.Visible = true;
            this.SOQUYETDINH.VisibleIndex = 1;
            this.SOQUYETDINH.Width = 94;
            // 
            // MANV
            // 
            this.MANV.Caption = "Mã NV";
            this.MANV.FieldName = "MANV";
            this.MANV.MinWidth = 25;
            this.MANV.Name = "MANV";
            this.MANV.Visible = true;
            this.MANV.VisibleIndex = 2;
            this.MANV.Width = 94;
            // 
            // HOTEN
            // 
            this.HOTEN.Caption = "Họ Tên";
            this.HOTEN.FieldName = "HOTEN";
            this.HOTEN.MinWidth = 25;
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Visible = true;
            this.HOTEN.VisibleIndex = 3;
            this.HOTEN.Width = 94;
            // 
            // TUNGAY
            // 
            this.TUNGAY.Caption = "TỪ Ngày";
            this.TUNGAY.FieldName = "TUNGAY";
            this.TUNGAY.MinWidth = 25;
            this.TUNGAY.Name = "TUNGAY";
            this.TUNGAY.Visible = true;
            this.TUNGAY.VisibleIndex = 4;
            this.TUNGAY.Width = 94;
            // 
            // DENNGAY
            // 
            this.DENNGAY.Caption = "Đến Ngày";
            this.DENNGAY.FieldName = "DENNGAY";
            this.DENNGAY.MinWidth = 25;
            this.DENNGAY.Name = "DENNGAY";
            this.DENNGAY.Visible = true;
            this.DENNGAY.VisibleIndex = 5;
            this.DENNGAY.Width = 94;
            // 
            // LYDO
            // 
            this.LYDO.Caption = "Lý Do";
            this.LYDO.FieldName = "LYDO";
            this.LYDO.MinWidth = 25;
            this.LYDO.Name = "LYDO";
            this.LYDO.Visible = true;
            this.LYDO.VisibleIndex = 6;
            this.LYDO.Width = 94;
            // 
            // NOIDUNG
            // 
            this.NOIDUNG.Caption = "Nội Dung";
            this.NOIDUNG.FieldName = "NOIDUNG";
            this.NOIDUNG.MinWidth = 25;
            this.NOIDUNG.Name = "NOIDUNG";
            this.NOIDUNG.Visible = true;
            this.NOIDUNG.VisibleIndex = 7;
            this.NOIDUNG.Width = 94;
            // 
            // SoTienString
            // 
            this.SoTienString.Caption = "Số Tiền Phạt";
            this.SoTienString.FieldName = "SoTienString";
            this.SoTienString.MinWidth = 25;
            this.SoTienString.Name = "SoTienString";
            this.SoTienString.Visible = true;
            this.SoTienString.VisibleIndex = 8;
            this.SoTienString.Width = 94;
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
            // formKyLuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 418);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl5);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl2);
            this.Name = "formKyLuat";
            this.Text = "formKyLuat";
            this.Load += new System.EventHandler(this.formKyLuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditTimNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlKyLuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKyLuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void gridViewKyLuat_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
            }
            //decimal lcb = luongCo.getLuongCoBan();


            id = Convert.ToInt32(gridViewKyLuat.GetFocusedRowCellValue("ID").ToString());
            //_list_hd_DTO = hd.getHopDongFocus(id, _data);
            var getHDclick = _KyLuat.getItem(id);

            TextBoxLyDo.Text = getHDclick.LYDO;
            TextBoxNoiDung.Text = getHDclick.NOIDUNG;
            textBoxSoTien.Text = getHDclick.SOTIEN.ToString();
            searchLookUpEditTimNhanVien.EditValue = getHDclick.MANV;
        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControl4;
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
        private DevExpress.XtraBars.BarDockControl barDockControl5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TextBoxNoiDung;
        private System.Windows.Forms.TextBox TextBoxLyDo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditTimNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn MANV_HD;
        private DevExpress.XtraGrid.Columns.GridColumn HOTEN_HD;
        private System.Windows.Forms.Label label18;
        private DevExpress.XtraGrid.GridControl gridControlKyLuat;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewKyLuat;
        private DevExpress.XtraGrid.Columns.GridColumn IDKT;
        private DevExpress.XtraGrid.Columns.GridColumn SOQUYETDINH;
        private DevExpress.XtraGrid.Columns.GridColumn MANV;
        private DevExpress.XtraGrid.Columns.GridColumn HOTEN;
        private DevExpress.XtraGrid.Columns.GridColumn TUNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn DENNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn LYDO;
        private DevExpress.XtraGrid.Columns.GridColumn NOIDUNG;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barBtn_GiaHanHopDong;
        private DevExpress.XtraBars.BarButtonItem btnPrintLoolList;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSoTien;
        private DevExpress.XtraGrid.Columns.GridColumn SoTienString;
    }
}