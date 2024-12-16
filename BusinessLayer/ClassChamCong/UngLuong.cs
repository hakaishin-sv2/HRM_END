using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Convert_DTO;
using Data_Layer;
namespace BusinessLayer.ClassChamCong
{
    public class UngLuong
    {

        HRMEntities hrm = new HRMEntities(Session.CONN_STR);
        public List<UngLuong_DTO> getListDTO()
        {
            var listHD = hrm.tb_UNGLUONG.ToList();
            var listPhuCap_DTO = new List<UngLuong_DTO>();
            /*
            CongTy ct = new CongTy();
            var CTY = ct.getCTYbyID(1234);
            string tenCT = CTY.TENCONGTY;
            */
            NhanVien nv = new NhanVien();
            PhongBan pb = new PhongBan();
           
            foreach (var item in listHD)
            {
                var hd_dto = new UngLuong_DTO();
                hd_dto.ID = item.ID;
                hd_dto.MANV = item.MANV;
                hd_dto.NGAY = item.NGAY;
                hd_dto.THANG = item.THANG;
                hd_dto.NAM = item.NAM;
                hd_dto.GHICHU = item.GHICHU;
                hd_dto.CREATED_DATE = item.CREATED_DATE;
                hd_dto.SOTIENUNGLUONG= item.SOTIENUNGLUONG;
                double sotien = item.SOTIENUNGLUONG.HasValue ? item.SOTIENUNGLUONG.Value : 0.0;
                hd_dto.formattedSotien = sotien.ToString("n0") + " VNĐ";
                var nhanVien = nv.FindMaNV((int)item.MANV);
                if (nhanVien != null)
                {
                    hd_dto.HOTEN = nhanVien.HOTEN;
                    var phongBan = pb.getItem((int)nhanVien.IDPB);
                  
                    /*
                    hopDong = new HopDong();
                    var dto_HD = hopDong.GetSoHopDongByMANV((int)item.MANV);
                    hd_dto.SoHopDong = dto_HD.MAHOPDONG.ToString();
                    */
                    if (phongBan != null)
                    {
                        hd_dto.TENPB = phongBan.TENPB;
                    }
                }

                listPhuCap_DTO.Add(hd_dto);
            }

            return listPhuCap_DTO;
        }



        public List<tb_UNGLUONG> getDanhSach()
        {
            return hrm.tb_UNGLUONG.ToList();
        }

        // Hàm ADD thêm nhân viên bên Tầng BusinessLayer truyền vào kiểu dữ liệu dạng bảng data
        public tb_UNGLUONG Them(tb_UNGLUONG data)
        {
            try
            {
                hrm.tb_UNGLUONG.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_UNGLUONG Update(tb_UNGLUONG data)
        {
            try
            {
                var row_update = hrm.tb_UNGLUONG.FirstOrDefault(x => x.ID == data.ID);

                if (row_update != null)
                {
                    row_update.MANV = data.MANV;
                    row_update.SOTIENUNGLUONG = data.SOTIENUNGLUONG;
                    row_update.NGAY = data.NGAY;
                    row_update.THANG = data.THANG;
                    row_update.NAM = data.NAM;
                    row_update.UPDATED_DATE = data.UPDATED_DATE;
                    row_update.GHICHU = data.GHICHU;
                    //row_update.UPDATED_BY = data.UPDATED_BY;
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
        public tb_UNGLUONG getItem(int id)
        {
            return hrm.tb_UNGLUONG.FirstOrDefault(x => x.ID == id);
        }

        public tb_UNGLUONG Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_UNGLUONG.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_UNGLUONG.Remove(row_to_delete);
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
            return hrm.tb_UNGLUONG.Count();
        }

    }
}
