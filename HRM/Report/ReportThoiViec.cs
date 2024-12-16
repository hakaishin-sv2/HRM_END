using BusinessLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace HRM.Report
{
    public partial class ReportThoiViec : DevExpress.XtraReports.UI.XtraReport
    {
        private List<ThoiViec_DTO> _ThoiViec_DTOs;
        public ReportThoiViec(System.Collections.Generic.List<BusinessLayer.DTO.ThoiViec_DTO> thoiViec_DTOs)
        {
            InitializeComponent();
            this._ThoiViec_DTOs = thoiViec_DTOs;
            this.DataSource = this._ThoiViec_DTOs;
            loadData();
        }
        private void loadData()
        {
            lblSTT.DataBindings.Add("Text", _ThoiViec_DTOs, "STT");
            lblMANV.DataBindings.Add("Text", _ThoiViec_DTOs, "MANV");
            lblHOTEN.DataBindings.Add("Text", _ThoiViec_DTOs, "HOTEN");
            lblPhongBan.DataBindings.Add("Text", _ThoiViec_DTOs, "TenPhongBan");
            lblNgayNop.DataBindings.Add("Text", _ThoiViec_DTOs, "NGAYNOPDON");
            lblNgayNghi.DataBindings.Add("Text", _ThoiViec_DTOs, "NGAYNGHI");
            lblLyDo.DataBindings.Add("Text", _ThoiViec_DTOs, "LYDO");

        }
    }
}
