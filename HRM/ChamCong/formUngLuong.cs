using BusinessLayer.ClassChamCong;
using BusinessLayer.Convert_DTO;
using BusinessLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Layer;

namespace HRM.ChamCong
{
    public partial class formUngLuong : DevExpress.XtraEditors.XtraForm
    {
        public formUngLuong()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
        }
        UngLuong _ungLuong;
        NhanVien _nhanVien;
        List<UngLuong_DTO> _ListDto_UngLuong;
        bool them;
        int id;
        int check;
        int fix = 0;

        void loadData()
        {
            _ungLuong = new UngLuong();
            _ListDto_UngLuong = _ungLuong.getListDTO();
            gridControlUngLuong.DataSource = _ListDto_UngLuong;
            gridViewUngLuong.OptionsBehavior.Editable = false;
        }

        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            TextBoxNoiDung.Enabled = !kt;
            textBoxSoTienUngLuong.Enabled = !kt;
            searchLookUpEditTimNhanVien.Enabled = !kt;


            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        void Reset()
        {
            TextBoxNoiDung.Text = string.Empty;
            TextBoxNoiDung.Text = string.Empty;
            searchLookUpEditTimNhanVien.Text = string.Empty;
            
        }

        void loadNhanVien()
        {
            _nhanVien = new NhanVien();
            searchLookUpEditTimNhanVien.Properties.DataSource = _nhanVien.getListDTO_NhanVien();
            searchLookUpEditTimNhanVien.Properties.ValueMember = "MANV";
            searchLookUpEditTimNhanVien.Properties.DisplayMember = "HOTEN";
            //searchLookUpEditTimNhanVien.Properties.DisplayMember = "TENCV";
        }
        private void textBoxSoTienUngLuong_TextChanged(object sender, EventArgs e)
        {
            // Lưu lại vị trí con trỏ trước khi thay đổi văn bản
            int cursorPosition = textBoxSoTienUngLuong.SelectionStart;

            // Loại bỏ dấu phân cách hàng nghìn và chuỗi " VNĐ" nếu có
            string input = textBoxSoTienUngLuong.Text.Replace(",", "").Replace(" VNĐ", "").Trim();

            // Chuyển đổi thành số nguyên (hoặc số thực nếu cần)
            if (decimal.TryParse(input, out decimal value))
            {
                // Định dạng lại số tiền với dấu phân cách hàng nghìn và thêm " VNĐ"
                textBoxSoTienUngLuong.Text = value.ToString("N0") + " VNĐ";

                // Đặt lại vị trí con trỏ sau khi định dạng lại văn bản
                textBoxSoTienUngLuong.SelectionStart = Math.Min(cursorPosition, textBoxSoTienUngLuong.Text.Length - " VNĐ".Length);
            }
        }

        private void formUngLuong_Load(object sender, EventArgs e)
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
            int sl = _ungLuong.SoLuong();
            var x = _ungLuong.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa Nhân viên"+" ứng lương này  không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _ungLuong.Xoa(id);
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
                MessageBox.Show("Quyết định không tồn tại hoặc đã bị xóa. Hoặc bạn cấn click vào dòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void SaveData()
        {
            double Sotienungluong=0;
            try
            {
                if (them)
                {
                    var value = Convert.ToInt32(searchLookUpEditTimNhanVien.EditValue);
                    if (value == 0)
                    {
                        MessageBox.Show("Bạn cần chọn Nhân Viên Cho Phụ Cấp", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }else if (Function.IsValidCurrencyFormat(textBoxSoTienUngLuong.Text) == false)
                    {
                        MessageBox.Show("Bạn cần nhập đúng dạng số tiền ! VÍ DỤ: 500,000 VNĐ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else
                    {
                        Sotienungluong = Function.ConvertToVND(textBoxSoTienUngLuong.Text);
                        var dt = new Data_Layer.tb_UNGLUONG
                        {
                            MANV = searchLookUpEditTimNhanVien.EditValue != null ? (int)searchLookUpEditTimNhanVien.EditValue : 0,
                            THANG = DateTime.Now.Month,
                            NGAY = DateTime.Now.Day,
                            NAM = DateTime.Now.Year,
                            SOTIENUNGLUONG = (double)Sotienungluong,
                            GHICHU = TextBoxNoiDung.Text.Trim(),
                            CREATED_DATE = DateTime.Now,
                           
                            //CREATE_BY = UserControl.ID,
                        };
                        var result = _ungLuong.Them(dt);
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
                }
                else // update
                {
                    if (Function.IsValidCurrencyFormat(textBoxSoTienUngLuong.Text) == false)
                    {
                        MessageBox.Show("Bạn cần nhập đúng dạng số tiền ! VÍ DỤ: 500,000 VNĐ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else
                    {
                        Sotienungluong = Function.ConvertToVND(textBoxSoTienUngLuong.Text);
                        var data = _ungLuong.getItem(id);
                        if (data != null)
                        {
                            data.MANV = searchLookUpEditTimNhanVien.EditValue != null ? (int)searchLookUpEditTimNhanVien.EditValue : 0;
                            data.THANG = DateTime.Now.Month;
                            data.NGAY = DateTime.Now.Day;
                            data.NAM = DateTime.Now.Year;
                            data.SOTIENUNGLUONG = (double)Sotienungluong;
                            data.GHICHU = TextBoxNoiDung.Text.Trim();
                            data.UPDATED_DATE = DateTime.Now;
                            //data.UPDATED_BY = User.ID;
                            fix = 1;
                            _ungLuong.Update(data);
                            MessageBox.Show("Đã cập nhật lại thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridViewUngLuong_Click(object sender, EventArgs e)
        {
            if (gridViewUngLuong.RowCount > 0)
            {
                if (splitContainer1.Panel1Collapsed == true)
                {
                    splitContainer1.Panel1Collapsed = false;
                }
                id = Convert.ToInt32(gridViewUngLuong.GetFocusedRowCellValue("ID").ToString());
                //_tangCa = new TangCa();
                var getHDclick = _ungLuong.getItem(id);
                searchLookUpEditTimNhanVien.EditValue = getHDclick.MANV;
                textBoxSoTienUngLuong.Text = getHDclick.SOTIENUNGLUONG.ToString();
                TextBoxNoiDung.Text = getHDclick.GHICHU;
            }
        }

        private void searchLookUpEditTimNhanVien_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}