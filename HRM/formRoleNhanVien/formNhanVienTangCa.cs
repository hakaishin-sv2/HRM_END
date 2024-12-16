using BusinessLayer;
using BusinessLayer.ClassChamCong;
using BusinessLayer.Convert_DTO;
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

namespace HRM.formRoleNhanVien
{
    public partial class formNhanVienTangCa : DevExpress.XtraEditors.XtraForm
    {
        public formNhanVienTangCa()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();   
        }
        BangCongChiTietNhanVien _bangCongchiTiet;
        
        TangCa _tangCa;
        void loadData()
        {
           
            _tangCa = new TangCa();
            string makycong = comboBoxMaKyCong.Text;
            int thang = int.Parse(makycong.Substring(6));
            int nam = int.Parse(makycong.Substring(0,4));
            List<TangCa_DTO> listData = _tangCa.getAllListTangCaByKyCong(Session.User.MANV, thang, nam);
            if(listData.Count > 0)
            {
                gridControlTangCa.DataSource = listData;
                gridViewTangCa.OptionsBehavior.Editable = false;
            }else
            {
                return;
            }
           
           
        }
        void loadMaKyCong()
        {
            _bangCongchiTiet = new BangCongChiTietNhanVien();
            comboBoxMaKyCong.DataSource = _bangCongchiTiet.GetMaKyCongList();
        }
        private void formNhanVienTangCa_Load(object sender, EventArgs e)
        {
            loadMaKyCong();
            loadData();
        }

        private void comboBoxMaKyCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}