using BusinessLayer;
using BusinessLayer.DTO;
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
    public partial class formKhenthuong : DevExpress.XtraEditors.XtraForm
    {
        public formKhenthuong()
        {
            InitializeComponent();
            //splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel1Collapsed = true;
        }
        KhenThuong_KyLuat _khenThuong;
        NhanVien _nhanVien;
        bool them;
        int id;
        int check;
        int fix = 0;
        void loadData()
        {
            _khenThuong = new KhenThuong_KyLuat();
            var list = _khenThuong.getListDTO_KTKL(1);
            gridControlKhenThuong.DataSource = list;
            gridViewKenThuong.OptionsBehavior.Editable = false;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            TextBoxLyDo.Enabled = !kt;
            TextBoxNoiDung.Enabled = !kt;
            textBoxSoTien.Enabled = !kt;

            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        void Reset()
        {
            TextBoxLyDo.Text = string.Empty;
            TextBoxNoiDung.Text = string.Empty;
            textBoxSoTien.Text = "0 VNĐ";
            searchLookUpEditTimNhanVien.Text = string.Empty;
        }
        void loadNhanVien()
        {
            _nhanVien = new NhanVien();
            searchLookUpEditTimNhanVien.Properties.DataSource = _nhanVien.getDanhSach();
            searchLookUpEditTimNhanVien.Properties.ValueMember = "MANV";
            searchLookUpEditTimNhanVien.Properties.DisplayMember = "HOTEN";
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
            int sl = _khenThuong.SoLuongKhenThuong(1);
            var x = _khenThuong.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa khen thưởng có mã " + x.SOQUYETDINH + " " + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _khenThuong.Xoa(id);
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
                float sotien = Function.ConvertToVND(textBoxSoTien.Text);
                if (them)
                {
                    if (string.IsNullOrEmpty(TextBoxLyDo.Text))
                    {
                        MessageBox.Show("Bạn cần nhập lý do khen thưởng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                        return;
                    }
                    if (string.IsNullOrEmpty(TextBoxNoiDung.Text))
                    {
                        MessageBox.Show("Bạn cần nhập nội dung khen thưởng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                        return;
                    }
                    if (searchLookUpEditTimNhanVien.EditValue == null)
                    {
                        MessageBox.Show("Bạn cần chọn Nhân Viên được khen thưởng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                        return;
                    }

                    var arr = _khenThuong.MaQuyetDinh(1)?.Split('_');
                    int soquetdinh = int.Parse(arr[0])+1;

                    var dt = new Data_Layer.tb_KHENTHUONG_KYLUAT
                    {
                        SOQUYETDINH = soquetdinh.ToString() + "_QĐKT",
                        TUNGAY = DateTime.Now,
                        Status_tb = 0,
                        MANV = (int)searchLookUpEditTimNhanVien.EditValue,
                        DENNGAY = DateTime.Now.AddMonths(1),
                        LYDO = TextBoxLyDo.Text.Trim(),
                        NOIDUNG = TextBoxNoiDung.Text.Trim(),
                        LOAI = 1,
                        SOTIEN = sotien,
                        NAM= DateTime.Now.Year,
                        THANG= DateTime.Now.Month,
                        CREATED_DATE = DateTime.Now,
                    };

                    var result = _khenThuong.Them(dt);
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
                    var data = _khenThuong.getItem(id);
                    if (data != null)
                    {
                        data.MANV = (int)searchLookUpEditTimNhanVien.EditValue;
                        data.LYDO = TextBoxLyDo.Text.Trim();
                        data.NOIDUNG = TextBoxNoiDung.Text.Trim();
                        data.SOTIEN = sotien;
                        data.NAM = DateTime.Now.Year;
                        data.THANG = DateTime.Now.Month;
                        fix = 1;
                        _khenThuong.Update(data);
                        MessageBox.Show("Đã cập nhật lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

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
        List<KhenThuong_kyluat_DTO> _ListGridView;
        public List<KhenThuong_kyluat_DTO> getDanhSachGridView()
        {
            _ListGridView = new List<KhenThuong_kyluat_DTO>();

            for (int i = 0; i < gridViewKenThuong.RowCount; i++)
            {
                var DTO_KhenThuong = new KhenThuong_kyluat_DTO
                {
                    STT = i + 1,
                    MANV = gridViewKenThuong.GetRowCellValue(i, "MANV") != DBNull.Value ? Convert.ToInt32(gridViewKenThuong.GetRowCellValue(i, "MANV")) : 000,
                    HOTEN = gridViewKenThuong.GetRowCellValue(i, "HOTEN") != DBNull.Value ? Convert.ToString(gridViewKenThuong.GetRowCellValue(i, "HOTEN")) : "",
                    TenPhongBan = gridViewKenThuong.GetRowCellValue(i, "TenPhongBan") != DBNull.Value ? Convert.ToString(gridViewKenThuong.GetRowCellValue(i, "TenPhongBan")) : string.Empty,
                    LYDO = gridViewKenThuong.GetRowCellValue(i, "LYDO") != DBNull.Value ? Convert.ToString(gridViewKenThuong.GetRowCellValue(i, "LYDO")) : string.Empty,
                    NOIDUNG = gridViewKenThuong.GetRowCellValue(i, "NOIDUNG") != DBNull.Value ? Convert.ToString(gridViewKenThuong.GetRowCellValue(i, "NOIDUNG")) : string.Empty,
                    //LuongHangThang = gridView_NhanVien.GetRowCellValue(i, "LuongHangThang") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "LuongHangThang")) : string.Empty,
                    TUNGAY = gridViewKenThuong.GetRowCellValue(i, "TUNGAY") != DBNull.Value ? Convert.ToDateTime(gridViewKenThuong.GetRowCellValue(i, "TUNGAY")) : DateTime.MinValue,
                };
                _ListGridView.Add(DTO_KhenThuong);
            }

            return _ListGridView;
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
            ReportChuyenNhanVien123 rpt = new ReportChuyenNhanVien123(getDanhSachGridView());
            rpt.ShowPreview();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridViewKenThuong_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
            }
            //decimal lcb = luongCo.getLuongCoBan();
            int sl = _khenThuong.SoLuongKhenThuong(1);
            if (sl != 0)
            {
                id = Convert.ToInt32(gridViewKenThuong.GetFocusedRowCellValue("ID").ToString());
                //_list_hd_DTO = hd.getHopDongFocus(id, _data);
                var getHDclick = _khenThuong.getItem(id);

                TextBoxLyDo.Text = getHDclick.LYDO;
                TextBoxNoiDung.Text = getHDclick.NOIDUNG;
                textBoxSoTien.Text = getHDclick.SOTIEN.ToString();
                searchLookUpEditTimNhanVien.EditValue = getHDclick.MANV;
            }  
        }

        private void formKhenthuong_Load(object sender, EventArgs e)
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

        private void textBoxSoTien_TextChanged(object sender, EventArgs e)
        {
            // Lưu lại vị trí con trỏ trước khi thay đổi văn bản
            int cursorPosition = textBoxSoTien.SelectionStart;

            // Loại bỏ dấu phân cách hàng nghìn và chuỗi " VNĐ" nếu có
            string input = textBoxSoTien.Text.Replace(",", "").Replace(" VNĐ", "").Trim();

            // Chuyển đổi thành số nguyên (hoặc số thực nếu cần)
            if (decimal.TryParse(input, out decimal value))
            {
                // Định dạng lại số tiền với dấu phân cách hàng nghìn và thêm " VNĐ"
                textBoxSoTien.Text = value.ToString("N0") + " VNĐ";

                // Đặt lại vị trí con trỏ sau khi định dạng lại văn bản
                textBoxSoTien.SelectionStart = Math.Min(cursorPosition, textBoxSoTien.Text.Length - " VNĐ".Length);
            }
        }
    }
}