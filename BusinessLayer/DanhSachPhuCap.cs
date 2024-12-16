using BusinessLayer.Convert_DTO;
using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class DanhSachPhuCap
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);
        public List<tb_DANHSACHPHUCAP> getList()
        {
            return hrm.tb_DANHSACHPHUCAP.ToList();
        }



        public List<DanhSachPhuCapDTO> getListDTO()
        {
            var ListAllPhuCap = hrm.tb_DANHSACHPHUCAP.ToList();
            List<DanhSachPhuCapDTO> lisrDto = new List<DanhSachPhuCapDTO>();

            foreach( var data in ListAllPhuCap)
            {
                var convert_Dto = new DanhSachPhuCapDTO();

                convert_Dto.ID = data.ID;
                convert_Dto.TENPHUCAP = data.TENPHUCAP;
                convert_Dto.SOTIENPHUCAP = data.SOTIENPHUCAP;
                convert_Dto.NOIDUNG = data.NOIDUNG;
                convert_Dto.CREATED_BY = data.CREATED_BY;
                convert_Dto.CREATED_DATE = data.CREATED_DATE;
                convert_Dto.UPDATED_DATE = data.UPDATED_DATE;
                lisrDto.Add(convert_Dto);
            }
            return lisrDto;
        }
        // Hàm ADD  Tầng BusinessLayer truyền vào kiểu dữ liệu dạng bảng data tb_DANHSACHPHUCAP
        public tb_DANHSACHPHUCAP Add_data(tb_DANHSACHPHUCAP data)
        {
            try
            {
                hrm.tb_DANHSACHPHUCAP.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_DANHSACHPHUCAP Update(tb_DANHSACHPHUCAP data)
        {
            try
            {
                var row_update = hrm.tb_DANHSACHPHUCAP.FirstOrDefault(x => x.ID == data.ID);
                
                if (row_update != null)
                {
                    row_update.ID = data.ID;
                    row_update.TENPHUCAP = data.TENPHUCAP;
                    row_update.SOTIENPHUCAP = data.SOTIENPHUCAP;
                    row_update.NOIDUNG = data.NOIDUNG;
                    row_update.CREATED_BY = data.CREATED_BY;
                    row_update.CREATED_DATE = data.CREATED_DATE;
                    row_update.UPDATED_DATE = DateTime.Now  ;
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
        public tb_DANHSACHPHUCAP getItem(int id)
        {
            return hrm.tb_DANHSACHPHUCAP.FirstOrDefault(x => x.ID == id);
        }

        public tb_DANHSACHPHUCAP Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_DANHSACHPHUCAP.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_DANHSACHPHUCAP.Remove(row_to_delete);
                    //row_to_delete.DELETE_BY = MaNV;
                    //row_to_delete.DELETE_DATE = DateTime.Now;
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



        public int SoLuong()
        {
            return hrm.tb_DANHSACHPHUCAP.Count();
        }
    }
}
