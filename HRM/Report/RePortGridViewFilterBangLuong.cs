using BusinessLayer.Convert_DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace HRM.Report
{
    public partial class RePortGridViewFilterBangLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public RePortGridViewFilterBangLuong()
        {
            InitializeComponent();
        }
        private List<TinhluongDTO> _listData;
        public RePortGridViewFilterBangLuong(List<TinhluongDTO> tinhluongDTOs)
        {
            InitializeComponent();
            this._listData = tinhluongDTOs;
            this.DataSource = _listData;
            string Makycong = _listData[0].MAKYCONG;
            string Thang = Makycong.Substring(6);
            string Nam = Makycong.Substring(0, 4);
            double TongTien = double.Parse(_listData.Sum(dto => dto.LUONGTHUCLANH).ToString());

            lblThang.Text = Thang;
            lblNam.Text = Nam;
            lblTongTienThang.Text = TongTien.ToString("n0") + " VNĐ";
            BindingData();
        }
        void BindingData()
        {
            // Định dạng tiền tệ và thêm chuỗi " VNĐ"
            lblSoTien.DataBindings.Add("Text", _listData, "LUONGNGAYTHUONG", "{0:n0} VNĐ");
            lblLuongLe.DataBindings.Add("Text", _listData, "LUONGNGAYLE", "{0:n0} VNĐ");
            lblLuongTangCa.DataBindings.Add("Text", _listData, "LUONGTANGCA", "{0:n0} VNĐ");
            lblLuongChuNhat.DataBindings.Add("Text", _listData, "LUONGNGAYCHUNHAT", "{0:n0} VNĐ");
            lblPhuCap.DataBindings.Add("Text", _listData, "PHUCAP", "{0:n0} VNĐ");
            lblUngLuong.DataBindings.Add("Text", _listData, "UNGLUONG", "{0:n0} VNĐ");
            lblKhenThuong.DataBindings.Add("Text", _listData, "SOTIENKHENTHUONG", "{0:n0} VNĐ");
            lblKyLuat.DataBindings.Add("Text", _listData, "SOTIENKYLUAT", "{0:n0} VNĐ");
            lblLuongPhep.DataBindings.Add("Text", _listData, "LUONGNGAYPHEP", "{0:n0} VNĐ");
            lblThucNhan.DataBindings.Add("Text", _listData, "LUONGTHUCLANH", "{0:n0} VNĐ");

            // Các binding không cần định dạng đặc biệt
            lblMaNv.DataBindings.Add("Text", _listData, "MANV");
            lblHoTen.DataBindings.Add("Text", _listData, "HOTEN");
            lblNgayCong.DataBindings.Add("Text", _listData, "NGAYCONGTRONGTHANG");
        }
    }
}
