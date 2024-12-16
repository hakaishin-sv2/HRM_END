
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
using BusinessLayer;
using Data_Layer;
namespace HRM
{
    public partial class formChucVu : DevExpress.XtraEditors.XtraForm
    {
        public formChucVu()
        {
            InitializeComponent();
            showBar(true);
            loadData();
        }
        ChucVu chucVu;
        bool them;
        int id;
        void loadData()
        {
            chucVu = new ChucVu();
            gridControlChucVu.DataSource = chucVu.getDanhSach();
            gridView_ChucVu.OptionsBehavior.Editable = false;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtbox_ChucVu.Enabled = !kt;


            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtbox_ChucVu.Text = string.Empty;
            them = true;
            showBar(false);
        }

        private void formChucVu_Load(object sender, EventArgs e)
        {
            them = false;
            showBar(true);
        }

        private void btnFix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            them = false;
            showBar(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                chucVu.Xoa(id);
                loadData();
                them = true;
            }
        }
        void SaveData()
        {
            try
            {
                if (them)
                {
                    if (string.IsNullOrWhiteSpace(txtbox_ChucVu.Text))
                    {
                        MessageBox.Show("Bạn cần nhập tên tôn giáo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var dt = new Data_Layer.tb_CHUCVU
                    {
                        TENCV = txtbox_ChucVu.Text.Trim()
                    };

                    var result = chucVu.Them(dt);
                    if (result != null)
                    {
                        MessageBox.Show("Thêm bộ phận thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Nếu muốn làm gì đó sau khi thêm thành công, bạn có thể thêm vào đây
                        them = false;
                    }
                }
                else
                {
                    var data = chucVu.getItem(id);
                    if (data != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtbox_ChucVu.Text))
                        {
                            MessageBox.Show("Bạn cần nhập tên bộ phận", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        data.TENCV = txtbox_ChucVu.Text.Trim();

                        chucVu.Update(data);
                        MessageBox.Show("Cập nhật tên bộ phận thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bộ phận để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showBar(true);
            them = false;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView_ChucVu_Click(object sender, EventArgs e)
        {

            if (gridView_ChucVu.FocusedRowHandle >= 0)
            {
                id = Convert.ToInt32(gridView_ChucVu.GetFocusedRowCellValue("IDCV"));
                txtbox_ChucVu.Text = gridView_ChucVu.GetFocusedRowCellValue("TENCV").ToString().Trim() + " ";
            }
        }
    }
}