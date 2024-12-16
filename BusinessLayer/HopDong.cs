using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using Data_Layer;
namespace BusinessLayer
{
    public class HopDong
    {
       HRMEntities hrm = new HRMEntities(Session.CONN_STR);
        NhanVien _nv= new NhanVien();
        public List<HopDong_DTO> getHopDongFocus(int id_HopDong, List<HopDong_DTO> list)
        {
            // Tìm đối tượng HopDong_DTO trong danh sách có ID tương ứng
            HopDong_DTO hopDong = list.FirstOrDefault(hd => hd.ID == id_HopDong);
            List<HopDong_DTO> resultList = new List<HopDong_DTO>();
            if (hopDong != null)
            {
                resultList.Add(hopDong);
            }
            return resultList;
        }

        public List<decimal> getListMucLuong()
        {
            try
            {
                
                var list = hrm.tb_LUONGCOBAN
                            .Select(x => x.MUCLUONG)
                            .ToList();

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi khi truy vấn dữ liệu: " + e.Message);
                throw;
            }
        }


        public List<HopDong_DTO> getListDTO_HopDong()
        {
            var listHD = hrm.tb_HOPDONG.ToList();
            var listHD_DTO = new List<HopDong_DTO>();

            //goi tai day
            var lcb = new LuongCoBan();
            var _LuongCoBan = lcb.getLuongCoBan();
          
            CongTy ct = new CongTy();
            var CTY = ct.getCTYbyID(1234);
            string tenCT = CTY.TENCONGTY;
            string dcCTY = CTY.DIACHI;

            var ListMaNVs = listHD.Select(p => p.MANV).ToList();// list mã nhân viên
            NhanVien nv = new NhanVien();
            var ListIDPB = nv.getDanhSach().Select(p => p.IDPB).ToList();
            var nv_x = nv.FindMaNVs(ListMaNVs);

            foreach (var item in listHD)
            {
                var hd_dto = new HopDong_DTO();
                hd_dto.ID = item.ID;
                hd_dto.MAHOPDONG = item.MAHOPDONG;
                hd_dto.MANV= item.MANV;
                hd_dto.NGAYKY = item.NGAYKY;
                hd_dto.NGAYBATDAU= item.NGAYBATDAU;
                hd_dto.NGAYKETTHUC=item.NGAYKETTHUC;
                hd_dto.THOIHANHOPDONG= item.THOIHANHOPDONG;
                hd_dto.LUONGCOBAN= item.LUONGCOBAN;
                hd_dto.LANKY= item.LANKY;
                hd_dto.Ngay = item.NGAYBATDAU.Value.Day;
                hd_dto.Thang = item.NGAYBATDAU.Value.Month;
                hd_dto.Nam = item.NGAYBATDAU.Value.Year;
                hd_dto.TrangThai = item.TrangThai;
                if (item.TrangThai == 0)
                {
                    hd_dto.TenTrangThai = "HẾT HẠN";
                }
                else
                {
                    hd_dto.TenTrangThai = "CÒN HẠN";
                }
                var NhanVien = nv_x.FirstOrDefault(p => p.MANV == hd_dto.MANV);
                string SoCCCD = NhanVien?.CCCD ?? string.Empty;
                string DiaChi = NhanVien?.DIACHI ?? string.Empty;
                hd_dto.CCCD = SoCCCD;
                hd_dto.DIACHI = DiaChi;
                hd_dto.VaiTro = (int)NhanVien.ROLE;
                DateTime NgaySinh = NhanVien?.NGAYSINH ?? DateTime.Now;
                string TenNhanVien = NhanVien?.HOTEN ?? string.Empty;
                hd_dto.TenCongTY = tenCT;
                hd_dto.DiaChiCongTy = dcCTY;
                var pb = new PhongBan();
                hd_dto.TenPhongBan = pb.getItem((int)NhanVien.IDPB).TENPB.ToString();
                hd_dto.HOTEN = TenNhanVien;
                hd_dto.HESOLUONG = item.HESOLUONG;

                string lcb_x = item.LUONGCOBAN.Value.ToString("n0")+" VNĐ";
                hd_dto.LuongCoBan = lcb_x;
                //decimal LuongThang = _LuongCoBan * (decimal)item.HESOLUONG;
                //hd_dto.LuongHangThang = LuongThang.ToString("n0")+" VNĐ";
                listHD_DTO.Add(hd_dto);
            }

            return listHD_DTO;
        }

