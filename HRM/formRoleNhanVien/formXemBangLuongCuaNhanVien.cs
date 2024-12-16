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
using BusinessLayer;
using BusinessLayer.ClassChamCong;
using HRM.Report;
using DevExpress.XtraReports.UI;
using BusinessLayer.Convert_DTO;
namespace HRM.formRoleNhanVien
{
    public partial class formXemBangLuongCuaNhanVien : DevExpress.XtraEditors.XtraForm
    {
        BangCongChiTietNhanVien _bangCongchiTiet;
        List<BangCongchiTietNhanVienDTO> listBC_nv_a = new List<BangCongchiTietNhanVienDTO>();
        void loadMaKyCong()
        {
            _bangCongchiTiet = new BangCongChiTietNhanVien();
            comboBoxMaKyCong.DataSource = _bangCongchiTiet.GetMaKyCongList();
        }
        public formXemBangLuongCuaNhanVien()
        {
            InitializeComponent();
        }

        private void formXemBangLuongCuaNhanVien_Load(object sender, EventArgs e)
        {
            loadMaKyCong();
            _bangCongchiTiet = new BangCongChiTietNhanVien();
            listBC_nv_a = _bangCongchiTiet.getListDTO(comboBoxMaKyCong.Text,Session.User.MANV);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (listBC_nv_a == null || listBC_nv_a.Count == 0)
            {
                MessageBox.Show("KỲ công này chưa được tính lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BangCongCuaNhanVien rpt = new BangCongCuaNhanVien(_bangCongchiTiet.getListDTO(comboBoxMaKyCong.Text, Session.User.MANV));
                rpt.ShowPreviewDialog();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}