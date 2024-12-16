using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer
{
    public class LoaiCong
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);
        public List<tb_LOAICONG> getList()
        {
            return hrm.tb_LOAICONG.ToList();
        }

        public tb_LOAICONG Them(tb_LOAICONG data)
        {
            try
            {
                hrm.tb_LOAICONG.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_LOAICONG Update(tb_LOAICONG data)
        {
            try
            {
                var row_update = hrm.tb_LOAICONG.FirstOrDefault(x => x.IDLC == data.IDLC);
                if (row_update != null)
                {
                    row_update.TENLOAICONG = data.TENLOAICONG;
                    row_update.HESO = data.HESO;
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
        public tb_LOAICONG getItem(int id)
        {
            return hrm.tb_LOAICONG.FirstOrDefault(x => x.IDLC == id);
        }
        public tb_LOAICONG Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_LOAICONG.FirstOrDefault(x => x.IDLC == id);
                if (row_to_delete != null)
                {
                    hrm.tb_LOAICONG.Remove(row_to_delete);
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
        public int getCountSoLuong()
        {
            return hrm.tb_LOAICONG.Count();
        }
    }
}
