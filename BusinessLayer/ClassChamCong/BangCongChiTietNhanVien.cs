using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Convert_DTO;
using Data_Layer;
namespace BusinessLayer.ClassChamCong
{
    public class BangCongChiTietNhanVien
    {

        HRMEntities hrm = new HRMEntities(Session.CONN_STR);
        public  List<string> GetMaKyCongList()
        {
            try
            {
                // Truy vấn cột MAKYCONG từ bảng tb_KYCONG với điều kiện TRANGTHAI = 1
                var list = hrm.tb_KYCONG.OrderByDescending(x=>x.CREATED_DATE)
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

        public List<BangCongchiTietNhanVienDTO> getListDTO(string makycong, int manv)
        {
            var listHD = hrm.tb_BANGCONG_CHITIET.Where(x => x.MAKYCONG == makycong && x.MANV == manv).ToList();
            var listBangCong_DTO = new List<BangCongchiTietNhanVienDTO>();

            BangCongChiTietNhanVien bcct;
            foreach (var item in listHD)
            {
                var hd_dto = new BangCongchiTietNhanVienDTO();
                hd_dto.ID = item.ID;
                hd_dto.MANV = item.MANV;
                hd_dto.HOTEN = item.HOTEN;
                hd_dto.NGAY = item.NGAY;
                hd_dto.MAKYCONG = item.MAKYCONG;
                hd_dto.UPDATED_DATE = item.UPDATED_DATE;
                hd_dto.GHICHU = item.GHICHU;
                hd_dto.CREATED_DATE = item.CREATED_DATE;
                hd_dto.CONGCHUNHAT = item.CONGCHUNHAT;
                hd_dto.CONGNGAYLE = item.CONGNGAYLE;
                hd_dto.NGAYCONGTRONGNGAY = item.NGAYCONGTRONGNGAY;
                hd_dto.NGAYPHEP = item.NGAYPHEP;
                hd_dto.KYHIEU = item.KYHIEU;
                hd_dto.THU = item.THU;
                hd_dto.GIOVAO = item.GIOVAO;
                hd_dto.GIORA = item.GIORA;

                bcct = new BangCongChiTietNhanVien();
                hd_dto.TongChuNhat  = bcct.TongNgayChuNhat(item.MAKYCONG,(int)item.MANV);
                hd_dto.TongNgayLe   = bcct.TongNgayLe(item.MAKYCONG, (int)item.MANV);
                hd_dto.TongNgayPhep = bcct.TongNgayPhep(item.MAKYCONG, (int)item.MANV);
                hd_dto.TongNgayCong = bcct.TongNgayCong(item.MAKYCONG, (int)item.MANV) + hd_dto.TongChuNhat;

                listBangCong_DTO.Add(hd_dto);
            }

            return listBangCong_DTO;
        }
        public List<tb_BANGCONG_CHITIET> GetBangCongCuaNhanVien(string makycong,int manv)
        {
            return hrm.tb_BANGCONG_CHITIET.Where(x=> x.MAKYCONG == makycong && x.MANV == manv).ToList();
        }
        public tb_BANGCONG_CHITIET getItem(string makycong , int mnv , int ngay)
        {
            return hrm.tb_BANGCONG_CHITIET.FirstOrDefault(x => x.MAKYCONG == makycong && x.MANV == mnv && x.NGAY.Value.Day == ngay);
        }
        public tb_BANGCONG_CHITIET Add(tb_BANGCONG_CHITIET bcct)
        {
            try
            {
                hrm.tb_BANGCONG_CHITIET.Add(bcct);
                hrm.SaveChanges();
                return bcct;
            }catch (Exception ex)
            {
                throw new Exception("Lỗi: "+ex.Message);
            }
        }

        public tb_BANGCONG_CHITIET Update(tb_BANGCONG_CHITIET data)
        {
            try
            {
                tb_BANGCONG_CHITIET bcct_NhanVien = hrm.tb_BANGCONG_CHITIET.FirstOrDefault(x=> x.MAKYCONG == data.MAKYCONG && x.MANV == data.MANV && x.NGAY == data.NGAY);
                bcct_NhanVien.KYHIEU = data.KYHIEU;
                bcct_NhanVien.GIOVAO = data.GIOVAO;
                bcct_NhanVien.GIORA = data.GIORA;
                bcct_NhanVien.CONGCHUNHAT = data.CONGCHUNHAT;
                bcct_NhanVien.CONGNGAYLE = data.CONGNGAYLE; 
                bcct_NhanVien.UPDATED_DATE = DateTime.Now;
                hrm.SaveChanges();
                return bcct_NhanVien;
            
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public double TongNgayPhep(string mkc, int manv)
        {
            return hrm.tb_BANGCONG_CHITIET
                .Where(x => x.MAKYCONG == mkc && x.MANV == manv)
                .Sum(p => p.NGAYPHEP ?? 0);
        }

        public double TongNgayLe(string mkc, int manv)
        {
            return hrm.tb_BANGCONG_CHITIET
                .Where(x => x.MAKYCONG == mkc && x.MANV == manv)
                .Sum(p => p.CONGNGAYLE ?? 0);
        }

        public double TongNgayChuNhat(string mkc, int manv)
        {
            return hrm.tb_BANGCONG_CHITIET
                .Where(x => x.MAKYCONG == mkc && x.MANV == manv)
                .Sum(p => p.CONGCHUNHAT ?? 0);
        }
        public double TongNgayCong(string mkc, int manv)
        {
            return hrm.tb_BANGCONG_CHITIET
                .Where(x => x.MAKYCONG == mkc && x.MANV == manv)
                .Sum(y =>y.NGAYCONGTRONGNGAY??0);
        }
    }
}
