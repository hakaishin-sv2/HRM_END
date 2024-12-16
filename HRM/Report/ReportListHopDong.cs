using BusinessLayer;
using Data_Layer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace HRM.Report
{
    public partial class ReportListHopDong : DevExpress.XtraReports.UI.XtraReport
    {
        private List<HopDong_DTO> _listHopDong;
        public ReportListHopDong(System.Collections.Generic.List<BusinessLayer.HopDong_DTO> hopDong_DTOs)
        {
            InitializeComponent();
            this._listHopDong = hopDong_DTOs;
            this.DataSource = _listHopDong;
            loadData();
        }
        private void loadData()
        {
            lblSTT.DataBindings.Add("Text", _listHopDong, "STT");
            lblLanKY.DataBindings.Add("Text", _listHopDong, "LANKY");
            lblNgayKy.DataBindings.Add("Text", _listHopDong, "NGAYKY");
            lblNgayBatDau.DataBindings.Add("Text", _listHopDong, "NGAYBATDAU");
            lblNgayKetThuc.DataBindings.Add("Text", _listHopDong, "NGAYKETTHUC");
            lblMaNV.DataBindings.Add("Text", _listHopDong, "MANV");
            lblHoTen.DataBindings.Add("Text", _listHopDong, "HOTEN");
            lblLuongCoBan.DataBindings.Add("Text", _listHopDong, "LuongCoBan");
            lblHeSoLuong.DataBindings.Add("Text", _listHopDong, "HESOLUONG");

        }
    }
}