        public List<HopDong_DTO> getListHetHanHopDong()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Lấy danh sách các hợp đồng hết hạn trong tháng hiện tại
            var listHD = hrm.tb_HOPDONG
                           .Where(x => x.NGAYKETTHUC.HasValue &&
                                       x.NGAYKETTHUC.Value >= firstDayOfMonth &&
                                       x.NGAYKETTHUC.Value <= lastDayOfMonth )
                           .ToList();
            var listHD_DTO = new List<HopDong_DTO>();
            var lcb = new LuongCoBan();
            var _LuongCoBan = lcb.getLuongCoBan();

            CongTy ct = new CongTy();
            var CTY = ct.getCTYbyID(1234);
            string tenCT = CTY.TENCONGTY;
            string dcCTY = CTY.DIACHI;

            var ListMaNVs = listHD.Select(p => p.MANV).ToList();// list mã nhân viên
            NhanVien nv = new NhanVien();
            var ListIDPB = nv.getDanhSach().Select(p => p.IDPB).ToList();
            var nv_x = nv.FindMaNVs(ListMaNVs);

            foreach (var item in listHD)
            {
                var hd_dto = new HopDong_DTO();
                hd_dto.ID = item.ID;
                hd_dto.MAHOPDONG = item.MAHOPDONG;
                hd_dto.MANV = item.MANV;
                hd_dto.NGAYKY = item.NGAYKY;
                hd_dto.NGAYBATDAU = item.NGAYBATDAU;
                hd_dto.NGAYKETTHUC = item.NGAYKETTHUC;
                hd_dto.THOIHANHOPDONG = item.THOIHANHOPDONG;
                hd_dto.LANKY = item.LANKY;
                hd_dto.Ngay = item.NGAYBATDAU.Value.Day;
                hd_dto.Thang = item.NGAYBATDAU.Value.Month;
                hd_dto.Nam = item.NGAYBATDAU.Value.Year;
                hd_dto.TrangThai = item.TrangThai;
                if (item.TrangThai == 0)
                {
                    hd_dto.TenTrangThai = "HẾT HẠN";
                }
                else
                {
                    hd_dto.TenTrangThai = "CÒN HẠN";
                }
                var NhanVien = nv_x.FirstOrDefault(p => p.MANV == hd_dto.MANV);
                string SoCCCD = NhanVien?.CCCD ?? string.Empty;
                string DiaChi = NhanVien?.DIACHI ?? string.Empty;
                hd_dto.CCCD = SoCCCD;
                hd_dto.DIACHI = DiaChi;
                hd_dto.VaiTro = (int)NhanVien.ROLE;
                DateTime NgaySinh = NhanVien?.NGAYSINH ?? DateTime.Now;
                string TenNhanVien = NhanVien?.HOTEN ?? string.Empty;
                hd_dto.TenCongTY = tenCT;
                hd_dto.DiaChiCongTy = dcCTY;
                var pb = new PhongBan();
                hd_dto.TenPhongBan = pb.getItem((int)NhanVien.IDPB).TENPB.ToString();
                hd_dto.HOTEN = TenNhanVien;
                hd_dto.HESOLUONG = item.HESOLUONG;
                string lcb_x = _LuongCoBan.ToString("n0") + " VNĐ";
                hd_dto.LuongCoBan = lcb_x;
                decimal LuongThang = _LuongCoBan * (decimal)item.HESOLUONG;
                hd_dto.LuongHangThang = LuongThang.ToString("n0") + " VNĐ";
                listHD_DTO.Add(hd_dto);
            }

