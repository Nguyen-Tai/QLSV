using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVLinq
{
    public partial class frmAdmin : Form
    {
        string user; string pass; string quyen;
        public frmAdmin()
        {
            InitializeComponent();
        }
        public frmAdmin(string user, string pass, string quyen)
        {
            InitializeComponent();
            this.user = user;
            this.pass = pass;
            this.quyen = quyen;
        }
        private void phanquyen()
        {
            if (quyen == "Member")
            {
                quảnLíNgườiDùngToolStripMenuItem.Enabled = false;
                danhMụcToolStripMenuItem.Enabled = false;
                sinhViênToolStripMenuItem.Enabled = false;
            }
        }
        
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            phanquyen();
        }

        private void mônHọcToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmMonHoc mh = new frmMonHoc();
            mh.ShowDialog();
        }

        private void khoaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmKhoa k = new frmKhoa();
            k.ShowDialog();
        }

        private void lớpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmLop l = new frmLop();
            l.ShowDialog();
        }

        private void sinhViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmQLSV ql = new frmQLSV();
            ql.ShowDialog();
        }

        private void điểmMônHọcToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmQLDiem d = new frmQLDiem(user, pass, quyen);
            d.ShowDialog();
        }

        private void kếtQuảHọcTậpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmThongKe tk = new frmThongKe(user, pass, quyen);
            tk.ShowDialog();
        }

        private void đổiMâToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDoiMatKhau npw = new frmDoiMatKhau(user, pass, quyen);
            npw.ShowDialog();
        }

        private void quảnLíNgườiDùngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmQLNguoiDung qlnd = new frmQLNguoiDung();
            qlnd.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmLogin lg = new frmLogin();
            lg.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
