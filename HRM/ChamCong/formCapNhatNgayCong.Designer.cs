namespace HRM.ChamCong
{
    partial class formCapNhatNgayCong
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
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.monthCalendarNgayCong = new System.Windows.Forms.MonthCalendar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.radioGroupChamCong = new DevExpress.XtraEditors.RadioGroup();
            this.groupControlTimeNghi = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioGroupTimeNghi = new DevExpress.XtraEditors.RadioGroup();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupControlThongTinNhanVien = new DevExpress.XtraEditors.GroupControl();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMaNv = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupChamCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTimeNghi)).BeginInit();
            this.groupControlTimeNghi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupTimeNghi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlThongTinNhanVien)).BeginInit();
            this.groupControlThongTinNhanVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCapNhat.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(230, 440);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(136, 54);
            this.btnCapNhat.TabIndex = 0;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // monthCalendarNgayCong
            // 
            this.monthCalendarNgayCong.Location = new System.Drawing.Point(18, 18);
            this.monthCalendarNgayCong.Name = "monthCalendarNgayCong";
            this.monthCalendarNgayCong.TabIndex = 1;
            this.monthCalendarNgayCong.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarNgayCong_DateChanged);
            this.monthCalendarNgayCong.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarNgayCong_DateSelected);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.radioGroupChamCong);
            this.groupControl1.Location = new System.Drawing.Point(336, 30);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(277, 186);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Chấm công";
            // 
            // radioGroupChamCong
            // 
            this.radioGroupChamCong.EditValue = "P";
            this.radioGroupChamCong.Location = new System.Drawing.Point(9, 36);
            this.radioGroupChamCong.Name = "radioGroupChamCong";
            this.radioGroupChamCong.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("P", "Nghỉ Phép"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("V", "Vắng"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("VCN", "Việc Cá Nhân"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("LCN", "Làm thêm chủ nhật")});
            this.radioGroupChamCong.Size = new System.Drawing.Size(263, 150);
            this.radioGroupChamCong.TabIndex = 0;
            // 
            // groupControlTimeNghi
            // 
            this.groupControlTimeNghi.Controls.Add(this.groupBox1);
            this.groupControlTimeNghi.Controls.Add(this.radioGroupTimeNghi);
            this.groupControlTimeNghi.Location = new System.Drawing.Point(336, 236);
            this.groupControlTimeNghi.Name = "groupControlTimeNghi";
            this.groupControlTimeNghi.Size = new System.Drawing.Size(277, 159);
            this.groupControlTimeNghi.TabIndex = 3;
            this.groupControlTimeNghi.Text = "Thời Gian Nghỉ";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(62, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // radioGroupTimeNghi
            // 
            this.radioGroupTimeNghi.EditValue = "NN";
            this.radioGroupTimeNghi.Location = new System.Drawing.Point(5, 31);
            this.radioGroupTimeNghi.Name = "radioGroupTimeNghi";
            this.radioGroupTimeNghi.Properties.Columns = 2;
            this.radioGroupTimeNghi.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("S", "Sáng"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("C", "Chiều"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("NN", "Nguyên Ngày")});
            this.radioGroupTimeNghi.Size = new System.Drawing.Size(263, 105);
            this.radioGroupTimeNghi.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Red;
            this.buttonClose.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(389, 440);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(136, 54);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Đóng";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupControlThongTinNhanVien
            // 
            this.groupControlThongTinNhanVien.Controls.Add(this.lblPhongBan);
            this.groupControlThongTinNhanVien.Controls.Add(this.label5);
            this.groupControlThongTinNhanVien.Controls.Add(this.lblHoTen);
            this.groupControlThongTinNhanVien.Controls.Add(this.label3);
            this.groupControlThongTinNhanVien.Controls.Add(this.lblMaNv);
            this.groupControlThongTinNhanVien.Controls.Add(this.label1);
            this.groupControlThongTinNhanVien.Location = new System.Drawing.Point(18, 237);
            this.groupControlThongTinNhanVien.Name = "groupControlThongTinNhanVien";
            this.groupControlThongTinNhanVien.Size = new System.Drawing.Size(312, 192);
            this.groupControlThongTinNhanVien.TabIndex = 5;
            this.groupControlThongTinNhanVien.Text = "Thông tin nhân viên";
            // 
            // lblPhongBan
            // 
            this.lblPhongBan.AutoSize = true;
            this.lblPhongBan.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhongBan.Location = new System.Drawing.Point(111, 144);
            this.lblPhongBan.Name = "lblPhongBan";
            this.lblPhongBan.Size = new System.Drawing.Size(87, 21);
            this.lblPhongBan.TabIndex = 8;
            this.lblPhongBan.Text = "phòng ban";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Phòng ban:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(111, 98);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(63, 21);
            this.lblHoTen.TabIndex = 6;
            this.lblHoTen.Text = "Họ Tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Họ Tên :";
            // 
            // lblMaNv
            // 
            this.lblMaNv.AutoSize = true;
            this.lblMaNv.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNv.Location = new System.Drawing.Point(111, 53);
            this.lblMaNv.Name = "lblMaNv";
            this.lblMaNv.Size = new System.Drawing.Size(58, 21);
            this.lblMaNv.TabIndex = 4;
            this.lblMaNv.Text = "Mã NV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã NV:";
            // 
            // formCapNhatNgayCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 506);
            this.Controls.Add(this.groupControlThongTinNhanVien);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupControlTimeNghi);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.monthCalendarNgayCong);
            this.Controls.Add(this.btnCapNhat);
            this.Name = "formCapNhatNgayCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chấm công thủ công";
            this.Load += new System.EventHandler(this.formCapNhatNgayCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupChamCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTimeNghi)).EndInit();
            this.groupControlTimeNghi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupTimeNghi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlThongTinNhanVien)).EndInit();
            this.groupControlThongTinNhanVien.ResumeLayout(false);
            this.groupControlThongTinNhanVien.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.MonthCalendar monthCalendarNgayCong;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroupChamCong;
        private DevExpress.XtraEditors.GroupControl groupControlTimeNghi;
        private DevExpress.XtraEditors.RadioGroup radioGroupTimeNghi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonClose;
        private DevExpress.XtraEditors.GroupControl groupControlThongTinNhanVien;
        private System.Windows.Forms.Label lblPhongBan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMaNv;
        private System.Windows.Forms.Label label1;
    }
}