using DevExpress.XtraBars;
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
using BusinessLayer;
using DevExpress.XtraPrinting.Native;
namespace HRM
{
    public partial class formDanToc : DevExpress.XtraEditors.XtraForm
    {
        public formDanToc()
        {
            InitializeComponent();
            loadListDanToc();
        }
        DanToc dantoc;
        bool them;
        int id;
        void loadListDanToc()
        {
            dantoc = new DanToc();
            gridControlDanToc.DataSource = dantoc.getListDanToc();
            gridView_DanToc.OptionsBehavior.Editable = false;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtbox_tendantoc.Enabled = !kt;


            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtbox_tendantoc.Text= string.Empty;
            them = true;
            showBar(false);
        }

        private void btnFix_ItemClick(object sender, ItemClickEventArgs e)
        {
            them = false;
            showBar(false);

        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(MessageBox.Show("Bạn muốn xóa không","Waring",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                dantoc.Xoa(id);
                loadListDanToc();
            }
        }
        void SaveData()
        {
            try
            {
                if (them)
                {
                    if (string.IsNullOrWhiteSpace(txtbox_tendantoc.Text))
                    {
                        MessageBox.Show("Bạn cần nhập tên dân tộc", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var dt = new Data_Layer.tb_DANTOC
                    {
                        TENDANTOC = txtbox_tendantoc.Text.Trim()
                    };

                    var result = dantoc.Them_dan_toc(dt);

                    //var result = dantoc.Them_dan_toc(new Data_Layer.tb_DANTOC
                    //{
                    //    ID = dt.ID,
                    //    TENDANTOC = dt.TENDANTOC,
                    //});

                    if (result != null)
                    {
                        MessageBox.Show("Thêm dân tộc thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Nếu muốn làm gì đó sau khi thêm thành công, bạn có thể thêm vào đây
                        them = false;
                    }
                }
                else
                {
                    var data = dantoc.getItem(id);
                    if (data != null)
                    {
                        if (string.IsNullOrWhiteSpace(txtbox_tendantoc.Text))
                        {
                            MessageBox.Show("Bạn cần nhập tên dân tộc", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        data.TENDANTOC = txtbox_tendantoc.Text.Trim();

                        dantoc.Update(data);
                        MessageBox.Show("Cập nhật dân tộc thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dân tộc để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveData();
            loadListDanToc();
            showBar(true);
            them = false;
        }

        private void btnHuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            showBar(true);
            them = false;
        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            showBar(false);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void txtbox_tendantoc_TextChanged(object sender, EventArgs e)
        {
            //txtbox_tendantoc.Text = null;
        }

        private void txtbox_tendantoc_Click(object sender, EventArgs e)
        {
            txtbox_tendantoc.Text = string.Empty;
        }
       

        
        private void formDanToc_Load(object sender, EventArgs e)
        {
            them = false;
            showBar(true);
            
        }

        private void gridView_DanToc_Click(object sender, EventArgs e)
        {
            if (gridView_DanToc.FocusedRowHandle >= 0)
            {
                id = Convert.ToInt32(gridView_DanToc.GetFocusedRowCellValue("ID"));
                txtbox_tendantoc.Text = gridView_DanToc.GetFocusedRowCellValue("TENDANTOC").ToString();
            }
        }
    }
}