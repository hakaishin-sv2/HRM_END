using BusinessLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace HRM
{
    public partial class ReportNangLuong : DevExpress.XtraReports.UI.XtraReport
    {
        private List<NangLuong_DTO> _listDTO;

        public ReportNangLuong(System.Collections.Generic.List<BusinessLayer.DTO.NangLuong_DTO> nangLuong_DTOs)
        {
            InitializeComponent();
            this._listDTO = nangLuong_DTOs;
            this.DataSource = _listDTO;
            loadData();
        }
        private void loadData()
        {
            lblSTT.DataBindings.Add("Text", _listDTO, "STT");
            lblMANV.DataBindings.Add("Text", _listDTO, "MANV");
            lblHOTEN.DataBindings.Add("Text", _listDTO, "HOTEN");
            lblPhongBan.DataBindings.Add("Text", _listDTO, "PHONGBAN");
            lblNgayLen.DataBindings.Add("Text", _listDTO, "NGAYLENLUONG");
            lblSoCu.DataBindings.Add("Text", _listDTO, "HSLUONGCU");
            lblSoMoi.DataBindings.Add("Text", _listDTO, "HSLUONGMOI");
            lblGhiChu.DataBindings.Add("Text", _listDTO, "GHICHU");
        }

    }
}
