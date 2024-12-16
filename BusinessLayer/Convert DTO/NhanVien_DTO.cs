using System;
namespace BusinessLayer
{
    public class NhanVien_DTO
    {
        public int STT { get; set; }
        public int ID { get; set; }
        public int MANV { get; set; }
        public string HOTEN { get; set; }
        public string GIOITINH { get; set; }
        public System.DateTime NGAYSINH { get; set; }
        public string DIENTHOAI { get; set; }
        public string CCCD { get; set; }
        public string DIACHI { get; set; }
       // public byte[] HINHANH { get; set; }

        // Thêm Cca sthuocj tính để láy ra tên theo ID
        public int IDPB { get; set; }
        public string TENPB { get; set; }
        public int IDBP { get; set; }
        public string TENBP { get; set; }
        public int IDCV { get; set; }
        public string TENCV { get; set; }

        public string IMGPATH { get; set; }
        public int IDTD { get; set; }
        public string TENTD {  get; set; }
        public int IDDANTOC { get; set; }
        public string TENDANTOC { get; set; }
        public Nullable<int> IDTONGIAO { get; set; }
        public string TENTONGIA { get; set; }
        public int ROLE { get; set; }
        public string TENVAITRO { get; set; }
        public int? TrangThaiLamViec { get; set; }
        public string TRANGTHAI { get;set; }
        
    }
}
