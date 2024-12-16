using System;
using System.Linq;
using Data_Layer;

namespace BusinessLayer
{
    public class LuongCoBan
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);

        public decimal getLuongCoBan()
        {

           /* var luongCoBan = hrm.tb_LUONGCOBAN
               .Where(l => l.MUCLUONG > 5000000)
               .FirstOrDefault();
           */
            var luongCoBan = hrm.tb_LUONGCOBAN.FirstOrDefault();
            if (luongCoBan != null)
            {
                return luongCoBan.MUCLUONG;
            }

            // Trả về giá trị mặc định nếu không có bản ghi nào trong bảng
            return 0;
        }
    }
}
