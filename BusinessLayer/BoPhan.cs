using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data_Layer;
namespace BusinessLayer
{
    public class BoPhan
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);

        public List<tb_BOPHAN> getDanhSach()
        {
           
            return hrm.tb_BOPHAN.ToList();
        }

        public tb_BOPHAN Them(tb_BOPHAN data)
        {
            try
            {
                hrm.tb_BOPHAN.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_BOPHAN Update(tb_BOPHAN data)
        {
            try
            {
                var row_update = hrm.tb_BOPHAN.FirstOrDefault(x => x.IDBP == data.IDBP);

                if (row_update != null)
                {
                    row_update.TENBP = data.TENBP;
                   

                    hrm.SaveChanges();
                    return data;
                }
                else
                {
                    throw new Exception("Bản ghi không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_BOPHAN getItem(int id)
        {
            return hrm.tb_BOPHAN.FirstOrDefault(x => x.IDBP == id);
        }
        public tb_BOPHAN Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_BOPHAN.FirstOrDefault(x => x.IDBP == id);
                if (row_to_delete != null)
                {
                    hrm.tb_BOPHAN.Remove(row_to_delete);
                    hrm.SaveChanges();
                    return row_to_delete;
                }
                else
                {
                    throw new Exception("Bản ghi không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);
            }
        }
    }
}
