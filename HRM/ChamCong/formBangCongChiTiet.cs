using BusinessLayer;
using BusinessLayer.ClassChamCong;
using Data_Layer;
using DevExpress.Office.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using HRM.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM.ChamCong
{
    public partial class formBangCongChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public formBangCongChiTiet()
        {
            InitializeComponent();
            //splitContainer1.Panel1Collapsed = true;
            this.AutoScroll = true;

        }
        KyCongChiTiet _kcchiTiet;
        NhanVien nhanVien;
        BangCongChiTietNhanVien _bangCongChiTiet;
        BangCong _bc;
        public string _maKyCong;
        public int _nam;
        public int _thang;
        public int _id;
        public int _KHOA;
        public int _TRANGTHAI;
        public string _dayClick;

        public void loadBangCong()
        {


            string mkc = comboBoxYear.Text + "_T" + comboBoxMonth.Text;
            _kcchiTiet = new KyCongChiTiet();
            var result = _kcchiTiet.CheckPhatSinhKyCong(int.Parse(comboBoxYear.Text),int.Parse(comboBoxMonth.Text));
            if (result == null)
            {
                MessageBox.Show("Kỳ công tháng: " + comboBoxMonth.Text + " Năm: " + comboBoxYear.Text + "Chưa được phát sinh", "Hướng dẫn", MessageBoxButtons.OK);
            }
            else
            {
              
               gcBangCongChiTiet.DataSource = _kcchiTiet.getListDTO(int.Parse(comboBoxYear.Text), int.Parse(comboBoxMonth.Text));
                CustomView(int.Parse(comboBoxMonth.Text), int.Parse(comboBoxYear.Text));
                DessignView();
                // GridView hiển thị thanh cuộn
                gvBangCongChiTiet.OptionsView.ColumnAutoWidth = false; // Tắt tự động điều chỉnh cột để hiển thị thanh cuộn ngang
                gvBangCongChiTiet.BestFitColumns(); // Tự động điều chỉnh kích thước các cột để vừa với nội dung
                
            }

        }

        private void formBangCongChiTiet_Load(object sender, EventArgs e)
        {    
            this.FormBorderStyle = FormBorderStyle.None;
            DessignView();
            comboBoxYear.Text = _nam.ToString();
            comboBoxMonth.Text = _thang.ToString();
            labelMonth.Text = comboBoxMonth.Text.ToString();
            labelYear.Text = comboBoxYear.Text.ToString();
            _kcchiTiet = new KyCongChiTiet();
            gcBangCongChiTiet.DataSource = _kcchiTiet.getListDTO(int.Parse(comboBoxYear.Text), int.Parse(comboBoxMonth.Text));
            CustomView(_thang, _nam);
            loadBangCong();
            // Gán ContextMenuStrip
            gcBangCongChiTiet.ContextMenuStrip = contextMenuStrip1;
            
        }

        private void btnPhatsinhKycong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            string mkc = comboBoxYear.Text + "_T" + comboBoxMonth.Text;
            _bc = new BangCong();
            if (_kcchiTiet.CheckPhatSinhKyCong(int.Parse(comboBoxYear.Text), int.Parse(comboBoxMonth.Text)) == true)
            {
                MessageBox.Show("Kỳ công này đã được phát sinh rồi  không thể phát sinh nữa hãy ấn chọn xem bảng công", "Hướng dẫn", MessageBoxButtons.OK);
            }
            else if (_maKyCong == null || _maKyCong == "")
            {
                MessageBox.Show("Bạn cấn lick chọn vào kỳ công để xem", "Hướng dẫn", MessageBoxButtons.OK);
            }
            else if (_bc.getItemByMaKyCong(mkc) == null)
            {
                DialogResult result = MessageBox.Show(" Bạn cần hãy tạo kỳ công tháng: " + comboBoxMonth.Text + " của năm Chọn YES để tự động tạo" + comboBoxYear.Text, "Hướng dẫn", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    var dt = new Data_Layer.tb_KYCONG
                    {
                        MAKYCONG = comboBoxYear.Text.ToString() + "_T" + comboBoxMonth.Text,
                        THANG = int.Parse(comboBoxMonth.Text),
                        NAM = int.Parse(comboBoxYear.Text),
                        KHOA = 0,
                        TRANGTHAI = 0,
                        NGAYCONGTRONTHANG = Function.demSoNgayLamTrongThang(int.Parse(comboBoxYear.Text), int.Parse(comboBoxMonth.Text)),
                        NGAYTINHCONG = DateTime.Now,
                        CREATED_DATE = DateTime.Now,
                    };
                    _bc.Them(dt);
                    MessageBox.Show("Bạn hãy chọn lại để nút PHát sinh bảng công để phát sinh", "Hướng dẫn", MessageBoxButtons.OK);
                }

            }
            else
            {
                SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
                _kcchiTiet.phatSinhKyCongChiTiet(int.Parse(comboBoxMonth.Text), int.Parse(comboBoxYear.Text));
                CustomView(int.Parse(comboBoxMonth.Text), int.Parse(comboBoxYear.Text));


                //_bc = new BangCong();
                var bangcong_x = _bc.getItemByMaKyCong(mkc);
                bangcong_x.TRANGTHAI = 1;
                _bc.Update(bangcong_x);
                SplashScreenManager.CloseForm();
                loadBangCong();
            }

            nhanVien = new NhanVien();
            List<NhanVien_DTO> listNV = nhanVien.getListDTO_NhanVien();
            foreach (var item in listNV)
            {
                for (int i = 1; i <= GetDayNumber(int.Parse(comboBoxMonth.Text), int.Parse(comboBoxYear.Text)); i++)
                {
                    string dayinweek = Function.layThu(int.Parse(comboBoxYear.Text), int.Parse(comboBoxMonth.Text), i);
                    int ngaycong =1;
                    if(dayinweek == "Chủ Nhật")
                    {
                        ngaycong = 0;
                    }
                    _bangCongChiTiet = new BangCongChiTietNhanVien();
                    var dt = new Data_Layer.tb_BANGCONG_CHITIET
                    {
                        MAKYCONG = comboBoxYear.Text.ToString() + "_T" + comboBoxMonth.Text,
                        MANV = item.MANV,
                        HOTEN = item.HOTEN,
                        GIOVAO = "08:00",
                        GIORA = "17:00",
                        NGAYCONGTRONGNGAY= ngaycong,
                        NGAY = DateTime.Parse(comboBoxYear.Text + "-" + comboBoxMonth.Text + "-" + i.ToString()),
                        THU = Function.layThu(int.Parse(comboBoxYear.Text), int.Parse(comboBoxMonth.Text), i),
                        CREATED_DATE = DateTime.Now,
                        NGAYPHEP = 0,
                        CONGCHUNHAT = 0,
                        CONGNGAYLE = 0,
                        KYHIEU = "X",
                    };
                    _bangCongChiTiet.Add(dt);
                }
            }


        }
        private int GetDayNumber(int thang, int nam)
        {
            int dayNumber = 0;
            switch (thang)
            {
                case 2:
                    dayNumber = (nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0 ? 29 : 28;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    dayNumber = 30;
                    break;

                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dayNumber = 31;
                    break;
            }

            return dayNumber;
        }
     
        void DessignView()
        {
            foreach (GridColumn column in gvBangCongChiTiet.Columns)
            {
                column.BestFit();
            }
        }


        private void CustomView(int thang, int nam)
        {
            gvBangCongChiTiet.RestoreLayoutFromXml("BangCong_Layout.xml");

            int i;
            foreach (GridColumn gridColumn in gvBangCongChiTiet.Columns)
            {
                if (gridColumn.FieldName == "HOTEN") continue;

                // Sử dụng một đối tượng RepositoryItemTextEdit không cho phép chỉnh sửa
                RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit
                {
                    ReadOnly = true // Đặt thành ReadOnly
                };

                gridColumn.ColumnEdit = textEdit;
            }

            for (i = 1; i <= GetDayNumber(thang, nam); i++)
            {

                DateTime newDate = new DateTime(nam, thang, i);

                GridColumn column = new GridColumn();
                column.Width = 100;
                column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
                string fieldName = "Day" + i;

                switch (newDate.DayOfWeek.ToString())
                {

                    case "Monday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Hai " + i.ToString();
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        column.Width = 100;
                        column.AppearanceHeader.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        column.OptionsColumn.AllowFocus = false;
                        break;

                    case "Tuesday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Ba " + i.ToString();
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        column.AppearanceHeader.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        column.Width = 100;
                        column.OptionsColumn.AllowFocus = false;


                        break;

                    case "Wednesday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Tư " + i.ToString();
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        column.AppearanceHeader.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        column.Width = 100;
                        column.OptionsColumn.AllowFocus = false;
                        break;
                    case "Thursday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Năm " + i.ToString();
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        column.AppearanceHeader.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        column.Width = 100;
                        column.OptionsColumn.AllowFocus = false;
                        break;
                    case "Friday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Sáu " + i.ToString();
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        column.AppearanceHeader.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        column.Width = 100;
                        column.OptionsColumn.AllowFocus = false;
                        break;
                    case "Saturday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Bảy " + i.ToString();
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Red;
                        column.AppearanceHeader.BackColor = Color.Violet;
                        column.AppearanceHeader.BackColor2 = Color.Violet;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Khaki;
                        column.OptionsColumn.AllowFocus = true;
                        column.AppearanceHeader.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        column.Width = 100;
                        break;
                    case "Sunday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "CN " + i.ToString();
                        column.OptionsColumn.AllowEdit = false;
                        column.AppearanceHeader.ForeColor = Color.Red;
                        column.AppearanceHeader.BackColor = Color.GreenYellow;
                        column.AppearanceHeader.BackColor2 = Color.GreenYellow;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Orange;
                        column.AppearanceHeader.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        column.Width = 100;
                        column.OptionsColumn.AllowFocus = false;
                        break;
                }
            }

            // Ẩn các cột thừa (ngày 31 trở lên)
            for (int j = GetDayNumber(thang, nam) + 1; j <= 31; j++)
            {
                string fieldName = "Day" + j;
                GridColumn column = gvBangCongChiTiet.Columns[fieldName];
                if (column != null)
                {
                    column.Visible = false;
                }
            }
        }
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadBangCong();
           
          
            labelMonth.Text = comboBoxMonth.Text.ToString();
            labelYear.Text = comboBoxYear.Text.ToString();
          
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        // In
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ReportBangCongThang rpt = new ReportBangCongThang();    
            rpt.ShowPreviewDialog();


        }

        private void gcBangCongChiTiet_Click(object sender, EventArgs e)
        {

        }


        private void btnXemBangCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
            loadBangCong();
            labelMonth.Text = comboBoxMonth.Text.ToString();
            labelYear.Text = comboBoxYear.Text.ToString();
            SplashScreenManager.CloseForm();
        }

      
        private void gvBangCongChiTiet_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.CellValue == null)
            {

            }
            else
            {
                if (e.CellValue.ToString() == "V")
                {
                    e.Appearance.BackColor= Color.IndianRed;
                    e.Appearance.ForeColor= Color.White;
                }
                if (e.CellValue.ToString() == "LCN")
                {
                    e.Appearance.BackColor = Color.Aquamarine;
                    e.Appearance.ForeColor = Color.Black;
                }
                if (e.CellValue.ToString() == "P")
                {
                    e.Appearance.BackColor = Color.LightBlue;
                   
                }
                if (e.CellValue.ToString() == "VCN")
                {
                    e.Appearance.BackColor = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }
        private void contexxtMenuCapNhatNgayCong_Click(object sender, EventArgs e)
        {
            formCapNhatNgayCong frm = new formCapNhatNgayCong();
            frm._MaNv = int.Parse(gvBangCongChiTiet.GetFocusedRowCellValue("MANV").ToString());
            frm._HoTen = gvBangCongChiTiet.GetFocusedRowCellValue("HOTEN").ToString();
            frm._MaKC = gvBangCongChiTiet.GetFocusedRowCellValue("MAKYCONG").ToString();
            frm._Ngay = _dayClick;
            MessageBox.Show("Cập nhật ngày công thứ: " + _dayClick);


            frm._PhongBan = gvBangCongChiTiet.GetFocusedRowCellValue("TENPB").ToString();
            frm.ShowDialog();
        }

        private void SomeOtherMethod()
        {
            // Nếu cần gọi hàm contexxtMenuCapNhatNgayCong_Click từ một nơi khác
            contexxtMenuCapNhatNgayCong_Click(null, EventArgs.Empty);
        }

        private void gcBangCongChiTiet_MouseDown(object sender, MouseEventArgs e)
        {
            // Kiểm tra nút chuột và chắc chắn là nhấp chuột trái
            if (e.Button == MouseButtons.Left)
            {
                var hitInfo = gvBangCongChiTiet.CalcHitInfo(e.Location);

                // Kiểm tra xem hitInfo có chứa cột không
                if (hitInfo.Column != null)
                {
                    string fieldName = hitInfo.Column.FieldName;

                    if (fieldName.Contains("Day"))
                    {
                        _dayClick = fieldName;
                        contexxtMenuCapNhatNgayCong_Click(sender, e);
                    }
                        

                }
            }
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
            loadBangCong();
            labelMonth.Text = comboBoxMonth.Text.ToString();
            labelYear.Text = comboBoxYear.Text.ToString();
            SplashScreenManager.CloseForm();
            */
        }
    }
}