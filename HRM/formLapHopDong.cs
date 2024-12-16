using BusinessLayer;
using BusinessLayer.ClassChamCong;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM
{
    public partial class formLapHopDong : DevExpress.XtraEditors.XtraForm
    {
        public formLapHopDong()
        {
            InitializeComponent();
        }
        public int _manv;
        NhanVien _nhanVien;
        PhuCap _phuCap;
        HopDong _hopDong = new HopDong();
        LuongCoBan _luongCoBan;
        int _selectedIDPC = 0;
        int check;

        public void LoadMucLuong()
        {
            var ListLuongCoBan = _hopDong.getListMucLuong();
            List<string> list = new List<string>();
            foreach (var item in ListLuongCoBan)
            {
                list.Add(item.ToString("n0") + " VNĐ");
            }
            comboBoxLuongcoban.DataSource = list;
        }
        private void LoadDataIntoComboBox()
        {
            _phuCap=new PhuCap();
            List<PhuCapInfo> danhSachPhuCap = _phuCap.GetDanhSachPhuCap();

            // Gán danh sách phụ cấp vào ComboBox
            comboBoxPhuCap.DataSource = danhSachPhuCap;
            comboBoxPhuCap.DisplayMember = "TenPhuCap"; // Hiển thị tên phụ cấp trong ComboBox
        }
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void comboBoxPhuCap_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxPhuCap.SelectedItem is PhuCapInfo selectedPhuCap)// để chon combobox nào sẽ lấy ra giá trị binding tương ứng
            {
                _selectedIDPC = selectedPhuCap.IDPC;
                double selectedSoTienPhuCap = double.Parse(selectedPhuCap.SoTienPhuCap.ToString());
                textBoxSoTien.Text = selectedSoTienPhuCap.ToString("N0") + " VNĐ";
            }
        }

        private void comboBoxThoiHanKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxThoiHanKy.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    MessageBox.Show("Hợp Đồng: 2 Tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(2);
                    break;
                case 1:
                    MessageBox.Show("Hợp Đồng: 6 Tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(6);
                    break;
                case 2:
                    MessageBox.Show("Hợp Đồng: 12 Tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(12);
                    break;
                case 3:
                    MessageBox.Show("Hợp Đồng: 24 Tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(24);
                    break;
                case 4:
                    MessageBox.Show("Hợp Đồng: 36 Tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(36);
                    break;
                default:
                    MessageBox.Show("Hợp đồng sẽ là 12 tháng");
                    dateTimePickerNgayKetThuc.Value = dateTimePickerNgayBatDau.Value.AddMonths(12);
                    break;
            }
        }

        // Lưu
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            double hsLuong = double.Parse(spinEditHeSoLuong.Value.ToString());
            float luongcoban = Function.ConvertToVND(comboBoxLuongcoban.Text);
            if (hsLuong <= 0)
            {
                MessageBox.Show("Hệ số lương phải lớn hơn", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                check = 0;
            }
            string currentYearString = DateTime.Now.Year.ToString();

            // lấy số tháng đc ký
            DateTime startDate = dateTimePickerNgayBatDau.Value;
            DateTime endDate = dateTimePickerNgayKetThuc.Value;

            // Tính tổng số tháng giữa ngày bắt đầu và ngày kết thúc
            int totalMonths = (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;

            var mhd = _hopDong.MaHopDong();
            string[] parts = mhd.Split('_');

            int old = int.Parse(parts[0]);
            int mahdNew = old + 1;
            var dt = new Data_Layer.tb_HOPDONG
            {
                MAHOPDONG = mahdNew.ToString() + "_" + currentYearString + "/HĐLĐ",
                NGAYKY = dateTimePickerNgayKy.Value,
                NGAYBATDAU = dateTimePickerNgayBatDau.Value,
                NGAYKETTHUC = dateTimePickerNgayKetThuc.Value,
                LUONGCOBAN = decimal.Parse(luongcoban.ToString()),
                LANKY = (int)spinEditLanKy.Value,
                HESOLUONG = (double)spinEditHeSoLuong.Value,
                MANV =  int.Parse(textBoxMaNv.Text),
                THOIHANHOPDONG = totalMonths.ToString() + " Tháng",
                MACTY = 1234,
                THAMNIEN = totalMonths,  /// Tính theo tháng
                CREATE_DATE = DateTime.Now,
                TrangThai = 1,
            };

            var checkHD = _hopDong.FindHopDongByMaNV(int.Parse(textBoxMaNv.Text));
            if (checkHD != null)
            {
                MessageBox.Show("Hợp đồng của nhân viên này đã được ký", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var result = _hopDong.Them(dt);
                if (result != null)
                {
                    check = 1;
                    // thêm phụ cấp
                    if (textBoxSoTien.Text.Length > 0)
                    {
                        double sotien = Function.ConvertToVND(textBoxSoTien.Text);
                        var data_phucap = new Data_Layer.tb_PHUCAP
                        {
                            MANV = int.Parse(textBoxMaNv.Text),
                            IDPC = _selectedIDPC,
                            TENPC = comboBoxPhuCap.Text,
                            SOTIEN = sotien,
                            NGAY = DateTime.Now,
                            CREATED_DATE = DateTime.Now,
                            CREATED_BY = Session.User.MANV,
                        };

                        var kq = _phuCap.Them(data_phucap);

                    }
                    MessageBox.Show("Đã thêm mới thành công hợp đồng", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm hợp đồng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Hủy
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        // in
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Vào danh mục hợp đồng để xem", "Thông Báo");
        }

        private void formLapHopDong_Load(object sender, EventArgs e)
        {
            _nhanVien = new NhanVien();
            var nv_x = _nhanVien.FindMaNV(_manv);
            textBoxHoten.Text = nv_x.HOTEN.ToString();
            textBoxMaNv.Text = nv_x.MANV.ToString();
            LoadDataIntoComboBox();
            LoadMucLuong();
        }
    }
}