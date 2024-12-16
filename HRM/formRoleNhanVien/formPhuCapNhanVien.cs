using BusinessLayer;
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

namespace HRM.formRoleNhanVien
{
    public partial class formPhuCapNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public formPhuCapNhanVien()
        {
            InitializeComponent();
        }
        PhuCap _pc;
        private void formPhuCapNhanVien_Load(object sender, EventArgs e)
        {
            _pc = new PhuCap();
            gridControlPhuCap.DataSource = _pc.PhuCamCuaNhanVien(Session.User.MANV);
            gridViewPhuCap.OptionsBehavior.Editable= false;
        }
    }
}