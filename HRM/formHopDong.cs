using BusinessLayer;
using Data_Layer;
using DevExpress.XtraEditors;
using HRM.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.Xpo.DB;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraCharts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DevExpress.XtraRichEdit.Import.Html;
using System.Data.SqlClient;
using DevExpress.XtraSplashScreen;

namespace HRM
{
    public partial class formHopDong : DevExpress.XtraEditors.XtraForm
    {
        public formHopDong()
        {
            InitializeComponent();
            showBar(true);

            
        }
       
        NhanVien _nv;
        HopDong hd;
        List<HopDong_DTO> _list_hd_DTO;
        List<HopDong_DTO> _data;
        List<HopDong_DTO> _listhetHopDong;
        NhanVien _nhanVien;
        int _CheckGianHan = 0;
        public bool them;
        int id;
        string MaHD;

        public int _TrangThaihopDong =1;
        int ClicXemListHopDong = 1; // lọc danh sách all
        private void buttonXemdanhsach_Click(object sender, EventArgs e)
        {
            ClicXemListHopDong = 0;
            loadData();   
        }
        public void LoadMucLuong()
        {
            hd = new HopDong();
            var ListLuongCoBan = hd.getListMucLuong();
            List<string> list = new List<string>();
            foreach (var item in ListLuongCoBan)
            {
                list.Add(item.ToString("n0") + " VNĐ");
            }
            comboBoxLuongcoban.DataSource = list;
        }
        private void btnGetAllHopDong_Click(object sender, EventArgs e)
        {
            ClicXemListHopDong = 1;
            loadData();
        }
        Function fct;
       
        void loadData()
        {
            fct = new Function();
            int mainF = fct.checkhethanhopdong;
            //MessageBox.Show("check: "+fct.checkhethanhopdong.ToString());
            hd = new HopDong();
            //fct = new Function();
         
            _data = hd.getListDTO_HopDong();
            if (_TrangThaihopDong == 0)// load toàn bộ
            {
                _listhetHopDong = hd.getListHetHanHopDong();
                gridControlLapHopDong.DataSource = _listhetHopDong;
                btnGiaHanMoi.Visible = false;
                gridViewLapHopDong.OptionsBehavior.Editable = false;
                gridViewLapHopDong.OptionsView.ColumnAutoWidth = true;
                hd.CapNhatTrangThaiHopDong();
                loadNhanVien();
                // load nhân viên để chọn
            }
            else if (ClicXemListHopDong == 0)
            {
                _listhetHopDong = hd.getListHetHanHopDong_a();
                gridControlLapHopDong.DataSource = _listhetHopDong;
                btnGiaHanMoi.Visible = false;
                gridViewLapHopDong.OptionsBehavior.Editable = false;
                gridViewLapHopDong.OptionsView.ColumnAutoWidth = true;
                hd.CapNhatTrangThaiHopDong();
                loadNhanVien(); // load nhân viên để chọn
            }
            else if  (ClicXemListHopDong == 0 && _TrangThaihopDong ==0)
            { 
                _listhetHopDong = hd.getListHetHanHopDong();
                gridControlLapHopDong.DataSource = _listhetHopDong;
                btnGiaHanMoi.Visible = false;
                gridViewLapHopDong.OptionsBehavior.Editable = false;
                gridViewLapHopDong.OptionsView.ColumnAutoWidth = true;
                hd.CapNhatTrangThaiHopDong();
                loadNhanVien(); // load nhân viên để chọn
            }
            else
            {
                gridControlLapHopDong.DataSource = _data;
                btnGiaHanMoi.Visible = false;
                gridViewLapHopDong.OptionsBehavior.Editable = false;
                gridViewLapHopDong.OptionsView.ColumnAutoWidth = true;
                hd.CapNhatTrangThaiHopDong();
                loadNhanVien();
            }
       
            splitContainer2.Visible = true;
            //MessageBox.Show(ListNv_DataGridView[0].HOTEN);
        }
        public void showBar(bool kt)
        {
            barButtonItem4.Enabled = !kt;
            barButtonItem5.Enabled = !kt;
            txtbox_HoTen.Enabled = !kt;
            txtbSoHopDong.Enabled = !kt;
            dateTimePickerNgayKy.Enabled = !kt;
            dateTimePickerNgayBatDau.Enabled = !kt;
            splitContainer1.Panel1Collapsed = true; // là mở lên
            comboBoxThoiHanKy.Enabled= !kt;
            dateTimePickerNgayKetThuc.Enabled = !kt;
            searchLookUpEditTimNhanVien.Enabled = !kt;
            spinEditLanKy.Enabled = !kt;
            spinEditHeSoLuong.Enabled = !kt;
            splitContainer1.Enabled = true;

            richTextBoxHuongDan.Visible = false;
            // thông báo số lượng người hết hợp đồng
            simpleButtonIconThongbao.Visible = false;
            lableThongbao.Visible = false;
            //buttonXemdanhsach.Visible = false;

            barBtn_GiaHanHopDong.Enabled = kt;
            barButtonItem1.Enabled = kt;
            barButtonItem2.Enabled = kt;
            barButtonItem3.Enabled = kt;
            barButtonItem6.Enabled = kt;
            btnClose.Enabled = kt;
        }
        
