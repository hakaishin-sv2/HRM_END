namespace HRMConfig
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSqlDatabaseName = new TextBox();
            txtSqlUserName = new TextBox();
            txtSqlPassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cbSql = new ComboBox();
            label4 = new Label();
            chkSqlIntegratedSecurity = new CheckBox();
            button1 = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(114, 147);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(32, 23);
            label1.TabIndex = 0;
            label1.Text = "DB";
            // 
            // txtSqlDatabaseName
            // 
            txtSqlDatabaseName.Font = new Font("Segoe UI", 10.2F);
            txtSqlDatabaseName.Location = new Point(157, 143);
            txtSqlDatabaseName.Margin = new Padding(4);
            txtSqlDatabaseName.Name = "txtSqlDatabaseName";
            txtSqlDatabaseName.Size = new Size(358, 30);
            txtSqlDatabaseName.TabIndex = 1;
            // 
            // txtSqlUserName
            // 
            txtSqlUserName.Font = new Font("Segoe UI", 10.2F);
            txtSqlUserName.Location = new Point(157, 195);
            txtSqlUserName.Margin = new Padding(4);
            txtSqlUserName.Name = "txtSqlUserName";
            txtSqlUserName.Size = new Size(358, 30);
            txtSqlUserName.TabIndex = 2;
            // 
            // txtSqlPassword
            // 
            txtSqlPassword.Font = new Font("Segoe UI", 10.2F);
            txtSqlPassword.Location = new Point(157, 247);
            txtSqlPassword.Margin = new Padding(4);
            txtSqlPassword.Name = "txtSqlPassword";
            txtSqlPassword.Size = new Size(358, 30);
            txtSqlPassword.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F);
            label2.Location = new Point(95, 200);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 23);
            label2.TabIndex = 4;
            label2.Text = "USER";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F);
            label3.Location = new Point(97, 253);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(48, 23);
            label3.TabIndex = 5;
            label3.Text = "PWD";
            // 
            // cbSql
            // 
            cbSql.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSql.Font = new Font("Segoe UI", 10.2F);
            cbSql.FormattingEnabled = true;
            cbSql.Location = new Point(157, 89);
            cbSql.Margin = new Padding(4);
            cbSql.Name = "cbSql";
            cbSql.Size = new Size(358, 31);
            cbSql.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F);
            label4.Location = new Point(76, 92);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(68, 23);
            label4.TabIndex = 7;
            label4.Text = "SERVER";
            // 
            // chkSqlIntegratedSecurity
            // 
            chkSqlIntegratedSecurity.AutoSize = true;
            chkSqlIntegratedSecurity.Font = new Font("Segoe UI", 10.2F);
            chkSqlIntegratedSecurity.Location = new Point(338, 293);
            chkSqlIntegratedSecurity.Name = "chkSqlIntegratedSecurity";
            chkSqlIntegratedSecurity.Size = new Size(177, 27);
            chkSqlIntegratedSecurity.TabIndex = 8;
            chkSqlIntegratedSecurity.Text = "Integrated Security";
            chkSqlIntegratedSecurity.UseVisualStyleBackColor = true;
            chkSqlIntegratedSecurity.CheckedChanged += chkSqlIntegratedSecurity_CheckedChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10.2F);
            button1.Location = new Point(227, 366);
            button1.Name = "button1";
            button1.Size = new Size(288, 39);
            button1.TabIndex = 9;
            button1.Text = "Thiết lập dữ liệu lần đầu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(109, 20);
            label5.Name = "label5";
            label5.Size = new Size(372, 41);
            label5.TabIndex = 10;
            label5.Text = "KHỞI TẠO DỮ LIỆU MẪU....";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 435);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(chkSqlIntegratedSecurity);
            Controls.Add(label4);
            Controls.Add(cbSql);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtSqlPassword);
            Controls.Add(txtSqlUserName);
            Controls.Add(txtSqlDatabaseName);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HRM";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSqlDatabaseName;
        private TextBox txtSqlUserName;
        private TextBox txtSqlPassword;
        private Label label2;
        private Label label3;
        private ComboBox cbSql;
        private Label label4;
        private CheckBox chkSqlIntegratedSecurity;
        private Button button1;
        private Label label5;
    }
}
