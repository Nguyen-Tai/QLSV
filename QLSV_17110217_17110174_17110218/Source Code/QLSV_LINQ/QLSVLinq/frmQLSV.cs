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
    public partial class frmQLSV : Form
    {
        bool Add;
        string err;
        BLKhoa dbKhoa = new BLKhoa();
        BLLop dbLop = new BLLop();
        BLSV dbSV = new BLSV();
        public frmQLSV()
        {
            InitializeComponent();
        }
       
        private void LoadComboLop(string MaKhoa)
        {
            cboLop.DataSource = dbLop.LayKhoaInLop(MaKhoa);
            cboLop.ValueMember = "maLop";
            cboLop.DisplayMember = "maLop";
        }
        void LoadData()
        {
            try
            {
                dgvDSSV.DataSource = dbSV.LaySinhVien();
                // Thay đổi độ rộng cột 
                dgvDSSV.AllowUserToAddRows = false;
                dgvDSSV.Columns["Lop"].Visible = false;
                // Xóa trống các đối tượng trong Panel 
                txtMaSV.ResetText();
                txtHoTen.ResetText();
                dtpNS.ResetText();
                txtDiaChi.ResetText();
                cboKhoahoc.DataSource = dbKhoa.LayKhoa();
                cboKhoahoc.ValueMember = "maKhoa";
                cboKhoahoc.DisplayMember = "maKhoa";
                LoadComboLop(cboKhoahoc.Text);
       
                cboMalop.DataSource = dbLop.LayLop();
                cboMalop.ValueMember = "maLop";
                cboMalop.DisplayMember = "maLop";
                // Không cho thao tác trên các nút Lưu / Hủy 
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
                this.groupBox2.Enabled = false;
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Add = true;
            // Xóa trống các đối tượng trong Panel 
            this.txtMaSV.ResetText();
            this.txtHoTen.ResetText();
            this.dtpNS.ResetText();
            this.txtDiaChi.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox2.Enabled = true;
            this.txtMaSV.Enabled = true;
            this.txtHoTen.Enabled = true;
            this.dtpNS.ResetText();
            this.txtDiaChi.ResetText();
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            this.groupBox3.Enabled = false;
            // Đưa con trỏ đến TextField txtThanhPho 
            this.txtMaSV.Focus();
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
                    BLSV blSV = new BLSV();
                    blSV.ThemSinhVien(this.txtMaSV.Text, this.txtHoTen.Text, this.dtpNS.Value, rdbNam.Checked ? "Nam" : "Nữ", this.txtDiaChi.Text, this.cboMalop.Text, ref err);
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
                BLSV blSV = new BLSV();
                blSV.CapNhatSinhVien(this.txtMaSV.Text, this.txtHoTen.Text, this.dtpNS.Value, rdbNam.Checked ? "Nam" : "Nữ", this.txtDiaChi.Text, this.cboMalop.Text, ref err);
                // Load lại dữ liệu trên DataGridView 
                LoadData();
                // Thông báo 
                MessageBox.Show("Đã sửa xong!");
            }
            // Đóng kết nối 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        { // Kích hoạt biến Sửa 
            Add = false;
            // Cho phép thao tác trên Panel 
            this.groupBox2.Enabled = true;
            dgvDSSV_CellClick(null, null);
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox1.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            this.txtMaSV.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH 

            this.txtHoTen.Focus();
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
                int r = dgvDSSV.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strSV =
                dgvDSSV.Rows[r].Cells[0].Value.ToString();
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
                    dbSV.XoaSinhVien(ref err, strSV);
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
            this.txtMaSV.ResetText();
            this.txtHoTen.ResetText();
            this.dtpNS.ResetText();
            this.txtDiaChi.ResetText();

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

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaSV.Checked == true)
            {

                dgvDSSV.DataSource = dbSV.TimMaSinhVien(txtSearch.Text);
            }

            if (rdbHoTen.Checked == true)
            {

                dgvDSSV.DataSource = dbSV.TimTenSinhVien(txtSearch.Text);
            }
        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvDSSV.DataSource = dbSV.LaySinhVienTrongKhoaLop(cboKhoahoc.SelectedValue.ToString(), cboLop.SelectedValue.ToString());
        }

        private void cboKhoahoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboLop(cboKhoahoc.Text);
        }

        private void dgvDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDSSV.CurrentCell.RowIndex;
            this.txtMaSV.Text = dgvDSSV.Rows[r].Cells["maSV"].Value.ToString();
            this.txtHoTen.Text = dgvDSSV.Rows[r].Cells["hoTen"].Value.ToString();
            this.dtpNS.Text = dgvDSSV.Rows[r].Cells["ngaySinh"].Value.ToString();
            this.txtDiaChi.Text = dgvDSSV.Rows[r].Cells["diaChi"].Value.ToString();
            this.cboMalop.Text = dgvDSSV.Rows[r].Cells["maLop"].Value.ToString();
            if (dgvDSSV.Rows[r].Cells["gioiTinh"].Value.ToString() == "Nam") rdbNam.Checked = true; else rdbNam.Checked = false;
            if (dgvDSSV.Rows[r].Cells["gioiTinh"].Value.ToString() == "Nữ") rdbNu.Checked = true; else rdbNu.Checked = false;
        }

        private void rdbMaSV_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
