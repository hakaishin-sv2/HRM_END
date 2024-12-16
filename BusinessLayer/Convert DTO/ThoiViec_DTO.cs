using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer.DTO
{
    public class ThoiViec_DTO:NhanVien_DTO
    {
        public int ID { get; set; }
        public string SOQUETDINH { get; set; }
        public Nullable<System.DateTime> NGAYNOPDON { get; set; }
        public Nullable<System.DateTime> NGAYNGHI { get; set; }
        public string LYDO { get; set; }
        public string GHICHU { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> CREATE_BY { get; set; }
        public Nullable<int> MANV { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }

        // Bổ sung thêm các thuộc tính để binding cho dễ
        public string TenPhongBan { get; set; }
        public string TencongTy {  get; set; }
        public string SoHopDong { get; set; }

        public string NgayHopDong { get; set; }
        public string ThangHopDong { get; set; }
        public string NamHopDong { get; set; }

        public string dayNghiViec { get; set; }
        public string monthNghiViec { get; set; }
        public string yearNghiViec { get; set; }

    }
}
