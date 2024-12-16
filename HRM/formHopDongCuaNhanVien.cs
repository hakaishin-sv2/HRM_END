using BusinessLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HRM.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace HRM
{
    public partial class formHopDongCuaNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public formHopDongCuaNhanVien()
        {
            InitializeComponent();
        }
        HopDong hd;
        
        List<HopDong_DTO> _data;
        List<HopDong_DTO> _NV_a;
        void LoadData()
        {
            hd = new HopDong();
            _data = hd.getListDTO_HopDong();

            // nếu có đang nhập vào class Sesion để lấy thông tin user đã đăng nhập mà ko cần tạo
            var hdnhanvien = _data.FirstOrDefault(x => x.MANV == Session.User.MANV);
            _NV_a = new List<HopDong_DTO>();
            _NV_a.Add(hdnhanvien);
            gridControlLapHopDong.DataSource = _NV_a;
            gridViewLapHopDong.OptionsBehavior.Editable = false;
        }

        private void btnXemHopDongChiTietNhanVien_Click(object sender, EventArgs e)
        {
            if (_NV_a == null)
            {
                MessageBox.Show("Hãy Click vào nhân viên", "Hướng dẫn");
            }
            else
            {
                ReportHopDongLaoDong rpt = new ReportHopDongLaoDong(_NV_a);
                rpt.ShowPreview();
            }
        }

        private void formHopDongCuaNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}