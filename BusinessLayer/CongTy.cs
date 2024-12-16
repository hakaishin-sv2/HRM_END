using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer
{
    public class CongTy
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);

        public List<tb_CONGTY> getDanhSach()
        {
            return hrm.tb_CONGTY.ToList();
        }
       
        public tb_CONGTY Them(tb_CONGTY data)
        {
            try
            {
                hrm.tb_CONGTY.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_CONGTY Update(tb_CONGTY data)
        {
            try
            {
                var row_update = hrm.tb_CONGTY.FirstOrDefault(x => x.ID == data.ID);

                if (row_update != null)
                {
                    row_update.IDCONGTY = data.IDCONGTY;
                    row_update.TENCONGTY = data.TENCONGTY;
                    row_update.SDT = data.SDT;
                    row_update.EMAIL = data.EMAIL;
                    row_update.DIACHI = data.DIACHI;

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
        public tb_CONGTY getItem(int id)
        {
            return hrm.tb_CONGTY.FirstOrDefault(x => x.ID == id);
        }

        public tb_CONGTY getCTYbyID(int id_CongTY)
        {
            return hrm.tb_CONGTY.FirstOrDefault(x => x.IDCONGTY == id_CongTY);
        }
        public tb_CONGTY Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_CONGTY.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_CONGTY.Remove(row_to_delete);
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
