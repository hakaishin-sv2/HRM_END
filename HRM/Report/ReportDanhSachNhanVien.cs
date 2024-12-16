using BusinessLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace HRM.Report
{
    public partial class ReportDanhSachNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        private List<NhanVien_DTO> _listNv;
        private int _stt = 0;

        private void SetSTT()
        {
            
            for (int i = 0; i < _listNv.Count; i++)
            {
                _listNv[i].STT = i + 1;
            }
        }
        public ReportDanhSachNhanVien()
        {
            InitializeComponent();
        }

        public ReportDanhSachNhanVien(List<NhanVien_DTO> listNv_DTO)
        {
            InitializeComponent();
            this._listNv = listNv_DTO;
            this.DataSource = _listNv;
            SetSTT();
            loadData();
        }

        private void loadData()
        {
            lbSTT.DataBindings.Add("Text", _listNv, "STT");
            lbMaNhanVien.DataBindings.Add("Text", _listNv, "MANV");
            lbHoTen.DataBindings.Add("Text", _listNv, "HOTEN");
            lbGioiTinh.DataBindings.Add("Text", _listNv, "GIOITINH");
            lbCCCD.DataBindings.Add("Text", _listNv, "CCCD");
            lblSDT.DataBindings.Add("Text", _listNv, "DIENTHOAI");
            lbPhongBan.DataBindings.Add("Text", _listNv, "TENPB");
            lbDiaChi.DataBindings.Add("Text", _listNv, "DIACHI");
            lbChucVu.DataBindings.Add("Text", _listNv, "TENCV");
            lbDanToc.DataBindings.Add("Text", _listNv, "TENDANTOC");


        }
        private void ReportDanhSachNhanVien_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _stt++;
            lbSTT.Text = _stt.ToString();
        }
    }
}
