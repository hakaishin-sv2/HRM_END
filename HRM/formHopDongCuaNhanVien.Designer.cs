namespace HRM
{
    partial class formHopDongCuaNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formHopDongCuaNhanVien));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnXemHopDongChiTietNhanVien = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControlLapHopDong = new DevExpress.XtraGrid.GridControl();
            this.gridViewLapHopDong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDHOPDONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MAHOPDONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYBATDAx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYKETTHUC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THOIHANHOPDONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LANKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MANVHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HOTENNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HESOLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LuongCoBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLapHopDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLapHopDong)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnXemHopDongChiTietNhanVien);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControlLapHopDong);
            this.splitContainer1.Size = new System.Drawing.Size(1226, 451);
            this.splitContainer1.SplitterDistance = 138;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnXemHopDongChiTietNhanVien
            // 
            this.btnXemHopDongChiTietNhanVien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXemHopDongChiTietNhanVien.ImageOptions.SvgImage")));
            this.btnXemHopDongChiTietNhanVien.Location = new System.Drawing.Point(616, 94);
            this.btnXemHopDongChiTietNhanVien.Name = "btnXemHopDongChiTietNhanVien";
            this.btnXemHopDongChiTietNhanVien.Size = new System.Drawing.Size(181, 46);
            this.btnXemHopDongChiTietNhanVien.TabIndex = 60;
            this.btnXemHopDongChiTietNhanVien.Text = "Xem Chi Tiết";
            this.btnXemHopDongChiTietNhanVien.Click += new System.EventHandler(this.btnXemHopDongChiTietNhanVien_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(489, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 34);
            this.label1.TabIndex = 59;
            this.label1.Text = "THÔNG TIN HỢP ĐỒNG CỦA BẠN";
            // 
            // gridControlLapHopDong
            // 
            this.gridControlLapHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControlLapHopDong.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControlLapHopDong.Location = new System.Drawing.Point(0, 0);
            this.gridControlLapHopDong.MainView = this.gridViewLapHopDong;
            this.gridControlLapHopDong.Name = "gridControlLapHopDong";
            this.gridControlLapHopDong.Size = new System.Drawing.Size(1226, 309);
            this.gridControlLapHopDong.TabIndex = 3;
            this.gridControlLapHopDong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLapHopDong});
            // 
            // gridViewLapHopDong
            // 
            this.gridViewLapHopDong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDHOPDONG,
            this.MAHOPDONG,
            this.NGAYKY,
            this.NGAYBATDAx,
            this.NGAYKETTHUC,
            this.THOIHANHOPDONG,
            this.LANKY,
            this.MANVHD,
            this.HOTENNV,
            this.HESOLUONG,
            this.LuongCoBan,
            this.TenTrangThai});
            this.gridViewLapHopDong.GridControl = this.gridControlLapHopDong;
            this.gridViewLapHopDong.Name = "gridViewLapHopDong";
            this.gridViewLapHopDong.OptionsView.ShowGroupPanel = false;
            // 
            // IDHOPDONG
            // 
            this.IDHOPDONG.Caption = "IDHOPDONG";
            this.IDHOPDONG.FieldName = "ID";
            this.IDHOPDONG.MaxWidth = 50;
            this.IDHOPDONG.MinWidth = 50;
            this.IDHOPDONG.Name = "IDHOPDONG";
            this.IDHOPDONG.Visible = true;
            this.IDHOPDONG.VisibleIndex = 0;
            this.IDHOPDONG.Width = 50;
            // 
            // MAHOPDONG
            // 
            this.MAHOPDONG.Caption = "Mã Hợp Đồng";
            this.MAHOPDONG.FieldName = "MAHOPDONG";
            this.MAHOPDONG.MaxWidth = 150;
            this.MAHOPDONG.MinWidth = 150;
            this.MAHOPDONG.Name = "MAHOPDONG";
            this.MAHOPDONG.Visible = true;
            this.MAHOPDONG.VisibleIndex = 1;
            this.MAHOPDONG.Width = 150;
            // 
            // NGAYKY
            // 
            this.NGAYKY.Caption = "Ngày Ký";
            this.NGAYKY.FieldName = "NGAYKY";
            this.NGAYKY.MaxWidth = 150;
            this.NGAYKY.MinWidth = 150;
            this.NGAYKY.Name = "NGAYKY";
            this.NGAYKY.Visible = true;
            this.NGAYKY.VisibleIndex = 2;
            this.NGAYKY.Width = 150;
            // 
            // NGAYBATDAx
            // 
            this.NGAYBATDAx.Caption = "Ngày Bắt Đầu";
            this.NGAYBATDAx.FieldName = "NGAYBATDAU";
            this.NGAYBATDAx.MaxWidth = 150;
            this.NGAYBATDAx.MinWidth = 150;
            this.NGAYBATDAx.Name = "NGAYBATDAx";
            this.NGAYBATDAx.Visible = true;
            this.NGAYBATDAx.VisibleIndex = 3;
            this.NGAYBATDAx.Width = 150;
            // 
            // NGAYKETTHUC
            // 
            this.NGAYKETTHUC.Caption = "Ngày kết thúc";
            this.NGAYKETTHUC.FieldName = "NGAYKETTHUC";
            this.NGAYKETTHUC.MaxWidth = 150;
            this.NGAYKETTHUC.MinWidth = 150;
            this.NGAYKETTHUC.Name = "NGAYKETTHUC";
            this.NGAYKETTHUC.Visible = true;
            this.NGAYKETTHUC.VisibleIndex = 4;
            this.NGAYKETTHUC.Width = 150;
            // 
            // THOIHANHOPDONG
            // 
            this.THOIHANHOPDONG.Caption = "Thời Hạn";
            this.THOIHANHOPDONG.FieldName = "THOIHANHOPDONG";
            this.THOIHANHOPDONG.MaxWidth = 150;
            this.THOIHANHOPDONG.MinWidth = 150;
            this.THOIHANHOPDONG.Name = "THOIHANHOPDONG";
            this.THOIHANHOPDONG.Visible = true;
            this.THOIHANHOPDONG.VisibleIndex = 5;
            this.THOIHANHOPDONG.Width = 150;
            // 
            // LANKY
            // 
            this.LANKY.Caption = "Lần Ký";
            this.LANKY.FieldName = "LANKY";
            this.LANKY.MaxWidth = 60;
            this.LANKY.MinWidth = 60;
            this.LANKY.Name = "LANKY";
            this.LANKY.Visible = true;
            this.LANKY.VisibleIndex = 6;
            this.LANKY.Width = 60;
            // 
            // MANVHD
            // 
            this.MANVHD.Caption = "MANV";
            this.MANVHD.FieldName = "MANV";
            this.MANVHD.MaxWidth = 80;
            this.MANVHD.MinWidth = 80;
            this.MANVHD.Name = "MANVHD";
            this.MANVHD.Visible = true;
            this.MANVHD.VisibleIndex = 7;
            this.MANVHD.Width = 80;
            // 
            // HOTENNV
            // 
            this.HOTENNV.Caption = "Họ Tên";
            this.HOTENNV.FieldName = "HOTEN";
            this.HOTENNV.MaxWidth = 250;
            this.HOTENNV.MinWidth = 250;
            this.HOTENNV.Name = "HOTENNV";
            this.HOTENNV.Visible = true;
            this.HOTENNV.VisibleIndex = 8;
            this.HOTENNV.Width = 250;
            // 
            // HESOLUONG
            // 
            this.HESOLUONG.Caption = "Hệ số Lương";
            this.HESOLUONG.FieldName = "HESOLUONG";
            this.HESOLUONG.MinWidth = 25;
            this.HESOLUONG.Name = "HESOLUONG";
            this.HESOLUONG.Visible = true;
            this.HESOLUONG.VisibleIndex = 9;
            this.HESOLUONG.Width = 94;
            // 
            // LuongCoBan
            // 
            this.LuongCoBan.Caption = "Lương Cơ Bản";
            this.LuongCoBan.FieldName = "LuongCoBan";
            this.LuongCoBan.MinWidth = 25;
            this.LuongCoBan.Name = "LuongCoBan";
            this.LuongCoBan.Visible = true;
            this.LuongCoBan.VisibleIndex = 10;
            this.LuongCoBan.Width = 94;
            // 
            // TenTrangThai
            // 
            this.TenTrangThai.Caption = "Trạng Thái";
            this.TenTrangThai.FieldName = "TenTrangThai";
            this.TenTrangThai.MinWidth = 25;
            this.TenTrangThai.Name = "TenTrangThai";
            this.TenTrangThai.Visible = true;
            this.TenTrangThai.VisibleIndex = 11;
            this.TenTrangThai.Width = 94;
            // 
            // formHopDongCuaNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 451);
            this.Controls.Add(this.splitContainer1);
            this.Name = "formHopDongCuaNhanVien";
            this.Text = "Xem hợp đồng";
            this.Load += new System.EventHandler(this.formHopDongCuaNhanVien_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLapHopDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLapHopDong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.SimpleButton btnXemHopDongChiTietNhanVien;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControlLapHopDong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLapHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn IDHOPDONG;
        private DevExpress.XtraGrid.Columns.GridColumn MAHOPDONG;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYKY;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYBATDAx;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYKETTHUC;
        private DevExpress.XtraGrid.Columns.GridColumn THOIHANHOPDONG;
        private DevExpress.XtraGrid.Columns.GridColumn LANKY;
        private DevExpress.XtraGrid.Columns.GridColumn MANVHD;
        private DevExpress.XtraGrid.Columns.GridColumn HOTENNV;
        private DevExpress.XtraGrid.Columns.GridColumn HESOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn LuongCoBan;
        private DevExpress.XtraGrid.Columns.GridColumn TenTrangThai;
    }
}