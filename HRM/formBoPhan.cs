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
namespace HRM
{
    public partial class formBoPhan : DevExpress.XtraEditors.XtraForm
    {
        public formBoPhan()
        {
            InitializeComponent();
            showBar(true);
            loadData();
        }
        BoPhan boPhan;
        bool them;
        int id;
        void loadData()
        {
            boPhan = new BoPhan();
            gridControlBoPhan.DataSource = boPhan.getDanhSach();
            gridView_BoPhan.OptionsBehavior.Editable = false;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtbox_BoPhan.Enabled = !kt;


            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtbox_BoPhan.Text = string.Empty;
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
            if (MessageBox.Show("Bạn muốn xóa không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                boPhan.Xoa(id);
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
                    if (string.IsNullOrWhiteSpace(txtbox_BoPhan.Text))
                    {
                        MessageBox.Show("Bạn cần nhập tên bộ phận ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var dt = new Data_Layer.tb_BOPHAN
                    {
                        TENBP = txtbox_BoPhan.Text.Trim()
                    };

                   

                    var result = boPhan.Them(dt);
                    if (result != null)
                    {
                        MessageBox.Show("Thêm bộ phận thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Nếu muốn làm gì đó sau khi thêm thành công, bạn có thể thêm vào đây
                        them = false;
                    }
                }
                else
                {
                    var data = boPhan.getItem(id);
                    if (data != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtbox_BoPhan.Text))
                        {
                            MessageBox.Show("Bạn cần nhập tên bộ phận", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        data.TENBP = txtbox_BoPhan.Text.Trim();

                        boPhan.Update(data);
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

        private void formBoPhan_Load(object sender, EventArgs e)
        {
            them = false;
            showBar(true);
        }

        private void gridView_BoPhan_Click(object sender, EventArgs e)
        {

            if (gridView_BoPhan.FocusedRowHandle >= 0)
            {
                id = Convert.ToInt32(gridView_BoPhan.GetFocusedRowCellValue("IDBP"));
                txtbox_BoPhan.Text = gridView_BoPhan.GetFocusedRowCellValue("TENBP").ToString().Trim() + " ";
            }
        }

        private void gridControlBoPhan_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlTop_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlBottom_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlLeft_Click(object sender, EventArgs e)
        {

        }

        private void barDockControlRight_Click(object sender, EventArgs e)
        {

        }

        private void txtbox_BoPhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbox_PhongBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}