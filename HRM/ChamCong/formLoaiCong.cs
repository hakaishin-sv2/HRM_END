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

namespace HRM.ChamCong
{
    public partial class formLoaiCong : DevExpress.XtraEditors.XtraForm
    {
        public formLoaiCong()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
        }
        LoaiCong _loaiCong;
        bool them;
        int id;
        int check;
        int fix = 0;

        void loadData()
        {
            _loaiCong = new LoaiCong();
            var list = _loaiCong.getList();
            gridControLoaiCong.DataSource = list;
            gridViewLoaiCong.OptionsBehavior.Editable = false;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtbTenLoaiCong.Enabled = !kt;
            spinEditHeSoLoaiCong.Enabled = !kt;


            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        void Reset()
        {
            txtbTenLoaiCong.Text = string.Empty;
            spinEditHeSoLoaiCong.Text = "0";
        }
        private void formLoaiCong_Load(object sender, EventArgs e)
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
            int sl = _loaiCong.getCountSoLuong();
            var x = _loaiCong.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa " + x.TENLOAICONG + " " + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _loaiCong.Xoa(id);
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
                MessageBox.Show("Quyết định không tồn tại hoặc đã bị xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        void SaveData()
        {
            try
            {
                if (them)
                {
                    if (string.IsNullOrEmpty(txtbTenLoaiCong.Text))
                    {
                        MessageBox.Show("Bạn cần Tên loại ca", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    if (spinEditHeSoLoaiCong.EditValue == null && spinEditHeSoLoaiCong.Value == 0)
                    {
                        MessageBox.Show("Bạn Cần chọn hệ số lương cửa ca", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else
                    {



                        var dt = new Data_Layer.tb_LOAICONG
                        {
                            TENLOAICONG = txtbTenLoaiCong.Text,
                            HESO = (double)spinEditHeSoLoaiCong.Value,
                        };

                        var result = _loaiCong.Them(dt);
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
                    var data = _loaiCong.getItem(id);
                    if (data != null)
                    {
                        data.TENLOAICONG = txtbTenLoaiCong.Text;
                        data.HESO = (double)spinEditHeSoLoaiCong.Value;
                        fix = 1;
                        _loaiCong.Update(data);
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

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // chưa in
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridViewLoaiCong_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
            }
            //decimal lcb = luongCo.getLuongCoBan();
            int sl = _loaiCong.getCountSoLuong();
            if (sl != 0)
            {
                id = Convert.ToInt32(gridViewLoaiCong.GetFocusedRowCellValue("IDLC").ToString());
                //_list_hd_DTO = hd.getHopDongFocus(id, _data);
                var getHDclick = _loaiCong.getItem(id);
                txtbTenLoaiCong.Text = getHDclick.TENLOAICONG;
                spinEditHeSoLoaiCong.Text = getHDclick.HESO.ToString();
            }
        }
    }
}