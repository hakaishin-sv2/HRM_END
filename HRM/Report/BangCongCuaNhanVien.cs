using BusinessLayer.Convert_DTO;
using Data_Layer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace HRM.Report
{
    public partial class BangCongCuaNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public List<BangCongchiTietNhanVienDTO> _listData;
        public BangCongCuaNhanVien(System.Collections.Generic.List<BusinessLayer.Convert_DTO.BangCongchiTietNhanVienDTO> listBC_nv_a)
        {
            InitializeComponent();
            this._listData = listBC_nv_a;
            this.DataSource = _listData;
            BindingData();
        }
        void BindingData()
        {
            lblMaNv.DataBindings.Add("Text", _listData, "MANV");
            lblHoTen.DataBindings.Add("Text", _listData, "HOTEN");
            lblMaKyCong.DataBindings.Add("Text", _listData, "MAKYCONG");
            lblNgay.DataBindings.Add("Text", _listData, "NGAY");
            lblThu.DataBindings.Add("Text", _listData, "THU");
            lblGioVao.DataBindings.Add("Text", _listData, "GIOVAO");
            lblGioRa.DataBindings.Add("Text", _listData, "GIORA");
            lblNghiPhep.DataBindings.Add("Text", _listData, "NGAYPHEP");
            lblNgayLe.DataBindings.Add("Text", _listData, "CONGNGAYLE");
            lblChuNhat.DataBindings.Add("Text", _listData, "CONGCHUNHAT");
            lblCongNgay.DataBindings.Add("Text", _listData, "NGAYCONGTRONGNGAY");
            lblKyHieu.DataBindings.Add("Text", _listData, "KYHIEU");
            lblGhiChu.DataBindings.Add("Text", _listData, "GHICHU");

            TongNgayPhep.DataBindings.Add("Text", _listData, "TongNgayPhep");
            TongChuNhat.DataBindings.Add("Text", _listData, "TongChuNhat");
            TongNgayLe.DataBindings.Add("Text", _listData, "TongNgayLe");
            TongNgayCong.DataBindings.Add("Text", _listData, "TongNgayCong");
        }
    }
}
