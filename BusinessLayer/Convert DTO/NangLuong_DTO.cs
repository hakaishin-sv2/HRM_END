using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;

namespace BusinessLayer.DTO
{
    public class NangLuong_DTO: NhanVien_DTO
    {
        public int STT { get; set; }
        public int ID { get; set; }
        public string SOQUYETDINH { get; set; }
        public Nullable<int> MANV { get; set; }
        public Nullable<double> HSLUONGCU { get; set; }
        public Nullable<System.DateTime> NGAYKY { get; set; }
        public Nullable<double> HSLUONGMOI { get; set; }
        public string GHICHU { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<int> UPDATE_BY { get; set; }
        public string SOHOPDONG { get; set; }
        public Nullable<System.DateTime> NGAYLENLUONG { get; set; }

        // thêm
        public string PHONGBAN {  get; set; }
        public string SoHopDong { get; set; }
        public string TenPhongBan { get; set; }
    }
}
