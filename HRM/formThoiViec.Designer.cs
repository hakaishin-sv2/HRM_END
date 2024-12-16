namespace HRM
{
    partial class formThoiViec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formThoiViec));
            this.GhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
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
            this.btnPrintDetail = new DevExpress.XtraBars.BarButtonItem();
            this.bar6 = new DevExpress.XtraBars.Bar();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_GiaHanHopDong = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintLoolList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.LYDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dateTimePickerNgayNop = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxGhiChu = new System.Windows.Forms.TextBox();
            this.TextBoxLydo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchLookUpEditTimNhanVien = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MANV_HD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HOTEN_HD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.gridControlThoiViec = new DevExpress.XtraGrid.GridControl();
            this.gridViewThoiViec = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDKT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOQUYETDINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYNOPDON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYNGHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditTimNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThoiViec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThoiViec)).BeginInit();
            this.SuspendLayout();
            // 
            // GhiChu
            // 
            this.GhiChu.Caption = "Ghi Chú";
            this.GhiChu.FieldName = "GHICHU";
            this.GhiChu.MaxWidth = 300;
            this.GhiChu.MinWidth = 300;
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = true;
            this.GhiChu.VisibleIndex = 8;
            this.GhiChu.Width = 300;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Xóa";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl4.Location = new System.Drawing.Point(0, 51);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl4.Size = new System.Drawing.Size(0, 451);
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
            this.btnClose,
            this.btnPrintDetail});
            this.barManager2.MainMenu = this.bar5;
            this.barManager2.MaxItemId = 8;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrintDetail)});
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
            this.btnPrint.Caption = "In danh sách hiển thị";
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
            // btnPrintDetail
            // 
            this.btnPrintDetail.Caption = "In quyết định thôi việc chi tiết từng nhân viên";
            this.btnPrintDetail.Id = 7;
            this.btnPrintDetail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintDetail.ImageOptions.Image")));
            this.btnPrintDetail.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPrintDetail.ImageOptions.LargeImage")));
            this.btnPrintDetail.Name = "btnPrintDetail";
            this.btnPrintDetail.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPrintDetail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintDetail_ItemClick);
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
            this.barDockControl2.Size = new System.Drawing.Size(1383, 51);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl3.Location = new System.Drawing.Point(0, 502);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl3.Size = new System.Drawing.Size(1383, 20);
            // 
            // barDockControl5
            // 
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl5.Location = new System.Drawing.Point(1383, 51);
            this.barDockControl5.Manager = this.barManager2;
            this.barDockControl5.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl5.Size = new System.Drawing.Size(0, 451);
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
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(1383, 51);
            this.barDockControl1.Manager = null;
            this.barDockControl1.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControl1.Size = new System.Drawing.Size(0, 451);
            // 
            // LYDO
            // 
            this.LYDO.Caption = "Lý do";
            this.LYDO.FieldName = "LYDO";
            this.LYDO.MaxWidth = 300;
            this.LYDO.MinWidth = 300;
            this.LYDO.Name = "LYDO";
            this.LYDO.Visible = true;
            this.LYDO.VisibleIndex = 7;
            this.LYDO.Width = 300;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Sửa";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerNgayNop);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.TextBoxGhiChu);
            this.splitContainer1.Panel1.Controls.Add(this.TextBoxLydo);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.searchLookUpEditTimNhanVien);
            this.splitContainer1.Panel1.Controls.Add(this.label18);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControlThoiViec);
            this.splitContainer1.Size = new System.Drawing.Size(1383, 451);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 16;
            // 
            // dateTimePickerNgayNop
            // 
            this.dateTimePickerNgayNop.Location = new System.Drawing.Point(494, 19);
            this.dateTimePickerNgayNop.Name = "dateTimePickerNgayNop";
            this.dateTimePickerNgayNop.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerNgayNop.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(409, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 21);
            this.label4.TabIndex = 56;
            this.label4.Text = "Ngày nộp";
            // 
            // TextBoxGhiChu
            // 
            this.TextBoxGhiChu.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxGhiChu.Location = new System.Drawing.Point(148, 106);
            this.TextBoxGhiChu.Name = "TextBoxGhiChu";
            this.TextBoxGhiChu.Size = new System.Drawing.Size(493, 28);
            this.TextBoxGhiChu.TabIndex = 53;
            // 
            // TextBoxLydo
            // 
            this.TextBoxLydo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxLydo.Location = new System.Drawing.Point(148, 71);
            this.TextBoxLydo.Name = "TextBoxLydo";
            this.TextBoxLydo.Size = new System.Drawing.Size(493, 28);
            this.TextBoxLydo.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 51;
            this.label2.Text = "Ghi chú";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 50;
            this.label1.Text = "Lý Do";
            // 
            // searchLookUpEditTimNhanVien
            // 
            this.searchLookUpEditTimNhanVien.EditValue = "";
            this.searchLookUpEditTimNhanVien.Location = new System.Drawing.Point(148, 12);
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
            this.label18.Location = new System.Drawing.Point(23, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 21);
            this.label18.TabIndex = 27;
            this.label18.Text = "Nhân Viên";
            // 
            // gridControlThoiViec
            // 
            this.gridControlThoiViec.Location = new System.Drawing.Point(0, 21);
            this.gridControlThoiViec.MainView = this.gridViewThoiViec;
            this.gridControlThoiViec.Name = "gridControlThoiViec";
            this.gridControlThoiViec.Size = new System.Drawing.Size(1683, 500);
            this.gridControlThoiViec.TabIndex = 0;
            this.gridControlThoiViec.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewThoiViec});
            // 
            // gridViewThoiViec
            // 
            this.gridViewThoiViec.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDKT,
            this.SOQUYETDINH,
            this.MANV,
            this.HOTEN,
            this.NGAYNOPDON,
            this.NGAYNGHI,
            this.TENPB,
            this.LYDO,
            this.GhiChu});
            this.gridViewThoiViec.GridControl = this.gridControlThoiViec;
            this.gridViewThoiViec.Name = "gridViewThoiViec";
            this.gridViewThoiViec.OptionsView.ShowGroupPanel = false;
            this.gridViewThoiViec.Click += new System.EventHandler(this.gridViewThoiViec_Click);
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
            this.SOQUYETDINH.Caption = "Số quyết định";
            this.SOQUYETDINH.FieldName = "SOQUETDINH";
            this.SOQUYETDINH.MaxWidth = 80;
            this.SOQUYETDINH.MinWidth = 80;
            this.SOQUYETDINH.Name = "SOQUYETDINH";
            this.SOQUYETDINH.Visible = true;
            this.SOQUYETDINH.VisibleIndex = 1;
            this.SOQUYETDINH.Width = 80;
            // 
            // MANV
            // 
            this.MANV.Caption = "Mã NV";
            this.MANV.FieldName = "MANV";
            this.MANV.MaxWidth = 68;
            this.MANV.MinWidth = 69;
            this.MANV.Name = "MANV";
            this.MANV.Visible = true;
            this.MANV.VisibleIndex = 2;
            this.MANV.Width = 69;
            // 
            // HOTEN
            // 
            this.HOTEN.Caption = "Họ Tên";
            this.HOTEN.FieldName = "HOTEN";
            this.HOTEN.MaxWidth = 250;
            this.HOTEN.MinWidth = 250;
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Visible = true;
            this.HOTEN.VisibleIndex = 3;
            this.HOTEN.Width = 250;
            // 
            // NGAYNOPDON
            // 
            this.NGAYNOPDON.Caption = "Ngày nộp đơn";
            this.NGAYNOPDON.FieldName = "NGAYNOPDON";
            this.NGAYNOPDON.MaxWidth = 120;
            this.NGAYNOPDON.MinWidth = 120;
            this.NGAYNOPDON.Name = "NGAYNOPDON";
            this.NGAYNOPDON.Visible = true;
            this.NGAYNOPDON.VisibleIndex = 5;
            this.NGAYNOPDON.Width = 120;
            // 
            // NGAYNGHI
            // 
            this.NGAYNGHI.Caption = "NGAYNGHI";
            this.NGAYNGHI.FieldName = "NGAYNGHI";
            this.NGAYNGHI.MaxWidth = 120;
            this.NGAYNGHI.MinWidth = 120;
            this.NGAYNGHI.Name = "NGAYNGHI";
            this.NGAYNGHI.Visible = true;
            this.NGAYNGHI.VisibleIndex = 6;
            this.NGAYNGHI.Width = 120;
            // 
            // TENPB
            // 
            this.TENPB.Caption = "Phòng ban";
            this.TENPB.FieldName = "TenPhongBan";
            this.TENPB.MaxWidth = 200;
            this.TENPB.MinWidth = 200;
            this.TENPB.Name = "TENPB";
            this.TENPB.Visible = true;
            this.TENPB.VisibleIndex = 4;
            this.TENPB.Width = 200;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Lưu";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem4.ImageOptions.SvgImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // formThoiViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 522);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl5);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl2);
            this.Name = "formThoiViec";
            this.Text = "Nhân Viên Thôi Việc";
            this.Load += new System.EventHandler(this.formThoiViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditTimNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlThoiViec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewThoiViec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn GhiChu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
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
        private System.Windows.Forms.TextBox TextBoxGhiChu;
        private System.Windows.Forms.TextBox TextBoxLydo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditTimNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn MANV_HD;
        private DevExpress.XtraGrid.Columns.GridColumn HOTEN_HD;
        private System.Windows.Forms.Label label18;
        private DevExpress.XtraGrid.GridControl gridControlThoiViec;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewThoiViec;
        private DevExpress.XtraGrid.Columns.GridColumn IDKT;
        private DevExpress.XtraGrid.Columns.GridColumn SOQUYETDINH;
        private DevExpress.XtraGrid.Columns.GridColumn MANV;
        private DevExpress.XtraGrid.Columns.GridColumn HOTEN;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYNOPDON;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYNGHI;
        private DevExpress.XtraGrid.Columns.GridColumn TENPB;
        private DevExpress.XtraGrid.Columns.GridColumn LYDO;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barBtn_GiaHanHopDong;
        private DevExpress.XtraBars.BarButtonItem btnPrintLoolList;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayNop;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraBars.BarButtonItem btnPrintDetail;
    }
}