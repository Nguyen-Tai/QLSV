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
    public partial class frmKhoa : Form
    {
        bool Add ;
        string err;
        BLKhoa dbKhoa = new BLKhoa();
        public frmKhoa()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dgvKhoa.DataSource = dbKhoa.LayKhoa();
                // Thay đổi độ rộng cột 
                dgvKhoa.AllowUserToAddRows = false;
                // Xóa trống các đối tượng trong Panel 
                txtMaKhoa.ResetText();
                txtTenKhoa.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
                this.groupBox1.Enabled = false;
                this.groupBox3.Enabled = true;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
                this.btnAdd.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnDel.Enabled = true;
            }
            catch
            {
               MessageBox.Show("Không lấy được nội dung trong table Khoa. Lỗi rồi!!!");
            }
        }
        private void frmKhoa_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Add = true;
            // Xóa trống các đối tượng trong Panel 
            this.txtMaKhoa.ResetText();
            this.txtTenKhoa.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox1.Enabled = true;
            this.txtMaKhoa.Enabled = true;
            this.txtTenKhoa.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            this.groupBox3.Enabled = false;
            // Đưa con trỏ đến TextField txtThanhPho 
            this.txtMaKhoa.Focus();
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
                    BLKhoa blKhoa = new BLKhoa();
                    blKhoa.ThemKhoa(this.txtMaKhoa.Text, this.txtTenKhoa.Text);
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
                BLKhoa blTp = new BLKhoa();
                blTp.CapNhatKhoa(this.txtMaKhoa.Text, this.txtTenKhoa.Text, ref err);
                // Load lại dữ liệu trên DataGridView 
                LoadData();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }
            // Đóng kết nối 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Add = false;
            // Cho phép thao tác trên Panel 
            this.groupBox1.Enabled = true;
            dgvKhoa_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            this.txtMaKhoa.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH 

            this.txtTenKhoa.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh 
                // Lấy thứ tự record hiện hành 
                int r = dgvKhoa.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strKhoa =
                dgvKhoa.Rows[r].Cells[0].Value.ToString();
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
                    dbKhoa.XoaKhoa( strKhoa);
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
            this.txtMaKhoa.ResetText();
            this.txtTenKhoa.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAdd.Enabled = true;
            this.btnEdit.Enabled = true;
            this.btnDel.Enabled = true;
            this.btnExit.Enabled = true;
            this.groupBox3.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.groupBox1.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi 
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp 
            traloi = MessageBox.Show("Bạn Có Chắc Không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không? 
            if (traloi == DialogResult.OK) this.Close();
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành 
            int r = dgvKhoa.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel 
            txtMaKhoa.Text = dgvKhoa.Rows[r].Cells["maKhoa"].Value.ToString();
            txtTenKhoa.Text = dgvKhoa.Rows[r].Cells["tenKhoa"].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaKhoa.Checked == true)
            {

                dgvKhoa.DataSource = dbKhoa.TimMaKhoa(txtSearch.Text);
            }

            if (rdbTenKhoa.Checked == true)
            {

                dgvKhoa.DataSource = dbKhoa.TimTenKhoa(txtSearch.Text);
            }
        }
    }
}
