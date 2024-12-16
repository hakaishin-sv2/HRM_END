using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using Data_Layer;
namespace BusinessLayer
{
    public class ThoiViec
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);


        public List<ThoiViec_DTO> getRowFocus(int id, List<ThoiViec_DTO> list)
        {
            // Tìm đối tượng HopDong_DTO trong danh sách có ID tương ứng
            ThoiViec_DTO hopDong = list.FirstOrDefault(hd => hd.ID == id);
            List<ThoiViec_DTO> resultList = new List<ThoiViec_DTO>();
            if (hopDong != null)
            {
                resultList.Add(hopDong);
            }
            return resultList;
        }


        public List<ThoiViec_DTO> getListDTO()
        {
            var listHD = hrm.tb_THOIVIEC.ToList();
            var listThoiViec_DTO = new List<ThoiViec_DTO>();

            CongTy ct = new CongTy();
            var CTY = ct.getCTYbyID(1234);
            string tenCT = CTY.TENCONGTY;
            
            NhanVien nv = new NhanVien();
            PhongBan pb = new PhongBan();
            ChucVu chucVu = new ChucVu();
            HopDong hopDong ;
            foreach (var item in listHD)
            {
                var hd_dto = new ThoiViec_DTO();
                hd_dto.ID = item.ID;
                hd_dto.MANV = item.MANV;
                hd_dto.TencongTy = tenCT;
                hd_dto.SOQUETDINH = item.SOQUETDINH;
                hd_dto.NGAYNOPDON = item.NGAYNOPDON;
                hd_dto.NGAYNGHI = item.NGAYNGHI;
                hd_dto.LYDO = item.LYDO;
                hd_dto.GHICHU = item.GHICHU;
                var nhanVien = nv.FindMaNV((int)item.MANV);
                if (nhanVien != null)
                {
                    hd_dto.HOTEN = nhanVien.HOTEN;
                    var phongBan = pb.getItem((int)nhanVien.IDPB);
                    var cv = chucVu.getItem((int)nhanVien.IDCV);
                    hd_dto.TENCV = cv.TENCV;
                    hopDong = new HopDong();
                    
                    hd_dto.dayNghiViec= item.NGAYNGHI.Value.Day.ToString();
                    hd_dto.monthNghiViec= item.NGAYNGHI.Value.Month.ToString();
                    hd_dto.yearNghiViec= item.NGAYNGHI.Value.Year.ToString();

                    if (phongBan != null)
                    {
                        hd_dto.TenPhongBan = phongBan.TENPB;
                    }
                }
               
                listThoiViec_DTO.Add(hd_dto);
            }

            return listThoiViec_DTO;
        }

        public List<ThoiViec_DTO> getListDTOQuetDinhThoiViec()
        {
            var listHD = hrm.tb_THOIVIEC.ToList();
            var listThoiViec_DTO = new List<ThoiViec_DTO>();

            CongTy ct = new CongTy();
            var CTY = ct.getCTYbyID(1234);
            string tenCT = CTY.TENCONGTY;

            NhanVien nv = new NhanVien();
            PhongBan pb = new PhongBan();
            ChucVu chucVu = new ChucVu();
            HopDong hopDong;
            foreach (var item in listHD)
            {
                var hd_dto = new ThoiViec_DTO();
                hd_dto.ID = item.ID;
                hd_dto.MANV = item.MANV;
                hd_dto.TencongTy = tenCT;
                hd_dto.SOQUETDINH = item.SOQUETDINH;
                hd_dto.NGAYNOPDON = item.NGAYNOPDON;
                hd_dto.NGAYNGHI = item.NGAYNGHI;
                hd_dto.LYDO = item.LYDO;
                hd_dto.GHICHU = item.GHICHU;
                var nhanVien = nv.FindMaNV((int)item.MANV);
                if (nhanVien != null)
                {
                    hd_dto.HOTEN = nhanVien.HOTEN;
                    var phongBan = pb.getItem((int)nhanVien.IDPB);
                    var cv = chucVu.getItem((int)nhanVien.IDCV);
                    hd_dto.TENCV = cv.TENCV;
                    hopDong = new HopDong();
                    var dto_HD = hopDong.GetSoHopDongByMANV((int)item.MANV);
                    hd_dto.SoHopDong = dto_HD.MAHOPDONG.ToString();

                    DateTime NgayHD = dto_HD.NGAYBATDAU.Value;
                    hd_dto.NgayHopDong = NgayHD.Day.ToString();
                    hd_dto.ThangHopDong = NgayHD.Month.ToString();
                    hd_dto.NamHopDong = NgayHD.Year.ToString();

                    hd_dto.dayNghiViec = item.NGAYNGHI.Value.Day.ToString();
                    hd_dto.monthNghiViec = item.NGAYNGHI.Value.Month.ToString();
                    hd_dto.yearNghiViec = item.NGAYNGHI.Value.Year.ToString();

                    if (phongBan != null)
                    {
                        hd_dto.TenPhongBan = phongBan.TENPB;
                    }
                }

                listThoiViec_DTO.Add(hd_dto);
            }

            return listThoiViec_DTO;
        }


        public List<tb_THOIVIEC> getDanhSach()
        {
            return hrm.tb_THOIVIEC.ToList();
        }

        // Hàm ADD thêm nhân viên bên Tầng BusinessLayer truyền vào kiểu dữ liệu dạng bảng data
        public tb_THOIVIEC Them(tb_THOIVIEC data)
        {
            try
            {
                hrm.tb_THOIVIEC.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_THOIVIEC Update(tb_THOIVIEC data)
        {
            try
            {
                var row_update = hrm.tb_THOIVIEC.FirstOrDefault(x => x.ID == data.ID);

                if (row_update != null)
                {
                    row_update.SOQUETDINH = data.SOQUETDINH;
                    row_update.MANV = data.MANV;
                    row_update.NGAYNOPDON = data.NGAYNOPDON;
                    row_update.NGAYNGHI = data.NGAYNGHI;
                    row_update.CREATED_DATE = data.CREATED_DATE;
                    row_update.LYDO = data.LYDO;
                    //row_update.HINHANH = data.HINHANH;
                    row_update.GHICHU = data.GHICHU;
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
        public tb_THOIVIEC getItem(int id)
        {
            return hrm.tb_THOIVIEC.FirstOrDefault(x => x.ID == id);
        }
       
        public tb_THOIVIEC Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_THOIVIEC.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_THOIVIEC.Remove(row_to_delete);
                    //row_to_delete.DELETE_BY = MaNV;
                    //row_to_delete.DELETE_DATE = DateTime.Now;
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



        public int SoLuong()
        {
            return hrm.tb_THOIVIEC.Count();
        }

        public string MaQuyetDinh()
        {
            if (hrm != null && hrm.tb_THOIVIEC.Any())
            {
                var qd = hrm.tb_THOIVIEC.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
                if (qd != null && qd.SOQUETDINH != null)
                {
                    return qd.SOQUETDINH.ToString();
                }
            }
            return "000";
        }
    }
}
