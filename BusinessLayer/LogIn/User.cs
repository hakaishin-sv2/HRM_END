using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
namespace BusinessLayer
{
    public class User
    {
        public int MANV { get; set; }
        public string Password { get; set; }
        public int Role { get; set; } // 0 = Employee, 1 = Admin

        public User()
        {
            // Khởi tạo với các giá trị mặc định nếu cần thiết
            MANV = 0;
            Password = "";
            Role = 0;

            
        }

        // Hàm tạo có tham số
        public User(int manv, string password, int role)
        {
            MANV = manv;
            Password = password;
            Role = role;
            
            
        }


        HRMEntities hrm = new HRMEntities(Session.CONN_STR);




        public tb_USER AddUser(tb_USER data)
        {
            
            try
            {
                hrm.tb_USER.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_USER Update(tb_USER data)
        {
            try
            {
                var row_update = hrm.tb_USER.FirstOrDefault(x => x.MANV_LOGIN == data.MANV_LOGIN);
                if (row_update != null)
                {
                    row_update.PASSWORD = data.PASSWORD;
                    row_update.HASHPASSWORD = data.HASHPASSWORD;
                    row_update.ROLE = data.ROLE;
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
        public tb_USER getItemByManv(int Manv, out string Error)
        {
            Error = string.Empty;
            tb_USER obj = null;
            try
            {
                obj = hrm.tb_USER.FirstOrDefault(x => x.MANV_LOGIN == Manv);

                if(obj == null)
                {
                    Error = $"User {Manv} is null";
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            
            return obj;
        }
        public tb_USER Xoa(int manv)
        {
            try
            {
                var row_to_delete = hrm.tb_USER.FirstOrDefault(x => x.MANV_LOGIN == manv);
                if (row_to_delete != null)
                {
                    hrm.tb_USER.Remove(row_to_delete);
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
