using BusinessLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace HRM.Report
{
    public partial class ReportQuyetDinhNghiViec : DevExpress.XtraReports.UI.XtraReport
    {
        private List<ThoiViec_DTO> _thoiViec_DTOs;
        public ReportQuyetDinhNghiViec(System.Collections.Generic.List<BusinessLayer.DTO.ThoiViec_DTO> _ChiTietNvThoiViec)
        {
            InitializeComponent();
            this._thoiViec_DTOs =_ChiTietNvThoiViec;
            this.DataSource = _thoiViec_DTOs;
        }

    }
}
