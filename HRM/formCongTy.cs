using BusinessLayer;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Data_Layer;

namespace HRM
{
    public partial class formCongTy : DevExpress.XtraEditors.XtraForm
    {
        public formCongTy()
        {
            InitializeComponent();
        }
        CongTy congTy;
        bool them;
        int id;

        void loadData()
        {
            congTy = new CongTy();
            gridControlCongTy.DataSource = congTy.getDanhSach();
            gridView_CongTy.OptionsBehavior.Editable = false;
        }

        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtbox_MaCongTy.Enabled = !kt;
            txtBox_TenCongTy.Enabled = !kt;
            textBox_EmailCongTy.Enabled = !kt;
            textBox_Sdt_CongTy.Enabled = !kt;
            textBoxDiaChiCongTy.Enabled = !kt;

            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtbox_MaCongTy.Text = string.Empty;
            txtBox_TenCongTy.Text = string.Empty;
            textBox_EmailCongTy.Text = string.Empty;
            textBox_Sdt_CongTy.Text = string.Empty;
            textBoxDiaChiCongTy.Text = string.Empty;
            them = true;
            showBar(false);
        }

        private void btnFix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = false;
            showBar(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa công ty " + txtBox_TenCongTy.Text + " không", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                congTy.Xoa(id);
                loadData();
                them = true;
            }
        }

        void SaveData()
        {
            try
            {
                if (txtbox_MaCongTy == null || txtBox_TenCongTy == null || textBox_Sdt_CongTy == null ||
                    textBox_EmailCongTy == null || textBoxDiaChiCongTy == null)
                {
                    MessageBox.Show("Có lỗi xảy ra với các điều khiển giao diện người dùng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (congTy == null)
                {
                    MessageBox.Show("Đối tượng congTy chưa được khởi tạo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (them)
                {
                    if (string.IsNullOrWhiteSpace(txtbox_MaCongTy.Text))
                    {
                        MessageBox.Show("Bạn cần nhập mã công ty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!Function.IsNumeric(txtbox_MaCongTy.Text.Trim()))
                    {
                        MessageBox.Show("Mã công ty phải là dạng số", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtBox_TenCongTy.Text))
                    {
                        MessageBox.Show("Bạn cần nhập Tên công ty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(textBox_Sdt_CongTy.Text))
                    {
                        MessageBox.Show("Bạn cần nhập SDT công ty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!Function.IsValidPhoneNumber(textBox_Sdt_CongTy.Text.Trim()))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(textBox_EmailCongTy.Text))
                    {
                        MessageBox.Show("Bạn cần nhập Email công ty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!Function.IsValidEmail(textBox_EmailCongTy.Text.Trim()))
                    {
                        MessageBox.Show("Email không hợp lệ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(textBoxDiaChiCongTy.Text))
                    {
                        MessageBox.Show("Bạn cần nhập Địa Chỉ công ty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var dt = new Data_Layer.tb_CONGTY
                    {
                        IDCONGTY = int.Parse(txtbox_MaCongTy.Text.ToString().Trim()),
                        TENCONGTY = txtBox_TenCongTy.Text.Trim(),
                        SDT = textBox_Sdt_CongTy.Text.ToString().Trim(),
                        EMAIL = textBox_EmailCongTy.Text.ToString().Trim(),
                        DIACHI = textBoxDiaChiCongTy.Text.ToString().Trim(),
                        
                    };

                    var result = congTy.Update(dt);

                    if (result != null)
                    {
                        MessageBox.Show("Thêm công ty thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        them = false;
                    }
                }
                else
                {
                    var data = congTy.getItem(id);
                    if (data != null)
                    {
                        data.IDCONGTY = int.Parse(txtbox_MaCongTy.Text.ToString().Trim());
                        data.TENCONGTY = txtBox_TenCongTy.Text.Trim();
                        data.SDT = textBox_Sdt_CongTy.Text.ToString().Trim();
                        data.EMAIL = textBox_EmailCongTy.Text.ToString().Trim();
                        data.DIACHI = textBoxDiaChiCongTy.Text.ToString().Trim();

                        congTy.Update(data);
                        MessageBox.Show("Cập nhật công ty thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy công ty để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            loadData();
            showBar(true);
            them = false;
            txtbox_MaCongTy.Text = string.Empty;
            txtBox_TenCongTy.Text = string.Empty;
            textBox_EmailCongTy.Text = string.Empty;
            textBox_Sdt_CongTy.Text = string.Empty;
            textBoxDiaChiCongTy.Text = string.Empty;

        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showBar(true);
            them = false;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Code for print function
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void formCongTy_Load(object sender, EventArgs e)
        {
            them = false;
            showBar(true);
            loadData();
        }

        private void gridView_CongTy_Click(object sender, EventArgs e)
        {
            if (gridView_CongTy.FocusedRowHandle >= 0)
            {
                id = Convert.ToInt32(gridView_CongTy.GetFocusedRowCellValue("ID"));
                txtBox_TenCongTy.Text = gridView_CongTy.GetFocusedRowCellValue("TENCONGTY").ToString().Trim() + " ";
                txtbox_MaCongTy.Text = gridView_CongTy.GetFocusedRowCellValue("IDCONGTY").ToString().Trim() + " ";
                textBox_EmailCongTy.Text = gridView_CongTy.GetFocusedRowCellValue("EMAIL").ToString().Trim() + " ";
                textBox_Sdt_CongTy.Text = gridView_CongTy.GetFocusedRowCellValue("SDT").ToString().Trim() + " ";
                textBoxDiaChiCongTy.Text = gridView_CongTy.GetFocusedRowCellValue("DIACHI").ToString().Trim() + " ";
            }
            MessageBox.Show("Id công ty  " + id.ToString());
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
