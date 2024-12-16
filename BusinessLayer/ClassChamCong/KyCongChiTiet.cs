using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer.Convert_DTO;
using Data_Layer;
namespace BusinessLayer.ClassChamCong
{
    public class KyCongChiTiet
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);

        public List<KyCongChiTiet_DTO> getListDTO(int nam, int thang)
        {
           string mkc = nam.ToString()+"_T"+thang.ToString();
            var listHD = hrm.tb_KYCONGCHITIET.Where(x => x.MAKYCONG == mkc).ToList();
            var listKycongchitiet_DTO = new List<KyCongChiTiet_DTO>();
            /*
            CongTy ct = new CongTy();
            var CTY = ct.getCTYbyID(1234);
            string tenCT = CTY.TENCONGTY;
            */
            NhanVien nv = new NhanVien();
            PhongBan pb = new PhongBan();
            BangCong kc = new BangCong();
            //ChucVu chucVu = new ChucVu();
            //HopDong hopDong;
            foreach (var item in listHD)
            {
                var hd_dto = new KyCongChiTiet_DTO();

                hd_dto.MAKYCONG = item.MAKYCONG;
                hd_dto.MANV = item.MANV;
                hd_dto.HOTEN = item.HOTEN;
                hd_dto.Day1 = item.Day1;
                hd_dto.Day2 = item.Day2;
                hd_dto.Day3 = item.Day3;
                hd_dto.Day4 = item.Day4;
                hd_dto.Day5 = item.Day5;
                hd_dto.Day6 = item.Day6;
                hd_dto.Day7 = item.Day7;
                hd_dto.Day8 = item.Day8;
                hd_dto.Day9 = item.Day9;
                hd_dto.Day10 = item.Day10;
                hd_dto.Day11 = item.Day11;
                hd_dto.Day12 = item.Day12;
                hd_dto.Day13 = item.Day13;
                hd_dto.Day14 = item.Day14;
                hd_dto.Day15 = item.Day15;
                hd_dto.Day16 = item.Day16;
                hd_dto.Day17 = item.Day17;
                hd_dto.Day18 = item.Day18;
                hd_dto.Day19 = item.Day19;
                hd_dto.Day20 = item.Day20;
                hd_dto.Day21 = item.Day21;
                hd_dto.Day22 = item.Day22;
                hd_dto.Day23 = item.Day23;
                hd_dto.Day24 = item.Day24;
                hd_dto.Day25 = item.Day25;
                hd_dto.Day26 = item.Day26;
                hd_dto.Day27 = item.Day27;
                hd_dto.Day28 = item.Day28;
                hd_dto.Day29 = item.Day29;
                hd_dto.Day30 = item.Day30;
                hd_dto.Day31 = item.Day31;
                hd_dto.NGAYCONG = item.NGAYCONG;
                hd_dto.NGAYPHEP = item.NGAYPHEP;
                hd_dto.NGHIKHONGPHEP = item.NGHIKHONGPHEP;
                hd_dto.CONGNGAYLE = item.CONGNGAYLE;
                hd_dto.CONGCHUNHAT = item.CONGCHUNHAT;
                hd_dto.TONGNGAYCONG = item.TONGNGAYCONG;
                var kycong_x = kc.getItemByMaKyCong(item.MAKYCONG);
                if(kycong_x.KHOA == 1)
                {
                    hd_dto.KHOA = 1;
                }
                else
                {
                    hd_dto.KHOA = 0;
                }

                if (kycong_x.TRANGTHAI == 1)
                {
                    hd_dto.TRANGTHAI = 1;
                }
                else
                {
                    hd_dto.TRANGTHAI = 0;
                }
                var nhanVien = nv.FindMaNV((int)item.MANV);
                if (nhanVien != null)
                {
                    hd_dto.HOTEN = nhanVien.HOTEN;
                    var phongBan = pb.getItem((int)nhanVien.IDPB);
                    //var cv = chucVu.getItem((int)nhanVien.IDCV);
                    //hd_dto.TENCV = cv.TENCV;
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

                listKycongchitiet_DTO.Add(hd_dto);
            }

            return listKycongchitiet_DTO;
        }
       
        PhongBan pb = new PhongBan();
        public void phatSinhKyCongChiTiet(int thang, int nam)
        {
            var lstNV = hrm.tb_NHANVIEN.Where(x=>x.TrangThaiLamViec ==1).ToList();
            if (lstNV.Count == 0) return;

            foreach (var item in lstNV)
            {
                List<string> listDay = new List<string>();

                for (int j = 1; j <= GetDayNumber(thang, nam); j++)
                {
                    DateTime newDate = new DateTime(nam, thang, j);

                    switch (newDate.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            listDay.Add("CN");
                            break;
                            // làm cả thứ 7
                        /* case "Saturday":
                            listDay.Add("T7");
                            break;  */
                        default:
                            listDay.Add("X");
                            break;
                    }
                }

                switch (listDay.Count)
                {
                    case 28:
                        listDay.Add("");
                        listDay.Add("");
                        listDay.Add("");
                        break;
                    case 29:
                        listDay.Add("");
                        listDay.Add("");
                        break;
                    case 30:
                        listDay.Add("");
                        break;
                }

                tb_KYCONGCHITIET kycongchitiet = new tb_KYCONGCHITIET();
                kycongchitiet.MAKYCONG = nam.ToString()+"_T"  + thang.ToString();
                kycongchitiet.MANV = item.MANV;
                kycongchitiet.HOTEN = item.HOTEN;
                kycongchitiet.Day1 = listDay[0];
                kycongchitiet.Day2 = listDay[1];
                kycongchitiet.Day3 = listDay[2];
                kycongchitiet.Day4 = listDay[3];
                kycongchitiet.Day5 = listDay[4];
                kycongchitiet.Day6 = listDay[5];
                kycongchitiet.Day7 = listDay[6];
                kycongchitiet.Day8 = listDay[7];
                kycongchitiet.Day9 = listDay[8];
                kycongchitiet.Day10 = listDay[9];
                kycongchitiet.Day11 = listDay[10];
                kycongchitiet.Day12 = listDay[11];
                kycongchitiet.Day13 = listDay[12];
                kycongchitiet.Day14 = listDay[13];
                kycongchitiet.Day15 = listDay[14];
                kycongchitiet.Day16 = listDay[15];
                kycongchitiet.Day17 = listDay[16];
                kycongchitiet.Day18 = listDay[17];
                kycongchitiet.Day19 = listDay[18];
                kycongchitiet.Day20 = listDay[19];
                kycongchitiet.Day21 = listDay[20];
                kycongchitiet.Day22 = listDay[21];
                kycongchitiet.Day23 = listDay[22];
                kycongchitiet.Day24 = listDay[23];
                kycongchitiet.Day25 = listDay[24];
                kycongchitiet.Day26 = listDay[25];
                kycongchitiet.Day27 = listDay[26];
                kycongchitiet.Day28 = listDay[27];
                kycongchitiet.Day29 = listDay[28];
                kycongchitiet.Day30 = listDay[29];
                kycongchitiet.Day31 = listDay[30];
                
                kycongchitiet.NGAYCONG = Function.demSoNgayLamTrongThang(nam, thang);
                kycongchitiet.TONGNGAYCONG = Function.demSoNgayLamTrongThang(nam, thang);

                hrm.tb_KYCONGCHITIET.Add(kycongchitiet);
                hrm.SaveChanges();
            }

        }

        public tb_KYCONGCHITIET getItem(string Makycong, int manv)
        {
            return hrm.tb_KYCONGCHITIET.FirstOrDefault(x=>x.MAKYCONG == Makycong && x.MANV == manv);
        }
        private int GetDayNumber(int thang, int nam)
        {
            int dayNumber = 0;
            switch (thang)
            {
                case 2:
                    dayNumber = (nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0 ? 29 : 28;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    dayNumber = 30;
                    break;

                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dayNumber = 31;
                    break;
            }

            return dayNumber;
        }
        public tb_KYCONGCHITIET Update(tb_KYCONGCHITIET data)
        {
            try
            {
                // Tìm bản ghi cần cập nhật
                var kycongchitiet = hrm.tb_KYCONGCHITIET.FirstOrDefault(x => x.MAKYCONG == data.MAKYCONG && x.MANV == data.MANV);

                if (kycongchitiet == null)
                {
                    throw new Exception("Không tìm thấy bản ghi với mã kỳ công và mã nhân viên cung cấp.");
                }

                // Cập nhật các giá trị từ data
                kycongchitiet.Day1 = data.Day1;
                kycongchitiet.Day2 = data.Day2;
                kycongchitiet.Day3 = data.Day3;
                kycongchitiet.Day4 = data.Day4;
                kycongchitiet.Day5 = data.Day5;
                kycongchitiet.Day6 = data.Day6;
                kycongchitiet.Day7 = data.Day7;
                kycongchitiet.Day8 = data.Day8;
                kycongchitiet.Day9 = data.Day9;
                kycongchitiet.Day10 = data.Day10;
                kycongchitiet.Day11 = data.Day11;
                kycongchitiet.Day12 = data.Day12;
                kycongchitiet.Day13 = data.Day13;
                kycongchitiet.Day14 = data.Day14;
                kycongchitiet.Day15 = data.Day15;
                kycongchitiet.Day16 = data.Day16;
                kycongchitiet.Day17 = data.Day17;
                kycongchitiet.Day18 = data.Day18;
                kycongchitiet.Day19 = data.Day19;
                kycongchitiet.Day20 = data.Day20;
                kycongchitiet.Day21 = data.Day21;
                kycongchitiet.Day22 = data.Day22;
                kycongchitiet.Day23 = data.Day23;
                kycongchitiet.Day24 = data.Day24;
                kycongchitiet.Day25 = data.Day25;
                kycongchitiet.Day26 = data.Day26;
                kycongchitiet.Day27 = data.Day27;
                kycongchitiet.Day28 = data.Day28;
                kycongchitiet.Day29 = data.Day29;
                kycongchitiet.Day30 = data.Day30;
                kycongchitiet.Day31 = data.Day31;

                kycongchitiet.NGAYCONG= data.NGAYCONG;
                kycongchitiet.NGAYPHEP= data.NGAYPHEP;
                kycongchitiet.NGHIKHONGPHEP= data.NGHIKHONGPHEP;
                kycongchitiet.CONGCHUNHAT= data.CONGCHUNHAT;
                kycongchitiet.CONGNGAYLE= data.CONGNGAYLE;
                kycongchitiet.TONGNGAYCONG = data.TONGNGAYCONG;

                // Lưu thay đổi
                hrm.SaveChanges();
                return kycongchitiet;
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc ghi vào hệ thống theo dõi lỗi
                throw new Exception("Lỗi khi cập nhật dữ liệu kỳ công chi tiết: " + ex.Message);
            }
        }

        public bool CheckPhatSinhKyCong(int nam, int thang)
        {
            string mkc = nam.ToString() + "_T" + thang.ToString();
            var result = hrm.tb_KYCONGCHITIET.FirstOrDefault(x => x.MAKYCONG == mkc);

            if( result == null)
            {
                return false;
            }
            return true;
        }

    }
}
