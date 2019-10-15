using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class frmDoimatkhau : Form
    {
        string user; string pass; string quyen;
        public frmDoimatkhau()
        {
            InitializeComponent();
        }
        public frmDoimatkhau(string user, string pass, string quyen)
        {
            InitializeComponent();
            this.user = user;
            this.pass = pass;
            this.quyen = quyen;
        }
        private void frmDoimatkhau_Load(object sender, EventArgs e)
        {
            txtTaikhoan.Text = user;
            if (quyen == "Member")
            {
                txtMKcu.Enabled = true;
                txtTaikhoan.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            BS_layer.BLAccount ac = new BS_layer.BLAccount();
            if(ac.ChangePassAccount(user, txtMKcu.Text, txtMKmoi.Text, txtConfimMk.Text, quyen))
            {
                MessageBox.Show("Cập nhật mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu thất bại");
            }
        }
    }
}