            return listHD_DTO;
        }
        public List<HopDong_DTO> getListHetHanHopDong_a()
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Lấy danh sách các hợp đồng hết hạn trong tháng hiện tại
            var listHD = hrm.tb_HOPDONG
                           .Where(x => x.NGAYKETTHUC.HasValue &&
                                       x.NGAYKETTHUC.Value >= firstDayOfMonth &&
                                       x.NGAYKETTHUC.Value <= lastDayOfMonth || x.TrangThai == 0)
                           .ToList();
            var listHD_DTO = new List<HopDong_DTO>();
            var lcb = new LuongCoBan();
            var _LuongCoBan = lcb.getLuongCoBan();

            CongTy ct = new CongTy();
            var CTY = ct.getCTYbyID(1234);
            string tenCT = CTY.TENCONGTY;
            string dcCTY = CTY.DIACHI;

            var ListMaNVs = listHD.Select(p => p.MANV).ToList();// list mã nhân viên
            NhanVien nv = new NhanVien();
            var ListIDPB = nv.getDanhSach().Select(p => p.IDPB).ToList();
            var nv_x = nv.FindMaNVs(ListMaNVs);

            foreach (var item in listHD)
            {
                var hd_dto = new HopDong_DTO();
                hd_dto.ID = item.ID;
                hd_dto.MAHOPDONG = item.MAHOPDONG;
                hd_dto.MANV = item.MANV;
                hd_dto.NGAYKY = item.NGAYKY;
                hd_dto.NGAYBATDAU = item.NGAYBATDAU;
                hd_dto.NGAYKETTHUC = item.NGAYKETTHUC;
                hd_dto.THOIHANHOPDONG = item.THOIHANHOPDONG;
                hd_dto.LANKY = item.LANKY;
                hd_dto.Ngay = item.NGAYBATDAU.Value.Day;
                hd_dto.Thang = item.NGAYBATDAU.Value.Month;
                hd_dto.Nam = item.NGAYBATDAU.Value.Year;
                hd_dto.TrangThai = item.TrangThai;
                if (item.TrangThai == 0)
                {
                    hd_dto.TenTrangThai = "HẾT HẠN";
                }
                else
                {
                    hd_dto.TenTrangThai = "CÒN HẠN";
                }
                var NhanVien = nv_x.FirstOrDefault(p => p.MANV == hd_dto.MANV);
                string SoCCCD = NhanVien?.CCCD ?? string.Empty;
                string DiaChi = NhanVien?.DIACHI ?? string.Empty;
                hd_dto.CCCD = SoCCCD;
                hd_dto.DIACHI = DiaChi;
                hd_dto.VaiTro = (int)NhanVien.ROLE;
                DateTime NgaySinh = NhanVien?.NGAYSINH ?? DateTime.Now;
                string TenNhanVien = NhanVien?.HOTEN ?? string.Empty;
                hd_dto.TenCongTY = tenCT;
                hd_dto.DiaChiCongTy = dcCTY;
                var pb = new PhongBan();
                hd_dto.TenPhongBan = pb.getItem((int)NhanVien.IDPB).TENPB.ToString();
                hd_dto.HOTEN = TenNhanVien;
                hd_dto.HESOLUONG = item.HESOLUONG;
                string lcb_x = _LuongCoBan.ToString("n0") + " VNĐ";
                hd_dto.LuongCoBan = lcb_x;
                decimal LuongThang = _LuongCoBan * (decimal)item.HESOLUONG;
                hd_dto.LuongHangThang = LuongThang.ToString("n0") + " VNĐ";
                listHD_DTO.Add(hd_dto);
            }

