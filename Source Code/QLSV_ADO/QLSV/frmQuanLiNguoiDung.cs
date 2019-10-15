using QLSV.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private void Enabletxt(bool t)
        {
            txtHoTen.Enabled = t;
            txtMK.Enabled = t;
            txtGT.Enabled = t;
            txtQuyen.Enabled = t;
            txtEmail.Enabled = t;
            txtTaikhoan.Enabled = t;
            mskPhone.Enabled = t;

        }
        private void resettext()
        {
            txtHoTen.ResetText();
            txtMK.ResetText();
            txtGT.ResetText();
            txtQuyen.ResetText();
            txtEmail.ResetText();
            txtTaikhoan.ResetText();
            mskPhone.ResetText();
        }
        private void frmQuanLiNguoiDung_Load(object sender, EventArgs e)
        {
            dgvLogin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogin.AllowUserToAddRows = false;
            dgvLogin.ReadOnly = true;
            dgvLogin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogin.DataSource = ac.GetAccount();
            Enabletxt(false);
            resettext();
            //// Không cho thao tác trên các nút Lưu / Hủy
            btnUpdate.Enabled = false;
            btnHuy.Enabled = false;
            //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            btnThem.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnExit.Enabled = true;
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

        private void dgvLogin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
             if (e.ColumnIndex == 1)
             {
                 e.Value = new string('*',e.Value.ToString().Length);
             }           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
          
            Them = true;
            Enabletxt(true);
            resettext();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnUpdate.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnExit.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            txtHoTen.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Cho phép thao tác trên Panel
            Enabletxt(true);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnUpdate.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnExit.Enabled = false;
            // Đưa con trỏ đến TextField 
            txtTaikhoan.Enabled = false;
            txtHoTen.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            if (ac.DeleteAccount(txtTaikhoan.Text))
                MessageBox.Show("Xóa người dùng thành công");
            else MessageBox.Show("Xóa người dùng thất bại");
            dgvLogin.DataSource = ac.GetAccount();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            resettext();
            Enabletxt(false);
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            btnThem.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnExit.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            btnUpdate.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                if ((!txtTaikhoan.Text.Trim().Equals("")))
                {
                    try
                    {
                        if (ac.InsertAccount(txtTaikhoan.Text, txtMK.Text, txtHoTen.Text, txtGT.Text, mskPhone.Text, txtEmail.Text))
                        {
                            // Load lại dữ liệu trên DataGridView     
                            dgvLogin.DataSource = ac.GetAccount();
                            Enabletxt(false);
                            resettext();
                            //// Không cho thao tác trên các nút Lưu / Hủy
                            btnUpdate.Enabled = false;
                            btnHuy.Enabled = false;
                            //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                            btnThem.Enabled = true;
                            btnEdit.Enabled = true;
                            btnDel.Enabled = true;
                            btnExit.Enabled = true;
                            // Thông báo         
                            MessageBox.Show("Đã thêm xong!");
                        }
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");
                    }
                }
                else
                    MessageBox.Show("Vui lòng điền thông tin");
            }
            else
            {
                if (ac.UpdateAccount(txtTaikhoan.Text, txtMK.Text, txtHoTen.Text, txtGT.Text, mskPhone.Text, txtEmail.Text))
                {
                    // Load lại dữ liệu trên DataGridView      
                    dgvLogin.DataSource = ac.GetAccount();
                    Enabletxt(false);
                    resettext();
                    //// Không cho thao tác trên các nút Lưu / Hủy
                    btnUpdate.Enabled = false;
                    btnHuy.Enabled = false;
                    //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                    btnThem.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                    btnExit.Enabled = true;
                    // Thông báo              
                    MessageBox.Show("Đã sửa xong!");
                }
            }
            // Đóng kết nối  
        }
    }
    
}
