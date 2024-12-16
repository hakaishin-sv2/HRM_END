using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer.Convert_DTO
{
    public class TangCa_DTO:NhanVien_DTO
    {
        public int ID { get; set; }
        public int NAM { get; set; }
        public int THANG { get; set; }
        public int NGAYTANGCA { get; set; }
        public double SOGIO { get; set; }
        public int MANV { get; set; }
        public int IDLOAICA { get; set; }
        public string TENLOAICA { get;set; }
        public double? HESO {  get; set; }
        public string GHICHU { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public float SOTIEN { get; set; }
        public string TienTangCa {  get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> DATE_TANGCA { get; set; }
    }
}
