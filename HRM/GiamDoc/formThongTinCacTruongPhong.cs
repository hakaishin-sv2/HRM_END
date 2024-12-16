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

namespace HRM.GiamDoc
{
    public partial class formThongTinCacTruongPhong : DevExpress.XtraEditors.XtraForm
    {
        public formThongTinCacTruongPhong()
        {
            InitializeComponent();
        }
        NhanVien _nhanVien;
        PhongBan _phongBan;
        void loadData()
        {
            _nhanVien = new NhanVien();
            _phongBan = new PhongBan();
            // Lấy IDPB của trưởng tròng
            var list = _nhanVien.getListDTO_NhanVien();
            var listTheoPhong = list
                .Where(x => x.ROLE == 1)
                .ToList();

            gridControlListNv.DataSource = listTheoPhong;
            gridViewListNv.OptionsBehavior.Editable = false;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void formThongTinCacTruongPhong_Load(object sender, EventArgs e)
        {
            //SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
            loadData();
           // SplashScreenManager.CloseForm();
          
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitFormLoad), true, true);
            loadData();
            SplashScreenManager.CloseForm();
        }
    }
}