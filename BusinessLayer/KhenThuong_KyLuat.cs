using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using Data_Layer;
namespace BusinessLayer
{
    public class KhenThuong_KyLuat
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);

        public List<tb_KHENTHUONG_KYLUAT> getDanhSach(int Loai)
        {

            return hrm.tb_KHENTHUONG_KYLUAT.ToList();
        }
        public List<KhenThuong_kyluat_DTO> getListDTO_KTKL(int loai)
        {
            try
            {
                // Lấy dữ liệu khen thưởng/kỷ luật
                var listData = hrm.tb_KHENTHUONG_KYLUAT.ToList();
                var listKT_DTO = new List<KhenThuong_kyluat_DTO>();
                var listKL_DTO = new List<KhenThuong_kyluat_DTO>();
                NhanVien nv = new NhanVien();
                //var mlm = nv.getItem(3773);
                PhongBan pb = new PhongBan();
                foreach (var item in listData)
                {
                    int i = 1;
                    double converVND = (double)item.SOTIEN;
                    var hd_dto = new KhenThuong_kyluat_DTO
                    {
                        STT = i,
                        ID = item.ID,
                        SOQUYETDINH = item.SOQUYETDINH,
                        MANV = item.MANV,
                        TUNGAY = item.TUNGAY,
                        DENNGAY = item.DENNGAY,
                        NOIDUNG = item.NOIDUNG,
                        LYDO = item.LYDO,
                        NAM= item.NAM,
                        THANG= item.THANG,
                        SOTIEN= item.SOTIEN,  
                        SoTienString= converVND.ToString("n0")+" VNĐ",
                        Status_tb = item.Status_tb,
                        LOAI = item.LOAI,
                        CREATED_DATE = item.CREATED_DATE
                    };
                    // Lấy thông tin nhân viên dựa trên MANV
                    var nhanVien = nv.FindMaNV((int)item.MANV);
                    if (nhanVien != null)
                    {
                        hd_dto.HOTEN = nhanVien.HOTEN;
                        var phongBan = pb.getItem((int)nhanVien.IDPB);
                        
                        if (phongBan != null)
                        {
                            hd_dto.TenPhongBan = phongBan.TENPB;
                        }
                    }   
                    if (item.LOAI == 1)
                    {  
                        listKT_DTO.Add(hd_dto);
                    }
                    else
                    {
                        listKL_DTO.Add(hd_dto);
                    }
                    i++;
                }
                return loai == 1 ? listKT_DTO : listKL_DTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách DTO KTKL: " + ex.Message, ex);
            }
        }
        public tb_KHENTHUONG_KYLUAT Them(tb_KHENTHUONG_KYLUAT data)
        {
            try
            {
                hrm.tb_KHENTHUONG_KYLUAT.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_KHENTHUONG_KYLUAT Update(tb_KHENTHUONG_KYLUAT data)
        {
            try
            {
                var row_update = hrm.tb_KHENTHUONG_KYLUAT.FirstOrDefault(x => x.ID == data.ID);

                if (row_update != null)
                {
                    row_update.LYDO = data.LYDO;
                    row_update.NOIDUNG = data.NOIDUNG;
                    //row_update.TUNGAY = data.TUNGAY;
                    //row_update.DENNGAY = data.DENNGAY;
                    row_update.MANV = data.MANV;
                    row_update.NAM = data.NAM;
                    row_update.THANG = data.THANG;
                    row_update.SOTIEN = data.SOTIEN;
                    //row_update.LOAI = data.LOAI;
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
        public tb_KHENTHUONG_KYLUAT getItem(int id)
        {
            return hrm.tb_KHENTHUONG_KYLUAT.FirstOrDefault(x => x.ID == id);
        }
        public tb_KHENTHUONG_KYLUAT Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_KHENTHUONG_KYLUAT.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_KHENTHUONG_KYLUAT.Remove(row_to_delete);
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
        public int SoLuongKhenThuong(int Loai)
        {
            return hrm.tb_KHENTHUONG_KYLUAT.Where(x=> x.LOAI == Loai).Count();
        }

        public string MaQuyetDinh(int Loai)
        {
            var qd = hrm.tb_KHENTHUONG_KYLUAT.Where(x=> x.LOAI== Loai).OrderByDescending(x=> x.CREATED_DATE).FirstOrDefault();
            if(qd != null)
            {
                return qd.SOQUYETDINH.ToString();
            }
            else
            {
                return "000";
            }
        }



        // 1 số hàm ROLE nhân viên

        public List<KhenThuong_kyluat_DTO> getListDTO_ROLE_NHANVIEN(int loai, int thang, int nam)
        {
            try
            {
                // Lấy dữ liệu khen thưởng/kỷ luật
                var listData = hrm.tb_KHENTHUONG_KYLUAT.Where(x=> x.TUNGAY.Value.Year == nam && x.TUNGAY.Value.Month == thang && x.LOAI == loai);
                var listKT_DTO = new List<KhenThuong_kyluat_DTO>();
                var listKL_DTO = new List<KhenThuong_kyluat_DTO>();
                NhanVien nv = new NhanVien();
                //var mlm = nv.getItem(3773);
                PhongBan pb = new PhongBan();
                foreach (var item in listData)
                {
                    int i = 1;
                    double converVND = (double)item.SOTIEN;
                    var hd_dto = new KhenThuong_kyluat_DTO
                    {
                        STT = i,
                        ID = item.ID,
                        SOQUYETDINH = item.SOQUYETDINH,
                        MANV = item.MANV,
                        TUNGAY = item.TUNGAY,
                        DENNGAY = item.DENNGAY,
                        NOIDUNG = item.NOIDUNG,
                        LYDO = item.LYDO,
                        NAM = item.NAM,
                        THANG = item.THANG,
                        SOTIEN = item.SOTIEN,
                        SoTienString = converVND.ToString("n0") + " VNĐ",
                        Status_tb = item.Status_tb,
                        LOAI = item.LOAI,
                        CREATED_DATE = item.CREATED_DATE
                    };
                    // Lấy thông tin nhân viên dựa trên MANV
                    var nhanVien = nv.FindMaNV((int)item.MANV);
                    if (nhanVien != null)
                    {
                        hd_dto.HOTEN = nhanVien.HOTEN;
                        var phongBan = pb.getItem((int)nhanVien.IDPB);

                        if (phongBan != null)
                        {
                            hd_dto.TenPhongBan = phongBan.TENPB;
                        }
                    }
                    if (item.LOAI == 1)
                    {
                        listKT_DTO.Add(hd_dto);
                    }
                    else
                    {
                        listKL_DTO.Add(hd_dto);
                    }
                    i++;
                }
                return loai == 1 ? listKT_DTO : listKL_DTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách DTO KTKL: " + ex.Message, ex);
            }
        }
    }
}
