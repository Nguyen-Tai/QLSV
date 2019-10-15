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
    public partial class frmMonHoc : Form
    {
        bool Add;
        string err;
        BLKhoa dbKhoa = new BLKhoa();
        BLMon dbMon = new BLMon();
        public frmMonHoc()
        {
            InitializeComponent();
        }
        
        void LoadData()
        {
            try
            {
                dgvMon.DataSource = dbMon.LayMon();
                dgvMon.Columns["Khoa"].Visible = false;
                // Thay đổi độ rộng cột 
                dgvMon.AllowUserToAddRows = false;
                cboKhoa.DataSource = dbKhoa.LayKhoa();
                cboKhoa.ValueMember = "maKhoa";
                cboKhoa.DisplayMember = "maKhoa";

                // Xóa trống các đối tượng trong Panel
                txtMaMon.ResetText();
                txtTenMon.ResetText();
                txtSTC.ResetText();
                txtHocKy.ResetText();
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdbMaMon.Checked == true)
            {

                dgvMon.DataSource = dbMon.TimMaMon(txtSearch.Text);
            }

            if (rdbTenMon.Checked == true)
            {

                dgvMon.DataSource = dbMon.TimTenMon(txtSearch.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Add = true;
            // Xóa trống các đối tượng trong Panel 
            this.txtMaMon.ResetText();
            this.txtTenMon.ResetText();
            this.txtSTC.ResetText();
            this.txtHocKy.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox1.Enabled = true;
            this.txtMaMon.Enabled = true;
            this.txtTenMon.Enabled = true;
            this.txtSTC.Enabled = true;
            this.txtHocKy.Enabled = true;
            this.cboKhoa.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            this.groupBox3.Enabled = false;
            // Đưa con trỏ đến TextField txtThanhPho 
            this.txtMaMon.Focus();
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
                    BLMon blMon = new BLMon();
                    blMon.ThemMon(this.txtMaMon.Text, this.txtTenMon.Text, this.cboKhoa.Text, int.Parse(this.txtSTC.Text), this.txtHocKy.Text, ref err);
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
                BLMon blMon = new BLMon();
                blMon.CapNhatMon(this.txtMaMon.Text, this.txtTenMon.Text, this.cboKhoa.Text, int.Parse(this.txtSTC.Text), this.txtHocKy.Text, ref err);
                // Load lại dữ liệu trên DataGridView 
                LoadData();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa 
            Add = false;
            // Cho phép thao tác trên Panel 
            this.groupBox1.Enabled = true;
            dgvMon_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            this.txtMaMon.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH 

            this.txtTenMon.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh 
                // Lấy thứ tự record hiện hành 
                int r = dgvMon.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strMon =
                dgvMon.Rows[r].Cells[0].Value.ToString();
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
                    dbMon.XoaMon(ref err, strMon);
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
            this.txtMaMon.ResetText();
            this.txtTenMon.ResetText();
            this.txtSTC.ResetText();
            this.txtHocKy.ResetText();
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

        private void dgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvMon.CurrentCell.RowIndex;
            this.txtMaMon.Text = dgvMon.Rows[r].Cells["maMon"].Value.ToString();
            this.txtTenMon.Text = dgvMon.Rows[r].Cells["tenMon"].Value.ToString();
            this.cboKhoa.Text = dgvMon.Rows[r].Cells["maKhoa"].Value.ToString();
            this.txtHocKy.Text = dgvMon.Rows[r].Cells["hocKi"].Value.ToString();
            this.txtSTC.Text = dgvMon.Rows[r].Cells["soTinChi"].Value.ToString();
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvMon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
