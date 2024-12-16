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
    public partial class formKyLuat : DevExpress.XtraEditors.XtraForm
    {
        public formKyLuat()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
        }
        KhenThuong_KyLuat _KyLuat;
        NhanVien _nhanVien;
        bool them;
        int id;
        int check;
        int fix = 0;
        void loadData()
        {
            _KyLuat = new KhenThuong_KyLuat();
            gridControlKyLuat.DataSource = _KyLuat.getListDTO_KTKL(0);
            gridViewKyLuat.OptionsBehavior.Editable = false;
        }
        void Reset()
        {
            TextBoxLyDo.Text = string.Empty;
            TextBoxNoiDung.Text = string.Empty;
            textBoxSoTien.Text = "0 VNĐ";
            searchLookUpEditTimNhanVien.Text = string.Empty;
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
            int sl = _KyLuat.SoLuongKhenThuong(0);
            var x = _KyLuat.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa kỷ luật có mã " + x.SOQUYETDINH + " " + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _KyLuat.Xoa(id);
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
            //MessageBox.Show(id.ToString());

            try
            {
                float sotien = Function.ConvertToVND(textBoxSoTien.Text);
                if (them)
                {
                    if (TextBoxLyDo.Text == string.Empty)
                    {
                        MessageBox.Show("Bạn cần nhập lý do kỷ luật", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (TextBoxNoiDung.Text == string.Empty)
                    {
                        MessageBox.Show("Bạn cần nhập nội dung kỷ luật ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (searchLookUpEditTimNhanVien.EditValue == string.Empty)
                    {
                        MessageBox.Show("Bạn cần chọn Nhân Viên bị kỷ luật ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }

                    else
                    {
                        var arr = _KyLuat.MaQuyetDinh(0).Split('-');
                        int soquetdinh = int.Parse(arr[0]) + 1;
                        var dt = new Data_Layer.tb_KHENTHUONG_KYLUAT
                        {

                            SOQUYETDINH = soquetdinh.ToString() + "-QĐKL",
                            TUNGAY = DateTime.Now,
                            Status_tb = 0,
                            MANV = (int)searchLookUpEditTimNhanVien.EditValue,
                            DENNGAY = DateTime.Now.AddMonths(1),
                            LYDO = TextBoxLyDo.Text.Trim(),
                            NOIDUNG = TextBoxNoiDung.Text.Trim(),
                            LOAI = 0,
                            SOTIEN = sotien,
                            NAM = DateTime.Now.Year,
                            THANG = DateTime.Now.Month,
                            CREATED_DATE = DateTime.Now,

                        };

                        var result = _KyLuat.Them(dt);
                        if (result != null)
                        {
                            check = 1;
                            MessageBox.Show("Đã thêm mới thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra khi thêm ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else// update
                {


                    var data = _KyLuat.getItem(id);
                    if (data != null)
                    {
                        data.MANV = (int)searchLookUpEditTimNhanVien.EditValue;
                        data.LYDO = TextBoxLyDo.Text.Trim();
                        data.NOIDUNG = TextBoxNoiDung.Text.Trim();
                        data.SOTIEN = sotien;
                        data.NAM = DateTime.Now.Year;
                        data.THANG = DateTime.Now.Month;
                        fix = 1;
                        _KyLuat.Update(data);
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
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            for (int i = 0; i < gridViewKyLuat.RowCount; i++)
            {
                var DTO_KhenThuong = new KhenThuong_kyluat_DTO
                {
                    STT = i + 1,
                    MANV = gridViewKyLuat.GetRowCellValue(i, "MANV") != DBNull.Value ? Convert.ToInt32(gridViewKyLuat.GetRowCellValue(i, "MANV")) : 000,
                    HOTEN = gridViewKyLuat.GetRowCellValue(i, "HOTEN") != DBNull.Value ? Convert.ToString(gridViewKyLuat.GetRowCellValue(i, "HOTEN")) : "",
                    TenPhongBan = gridViewKyLuat.GetRowCellValue(i, "TenPhongBan") != DBNull.Value ? Convert.ToString(gridViewKyLuat.GetRowCellValue(i, "TenPhongBan")) : string.Empty,
                    LYDO = gridViewKyLuat.GetRowCellValue(i, "LYDO") != DBNull.Value ? Convert.ToString(gridViewKyLuat.GetRowCellValue(i, "LYDO")) : string.Empty,
                    NOIDUNG = gridViewKyLuat.GetRowCellValue(i, "NOIDUNG") != DBNull.Value ? Convert.ToString(gridViewKyLuat.GetRowCellValue(i, "NOIDUNG")) : string.Empty,
                    //LuongHangThang = gridView_NhanVien.GetRowCellValue(i, "LuongHangThang") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "LuongHangThang")) : string.Empty,
                    TUNGAY = gridViewKyLuat.GetRowCellValue(i, "TUNGAY") != DBNull.Value ? Convert.ToDateTime(gridViewKyLuat.GetRowCellValue(i, "TUNGAY")) : DateTime.MinValue,
                    DENNGAY = Convert.ToDateTime(gridViewKyLuat.GetRowCellValue(i, "TUNGAY")).AddMonths(1),
                };
                _ListGridView.Add(DTO_KhenThuong);
            }

            return _ListGridView;
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportKyLuat rpt = new ReportKyLuat(getDanhSachGridView());
            rpt.ShowPreview();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void formKyLuat_Load(object sender, EventArgs e)
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
                splitContainer1.Panel1Collapsed = true;
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