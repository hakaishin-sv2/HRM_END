using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer.Convert_DTO
{
    public class DanhSachPhuCapDTO
    {
        public int ID { get; set; }
        public string TENPHUCAP { get; set; }
        public Nullable<double> SOTIENPHUCAP { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public string TrangThaiPhuCap { get; set; }
    }
}
