using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSVLinq.BS_Layer;
namespace QLSVLinq
{
    public partial class frmDoiMatKhau : Form
    {
        string user; string pass; string quyen;
        string err;
        BLLogin dbLogin = new BLLogin();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public frmDoiMatKhau(string user, string pass, string quyen)
        {
            InitializeComponent();
            this.user = user;
            this.pass = pass;
            this.quyen = quyen;
        }
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTaikhoan.Text = user;
            if (quyen == "Member")
            {
                txtMKcu.Enabled = true;
                txtTaikhoan.Enabled = false;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
