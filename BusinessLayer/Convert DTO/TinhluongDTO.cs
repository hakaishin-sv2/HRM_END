using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer.Convert_DTO
{
    public class TinhluongDTO:NhanVien_DTO
    {
        public int STT { get; set; }
        public int ID { get; set; }
        public string MAKYCONG { get; set; }
        public string EMAIL { get; set; }
        public Nullable<int> MANV { get; set; }
        public string HOTEN { get; set; }
        public Nullable<double> NGAYCONGTRONGTHANG { get; set; }
        public Nullable<double> LUONGNGAYPHEP { get; set; }
        public Nullable<double> LUONGNGAYKHONGPHEP { get; set; }
        public Nullable<double> LUONGNGAYLE { get; set; }
        public Nullable<double> LUONGNGAYCHUNHAT { get; set; }
        public Nullable<double> UNGLUONG { get; set; }
        public Nullable<double> PHUCAP { get; set; }
        public Nullable<double> LUONGTANGCA { get; set; }
        public Nullable<double> SOTIENKYLUAT { get; set; }
        public Nullable<double> SOTIENKHENTHUONG { get; set; }
        public Nullable<double> LUONGNGAYTHUONG { get; set; }
        public Nullable<double> LUONGTHUCLANH { get; set; }
        public Nullable<double> TongTienCuaThang { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }
    }
}
