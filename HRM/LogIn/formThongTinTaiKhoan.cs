using BusinessLayer;
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
    public partial class formThongTinTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public formThongTinTaiKhoan()
        {
            InitializeComponent();
        }
        NhanVien _nhanVien;
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void formThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            textBoxMaNV.Text = Session.User.MANV.ToString();
            _nhanVien = new NhanVien(); 
            var nvdto = _nhanVien.getNhanVienDTO(Session.User.MANV);
            _BaseForm baseForm = new _BaseForm();
            pictureBoxHinhAnh.ImageLocation = baseForm._CFG_UPLOAD_FOLDER + nvdto.IMGPATH;
            textBoxHoTen.Text = nvdto.HOTEN;
            textBoxPhongBan.Text = nvdto.TENPB;
            string tenChucVu="";
            if (Session.User.Role == 0)
            {
                tenChucVu = "Nhân Viên";
            }else if(Session.User.Role == 1)
            {
                tenChucVu = "Trưởng Phòng";
            }else if(Session.User.Role == 2)
            {
                tenChucVu = "Giám Đốc";
            }
            textBoxChucVu.Text = tenChucVu;

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}