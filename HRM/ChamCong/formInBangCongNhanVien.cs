using BusinessLayer;
using BusinessLayer.ClassChamCong;
using BusinessLayer.Convert_DTO;
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

namespace HRM.ChamCong
{
    public partial class formInBangCongNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public formInBangCongNhanVien()
        {
            InitializeComponent();
        }
        NhanVien _nhanVien;
        BangCongChiTietNhanVien _bangCongchiTiet;
        private void formInBangCongNhanVien_Load(object sender, EventArgs e)
        {
            loadNhanVien();
            loadMaKyCong();
        }

        void loadMaKyCong()
        {
            _bangCongchiTiet = new BangCongChiTietNhanVien();
            comboBoxMaKyCong.DataSource = _bangCongchiTiet.GetMaKyCongList();
        }
        void loadNhanVien()
        {
            _nhanVien = new NhanVien();
            searchLookUpEditTimNhanVien.Properties.DataSource = _nhanVien.getListDTO_NhanVien();
            searchLookUpEditTimNhanVien.Properties.ValueMember = "MANV";
            searchLookUpEditTimNhanVien.Properties.DisplayMember = "HOTEN";
            //searchLookUpEditTimNhanVien.Properties.DisplayMember = "TENCV";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
          

            if (searchLookUpEditTimNhanVien.EditValue == null ||
        searchLookUpEditTimNhanVien.EditValue == DBNull.Value ||
        string.IsNullOrEmpty(searchLookUpEditTimNhanVien.EditValue.ToString()))
            {
                MessageBox.Show("Bạn cần chọn Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                int manv = searchLookUpEditTimNhanVien.EditValue != null ? (int)searchLookUpEditTimNhanVien.EditValue : 0;
                var listBC_nv_a = _bangCongchiTiet.getListDTO(comboBoxMaKyCong.Text, manv);
                BangCongCuaNhanVien rpt = new BangCongCuaNhanVien(listBC_nv_a);
                rpt.ShowPreviewDialog();
            }
           
        }
    }
}