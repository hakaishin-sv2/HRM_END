using BusinessLayer;
using DevExpress.Xpo;
using HRM.ChamCong;
using HRM.formRoleNhanVien;
using HRM.GiamDoc;
using HRM.LogIn;
using HRM.TruongPhong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Session = BusinessLayer.Session;

namespace HRM
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateRibbonAccess(Session.User.Role);
            
        }
        NhanVien _nhanVien;
        void onpenForm(Type typeForm)
        {
            foreach (var form in MdiChildren)
            {
                if (form.GetType() == typeForm)
                {
                    form.Activate();
                    return;
                }

            }
            Form frm = (Form)Activator.CreateInstance(typeForm);
            frm.MdiParent = this;
            frm.Show();

        }
        
        private void UpdateRibbonAccess(int Role)
        {
            if (Role == 0) // Nhân viên
            {
                ribbonNhanVien.Visible = true;
                ribbonNhanSu.Visible = false;
                ribbonGiamDoc.Visible = false;
                ribbonChamCong.Visible = false;
                ribbonPageTruongPhuong.Visible = false;
                ribbonHeThong.Visible = false;
            }
            else if (Role == 1 ) // Quản lý
            {
                _nhanVien = new NhanVien();
                var nv = _nhanVien.FindMaNV(Session.User.MANV);
                if(nv.IDPB ==6)// id 6 là phòng nhân sự
                {
                    ribbonNhanVien.Visible = true;
                    ribbonNhanSu.Visible = true;
                    ribbonGiamDoc.Visible = false;
                    ribbonChamCong.Visible = true;
                    ribbonHeThong.Visible = false;
                    ribbonHeThong.Visible = false;
                }
                else 
                {
                    ribbonNhanVien.Visible = true;
                    ribbonNhanSu.Visible = false;
                    ribbonGiamDoc.Visible = false;
                    ribbonChamCong.Visible = true;
                    ribbonHeThong.Visible = false;
                    ribbonHeThong.Visible = false;
                }
            }
            else if (Role == 2) // Giám đốc
            {
                ribbonNhanVien.Visible = false;
                ribbonChamCong.Visible = false;
                ribbonNhanSu.Visible = true;
                ribbonGiamDoc.Visible = true;
                ribbonPageTruongPhuong.Visible = false;
            }
            else
            {
                // Xử lý nếu có vai trò khác
            }
        }
        private void btnDanToc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formDanToc));
        }

        private void btnTonGiao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            onpenForm(typeof(formTonGiao));

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
            // ribbonControl1.SelectedPage = ribbonPage2;
        }
        HopDong _hopDong;
        void LoadHetHopDong()
        {
            _hopDong= new HopDong();
            listBoxControlHopDong.DataSource = _hopDong.getListHetHanHopDong();
            listBoxControlHopDong.ValueMember = "MANV";
            listBoxControlHopDong.DisplayMember = "HOTEN";
            listBoxControlHopDong.DisplayMember = "TenPhongBan";
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(BusinessLayer.Session.User.Role.ToString());
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            if (dockPanel1 != null)
            {
                //dockPanelThongBao.Visibility = Hidden;
            }
            LoadHetHopDong();
            _hopDong.CapNhatTrangThaiHopDong();// cập nhật xem các hợp đồng nào hết hạn
            // hiển thị thong tin người đăng nhập vào
            _nhanVien = new NhanVien();
            var nv_login = _nhanVien.getNhanVienDTO(Session.User.MANV);
            if(nv_login != null)
            {
                string inforLogIn = nv_login.HOTEN + "-" + nv_login.TENPB;
                lbInfor.Text = inforLogIn;
            }
            else
            {
                lbInfor.Text = "Giám Đốc";
            }
            switch (Session.User.Role)
            {
                case 0:
                    ribbonControl1.SelectedPage = ribbonNhanVien;
                    break;
                case 1:
                    _nhanVien = new NhanVien();
                    var nv = _nhanVien.FindMaNV(Session.User.MANV);
                    if (nv.IDPB == 6)// id 6 là phòng nhân sự
                    {
                        ribbonControl1.SelectedPage = ribbonNhanSu;
                        break;
                    }
                    else
                    {
                        ribbonControl1.SelectedPage = ribbonPageTruongPhuong;
                        break;
                    }               
                  
                case 2:
                    ribbonControl1.SelectedPage = ribbonGiamDoc;
                    break;
                default:
                    // Xử lý nếu có giá trị Role khác
                    ribbonControl1.SelectedPage = ribbonNhanVien;
                    break;
            }
            
        }

        private void btnTrinhDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formTrinhDo));
        }

        private void btnPhongBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formPhongBan));
        }

        private void btnCongTy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formCongTy));
        }

        private void btn_CongTy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formCongTy));
        }

        private void MainForm_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {

        }

        private void btnBoPhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formBoPhan));
        }

        private void btnChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formChucVu));
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formNhanVien));
        }

        private void btnHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formHopDong));
        }

        private void btnKhenThuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formKhenthuong));
        }

        private void btnKyLuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formKyLuat));
        }

        private void btnChuyenPhongLamVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formChuyenNhanVien));
        }

        private void btnNghiViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formThoiViec));
        }

        private void btnNangLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formNangLuong));
        }
        Function fct;
        private void simpleBtnXemtaiday_Click(object sender, EventArgs e)
        {
            formHopDong frmHD = new formHopDong();
            frmHD._TrangThaihopDong = 0;

            frmHD.ShowDialog();
            //onpenForm(typeof(formHopDong));
            fct = new Function();
            fct.checkhethanhopdong = 2;
        }

        private void btnLoaiCaLamViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formLoaiCa));
        }

        private void btnLLoaiCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formLoaiCong));
        }

        private void btnBangCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formBangCong));
        }

        private void btnPhuCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formPhuCap));
        }

        private void btnTangCaLamViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formTangCa));
        }

        private void btnUngLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formUngLuong));
        }

        private void btnBangCongChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formInBangCongNhanVien));
        }

        private void btnBangLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formBangLuong));
        }

        private void btnNhanVienXemKhenThuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formDanhSachKhenThuong));
        }

        private void btnNhanVienXemKyLuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formDanhSachKyLuat));
        }

        private void btnNhanVienXemHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formHopDongCuaNhanVien));
        }

        private void btnNhanVienXemPhuCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formPhuCapNhanVien));
        }

        private void btnAddPhuCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formAddPhuCapCTY));
        }

        private void btnNhanVienKyCongChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formXemBangLuongCuaNhanVien));
        }

        private void btnNhanVienXemTangCa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formNhanVienTangCa));
        }

        private void btnNhanVienXemBangLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formNhanVienXemBangLuong));
        }

        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formDoiMatKhau));
        }

        private void btnLogOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Session.User = null;
            onpenForm(typeof(formLogIn));
            this.Close();
           
        }

        private void btnThongTinTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formThongTinTaiKhoan));
        }

        private void btnDanhSachNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formDanhSachThanhVien));
        }

        private void btnThongTinNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formThongTinTaiKhoan));
        }

        private void btnDanhSachNhanVienCuaPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formDanhSachThanhVien));
        }

        private void btnDanhSachTruongPhuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            onpenForm(typeof(formThongTinCacTruongPhong));
        }
    }
}
