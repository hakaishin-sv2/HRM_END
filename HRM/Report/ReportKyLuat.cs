using BusinessLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace HRM.Report
{
    public partial class ReportKyLuat : DevExpress.XtraReports.UI.XtraReport
    {
        private List<KhenThuong_kyluat_DTO> _listKyLuat;
        public ReportKyLuat(System.Collections.Generic.List<BusinessLayer.DTO.KhenThuong_kyluat_DTO> khenThuong_kyluat_DTOs)
        {
            InitializeComponent();
            this._listKyLuat = khenThuong_kyluat_DTOs;
            this.DataSource = _listKyLuat;
            loadData();
        }
        private void loadData()
        {
            lblSTT.DataBindings.Add("Text", _listKyLuat, "STT");
            lblMANV.DataBindings.Add("Text", _listKyLuat, "MANV");
            lblHOTEN.DataBindings.Add("Text", _listKyLuat, "HOTEN");
            lblTenPhongBan.DataBindings.Add("Text", _listKyLuat, "TenPhongBan");
            lblNgayKyLuat.DataBindings.Add("Text", _listKyLuat, "TUNGAY");
            lblLyDo.DataBindings.Add("Text", _listKyLuat, "LYDO");
            lblNoiDung.DataBindings.Add("Text", _listKyLuat, "NOIDUNG");

        }
    }
}
