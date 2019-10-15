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
    public partial class frmLop : Form
    {
        bool Add;
        string err;
        BLKhoa dbKhoa = new BLKhoa();
        BLLop dbLop = new BLLop();
        public frmLop()
        {
            InitializeComponent();
        }
        
        void LoadData()
        {
            try
            {
                dgvLop.DataSource = dbLop.LayLop();
                
                // Thay đổi độ rộng cột 
                dgvLop.AllowUserToAddRows = false;
                cboMaKhoa.DataSource = dbKhoa.LayKhoa();
                cboMaKhoa.ValueMember = "maKhoa";
                cboMaKhoa.DisplayMember = "maKhoa";
                
                // Xóa trống các đối tượng trong Panel
                txtMaLop.ResetText();
                txtTenLop.ResetText();
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
                MessageBox.Show("Không lấy được nội dung trong table Lop. Lỗi rồi!!!");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Add = true;
            // Xóa trống các đối tượng trong Panel 
            this.txtMaLop.ResetText();
            this.txtTenLop.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox1.Enabled = true;
            this.txtMaLop.Enabled = true;
            this.txtTenLop.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            this.groupBox3.Enabled = false;
            // Đưa con trỏ đến TextField txtThanhPho 
            this.txtMaLop.Focus();
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
                    BLLop blLop = new BLLop();
                    blLop.ThemLop(this.txtMaLop.Text, this.txtTenLop.Text, this.cboMaKhoa.Text, ref err);
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
                BLLop blLop = new BLLop();
                blLop.CapNhatLop(this.txtMaLop.Text, this.txtTenLop.Text, this.cboMaKhoa.Text, ref err);
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
            dgvLop_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            this.txtMaLop.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH 

            this.txtTenLop.Focus();
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
                int r = dgvLop.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strLop =
                dgvLop.Rows[r].Cells[0].Value.ToString();
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
                    dbLop.XoaLop(ref err, strLop);
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
            this.txtMaLop.ResetText();
            this.txtTenLop.ResetText();
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

        

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvLop.CurrentCell.RowIndex;
            this.txtMaLop.Text = dgvLop.Rows[r].Cells["maLop"].Value.ToString();
            this.txtTenLop.Text = dgvLop.Rows[r].Cells["tenLop"].Value.ToString();
            this.cboMaKhoa.Text = dgvLop.Rows[r].Cells["maKhoa"].Value.ToString();

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaLop.Checked == true)
            {

                dgvLop.DataSource = dbLop.TimMaLop(txtSearch.Text);
            }

            if (rdbTenLop.Checked == true)
            {

                dgvLop.DataSource = dbLop.TimTenLop(txtSearch.Text);
            }
        }

        private void dgvLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
