using BusinessLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM.TruongPhong
{
    public partial class formDanhSachThanhVien : DevExpress.XtraEditors.XtraForm
    {
        public formDanhSachThanhVien()
        {
            InitializeComponent();
        }
        NhanVien _nhanVien;
        PhongBan _phongBan;
        public string tenpb;
        void loadData()
        {
            _nhanVien = new NhanVien();
            _phongBan = new PhongBan();
            // Lấy IDPB của trưởng tròng
            string IDPB = _nhanVien.FindMaNV(Session.User.MANV).IDPB.ToString();
            //var pb = _phongBan.getItem(int.Parse(IDPB));
            int idpb = int.Parse(IDPB);
            var list = _nhanVien.getListDTO_NhanVien();
            tenpb = list[0].TENPB;
            var listTheoPhong = list
                .Where(x => x.IDPB == idpb)
                .OrderByDescending(x => x.ROLE == 1)
                .ToList();

            gridControlListNv.DataSource = listTheoPhong;
            gridViewListNv.OptionsBehavior.Editable = false;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
            loadData();
            lbTenPhongBan.Text = tenpb;
            SplashScreenManager.CloseForm();
           
        }

        private void formDanhSachThanhVien_Load(object sender, EventArgs e)
        {
            loadData();
            lbTenPhongBan.Text = tenpb;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}