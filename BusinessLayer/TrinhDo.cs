using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer
{
    public class TrinhDo
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);

        public List<tb_TRINHDO> getListTrinhDo()
        {
            return hrm.tb_TRINHDO.ToList();
        }

        public tb_TRINHDO Them_Trinh_Do(tb_TRINHDO data)
        {
            try
            {
                hrm.tb_TRINHDO.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_TRINHDO Update(tb_TRINHDO data)
        {
            try
            {
                var row_update = hrm.tb_TRINHDO.FirstOrDefault(x => x.IDTD == data.IDTD);
                
                if (row_update != null)
                {
                    row_update.TENTD = data.TENTD;
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
        public tb_TRINHDO getItem(int id)
        {
            return hrm.tb_TRINHDO.FirstOrDefault(x => x.IDTD == id);
        }
        public tb_TRINHDO Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_TRINHDO.FirstOrDefault(x => x.IDTD == id);
                if (row_to_delete != null)
                {
                    hrm.tb_TRINHDO.Remove(row_to_delete);
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
