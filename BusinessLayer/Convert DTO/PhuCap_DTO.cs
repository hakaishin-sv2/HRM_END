using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer.Convert_DTO
{
    public class PhuCap_DTO:NhanVien_DTO
    {
        public int IDPC { get; set; }
        public string TENPC { get; set; }
        public double SOTIEN { get; set; }
        public string TienToVND {  get; set; }  
        public int MANV { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> UPDATE_BY { get; set; }
        public Nullable<int> DELETE_BY { get; set; }
        public string TenPhongBan { get; set; }
        
    }
}
