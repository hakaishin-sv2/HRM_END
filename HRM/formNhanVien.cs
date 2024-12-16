using BusinessLayer;
using BusinessLayer.LogIn;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using HRM.Report;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HRM
{
    public partial class formNhanVien : _BaseForm
    {
        public formNhanVien()
        {
            InitializeComponent();
            showBar(true);
            //loadData();
           // labelEror.Enabled = false;
        }


        NhanVien nhanVien;
        BusinessLayer.User _user;
        bool them;
        int id;

        // Đổ dữ liệu vào combobox
        PhongBan phongBan;
        BoPhan boPhan;
        ChucVu chucVu;
        TrinhDo trinhDo;
        DanToc danToc;
        TonGiao tonGiao;

        List<NhanVien_DTO> ListNv_DataGridView;
        public List<NhanVien_DTO> getDanhSachGridView()
        {
            var Temp_ListNv_gridView = new List<NhanVien_DTO>();

            for (int i = 0; i < gridView_NhanVien.RowCount; i++)
            {
                var DTO_NhanVien = new NhanVien_DTO
                {
                    
                    ID = gridView_NhanVien.GetRowCellValue(i, "ID") != DBNull.Value ? Convert.ToInt32(gridView_NhanVien.GetRowCellValue(i, "ID")) : 0,
                    MANV = gridView_NhanVien.GetRowCellValue(i, "MANV") != DBNull.Value ? Convert.ToInt32(gridView_NhanVien.GetRowCellValue(i, "MANV")) : 0,
                    HOTEN = gridView_NhanVien.GetRowCellValue(i, "HOTEN") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "HOTEN")) : string.Empty,
                    GIOITINH = gridView_NhanVien.GetRowCellValue(i, "GIOITINH") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "GIOITINH")) : string.Empty,
                    NGAYSINH = gridView_NhanVien.GetRowCellValue(i, "NGAYSINH") != DBNull.Value ? Convert.ToDateTime(gridView_NhanVien.GetRowCellValue(i, "NGAYSINH")) : DateTime.MinValue,
                    DIENTHOAI = gridView_NhanVien.GetRowCellValue(i, "DIENTHOAI") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "DIENTHOAI")) : string.Empty,
                    CCCD = gridView_NhanVien.GetRowCellValue(i, "CCCD") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "CCCD")) : string.Empty,
                    DIACHI = gridView_NhanVien.GetRowCellValue(i, "DIACHI") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "DIACHI")) : string.Empty,
                    IMGPATH = gridView_NhanVien.GetRowCellValue(i, "IMGPATH") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "IMGPATH")) : string.Empty,
                    TENPB = gridView_NhanVien.GetRowCellValue(i, "TENPB") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "TENPB")) : string.Empty,
                    TENBP = gridView_NhanVien.GetRowCellValue(i, "TENBP") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "TENBP")) : string.Empty,
                    TENCV = gridView_NhanVien.GetRowCellValue(i, "TENCV") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "TENCV")) : string.Empty,
                    TENTD = gridView_NhanVien.GetRowCellValue(i, "TENTD") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "TENTD")) : string.Empty,
                    TENDANTOC = gridView_NhanVien.GetRowCellValue(i, "TENDANTOC") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "TENDANTOC")) : string.Empty,
                    TENTONGIA = gridView_NhanVien.GetRowCellValue(i, "TENTONGIA") != DBNull.Value ? Convert.ToString(gridView_NhanVien.GetRowCellValue(i, "TENTONGIA")) : string.Empty
                };


                Temp_ListNv_gridView.Add(DTO_NhanVien);
            }


            return Temp_ListNv_gridView;
        }
        private void LoadComboBoxRole()
        {
            // Xóa các mục cũ (nếu có)
            comboBox_Role.Items.Clear();

            // Tạo Dictionary với Text và Value
            var roles = new Dictionary<string, int>
    {
        { "Nhân viên", 0 },
        { "Trưởng phòng", 1 }
    };

            // Đổ dữ liệu từ Dictionary vào ComboBox
            comboBox_Role.DataSource = new BindingSource(roles, null);
            comboBox_Role.DisplayMember = "Key";
            comboBox_Role.ValueMember = "Value";

            // Thiết lập mục mặc định (nếu cần)
            comboBox_Role.SelectedIndex = 0;
        }
        void loadData()
        {
            nhanVien = new NhanVien();
            _user= new BusinessLayer.User();
             var data = nhanVien.getListDTO_NhanVien();
            gridControlNhanVien.DataSource = data;
            gridView_NhanVien.OptionsBehavior.Editable = false;
            gridView_NhanVien.OptionsView.ColumnAutoWidth = true;
            
            //MessageBox.Show(ListNv_DataGridView[0].HOTEN);
        }
        void showBar(bool kt)
        {
            btnSave.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtbox_HoTen.Enabled = !kt;
            textBoxMaNV.Enabled = !kt;
            txtbox_HoTen.Enabled = !kt;
            textBox_CCCD.Enabled = !kt;
            txtEmail.Enabled = !kt;
            //pictureBoxHinhAnh.Enabled = !kt;
            dateTimePicker_NgaySinh.Enabled = !kt;
            comboBoxPhongBan.Enabled = !kt;
            comboBoxBoPhan.Enabled = !kt;
            comboBoxChucVu.Enabled = !kt;
            comboBoxTrìnhDo.Enabled = !kt;
            comboBoxDanToc.Enabled = !kt;
            comboBoxTonGiao.Enabled = !kt;
            comboBox_Role.Enabled = !kt;
            txtb_SDT.Enabled = !kt;
            textBox_DiaChi.Enabled = !kt;
            splitContainer1.Enabled = true;
           

            btnThem.Enabled = kt;
            btnFix.Enabled = kt;
            btnXoa.Enabled = kt;
            btnPrint.Enabled = kt;
            btnClose.Enabled = kt;
        }
        int check ;
        int fix;

        private readonly string _uploadFolder = "D:\\Uploads\\";
        public void EnsureUploadFolderExists()
        {
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
        }

        public string _newFilePath;
        public bool _checkNewPickTrue;
        public string GetImagePath(PictureBox ptb)
        {
            _newFilePath = "";
            string selectedPath =  ptb.ImageLocation;
            //MessageBox.Show(selectedPath);

            // Kiểm tra xem đường dẫn tệp có rỗng hoặc null hay không, và kiểm tra tệp có tồn tại tại đường dẫn được chỉ định hay không
            if (string.IsNullOrEmpty(selectedPath))
            {
                throw new ArgumentException("No image selected.");
            }

            if (!File.Exists(selectedPath))
            {
                throw new FileNotFoundException("Image file not found.", selectedPath);
            }

            string imgExt = Path.GetExtension(selectedPath);  // phần mở rộng file
            string newFileName = Guid.NewGuid().ToString() + imgExt; // tạo tên tệp khoong trùng lặp
            _newFilePath = Path.Combine(_uploadFolder, newFileName);

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }

            return newFileName;
        }


        private void XoaFile(string tenFile)
        {
            string duongDanFile = Path.Combine(_uploadFolder, tenFile);
            if (File.Exists(duongDanFile))
            {
                try
                {
                    // Xóa tệp
                    File.Delete(duongDanFile);
                    Console.WriteLine("Xóa tệp thành công: " + duongDanFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi xóa tệp: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy tệp: " + duongDanFile);
            }
        }


        bool IsValid(bool IsAdd)
        {
            bool _IsValid = true;
            errorProvider1.Clear();
            if (IsAdd)
            {
                if (string.IsNullOrWhiteSpace(textBoxMaNV.Text))
                {
                    errorProvider1.SetError(textBoxMaNV, "Bạn cần nhập Mã Nhân Viên");
                    errorProvider1.SetIconAlignment(textBoxMaNV, ErrorIconAlignment.MiddleRight);

                    _IsValid = false;
                }

            }

            if (comboBox_Role.SelectedItem == null)
            {
                errorProvider1.SetError(comboBox_Role, "Bạn cần chọn Vai Trò cho Nhân Viên");
                errorProvider1.SetIconAlignment(comboBox_Role, ErrorIconAlignment.MiddleRight);
                _IsValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtbox_HoTen.Text))
            {
                errorProvider1.SetError(txtbox_HoTen, "Bạn cần nhập Họ Tên Nhân Viên");
                errorProvider1.SetIconAlignment(txtbox_HoTen, ErrorIconAlignment.MiddleRight);
                _IsValid = false;

            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Bạn cần nhập Email Nhân Viên");
                errorProvider1.SetIconAlignment(txtEmail, ErrorIconAlignment.MiddleRight);
                _IsValid = false;
            }
            if (cbGioiTinh.SelectedItem == cbGioiTinh.Items[0])
            {
                errorProvider1.SetError(cbGioiTinh, "Bạn cần chọn giới tính Nhân Viên");
                errorProvider1.SetIconAlignment(cbGioiTinh, ErrorIconAlignment.MiddleRight);
                _IsValid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox_CCCD.Text))
            {
                errorProvider1.SetError(textBox_CCCD, "Bạn cần nhập số CCCD Nhân Viên");
                errorProvider1.SetIconAlignment(textBox_CCCD, ErrorIconAlignment.MiddleRight);
                _IsValid = false;
            }

            else if (!Function.IsNumeric(textBox_CCCD.Text))
            {
                errorProvider1.SetError(textBox_CCCD, "Số CCCD phải là dạng số");
                errorProvider1.SetIconAlignment(textBox_CCCD, ErrorIconAlignment.MiddleRight);
                _IsValid = false;
            }

            return _IsValid;//test


            if (string.IsNullOrWhiteSpace(txtb_SDT.Text))
            {
                errorProvider1.SetError(textBox_CCCD, "Bạn cần nhập Số điện thoại Nhân Viên");
                errorProvider1.SetIconAlignment(textBox_CCCD, ErrorIconAlignment.MiddleRight);
                _IsValid = false;
               
            }
            if (!Function.IsNumeric(txtb_SDT.Text))
            {
                MessageBox.Show("Số Điện Thoại phải là dạng số và bắt đầu là 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _IsValid = false;
            }
             if (string.IsNullOrWhiteSpace(textBox_DiaChi.Text))
            {
                errorProvider1.SetError(textBox_CCCD, "Bạn cần nhập Địa Chỉ Nhân Viên");
                errorProvider1.SetIconAlignment(textBox_CCCD, ErrorIconAlignment.MiddleRight);
                _IsValid = false;
               
            }
            //de yen tao coi
            
            if (comboBoxPhongBan.SelectedItem == null)
            {
                MessageBox.Show("Bạn cần chọn phòng ban cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _IsValid = false;
            }
            if (comboBoxBoPhan.SelectedItem == null)
            {
                MessageBox.Show("Bạn cần chọn Bộ Phận cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _IsValid = false;
            }
            if (comboBoxChucVu.SelectedItem == null)
            {
                MessageBox.Show("Bạn cần chọn chức vụ ứng với Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _IsValid = false;
            }
            if (comboBoxTrìnhDo.SelectedItem == null)
            {
                MessageBox.Show("Bạn cần chọn Trình Độ ứng với Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _IsValid = false;
            }
            if (comboBoxDanToc.SelectedItem == null)
            {
                MessageBox.Show("Bạn cần chọn Dân Tộc cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _IsValid = false;
            }
             if (comboBoxTonGiao.SelectedItem == null)
            {
                MessageBox.Show("Bạn cần chọn Tôn Giáo cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _IsValid = false;
            }
            if (comboBox_Role.SelectedItem == null)
            {
                MessageBox.Show("Bạn cần chọn Vai Trò cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
                _IsValid = false;

            }
            if (cbGioiTinh.SelectedItem == cbGioiTinh.Items[0])
            {
                MessageBox.Show("Bạn cần tích chọn giới tính Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _IsValid = false;
            }

            return _IsValid;    
        }


        void SaveData()
        {
            

            //MessageBox.Show(id.ToString());
            EnsureUploadFolderExists();
            GetImagePath(pictureBoxHinhAnh);
            string GioiTinh=cbGioiTinh.SelectedItem.ToString();

          
            try
            {
               

                if (them)

                {
                   
                    if (string.IsNullOrWhiteSpace(txtbox_HoTen.Text))
                    {
                        MessageBox.Show("Bạn cần nhập Họ Tên Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;

                    }
                    else if (string.IsNullOrWhiteSpace(txtEmail.Text))
                    {
                        MessageBox.Show("Bạn cần nhập Email Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (string.IsNullOrWhiteSpace(textBoxMaNV.Text))
                    {
                        MessageBox.Show("Bạn cần nhập Mã Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (string.IsNullOrWhiteSpace(textBox_CCCD.Text))
                    {
                        MessageBox.Show("Bạn cần nhập số CCCD Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (!Function.IsNumeric(textBox_CCCD.Text))
                    {
                        MessageBox.Show("Số CCCD phải là dạng số", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (string.IsNullOrWhiteSpace(txtb_SDT.Text))
                    {
                        MessageBox.Show("Bạn cần nhập Số điện thoại Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (!Function.IsNumeric(txtb_SDT.Text))
                    {
                        MessageBox.Show("Số Điện Thoại phải là dạng số và bắt đầu là 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (string.IsNullOrWhiteSpace(textBox_DiaChi.Text))
                    {
                        MessageBox.Show("Bạn cần nhập Địa Chỉ Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    //de yen tao coi
                    else if (cbGioiTinh.SelectedItem == cbGioiTinh.Items[0])
                    {
                        MessageBox.Show("Bạn cần tích chọn giới tính Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (comboBoxPhongBan.SelectedItem == null)
                    {
                        MessageBox.Show("Bạn cần chọn phòng ban cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (comboBoxBoPhan.SelectedItem == null)
                    {
                        MessageBox.Show("Bạn cần chọn Bộ Phận cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (comboBoxChucVu.SelectedItem == null)
                    {
                        MessageBox.Show("Bạn cần chọn chức vụ ứng với Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (comboBoxTrìnhDo.SelectedItem == null)
                    {
                        MessageBox.Show("Bạn cần chọn Trình Độ ứng với Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (comboBoxDanToc.SelectedItem == null)
                    {
                        MessageBox.Show("Bạn cần chọn Dân Tộc cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (comboBoxTonGiao.SelectedItem == null)
                    {
                        MessageBox.Show("Bạn cần chọn Tôn Giáo cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        check = 0;
                    }
                    else if (comboBox_Role.SelectedItem == null)
                    {
                        MessageBox.Show("Bạn cần chọn Vai Trò cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //return;
                        check = 0;
                        
                    }
                    else
                    {
                        fix = 0;
                        //cho nay la của add
                        if (cbGioiTinh.SelectedItem == cbGioiTinh.Items[0])
                        {
                            MessageBox.Show("Bạn cần tích chọn giới tính Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            check = 0;
                        }
                        else
                        {
                            //MessageBox.Show(comboBoxPhongBan.Text.ToString());
                            var dt = new Data_Layer.tb_NHANVIEN
                            {
                                MANV = int.Parse(textBoxMaNV.Text.Trim()),
                                EMAIL = txtEmail.Text.Trim(),
                                HOTEN = txtbox_HoTen.Text.Trim(),
                                GIOITINH = GioiTinh,
                                NGAYSINH = dateTimePicker_NgaySinh.Value, // Giữ nguyên kiểu DateTime
                                DIENTHOAI = txtb_SDT.Text,
                                CCCD = textBox_CCCD.Text,
                                DIACHI = textBox_DiaChi.Text,
                                TrangThaiLamViec = 1,
                                //HINHANH = ImageToBase64(pictureBoxHinhAnh.Image, pictureBoxHinhAnh.Image.RawFormat),
                                IDPB = int.Parse(comboBoxPhongBan.SelectedValue.ToString()),
                                IDBP = int.Parse(comboBoxBoPhan.SelectedValue.ToString()),
                                IDCV = int.Parse(comboBoxChucVu.SelectedValue.ToString()),
                                IDTD = int.Parse(comboBoxTrìnhDo.SelectedValue.ToString()),
                                IDDANTOC = int.Parse(comboBoxDanToc.SelectedValue.ToString()),
                                IDTONGIAO = int.Parse(comboBoxTonGiao.SelectedValue.ToString()),
                                ROLE = int.Parse(comboBox_Role.SelectedValue.ToString()),
                                IMGPATH = GetImagePath(pictureBoxHinhAnh)
                            };

                            var maNV = int.Parse(textBoxMaNV.Text);

                            // Kiểm tra xem mã nhân viên đã tồn tại chưa
                            var existingNV = nhanVien.FindMaNV(maNV);
                            if (existingNV == null)
                            {
                                var result = nhanVien.Them(dt);
                                if (result != null)
                                {
                                    check = 1;
                                    File.Copy(pictureBoxHinhAnh.ImageLocation, _newFilePath); // đưa ảnh vào
                                    _checkNewPickTrue = false;
                                    MessageBox.Show("Thêm Nhân Viên mới thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _user = new BusinessLayer.User();
                                    int manv = int.Parse(textBoxMaNV.Text);
                                    string ngaysinh = dateTimePicker_NgaySinh.Value.ToString("dd/MM/yyyy");
                                    string password = ngaysinh.Replace("/", "");
                                    string haspassword = PasswordHelper.HashPassword(password);
                                    int role = int.Parse(comboBox_Role.SelectedValue.ToString());
                                    // Mượn đối tượng user để gán thôi thực chất là mã nhân viên ấy
                                    var data_user = new Data_Layer.tb_USER
                                    {
                                        MANV_LOGIN = manv,
                                        PASSWORD = password,
                                        HASHPASSWORD = haspassword,
                                        ROLE = role,
                                    };
                                    _user.AddUser(data_user);
                                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn lập hợp đồng cho nhân viên này luôn không?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        formLapHopDong frmLHP = new formLapHopDong();
                                        frmLHP._manv = manv;
                                        // frmHD.
                                        frmLHP.ShowDialog();
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Có lỗi xảy ra khi thêm Nhân Viên mới", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                // Mã nhân viên đã tồn tại
                                MessageBox.Show("Mã Nhân Viên đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }

                }
                else// chỉnh sửa
                {
                    bool _IsValid = IsValid(false);
                    if(_IsValid)
                    {
                        //string GioiTinh = radioButtonNam.Checked ? "Nữ" : "Nam";
                        int role = (int)comboBox_Role.SelectedValue;
                        if (role == 1)
                        {
                            var checkPB = phongBan.checkTp(int.Parse(comboBoxPhongBan.SelectedValue.ToString()));

                            if (checkPB == true)
                            {
                                DialogResult dialogResult = MessageBox.Show("Phòng ban này đã có người quản lý, Bạn có muốn đổi Thành người này không, Nếu Không vui lòng chọn lại vai trò là 0", "Cảnh báo", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    role = 1;
                                    var pb = phongBan.getItem(int.Parse(comboBoxPhongBan.SelectedValue.ToString()));

                                    // update lại trưởng phòng cũ thành nhân viên
                                    var nhanvien_x = nhanVien.FindMaNV(int.Parse(pb.IDTP.ToString()));
                                    nhanvien_x.ROLE = 0;
                                    nhanVien.Update(nhanvien_x);
                                    pb.IDTP = int.Parse(textBoxMaNV.Text.Trim());
                                    phongBan.Update(pb);

                                    // cập nhật lại role trong tb_USER
                                    var user_tp_old = _user.getItemByManv(nhanvien_x.MANV, out _);
                                    user_tp_old.ROLE = 0;
                                    _user.Update(user_tp_old);

                                    var user_tp_new = _user.getItemByManv(int.Parse(textBoxMaNV.Text.Trim()), out _);
                                    user_tp_new.ROLE = 1;
                                    _user.Update(user_tp_new);

                                }

                            }
                            else
                            {
                                _user = new BusinessLayer.User();
                                var user_tp_new = _user.getItemByManv(int.Parse(textBoxMaNV.Text.Trim()), out _);
                                user_tp_new.ROLE = 1;
                                _user.Update(user_tp_new);
                                var pb = phongBan.getItem(int.Parse(comboBoxPhongBan.SelectedValue.ToString()));
                                pb.IDTP = int.Parse(textBoxMaNV.Text.Trim());
                                phongBan.Update(pb);

                            }
                        }

                        var data = nhanVien.getItem(id);
                        if (data != null)
                        {
                            data.MANV = int.Parse(textBoxMaNV.Text.Trim());
                            data.HOTEN = txtbox_HoTen.Text.Trim();
                            data.GIOITINH = GioiTinh;
                            data.NGAYSINH = dateTimePicker_NgaySinh.Value;
                            data.DIENTHOAI = txtb_SDT.Text;
                            data.CCCD = textBox_CCCD.Text;
                            data.DIACHI = textBox_DiaChi.Text;
                            data.EMAIL = txtEmail.Text;
                            //data.HINHANH = ImageToBase64(pictureBoxHinhAnh.Image, pictureBoxHinhAnh.Image.RawFormat);
                            data.IDPB = int.Parse(comboBoxPhongBan.SelectedValue.ToString());
                            data.IDBP = int.Parse(comboBoxBoPhan.SelectedValue.ToString());
                            data.IDCV = int.Parse(comboBoxChucVu.SelectedValue.ToString());
                            data.IDTD = int.Parse(comboBoxTrìnhDo.SelectedValue.ToString());
                            data.IDDANTOC = int.Parse(comboBoxDanToc.SelectedValue.ToString());
                            data.IDTONGIAO = int.Parse(comboBoxTonGiao.SelectedValue.ToString());
                            data.ROLE = role;
                            if (_checkNewPickTrue == true)
                            {

                                XoaFile(data.IMGPATH);
                                data.IMGPATH = GetImagePath(pictureBoxHinhAnh);
                                nhanVien.Update(data);
                                File.Copy(pictureBoxHinhAnh.ImageLocation, _newFilePath);
                                fix = 1;
                                MessageBox.Show("Cập nhật thông tin mới cho nhân viên có mã: " + textBoxMaNV.Text + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                data.IMGPATH = data.IMGPATH;
                                nhanVien.Update(data);
                                fix = 1;
                                MessageBox.Show("Cập nhật thông tin mới cho nhân viên có mã: " + textBoxMaNV.Text + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(textBoxMaNV, $"Không tìm thấy Nhân Viên có mã {textBoxMaNV.Text} để cập nhật");
                            errorProvider1.SetIconAlignment(textBoxMaNV, ErrorIconAlignment.MiddleRight);
                        }
                    }


                    return;


                    if (cbGioiTinh.SelectedItem == cbGioiTinh.Items[0])
                    {
                        MessageBox.Show("Phai chon gioi tinh", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        check = 0;
                    }
                    else if (comboBox_Role.SelectedItem == null)
                    {
                        MessageBox.Show("Bạn cần chọn Vai Trò cho Nhân Viên", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //return;
                        check = 0;
                    }        
                    else
                    {
                        //string GioiTinh = radioButtonNam.Checked ? "Nữ" : "Nam";
                        int role = (int)comboBox_Role.SelectedValue;
                        if (role == 1)
                        {
                            var checkPB = phongBan.checkTp(int.Parse(comboBoxPhongBan.SelectedValue.ToString()));

                            if (checkPB == true)
                            {
                                DialogResult dialogResult = MessageBox.Show("Phòng ban này đã có người quản lý, Bạn có muốn đổi Thành người này không, Nếu Không vui lòng chọn lại vai trò là 0", "Cảnh báo", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    role = 1;
                                    var pb = phongBan.getItem(int.Parse(comboBoxPhongBan.SelectedValue.ToString()));

                                    // update lại trưởng phòng cũ thành nhân viên
                                    var nhanvien_x = nhanVien.FindMaNV(int.Parse(pb.IDTP.ToString()));
                                    nhanvien_x.ROLE = 0;
                                    nhanVien.Update(nhanvien_x);
                                    pb.IDTP = int.Parse(textBoxMaNV.Text.Trim());
                                    phongBan.Update(pb);

                                    // cập nhật lại role trong tb_USER
                                    var user_tp_old = _user.getItemByManv(nhanvien_x.MANV, out _);
                                    user_tp_old.ROLE = 0;
                                    _user.Update(user_tp_old);

                                    var user_tp_new = _user.getItemByManv(int.Parse(textBoxMaNV.Text.Trim()), out _);
                                    user_tp_new.ROLE = 1;
                                    _user.Update(user_tp_new);

                                }

                            }
                            else
                            {
                                _user = new BusinessLayer.User();
                                var user_tp_new = _user.getItemByManv(int.Parse(textBoxMaNV.Text.Trim()), out _);
                                user_tp_new.ROLE = 1;
                                _user.Update(user_tp_new);
                                 var pb = phongBan.getItem(int.Parse(comboBoxPhongBan.SelectedValue.ToString()));
                                pb.IDTP = int.Parse(textBoxMaNV.Text.Trim());
                                phongBan.Update(pb) ;

                            }
                        }

                        var data = nhanVien.getItem(id);
                        if (data != null)
                        {
                            data.MANV = int.Parse(textBoxMaNV.Text.Trim());
                            data.HOTEN = txtbox_HoTen.Text.Trim();
                            data.GIOITINH = GioiTinh;
                            data.NGAYSINH = dateTimePicker_NgaySinh.Value;
                            data.DIENTHOAI = txtb_SDT.Text;
                            data.CCCD = textBox_CCCD.Text;
                            data.DIACHI = textBox_DiaChi.Text;
                            data.EMAIL = txtEmail.Text;
                            //data.HINHANH = ImageToBase64(pictureBoxHinhAnh.Image, pictureBoxHinhAnh.Image.RawFormat);
                            data.IDPB = int.Parse(comboBoxPhongBan.SelectedValue.ToString());
                            data.IDBP = int.Parse(comboBoxBoPhan.SelectedValue.ToString());
                            data.IDCV = int.Parse(comboBoxChucVu.SelectedValue.ToString());
                            data.IDTD = int.Parse(comboBoxTrìnhDo.SelectedValue.ToString());
                            data.IDDANTOC = int.Parse(comboBoxDanToc.SelectedValue.ToString());
                            data.IDTONGIAO = int.Parse(comboBoxTonGiao.SelectedValue.ToString());
                            data.ROLE = role;
                            if (_checkNewPickTrue == true)
                            {
                               
                                XoaFile(data.IMGPATH);
                                data.IMGPATH = GetImagePath(pictureBoxHinhAnh);
                                nhanVien.Update(data);
                                File.Copy(pictureBoxHinhAnh.ImageLocation, _newFilePath);
                                fix = 1;
                                MessageBox.Show("Cập nhật thông tin mới cho nhân viên có mã: " + textBoxMaNV.Text + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               
                            }
                            else
                            {
                                data.IMGPATH = data.IMGPATH;
                                nhanVien.Update(data);
                                fix = 1;
                                MessageBox.Show("Cập nhật thông tin mới cho nhân viên có mã: " + textBoxMaNV.Text + " thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                           
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy Nhân Viên để cập nhật", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Hàm chuyển hình ảnh vè nhị phân 

        void Reset()
        {
            textBoxMaNV.Text = string.Empty;
            txtbox_HoTen.Text = string.Empty;

          


            dateTimePicker_NgaySinh.Value = DateTime.Now;
            txtb_SDT.Text = string.Empty; ;
            textBox_CCCD.Text = string.Empty; ;
            textBox_DiaChi.Text = string.Empty;

        }
       
        public static byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }



        // Chuyển đổi dữ liệu base64 thành hình ảnh
        public static Image Base64ToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms);
            return image;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            them = true;
            showBar(false);
            Reset();
            splitContainer1.Panel1Collapsed = false; // là mở lên
            pictureBoxHinhAnh.ImageLocation = "C:\\img hrm\\no_Image.jpg";
        }

        private void btnFix_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            them = false;
            showBar(false);
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int sl = nhanVien.TongSoLuongNhanVien();
            var nv = nhanVien.getItem(id);
            if(nv != null)
            {
                if (MessageBox.Show("Bạn muốn xóa nhân viên có mã " + nv.MANV + " " + nv.HOTEN + " không", "Waring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    nhanVien.Xoa(id);
                    loadData();
                    XoaFile(nv.IMGPATH);
                    them = true;
                    MessageBox.Show("Xóa thành công");
                }
            }else if(sl <=0){
                MessageBox.Show("Chưa có nhân viên nào trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nhân viên không tồn tại hoặc đã bị xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            if(them == true && check == 1)
            {
                splitContainer1.Panel1Collapsed = true;
                showBar(true);
                loadData();
                them = false;
            }
            else if(them == true && check == 0)
            {   
                showBar(false);
                them = true;
                
            }else if(them == false && fix == 1)
            {
                showBar(true);
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
            ListNv_DataGridView = getDanhSachGridView();
            ReportDanhSachNhanVien rpt = new ReportDanhSachNhanVien(ListNv_DataGridView);
            rpt.ShowPreview();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        bool IsLoaded = false;

        private void formNhanVien_Load(object sender, EventArgs e)
        {
            IsLoaded = false;
            try
            {
                textBoxMaNV.KeyPress += (s, evt) => 
                {
                    evt.Handled = !char.IsDigit(evt.KeyChar) && !char.IsControl(evt.KeyChar);
                };

                // Kiểm tra và hiển thị màn hình chờ nếu chưa hiển thị
                if (SplashScreenManager.Default != null && !SplashScreenManager.Default.IsSplashFormVisible)
                {
                    SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
                }

                if (splitContainer1.Panel1Collapsed == false || fix == 1)
                {
                    loadComBoBox();
                }

                loadData();
                LoadComboBoxRole();
                them = false;
                showBar(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng màn hình chờ nếu nó đang hiển thị
                if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
                {
                    SplashScreenManager.CloseForm();
                }

                // Thiết lập trạng thái của Panel
                splitContainer1.Panel1Collapsed = (fix == 0);

                IsValid(them);

                IsLoaded = true;
            }
        }


        void loadComBoBox()
        {
            phongBan = new PhongBan();
            boPhan = new BoPhan();
            chucVu = new ChucVu();
            trinhDo = new TrinhDo();
            danToc = new DanToc();
            tonGiao = new TonGiao();


           
            #region load gioi tinh
            cbGioiTinh.SelectedItem = cbGioiTinh.Items[0];
            #endregion  



            comboBoxPhongBan.DataSource = phongBan.getListPhongBan();
            comboBoxPhongBan.ValueMember = "IDPB";
            comboBoxPhongBan.DisplayMember = "TENPB";

            comboBoxBoPhan.DataSource = boPhan.getDanhSach();
            comboBoxBoPhan.ValueMember = "IDBP";
            comboBoxBoPhan.DisplayMember = "TENBP";

            comboBoxChucVu.DataSource = chucVu.getDanhSach();
            comboBoxChucVu.ValueMember = "IDCV";
            comboBoxChucVu.DisplayMember = "TENCV";

            #region load trinh do
            var ListTrinhDo = new List<Data_Layer.tb_TRINHDO>();
            ListTrinhDo.Add(new Data_Layer.tb_TRINHDO
            {
                IDTD = -1,
                TENTD = "Chọn trình độ"
            });

            ListTrinhDo.AddRange(trinhDo.getListTrinhDo());
            comboBoxTrìnhDo.DataSource = ListTrinhDo;
            comboBoxTrìnhDo.ValueMember = "IDTD";
            comboBoxTrìnhDo.DisplayMember = "TENTD";
            if (comboBoxTrìnhDo.Items.Count > 0)
            {
                comboBoxTrìnhDo.SelectedIndex = 0;
            }
            #endregion


            #region load dan toc
            var ListDanToc = new List<Data_Layer.tb_DANTOC>();
            ListDanToc.Add(new Data_Layer.tb_DANTOC
            {
                ID = -1,
                TENDANTOC = "Chọn dân tộc"
            });

            ListDanToc.AddRange(danToc.getListDanToc());

            comboBoxDanToc.DataSource = ListDanToc;
            comboBoxDanToc.ValueMember = "ID";
            comboBoxDanToc.DisplayMember = "TENDANTOC";
            if (comboBoxDanToc.Items.Count > 0)
            {
                comboBoxDanToc.SelectedIndex = 0;
            }
            #endregion




            comboBoxTonGiao.DataSource = tonGiao.getListTonGiao();
            comboBoxTonGiao.ValueMember = "ID";
            comboBoxTonGiao.DisplayMember = "TENTONGIA";

            //comboBox_Role.DataSource = getNhanVien.ROLE;
        }

        private void gridView_NhanVien_Click(object sender, EventArgs e)
        {
            if(splitContainer1.Panel1Collapsed == true)
            {
                splitContainer1.Panel1Collapsed = false;
            }
            int sl = nhanVien.TongSoLuongNhanVien();
            if (sl == 0)
            {

            }
            else
            {
                id = Convert.ToInt32(gridView_NhanVien.GetFocusedRowCellValue("ID"));
                var getNhanVien = nhanVien.getItem(id);

                textBoxMaNV.Text = getNhanVien.MANV.ToString();
                txtbox_HoTen.Text = getNhanVien.HOTEN;
                string gioitinh = getNhanVien.GIOITINH.ToString();
                if (gioitinh == "Nam")
                {
                    cbGioiTinh.SelectedItem = "Nam";
                }
                else if(gioitinh== "Nữ")
                {
                    cbGioiTinh.SelectedItem = "Nữ";
                }
                else if (gioitinh.ToLower() == "không xác định")
                {
                    cbGioiTinh.SelectedItem = "Không xác định";
                }

                else
                {
                    cbGioiTinh.SelectedItem = cbGioiTinh.Items[0];
                }

                dateTimePicker_NgaySinh.Value = getNhanVien.NGAYSINH;
                txtb_SDT.Text = getNhanVien.DIENTHOAI;
                textBox_CCCD.Text = getNhanVien.CCCD;
                textBox_DiaChi.Text = getNhanVien.DIACHI;
                txtEmail.Text = getNhanVien.EMAIL;
                //pictureBoxHinhAnh.Image = Base64ToImage(getNhanVien.HINHANH);
                pictureBoxHinhAnh.ImageLocation = this._CFG_UPLOAD_FOLDER + getNhanVien.IMGPATH;

                comboBoxPhongBan.SelectedValue = getNhanVien.IDPB;
                comboBoxBoPhan.SelectedValue = getNhanVien.IDBP;
                comboBoxChucVu.SelectedValue = getNhanVien.IDCV;
                comboBoxTrìnhDo.SelectedValue = getNhanVien.IDTD;
                comboBoxDanToc.SelectedValue = getNhanVien.IDDANTOC;
                comboBoxTonGiao.SelectedValue = getNhanVien.IDTONGIAO;
                comboBox_Role.SelectedValue = getNhanVien.ROLE;
            }
           
        }

        private void btnChonHinhAnh_Click(object sender, EventArgs e)
        {
          
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Pictrue file (*.png;*.jpg)|*.png;*.jpg";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHinhAnh.Image = Image.FromFile(dlg.FileName);
                pictureBoxHinhAnh.ImageLocation = dlg.FileName;
                pictureBoxHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                _checkNewPickTrue = true;
            }
        }

        private void gridView_NhanVien_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private void comboBoxChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
            if (splitContainer1.Panel1Collapsed == false || fix == 1)
            {
                loadComBoBox();
            }

            loadData();
            them = false;
            showBar(true);
            SplashScreenManager.CloseForm();
            
        }

        private void txtbox_HoTen_TextChanged(object sender, EventArgs e)
        {
            //tu tu nha
            //lam sao biết dang o che đô nào

            IsValid(them);

            return;

            TextBox txt = sender as TextBox;
            if(txt != null && txt.Tag != null)
            {
                Control[] ctrs = this.Controls.Find(txt.Tag.ToString(), true);
                if (ctrs != null && ctrs.Count() > 0)
                {
                    IsValid(false);
                    if (string.IsNullOrEmpty(txt.Text.Trim()))
                    {
                        ctrs[0].Visible = true;
                        
                    }
                    else
                    {
                        ctrs[0].Visible = false;
                        //ko duoc, to chuc du lieu lai moi duoc

                    }
                }
            }
        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(IsLoaded)
            {

                IsValid(them);

                return;

                ComboBox cb = sender as ComboBox;
                if (cb != null && cb.Tag != null)                   
                {
                    Control[] ctrs = this.Controls.Find(cb.Tag.ToString(), true);
                    if (ctrs != null && ctrs.Count() > 0)
                    {
                        IsValid(false);
                        if (cb.SelectedIndex == 0)
                        {
                            ctrs[0].Visible = true;
                        }
                        else
                        {
                            ctrs[0].Visible = false;
                        }
                    }
                }
            }

        }
    }
}