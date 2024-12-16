using BusinessLayer;
using BusinessLayer.ClassChamCong;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
    public partial class formBangCong : DevExpress.XtraEditors.XtraForm
    {
        public formBangCong()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
        }
        BangCong _bangCong;
        bool them;
        int id;
        int check;
        int fix = 0;

        void loadData()
        {
            _bangCong = new BangCong();
            var list = _bangCong.getListDTO();
            gridControBanGcong.DataSource = list;
            gridViewBangCong.OptionsBehavior.Editable = false;
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            comboBoxYear.Enabled = !kt;
            comboBoxMonth.Enabled = !kt;


            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        void Reset()
        {
            //comboBoxMo.Text = "Chọn Tháng";
            //comboBoxYear.Text = "Chọn Năm";
            checkBoxKhoa.Checked = false;
            checkBoxTrangThai.Checked = false;
        }
        private void formBangCong_Load(object sender, EventArgs e)
        {
            loadData();
            comboBoxYear.Text = DateTime.Now.Year.ToString();
            comboBoxMonth.Text = DateTime.Now.Month.ToString();
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
            checkBoxKhoa.Checked = false;
            checkBoxTrangThai.Checked = false;
        }

        private void btnFix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = false;
            showBar(false);
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int sl = _bangCong.getCountSoLuong();
            var x = _bangCong.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa kỳ công có mã " + x.MAKYCONG + " " + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _bangCong.Xoa(id);
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
                MessageBox.Show("Bạn cần clik vào kỳ công rồi ấn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void SaveData()
        {
            int khoa =0; ;
            int  trangthai = 0;
           
            try
            {
                if (them)
                {
                    if (_bangCong.CheckTonTai(comboBoxYear.Text.ToString() + "_T" + comboBoxMonth.Text) == true)
                    {
                        MessageBox.Show("Mã kỳ công đã tồn tại", "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var dt = new Data_Layer.tb_KYCONG
                        {
                            MAKYCONG = comboBoxYear.Text.ToString() + "_T" + comboBoxMonth.Text,
                            THANG = int.Parse(comboBoxMonth.Text),
                            NAM = int.Parse(comboBoxYear.Text),
                            KHOA = khoa,
                            TRANGTHAI = trangthai,
                            NGAYCONGTRONTHANG = Function.demSoNgayLamTrongThang(int.Parse(comboBoxYear.Text), int.Parse(comboBoxMonth.Text)),
                            NGAYTINHCONG = DateTime.Now,
                            CREATED_DATE = DateTime.Now,
                        };

                        var result = _bangCong.Them(dt);
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
                    var data = _bangCong.getItem(id);
                    if (data != null)
                    {
                        data.THANG = int.Parse(comboBoxMonth.Text);
                        data.NAM = int.Parse(comboBoxYear.Text);
                        data.NGAYCONGTRONTHANG = Function.demSoNgayLamTrongThang(int.Parse(comboBoxYear.Text), int.Parse(comboBoxMonth.Text));
                        data.KHOA = khoa;
                        data.TRANGTHAI = trangthai;
                        data.NGAYTINHCONG=DateTime.Now;
                        fix = 1;
                        _bangCong.Update(data);
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

        public string _maKyCong_bc;
        int namFrmbc;
        int thangFrmbc;
        int KHOAfrmBC;
        int TRANGTHAIfrmBC;
        private void gridViewBangCong_Click(object sender, EventArgs e)
        {
            if(gridViewBangCong.RowCount>0)
            {
                if (splitContainer1.Panel1Collapsed == true)
                {
                    splitContainer1.Panel1Collapsed = false;
                }
                //decimal lcb = luongCo.getLuongCoBan();
              
                id = Convert.ToInt32(gridViewBangCong.GetFocusedRowCellValue("ID").ToString());
                _maKyCong_bc = gridViewBangCong.GetFocusedRowCellValue("MAKYCONG").ToString();
                //_list_hd_DTO = hd.getHopDongFocus(id, _data);
                var getHDclick = _bangCong.getItemByMaKyCong(_maKyCong_bc);
                KHOAfrmBC = (int)getHDclick.KHOA;
                TRANGTHAIfrmBC = (int)getHDclick.TRANGTHAI;
                namFrmbc= (int)gridViewBangCong.GetFocusedRowCellValue("NAM");
                thangFrmbc= (int)gridViewBangCong.GetFocusedRowCellValue("THANG");
                
                comboBoxMonth.Text =getHDclick.THANG.ToString();
                comboBoxYear.Text = getHDclick.NAM.ToString();

                if (gridViewBangCong.GetFocusedRowCellValue("KhoaChua").ToString()== "Đã khóa")
                {
                    checkBoxKhoa.Checked = true;      
                }
                else
                {
                    checkBoxKhoa.Checked = false;
                }
                if(gridViewBangCong.GetFocusedRowCellValue("TenTrangThai").ToString() == "Đã phát sinh")
                {
                    checkBoxTrangThai.Checked = true;
                }
                else
                {
                    checkBoxTrangThai.Checked = false;
                }
                
            }
        }

       
        private void btnXemBangCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewBangCong.RowCount == 0)
            {
                MessageBox.Show("Bạn cần click vào kỳ công muỗn xem", "Hướng dẫn", MessageBoxButtons.OK);
            }
            else if(_maKyCong_bc == null || _maKyCong_bc == "" || namFrmbc ==0 || thangFrmbc==0)
            {
                MessageBox.Show("Bạn cần click vào kỳ công muỗn xem", "Hướng dẫn", MessageBoxButtons.OK) ;
            }
            else
            {
                // ép form nhỏ vào form chính

                // Lấy form chính
                MainForm frmMain = (MainForm)this.MdiParent;

                // Khởi tạo và thiết lập form chi tiết
                formBangCongChiTiet frmBCCT = new formBangCongChiTiet();
                frmBCCT._maKyCong = _maKyCong_bc;
                frmBCCT._nam = namFrmbc;
                frmBCCT._thang = thangFrmbc;
                // Thiết lập form cha và hiển thị
                frmBCCT.MdiParent = frmMain;
                
                frmBCCT.Show();

               
            }
            
        }
    }
}