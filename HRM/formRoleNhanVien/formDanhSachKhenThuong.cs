using BusinessLayer;
using BusinessLayer.DTO;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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

namespace HRM.formRoleNhanVien
{
    public partial class formDanhSachKhenThuong : DevExpress.XtraEditors.XtraForm
    {
        public formDanhSachKhenThuong()
        {
            InitializeComponent();
        }
        List<KhenThuong_kyluat_DTO> _ListGridView;
        public List<KhenThuong_kyluat_DTO> getDanhSachGridView()
        {
            _ListGridView = new List<KhenThuong_kyluat_DTO>();

            for (int i = 0; i < gridViewKenThuong.RowCount; i++)
            {
                var DTO_KhenThuong = new KhenThuong_kyluat_DTO
                {
                    STT = i + 1,
                    MANV = gridViewKenThuong.GetRowCellValue(i, "MANV") != DBNull.Value ? Convert.ToInt32(gridViewKenThuong.GetRowCellValue(i, "MANV")) : 000,
                    HOTEN = gridViewKenThuong.GetRowCellValue(i, "HOTEN") != DBNull.Value ? Convert.ToString(gridViewKenThuong.GetRowCellValue(i, "HOTEN")) : "",
                    TenPhongBan = gridViewKenThuong.GetRowCellValue(i, "TenPhongBan") != DBNull.Value ? Convert.ToString(gridViewKenThuong.GetRowCellValue(i, "TenPhongBan")) : string.Empty,
                    LYDO = gridViewKenThuong.GetRowCellValue(i, "LYDO") != DBNull.Value ? Convert.ToString(gridViewKenThuong.GetRowCellValue(i, "LYDO")) : string.Empty,
                    NOIDUNG = gridViewKenThuong.GetRowCellValue(i, "NOIDUNG") != DBNull.Value ? Convert.ToString(gridViewKenThuong.GetRowCellValue(i, "NOIDUNG")) : string.Empty,
                    //LuongHangThang = gridView_NhanVien.GetRowCellValue(i, "LuongHangThang") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "LuongHangThang")) : string.Empty,
                    TUNGAY = gridViewKenThuong.GetRowCellValue(i, "TUNGAY") != DBNull.Value ? Convert.ToDateTime(gridViewKenThuong.GetRowCellValue(i, "TUNGAY")) : DateTime.MinValue,
                };
                _ListGridView.Add(DTO_KhenThuong);
            }

            return _ListGridView;
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportChuyenNhanVien123 rpt = new ReportChuyenNhanVien123(getDanhSachGridView());
            rpt.ShowPreview();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        KhenThuong_KyLuat _khenThuong;
       
        void loadData()
        {
            _khenThuong = new KhenThuong_KyLuat();
            int thang = int.Parse(comboBoxMonth.Text);
            int nam = int.Parse(comboBoxYear.Text);
            lblNam.Text = comboBoxYear.Text;
            lblThang.Text = comboBoxMonth.Text;
            var list = _khenThuong.getListDTO_ROLE_NHANVIEN(1, thang, nam);

            if (list.Any() && Session.User != null)
            {
                int manvDangNhap = Session.User.MANV;
                // Kiểm tra xem list có chứa MANV đăng nhập không
                bool containsManv = list.Any(item => item.MANV == manvDangNhap);
                if (containsManv)
                {
                    // Sắp xếp lại danh sách đưa thông tin của user đăng nhập lên đầu
                    var sortedList = list
                        .OrderByDescending(item => item.MANV == manvDangNhap)
                        .ThenBy(item => item.STT)
                        .ToList();

                    // Gán lại danh sách đã sắp xếp
                    list = sortedList;
                }
            }

            gridControlKhenThuong.DataSource = list;
            gridViewKenThuong.OptionsBehavior.Editable = false;

        }
        private void formDanhSachKhenThuong_Load(object sender, EventArgs e)
        {
            comboBoxYear.Text = DateTime.Now.Year.ToString();
            comboBoxMonth.Text = DateTime.Now.Month.ToString(); 
            loadData();
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadData();
        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadData();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int thang = int.Parse(comboBoxMonth.Text);
            int nam = int.Parse(comboBoxYear.Text);
            lblNam.Text = comboBoxYear.Text;
            lblThang.Text = comboBoxMonth.Text;
            var list = _khenThuong.getListDTO_ROLE_NHANVIEN(1, thang, nam);
            if (list.Count >0)
            {
                gridControlKhenThuong.DataSource = list;
                gridViewKenThuong.OptionsBehavior.Editable = false;
            }
            else
            {
                MessageBox.Show("Không có danh sách trong  tháng " + comboBoxMonth.Text + " năm " + comboBoxYear.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // nếu có tên thì sẽ hiện lên đầu và đổi background
        private void gridViewKenThuong_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            // Kiểm tra cột "MANV"
            if (e.Column.FieldName == "MANV")
            {
                // Lấy giá trị MANV từ ô hiện tại
                int manvCell = Convert.ToInt32(e.CellValue);

                // Kiểm tra xem MANV có phải của user đăng nhập không
                if (Session.User != null && manvCell == Session.User.MANV)
                {
                    // Đặt màu nền và màu chữ
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }
    }
}