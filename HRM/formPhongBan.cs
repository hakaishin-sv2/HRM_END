using BusinessLayer;
using Data_Layer;
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
using DevExpress.XtraEditors.Design;
namespace HRM
{
    public partial class formPhongBan : DevExpress.XtraEditors.XtraForm
    {
        public formPhongBan()
        {
            InitializeComponent();
            loadData();
            showBar(true);
        }
        PhongBan phongBan;
        bool them;
        int id;
        void loadData()
        {
            phongBan = new PhongBan();
            gridControlPhongBan.DataSource = phongBan.getListPhongBan();
            gridView_PhongBan.OptionsBehavior.Editable = false;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            tbox_PhongBan.Enabled = !kt;

            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControlPhongBan_Click(object sender, EventArgs e)
        {

        }

        private void btnFix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = false;
            showBar(false);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tbox_PhongBan.Text = string.Empty;
            them = true;
            showBar(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa trình độ " + tbox_PhongBan.Text + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                phongBan.Xoa(id);
                loadData();
                them = true;
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
        void SaveData()
        {
            try
            {
                if (them)
                {
                    if (string.IsNullOrWhiteSpace(tbox_PhongBan.Text))
                    {
                        MessageBox.Show("Bạn cần nhập tên phòng ban", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var dt = new Data_Layer.tb_PHONGBAN
                    {
                        TENPB = tbox_PhongBan.Text.Trim()
                    };

                    var result = phongBan.Them(dt);
                    if (result != null)
                    {
                        MessageBox.Show("Thêm phòng ban thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Nếu muốn làm gì đó sau khi thêm thành công, bạn có thể thêm vào đây
                        them = false;
                    }
                }
                else
                {
                    var data = phongBan.getItem(id);
                    if (data != null)
                    {
                        if (string.IsNullOrWhiteSpace(tbox_PhongBan.Text))
                        {
                            MessageBox.Show("Bạn cần nhập tên phòng ban", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        data.TENPB = tbox_PhongBan.Text.Trim();

                        phongBan.Update(data);
                        MessageBox.Show("Cập nhật phòng ban thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phòng ban để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView_PhongBan_Click(object sender, EventArgs e)
        {
            if (gridView_PhongBan.FocusedRowHandle >= 0)
            {
                id = Convert.ToInt32(gridView_PhongBan.GetFocusedRowCellValue("IDPB"));
                tbox_PhongBan.Text = gridView_PhongBan.GetFocusedRowCellValue("TENPB").ToString().Trim() + " ";
            }
        }

        private void formPhongBan_Load(object sender, EventArgs e)
        {
            them = false;
            showBar(true);
        }
    }
}