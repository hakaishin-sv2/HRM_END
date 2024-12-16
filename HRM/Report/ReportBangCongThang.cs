using Data_Layer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace HRM.Report
{
    public partial class ReportBangCongThang : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportBangCongThang()
        {
            InitializeComponent();
        }
        public string _title = "";
        public List<tb_BANGCONG_CHITIET> _listKCCT;

        public ReportBangCongThang(List<tb_BANGCONG_CHITIET> ListData)
        {
            InitializeComponent();
            this._listKCCT= ListData;
        }
    }
}
