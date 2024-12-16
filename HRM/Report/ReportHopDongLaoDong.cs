using BusinessLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace HRM.Report
{
    public partial class ReportHopDongLaoDong : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportHopDongLaoDong()
        {
            InitializeComponent();
        }
        List<HopDong_DTO> _hopDong_DTOs;
        public ReportHopDongLaoDong(List<HopDong_DTO> data_hd_DTO)
        {
            InitializeComponent();
            this._hopDong_DTOs = data_hd_DTO;
            this.DataSource = _hopDong_DTOs;
            loadData();
        }
        private void loadData()
        {
            lbl_MaHopDong.DataBindings.Add("Text", _hopDong_DTOs, "MAHOPDONG");

        }

        private void xrRichText1_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
