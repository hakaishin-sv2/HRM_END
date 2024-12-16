using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer
{
    public class TonGiao
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);
        public List<tb_TONGIAO> getListTonGiao()
        {
            return hrm.tb_TONGIAO.ToList();
        }

        public tb_TONGIAO Them_Ton_Giao(tb_TONGIAO data)
        {
            try
            {
                hrm.tb_TONGIAO.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_TONGIAO Update(tb_TONGIAO data)
        {
            try
            {
                var row_update = hrm.tb_TONGIAO.FirstOrDefault(x => x.ID == data.ID);
                if (row_update != null)
                {
                    row_update.TENTONGIA = data.TENTONGIA;
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
        public tb_TONGIAO getItem(int id)
        {
            return hrm.tb_TONGIAO.FirstOrDefault(x => x.ID == id);
        }
        public tb_TONGIAO Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_TONGIAO.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_TONGIAO.Remove(row_to_delete);
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
