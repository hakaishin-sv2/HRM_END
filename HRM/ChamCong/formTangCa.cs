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
using DevExpress.Utils.Extensions;

namespace HRM.ChamCong
{
    public partial class formTangCa : DevExpress.XtraEditors.XtraForm
    {
        public formTangCa()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
        }
        TangCa _tangCa;
        LoaiCa _loaiCa;
        NhanVien _nhanVien;
        PhongBan _phongBan;
        List<TangCa_DTO> _ListDto_Tangca;
        bool them;
        int id;
        int check;
        int fix = 0;

        void loadData()
        {
            _tangCa = new TangCa();
            _ListDto_Tangca = _tangCa.getListDTO();
            gridControlTangCa.DataSource = _ListDto_Tangca;
            gridViewTangCa.OptionsBehavior.Editable = false;
            LoadComboBoxLoaiCa();
            comboBoxLoaiCa.SelectedIndex = 0;
            spinEditSoGioLam.Text = "3";
        }

        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            spinEditSoGioLam.Enabled = !kt;
            comboBoxLoaiCa.Enabled = !kt;
            TextBoxGhiChu.Enabled = !kt;
            searchLookUpEditTimNhanVien.Enabled = !kt;


            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        void Reset()
        {
            TextBoxGhiChu.Text = string.Empty;
            comboBoxLoaiCa.SelectedValue = 1;
            searchLookUpEditTimNhanVien.Text = string.Empty;
            spinEditSoGioLam.Text = "3";
        }
        void loadNhanVien()
        {
            _nhanVien = new NhanVien();
            searchLookUpEditTimNhanVien.Properties.DataSource = _nhanVien.getListDTO_NhanVien();
            searchLookUpEditTimNhanVien.Properties.ValueMember = "MANV";
            searchLookUpEditTimNhanVien.Properties.DisplayMember = "HOTEN";
            //searchLookUpEditTimNhanVien.Properties.DisplayMember = "TENCV";
        }
        void LoadComboBoxLoaiCa()
        {
            _loaiCa= new LoaiCa();
            comboBoxLoaiCa.DataSource = _loaiCa.getList();
            comboBoxLoaiCa.DisplayMember = "TENLOAICA";
            comboBoxLoaiCa.ValueMember= "IDLOAICA";
        }
        private void formTangCa_Load(object sender, EventArgs e)
        {
            loadData();
            loadNhanVien();
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
            spinEditSoGioLam.Text = "3";
        }

        private void btnFix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = false;
            showBar(false);
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int sl = _tangCa.SoLuong();
            var x = _tangCa.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa Nhân viên tăng ca này  không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _tangCa.Xoa(id);
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
            _loaiCa = new LoaiCa();
            var itemLoaica = _loaiCa.getItem((int)comboBoxLoaiCa.SelectedValue);
            float sotien = 0;
            if (spinEditSoGioLam.EditValue != null && itemLoaica != null)
            {
                float soGioLam = Convert.ToSingle(spinEditSoGioLam.EditValue); // Chuyển đổi sang float
                float heSo = Convert.ToSingle(itemLoaica.HESO); // Chuyển đổi sang float

                sotien = soGioLam * heSo * 50000;
            }
            try
            {
                if (them)
                {
                    var value = Convert.ToInt32(searchLookUpEditTimNhanVien.EditValue);
                    if (value == 0)
                    {
                        MessageBox.Show("Bạn cần chọn Nhân Viên Cho Phụ Cấp", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else
                    {
                        var dt = new Data_Layer.tb_TANGCA
                        {
                            MANV = searchLookUpEditTimNhanVien.EditValue != null ? (int)searchLookUpEditTimNhanVien.EditValue : 0,
                            IDLOAICA = comboBoxLoaiCa.SelectedValue != null ? (int)comboBoxLoaiCa.SelectedValue : 0,
                            NGAYTANGCA = DateTime.Now.Day,
                            THANG = DateTime.Now.Month,
                            NAM = DateTime.Now.Year,
                            SOGIO = spinEditSoGioLam.EditValue != null ? Convert.ToDouble(spinEditSoGioLam.EditValue) : 0.0,
                            SOTIEN = sotien,
                            GHICHU = TextBoxGhiChu.Text.Trim(),
                            CREATED_DATE = DateTime.Now,
                            DATE_TANGCA= DateTime.Now,
                            //CREATE_BY = UserControl.ID,
                        };
                        var result = _tangCa.Them(dt);
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
                    var data = _tangCa.getItem(id);
                    if (data != null)
                    {
                        data.MANV = (int)searchLookUpEditTimNhanVien.EditValue;
                        data.IDLOAICA = (int)comboBoxLoaiCa.SelectedValue;
                        data.NGAYTANGCA = DateTime.Now.Day;
                        data.THANG = DateTime.Now.Month;
                        data.NAM = DateTime.Now.Year;
                        data.SOGIO = spinEditSoGioLam.EditValue != null ? Convert.ToDouble(spinEditSoGioLam.EditValue) : 0.0;
                        data.SOTIEN = sotien;
                        data.GHICHU = TextBoxGhiChu.Text.Trim();
                        data.DATE_TANGCA = DateTime.Now;
                        fix = 1;
                        _tangCa.Update(data);
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

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridViewTangCa_Click(object sender, EventArgs e)
        {
            if (gridViewTangCa.RowCount > 0)
            {
                if (splitContainer1.Panel1Collapsed == true)
                {
                    splitContainer1.Panel1Collapsed = false;
                }
                id = Convert.ToInt32(gridViewTangCa.GetFocusedRowCellValue("ID").ToString());
                //_tangCa = new TangCa();
                var getHDclick = _tangCa.getItem(id);
                searchLookUpEditTimNhanVien.EditValue = getHDclick.MANV;
                comboBoxLoaiCa.SelectedValue = getHDclick.IDLOAICA;
                spinEditSoGioLam.Text = getHDclick.SOGIO.ToString();
                TextBoxGhiChu.Text = getHDclick.GHICHU;
            }
        }
    }
}