using BusinessLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace HRM.Report
{
    public partial class ReportChuyenNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        private List<ChuyenNhanVien_DTO> _chuyenNhanVien_DTOs;
        public ReportChuyenNhanVien(System.Collections.Generic.List<BusinessLayer.DTO.ChuyenNhanVien_DTO> chuyenNhanVien_DTOs)
        {
            InitializeComponent();
            this._chuyenNhanVien_DTOs = chuyenNhanVien_DTOs;
            this.DataSource = _chuyenNhanVien_DTOs;
            loadData();
        }
        private void loadData()
        {
            lblSTT.DataBindings.Add("Text", _chuyenNhanVien_DTOs, "STT");
            lblMANV.DataBindings.Add("Text", _chuyenNhanVien_DTOs, "MANV");
            lblHOTEN.DataBindings.Add("Text", _chuyenNhanVien_DTOs, "HOTEN");
            lblNGAY.DataBindings.Add("Text", _chuyenNhanVien_DTOs, "NGAY");
            lblPhongCu.DataBindings.Add("Text", _chuyenNhanVien_DTOs, "TenPhongBanCu");
            lblPhongMoi.DataBindings.Add("Text", _chuyenNhanVien_DTOs, "TenPhongBanMoi");
            lblLydo.DataBindings.Add("Text", _chuyenNhanVien_DTOs, "LYDO");

        }
    }
}
