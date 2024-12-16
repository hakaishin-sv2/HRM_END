using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Convert_DTO;
using Data_Layer;
namespace BusinessLayer.ClassChamCong
{
    public class BangCong
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);
        public List<tb_KYCONG> getList()
        {
            return hrm.tb_KYCONG.ToList();
        }

        public List<BangCong_DTO> getListDTO()
        {
            var listHD = hrm.tb_KYCONG.ToList();
            var listPhuCap_DTO = new List<BangCong_DTO>();
            /*
            CongTy ct = new CongTy();
            var CTY = ct.getCTYbyID(1234);
            string tenCT = CTY.TENCONGTY;
            */
            foreach (var item in listHD)
            {
                var hd_dto = new BangCong_DTO();
                hd_dto.ID = item.ID;
                hd_dto.MAKYCONG = item.MAKYCONG;
                hd_dto.THANG = item.THANG;
                hd_dto.NAM = item.NAM;
                hd_dto.KHOA = item.KHOA;
                hd_dto.TRANGTHAI = item.TRANGTHAI;
                hd_dto.NGAYTINHCONG = item.NGAYTINHCONG;
                hd_dto.NGAYCONGTRONTHANG = item.NGAYCONGTRONTHANG;
                hd_dto.MACTY= item.MACTY;
                hd_dto.CREATED_DATE = item.CREATED_DATE;
                if(item.KHOA == 1)
                {
                    hd_dto.KhoaChua = "Chưa khóa";
                }
                else
                {
                    hd_dto.KhoaChua = "Đã khóa";
                }
                if(item.TRANGTHAI == 1)
                {
                    hd_dto.TenTrangThai = "Đã phát sinh";
                }
                else
                {
                    hd_dto.TenTrangThai = "Chưa phát sinh";
                }
                listPhuCap_DTO.Add(hd_dto);
            }

            return listPhuCap_DTO;
        }

        public bool checkTrangThaiPhatSinh(string makycong)
        {
            var trangThai = hrm.tb_KYCONG
                 .Where(x => x.MAKYCONG == makycong)
                 .Select(x => x.TRANGTHAI)
                 .FirstOrDefault();
            if(trangThai== 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkKhoaKyCong(string makycong)
        {
            var khoa = hrm.tb_KYCONG
                 .Where(x => x.MAKYCONG == makycong)
                 .Select(x => x.KHOA)
                 .FirstOrDefault();
            if (khoa == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckTonTai(string makycong)
        {
            return hrm.tb_KYCONG.Any(x => x.MAKYCONG == makycong);
        }

        public tb_KYCONG Them(tb_KYCONG data)
        {
            try
            {
                hrm.tb_KYCONG.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_KYCONG Update(tb_KYCONG data)
        {
            try
            {
                var row_update = hrm.tb_KYCONG.FirstOrDefault(x => x.ID == data.ID);
                if (row_update != null)
                {
                    row_update.THANG = data.THANG;
                    row_update.NAM = data.NAM;
                    row_update.KHOA = data.KHOA;
                    row_update.TRANGTHAI = data.TRANGTHAI;
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
        public tb_KYCONG getItem(int id)
        {
            return hrm.tb_KYCONG.FirstOrDefault(x => x.ID == id);
        }
        public tb_KYCONG getItemByMaKyCong(string MaKyCong)
        {
            return hrm.tb_KYCONG.FirstOrDefault(x => x.MAKYCONG == MaKyCong);
        }
        public tb_KYCONG Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_KYCONG.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_KYCONG.Remove(row_to_delete);
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
        public int getCountSoLuong()
        {
            return hrm.tb_KYCONG.Count();
        }
        public string MaKyCong()
        {
            var qd = hrm.tb_KYCONG.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (qd != null)
            {
                return qd.MAKYCONG.ToString();
            }
            else
            {
                return "000";
            }
        }
    }
}
