using BusinessLayer;
using BusinessLayer.ClassChamCong;
using BusinessLayer.Convert_DTO;
using DevExpress.Diagram.Core.Themes;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using HRM.Report;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HRM.ChamCong
{
    public partial class formBangLuong : DevExpress.XtraEditors.XtraForm
    {
        public formBangLuong()
        {
            InitializeComponent();
        }
        TinhLuong _tinhLuong;
        List<TinhluongDTO> _tinhLuongList;
        void loadMaKyCong()
        {
            _tinhLuong = new TinhLuong();
            comboBoxMaKyCong.DataSource = _tinhLuong.GetMaKyCongList();
        }

        void LoadData()
        {
            _tinhLuong = new TinhLuong();
            _tinhLuongList = _tinhLuong.GetBangTinhluongDTOs(comboBoxMaKyCong.Text);
            if (_tinhLuongList == null || _tinhLuongList.Count == 0)
            {
               // MessageBox.Show("KỲ công này chưa được tính lương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                gridControBangLuong.DataSource = _tinhLuongList;
                gridViewBangLuong.OptionsBehavior.Editable = false;
            }
            
        }
        private async void formBangLuong_Load(object sender, EventArgs e)
        {
           
            loadMaKyCong();
            LoadData();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnTinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(_tinhLuong.checkTinhLuongchua(comboBoxMaKyCong.Text) == true)
            {
               DialogResult result = MessageBox.Show("Mã kỳ công đã được tính! Nếu muốn tính lại Nhấn nút YES", " Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
               
               if (result == DialogResult.Yes)
                {
                    string makycong = comboBoxMaKyCong.Text;
                    string sql = "DELETE FROM tb_BANGLUONG WHERE MAKYCONG = '" + makycong + "'";
                    Function.excuQuery(sql);
                    
                   // SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
                    _tinhLuong.TinhLuongNhanVien(comboBoxMaKyCong.Text);
                    LoadData();
                   // SplashScreenManager.CloseForm();
                }

            }
            else
            {
                //SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
                _tinhLuong.TinhLuongNhanVien(comboBoxMaKyCong.Text);
                LoadData();
                //SplashScreenManager.CloseForm();
            }
            
        }

        private void btnXemBangLuong_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
            LoadData();
            SplashScreenManager.CloseForm();
        }



        private async void comboBoxMaKyCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var waitFormLoad = new WaitFormLoad())
            {
                // Đặt vị trí form chờ ở giữa màn hình
                waitFormLoad.StartPosition = FormStartPosition.CenterScreen;
                waitFormLoad.Show(); // Hiển thị form chờ

                await Task.Run(() =>
                {
                    LoadData(); // Gọi phương thức để load dữ liệu
                });

                waitFormLoad.Close(); // Đóng form chờ sau khi hoàn tất
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportPhieuLuongNhanVien rpt = new ReportPhieuLuongNhanVien(_tinhLuongList);
            rpt.ShowPreviewDialog();
        }


        List<TinhluongDTO> _LisDataGridView;
        public List<TinhluongDTO> getDanhSachGridView()
        {
            _LisDataGridView = new List<TinhluongDTO>();

            for (int i = 0; i < gridViewBangLuong.RowCount; i++)
            {
                var DTO_HOPDONG = new TinhluongDTO
                {
                    STT = i + 1,
                    MANV = gridViewBangLuong.GetRowCellValue(i, "MANV") != DBNull.Value ? Convert.ToInt32(gridViewBangLuong.GetRowCellValue(i, "MANV")) : 0000,
                    HOTEN = gridViewBangLuong.GetRowCellValue(i, "HOTEN") != DBNull.Value ? Convert.ToString(gridViewBangLuong.GetRowCellValue(i, "HOTEN")) : string.Empty,
                    TENPB = gridViewBangLuong.GetRowCellValue(i, "TENPB") != DBNull.Value ? Convert.ToString(gridViewBangLuong.GetRowCellValue(i, "TENPB")) : string.Empty,
                    MAKYCONG = gridViewBangLuong.GetRowCellValue(i, "MAKYCONG") != DBNull.Value ? Convert.ToString(gridViewBangLuong.GetRowCellValue(i, "MAKYCONG")) : "",
                    NGAYCONGTRONGTHANG = gridViewBangLuong.GetRowCellValue(i, "NGAYCONGTRONGTHANG") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "NGAYCONGTRONGTHANG")) : 0.0,
                    LUONGNGAYTHUONG = gridViewBangLuong.GetRowCellValue(i, "LUONGNGAYTHUONG") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "LUONGNGAYTHUONG")) : 0.0,
                    LUONGNGAYPHEP = gridViewBangLuong.GetRowCellValue(i, "LUONGNGAYPHEP") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "LUONGNGAYPHEP")) : 0.0,
                    LUONGNGAYCHUNHAT = gridViewBangLuong.GetRowCellValue(i, "LUONGNGAYCHUNHAT") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "LUONGNGAYCHUNHAT")) : 0,
                    LUONGTANGCA = gridViewBangLuong.GetRowCellValue(i, "LUONGTANGCA") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "LUONGTANGCA")) : 0,
                    PHUCAP = gridViewBangLuong.GetRowCellValue(i, "PHUCAP") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "PHUCAP")) : 0,
                    UNGLUONG = gridViewBangLuong.GetRowCellValue(i, "UNGLUONG") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "UNGLUONG")) : 0,
                    SOTIENKHENTHUONG = gridViewBangLuong.GetRowCellValue(i, "SOTIENKHENTHUONG") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "SOTIENKHENTHUONG")) : 0,
                    SOTIENKYLUAT = gridViewBangLuong.GetRowCellValue(i, "SOTIENKYLUAT") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "SOTIENKYLUAT")) : 0,
                    LUONGTHUCLANH = gridViewBangLuong.GetRowCellValue(i, "LUONGTHUCLANH") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "LUONGTHUCLANH")) : 0,
                    //UNGLUONG = gridViewBangLuong.GetRowCellValue(i, "UNGLUONG") != DBNull.Value ? Convert.ToDouble(gridViewBangLuong.GetRowCellValue(i, "UNGLUONG")) : 0,
                };


                _LisDataGridView.Add(DTO_HOPDONG);
            }


            return _LisDataGridView;
        }
        private void btnPrintfilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RePortGridViewFilterBangLuong rpt = new RePortGridViewFilterBangLuong(getDanhSachGridView());
            rpt.ShowPreviewDialog();
        }
        /*
        private void btn_sendmail_Click(object sender, EventArgs e)
        {
            try
            {
                // Duyệt qua danh sách lương
                foreach (var tinhluong in _tinhLuongList)
                {
                    // Kiểm tra xem email có hợp lệ không
                    if (!string.IsNullOrWhiteSpace(tinhluong.EMAIL))
                    {
                        SendEmail(tinhluong);
                    }
                }

                MessageBox.Show("Emails đã được gửi thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        const string SMTP = "smtp.gmail.com";
        const string USER = "hoanhangodz9779@gmail.com";
        const string PWD = "jrxt juhz cveh ceyh"; // Mật khẩu thật nên được mã hóa hoặc sử dụng một cách an toàn
        const int PORT = 587;

        public void SendEmail(TinhluongDTO tinhluong)
        {
            try
            {
                var fromAddress = new MailAddress(USER, USER.Split('@')[0]);
                var toAddress = new MailAddress(tinhluong.EMAIL, tinhluong.HOTEN);
                string subject = $"Công Ty XYZ Gửi Bảng Lương Tháng - {tinhluong.MAKYCONG}";

                // Tạo nội dung email với thông tin bảng lương
                string body = $"Chào {tinhluong.HOTEN},\n\n" +
                      $"Dưới đây là thông tin bảng lương của bạn cho tháng {tinhluong.MAKYCONG}:\n" +
                      $"Ngày công trong tháng: {tinhluong.NGAYCONGTRONGTHANG}\n" +
                      $"Lương ngày phép: {FormatCurrency(tinhluong.LUONGNGAYPHEP)}\n" +
                      $"Lương ngày không phép: {FormatCurrency(tinhluong.LUONGNGAYKHONGPHEP)}\n" +
                      $"Lương ngày lễ: {FormatCurrency(tinhluong.LUONGNGAYLE)}\n" +
                      $"Lương ngày chủ nhật: {FormatCurrency(tinhluong.LUONGNGAYCHUNHAT)}\n" +
                      $"Lương tăng ca: {FormatCurrency(tinhluong.LUONGTANGCA)}\n" +
                      $"Phụ cấp: {FormatCurrency(tinhluong.PHUCAP)}\n" +
                      $"Số tiền kỷ luật: {FormatCurrency(tinhluong.SOTIENKYLUAT)}\n" +
                      $"Số tiền khen thưởng: {FormatCurrency(tinhluong.SOTIENKHENTHUONG)}\n" +
                      $"Lương thực lãnh: {FormatCurrency(tinhluong.LUONGTHUCLANH)}\n" +
                      $"Tổng tiền của tháng: {FormatCurrency(tinhluong.TongTienCuaThang)}\n\n" +
                      $"Trân trọng,\n" +
                      $"Phòng nhân sự";

                var smtp = new SmtpClient
                {
                    Host = SMTP,
                    Port = PORT,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(USER, PWD),
                    Timeout = 20000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi gửi email đến {tinhluong.EMAIL}: {ex.Message}");
            }
        }
        */
        private async void btn_sendmail_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận
                var result = MessageBox.Show("Bạn có chắc chắn muốn gửi email không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Hiển thị form chờ
                    using (var waitFormLoad = new WaitFormLoad())
                    {
                        // Đặt vị trí form chờ ở giữa màn hình
                        waitFormLoad.StartPosition = FormStartPosition.CenterScreen;
                        waitFormLoad.Show(); // Hiển thị form chờ

                        await Task.Run(() => // Chạy việc gửi email trong nền
                        {
                            foreach (var tinhluong in _tinhLuongList)
                            {
                                if (!string.IsNullOrWhiteSpace(tinhluong.EMAIL))
                                {
                                    SendEmail(tinhluong);
                                }
                            }
                        });

                        waitFormLoad.Close(); // Đóng form chờ sau khi hoàn tất
                    }

                    MessageBox.Show("Email đã được gửi thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }


        public string CreatePdf(TinhluongDTO tinhluong)
        {
            // Duong dan den file PDF
            string directoryPath = @"D:\PaySalary";

            // Kiem tra va tao thu muc neu khong ton tai
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, $"{tinhluong.HOTEN}_BangLuong_{tinhluong.MAKYCONG}.pdf");

            // Tao file PDF
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
                document.Open();

                // Them tieu de
                document.Add(new Paragraph($"Bang luong cho thang: {tinhluong.MAKYCONG}", FontFactory.GetFont("Arial Unicode MS", 16)));

                // Them mot dong trong
                document.Add(new Paragraph("\n"));

                // Tao bang voi 2 cot
                PdfPTable table = new PdfPTable(2)
                {
                    WidthPercentage = 100 // Dat do rong bang la 100%
                };

                // Them tieu de cot
                table.AddCell(new PdfPCell(new Phrase("Noi dung", FontFactory.GetFont("Arial Unicode MS", 12))) { HorizontalAlignment = 1 });
                table.AddCell(new PdfPCell(new Phrase("Gia tri", FontFactory.GetFont("Arial Unicode MS", 12))) { HorizontalAlignment = 1 });

                // Them du lieu vao bang
                table.AddCell(new Phrase("Ngay cong trong thang", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.NGAYCONGTRONGTHANG), FontFactory.GetFont("Arial Unicode MS", 12)));

                table.AddCell(new Phrase("Luong ngay phep", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.LUONGNGAYPHEP), FontFactory.GetFont("Arial Unicode MS", 12)));

                table.AddCell(new Phrase("Luong ngay khong phep", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.LUONGNGAYKHONGPHEP), FontFactory.GetFont("Arial Unicode MS", 12)));

                table.AddCell(new Phrase("Luong ngay le", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.LUONGNGAYLE), FontFactory.GetFont("Arial Unicode MS", 12)));

                table.AddCell(new Phrase("Luong ngay chu nhat", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.LUONGNGAYCHUNHAT), FontFactory.GetFont("Arial Unicode MS", 12)));

                table.AddCell(new Phrase("Luong tang ca", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.LUONGTANGCA), FontFactory.GetFont("Arial Unicode MS", 12)));

                table.AddCell(new Phrase("Phu cap", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.PHUCAP), FontFactory.GetFont("Arial Unicode MS", 12)));

                table.AddCell(new Phrase("So tien ky luat", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.SOTIENKYLUAT), FontFactory.GetFont("Arial Unicode MS", 12)));

                table.AddCell(new Phrase("So tien khen thuong", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.SOTIENKHENTHUONG), FontFactory.GetFont("Arial Unicode MS", 12)));

                table.AddCell(new Phrase("Luong thuc lanh", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.LUONGTHUCLANH), FontFactory.GetFont("Arial Unicode MS", 12)));

                table.AddCell(new Phrase("Tong tien cua thang", FontFactory.GetFont("Arial Unicode MS", 12)));
                table.AddCell(new Phrase(FormatCurrency(tinhluong.TongTienCuaThang), FontFactory.GetFont("Arial Unicode MS", 12)));

                // Them bang vao document
                document.Add(table);

                document.Close();
            }

            return filePath;
        }


        const string SMTP = "smtp.gmail.com";
        const string USER = "hoanhangodz9779@gmail.com";
        const string PWD = "jrxt juhz cveh ceyh"; // Mật khẩu thật nên được mã hóa hoặc sử dụng một cách an toàn
        const int PORT = 587;

        public void SendEmail(TinhluongDTO tinhluong)
        {
            try
            {
                var fromAddress = new MailAddress(USER, USER.Split('@')[0]);
                var toAddress = new MailAddress(tinhluong.EMAIL, tinhluong.HOTEN);
                string subject = $"Công Ty XYZ Gửi Bảng Lương Tháng - {tinhluong.MAKYCONG}";

                // Tạo file PDF
                string pdfFilePath = CreatePdf(tinhluong);

                var smtp = new SmtpClient
                {
                    Host = SMTP,
                    Port = PORT,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(USER, PWD),
                    Timeout = 20000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = "Đính kèm bảng lương của bạn."
                })
                {
                    message.Attachments.Add(new Attachment(pdfFilePath));
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi gửi email đến {tinhluong.EMAIL}: {ex.Message}");
            }
        }

        private string FormatCurrency(double? amount)
        {
            // Định dạng số thành VNĐ
            return $"{amount?.ToString("N0")} VNĐ";
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
            LoadData();
            SplashScreenManager.CloseForm();
        }
    }
}