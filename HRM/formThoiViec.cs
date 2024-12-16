using BusinessLayer;
using BusinessLayer.DTO;
using Data_Layer;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HRM.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM
{
    public partial class formThoiViec : DevExpress.XtraEditors.XtraForm
    {
        public formThoiViec()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
        }

        ThoiViec _thoiViec;
        NhanVien _nhanVien;
        PhongBan _phongBan;
        List<ThoiViec_DTO> _thoiViec_s;
        List<ThoiViec_DTO> _quyetDinhThoiViecDTO;
        bool them;
        int id;
        int check;
        int fix = 0;

        void loadData()
        {
            _thoiViec = new ThoiViec();
            _thoiViec_s = _thoiViec.getListDTO();
            gridControlThoiViec.DataSource = _thoiViec_s;
            gridViewThoiViec.OptionsBehavior.Editable = false;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            TextBoxLydo.Enabled = !kt;
            TextBoxGhiChu.Enabled = !kt;
            searchLookUpEditTimNhanVien.Enabled = !kt;
            dateTimePickerNgayNop.Enabled = !kt;
           
            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        void Reset()
        {
            TextBoxLydo.Text = string.Empty;
            TextBoxGhiChu.Text = string.Empty;
            searchLookUpEditTimNhanVien.Text = string.Empty;
        }
        void loadNhanVien()
        {
            _nhanVien = new NhanVien();
            searchLookUpEditTimNhanVien.Properties.DataSource = _nhanVien.getDanhSach();
            searchLookUpEditTimNhanVien.Properties.ValueMember = "MANV";
            searchLookUpEditTimNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void formThoiViec_Load(object sender, EventArgs e)
        {
            loadData();
            loadNhanVien();
           
            if (splitContainer1.Panel1Collapsed == false && check == 0) // thêm lỗi
            {
                splitContainer1.Panel1Collapsed = false;
            }
            else if (splitContainer1.Panel1Collapsed == false && fix == 0)
            { // sửa lỗi
                splitContainer1.Panel1Collapsed = false;
            }
            else
            {

                splitContainer1.Panel1Collapsed = true;// ẩn đi
                loadData();
                them = false;
                showBar(true);

            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = true;
            showBar(false);
            Reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnFix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = false;
            showBar(false);
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int sl = _thoiViec.SoLuong();
            var x = _thoiViec.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa  có mã " + x.SOQUETDINH + " " + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _thoiViec.Xoa(id);
                    loadData();
                    them = true;
                    MessageBox.Show("Xóa thành công");
                }
            }
            else if (sl <= 0)
            {
                MessageBox.Show("Chưa có quết định nào nào trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Quyết định không tồn tại hoặc đã bị xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void SaveData()
        {
            try
            {
                if (them)
                {
                    if (string.IsNullOrEmpty(TextBoxLydo.Text))
                    {
                        MessageBox.Show("Bạn cần nhập lý do ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;

                    }
                    else if (searchLookUpEditTimNhanVien.EditValue == null)
                    {
                        MessageBox.Show("Bạn cần chọn Nhân Viên được khen thưởng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                       
                    }

                    var arr = _thoiViec.MaQuyetDinh()?.Split('_');
                    int soquetdinh = int.Parse(arr[0]) + 1;
                    //int IDPB_old = (int)_nhanVien.FindMaNV(int.Parse(searchLookUpEditTimNhanVien.EditValue.ToString())).IDPB;
                    //int IDPB_NEW = int.Parse(comboBoxPhongBan.SelectedValue.ToString());
                    var dt = new Data_Layer.tb_THOIVIEC
                    {
                        SOQUETDINH = soquetdinh.ToString() + "_QĐTV",
                        MANV = (int)searchLookUpEditTimNhanVien.EditValue,
                        NGAYNOPDON = dateTimePickerNgayNop.Value,
                        NGAYNGHI = dateTimePickerNgayNop.Value.AddDays(10),
                        LYDO = TextBoxLydo.Text.Trim(),
                        GHICHU = TextBoxGhiChu.Text.Trim(),
                        CREATED_DATE = DateTime.Now,
                        //CREATE_BY = UserControl.ID,
                    };

                    var result = _thoiViec.Them(dt);
                    if (result != null)
                    {
                        check = 1;
                        MessageBox.Show("Đã thêm mới thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thêm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // update
                {
                    var data = _thoiViec.getItem(id);
                    if (data != null)
                    {
                        data.MANV = (int)searchLookUpEditTimNhanVien.EditValue;
                        data.NGAYNOPDON = dateTimePickerNgayNop.Value;
                        data.NGAYNGHI = dateTimePickerNgayNop.Value.AddDays(10);
                        data.LYDO = TextBoxLydo.Text.Trim();
                        data.GHICHU = TextBoxGhiChu.Text.Trim();
                        data.UPDATE_DATE = DateTime.Now;

                        fix = 1;
                        _thoiViec.Update(data);
                        MessageBox.Show("Đã cập nhật lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // cập nhận phòng mới cho nhân viên
                int manv = (int)searchLookUpEditTimNhanVien.EditValue;
                var nv_update = _nhanVien.FindMaNV(manv);
                nv_update.TrangThaiLamViec = 0;
                _nhanVien.Update(nv_update);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}\nChi tiết lỗi: {ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            if (them == true && check == 1)// thêm thành công
            {
                splitContainer1.Panel1Collapsed = true;
                showBar(true);
                loadData();
                them = false;
            }
            else if (them == true && check == 0)// thêm không thành công
            {
                showBar(false);
                them = true;

            }
            else if (them == false && fix == 1)// sửa thành công
            {
                showBar(true);
                splitContainer1.Panel1Collapsed = true;
                loadData();
            }
            else
            {
                them = false;
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showBar(true);
            them = false;
            splitContainer1.Panel1Collapsed = true;
        }
        List<ThoiViec_DTO> _ListGridView;
        public List<ThoiViec_DTO> getDanhSachGridView()
        {
            _ListGridView = new List<ThoiViec_DTO>();

            for (int i = 0; i < gridViewThoiViec.RowCount; i++)
            {
                var DTO_ThoiViec = new ThoiViec_DTO
                {
                    STT = i + 1,
                    SOQUETDINH = gridViewThoiViec.GetRowCellValue(i, "SOQUYETDINH") != DBNull.Value ? Convert.ToString(gridViewThoiViec.GetRowCellValue(i, "SOQUYETDINH")) : string.Empty,
                    MANV = gridViewThoiViec.GetRowCellValue(i, "MANV") != DBNull.Value ? Convert.ToInt32(gridViewThoiViec.GetRowCellValue(i, "MANV")) : 000,
                    HOTEN = gridViewThoiViec.GetRowCellValue(i, "HOTEN") != DBNull.Value ? Convert.ToString(gridViewThoiViec.GetRowCellValue(i, "HOTEN")) : "",
                    NGAYNOPDON = gridViewThoiViec.GetRowCellValue(i, "NGAYNOPDON") != DBNull.Value ? Convert.ToDateTime(gridViewThoiViec.GetRowCellValue(i, "NGAYNOPDON")) : DateTime.MinValue,
                    NGAYNGHI = gridViewThoiViec.GetRowCellValue(i, "NGAYNGHI") != DBNull.Value ? Convert.ToDateTime(gridViewThoiViec.GetRowCellValue(i, "NGAYNGHI")) : DateTime.MinValue,
                    TenPhongBan = gridViewThoiViec.GetRowCellValue(i, "TenPhongBan") != DBNull.Value ? Convert.ToString(gridViewThoiViec.GetRowCellValue(i, "TenPhongBan")) : string.Empty,
                    LYDO = gridViewThoiViec.GetRowCellValue(i, "LYDO") != DBNull.Value ? Convert.ToString(gridViewThoiViec.GetRowCellValue(i, "LYDO")) : string.Empty,
                    //LuongHangThang = gridView_NhanVien.GetRowCellValue(i, "LuongHangThang") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "LuongHangThang")) : string.Empty,
                    GHICHU = gridViewThoiViec.GetRowCellValue(i, "GhiChu") != DBNull.Value ? Convert.ToString(gridViewThoiViec.GetRowCellValue(i, "GhiChu")) : string.Empty,
                };
                _ListGridView.Add(DTO_ThoiViec);
            }

            return _ListGridView;
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportThoiViec rpt = new ReportThoiViec(getDanhSachGridView());
            rpt.ShowPreview();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridViewThoiViec_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
            }
            //decimal lcb = luongCo.getLuongCoBan();


            id = Convert.ToInt32(gridViewThoiViec.GetFocusedRowCellValue("ID").ToString());
            _quyetDinhThoiViecDTO = _thoiViec.getListDTOQuetDinhThoiViec();
            _ChiTietNvThoiViec = _thoiViec.getRowFocus(id, _quyetDinhThoiViecDTO);
            var getHDclick = _thoiViec.getItem(id);
            dateTimePickerNgayNop.Value = getHDclick.NGAYNOPDON.Value;
            TextBoxLydo.Text = getHDclick.LYDO;
            TextBoxGhiChu.Text = getHDclick.GHICHU;
            searchLookUpEditTimNhanVien.EditValue = getHDclick.MANV;
        }
        List<ThoiViec_DTO> _ChiTietNvThoiViec;
        private void btnPrintDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (_ChiTietNvThoiViec == null)
            {
                MessageBox.Show("Hãy Click vào nhân viên muốn in rồi ấn lại", "Hướng dẫn");
            }
            else
            {
                ReportQuyetDinhNghiViec rpt = new ReportQuyetDinhNghiViec(_ChiTietNvThoiViec);
                rpt.ShowPreview();
            }
            
        }
    }
}