        void Reset()
        {
            txtbSoHopDong.Text = string.Empty;
            dateTimePickerNgayKy.Value = DateTime.Now;
            dateTimePickerNgayBatDau.Value = DateTime.Now;
            dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(12);

            spinEditLanKy.Text = "0";
            spinEditHeSoLuong.Text = "0";

        }
        int check;
        int fix=0;
        // Thêm
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = true;
            showBar(false);
            Reset();
            splitContainer1.Panel1Collapsed = false; // là mở lên
        }

        void loadNhanVien()
        {
            _nhanVien = new NhanVien();
            searchLookUpEditTimNhanVien.Properties.DataSource = _nhanVien.getDanhSach();
            searchLookUpEditTimNhanVien.Properties.ValueMember= "MANV";
            searchLookUpEditTimNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void formHopDong_Load(object sender, EventArgs e)
        {
            //loadData();
            this.WindowState = FormWindowState.Maximized;

            // Nếu muốn ẩn thanh tiêu đề và viền form
            //this.FormBorderStyle = FormBorderStyle.None;

            // Đặt form luôn luôn ở trên cùng (optional)
            //this.TopMost = true;

            if (splitContainer1.Panel1Collapsed == false && check == 0 ) // thêm lỗi
            {
                splitContainer1.Panel1Collapsed = false;
            }else if(splitContainer1.Panel1Collapsed== false && fix == 0)
            { // sửa lỗi
                splitContainer1.Panel1Collapsed = false;
            }
            else
            {
                splitContainer1.Panel1Collapsed = false;
                dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(12);
                loadData();
                LoadMucLuong();
                them = false;
                showBar(true);

            }

        }

        //Sửa
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = false;
            dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(12);
            showBar(false);
            splitContainer1.Panel1Collapsed = false; // là mở lên
        }

