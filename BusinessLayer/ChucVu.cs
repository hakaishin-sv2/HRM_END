using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer
{
    public class ChucVu
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);



        public List<tb_CHUCVU> getDanhSach()
        {
            return hrm.tb_CHUCVU.ToList();
        }

        public tb_CHUCVU Them(tb_CHUCVU data)
        {
            try
            {
                hrm.tb_CHUCVU.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_CHUCVU Update(tb_CHUCVU data)
        {
            try
            {
                var row_update = hrm.tb_CHUCVU.FirstOrDefault(x => x.IDCV == data.IDCV);

                if (row_update != null)
                {
                    row_update.TENCV = data.TENCV;


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
        public tb_CHUCVU getItem(int id)
        {
            return hrm.tb_CHUCVU.FirstOrDefault(x => x.IDCV == id);
        }
        public tb_CHUCVU Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_CHUCVU.FirstOrDefault(x => x.IDCV == id);
                if (row_to_delete != null)
                {
                    hrm.tb_CHUCVU.Remove(row_to_delete);
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
