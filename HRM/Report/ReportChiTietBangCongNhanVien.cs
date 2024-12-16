using BusinessLayer.Convert_DTO;
using Data_Layer;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace HRM.Report
{
    public partial class rptBangCongNhanVienCuThe : DevExpress.XtraReports.UI.XtraReport
    {
        private List<tb_BANGCONG_CHITIET> _listData;

        public rptBangCongNhanVienCuThe(List<tb_BANGCONG_CHITIET> listBC_nv_a)
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
            lblKyHieu.DataBindings.Add("Text", _listData, "KYHIEU");
            lblChuNhat.DataBindings.Add("Text", _listData, "CONGCHUNHAT");
            lblCongNgay.DataBindings.Add("Text", _listData, "NGAYCONGTRONGNGAY");
            lblGhiChu.DataBindings.Add("Text", _listData, "GHICHU");
        }
    }
}
