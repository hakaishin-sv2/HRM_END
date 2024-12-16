using System;
using System.IO;
using System.Windows.Forms;

namespace HRM
{
    public class _BaseForm : DevExpress.XtraEditors.XtraForm
    {
        

        public string _CFG_UPLOAD_FOLDER
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["UploadFolder"];
            }
        }

        public void GhiLog(string LogMsg)
        {
            string _Msg = $"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}: {LogMsg}\r\n";

            File.AppendAllText(_CFG_LOG_FILE, _Msg);
        }

        string _CFG_LOG_FILE
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["LogFile"];
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // _BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(298, 260);
            this.Name = "_BaseForm";
            this.Load += new System.EventHandler(this._BaseForm_Load);
            this.ResumeLayout(false);

        }

        protected string GetConn_Master (string Server)
        {
            return $"Server={Server};Database=master;Trusted_Connection=True;TrustServerCertificate=True";
        }


        private void _BaseForm_Load(object sender, EventArgs e)
        {

        }

        protected void ShowError(string Err)
        {
            MessageBox.Show(Err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void ShowInfo(string Msg)
        {
            MessageBox.Show(Msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected DialogResult ShowConfirm_YesNo(string Msg)
        {
            return MessageBox.Show(Msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
