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

namespace HRM
{
    public partial class formTonGiao : DevExpress.XtraEditors.XtraForm
    {
        public formTonGiao()
        {
            InitializeComponent();
            showBar(true);
            loadData();
        }
        TonGiao TonGiao;
        bool them;
        int id;
        void loadData()
        {
            TonGiao = new TonGiao();
            gridControl_TonGiao.DataSource = TonGiao.getListTonGiao();
            gridViewTonGiao.OptionsBehavior.Editable = false;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtbox_tenTonGiao.Enabled = !kt;


            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtbox_tenTonGiao.Text = string.Empty;
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
                TonGiao.Xoa(id);
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
                    if (string.IsNullOrWhiteSpace(txtbox_tenTonGiao.Text))
                    {
                        MessageBox.Show("Bạn cần nhập tên tôn giáo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var dt = new Data_Layer.tb_TONGIAO
                    {
                        TENTONGIA = txtbox_tenTonGiao.Text.Trim()
                    };

                    
                    var result = TonGiao.Them_Ton_Giao(dt);
                    if (result != null)
                    {
                        MessageBox.Show("Thêm tôn giáo thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Nếu muốn làm gì đó sau khi thêm thành công, bạn có thể thêm vào đây
                        them = false;
                    }
                }
                else
                {
                    var data = TonGiao.getItem(id);
                    if (data != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtbox_tenTonGiao.Text))
                        {
                            MessageBox.Show("Bạn cần nhập tên tôn giáo", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        data.TENTONGIA = txtbox_tenTonGiao.Text.Trim();

                        TonGiao.Update(data);
                        MessageBox.Show("Cập nhật tôn giáo thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tôn giáo để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        

        private void formTonGiao_Load(object sender, EventArgs e)
        {
            them = false;
            showBar(true);

        }

        private void gridViewTonGiao_Click(object sender, EventArgs e)
        {
            if (gridViewTonGiao.FocusedRowHandle >= 0)
            {
                id = Convert.ToInt32(gridViewTonGiao.GetFocusedRowCellValue("ID"));
                txtbox_tenTonGiao.Text = gridViewTonGiao.GetFocusedRowCellValue("TENTONGIA").ToString().Trim()+ " ";
            }
        }
    }
}