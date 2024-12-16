using BusinessLayer;
using System;
namespace HRM
{
    public partial class formTest : DevExpress.XtraEditors.XtraForm
    {
        public formTest()
        {
            InitializeComponent();
        }

        private void formTest_Load(object sender, EventArgs e)
        {
            TrinhDo tb = new TrinhDo();
            gridControl1.DataSource = tb.getListTrinhDo();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}