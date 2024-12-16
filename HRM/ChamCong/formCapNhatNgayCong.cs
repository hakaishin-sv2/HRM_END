using BusinessLayer;
using BusinessLayer.ClassChamCong;
using Data_Layer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM.ChamCong
{
    public partial class formCapNhatNgayCong : DevExpress.XtraEditors.XtraForm
    {
        public formCapNhatNgayCong()
        {
            InitializeComponent();
        }
        public int _MaNv;
        public string _HoTen;
        public string _PhongBan;
        public string _MaKC;
        public string _Ngay;
        public int _NgayClick;
        BangCongChiTietNhanVien _bcct_nv;
        formBangCongChiTiet frmBCCt = (formBangCongChiTiet) Application.OpenForms["formBangCongChiTiet"];
        private void formCapNhatNgayCong_Load(object sender, EventArgs e)
        {
            lblHoTen.Text = _HoTen;
            lblMaNv.Text = _MaNv.ToString();
            lblPhongBan.Text = _PhongBan;
            string nam = _MaKC.Substring(0, 4);
            string thang = _MaKC.Substring(6);
            string d = _Ngay.Substring(3);
            DateTime date = DateTime.Parse(nam + "-" + thang + "-" + d);
            monthCalendarNgayCong.SetDate(date);
        }
      
        KyCongChiTiet _KCTT;
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(_MaNv.ToString() + "_"+_MaKC+"Ngày: "+_Ngay);

            string valueChamNgayCong = radioGroupChamCong.Properties.Items[radioGroupChamCong.SelectedIndex].Value.ToString();
            string valuetimeNghi = radioGroupTimeNghi.Properties.Items[radioGroupTimeNghi.SelectedIndex].Value.ToString();      
           
            _KCTT = new KyCongChiTiet();
            var KCCT_nv_a = _KCTT.getItem(_MaKC, _MaNv);
            string check_mkc = monthCalendarNgayCong.SelectionRange.Start.Year.ToString()+"_T"+ monthCalendarNgayCong.SelectionRange.Start.Month.ToString();
            if(_MaKC != check_mkc)
            {
                MessageBox.Show("Thực hiện kỳ công không đúng tháng! Vui lòng kiểm tra lại", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string fieldName = "Day" + _NgayClick.ToString();

                string sql = "UPDATE tb_KYCONGCHITIET SET " + fieldName + " = '" + valueChamNgayCong + "' WHERE MAKYCONG = '" + _MaKC + "' AND MANV = " + _MaNv;
                Function.excuQuery(sql);

                _bcct_nv = new BangCongChiTietNhanVien();
                var bcnv_a = _bcct_nv.getItem(_MaKC,_MaNv,_NgayClick);
                bcnv_a.KYHIEU = valueChamNgayCong;
                if (monthCalendarNgayCong.SelectionStart.DayOfWeek == DayOfWeek.Sunday) // làm thêm chủ nhật
                {
                    if (valueChamNgayCong == "LCN" && valuetimeNghi == "NN")
                    {              
                        bcnv_a.CONGCHUNHAT = 1;
                        bcnv_a.KYHIEU = "LCN";
                    }


                    else if (valueChamNgayCong == "LCN" && valuetimeNghi == "S" || valueChamNgayCong == "P" && valuetimeNghi == "C")
                    {                 
                        bcnv_a.CONGCHUNHAT = 0.5;
                        bcnv_a.KYHIEU = "LCN";
                    }
                }
                else // thứ 2 đến 7
                {
                    if (valueChamNgayCong == "P" && valuetimeNghi == "NN")
                    {
                        bcnv_a.NGAYPHEP = 1;
                        bcnv_a.NGAYCONGTRONGNGAY = 0;

                    }


                    else if (valueChamNgayCong == "P" && valuetimeNghi == "S" || valueChamNgayCong == "P" && valuetimeNghi == "C")
                    {
                        bcnv_a.NGAYPHEP = 0.5;
                        bcnv_a.NGAYCONGTRONGNGAY = 0.5;
                    }

                    else if (valueChamNgayCong == "VCN" && valuetimeNghi == "NN")
                    {
                        bcnv_a.NGAYPHEP = 1;
                        bcnv_a.NGAYCONGTRONGNGAY = 0;

                    }
                    else if (valueChamNgayCong == "VCN" && valuetimeNghi == "S" || valueChamNgayCong == "VCN" && valuetimeNghi == "C")
                    {
                        bcnv_a.NGAYPHEP = 0.5;
                        bcnv_a.NGAYCONGTRONGNGAY = 0.5;

                    }

                    else if (valueChamNgayCong == "V" && valuetimeNghi == "NN")
                    {
                        bcnv_a.NGAYPHEP = 1;
                        bcnv_a.NGAYCONGTRONGNGAY = 0;
                        //KCCT_nv_a.NGHIKHONGPHEP = TongNgayPhep + 1;

                    }
                    else if (valueChamNgayCong == "V" && valuetimeNghi == "S" || valueChamNgayCong == "V" && valuetimeNghi == "C")
                    {
                        bcnv_a.NGAYPHEP = 0.5;
                        bcnv_a.NGAYCONGTRONGNGAY = 0.5;
                    }
                }
                    
                _bcct_nv.Update(bcnv_a);
                double TongNgayCong = _bcct_nv.TongNgayCong(_MaKC, _MaNv);
                double TongNgayPhep = _bcct_nv.TongNgayPhep(_MaKC, _MaNv);
                double TongChuNhat = _bcct_nv.TongNgayChuNhat(_MaKC, _MaNv);

                KCCT_nv_a.NGAYPHEP = TongNgayPhep;
                KCCT_nv_a.TONGNGAYCONG = TongNgayCong+ TongChuNhat;
                KCCT_nv_a.CONGCHUNHAT = TongChuNhat;
                _KCTT.Update(KCCT_nv_a);
                frmBCCt.loadBangCong();
                MessageBox.Show("Bạn đã update thành công","Thông báo",MessageBoxButtons.OK);
            }
        }

        private void monthCalendarNgayCong_DateSelected(object sender, DateRangeEventArgs e)
        {
            _NgayClick = monthCalendarNgayCong.SelectionRange.Start.Day;
            //MessageBox.Show(monthCalendarNgayCong.SelectionRange.Start.Day.ToString());
        }

        private void monthCalendarNgayCong_DateChanged(object sender, DateRangeEventArgs e)
        {
            _NgayClick = monthCalendarNgayCong.SelectionRange.Start.Day;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}