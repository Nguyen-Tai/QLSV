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
    public partial class frmAdmin : Form
    {
        string user; string pass; string quyen;
        public frmAdmin()
        {          
            InitializeComponent();
        }
        public frmAdmin(string user,string pass,string quyen)
        {
            InitializeComponent();
            this.user = user;
            this.pass = pass;
            this.quyen = quyen;
        }
        private void phanquyen()
        {
            if(quyen=="Member")
            {
                quảnLíNgườiDùngToolStripMenuItem.Enabled = false;
                danhMụcToolStripMenuItem.Enabled = false;
                sinhViênToolStripMenuItem.Enabled = false;
            }
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin lg = new frmLogin();
            lg.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đổiMâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoimatkhau npw = new frmDoimatkhau(user,pass,quyen);
            npw.ShowDialog();
        }

        private void quảnLíNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLiNguoiDung qlnd =new frmQuanLiNguoiDung();
            qlnd.ShowDialog();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            phanquyen();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonHoc mh = new frmMonHoc();
            mh.ShowDialog();
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhoa k = new frmKhoa();
            k.ShowDialog();

        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLop l = new frmLop();
            l.ShowDialog();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLSV ql = new frmQLSV();
            ql.ShowDialog();
        }

        private void giảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void điểmMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLĐiểm d = new frmQLĐiểm(user, pass, quyen);
            d.ShowDialog(); 
        }

        private void kếtQuảHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thongkehoctap tk = new Thongkehoctap(user, pass, quyen);
            tk.ShowDialog();
        }
    }
}
