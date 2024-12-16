using BusinessLayer;
using BusinessLayer.LogIn;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM.LogIn
{
    public partial class formDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public formDoiMatKhau()
        {
            InitializeComponent();
        }
        User _user;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            int manvSesion = Session.User.MANV;
            int Manv = int.Parse(textBoxMaNV.Text);
            string oldpassword = textBoxPasswordOld.Text;
            string newpassword = textBoxPasswordNew.Text;
            _user = new User();
            var nvDMK = _user.getItemByManv(Manv, out _);
            if(nvDMK == null )
            {
                MessageBox.Show("Thông tin không tồn tại!", "Cảnh báo", MessageBoxButtons.OK);
            }
            else if( nvDMK.PASSWORD != oldpassword )
            {
                MessageBox.Show("Thông tin không mật khẩu không chính xác!", "Cảnh báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thành công", "Cảnh báo", MessageBoxButtons.OK);
                nvDMK.PASSWORD = newpassword;
                string hashpass = PasswordHelper.HashPassword(newpassword);
                nvDMK.HASHPASSWORD = hashpass;
                _user.Update(nvDMK);
            }
        }

        private void formDoiMatKhau_Load(object sender, EventArgs e)
        {
            textBoxMaNV.Text = Session.User.MANV.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}