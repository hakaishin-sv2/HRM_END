using BusinessLayer.DTO;
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
using BusinessLayer.ClassChamCong;
using BusinessLayer.Convert_DTO;
using Data_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HRM.ChamCong
{
    public partial class formPhuCap : DevExpress.XtraEditors.XtraForm
    {
        public formPhuCap()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
        }
        PhuCap _phuCap;
        int _selectedIDPC=0;

        NhanVien _nhanVien;
        PhongBan _phongBan;
        List<PhuCap_DTO> _ListDto_PhuCap;
        bool them;
        int id;
        int check;
        int fix = 0;

        void loadData()
        {
            _phuCap = new PhuCap();
            _ListDto_PhuCap = _phuCap.getListDTO();
            gridControlPhuCap.DataSource = _ListDto_PhuCap;
            gridViewPhuCap.OptionsBehavior.Editable = false;
            textBoxSoTien.Text = "1,000,000 VNĐ";
        }

        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            comboBoxPhuCap.Enabled = !kt;
            textBoxSoTien.Enabled = !kt;
            TextBoxNoiDung.Enabled = !kt;
            searchLookUpEditTimNhanVien.Enabled = !kt;
            

            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        void Reset()
        {
            textBoxSoTien.Text = string.Empty;
            searchLookUpEditTimNhanVien.Text = string.Empty;
            TextBoxNoiDung.Text= string.Empty;
        }
        void loadNhanVien()
        {
            _nhanVien = new NhanVien();
            searchLookUpEditTimNhanVien.Properties.DataSource = _nhanVien.getListDTO_NhanVien();
            searchLookUpEditTimNhanVien.Properties.ValueMember = "MANV";
         
            searchLookUpEditTimNhanVien.Properties.DisplayMember = "TENCV";
            searchLookUpEditTimNhanVien.Properties.DisplayMember = "HOTEN";
        }
        // Hàm để đưa dữ liệu vào ComboBox
        private void LoadDataIntoComboBox()
        {
            List<PhuCapInfo> danhSachPhuCap = _phuCap.GetDanhSachPhuCap();

            comboBoxPhuCap.DataSource = danhSachPhuCap;
            comboBoxPhuCap.DisplayMember = "TenPhuCap"; // Hiển thị tên phụ cấp
            comboBoxPhuCap.ValueMember = "IDPC";       // Giá trị chính là ID phụ cấp
        }

        private void formPhuCap_Load(object sender, EventArgs e)
        {
            loadData();
            loadNhanVien();
            LoadDataIntoComboBox();
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
            int sl = _phuCap.SoLuong();
            var x = _phuCap.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa Phụ Cấp " + x.TENPC + " " + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _phuCap.Xoa(id);
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
            try
            {
                double sotien = Function.ConvertToVND(textBoxSoTien.Text);
                if (them)
                {
                    if (searchLookUpEditTimNhanVien.EditValue == null ||
    string.IsNullOrEmpty(searchLookUpEditTimNhanVien.EditValue.ToString()))
                    {
                        MessageBox.Show("Bạn cần chọn Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                      
                        var dt = new Data_Layer.tb_PHUCAP
                        {
                            MANV = (int)searchLookUpEditTimNhanVien.EditValue,
                            IDPC = _selectedIDPC,
                            TENPC = comboBoxPhuCap.Text,
                            SOTIEN = sotien,
                            NGAY = DateTime.Now,
                            NOIDUNG = TextBoxNoiDung.Text,
                            CREATED_DATE = DateTime.Now,
                            //CREATE_BY = UserControl.ID,
                        };

                        var result = _phuCap.Them(dt);
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
                    var data = _phuCap.getItem(id);
                    if (data != null)
                    {
                        data.MANV = (int)searchLookUpEditTimNhanVien.EditValue;
                        data.IDPC = _selectedIDPC;
                        data.TENPC = comboBoxPhuCap.Text;
                        data.SOTIEN = sotien;
                        data.NGAY = DateTime.Now;
                        data.NOIDUNG = TextBoxNoiDung.Text.Trim();
                        data.CREATED_DATE = DateTime.Now;

                        fix = 1;
                        _phuCap.Update(data);
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

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridViewPhuCap_Click(object sender, EventArgs e)
        {
            if (gridViewPhuCap.RowCount > 0)
            {
                if (splitContainer1.Panel1Collapsed == true)
                {
                    splitContainer1.Panel1Collapsed = false;
                }       
                id = Convert.ToInt32(gridViewPhuCap.GetFocusedRowCellValue("ID").ToString());
                var getHDclick = _phuCap.getItem(id);
                searchLookUpEditTimNhanVien.EditValue = getHDclick.MANV;
                var x = getHDclick.IDPC;
                comboBoxPhuCap.SelectedValue = x;
                textBoxSoTien.Text = getHDclick.SOTIEN.ToString();
                TextBoxNoiDung.Text = getHDclick.NOIDUNG;
            }
        }

        private void comboBoxPhuCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (comboBoxPhuCap.SelectedItem is PhuCapInfo selectedPhuCap)// để chon combobox nào sẽ lấy ra giá trị binding tương ứng
            {
                _selectedIDPC = selectedPhuCap.IDPC;
                double selectedSoTienPhuCap = double.Parse(selectedPhuCap.SoTienPhuCap.ToString());
                textBoxSoTien.Text = selectedSoTienPhuCap.ToString("N0") + " VNĐ"; 
            }
            
        }

        private void textBoxSoTien_TextChanged(object sender, EventArgs e)
        {
            BusinessLayer.Function.formatTextToVND(textBoxSoTien);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}