using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using Data_Layer;
namespace BusinessLayer
{
    public class NangLuong
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

        

        public List<NangLuong_DTO> getListDTO()
        {
            var listHD = hrm.tb_NANGLUONG.ToList();
            var listThoiViec_DTO = new List<NangLuong_DTO>();
            /*
            CongTy ct = new CongTy();
            var CTY = ct.getCTYbyID(1234);
            string tenCT = CTY.TENCONGTY;
            */

            NhanVien nv = new NhanVien();
            PhongBan pb = new PhongBan();
            HopDong hopDong;
            foreach (var item in listHD)
            {
                int i = 1;
                var hd_dto = new NangLuong_DTO();
                hd_dto.SOQUYETDINH = item.SOQUYETDINH;
                hd_dto.ID = item.ID;
                hd_dto.MANV = item.MANV;
                hd_dto.STT = i;
                hd_dto.NGAYKY = item.NGAYKY;
                hd_dto.NGAYLENLUONG=item.NGAYLENLUONG;
                hd_dto.CREATE_DATE = item.CREATE_DATE;
                hd_dto.UPDATE_DATE = item.UPDATE_DATE;
                hd_dto.GHICHU = item.GHICHU;
                hd_dto.HSLUONGCU = item.HSLUONGCU;
                hd_dto.HSLUONGMOI = item.HSLUONGMOI;
                var nhanVien = nv.FindMaNV((int)item.MANV);
                if (nhanVien != null)
                {
                    hd_dto.HOTEN = nhanVien.HOTEN;
                    var phongBan = pb.getItem((int)nhanVien.IDPB);
                    hopDong = new HopDong();
                    var dto_HD = hopDong.GetSoHopDongByMANV((int)item.MANV);
                    hd_dto.SoHopDong = dto_HD.MAHOPDONG.ToString();

                    if (phongBan != null)
                    {
                        hd_dto.PHONGBAN = phongBan.TENPB;
                    }
                }

                listThoiViec_DTO.Add(hd_dto);
            }

            return listThoiViec_DTO;
        }

        

        public List<tb_NANGLUONG> getDanhSach()
        {
            return hrm.tb_NANGLUONG.ToList();
        }

        // Hàm ADD thêm nhân viên bên Tầng BusinessLayer truyền vào kiểu dữ liệu dạng bảng data
        public tb_NANGLUONG Them(tb_NANGLUONG data)
        {
            try
            {
                hrm.tb_NANGLUONG.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_NANGLUONG Update(tb_NANGLUONG data)
        {
            try
            {
                var row_update = hrm.tb_NANGLUONG.FirstOrDefault(x => x.ID == data.ID);

                if (row_update != null)
                {
                    row_update.SOHOPDONG = data.SOHOPDONG;
                    row_update.HSLUONGCU = data.HSLUONGCU;
                    row_update.HSLUONGMOI = data.HSLUONGMOI;
                    row_update.NGAYKY = data.NGAYKY;
                    row_update.NGAYLENLUONG = data.NGAYLENLUONG;
                    row_update.CREATE_DATE = data.CREATE_DATE;
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
        public tb_NANGLUONG getItem(int id)
        {
            return hrm.tb_NANGLUONG.FirstOrDefault(x => x.ID == id);
        }

        public tb_NANGLUONG Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_NANGLUONG.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_NANGLUONG.Remove(row_to_delete);
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
            return hrm.tb_NANGLUONG.Count();
        }

        public string MaQuyetDinh()
        {
            if (hrm != null && hrm.tb_NANGLUONG.Any())
            {
                var qd = hrm.tb_NANGLUONG.OrderByDescending(x => x.CREATE_DATE).FirstOrDefault();
                if (qd != null && qd.SOQUYETDINH != null)
                {
                    return qd.SOQUYETDINH.ToString();
                }
            }
            return "000";
        }
    }
}
