namespace HRM.ChamCong
{
    partial class formInBangCongNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formInBangCongNhanVien));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMaKyCong = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchLookUpEditTimNhanVien = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MANV_HD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HOTEN_HD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENCV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditTimNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Kỳ Công";
            // 
            // comboBoxMaKyCong
            // 
            this.comboBoxMaKyCong.FormattingEnabled = true;
            this.comboBoxMaKyCong.Location = new System.Drawing.Point(154, 53);
            this.comboBoxMaKyCong.Name = "comboBoxMaKyCong";
            this.comboBoxMaKyCong.Size = new System.Drawing.Size(121, 29);
            this.comboBoxMaKyCong.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nhân Viên";
            // 
            // searchLookUpEditTimNhanVien
            // 
            this.searchLookUpEditTimNhanVien.EditValue = "";
            this.searchLookUpEditTimNhanVien.Location = new System.Drawing.Point(154, 122);
            this.searchLookUpEditTimNhanVien.Margin = new System.Windows.Forms.Padding(5);
            this.searchLookUpEditTimNhanVien.Name = "searchLookUpEditTimNhanVien";
            this.searchLookUpEditTimNhanVien.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLookUpEditTimNhanVien.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpEditTimNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEditTimNhanVien.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchLookUpEditTimNhanVien.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.searchLookUpEditTimNhanVien.Size = new System.Drawing.Size(328, 28);
            this.searchLookUpEditTimNhanVien.TabIndex = 50;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MANV_HD,
            this.HOTEN_HD,
            this.TENCV});
            this.searchLookUpEdit1View.DetailHeight = 546;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // MANV_HD
            // 
            this.MANV_HD.Caption = "Mã NV";
            this.MANV_HD.FieldName = "MANV";
            this.MANV_HD.MaxWidth = 77;
            this.MANV_HD.MinWidth = 77;
            this.MANV_HD.Name = "MANV_HD";
            this.MANV_HD.Visible = true;
            this.MANV_HD.VisibleIndex = 0;
            this.MANV_HD.Width = 77;
            // 
            // HOTEN_HD
            // 
            this.HOTEN_HD.Caption = "Họ Tên";
            this.HOTEN_HD.FieldName = "HOTEN";
            this.HOTEN_HD.MaxWidth = 390;
            this.HOTEN_HD.MinWidth = 390;
            this.HOTEN_HD.Name = "HOTEN_HD";
            this.HOTEN_HD.Visible = true;
            this.HOTEN_HD.VisibleIndex = 1;
            this.HOTEN_HD.Width = 390;
            // 
            // TENCV
            // 
            this.TENCV.Caption = "Chức Vụ";
            this.TENCV.FieldName = "TENCV";
            this.TENCV.MinWidth = 31;
            this.TENCV.Name = "TENCV";
            this.TENCV.Visible = true;
            this.TENCV.VisibleIndex = 2;
            this.TENCV.Width = 117;
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            this.btnPrint.Location = new System.Drawing.Point(42, 216);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPrint.Size = new System.Drawing.Size(138, 43);
            this.btnPrint.TabIndex = 51;
            this.btnPrint.Text = "In Chi Tiết";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.Location = new System.Drawing.Point(230, 216);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 36);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.comboBoxMaKyCong);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.searchLookUpEditTimNhanVien);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(148, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 301);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export  File";
            // 
            // formInBangCongNhanVien
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 377);
            this.Controls.Add(this.groupBox1);
            this.Name = "formInBangCongNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Bảng Công Nhân Viên";
            this.Load += new System.EventHandler(this.formInBangCongNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEditTimNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMaKyCong;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEditTimNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn MANV_HD;
        private DevExpress.XtraGrid.Columns.GridColumn HOTEN_HD;
        private DevExpress.XtraGrid.Columns.GridColumn TENCV;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}