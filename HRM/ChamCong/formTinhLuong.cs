using BusinessLayer.ClassChamCong;
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
    public partial class formTinhLuong : DevExpress.XtraEditors.XtraForm
    {
        public formTinhLuong()
        {
            InitializeComponent();
        }

        TinhLuong _tinhLuong;

        void loadMaKyCong()
        {
            _tinhLuong = new TinhLuong();
            comboBoxMaKyCong.DataSource = _tinhLuong.GetMaKyCongList();
        }
        private void btnTinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void formTinhLuong_Load(object sender, EventArgs e)
        {
            loadMaKyCong();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}