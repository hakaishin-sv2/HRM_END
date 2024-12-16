using Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System.Configuration;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class Function
    {
        public int checkhethanhopdong { get; set; }
       

        public static int getCheck(int x)
        {
            return x;
        }

        // Hàm kiểm tra định dạng số tiền
        public static bool IsValidCurrencyFormat(string vndText)
        {
            if (string.IsNullOrWhiteSpace(vndText))
                return false;

            string pattern = @"^\d{1,3}(,\d{3})* VNĐ$";
            return Regex.IsMatch(vndText, pattern);
        }

        // formart textbox khi nhập về dạng tiền ví dụ 500,000 VNĐ khi textchange

        public static void formatTextToVND(TextBox nameTextBox)
        {
            // Lưu lại vị trí con trỏ trước khi thay đổi văn bản
            int cursorPosition = nameTextBox.SelectionStart;

            // Loại bỏ dấu phân cách hàng nghìn và chuỗi " VNĐ" nếu có
            string input = nameTextBox.Text.Replace(",", "").Replace(" VNĐ", "").Trim();

            // Chuyển đổi thành số nguyên (hoặc số thực nếu cần)
            if (decimal.TryParse(input, out decimal value))
            {
                // Định dạng lại số tiền với dấu phân cách hàng nghìn và thêm " VNĐ"
                nameTextBox.Text = value.ToString("N0") + " VNĐ";

                // Đặt lại vị trí con trỏ sau khi định dạng lại văn bản
                nameTextBox.SelectionStart = Math.Min(cursorPosition, nameTextBox.Text.Length - " VNĐ".Length);
            }
        }

      
        public static float ConvertToVND(string vndText)
        {
            if (string.IsNullOrWhiteSpace(vndText))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }
            string sanitized = vndText.Replace(" VNĐ", "").Trim();
            sanitized = sanitized.Replace(",", "");
            // Chuyển đổi chuỗi thành số float
            if (float.TryParse(sanitized, out float result))
            {
                return result;
            }
            else
            {
                throw new FormatException("Input string is not in the correct format.");
            }
        }

        // Đếm số ngày làm việc trong tháng 
        public static int demSoNgayLamTrongThang(int nam, int thang)
        {
            int dem = 0;
            DateTime ngayDauTien = new DateTime(nam, thang, 1);
            DateTime ngayCuoiCung = ngayDauTien.AddMonths(1).AddDays(-1);  // Lấy ngày cuối cùng của tháng

            for (DateTime ngay = ngayDauTien; ngay <= ngayCuoiCung; ngay = ngay.AddDays(1))
            {
                if (ngay.DayOfWeek != DayOfWeek.Sunday)  // Trừ Chủ Nhật
                {
                    dem++;
                }
            }
            return dem;
        }

        // Lấy số ngày của tháng cho form chấm công
        public static int laySoNgayCuaThang(int nam, int thang)
        {
            return DateTime.DaysInMonth(nam, thang);
        }
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);

        // Hàm kiểm tra email hợp lệ
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public static string layThu(int nam, int thang, int ngay)
        {
            string thu = "";
            DateTime date;
            if (DateTime.TryParse($"{nam}-{thang}-{ngay}", out date))
            {
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        thu = "Chủ Nhật";
                        break;
                    case DayOfWeek.Monday:
                        thu = "Thứ Hai";
                        break;
                    case DayOfWeek.Tuesday:
                        thu = "Thứ Ba";
                        break;
                    case DayOfWeek.Wednesday:
                        thu = "Thứ Tư";
                        break;
                    case DayOfWeek.Thursday:
                        thu = "Thứ Năm";
                        break;
                    case DayOfWeek.Friday:
                        thu = "Thứ Sáu";
                        break;
                    case DayOfWeek.Saturday:
                        thu = "Thứ Bảy";
                        break;
                    default:
                        thu = "Không xác định";
                        break;
                }
            }
            else
            {
                thu = "Ngày không hợp lệ";
            }

            return thu;
        }


        // Hàm kiểm tra số điện thoại hợp lệ
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy kiểm tra số điện thoại bắt đầu bằng 0 và có 10 ký tự số
            string pattern = @"^0\d{9}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }

     
        public static bool IsNumeric(string input)
        {
            return double.TryParse(input, out _);
        }


        // kết nối thủ công database

        static string connectionString = "Data Source=DESKTOP-U0JHR1S\\SQLEXPRESS;Initial Catalog=HRM;Integrated Security=True";

        static SqlConnection conn = new SqlConnection(connectionString);

        // Hàm mở kết nối
        public static void taoKetNoi()
        {
            try
            {
                conn.Open();
                Console.WriteLine("Kết nối đến cơ sở dữ liệu thành công!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi kết nối đến cơ sở dữ liệu: " + e.Message);
                throw;
            }
        }


        public static void dongKetNoi()
        {
            conn.Close();
        }

        public static DataTable getData(string sql)
        {
            taoKetNoi();
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(tb);
            dongKetNoi();
            return tb;
        }

        public static DataSet DataSet(string sql)
        {
            taoKetNoi();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);  
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataSet dts = new DataSet();
            da.Fill(dts);
            dongKetNoi();
            return dts;
        }

        // insert update
        public static  void excuQuery(string sql)
        {
            taoKetNoi();
            SqlCommand cmd = new SqlCommand(sql,conn);
            cmd.CommandType= CommandType.Text;  
            cmd.ExecuteNonQuery();
            dongKetNoi();
        }
    }
}
