namespace HRMConfiguration
{
    partial class Form1
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
            this.cbSql = new System.Windows.Forms.ComboBox();
            this.chkSqlIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.txtSqlDatabaseName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSqlPassword = new System.Windows.Forms.TextBox();
            this.txtSqlUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbSql
            // 
            this.cbSql.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSql.FormattingEnabled = true;
            this.cbSql.Location = new System.Drawing.Point(232, 93);
            this.cbSql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSql.Name = "cbSql";
            this.cbSql.Size = new System.Drawing.Size(254, 28);
            this.cbSql.TabIndex = 10;
            // 
            // chkSqlIntegratedSecurity
            // 
            this.chkSqlIntegratedSecurity.AutoSize = true;
            this.chkSqlIntegratedSecurity.Checked = true;
            this.chkSqlIntegratedSecurity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSqlIntegratedSecurity.Location = new System.Drawing.Point(250, 261);
            this.chkSqlIntegratedSecurity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSqlIntegratedSecurity.Name = "chkSqlIntegratedSecurity";
            this.chkSqlIntegratedSecurity.Size = new System.Drawing.Size(169, 24);
            this.chkSqlIntegratedSecurity.TabIndex = 17;
            this.chkSqlIntegratedSecurity.Text = "Integrated security";
            this.chkSqlIntegratedSecurity.UseVisualStyleBackColor = true;
            this.chkSqlIntegratedSecurity.CheckedChanged += new System.EventHandler(this.chkSqlIntegratedSecurity_CheckedChanged);
            // 
            // txtSqlDatabaseName
            // 
            this.txtSqlDatabaseName.Location = new System.Drawing.Point(232, 135);
            this.txtSqlDatabaseName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSqlDatabaseName.Name = "txtSqlDatabaseName";
            this.txtSqlDatabaseName.Size = new System.Drawing.Size(254, 27);
            this.txtSqlDatabaseName.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 131);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Database Name";
            // 
            // txtSqlPassword
            // 
            this.txtSqlPassword.Location = new System.Drawing.Point(232, 218);
            this.txtSqlPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.Size = new System.Drawing.Size(254, 27);
            this.txtSqlPassword.TabIndex = 16;
            // 
            // txtSqlUserName
            // 
            this.txtSqlUserName.Location = new System.Drawing.Point(232, 177);
            this.txtSqlUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSqlUserName.Name = "txtSqlUserName";
            this.txtSqlUserName.Size = new System.Drawing.Size(254, 27);
            this.txtSqlUserName.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 214);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "Pasword";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Server";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(256, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Khởi tạo dữ liệu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "KHỞI TẠO DỮ LIỆU MẪU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 392);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbSql);
            this.Controls.Add(this.chkSqlIntegratedSecurity);
            this.Controls.Add(this.txtSqlDatabaseName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSqlPassword);
            this.Controls.Add(this.txtSqlUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HRM Configuration";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSql;
        private System.Windows.Forms.CheckBox chkSqlIntegratedSecurity;
        private System.Windows.Forms.TextBox txtSqlDatabaseName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSqlPassword;
        private System.Windows.Forms.TextBox txtSqlUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

