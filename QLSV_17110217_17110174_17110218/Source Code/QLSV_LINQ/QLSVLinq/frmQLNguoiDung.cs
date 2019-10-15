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
    public partial class frmQLNguoiDung : Form
    {
        bool Add;
        string err;
        BLLogin dbLogin = new BLLogin();
        public frmQLNguoiDung()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {
                dgvLogin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvLogin.AllowUserToAddRows = false;
                dgvLogin.ReadOnly = true;
                dgvLogin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLogin.DataSource = dbLogin.LayLogin();
                groupBox1.Enabled = false;
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
                this.groupBox1.Enabled = false;
                
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnAdd.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnDel.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong table . Lỗi rồi!!!");
            }
            
        }
        private void frmQLNguoiDung_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Add = true;
            // Xóa trống các đối tượng trong Panel 
            txtHoTen.ResetText();
            txtTaikhoan.ResetText();
            txtGT.ResetText();
            txtMK.ResetText();
            txtEmail.ResetText();
            mskPhone.ResetText();
            txtConfimMk.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox1.Enabled = true;
            txtQuyen.Text = "Member";
            
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            
            // Đưa con trỏ đến TextField txtThanhPho 
            this.txtHoTen.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Add = false;
            // Cho phép thao tác trên Panel 
            this.groupBox1.Enabled = true;
            dgvLogin_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh 
                // Lấy thứ tự record hiện hành 
                int r = dgvLogin.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strLogin =
                dgvLogin.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL 
                // Hiện thông báo xác nhận việc xóa mẫu tin 
                // Khai báo biến traloi 
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp 
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không? 
                if (traloi == DialogResult.Yes)
                {
                    dbLogin.XoaAc(ref err, strLogin);
                    // Cập nhật lại DataGridView 
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    // Thông báo 
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            txtHoTen.ResetText();
            txtTaikhoan.ResetText();
            txtGT.ResetText();
            txtMK.ResetText();
            txtEmail.ResetText();
            mskPhone.ResetText();
            txtConfimMk.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAdd.Enabled = true;
            this.btnEdit.Enabled = true;
            this.btnDel.Enabled = true;
            this.btnExit.Enabled = true;
            
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.groupBox1.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Mở kết nối 
            // Thêm dữ liệu 
            if (Add)
            {
                try
                {
                    // Thực hiện lệnh 
                    BLLogin blLogin = new BLLogin();
                    blLogin.ThemAc(txtTaikhoan.Text, txtMK.Text, txtHoTen.Text, txtGT.Text, mskPhone.Text, txtEmail.Text, ref err);
                    // Load lại dữ liệu trên DataGridView 
                    LoadData();
                    // Thông báo 
                    MessageBox.Show("Đã thêm xong!");
                }
                catch
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            else
            {
                // Thực hiện lệnh 
                BLLogin blLogin = new BLLogin();
                blLogin.CapNhatAc(txtTaikhoan.Text, txtMK.Text, txtHoTen.Text, txtGT.Text, mskPhone.Text, txtEmail.Text, ref err);
                // Load lại dữ liệu trên DataGridView 
                LoadData();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }
            // Đóng kết nối 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvLogin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }
    }
}