            return listHD_DTO;
        }

        public tb_HOPDONG FindMaMaHD(string mahopdong)
        {
            return hrm.tb_HOPDONG.FirstOrDefault(x => x.MAHOPDONG == mahopdong);
        }

        public tb_HOPDONG GetSoHopDongByMANV(int MANV)
        {
            return hrm.tb_HOPDONG.FirstOrDefault(x => x.MANV == MANV);
        }

        public tb_HOPDONG GetSoHopDongByMAHD(string SoHopDong)
        {
            return hrm.tb_HOPDONG.FirstOrDefault(x => x.MAHOPDONG == SoHopDong);
        }
        public List<tb_HOPDONG> getDanhSach()
        {
            return hrm.tb_HOPDONG.ToList();
        }

        // Hàm ADD thêm nhân viên bên Tầng BusinessLayer truyền vào kiểu dữ liệu dạng bảng data
        public tb_HOPDONG Them(tb_HOPDONG data)
        {
            try
            {
                hrm.tb_HOPDONG.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_HOPDONG Update(tb_HOPDONG data)
        {
            try
            {
                var row_update = hrm.tb_HOPDONG.FirstOrDefault(x => x.ID== data.ID);

                if (row_update != null)
                {
                    row_update.MAHOPDONG = data.MAHOPDONG;
                    row_update.NGAYBATDAU = data.NGAYBATDAU;
                    row_update.NGAYKETTHUC = data.NGAYKETTHUC;
                    row_update.NGAYKY = data.NGAYKY;
                    row_update.LANKY = data.LANKY;
                    row_update.NOIDUNG = data.NOIDUNG;
                    //row_update.HINHANH = data.HINHANH;
                    row_update.THOIHANHOPDONG = data.THOIHANHOPDONG;
                    row_update.HESOLUONG = data.HESOLUONG;
                    row_update.MANV = data.MANV;
                    row_update.MACTY = data.MACTY;
                    
                   
                    row_update.UPDATE_BY = data.UPDATE_BY;
                    row_update.UPDATE_DATE = data.UPDATE_DATE;

                    hrm.SaveChanges();
                    return data;
                }
                else
                {
                    throw new Exception("Bản ghi không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_HOPDONG getItem(int id)
        {
            return hrm.tb_HOPDONG.FirstOrDefault(x => x.ID == id);
        }
        
        public tb_HOPDONG FindHopDongByMaNV(int MaNV)
        {
            return hrm.tb_HOPDONG.FirstOrDefault(x => x.MANV == MaNV);
        }
       
        public tb_HOPDONG Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_HOPDONG.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_HOPDONG.Remove(row_to_delete);
                    //row_to_delete.DELETE_BY = MaNV;
                    row_to_delete.DELETE_DATE= DateTime.Now;
                    hrm.SaveChanges();
                    return row_to_delete;
                }
                else
                {
                    throw new Exception("Bản ghi không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);
            }
        }


        public void CapNhatTrangThaiHopDong()
        {
            try
            {
                var danhSachHopDong = hrm.tb_HOPDONG.ToList();

                foreach (var hopDong in danhSachHopDong)
                {
                    if (hopDong.NGAYBATDAU <= DateTime.Now && DateTime.Now <= hopDong.NGAYKETTHUC)
                    {
                        hopDong.TrangThai = 1; // Hợp đồng còn hiệu lực

                    }
                    else
                    {
                        hopDong.TrangThai = 0; // Hợp đồng đã hết hạn hoặc chưa bắt đầu
                        var nhanvienHetHopDong = _nv.FindMaNV((int)hopDong.MANV);

                        nhanvienHetHopDong.TrangThaiLamViec = 2;// trạng thái hết hợp đồng
                        _nv.Update(nhanvienHetHopDong);
                    }
                }

                hrm.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public int SoLuongHuongDong()
        {
            return hrm.tb_HOPDONG.Count();
        }
        public int getSoLuongHetHD()
        {
            return hrm.tb_HOPDONG.Count(hd => hd.TrangThai == 0);
        }

        public string MaHopDong()
        {
            var qd = hrm.tb_HOPDONG.OrderByDescending(x => x.CREATE_DATE).FirstOrDefault();
            if (qd != null)
            {
                return qd.MAHOPDONG.ToString();
            }
            else
            {
                return "000";
            }
        }
    }
}

