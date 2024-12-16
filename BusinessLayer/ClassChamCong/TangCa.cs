using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Convert_DTO;
using Data_Layer;
namespace BusinessLayer.ClassChamCong
{
    public class TangCa
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);
        public List<TangCa_DTO> getListDTO()
        {
            // Lấy toàn bộ danh sách từ bảng tb_TANGCA
            var listHD = hrm.tb_TANGCA.ToList();
            var listTangCa_DTO = new List<TangCa_DTO>();

            NhanVien nv = new NhanVien();
            LoaiCa loaiCa = new LoaiCa();
            PhongBan pb = new PhongBan();

            foreach (var item in listHD)
            {
                var hd_dto = new TangCa_DTO();
                hd_dto.ID = item.ID;
                hd_dto.IDLOAICA = item.IDLOAICA;
                hd_dto.NGAYTANGCA = item.NGAYTANGCA;
                hd_dto.THANG = item.THANG;
                hd_dto.NAM = item.NAM;
                hd_dto.MANV = item.MANV;
                hd_dto.GHICHU = item.GHICHU;
                hd_dto.SOGIO = item.SOGIO;
                hd_dto.SOTIEN = (float)item.SOTIEN;
                decimal tienTC = (decimal)item.SOTIEN;
                hd_dto.TienTangCa = tienTC.ToString("n0")+" VNĐ";
                hd_dto.DATE_TANGCA = item.DATE_TANGCA;
                var nhanVien = nv.FindMaNV((int)item.MANV);
                if (nhanVien != null)
                {
                    hd_dto.HOTEN = nhanVien.HOTEN;

                    var phongBan = pb.getItem((int)nhanVien.IDPB);
                    var lc = loaiCa.getItem(item.IDLOAICA);

                    if (lc != null)
                    {
                        hd_dto.TENLOAICA = lc.TENLOAICA;
                        hd_dto.HESO = (double)lc.HESO;
                    }

                    if (phongBan != null)
                    {
                        hd_dto.TENPB = phongBan.TENPB;
                        hd_dto.IDPB =phongBan.IDPB;
                    }
                }

                listTangCa_DTO.Add(hd_dto);
            }

            return listTangCa_DTO;
        }




        public List<tb_TANGCA> getDanhSach()
        {
            return hrm.tb_TANGCA.ToList();
        }

        // Hàm ADD thêm nhân viên bên Tầng BusinessLayer truyền vào kiểu dữ liệu dạng bảng data
        public tb_TANGCA Them(tb_TANGCA data)
        {
            try
            {
                hrm.tb_TANGCA.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_TANGCA Update(tb_TANGCA data)
        {
            try
            {
                var row_update = hrm.tb_TANGCA.FirstOrDefault(x => x.ID == data.ID);

                if (row_update != null)
                {
                    row_update.IDLOAICA = data.IDLOAICA;
                    row_update.NGAYTANGCA = data.NGAYTANGCA;
                    row_update.THANG = data.NGAYTANGCA;
                    row_update.NAM = data.NGAYTANGCA;
                    row_update.MANV = data.MANV;
                    row_update.GHICHU = data.GHICHU;
                    row_update.SOGIO = data.SOGIO;
                    row_update.DATE_TANGCA = data.DATE_TANGCA;
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

       

        public List<TangCa_DTO> getAllListTangCaByKyCong(int manv, int thang, int nam)
        {
            var list = new List<TangCa_DTO>();
            var listTcNv = hrm.tb_TANGCA.Where(x => x.MANV == manv && x.NAM == nam && x.THANG == thang).ToList();
            NhanVien nv = new NhanVien();
            LoaiCa loaiCa = new LoaiCa();
            PhongBan pb = new PhongBan();
            foreach (var item in listTcNv)
            {
                var hd_dto = new TangCa_DTO();
                hd_dto.ID = item.ID;
                hd_dto.IDLOAICA = item.IDLOAICA;
                hd_dto.NGAYTANGCA = item.NGAYTANGCA;
                hd_dto.THANG = item.THANG;
                hd_dto.NAM = item.NAM;
                hd_dto.MANV = item.MANV;
                hd_dto.GHICHU = item.GHICHU;
                hd_dto.SOGIO = item.SOGIO;
                hd_dto.SOTIEN = (float)item.SOTIEN;
                decimal tienTC = (decimal)item.SOTIEN;
                hd_dto.TienTangCa = tienTC.ToString("n0") + " VNĐ";
                hd_dto.DATE_TANGCA = item.DATE_TANGCA;
                var nhanVien = nv.FindMaNV((int)item.MANV);
                if (nhanVien != null)
                {
                    hd_dto.HOTEN = nhanVien.HOTEN;

                    var phongBan = pb.getItem((int)nhanVien.IDPB);
                    var lc = loaiCa.getItem(item.IDLOAICA);

                    if (lc != null)
                    {
                        hd_dto.TENLOAICA = lc.TENLOAICA;
                        hd_dto.HESO = (double)lc.HESO;
                    }

                    if (phongBan != null)
                    {
                        hd_dto.TENPB = phongBan.TENPB;
                        hd_dto.IDPB = phongBan.IDPB;
                    }
                }

                list.Add(hd_dto);
            }
             return list;
        }
        public tb_TANGCA getItem(int id)
        {
            return hrm.tb_TANGCA.FirstOrDefault(x => x.ID == id);
        }
        public tb_TANGCA getTangCaByMaNV(int manv)
        {
            return hrm.tb_TANGCA.FirstOrDefault(x => x.MANV == manv);
        }
        public tb_TANGCA Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_TANGCA.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_TANGCA.Remove(row_to_delete);
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
            return hrm.tb_TANGCA.Count();
        }

    }
}
