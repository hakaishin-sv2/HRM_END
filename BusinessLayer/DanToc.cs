using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer
{
    public class DanToc
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);
        public List<tb_DANTOC> getListDanToc()
        {
            return hrm.tb_DANTOC.ToList();
        }

        public tb_DANTOC Them_dan_toc(tb_DANTOC data) 
        {
            try
            {
                hrm.tb_DANTOC.Add(data);
                hrm.SaveChanges();
                return data;
            }catch (Exception ex)
            {
                throw new Exception("Lỗi"+ ex.Message);

            }
        }
        public tb_DANTOC Update(tb_DANTOC data)
        {
            try
            {
                var row_update = hrm.tb_DANTOC.FirstOrDefault(x => x.ID == data.ID);
                if (row_update != null)
                {
                    row_update.TENDANTOC = data.TENDANTOC;
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
        public tb_DANTOC getItem(int id)
        {
            return hrm.tb_DANTOC.FirstOrDefault(x=>x.ID == id);
        }
        public tb_DANTOC Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_DANTOC.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_DANTOC.Remove(row_to_delete);
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
