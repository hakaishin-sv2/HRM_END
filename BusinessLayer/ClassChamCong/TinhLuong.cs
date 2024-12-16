using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Convert_DTO;
using Data_Layer;
namespace BusinessLayer.ClassChamCong
{
    public class TinhLuong
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);


        public void TinhLuongNhanVien(string makycong)
        {
            double luongngayThuong, luongPhep, luongTangCa, luongChuNhat, luongNgayLe, Tienphucap, Tienungluong, hesoluong, Tientangca, TienKhenThuong, TienKyLuat, ThucLanh;

            var listNv = hrm.tb_NHANVIEN.Where(x => x.TrangThaiLamViec == 1).ToList();

            foreach (var item in listNv)
            {
                var hd = hrm.tb_HOPDONG.FirstOrDefault(x => x.MANV == item.MANV);
                var kcct = hrm.tb_KYCONGCHITIET.FirstOrDefault(x => x.MAKYCONG == makycong && x.MANV == item.MANV);

                if (kcct == null)
                {
                    // Xử lý cho nhân viên chưa có kỳ công chi tiết cho tháng đó
                    continue;
                }

                if (hd != null)
                {
                    // Lấy hệ số lương mới nếu có tăng lương
                    var nangLuong = hrm.tb_NANGLUONG.OrderByDescending(x => x.NGAYKY).FirstOrDefault(x => x.SOHOPDONG == hd.MAHOPDONG);
                    hesoluong = nangLuong != null ? (double)nangLuong.HSLUONGMOI : (double)hd.HESOLUONG;

                    // Tính toán ngày công
                    int nam = int.Parse(makycong.Substring(0, 4));
                    int thang = int.Parse(makycong.Substring(6));

                    double soNgayThuong = (kcct.NGAYCONG ?? 0) - (kcct.CONGCHUNHAT ?? 0) - (kcct.CONGNGAYLE ?? 0) - (kcct.NGAYPHEP ?? 0);
                    var luong1ngay = ((double)hd.LUONGCOBAN * hesoluong) / (kcct.NGAYCONG ?? 1); // Đảm bảo NGAYCONG không là 0

                    // Tính lương các loại
                    luongngayThuong = soNgayThuong * luong1ngay;
                    luongChuNhat = (kcct.CONGCHUNHAT ?? 0) * luong1ngay * 1.5;
                    luongPhep = (kcct.NGAYPHEP ?? 0) * luong1ngay * 0.3;
                    luongNgayLe = (kcct.CONGNGAYLE ?? 0) * luong1ngay * 3;

                    // Tính các khoản tiền khác
                    var tangcanv = hrm.tb_TANGCA.Where(x => x.NAM == nam && x.THANG == thang && x.MANV == item.MANV).Sum(x => (double?)x.SOTIEN) ?? 0;
                    Tientangca = tangcanv;
                    Tienphucap = hrm.tb_PHUCAP.Where(x => x.MANV == item.MANV).Sum(x => (double?)x.SOTIEN) ?? 0;
                    Tienungluong = hrm.tb_UNGLUONG.Where(x => x.MANV == item.MANV && x.NAM == nam && x.THANG == thang).Sum(x => (double?)x.SOTIENUNGLUONG) ?? 0;
                    TienKhenThuong = hrm.tb_KHENTHUONG_KYLUAT.Where(x => x.LOAI == 1 && x.MANV == item.MANV && x.THANG == thang && x.NAM == nam).Sum(x => (double?)x.SOTIEN) ?? 0;
                    TienKyLuat = hrm.tb_KHENTHUONG_KYLUAT.Where(x => x.LOAI == 0 && x.MANV == item.MANV && x.THANG == thang && x.NAM == nam).Sum(x => (double?)x.SOTIEN) ?? 0;

                    // Tính lương thực lãnh
                    ThucLanh = (luongngayThuong + luongChuNhat + luongPhep + luongNgayLe + Tientangca + Tienphucap + TienKhenThuong) - Tienungluong - TienKyLuat;

                    // Tạo bản ghi bảng lương
                    tb_BANGLUONG bangLuong = new tb_BANGLUONG
                    {
                        MAKYCONG = makycong,
                        MANV = item.MANV,
                        HOTEN = item.HOTEN,
                        NGAYCONGTRONGTHANG = soNgayThuong,
                        LUONGNGAYPHEP = luongPhep,
                        LUONGNGAYKHONGPHEP = 0,
                        LUONGNGAYLE = luongNgayLe,
                        LUONGNGAYCHUNHAT = luongChuNhat,
                        UNGLUONG = Tienungluong,
                        PHUCAP = Tienphucap,
                        LUONGTANGCA = Tientangca,
                        LUONGNGAYTHUONG = luongngayThuong,
                        LUONGTHUCLANH = ThucLanh,
                        SOTIENKHENTHUONG = TienKhenThuong,
                        SOTIENKYLUAT = TienKyLuat,
                        CREATED_DATE = DateTime.Now
                    };

                    Add(bangLuong);
                }
            }
        }


        public List<TinhluongDTO> GetBangTinhluongDTOs(string makycong)
        {
            var list = hrm.tb_BANGLUONG.Where(x=> x.MAKYCONG == makycong).ToList();
            
            List<TinhluongDTO> danhSachDTOBangLuong = new List<TinhluongDTO>();
            NhanVien nv = new NhanVien();
            PhongBan pb = new PhongBan();

           
            foreach (var item in list)
            {
                var hd_dto = new TinhluongDTO();
                int i = 0;
                hd_dto.STT = i;
                i++;
                hd_dto.ID = item.ID;
                hd_dto.MAKYCONG = item.MAKYCONG;
                hd_dto.MANV= item.MANV;
                var nhanVien = nv.FindMaNV((int)item.MANV);
                if (nhanVien != null)
                {
                    var phongBan = pb.getItem((int)nhanVien.IDPB);
                    if (phongBan != null)
                    {
                        hd_dto.TENPB = phongBan.TENPB;
                    }

                }
                hd_dto.HOTEN= item.HOTEN;
                hd_dto.NGAYCONGTRONGTHANG= item.NGAYCONGTRONGTHANG;
                hd_dto.LUONGNGAYPHEP= item.LUONGNGAYPHEP;
                hd_dto.LUONGNGAYKHONGPHEP= item.LUONGNGAYKHONGPHEP;
                hd_dto.LUONGNGAYCHUNHAT= item.LUONGNGAYCHUNHAT;
                hd_dto.LUONGNGAYLE = item.LUONGNGAYLE;
                hd_dto.LUONGNGAYTHUONG= item.LUONGNGAYTHUONG;
                hd_dto.LUONGTHUCLANH = item.LUONGTHUCLANH;
                hd_dto.LUONGTANGCA = item.LUONGTANGCA;
                hd_dto.UNGLUONG = item.UNGLUONG;
                hd_dto.PHUCAP = item.PHUCAP;
                hd_dto.EMAIL = nhanVien.EMAIL;
                hd_dto.SOTIENKHENTHUONG = item.SOTIENKHENTHUONG;
                hd_dto.SOTIENKYLUAT = item.SOTIENKYLUAT;
                hd_dto.CREATED_DATE = item.CREATED_DATE;
                danhSachDTOBangLuong.Add(hd_dto);
            }
            return danhSachDTOBangLuong;
        }


        // chỉ cho riêng nhân viên cụ thể
        public List<TinhluongDTO> getBangLuongByMaNv(string makycong, int manv)
        {
            var list = hrm.tb_BANGLUONG
                           .Where(x => x.MAKYCONG == makycong && x.MANV == manv)
                           .ToList();

            List<TinhluongDTO> danhSachDTOBangLuong = new List<TinhluongDTO>();
            NhanVien nv = new NhanVien();
            PhongBan pb = new PhongBan();
            int i = 0; // Di chuyển biến i ra ngoài vòng lặp để tránh reset nó trong mỗi vòng lặp

            foreach (var item in list)
            {
                var hd_dto = new TinhluongDTO
                {
                    STT = i,
                    ID = item.ID,
                    MAKYCONG = item.MAKYCONG,
                    MANV = item.MANV,
                    HOTEN = item.HOTEN,
                    NGAYCONGTRONGTHANG = item.NGAYCONGTRONGTHANG,
                    LUONGNGAYPHEP = item.LUONGNGAYPHEP,
                    LUONGNGAYKHONGPHEP = item.LUONGNGAYKHONGPHEP,
                    LUONGNGAYCHUNHAT = item.LUONGNGAYCHUNHAT,
                    LUONGNGAYLE = item.LUONGNGAYLE,
                    LUONGNGAYTHUONG = item.LUONGNGAYTHUONG,
                    LUONGTHUCLANH = item.LUONGTHUCLANH,
                    LUONGTANGCA = item.LUONGTANGCA,
                    UNGLUONG = item.UNGLUONG,
                    PHUCAP = item.PHUCAP,
                    SOTIENKHENTHUONG = item.SOTIENKHENTHUONG,
                    SOTIENKYLUAT = item.SOTIENKYLUAT,
                    CREATED_DATE = item.CREATED_DATE
                };

                // Tìm nhân viên
                var nhanVien = nv.FindMaNV(item.MANV ?? 0);
                if (nhanVien != null)
                {
                    // Tìm phòng ban
                    var phongBan = pb.getItem(nhanVien.IDPB ?? 0);
                    if (phongBan != null)
                    {
                        hd_dto.TENPB = phongBan.TENPB;
                    }
                }

                danhSachDTOBangLuong.Add(hd_dto);
                i++; // Tăng giá trị của i sau mỗi lần lặp
            }

            return danhSachDTOBangLuong;
        }

        public List<string> GetMaKyCongList()
        {
            try
            {
                // Truy vấn cột MAKYCONG từ bảng tb_KYCONG với điều kiện TRANGTHAI = 1 tức là đã phát sinh
                var list = hrm.tb_KYCONG
                            .OrderByDescending(x=> x.CREATED_DATE)
                            .Where(kc => kc.TRANGTHAI == 1)
                            .Select(kc => kc.MAKYCONG)
                            .ToList();

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi khi truy vấn dữ liệu: " + e.Message);
                throw;
            }
        }

        public bool checkTinhLuongchua(string makycong)
        {
            var result = hrm.tb_BANGLUONG.FirstOrDefault(x => x.MAKYCONG == makycong);
            if( result == null)
            {
                return false;
            }
            return true;
        }
        public List<PhuCap_DTO> getListDTO()
        {
            var listHD = hrm.tb_PHUCAP.ToList();
            var listPhuCap_DTO = new List<PhuCap_DTO>();
            /*
            CongTy ct = new CongTy();
            var CTY = ct.getCTYbyID(1234);
            string tenCT = CTY.TENCONGTY;
            */
                NhanVien nv = new NhanVien();
                PhongBan pb = new PhongBan();
                ChucVu chucVu = new ChucVu();
                HopDong hopDong;
                foreach (var item in listHD)
                {
                    var hd_dto = new PhuCap_DTO();
                    hd_dto.IDPC = item.IDPC;
                    hd_dto.MANV = item.MANV;
                    hd_dto.NGAY = item.NGAY;
                    hd_dto.NOIDUNG = item.NOIDUNG;
                    hd_dto.SOTIEN = item.SOTIEN;
                    hd_dto.TENPC = item.TENPC;

                    var nhanVien = nv.FindMaNV((int)item.MANV);
                    if (nhanVien != null)
                    {
                        hd_dto.HOTEN = nhanVien.HOTEN;
                        var phongBan = pb.getItem((int)nhanVien.IDPB);
                        var cv = chucVu.getItem((int)nhanVien.IDCV);
                        hd_dto.TENCV = cv.TENCV;
                        /*
                        hopDong = new HopDong();
                        var dto_HD = hopDong.GetSoHopDongByMANV((int)item.MANV);
                        hd_dto.SoHopDong = dto_HD.MAHOPDONG.ToString();
                        */
                        if (phongBan != null)
                        {
                            hd_dto.TenPhongBan = phongBan.TENPB;
                        }
                    }

                    listPhuCap_DTO.Add(hd_dto);
                }

                return listPhuCap_DTO;
            }


            public tb_BANGLUONG getItem(string makycong, int mnv)
            {
                return hrm.tb_BANGLUONG.FirstOrDefault(x => x.MAKYCONG == makycong && x.MANV == mnv);
            }

            public tb_BANGLUONG Add(tb_BANGLUONG bangLuong)
            {
                try
                {
                    hrm.tb_BANGLUONG.Add(bangLuong);
                    hrm.SaveChanges();
                    return bangLuong;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi: " + ex.Message);
                }
            }

            public tb_BANGLUONG Update(tb_BANGLUONG data)
            {
                try
                {
                    tb_BANGLUONG LuongNv = hrm.tb_BANGLUONG.FirstOrDefault(x => x.MAKYCONG == data.MAKYCONG && x.MANV == data.MANV);
                    LuongNv.MANV = data.MANV;
                    LuongNv.HOTEN = data.HOTEN;
                    LuongNv.CREATED_DATE = data.CREATED_DATE;
                    LuongNv.NGAYCONGTRONGTHANG = data.NGAYCONGTRONGTHANG;
                    LuongNv.LUONGNGAYTHUONG = data.LUONGNGAYTHUONG;
                    LuongNv.LUONGNGAYPHEP = data.LUONGNGAYPHEP;
                    LuongNv.LUONGNGAYKHONGPHEP = data.LUONGNGAYKHONGPHEP;
                    LuongNv.LUONGNGAYLE = data.LUONGNGAYLE;
                    LuongNv.LUONGNGAYCHUNHAT = data.LUONGNGAYCHUNHAT;
                    LuongNv.LUONGTHUCLANH = data.LUONGTHUCLANH;
                    LuongNv.UNGLUONG = data.UNGLUONG;
                    LuongNv.LUONGTANGCA = data.LUONGTANGCA;
                    LuongNv.PHUCAP = data.PHUCAP;
                    LuongNv.SOTIENKHENTHUONG = data.SOTIENKHENTHUONG;
                    LuongNv.SOTIENKYLUAT = data.SOTIENKYLUAT;
                    hrm.SaveChanges();
                    return LuongNv;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
     
 }
 
