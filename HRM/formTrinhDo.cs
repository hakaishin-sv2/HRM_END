using BusinessLayer;
using Data_Layer;
using DevExpress.Entity.Model.Metadata;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
namespace HRM
{
    public partial class formTrinhDo : DevExpress.XtraEditors.XtraForm
    {
        public formTrinhDo()
        {
            
            InitializeComponent();
            
            loadData();
            showBar(true);
        }

        TrinhDo trinhDo;
        bool them;
        int id;

        void loadData()
        {
            trinhDo = new TrinhDo();
            gridControlTrinhDo.DataSource = trinhDo.getListTrinhDo();
            gridView_TrinhDo.OptionsBehavior.Editable = false;
        }

        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtbox_TrinhDo.Enabled = !kt;

            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }

        private void formTrinhDo_Load(object sender, EventArgs e)
        {
            them = false;
            showBar(true);
        }

        void SaveData()
        {
            try
            {
                if (them)
                {
                    if (string.IsNullOrWhiteSpace(txtbox_TrinhDo.Text))
                    {
                        MessageBox.Show("Bạn cần nhập tên trình độ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    tb_TRINHDO dt = new tb_TRINHDO
                    {
                        TENTD = txtbox_TrinhDo.Text.Trim()
                    };

                    var result = trinhDo.Them_Trinh_Do(new Data_Layer.tb_TRINHDO 
                    {
                        IDTD = dt.IDTD,
                        TENTD = dt.TENTD
                    });

                    //var result = trinhDo.Them_Trinh_Do(dt);
                    if (result != null)
                    {
                        MessageBox.Show("Thêm trình độ thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Nếu muốn làm gì đó sau khi thêm thành công, bạn có thể thêm vào đây
                        them = false;
                    }
                }
                else
                {
                    var data = trinhDo.getItem(id);
                    if (data != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtbox_TrinhDo.Text))
                        {
                            MessageBox.Show("Bạn cần nhập tên trình độ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        data.TENTD = txtbox_TrinhDo.Text.Trim();

                        trinhDo.Update(data);
                        MessageBox.Show("Cập nhật trình độ thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy trình độ để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gridView_TrinhDo_Click(object sender, EventArgs e)
        {
            if (gridView_TrinhDo.FocusedRowHandle >= 0)
            {
                id = Convert.ToInt32(gridView_TrinhDo.GetFocusedRowCellValue("IDTD"));
                txtbox_TrinhDo.Text = gridView_TrinhDo.GetFocusedRowCellValue("TENTD").ToString().Trim()+" ";
            }
        }

        private void btnThem_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtbox_TrinhDo.Text = string.Empty;
            them = true;
            showBar(false);
        }

        private void btnFix_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = false;
            showBar(false);
        }

        private void btnXoa_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa phòng ban "+ txtbox_TrinhDo.Text+ " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                trinhDo.Xoa(id);
                loadData();
                them = true;
            }
        }

        private void btnSave_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            showBar(true);
            them = false;
        }

        private void btnHuy_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
    }
}
