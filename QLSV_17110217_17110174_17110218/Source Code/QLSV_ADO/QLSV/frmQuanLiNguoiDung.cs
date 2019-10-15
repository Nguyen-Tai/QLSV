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
    public partial class frmQuanLiNguoiDung : Form
    {
        BLAccount ac = new BLAccount();
        bool Them;
        public frmQuanLiNguoiDung()
        {
            InitializeComponent();
        }

        private void frmQuanLiNguoiDung_Load(object sender, EventArgs e)
        {
            dgvLogin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogin.AllowUserToAddRows = false;
            dgvLogin.ReadOnly = true;
            dgvLogin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogin.DataSource = ac.GetAccount();
            groupBox1.Enabled = false;         
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLogin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành      
            int r = dgvLogin.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel           
            this.txtHoTen.Text = dgvLogin.Rows[r].Cells["HoTen"].Value.ToString();
            this.txtMK.Text = dgvLogin.Rows[r].Cells["passWord"].Value.ToString();
            this.txtTaikhoan.Text = dgvLogin.Rows[r].Cells["userName"].Value.ToString();
            this.txtGT.Text = dgvLogin.Rows[r].Cells["gioiTinh"].Value.ToString();
            this.mskPhone.Text = dgvLogin.Rows[r].Cells["Phone"].Value.ToString();
            this.txtEmail.Text = dgvLogin.Rows[r].Cells["Email"].Value.ToString();
            this.txtQuyen.Text = dgvLogin.Rows[r].Cells["Quyen"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ac.DeleteAccount(txtTaikhoan.Text))
                MessageBox.Show("Xóa người dùng thành công");
            else MessageBox.Show("Xóa người dùng thất bại");
            dgvLogin.DataSource = ac.GetAccount();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            groupBox1.Enabled = true;
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            Them = true;
            groupBox1.Enabled = true;
            txtHoTen.ResetText();
            txtTaikhoan.ResetText();
            txtGT.ResetText();
            txtMK.ResetText();
            txtEmail.ResetText();
            mskPhone.ResetText();
            txtQuyen.Text = "Member";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThemmoi.Enabled = false;
            txtHoTen.Focus();
           // dgvLogin.DataSource = ac.GetAccount();
        }

        private void dgvLogin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
             if (e.ColumnIndex == 1)
             {
                 e.Value = new string('*',e.Value.ToString().Length);
             }           
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(Them)          
              if (ac.InsertAccount(txtTaikhoan.Text, txtMK.Text, txtHoTen.Text, txtGT.Text, mskPhone.Text, txtEmail.Text))
                MessageBox.Show("Thêm người dùng thành công");
              else MessageBox.Show("Thêm người dùng thất bại");
            else
             if (ac.UpdateAccount(txtTaikhoan.Text, txtMK.Text, txtHoTen.Text, txtGT.Text, mskPhone.Text, txtEmail.Text))
                MessageBox.Show("Cập nhật thành công");
             else MessageBox.Show("Cập nhật thất bại");
            dgvLogin.DataSource = ac.GetAccount();
        }
    }
    //xét trường hợp trùng tk khi thêm(thêm hàn vào BLAccount) , thêm tùy chọn nhắc lại khi xóa, thêm,bắt lỗi exception
}
