using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer.DTO
{
    public class ChuyenNhanVien_DTO:NhanVien_DTO
    {
        public int STT { get; set; }
        public int ID { get; set; }
        public string SOQUYETDINH { get; set; }
        public int MANV { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public Nullable<int> IDPBHIENTAI { get; set; }
        public Nullable<int> IDPHONGBANMOI { get; set; }
        public string LYDO { get; set; }
        public string GHICHU { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> CREATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<System.DateTime> DELETE_DATE { get; set; }
        public string TenPhongBanMoi {  get; set; }
        public string TenPhongBanCu { get; set; }
    }
}
