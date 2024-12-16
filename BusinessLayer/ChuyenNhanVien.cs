using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using Data_Layer;
namespace BusinessLayer
{
    public class ChuyenNhanVien
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);

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

        
        public List<ChuyenNhanVien_DTO> getListDTO()
        {
            var listHD = hrm.tb_CHUYENNHANVIEN.ToList();
            var listChuyen_DTO = new List<ChuyenNhanVien_DTO>();

            NhanVien nv = new NhanVien();
            PhongBan pb = new PhongBan();
            foreach (var item in listHD)
            {
                var hd_dto = new ChuyenNhanVien_DTO();
                hd_dto.ID = item.ID;
                hd_dto.MANV = item.MANV;
                hd_dto.NGAY = item.NGAY;
                hd_dto.IDPBHIENTAI = item.IDPBHIENTAI;
                hd_dto.IDPHONGBANMOI = item.IDPHONGBANMOI;
                hd_dto.SOQUYETDINH = item.SOQUYETDINH;
                hd_dto.LYDO= item.LYDO;
                hd_dto.GHICHU=  item.GHICHU;
                var nhanVien = nv.FindMaNV((int)item.MANV);
                if (nhanVien != null)
                {
                    hd_dto.HOTEN = nhanVien.HOTEN;
                    var phongBan = pb.getItem((int)nhanVien.IDPB);

                    if (phongBan != null)
                    {
                        hd_dto.TenPhongBanCu = phongBan.TENPB;
                    }
                }
                hd_dto.TenPhongBanMoi = pb.getItem((int)item.IDPHONGBANMOI).TENPB;
                listChuyen_DTO.Add(hd_dto);
            }

            return listChuyen_DTO;
        }

        
        
        public List<tb_CHUYENNHANVIEN> getDanhSach()
        {
            return hrm.tb_CHUYENNHANVIEN.ToList();
        }

        // Hàm ADD thêm nhân viên bên Tầng BusinessLayer truyền vào kiểu dữ liệu dạng bảng data
        public tb_CHUYENNHANVIEN Them(tb_CHUYENNHANVIEN data)
        {
            try
            {
                hrm.tb_CHUYENNHANVIEN.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_CHUYENNHANVIEN Update(tb_CHUYENNHANVIEN data)
        {
            try
            {
                var row_update = hrm.tb_CHUYENNHANVIEN.FirstOrDefault(x => x.ID == data.ID);

                if (row_update != null)
                {
                    row_update.SOQUYETDINH = data.SOQUYETDINH;
                    row_update.MANV = data.MANV;
                    row_update.NGAY = data.NGAY;
                    row_update.IDPBHIENTAI = data.IDPBHIENTAI;
                    row_update.IDPHONGBANMOI = data.IDPHONGBANMOI;
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
        public tb_CHUYENNHANVIEN getItem(int id)
        {
            return hrm.tb_CHUYENNHANVIEN.FirstOrDefault(x => x.ID == id);
        }
        /*
        public tb_CHUYENNHANVIEN FindMaNV(int MaNV)
        {
            return hrm.tb_CHUYENNHANVIEN.FirstOrDefault(x => x.MANV == MaNV);
        }
        */
        public tb_CHUYENNHANVIEN Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_CHUYENNHANVIEN.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_CHUYENNHANVIEN.Remove(row_to_delete);
                    //row_to_delete.DELETE_BY = MaNV;
                    row_to_delete.DELETE_DATE = DateTime.Now;
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
            return hrm.tb_CHUYENNHANVIEN.Count();
        }

        public string MaQuyetDinh()
        {
            if (hrm != null && hrm.tb_CHUYENNHANVIEN.Any())
            {
                var qd = hrm.tb_CHUYENNHANVIEN.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
                if (qd != null && qd.SOQUYETDINH != null)
                {
                    return qd.SOQUYETDINH.ToString();
                }
            }
            return "000";
        }
    }
}
