using BusinessLayer.Convert_DTO;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer.ClassChamCong
{
    public class PhuCap
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);
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
                hd_dto.ID = item.ID;
                hd_dto.IDPC = item.IDPC;
                hd_dto.MANV = item.MANV;
                hd_dto.NGAY = item.NGAY;
                hd_dto.NOIDUNG = item.NOIDUNG;
                hd_dto.SOTIEN = item.SOTIEN;
                hd_dto.TienToVND = item.SOTIEN.ToString("n0") + " VNĐ";
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



        // Lấy danh sách PhuCapInfo từ cơ sở dữ liệu
        public List<PhuCapInfo> GetDanhSachPhuCap()
        {
            List<PhuCapInfo> danhSachPhuCap = new List<PhuCapInfo>();

            danhSachPhuCap = hrm.tb_DANHSACHPHUCAP
                                .Select(pc => new PhuCapInfo
                                {
                                    IDPC = pc.ID,
                                    TenPhuCap = pc.TENPHUCAP,
                                    SoTienPhuCap = pc.SOTIENPHUCAP.ToString(),
                                })
                                .ToList();

            return danhSachPhuCap;
        }

        DanhSachPhuCap _dsPC = new DanhSachPhuCap();
        public List<DanhSachPhuCapDTO> PhuCamCuaNhanVien(int mnv)
        {

            var ListAllPhuCap = _dsPC.getListDTO();

            var listNvInPhuCap = getListDTO();
            foreach (var item in ListAllPhuCap)
            {
              
                if(listNvInPhuCap.FirstOrDefault(x=> x.IDPC == item.ID && x.MANV == mnv ) !=null) 
                {
                    item.TrangThaiPhuCap = "Đã hõ trợ";
                }
                else {
                    item.TrangThaiPhuCap = "Chữa hỗ trợ";
                }
            }
            return ListAllPhuCap;
        }

        // Hàm ADD thêm nhân viên bên Tầng BusinessLayer truyền vào kiểu dữ liệu dạng bảng data
        public tb_PHUCAP Them(tb_PHUCAP data)
        {
            try
            {
                hrm.tb_PHUCAP.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_PHUCAP Update(tb_PHUCAP data)
        {
            try
            {
                var row_update = hrm.tb_PHUCAP.FirstOrDefault(x => x.ID == data.ID);

                if (row_update != null)
                {
                    row_update.IDPC = data.IDPC;
                    row_update.TENPC = data.TENPC;
                    row_update.MANV = data.MANV;
                    row_update.SOTIEN = data.SOTIEN;
                    row_update.NGAY = data.NGAY;
                    row_update.CREATED_DATE = data.CREATED_DATE;
                    row_update.NOIDUNG = data.NOIDUNG;
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
        public tb_PHUCAP getItem(int id)
        {
            return hrm.tb_PHUCAP.FirstOrDefault(x => x.ID == id);
        }

        public tb_PHUCAP Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_PHUCAP.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_PHUCAP.Remove(row_to_delete);
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
            return hrm.tb_PHUCAP.Count();
        }
 
    }
}
