using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer.Convert_DTO
{
    public class BangCong_DTO
    {
        public int ID { get; set; }
        public string MAKYCONG { get; set; }
        public Nullable<int> THANG { get; set; }
        public Nullable<int> NAM { get; set; }
        public Nullable<int> KHOA { get; set; }
        public string KhoaChua { get; set; }
        public Nullable<System.DateTime> NGAYTINHCONG { get; set; }
        public Nullable<int> NGAYCONGTRONTHANG { get; set; }
        public Nullable<int> MACTY { get; set; }
        public Nullable<int> TRANGTHAI { get; set; }
        public string TenTrangThai { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
       
       
    }
}
