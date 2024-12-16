namespace HRM.formRoleNhanVien
{
    partial class formPhuCapNhanVien
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControlPhuCap = new DevExpress.XtraGrid.GridControl();
            this.gridViewPhuCap = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENPC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOIDUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TrangThaiPhuCap = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhuCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhuCap)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1248, 450);
            this.splitContainer1.SplitterDistance = 416;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gridControlPhuCap);
            this.splitContainer2.Size = new System.Drawing.Size(1248, 416);
            this.splitContainer2.SplitterDistance = 83;
            this.splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH CÁC PHỤ CẤP CÔNG TY";
            // 
            // gridControlPhuCap
            // 
            this.gridControlPhuCap.Location = new System.Drawing.Point(6, -4);
            this.gridControlPhuCap.MainView = this.gridViewPhuCap;
            this.gridControlPhuCap.Name = "gridControlPhuCap";
            this.gridControlPhuCap.Size = new System.Drawing.Size(1237, 299);
            this.gridControlPhuCap.TabIndex = 1;
            this.gridControlPhuCap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPhuCap});
            // 
            // gridViewPhuCap
            // 
            this.gridViewPhuCap.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.TENPC,
            this.SOTIEN,
            this.NOIDUNG,
            this.TrangThaiPhuCap});
            this.gridViewPhuCap.GridControl = this.gridControlPhuCap;
            this.gridViewPhuCap.Name = "gridViewPhuCap";
            this.gridViewPhuCap.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.MinWidth = 25;
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 41;
            // 
            // TENPC
            // 
            this.TENPC.Caption = "Loại Phụ Cấp";
            this.TENPC.FieldName = "TENPHUCAP";
            this.TENPC.MinWidth = 25;
            this.TENPC.Name = "TENPC";
            this.TENPC.Visible = true;
            this.TENPC.VisibleIndex = 1;
            this.TENPC.Width = 169;
            // 
            // SOTIEN
            // 
            this.SOTIEN.Caption = "Số Tiền";
            this.SOTIEN.DisplayFormat.FormatString = "{0:n0} VNĐ";
            this.SOTIEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.SOTIEN.FieldName = "SOTIENPHUCAP";
            this.SOTIEN.MinWidth = 200;
            this.SOTIEN.Name = "SOTIEN";
            this.SOTIEN.Visible = true;
            this.SOTIEN.VisibleIndex = 2;
            this.SOTIEN.Width = 200;
            // 
            // NOIDUNG
            // 
            this.NOIDUNG.Caption = "Nội Dung";
            this.NOIDUNG.FieldName = "NOIDUNG";
            this.NOIDUNG.MinWidth = 250;
            this.NOIDUNG.Name = "NOIDUNG";
            this.NOIDUNG.Visible = true;
            this.NOIDUNG.VisibleIndex = 3;
            this.NOIDUNG.Width = 250;
            // 
            // TrangThaiPhuCap
            // 
            this.TrangThaiPhuCap.Caption = "Trạng Thái";
            this.TrangThaiPhuCap.FieldName = "TrangThaiPhuCap";
            this.TrangThaiPhuCap.MinWidth = 25;
            this.TrangThaiPhuCap.Name = "TrangThaiPhuCap";
            this.TrangThaiPhuCap.Visible = true;
            this.TrangThaiPhuCap.VisibleIndex = 4;
            this.TrangThaiPhuCap.Width = 94;
            // 
            // formPhuCapNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "formPhuCapNhanVien";
            this.Text = "Phụ cấp nhân viên";
            this.Load += new System.EventHandler(this.formPhuCapNhanVien_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPhuCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhuCap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControlPhuCap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPhuCap;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn TENPC;
        private DevExpress.XtraGrid.Columns.GridColumn SOTIEN;
        private DevExpress.XtraGrid.Columns.GridColumn NOIDUNG;
        private DevExpress.XtraGrid.Columns.GridColumn TrangThaiPhuCap;
    }
}