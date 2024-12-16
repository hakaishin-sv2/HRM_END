using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer
{
    public class LoaiCa
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);
        public List<tb_LOAICA> getList()
        {
            return hrm.tb_LOAICA.ToList();
        }

        public tb_LOAICA Them(tb_LOAICA data)
        {
            try
            {
                hrm.tb_LOAICA.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_LOAICA Update(tb_LOAICA data)
        {
            try
            {
                var row_update = hrm.tb_LOAICA.FirstOrDefault(x => x.IDLOAICA == data.IDLOAICA);
                if (row_update != null)
                {
                    row_update.TENLOAICA = data.TENLOAICA;
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
        public tb_LOAICA getItem(int id)
        {
            return hrm.tb_LOAICA.FirstOrDefault(x => x.IDLOAICA == id);
        }
        public tb_LOAICA Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_LOAICA.FirstOrDefault(x => x.IDLOAICA == id);
                if (row_to_delete != null)
                {
                    hrm.tb_LOAICA.Remove(row_to_delete);
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
            return hrm.tb_LOAICA.Count();
        }
    }
}
