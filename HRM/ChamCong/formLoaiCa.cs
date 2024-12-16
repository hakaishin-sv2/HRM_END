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

namespace HRM.ChamCong
{
    public partial class formLoaiCa : DevExpress.XtraEditors.XtraForm
    {
        public formLoaiCa()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
        }
        LoaiCa _loaiCa;
        bool them;
        int id;
        int check;
        int fix = 0;

        void loadData()
        {
            _loaiCa = new LoaiCa();
            var list = _loaiCa.getList();
            gridControLoaiCa.DataSource = list;
            gridViewLoaiCa.OptionsBehavior.Editable = false;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtbTenLoaiCa.Enabled = !kt;
            spinEditHeSoCa.Enabled = !kt;


            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        void Reset()
        {
            txtbTenLoaiCa.Text = string.Empty;
            spinEditHeSoCa.Text = "0";
        }
        private void formLoaiCa_Load(object sender, EventArgs e)
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
            int sl = _loaiCa.getCountSoLuong();
            var x = _loaiCa.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa " + x.TENLOAICA + " " + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _loaiCa.Xoa(id);
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
                    if (string.IsNullOrEmpty(txtbTenLoaiCa.Text))
                    {
                        MessageBox.Show("Bạn cần Tên loại ca", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;               
                    }
                    if (spinEditHeSoCa.EditValue == null && spinEditHeSoCa.Value == 0)
                    {
                        MessageBox.Show("Bạn Cần chọn hệ số lương cửa ca", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else
                    {

                      

                        var dt = new Data_Layer.tb_LOAICA
                        {
                            TENLOAICA = txtbTenLoaiCa.Text,
                            HESO = (double)spinEditHeSoCa.Value,
                        };

                        var result = _loaiCa.Them(dt);
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
                    var data = _loaiCa.getItem(id);
                    if (data != null)
                    {
                        data.TENLOAICA = txtbTenLoaiCa.Text;
                        data.HESO = (double)spinEditHeSoCa.Value;
                        fix = 1;
                        _loaiCa.Update(data);
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

        private void gridViewLoaiCa_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
            }
            //decimal lcb = luongCo.getLuongCoBan();
            int sl = _loaiCa.getCountSoLuong();
            if (sl != 0)
            {
                id = Convert.ToInt32(gridViewLoaiCa.GetFocusedRowCellValue("IDLOAICA").ToString());
                //_list_hd_DTO = hd.getHopDongFocus(id, _data);
                var getHDclick = _loaiCa.getItem(id);
                txtbTenLoaiCa.Text = getHDclick.TENLOAICA;
                spinEditHeSoCa.Text = getHDclick.HESO.Value.ToString();
            }
        }
    }
}