        //Xóa
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int sl = hd.SoLuongHuongDong();
            var x = hd.getItem(id);
            if (x != null)
            {
                if (MessageBox.Show("Bạn muốn xóa hợp đồng có mã " + x.MAHOPDONG + " "+ " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    hd.Xoa(id);
                    loadData();
                    them = true;
                    MessageBox.Show("Xóa thành công");
                }
            }
            else if (sl <= 0)
            {
                MessageBox.Show("Chưa có hợp dồng nào trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Hợp Đồng không tồn tại hoặc đã bị xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void SaveData()
        {
            //MessageBox.Show(id.ToString());
         
            try
            {
                float luongcoban = Function.ConvertToVND(comboBoxLuongcoban.Text);
                if (them)
                {
                    double hsLuong = double.Parse(spinEditHeSoLuong.Value.ToString()) ;
                    decimal lanKy = spinEditLanKy.Value;
                     if (hsLuong <= 0)
                    {
                        MessageBox.Show("Hệ số lương phải lớn hơn", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (lanKy <= 0)
                    {
                        MessageBox.Show("Lần ký phải từ lớn hơn hơn 0 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }

                    else
                    {

                        string currentYearString = DateTime.Now.Year.ToString();

                        // lấy số tháng đc ký
                        DateTime startDate = dateTimePickerNgayBatDau.Value;
                        DateTime endDate = dateTimePickerNgayKetThuc.Value;

                        // Tính tổng số tháng giữa ngày bắt đầu và ngày kết thúc
                        int totalMonths = (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;

                        var mhd = hd.MaHopDong();
                        string[] parts = mhd.Split('_');

                        int old = int.Parse(parts[0]) ;
                        int mahdNew = old + 1;
                        var dt = new Data_Layer.tb_HOPDONG
                        {
                            MAHOPDONG = mahdNew.ToString()+ "_" + currentYearString + "/HĐLĐ",
                            NGAYKY = dateTimePickerNgayKy.Value,
                            NGAYBATDAU = dateTimePickerNgayBatDau.Value,
                            NGAYKETTHUC = dateTimePickerNgayKetThuc.Value,
                            LUONGCOBAN = decimal.Parse(luongcoban.ToString()),
                            LANKY = (int)spinEditLanKy.Value,
                            HESOLUONG = (double)spinEditHeSoLuong.Value,
                            MANV = (int)searchLookUpEditTimNhanVien.EditValue,
                            THOIHANHOPDONG = totalMonths.ToString() + " Tháng",
                            MACTY = 1234,
                            THAMNIEN = totalMonths,  /// Tính theo tháng
                            CREATE_DATE = DateTime.Now,
                            TrangThai = 1,
                        };

                        var checkHD = hd.FindHopDongByMaNV((int)searchLookUpEditTimNhanVien.EditValue);
                        if(checkHD != null)
                        {
                            MessageBox.Show("Hợp đồng của nhân viên này đã được ký", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var result = hd.Them(dt);
                            if (result != null)
                            {
                                check = 1;
                                MessageBox.Show("Đã thêm mới thành công hợp đồng", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                            }
                            else
                            {
                                MessageBox.Show("Có lỗi xảy ra khi thêm hợp đồng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        
                    }

                }
                else
                {

                    txtbSoHopDong.ReadOnly = true;
                    var data = hd.getItem(id);
                    if (_CheckGianHan == 0 && data != null) // chỉnh sửa hợp đồng bình thường
                    {

                        data.MANV = (int)searchLookUpEditTimNhanVien.EditValue;
                        string currentYearString = data.NGAYBATDAU.Value.Year.ToString();
                       
                        data.MAHOPDONG = data.MAHOPDONG;
                        data.NGAYKY = dateTimePickerNgayKy.Value;
                        data.NGAYBATDAU = dateTimePickerNgayBatDau.Value;
                        data.NGAYKETTHUC = dateTimePickerNgayKetThuc.Value;
                        DateTime startDate = dateTimePickerNgayBatDau.Value;
                        DateTime endDate = dateTimePickerNgayKetThuc.Value;

                        data.LANKY = (int)spinEditLanKy.Value;
                        data.HESOLUONG = (double)spinEditHeSoLuong.Value;
                        data.LUONGCOBAN = decimal.Parse(luongcoban.ToString());
                        
                        data.UPDATE_DATE = DateTime.Now;
                        int totalMonths = (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;
                        data.THOIHANHOPDONG = totalMonths.ToString() + " Tháng";
                        data.THAMNIEN = totalMonths;
                        fix = 1;
                        hd.Update(data);
                        MessageBox.Show("Đã cập nhật lại hợp đồng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if(_CheckGianHan ==1 && data != null)// Gia Hạn thêm hợp đồng
                    {
                        txtbSoHopDong.ReadOnly = false;
                        string currentYearString = DateTime.Now.Year.ToString();

                        var mhd = hd.MaHopDong();
                        int old = int.Parse(mhd.Substring(0, 1));
                        int mahdNew = old + 1;
                        data.MAHOPDONG = mahdNew.ToString() + "_" + currentYearString + "/HĐLĐ";
                        data.NGAYKY = dateTimePickerNgayKy.Value;
                        data.NGAYBATDAU = dateTimePickerNgayBatDau.Value;
                        data.NGAYKETTHUC = dateTimePickerNgayKetThuc.Value;
                        data.LANKY = data.LANKY+1;
                        data.HESOLUONG = (float)spinEditHeSoLuong.Value;
                        data.LUONGCOBAN = decimal.Parse(luongcoban.ToString());
                        data.UPDATE_DATE = DateTime.Now;
                        DateTime ngaybatdau = dateTimePickerNgayBatDau.Value;
                        DateTime ngayketthuc = dateTimePickerNgayKetThuc.Value;
                        int tongThangKY = (ngayketthuc.Year - ngaybatdau.Year) * 12 + ngayketthuc.Month - ngaybatdau.Month;
                        data.THOIHANHOPDONG = tongThangKY.ToString() + " Tháng";
                        data.THAMNIEN = data.THAMNIEN + tongThangKY;

                        fix = 1;
                        _CheckGianHan = 0;
                        MessageBox.Show("Đã gia hạn hợp đồng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Hợp đồng để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Lưu
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            SaveData();
            if (them == true && check == 1)
            {
                splitContainer1.Panel1Collapsed = true;
                showBar(true);
                loadData();
                them = false;
            }
            else if (them == true && check == 0)
            {
                showBar(false);
                them = true;

            }
            else if (them == false && fix == 1)
            {
                showBar(true);
                loadData();
            }
            else
            {
                them = false;
            }

        }

        //Hủy
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showBar(true);
            them = false;
            splitContainer1.Panel1Collapsed = true;
            _CheckGianHan = 0;
        }

        //IN
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_list_hd_DTO == null)
            {
                MessageBox.Show("Hãy Click vào nhân viên", "Hướng dẫn");
            }
            else
            {
                ReportHopDongLaoDong rpt = new ReportHopDongLaoDong(_list_hd_DTO);
                rpt.ShowPreview();
            }
            
        }
        List<HopDong_DTO> _ListHopDongGridView;
        public List<HopDong_DTO> getDanhSachGridView()
        {
            _ListHopDongGridView = new List<HopDong_DTO>();

            for (int i = 0; i < gridViewLapHopDong.RowCount; i++)
            {
                var DTO_HOPDONG = new HopDong_DTO
                {
                    STT = i + 1,
                    MAHOPDONG = gridViewLapHopDong.GetRowCellValue(i, "MAHOPDONG") != DBNull.Value ? Convert.ToString(gridViewLapHopDong.GetRowCellValue(i, "MAHOPDONG")) : "",
                    NGAYKY = gridViewLapHopDong.GetRowCellValue(i, "NGAYKY") != DBNull.Value ? Convert.ToDateTime(gridViewLapHopDong.GetRowCellValue(i, "NGAYKY")) : DateTime.MinValue,
                    NGAYBATDAU = gridViewLapHopDong.GetRowCellValue(i, "NGAYBATDAU") != DBNull.Value ? Convert.ToDateTime(gridViewLapHopDong.GetRowCellValue(i, "NGAYBATDAU")) : DateTime.MinValue,
                    NGAYKETTHUC = gridViewLapHopDong.GetRowCellValue(i, "NGAYKETTHUC") != DBNull.Value ? Convert.ToDateTime(gridViewLapHopDong.GetRowCellValue(i, "NGAYKETTHUC")) : DateTime.MinValue,
                    THOIHANHOPDONG = gridViewLapHopDong.GetRowCellValue(i, "THOIHANHOPDONG") != DBNull.Value ? Convert.ToString(gridViewLapHopDong.GetRowCellValue(i, "THOIHANHOPDONG")) : "",
                    LANKY = gridViewLapHopDong.GetRowCellValue(i, "LANKY") != DBNull.Value ? Convert.ToInt32(gridViewLapHopDong.GetRowCellValue(i, "LANKY")) : 0,
                    MANV = gridViewLapHopDong.GetRowCellValue(i, "MANV") != DBNull.Value ? Convert.ToInt32(gridViewLapHopDong.GetRowCellValue(i, "MANV")) : 0000,
                    HESOLUONG = gridViewLapHopDong.GetRowCellValue(i, "HESOLUONG") != DBNull.Value ? Convert.ToInt32(gridViewLapHopDong.GetRowCellValue(i, "HESOLUONG")) : 0000,
                    LuongCoBan = gridViewLapHopDong.GetRowCellValue(i, "LuongCoBan") != DBNull.Value ? Convert.ToString(gridViewLapHopDong.GetRowCellValue(i, "LuongCoBan")) : string.Empty,
                    HOTEN = gridViewLapHopDong.GetRowCellValue(i, "HOTEN") != DBNull.Value ? Convert.ToString(gridViewLapHopDong.GetRowCellValue(i, "HOTEN")) : string.Empty,
                    
                    //LuongHangThang = gridView_NhanVien.GetRowCellValue(i, "LuongHangThang") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "LuongHangThang")) : string.Empty,
                    
                };


                _ListHopDongGridView.Add(DTO_HOPDONG);
            }


            return _ListHopDongGridView;
        }
        // IN TREN LƯỚI
        private void btnPrintLoolList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show(gridViewLapHopDong.GetRowCellValue(0, "HOTENNV");
            ReportListHopDong rpt = new ReportListHopDong(getDanhSachGridView());
            rpt.ShowPreview();
        }

        // Đóng
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

      

        private void btnGiaHanMoi_Click(object sender, EventArgs e)
        {
            richTextBoxHuongDan.Visible = true;
        }

        private void comboBoxThoiHanKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxThoiHanKy.SelectedIndex;
           
            switch (selectedIndex)
            {
                case 0:
                    MessageBox.Show("Bạn đã chọn: 2 Tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(2);
                    break;
                case 1:
                    MessageBox.Show("Bạn đã chọn: 6 Tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(6);
                    break;
                case 2:
                    MessageBox.Show("Bạn đã chọn: 12 Tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(12);
                    break;
                case 3:
                    MessageBox.Show("Bạn đã chọn: 24 Tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(24);
                    break;
                case 4:
                    MessageBox.Show("Bạn đã chọn: 36 Tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(36);
                    break;
                default:
                    MessageBox.Show("Hợp đồng sẽ là 12 tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(12);
                    break;
            }
        }

        LuongCoBan luongCo;
        
        private void gridViewLapHopDong_Click_1(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
            }
            //decimal lcb = luongCo.getLuongCoBan();
            int sl = hd.SoLuongHuongDong();
            if (sl !=0)
            {
                id = Convert.ToInt32(gridViewLapHopDong.GetFocusedRowCellValue("ID").ToString());
                _list_hd_DTO = hd.getHopDongFocus(id, _data);
                var getHDclick = hd.getItem(id);

                txtbSoHopDong.Text = getHDclick.MAHOPDONG;
                dateTimePickerNgayKy.Value = getHDclick.NGAYKY.Value;
                dateTimePickerNgayBatDau.Value = getHDclick.NGAYBATDAU.Value;
                dateTimePickerNgayKetThuc.Value = getHDclick.NGAYKETTHUC.Value;

                spinEditLanKy.Text = getHDclick.LANKY.ToString();
                spinEditHeSoLuong.Text = getHDclick.HESOLUONG.ToString();
                searchLookUpEditTimNhanVien.EditValue = getHDclick.MANV;
            }
        }

        private void barBtn_GiaHanHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            them = false;
            showBar(false);
            splitContainer1.Panel1Collapsed = false;
            _CheckGianHan = 1;
            btnGiaHanMoi.Visible = true;
            spinEditLanKy.ReadOnly = true;
        }

        private void spinEditLanKy_EditValueChanged(object sender, EventArgs e)
        {

        }

        private async void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var waitFormLoad = new WaitFormLoad())
            {
                // Đặt vị trí form chờ ở giữa màn hình
                waitFormLoad.StartPosition = FormStartPosition.CenterScreen;
                waitFormLoad.Show(); // Hiển thị form chờ

                await Task.Run(() =>
                {
                    loadData();
                    them = false;
                    showBar(true);
                });

                waitFormLoad.Close(); // Đóng form chờ sau khi hoàn tất
            }
        }
       
    }
}