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
    public partial class formNangLuong : DevExpress.XtraEditors.XtraForm
    {
        public formNangLuong()
        {
            InitializeComponent();
            splitContainer2.Panel1Collapsed = true;
            showBar(true);
        }
        NangLuong _nangLuong;
        //List<HopDong_DTO> _list_hd_DTO;
        List<NangLuong_DTO> _data;
        HopDong _hopDong_DTO;
        NhanVien _nhanVien;
        int _CheckGianHan = 0;
        bool them;
        int id;
        void loadData()
        {
            spinEditLuongHienTai.Properties.ReadOnly = true;
            _nangLuong = new NangLuong();
            _data = _nangLuong.getListDTO();
            gridControlNangLuong.DataSource = _data;    
            gridViewNangLuong.OptionsBehavior.Editable = false;
            gridViewNangLuong.OptionsView.ColumnAutoWidth = true;
            loadNhanVien(); // load nhân viên để chọn
            //int slhd_HetHan = hd.getSoLuongHetHD();
            //splitContainer2.Visible = true;
        }
        void loadNhanVien()
        {
            _nhanVien = new NhanVien();
            searchLookUpEditNV.Properties.DataSource = _nhanVien.getDanhSach();
            searchLookUpEditNV.Properties.ValueMember = "MANV";
            searchLookUpEditNV.Properties.DisplayMember = "HOTEN";
        }
        void showBar(bool kt)
        {
            btnSavei.Enabled = !kt;
            btnRollback.Enabled = !kt;
            textBoxMaHopDong.Enabled = !kt;
            dateTimePickerNgayTangLuong.Enabled = !kt;
            dateTimePickerNgayLen.Enabled = !kt;
            textBoxHoTen.Enabled = !kt;
             // là mở lên
            TextBoxNoiDung.Enabled = !kt;
            spinEditLuongHienTai.Enabled = !kt;
            spinEditHSluongnanglen.Enabled = !kt;
            searchLookUpEditNV.Enabled = !kt;

            barBtn_GiaHanHopDong.Enabled = kt;
            btnAdd.Enabled = kt;
            btnSua.Enabled = kt;
            btnDelete.Enabled = kt;
            btnCancel.Enabled = kt;
            btnClose.Enabled = kt;
        }

        void Reset()
        {
            TextBoxNoiDung.Text = string.Empty;
            dateTimePickerNgayTangLuong.Value = DateTime.Now;
            dateTimePickerNgayLen.Value= DateTime.Now;
            textBoxHoTen.Text=string.Empty;
            textBoxMaHopDong.Text= string.Empty;
            spinEditLuongHienTai.Text = "0";
            spinEditHSluongnanglen.Text = "0";

        }
        int check;
        int fix = 0;
        private void formNangLuong_Load(object sender, EventArgs e)
        {
            loadData();
            loadNhanVien();
            if (splitContainer2.Panel1Collapsed == false && check == 0) // thêm lỗi
            {
                splitContainer2.Panel1Collapsed = false;
            }
            else if (splitContainer2.Panel1Collapsed == false && fix == 0)
            { // sửa lỗi
                splitContainer2.Panel1Collapsed = false;
            }
            else
            {

                splitContainer2.Panel1Collapsed = true;// ẩn đi
                loadData();
                them = false;
                showBar(true);

            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = true;
            showBar(false);
            Reset();
            splitContainer2.Panel1Collapsed = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = false;
            showBar(false);
            splitContainer2.Panel1Collapsed = false;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int sl = _nangLuong.SoLuong();
            var x = _nangLuong.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa  có mã " + x.SOQUYETDINH + " " + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int manv = (int)searchLookUpEditNV.EditValue;
                    var HD_update = _hopDong_DTO.GetSoHopDongByMANV(manv);
                    HD_update.HESOLUONG = (double)spinEditLuongHienTai.Value;

                    // _hopDong_DTO.Update(HD_update);
                    _nangLuong.Xoa(id);
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
                    if ((float)spinEditHSluongnanglen.Value == 1)
                    {
                        MessageBox.Show("Hệ số lương đang bàng 0 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;

                    }
                    else if (searchLookUpEditNV.EditValue == null)
                    {
                        MessageBox.Show("Bạn cần chọn Nhân Viên được khen thưởng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;

                    }

                    var arr = _nangLuong.MaQuyetDinh()?.Split('_');
                    int soquetdinh = int.Parse(arr[0]) + 1;
                    var dt = new Data_Layer.tb_NANGLUONG
                    {
                        SOQUYETDINH = soquetdinh.ToString() + "_QĐTANGLUONG",
                        MANV = (int)searchLookUpEditNV.EditValue,
                        NGAYKY = dateTimePickerNgayTangLuong.Value,
                        NGAYLENLUONG = dateTimePickerNgayLen.Value,
                        HSLUONGCU =(double)spinEditLuongHienTai.Value,
                        HSLUONGMOI = (double)spinEditHSluongnanglen.Value,
                        GHICHU = TextBoxNoiDung.Text.Trim(),
                        CREATE_DATE = DateTime.Now,
                        //CREATE_BY = User.ID,
                    };
                    var result = _nangLuong.Them(dt);
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
                    var data = _nangLuong.getItem(id);
                    if (data != null)
                    {
                        data.MANV = (int)searchLookUpEditNV.EditValue;
                        data.NGAYKY = dateTimePickerNgayTangLuong.Value;
                        data.NGAYLENLUONG = dateTimePickerNgayLen.Value;
                        data.HSLUONGMOI = (double)spinEditHSluongnanglen.Value;
                        data.GHICHU = TextBoxNoiDung.Text.Trim();
                        data.UPDATE_DATE = DateTime.Now;
                        fix = 1;
                        _nangLuong.Update(data);
                        MessageBox.Show("Đã cập nhật lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // cập nhận phòng mới cho nhân viên
                int manv = (int)searchLookUpEditNV.EditValue;
                var HD_update = _hopDong_DTO.GetSoHopDongByMANV(manv);
                HD_update.HESOLUONG = (double)spinEditHSluongnanglen.Value;
               
                // vẫn để hệ so ben hop dong nguyen chi luu ben bang nang luong thoi
                //_hopDong_DTO.Update(HD_update);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}\nChi tiết lỗi: {ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSavei_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            if (them == true && check == 1)// thêm thành công
            {
                splitContainer2.Panel1Collapsed = true;
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
                splitContainer2.Panel1Collapsed = true;
                loadData();
            }
            else
            {
                them = false;
            }
        }

        private void btnRollback_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showBar(true);
            them = false;
            splitContainer2.Panel1Collapsed = true;
        }

        List<NangLuong_DTO> _ListGridView;
        public List<NangLuong_DTO> getDanhSachGridView()
        {
            _ListGridView = new List<NangLuong_DTO>();

            for (int i = 0; i < gridViewNangLuong.RowCount; i++)
            {
                var DTO_KhenThuong = new NangLuong_DTO
                {
                    STT = i + 1,
                    MANV = gridViewNangLuong.GetRowCellValue(i, "MANV") != DBNull.Value ? Convert.ToInt32(gridViewNangLuong.GetRowCellValue(i, "MANV")) : 000,
                    HOTEN = gridViewNangLuong.GetRowCellValue(i, "HOTEN") != DBNull.Value ? Convert.ToString(gridViewNangLuong.GetRowCellValue(i, "HOTEN")) : "",
                    PHONGBAN = gridViewNangLuong.GetRowCellValue(i, "PHONGBAN") != DBNull.Value ? Convert.ToString(gridViewNangLuong.GetRowCellValue(i, "PHONGBAN")) : string.Empty,
                    GHICHU = gridViewNangLuong.GetRowCellValue(i, "GHICHU") != DBNull.Value ? Convert.ToString(gridViewNangLuong.GetRowCellValue(i, "GHICHU")) : string.Empty,
                    NGAYLENLUONG = gridViewNangLuong.GetRowCellValue(i, "NGAYLENLUONG") != DBNull.Value ? Convert.ToDateTime(gridViewNangLuong.GetRowCellValue(i, "NGAYLENLUONG")) : DateTime.MinValue,
                    //LuongHangThang = gridView_NhanVien.GetRowCellValue(i, "LuongHangThang") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "LuongHangThang")) : string.Empty,
                    HSLUONGCU = gridViewNangLuong.GetRowCellValue(i, "HSLUONGCU") != DBNull.Value ? Convert.ToDouble(gridViewNangLuong.GetRowCellValue(i, "HSLUONGCU")) :1,
                    HSLUONGMOI = gridViewNangLuong.GetRowCellValue(i, "HSLUONGMOI") != DBNull.Value ? Convert.ToDouble(gridViewNangLuong.GetRowCellValue(i, "HSLUONGMOI")) : 1,
                };
                _ListGridView.Add(DTO_KhenThuong);
            }

            return _ListGridView;
        }
        private void btnInList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportNangLuong rpt = new ReportNangLuong(getDanhSachGridView());
            rpt.ShowPreview();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridViewNangLuong_Click(object sender, EventArgs e)
        {
            int sl = _nangLuong.SoLuong();
            if (sl == 0)
            {

            }
            else
            {
                if (splitContainer2.Panel1Collapsed == true)
                {
                    splitContainer2.Panel1Collapsed = false;
                }
                //decimal lcb = luongCo.getLuongCoBan();


                id = Convert.ToInt32(gridViewNangLuong.GetFocusedRowCellValue("ID").ToString());
                //_ChiTietNvThoiViec = _thoiViec.getRowFocus(id, _thoiViec_s);
                var getHDclick = _nangLuong.getItem(id);
                dateTimePickerNgayTangLuong.Value = getHDclick.NGAYKY.Value;
                TextBoxNoiDung.Text = getHDclick.GHICHU;
                searchLookUpEditNV.EditValue = getHDclick.MANV;

                spinEditLuongHienTai.Text = getHDclick.HSLUONGCU.ToString();
                spinEditHSluongnanglen.Text = getHDclick.HSLUONGMOI.ToString();
                TextBoxNoiDung.Text = getHDclick.GHICHU.ToString();
            }
           
        }

        private void searchLookUpEditNV_EditValueChanged(object sender, EventArgs e)
        {
            _hopDong_DTO = new HopDong();
            var danhSachHopDong = _hopDong_DTO.getListDTO_HopDong();
            var hd = danhSachHopDong.FirstOrDefault(item => item.MANV == (int)searchLookUpEditNV.EditValue);
            spinEditLuongHienTai.Text = hd.HESOLUONG.ToString();
            textBoxHoTen.Text = hd.HOTEN;
            textBoxMaHopDong.Text = hd.MAHOPDONG.ToString();
        }

    }
}