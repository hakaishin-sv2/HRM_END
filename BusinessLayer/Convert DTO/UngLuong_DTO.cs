using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer.ClassChamCong
{
    public class UngLuong_DTO:NhanVien_DTO
    {
        public int ID { get; set; }
        public Nullable<int> NAM { get; set; }
        public Nullable<int> THANG { get; set; }
        public Nullable<int> NGAY { get; set; }
        public Nullable<int> MANV { get; set; }
        public Nullable<double> SOTIENUNGLUONG { get; set; }
        public string formattedSotien { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> CREATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<int> TRANGTHAI { get; set; }
        public string GHICHU { get; set; }

    }
}
