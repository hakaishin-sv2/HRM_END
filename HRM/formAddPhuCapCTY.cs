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
using DevExpress.XtraRichEdit.Model;

namespace HRM
{
    public partial class formAddPhuCapCTY : DevExpress.XtraEditors.XtraForm
    {
        public formAddPhuCapCTY()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
        }
        DanhSachPhuCap _dsPhuCap;
        NhanVien _nhanVien;
        PhongBan _phongBan;
       
        bool them;
        int id;
        int check;
        int fix = 0;


        void loadData()
        {
            _dsPhuCap = new DanhSachPhuCap();
            var ListData  = _dsPhuCap.getList();
            gridControlPhuCap.DataSource = ListData;
            gridViewPhuCap.OptionsBehavior.Editable = false;
           
        }

        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            textBoxTenPhuCap.Enabled= !kt;  
            textBoxSoTien.Enabled = !kt;
            TextBoxNoiDung.Enabled = !kt;

            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        void Reset()
        {
            textBoxSoTien.Text = string.Empty;
            textBoxTenPhuCap.Text = string.Empty;
            TextBoxNoiDung.Text = string.Empty;
        }
        private void formAddPhuCapCTY_Load(object sender, EventArgs e)
        {
            loadData();
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

            int sl = _dsPhuCap.SoLuong();
            var x = _dsPhuCap.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa Phụ Cấp " + x.TENPHUCAP + " " + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _dsPhuCap.Xoa(id);
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
                float sotien = BusinessLayer.Function.ConvertToVND(textBoxSoTien.Text);
                if (them)
                {
                    if (textBoxTenPhuCap.Text == string.Empty || textBoxTenPhuCap.Text =="")
                    {
                        check = 0;
                        MessageBox.Show("Bạn cần nhập tên phụ cấp ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }else if (textBoxSoTien.Text ==string.Empty || textBoxSoTien.Text=="")
                    {
                        check = 0;
                        MessageBox.Show("Bạn Nhập số tiền cho phụ cấp", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        var dt = new Data_Layer.tb_DANHSACHPHUCAP
                        {
                            TENPHUCAP = textBoxTenPhuCap.Text,
                            SOTIENPHUCAP =sotien,
                            NOIDUNG = TextBoxNoiDung.Text.Trim(),
                            CREATED_DATE = DateTime.Now,
                            //CREATE_BY = UserControl.ID,
                        };

                        var result = _dsPhuCap.Add_data(dt);
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
                    var data = _dsPhuCap.getItem(id);
                    if (data != null)
                    {
                        data.TENPHUCAP = textBoxTenPhuCap.Text;
                        data.SOTIENPHUCAP = sotien;
                        data.NOIDUNG = TextBoxNoiDung.Text;
                        data.UPDATED_DATE = DateTime.Now;
                        //data.UPDATED_BY = Session.User.MANV;
                        fix = 1;
                        _dsPhuCap.Update(data);
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

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void textBoxSoTien_TextChanged(object sender, EventArgs e)
        {
            BusinessLayer.Function.formatTextToVND(textBoxSoTien);
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
                var getHDclick = _dsPhuCap.getItem(id);
                textBoxSoTien.Text = getHDclick.SOTIENPHUCAP.ToString();
                textBoxTenPhuCap.Text = getHDclick.TENPHUCAP;
                TextBoxNoiDung.Text = getHDclick.NOIDUNG;
            }
        }
    }
}