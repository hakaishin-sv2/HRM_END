using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer.DTO
{
    public class KhenThuong_kyluat_DTO:NhanVien_DTO
    {
        public int STT { get; set; }
        public int ID { get; set; }
        public string SOQUYETDINH { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<System.DateTime> DENNGAY { get; set; }
        public int MANV { get; set; }
        public Nullable<int> LOAI { get; set; }
        public string LYDO { get; set; }
        public Nullable<System.DateTime> TUNGAY { get; set; }
        public Nullable<int> Status_tb { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public string TenPhongBan {  get; set; }
        public Nullable<int> NAM { get; set; }
        public Nullable<int> THANG { get; set; }
        public Nullable<double> SOTIEN { get; set; }

        public string SoTienString {  get; set; }   
    }
}
