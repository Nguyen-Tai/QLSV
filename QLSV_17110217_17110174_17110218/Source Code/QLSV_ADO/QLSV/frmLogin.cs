using QLSV.BS_layer;
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
    public partial class frmLogin : Form
    {
        BLAccount ac = new BLAccount();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDN.Text;
            string password = txtMatKhau.Text;
            DataTable tb = new DataTable();
            if (rdbAd.Checked)
            {
                tb = ac.LoginAdmin(username, password);
                if (tb.Rows.Count>0)
                {                  
                    frmAdmin ad = new frmAdmin(tb.Rows[0][0].ToString(), tb.Rows[0][1].ToString(),"Admin");
                    this.Hide();
                    ad.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                    txtTenDN.Select();
                }
            }
            else
            {
                tb = ac.LoginMember(username, password);
                if (tb.Rows.Count>0)
                {
                    frmAdmin ad = new frmAdmin(tb.Rows[0][0].ToString(), tb.Rows[0][1].ToString(),"Member");
                    this.Hide();
                    ad.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                    txtTenDN.Select();
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtTenDN.Select();
            rdbMb.Checked = true;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
