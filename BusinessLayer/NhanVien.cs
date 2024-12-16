using Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class NhanVien
    {
        HRMEntities hrm = new HRMEntities(Session.CONN_STR);

        public List<NhanVien_DTO> getListDTO_NhanVien()
        {
            var listNV = hrm.tb_NHANVIEN.ToList();
            var listNV_DTO = new List<NhanVien_DTO>();

            foreach (var item in listNV)
            {
                string status;
                if(item.TrangThaiLamViec == 1)
                {
                    status = "Còn làm";
                }else if (item.TrangThaiLamViec == 2)
                {
                    status = "Hết hợp đồng";
                }
                else
                {
                    status = "Đã Thôi việc";
                }
                string vaitronhanvien;
                if (item.ROLE == 1)
                {
                    vaitronhanvien = "Trưởng Phòng";
                }
                else
                {
                    vaitronhanvien = "Nhân Viên";
                }
                var DTO_NhanVien = new NhanVien_DTO
                {
                    ID = item.ID,
                    MANV = item.MANV,
                    HOTEN = item.HOTEN,
                    GIOITINH = item.GIOITINH,
                    NGAYSINH = item.NGAYSINH,
                    DIENTHOAI = item.DIENTHOAI,
                    CCCD = item.CCCD,
                    DIACHI = item.DIACHI,
                    IMGPATH = item.IMGPATH,
                    TrangThaiLamViec = item.TrangThaiLamViec,
                    TRANGTHAI= status,
                    TENVAITRO= vaitronhanvien,
                    ROLE = int.Parse(item.ROLE.ToString()),
                    //HINHANH = item.HINHANH,
                    // Phòng ban
                    IDPB = (int)item.IDPB,
                    TENPB = hrm.tb_PHONGBAN.FirstOrDefault(x => x.IDPB == item.IDPB)?.TENPB,
                    // Bộ phận
                    IDBP = (int)item.IDBP,
                    TENBP = hrm.tb_BOPHAN.FirstOrDefault(x => x.IDBP == item.IDBP)?.TENBP,
                    // Chức vụ
                    IDCV = (int)item.IDCV,
                    TENCV = hrm.tb_CHUCVU.FirstOrDefault(x => x.IDCV == item.IDCV)?.TENCV,
                    // Trình độ
                    IDTD = (int)item.IDTD,
                    TENTD = hrm.tb_TRINHDO.FirstOrDefault(x => x.IDTD == item.IDTD)?.TENTD,
                    // Dân tộc
                    IDDANTOC =(int) item.IDDANTOC,
                    TENDANTOC = hrm.tb_DANTOC.FirstOrDefault(x => x.ID == item.IDDANTOC)?.TENDANTOC,
                    // Tôn giáo
                    IDTONGIAO = item.IDTONGIAO,
                    TENTONGIA = hrm.tb_TONGIAO.FirstOrDefault(x => x.ID == item.IDTONGIAO)?.TENTONGIA
                };

                listNV_DTO.Add(DTO_NhanVien);
            }

            return listNV_DTO;
        }

       
        public List<tb_NHANVIEN> getDanhSach()
        {
            return hrm.tb_NHANVIEN.ToList();
        }

        

        // Hàm ADD thêm nhân viên bên Tầng BusinessLayer truyền vào kiểu dữ liệu dạng bảng data
        public tb_NHANVIEN Them(tb_NHANVIEN data)
        {
            try
            {
                hrm.tb_NHANVIEN.Add(data);
                hrm.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi" + ex.Message);

            }
        }
        public tb_NHANVIEN Update(tb_NHANVIEN data)
        {
            try
            {
                var row_update = hrm.tb_NHANVIEN.FirstOrDefault(x => x.ID == data.ID);

                if (row_update != null)
                {
                    row_update.MANV = data.MANV;
                    row_update.HOTEN = data.HOTEN;
                    row_update.GIOITINH = data.GIOITINH;
                    row_update.NGAYSINH = data.NGAYSINH;
                    row_update.DIENTHOAI = data.DIENTHOAI;
                    row_update.CCCD = data.CCCD;
                    //row_update.HINHANH = data.HINHANH;
                    row_update.IMGPATH = data.IMGPATH;
                    row_update.DIACHI = data.DIACHI;
                    row_update.IDPB = data.IDPB;
                    row_update.IDBP = data.IDBP;
                    row_update.IDCV = data.IDCV;
                    row_update.IDTD = data.IDTD;
                    row_update.IDDANTOC = data.IDDANTOC;
                    row_update.IDTONGIAO = data.IDTONGIAO;
                    row_update.ROLE = data.ROLE;
                    row_update.TrangThaiLamViec= data.TrangThaiLamViec;
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
        public tb_NHANVIEN getItem(int id)
        {
            return hrm.tb_NHANVIEN.FirstOrDefault(x => x.ID == id);
        }

        public tb_NHANVIEN FindMaNV(int MaNV)
        {
            return hrm.tb_NHANVIEN.FirstOrDefault(x => x.MANV == MaNV);
        }

        public List<tb_NHANVIEN> FindMaNVs(List<int?> MaNVs)
        {
            //van chua optimize 
            return hrm.tb_NHANVIEN.Where(x => MaNVs.Any(y => y == x.MANV)).ToList();
        }




        public tb_NHANVIEN Xoa(int id)
        {
            try
            {
                var row_to_delete = hrm.tb_NHANVIEN.FirstOrDefault(x => x.ID == id);
                if (row_to_delete != null)
                {
                    hrm.tb_NHANVIEN.Remove(row_to_delete);
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


        public int TongSoLuongNhanVien()
        {
            return hrm.tb_NHANVIEN.Count();
        }
        public bool checkTp(int IDPB)
        {
            var phongBan = hrm.tb_PHONGBAN.FirstOrDefault(pb => pb.IDPB == IDPB);
            return phongBan != null && phongBan.IDTP != null;
        }
        public NhanVien_DTO getNhanVienDTO(int MANV)
        {
            NhanVien_DTO nvDto = new NhanVien_DTO();
            var nventity = hrm.tb_NHANVIEN.FirstOrDefault(x=>x.MANV == MANV);
            if (nventity != null)
            {
                nvDto.MANV = nventity.MANV;
                nvDto.HOTEN= nventity.HOTEN;
                nvDto.IMGPATH= nventity.IMGPATH;
                var pb = hrm.tb_PHONGBAN.FirstOrDefault(x=>x.IDPB == nventity.IDPB);
                nvDto.TENPB =pb.TENPB;

            }
            return nvDto;
        }
    }
}
