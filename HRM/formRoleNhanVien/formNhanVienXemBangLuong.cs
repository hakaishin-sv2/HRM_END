using BusinessLayer.ClassChamCong;
using BusinessLayer.Convert_DTO;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HRM.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Session = BusinessLayer.Session;

namespace HRM.formRoleNhanVien
{
    public partial class formNhanVienXemBangLuong : DevExpress.XtraEditors.XtraForm
    {
        public formNhanVienXemBangLuong()
        {
            InitializeComponent();
        }
        TinhLuong _tinhLuong;
        List<TinhluongDTO> _tinhLuongList;
        void loadMaKyCong()
        {
            _tinhLuong = new TinhLuong();
            comboBoxMaKyCong.DataSource = _tinhLuong.GetMaKyCongList();
        }

        void LoadData()
        {
            _tinhLuong = new TinhLuong();
             
            _tinhLuongList = _tinhLuong.getBangLuongByMaNv(comboBoxMaKyCong.Text, Session.User.MANV);
            if(_tinhLuongList.Count > 0)
            {
                gridControBangLuong.DataSource = _tinhLuongList;
                gridViewBangLuong.OptionsBehavior.Editable = false;
            }
            else
            {
                gridControBangLuong.DataSource = _tinhLuongList;
                gridViewBangLuong.OptionsBehavior.Editable = false;
                //MessageBox.Show("Bạn chưa có tên trong này!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(_tinhLuongList == null || _tinhLuongList.Count == 0)
            {
                MessageBox.Show("KỲ công này chưa được tính lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ReportPhieuLuongNhanVien rpt = new ReportPhieuLuongNhanVien(_tinhLuongList);
                rpt.ShowPreviewDialog();
            }
            
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXemBangLuong_Click(object sender, EventArgs e)
        {
            if (_tinhLuongList == null || _tinhLuongList.Count == 0)
            {
                MessageBox.Show("KỲ công này chưa được ttinhs lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ReportPhieuLuongNhanVien rpt = new ReportPhieuLuongNhanVien(_tinhLuongList);
                rpt.ShowPreviewDialog();
            }
        }

        private void comboBoxMaKyCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void formNhanVienXemBangLuong_Load(object sender, EventArgs e)
        {
            loadMaKyCong();
            LoadData();
        }
    }
}