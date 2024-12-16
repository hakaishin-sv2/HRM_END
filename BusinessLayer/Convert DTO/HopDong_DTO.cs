using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HopDong_DTO : NhanVien_DTO
    {
        
        public int ID { get; set; }
        public string MAHOPDONG { get; set; }
        public Nullable<System.DateTime> NGAYBATDAU { get; set; }
        public Nullable<System.DateTime> NGAYKETTHUC { get; set; }
        public Nullable<System.DateTime> NGAYKY { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<int> LANKY { get; set; }
        public string THOIHANHOPDONG { get; set; }
        public Nullable<double> HESOLUONG { get; set; }
        public Nullable<decimal> LUONGCOBAN { get; set; }
        public Nullable<int> MANV { get; set; }
        //public string HOTEN { get; set; }
        public Nullable<int> MACTY { get; set; }
        public Nullable<int> DELETE_BY { get; set; }
        public Nullable<System.DateTime> DELETE_DATE { get; set; }
        public Nullable<int> UPDATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public Nullable<int> CREATE_BY { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        public Nullable<int> THAMNIEN { get; set; }
        public Nullable<int> TrangThai { get; set; }
        public string TenTrangThai { get; set; }
        public string LuongCoBan { get; set; }
        public string LuongHangThang { get; set; }

        public int VaiTro { get; set; }
        public string TenPhongBan { get; set; }
        public string TenCongTY { get; set; }

        public string DiaChiCongTy { get; set; }
        public int Ngay { get; set; } 
        public int Thang { get; set; }
        public int Nam { get; set; }

        //decimal? __LuongCoBan = null;
        //decimal _LuongCoBan
        //{
        //    get
        //    {
        //        if (__LuongCoBan == null || __LuongCoBan == 0)
        //        {

        //            var lcb = new LuongCoBan();
        //            __LuongCoBan = lcb.getLuongCoBan();
        //        }

        //        return __LuongCoBan.Value;
        //    }
        //}

        //public string LuongCoBan
        //{
        //    get
        //    {
        //        return _LuongCoBan.ToString("n0") + " VNĐ";
        //    }
        //}
        //public string LuongHangThang
        //{
        //    get
        //    {
        //        decimal LuongThang = _LuongCoBan * (decimal)HESOLUONG;

        //        return LuongThang.ToString("n0") + " VNĐ";
        //    }
        //}

    }
}
