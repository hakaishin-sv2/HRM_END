using BusinessLayer;
using BusinessLayer.LogIn;
using DevExpress.CodeParser;
using Newtonsoft.Json;
using Org.BouncyCastle.Tls;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HRM.LogIn
{



    //public partial class formLogIn : DevExpress.XtraEditors.XtraForm
    public partial class formLogIn : _BaseForm
    {
        const string CONNSTR_FILE = "data";

        bool IsFormLoaded = false;

        public formLogIn()
        {
            InitializeComponent();

            ReloadRemember();

            GetServerDropDown(false);
        }

        void ReloadRemember()
        {
            try
            {
                if (File.Exists(CONNSTR_FILE))
                {
                    string hashedCONN = File.ReadAllText(CONNSTR_FILE);

                    string _text = StringCipher.Decrypt(hashedCONN);

                    RememberLogin RememberData = JsonConvert.DeserializeObject<RememberLogin>(_text);

                    cbDatabase.Text = RememberData.DatabaseName;
                    textBoxPasswoed.Text = RememberData.Password;
                    checkEdit1.Checked = RememberData.Remember;                    
                    textBoxMaNV.Text = RememberData.UserName;

                    cbServer.Text = RememberData.ServerName;
                }
            }
            catch
            {

            }
        }

        User _us;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("xxxx");
            
            int manv = 0;
            bool IsOk = true;
            errorProvider1.Clear();

            if(string.IsNullOrEmpty(cbServer.Text.Trim()))
            {
                errorProvider1.SetError(simpleButton1, "Chưa chọn Máy chủ.");
                IsOk = false;
            }

            if (string.IsNullOrEmpty(cbDatabase.Text.Trim()))
            {
                errorProvider1.SetError(simpleButton2, "Chưa chọn Cơ sở dữ liệu.");
                IsOk = false;
            }

            if (string.IsNullOrEmpty(textBoxMaNV.Text.Trim()))
            {
                errorProvider1.SetError(textBoxMaNV, "Chưa nhập Mã nhân viên.");
                IsOk = false;
            }
            else
            {
                if (!int.TryParse(textBoxMaNV.Text, out manv))
                {
                    errorProvider1.SetError(textBoxMaNV, "Mã nhân viên phải là số!");
                    IsOk = false;
                }
            }

            if (string.IsNullOrEmpty(textBoxPasswoed.Text.Trim()))
            {
                errorProvider1.SetError(textBoxPasswoed, "Chưa nhập Mật khẩu.");
                IsOk = false;
            }

            if (IsOk)
            {
                //grHrm.Enabled = false;
                //Application.DoEvents();

                Login_Sql_Model m = new Login_Sql_Model
                {
                    ServerName = cbServer.Text.Trim(),
                    DatabaseName = cbDatabase.Text.Trim()
                    /*
                     public string ServerName { get; set; } = string.Empty;
            public string DatabaseName { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
                     */
                };
                Session.CONN_STR = m.CONNSTR;
                DoLogin(manv);

                //try
                //{
                    
                //}
                //catch(Exception ex) 
                //{
                //    //grHrm.Enabled = true;
                //    //Application.DoEvents();
                //}
            }

            return;
        }

        void DoLogin(int manv)
        {
            try
            {
                string password = textBoxPasswoed.Text;

                // Mã hóa mật khẩu
                string hashpassword = PasswordHelper.HashPassword(password);

                // Lấy thông tin người dùng từ cơ sở dữ liệu

                _us = new User();
                var user_login = _us.getItemByManv(manv, out string Error);

                // Kiểm tra mã nhân viên và mật khẩu
                if (user_login != null && user_login.MANV_LOGIN == manv && user_login.HASHPASSWORD == hashpassword)
                {
                    int role = int.Parse(user_login.ROLE.ToString());
                    Session.User = new User(manv, hashpassword, role);
                    this.Hide();

                    MainForm frmMain = new MainForm();
                    frmMain.ShowDialog();
                    this.Close();
                }
                else
                {
                    if (string.IsNullOrEmpty(Error) == false)
                    {
                        //Session.CONN_STR

                        this.GhiLog(Session.CONN_STR);
                        this.GhiLog(Error);
                    }

                    this.ShowError("Tài khoản hoặc mật khẩu không chính xác.");
                }
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine (ex.Message);   
                if(ex.InnerException != null) 
                {
                    sb.AppendLine(ex.InnerException.Message);
                }

                this.ShowError("Lỗi đăng nhập: " + sb.ToString());
            }
            finally
            {
                //grHrm.Enabled = true;
                //Application.DoEvents();
            }
        }


        //private void SaveDbDaChon()
        //{
        //    Login_Sql_Model login = new Login_Sql_Model();

        //    login.ServerName = cbSql.Text.Trim();
        //    login.DatabaseName = cbDatabase.Text.Trim();
        //    login.UserName = txtSqlUserName.Text.Trim();
        //    login.Password = txtSqlPassword.Text.Trim();
        //    login.IntegratedSecurity = chkSqlIntegratedSecurity.Checked;

        //    Session.CONN_STR_INIT = login.CONNSTR_INIT;
        //    Session.CONN_STR = login.CONNSTR;

        //    string LoginSqlInfoJson = JsonConvert.SerializeObject(login);

        //    string hashedCONN = StringCipher.Encrypt(LoginSqlInfoJson);

        //    //sau khi thiet lap data thanh cong moi luu conn
        //    System.IO.File.WriteAllText(CONNSTR_FILE, hashedCONN);

        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //this.Close();
            //Application.Restart();

            if (File.Exists("HRMConfiguration.exe"))
            {


                System.Diagnostics.Process.Start("HRMConfiguration.exe");
            }
            else
            {
                MessageBox.Show("không tìm thấy file HRMConfiguration.exe\r\nVui lòng liên hệ người quản trị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangNhapSql_Click(object sender, EventArgs e)
        {
            if(System.IO.File.Exists(CONNSTR_FILE))
            {
                if(MessageBox.Show("Thiết lập lại cơ sở dữ liệu lại sẽ làm mất dữ liệu hiện có\r\nBạn muốn thực hiện không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            Login_Sql_Model login = new Login_Sql_Model();

            login.ServerName = cbSql.Text.Trim();
            login.DatabaseName = txtSqlDatabaseName.Text.Trim();
            login.UserName = txtSqlUserName.Text.Trim();
            login.Password = txtSqlPassword.Text.Trim();
            login.IntegratedSecurity = chkSqlIntegratedSecurity.Checked;

            Session.CONN_STR_INIT = login.CONNSTR_INIT;
            Session.CONN_STR = login.CONNSTR;

            Init init = new Init();
            bool res= init.SetupDB("", login.DatabaseName, out string Err);


            if (res)
            {
                string LoginSqlInfoJson = JsonConvert.SerializeObject(login);

                string hashedCONN = StringCipher.Encrypt(LoginSqlInfoJson);

                //sau khi thiet lap data thanh cong moi luu conn
                System.IO.File.WriteAllText(CONNSTR_FILE, hashedCONN);

                //day la dang nhap lan dau nen cai script ở đây
                MessageBox.Show("Da tao thanh cong co so du lieu mau", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                grHrm.Enabled = true;
            }
            else
            {
                if (string.IsNullOrEmpty(Err))
                {
                    Err = "Khong the tao co so du lieu";
                }

                MessageBox.Show(Err, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);


                ////this will try to get the administrator rights if the user is an admin                           
                //System.AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);

                bool IsAdministrator = principal.IsInRole(WindowsBuiltInRole.Administrator);

                if (IsAdministrator == false)
                {
                    //Init a new instance of the program
                    ProcessStartInfo startInfo = new ProcessStartInfo(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, "admin");
                    startInfo.UseShellExecute = true;
                    startInfo.Verb = "runas";
                    System.Diagnostics.Process.Start(startInfo);
                    //no need for Application.Exit()
                }
            }
        }


        void GetServerDropDown(bool IsShowDropDown = true)
        {
            try
            {
                cbServer.Items.Clear();
                string ServerName = Environment.MachineName;
                Microsoft.Win32.RegistryView registryView = Environment.Is64BitOperatingSystem ? Microsoft.Win32.RegistryView.Registry64 : Microsoft.Win32.RegistryView.Registry32;
                using (Microsoft.Win32.RegistryKey hklm = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, registryView))
                {
                    Microsoft.Win32.RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                    if (instanceKey != null)
                    {
                        foreach (var instanceName in instanceKey.GetValueNames())
                        {
                            if (instanceName == "MSSQLSERVER")
                            {
                                cbServer.Items.Add(ServerName);

                            }
                            else
                            {
                                cbServer.Items.Add(ServerName + "\\" + instanceName);
                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                this.ShowError(ex.Message);
            }
            finally
            {
                if (IsShowDropDown)
                {
                    if (cbServer.Items.Count > 0)
                    {
                        cbServer.DroppedDown = true;
                    }
                }
            }
        }

        string MasterCnn
        {
            get
            {
                return this.GetConn_Master(cbServer.Text);
            }
        }

        void GetDatabaseDropDown(bool IsShowDropDown = true)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                SqlConnection masterConn = new SqlConnection(MasterCnn);

                try
                {
                    masterConn.Open();

                    cbDatabase.Items.Clear();
                    //  retrieve the name of all the databases from the sysdatabases table
                    using (SqlCommand cmd = new SqlCommand("SELECT [name] FROM sysdatabases", masterConn))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                cbDatabase.Items.Add(rdr["name"].ToString());
                            }
                        }
                    }
                }
                catch(Exception _ex)
                {
                    sb.Append(_ex.Message);
                }
                finally
                {
                    masterConn.Close();
                }
            }
            catch (Exception ex)
            {
                sb.Append(ex.Message);
                
            }
            finally
            {
                string Err = sb.ToString();
                if(string.IsNullOrEmpty(Err) == false)
                {
                    this.ShowError(Err);
                }

                if(IsShowDropDown)
                {
                    if (cbDatabase.Items.Count > 0)
                    {
                        cbDatabase.DroppedDown = true;
                    }
                }
            }

        }

        private void formLogIn_Load(object sender, EventArgs e)
        {



            IsFormLoaded = true;


                        //    Login_Sql_Model m = new Login_Sql_Model 
            //    {
            //        ServerName = cbServer.Text.Trim(),
            //        DatabaseName = cbDatabase.Text.Trim()
            //        /*
            //         public string ServerName { get; set; } = string.Empty;
            //public string DatabaseName { get; set; } = string.Empty;
            //public string UserName { get; set; } = string.Empty;
            //public string Password { get; set; } = string.Empty;
            //         */
            //    };
            //    Session.CONN_STR =  m.CONNSTR;

            return;
            
            bool IsClosed = false;

            if (System.IO.File.Exists(CONNSTR_FILE) == false)
            {
                var dlg = MessageBox.Show("Chưa có cơ sở dữ liệu mẫu.\r\nBạn có muốn thiết lập ngay bây giờ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dlg == DialogResult.Yes)
                {
                    IsClosed = true;
                }
            }
            else
            {

                //Required admin runtime: https://stackoverflow.com/questions/75210227/request-administrator-rights-at-runtime

                //chay thu ben release xem

                //string fn = "BangCong_Layout.xml";

                //if (File.Exists(fn) == false)
                //{
                //    string xmlBangCong = Properties.Resources.BangCong_Layout;
                //    File.WriteAllText(fn, xmlBangCong);
                //}


                //GetSqlDropDown();            

                //chkSqlIntegratedSecurity_CheckedChanged(null, null);

                if (System.IO.File.Exists(CONNSTR_FILE))
                {
                    string CONN = StringCipher.Decrypt(System.IO.File.ReadAllText(CONNSTR_FILE));

                    Login_Sql_Model obj = JsonConvert.DeserializeObject<Login_Sql_Model>(CONN);

                    cbSql.Text = obj.ServerName;
                    txtSqlDatabaseName.Text = obj.DatabaseName;
                    txtSqlUserName.Text = obj.UserName;
                    txtSqlPassword.Text = obj.Password;
                    chkSqlIntegratedSecurity.Checked = obj.IntegratedSecurity;
                    chkSqlIntegratedSecurity_CheckedChanged(null, null);

                    Session.CONN_STR = obj.CONNSTR;

                    Session.CONN_STR_INIT = obj.CONNSTR_INIT;

                    //grSql.Enabled = false;
                    grHrm.Enabled = true;

                    GetSqlDropDownLogin();

                    foreach (var item in cbDatabase.Items)
                    {
                        if (item.ToString() == obj.DatabaseName)
                        {
                            cbDatabase.SelectedItem = item;
                            break;
                        }
                    }

                }
                else
                {
                    //grHrm.Enabled = false;
                    //grSql.Enabled = true;
                }
            }

            this.Activate();

            //Task.Run(() =>
            //{

            //}).GetAwaiter().GetResult();

            if (IsClosed)
            {
                if(File.Exists("HRMConfiguration.exe"))
                {


                    System.Diagnostics.Process.Start("HRMConfiguration.exe");
                }
                else
                {
                    MessageBox.Show("không tìm thấy file HRMConfiguration.exe\r\nVui lòng liên hệ người quản trị.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Application.Exit();
            }
        }

        private void GetSqlDropDownLogin()
        {
            
        }

        private void chkSqlIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSqlIntegratedSecurity.Checked)
            {
                txtSqlPassword.Enabled = txtSqlUserName.Enabled = false;
            }
            else
            {
                txtSqlPassword.Enabled = txtSqlUserName.Enabled = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GetServerDropDown();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GetDatabaseDropDown();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbServer.SelectedIndex >=0)
            {
                simpleButton2.PerformClick();
            }
        }

        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDatabase.SelectedIndex >= 0)
            {
                textBoxMaNV.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(string.IsNullOrEmpty(cbDatabase.Text) == false)
            {

                bool IsCheck = false;
                foreach (var item in cbDatabase.Items)
                {
                    if (item.ToString().ToLower() == cbDatabase.Text.ToLower())
                    {
                        IsCheck = true;

                        break;
                    }
                }

                if (IsCheck)
                {
                    this.ShowError($"Cơ sở dữ liệu {cbDatabase.Text} đã tồn tại.\r\nVui lòng nhập tên cơ sở dữ liệu khác.");

                    return;
                }

                Init init = new Init();
                bool res = init.SetupDB(MasterCnn, cbDatabase.Text, out string Err);

                if(res)
                {
                    this.ShowInfo("Khởi tạo dữ liệu thành công.\r\nBạn có thể sử dụng HRM...");
                    textBoxMaNV.Focus();
                }
                else
                {
                    if(string.IsNullOrEmpty(Err))
                    {
                        this.ShowError($"Có lỗi khi khởi tạo dữ liệu.\r\nVui lòng thử lại sau hoặc liên hệ người quản trị.");
                    }
                    else
                    {
                        if(Err.ToLower().Contains("already exists"))
                        {
                            this.ShowError($"Cơ sở dữ liệu {cbDatabase.Text} đã tồn tại.\r\nVui lòng nhập tên cơ sở dữ liệu khác.");
                        }
                        else
                        {
                            this.ShowError($"{Err}");
                        }
                    }
                }
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if(IsFormLoaded)
            {
                if(checkEdit1.Checked == false)
                {
                    if (File.Exists(CONNSTR_FILE))
                    {

                        ProcessStartInfo ps = new ProcessStartInfo();
                        ps.FileName = "HRM_Ext.exe";
                        ps.Verb = "runas";

                        if (File.Exists(ps.FileName) == false)
                        {
                            this.ShowError($"File {ps.FileName} không tìm thấy.\r\nLiên hệ người quản trị.");

                            return;
                        }

                        ps.Arguments = "DEL";
                        var process = new Process();
                        process.StartInfo = ps;
                        process.Start();
                    }
                }
                else
                {

                    RememberLogin remember = new RememberLogin
                    {
                        DatabaseName = cbDatabase.Text.Trim(),
                        Password = textBoxPasswoed.Text.Trim(),
                        Remember = checkEdit1.Checked,
                        ServerName = cbServer.Text.Trim(),
                        UserName = textBoxMaNV.Text.Trim()
                    };

                    if (File.Exists(CONNSTR_FILE))
                    {
                        string _f = File.ReadAllText(CONNSTR_FILE);

                        string _t = StringCipher.Decrypt(_f);

                        RememberLogin old = JsonConvert.DeserializeObject<RememberLogin>(_t);

                    }

                    string JsonRemember = JsonConvert.SerializeObject(remember);

                    string hashedCONN = StringCipher.Encrypt(JsonRemember);


                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.FileName = "HRM_Ext.exe";
                    ps.Verb = "runas";

                    if (File.Exists(ps.FileName) == false)
                    {
                        this.ShowError($"File {ps.FileName} không tìm thấy.\r\nLiên hệ người quản trị.");

                        return;
                    }


                    ps.Arguments = hashedCONN;

                    var process = new Process();
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo = ps;

                    try
                    {
                        process.Start();
                        process.WaitForInputIdle();
                        while (process.MainWindowHandle == IntPtr.Zero)
                        {
                            Thread.Sleep(100);
                            process.Refresh();

                        }
                    }
                    catch
                    {

                    }
                }





                //ProcessStartInfo ps = new ProcessStartInfo();
                //ps.FileName = "HRM_Ext.exe";
                //ps.Verb = "runas";

                //if (File.Exists(ps.FileName) == false)
                //{
                //    this.ShowError($"File {ps.FileName} không tìm thấy.\r\nLiên hệ người quản trị.");

                //    return;
                //}

                //if (checkEdit1.Checked)
                //{
                //    RememberLogin remember = new RememberLogin
                //    {
                //        DatabaseName = cbDatabase.Text.Trim(),
                //        Password = textBoxPasswoed.Text.Trim(),
                //        Remember = checkEdit1.Checked,
                //        ServerName = cbServer.Text.Trim(),
                //        UserName = textBoxMaNV.Text.Trim()
                //    };

                //    string JsonRemember = JsonConvert.SerializeObject(remember);

                //    string hashedCONN = StringCipher.Encrypt(JsonRemember);

                //    ps.Arguments = hashedCONN;
                //}
                //else
                //{
                //    ps.Arguments = "DEL";
                //}

                //var process = new Process();
                //process.StartInfo = ps;
                //process.Start();
            }
        }
    }
}