using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer.Convert_DTO
{
    public  class BangCongchiTietNhanVienDTO: NhanVien_DTO
    {
        public int ID { get; set; }
        public string MAKYCONG { get; set; }
        public Nullable<int> MANV { get; set; }
        public string HOTEN { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public string THU { get; set; }
        public string GIOVAO { get; set; }
        public string GIORA { get; set; }
        public Nullable<double> NGAYPHEP { get; set; }
        public Nullable<double> NGAYCONGTRONGNGAY { get; set; }
        public Nullable<double> CONGNGAYLE { get; set; }
        public Nullable<double> CONGCHUNHAT { get; set; }
        public string KYHIEU { get; set; }
        public string GHICHU { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }

        public double TongNgayCong {  get; set; }

        public double TongNgayPhep { get; set; }
        public double TongNgayLe { get; set; }
        public double TongChuNhat { get; set; }
    }
}
