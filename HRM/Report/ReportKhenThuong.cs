using BusinessLayer;
using BusinessLayer.DTO;
using Data_Layer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace HRM.Report
{
    public partial class ReportChuyenNhanVien123 : DevExpress.XtraReports.UI.XtraReport
    {
        private List<KhenThuong_kyluat_DTO> _listKhen;

        public ReportChuyenNhanVien123(System.Collections.Generic.List<BusinessLayer.DTO.KhenThuong_kyluat_DTO> khenThuong_kyluat_DTOs)
        {
            InitializeComponent();
            this._listKhen = khenThuong_kyluat_DTOs;
            this.DataSource = _listKhen;
            loadData();
        }

       

        private void loadData()
        {
            lblSTT.DataBindings.Add("Text", _listKhen, "STT");
            lblMANV.DataBindings.Add("Text", _listKhen, "MANV");
            lblHOTEN.DataBindings.Add("Text", _listKhen, "HOTEN");
            lblTenPhongBan.DataBindings.Add("Text", _listKhen, "TenPhongBan");
            lblNgayKhenThuong.DataBindings.Add("Text", _listKhen, "TUNGAY");
            lblLyDo.DataBindings.Add("Text", _listKhen, "LYDO");
            lblNoiDung.DataBindings.Add("Text", _listKhen, "NOIDUNG");
          
        }

    }
}
