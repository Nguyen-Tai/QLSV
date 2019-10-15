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
            BLLogin lg = new BLLogin();
            if (lg.ChangePassAccount(user, txtMKcu.Text, txtMKmoi.Text, txtConfimMk.Text, quyen))
            {
                MessageBox.Show("Cập nhật mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu thất bại");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
