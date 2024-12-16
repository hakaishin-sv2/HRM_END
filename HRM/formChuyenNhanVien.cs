using BusinessLayer;
using BusinessLayer.DTO;
using DevExpress.XtraReports.UI;
using HRM.Report;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HRM
{
    public partial class formChuyenNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public formChuyenNhanVien()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
        }
        ChuyenNhanVien _chuyenNhanVien;
        NhanVien _nhanVien;
        bool them;
        int id;
        int check;
        int fix = 0;

        void loadData()
        {
            _chuyenNhanVien = new ChuyenNhanVien();
            var list = _chuyenNhanVien.getListDTO();
            gridControlChuyenNhanVien.DataSource = list;
            gridViewChuyenVanVien.OptionsBehavior.Editable = false;
        }
        PhongBan _phongBan;
        void loadComBoBox()
        {
            _phongBan = new PhongBan();
            comboBoxPhongBan.DataSource = _phongBan.getListPhongBan();
            comboBoxPhongBan.ValueMember = "IDPB";
            comboBoxPhongBan.DisplayMember = "TENPB";
            //comboBox_Role.DataSource = getNhanVien.ROLE;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            TextBoxLydo.Enabled = !kt;
            TextBoxGhiChu.Enabled = !kt;
            searchLookUpEditTimNhanVien.Enabled = !kt;
            comboBoxPhongBan.Enabled = !kt;
            textBoxPBCU.Enabled = !kt;

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
        private void formChuyenNhanVien_Load(object sender, EventArgs e)
        {
            loadData();
            loadNhanVien();
            loadComBoBox();
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
            int sl = _chuyenNhanVien.SoLuong();
            var x = _chuyenNhanVien.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa khen thưởng có mã " + x.SOQUYETDINH + " " + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _chuyenNhanVien.Xoa(id);
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
                        return;
                    }

                    var arr = _chuyenNhanVien.MaQuyetDinh()?.Split('_');
                    int soquetdinh = int.Parse(arr[0]) + 1;
                    int IDPB_old = (int)_nhanVien.FindMaNV(int.Parse(searchLookUpEditTimNhanVien.EditValue.ToString())).IDPB;
                    int IDPB_NEW = int.Parse(comboBoxPhongBan.SelectedValue.ToString());
                    var dt = new Data_Layer.tb_CHUYENNHANVIEN
                    {
                        SOQUYETDINH = soquetdinh.ToString()+ "_QĐCPB",
                        MANV = (int)searchLookUpEditTimNhanVien.EditValue,
                        NGAY = DateTime.Now,
                        LYDO = TextBoxLydo.Text.Trim(),
                        GHICHU = TextBoxGhiChu.Text.Trim(),
                        CREATED_DATE = DateTime.Now,
                        IDPBHIENTAI = IDPB_old,
                        IDPHONGBANMOI = IDPB_NEW,   
                    };

                    var result = _chuyenNhanVien.Them(dt);
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
                    var data = _chuyenNhanVien.getItem(id);
                    if (data != null)
                    {
                        data.MANV = (int)searchLookUpEditTimNhanVien.EditValue;
                        data.NGAY = DateTime.Now;
                        data.IDPHONGBANMOI = int.Parse(comboBoxPhongBan.SelectedValue.ToString());
                        data.LYDO = TextBoxLydo.Text.Trim();
                        data.GHICHU = TextBoxGhiChu.Text.Trim();
                        data.UPDATE_DATE = DateTime.Now;

                        fix = 1;
                        _chuyenNhanVien.Update(data);
                        MessageBox.Show("Đã cập nhật lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // cập nhận phòng mới cho nhân viên

                int idpb_ud = (int)comboBoxPhongBan.SelectedValue;
                int manv = (int)searchLookUpEditTimNhanVien.EditValue;
                var nv_update = _nhanVien.FindMaNV(manv);
                nv_update.IDPB = idpb_ud;
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

        List<ChuyenNhanVien_DTO> _ListGridView;
        public List<ChuyenNhanVien_DTO> getDanhSachGridView()
        {
            _ListGridView = new List<ChuyenNhanVien_DTO>();

            for (int i = 0; i < gridViewChuyenVanVien.RowCount; i++)
            {
                var DTO_ChuyenPhongBan = new ChuyenNhanVien_DTO
                {
                    STT = i + 1,
                    SOQUYETDINH= gridViewChuyenVanVien.GetRowCellValue(i, "SOQUYETDINH") != DBNull.Value ? Convert.ToString(gridViewChuyenVanVien.GetRowCellValue(i, "SOQUYETDINH")) : string.Empty,
                    MANV = gridViewChuyenVanVien.GetRowCellValue(i, "MANV") != DBNull.Value ? Convert.ToInt32(gridViewChuyenVanVien.GetRowCellValue(i, "MANV")) : 000,
                    HOTEN = gridViewChuyenVanVien.GetRowCellValue(i, "HOTEN") != DBNull.Value ? Convert.ToString(gridViewChuyenVanVien.GetRowCellValue(i, "HOTEN")) : "",
                    NGAY = gridViewChuyenVanVien.GetRowCellValue(i,"NGAY") != DBNull.Value ? Convert.ToDateTime(gridViewChuyenVanVien.GetRowCellValue(i,"NGAY")): DateTime.MinValue,
                    TenPhongBanCu = gridViewChuyenVanVien.GetRowCellValue(i, "TenPhongBanCu") != DBNull.Value ? Convert.ToString(gridViewChuyenVanVien.GetRowCellValue(i, "TenPhongBanCu")) : string.Empty,
                    TenPhongBanMoi = gridViewChuyenVanVien.GetRowCellValue(i, "TenPhongBanMoi") != DBNull.Value ? Convert.ToString(gridViewChuyenVanVien.GetRowCellValue(i, "TenPhongBanMoi")) : string.Empty,
                    LYDO = gridViewChuyenVanVien.GetRowCellValue(i, "LYDO") != DBNull.Value ? Convert.ToString(gridViewChuyenVanVien.GetRowCellValue(i, "LYDO")) : string.Empty,
                    //LuongHangThang = gridView_NhanVien.GetRowCellValue(i, "LuongHangThang") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "LuongHangThang")) : string.Empty,
                    GHICHU = gridViewChuyenVanVien.GetRowCellValue(i, "GhiChu") != DBNull.Value ? Convert.ToString(gridViewChuyenVanVien.GetRowCellValue(i, "GhiChu")) : string.Empty,
                };
                _ListGridView.Add(DTO_ChuyenPhongBan);
            }

            return _ListGridView;
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportChuyenNhanVien rpt = new ReportChuyenNhanVien(getDanhSachGridView());
            rpt.ShowPreview();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridViewChuyenVanVien_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
            }
            //decimal lcb = luongCo.getLuongCoBan();


            id = Convert.ToInt32(gridViewChuyenVanVien.GetFocusedRowCellValue("ID").ToString());
            //_list_hd_DTO = hd.getHopDongFocus(id, _data);
            var getHDclick = _chuyenNhanVien.getItem(id);

            TextBoxLydo.Text = getHDclick.LYDO;
            TextBoxGhiChu.Text = getHDclick.GHICHU;
            comboBoxPhongBan.SelectedValue = getHDclick.IDPHONGBANMOI;
            searchLookUpEditTimNhanVien.EditValue = getHDclick.MANV;
        }
        //PhongBan PB;
        private void searchLookUpEditTimNhanVien_EditValueChanged(object sender, EventArgs e)
        {
            int phongban = (int)_nhanVien.FindMaNV(int.Parse(searchLookUpEditTimNhanVien.EditValue.ToString())).IDPB;
            //PB = new PhongBan();
            var kq = _phongBan.getItem(phongban);
            textBoxPBCU.Text = kq.TENPB.ToString();
        }

    }
}