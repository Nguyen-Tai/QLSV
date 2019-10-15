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
    public partial class frmQLDiem : Form
    {
        string user; string pass; string quyen;
        bool Add;
        string err;
        BLSV dbSV = new BLSV();
        BLQLDiem dbDiem = new BLQLDiem();
        BLKhoa dbKhoa = new BLKhoa();
        BLLop dbLop = new BLLop();
        BLMon dbMon = new BLMon();
        Double tong = 0;
        int stc = 0;
        int stcDau = 0;
        int stcRot = 0;
        public frmQLDiem()
        {
            InitializeComponent();
        }
        public frmQLDiem(string user, string pass, string quyen)
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
                groupBox1.Enabled = false;
                groupBox5.Enabled = false;
                btnDel.Enabled = false;
                btnEdit.Enabled = false;
                btnHienThi.Enabled = false;
                btnAdd.Enabled = false;
                btnTim.Enabled = false;
                btnCancel.Enabled = false;
                btnUpdate.Enabled = false;
                btnSave.Enabled = false;
            }
        }
        private void LoadComboLop(string MaKhoa)
        {
            cboSLop.DataSource = dbLop.LayKhoaInLop(MaKhoa);
            cboSLop.ValueMember = "maLop";
            cboSLop.DisplayMember = "maLop";
        }

        private void LoadComboKhoa()
        {
            cboKhoaHoc.DataSource = dbKhoa.LayKhoa();
            cboKhoaHoc.ValueMember = "maKhoa";
            cboKhoaHoc.DisplayMember = "maKhoa";
        }
        private void resettextDiem()
        {
            this.txtdiemCK.ResetText();
            this.txtdiemGK.ResetText();
            this.txtDiemTB.ResetText();
            this.lbdau.ResetText();
            this.lbrot.ResetText();
            this.lbtb.ResetText();
            this.lbstc.ResetText();
            this.cbKQ.ResetText();

        }

        void LoadDiem(string MaSV)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.KetQuas
                           from up in qlSV.Mons
                           where tp.maSV == MaSV
                           && up.maMon == tp.maMon
                           select new
                           {
                               tp.maMon,
                               up.soTinChi,
                               up.tenMon,
                               tp.diemGiuaKi,
                               tp.diemCuoiKi,
                               tp.diemTB,
                               up.hocKi,
                               tp.ketQua,
                               
                           }
                          ).ToList();
            dgvDiem.DataSource = tpQuery;
        }
        void LoadDataSV()
        {
            if (quyen == "Admin")
            {
                dgvSV.DataSource = dbSV.LaySinhVien();
            }
            else
            {
                dgvSV.DataSource = dbSV.TimMaSinhVien(user);
            }
            
            dgvSV.Columns.Remove("ngaySinh");
            dgvSV.Columns.Remove("gioiTinh");
            dgvSV.Columns.Remove("diaChi");
            dgvSV.Columns["Lop"].Visible = false;
            dgvSV.Columns["maLop"].Visible = false;
            dgvSV.AllowUserToAddRows = false;
            dgvSV.ReadOnly = true;
            rdbMaSV.Checked = true;
            LoadComboKhoa();
            LoadComboLop(cboKhoaHoc.Text);
            dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.ReadOnly = true;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cbLop.DataSource = dbLop.LayLop();
            cbLop.ValueMember = "maLop";
            cbLop.DisplayMember = "maLop";
            cbMon.DataSource = dbMon.LayMon();
            cbMon.ValueMember = "maMon";
            cbMon.DisplayMember = "maMon";
            // Không cho thao tác trên các nút Lưu / Hủy 
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.groupBox2.Enabled = false;

            // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát 
            this.btnAdd.Enabled = true;
            this.btnEdit.Enabled = true;
            this.btnDel.Enabled = true;
            this.btnExit.Enabled = true;
            //resettextDiem();

        }
        private void frmQLDiem_Load(object sender, EventArgs e)
        {
            LoadDataSV();
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                stc = 0;
                tong = 0;
                int stcDau = 0;
                int stcRot = 0;
                int r = dgvSV.CurrentCell.RowIndex;
                this.txtMaSV.Text = dgvSV.Rows[r].Cells["maSV"].Value.ToString();
                this.txtHoTen.Text = dgvSV.Rows[r].Cells["hoTen"].Value.ToString();
                this.cbLop.Text = dgvSV.Rows[r].Cells["maLop"].Value.ToString();
                cbMon.DataSource = dbMon.LoadMonTrongMaLop(cbLop.Text);
                LoadDiem(txtMaSV.Text);
                resettextDiem();
                foreach (DataGridViewRow row in dgvDiem.Rows)
                {
                    DataGridViewCheckBoxCell kq = row.Cells["ketQua"] as DataGridViewCheckBoxCell;
                    if ((bool)kq.Value)
                        stcDau += Convert.ToInt32(row.Cells["soTinChi"].Value.ToString());
                    else
                        stcRot += Convert.ToInt32(row.Cells["soTinChi"].Value.ToString());
                    stc += Convert.ToInt32(row.Cells["soTinChi"].Value.ToString());
                    tong += Convert.ToDouble(row.Cells["diemTB"].Value.ToString()) * Convert.ToDouble(row.Cells["soTinChi"].Value.ToString());
                }
                if (tong != 0)
                {
                    Double t = Math.Round(tong / stc, 2);
                    
                    lbtb.Text = t.ToString();
                }
                lbdau.Text = stcDau.ToString();
                lbrot.Text = stcRot.ToString();
            }
            catch { }
        }

        

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboLop(cboKhoaHoc.Text);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvSV.DataSource = dbSV.LaySinhVienTrongKhoaLop(cboKhoaHoc.SelectedValue.ToString(), cboSLop.SelectedValue.ToString());
            dgvSV.Columns.Remove("ngaySinh");
            dgvSV.Columns.Remove("gioiTinh");
            dgvSV.Columns.Remove("diaChi");
            dgvSV.Columns["Lop"].Visible = false;
            dgvSV.Columns["maLop"].Visible = false;
            dgvSV.AllowUserToAddRows = false;
            dgvSV.ReadOnly = true;
        }

        

        private void dgvDiem_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDiem.CurrentCell.RowIndex;
            this.cbMon.Text = dgvDiem.Rows[r].Cells["maMon"].Value.ToString();
            this.txtdiemGK.Text = dgvDiem.Rows[r].Cells["diemGiuaKi"].Value.ToString();
            this.txtdiemCK.Text = dgvDiem.Rows[r].Cells["diemCuoiKi"].Value.ToString();
            this.txtDiemTB.Text = dgvDiem.Rows[r].Cells["diemTB"].Value.ToString();
            this.lbhk.Text = dgvDiem.Rows[r].Cells["hocKi"].Value.ToString();
            this.lbstc.Text = dgvDiem.Rows[r].Cells["soTinChi"].Value.ToString();
            this.cbKQ.Checked = (bool)dgvDiem.Rows[r].Cells["ketQua"].Value;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            //frmReportDiem rp = new frmReportDiem(txtMaSV.Text);
            //rp.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them 
            Add = true;
            // Xóa trống các đối tượng trong Panel 
            
            this.txtdiemCK.ResetText();
            this.txtdiemGK.ResetText();
            this.txtDiemTB.ResetText();
            this.cbKQ.Checked = false;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox2.Enabled = true;
            this.txtMaSV.Enabled = false;
            this.txtHoTen.Enabled = false;
            this.cbLop.Enabled = false;
            this.cbMon.Enabled = true;
            this.txtdiemGK.Enabled = true;
            this.txtdiemCK.Enabled = true;
            this.txtDiemTB.Enabled = true;
            this.cbKQ.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            this.groupBox5.Enabled = false;
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
                    BLQLDiem blDiem = new BLQLDiem();
                    blDiem.ThemDiem(this.txtMaSV.Text, cbMon.Text, this.txtdiemGK.Text,this.txtdiemCK.Text,
                    this.txtDiemTB.Text, (this.cbKQ.Checked ? true : false));
                    // Load lại dữ liệu trên DataGridView 
                    
                    LoadDiem(txtMaSV.Text);
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
                BLQLDiem blDiem = new BLQLDiem();
                blDiem.CapNhatDiem(this.txtMaSV.Text, cbMon.Text,this.txtdiemGK.Text, this.txtdiemCK.Text,
                    this.txtDiemTB.Text, (this.cbKQ.Checked ? true : false));
                // Load lại dữ liệu trên DataGridView
                
                LoadDiem(txtMaSV.Text);
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
            this.groupBox2.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel 
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.groupBox1.Enabled = true;
            this.groupBox5.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát 
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDel.Enabled = false;
            this.txtMaSV.Enabled = false;
            this.txtHoTen.Enabled = false;
            this.cbLop.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH 

            this.txtdiemGK.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadDiem(txtMaSV.Text);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh 
                // Lấy thứ tự record hiện hành 
                int r = dgvDiem.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành 
                string strDiem =
                dgvDiem.Rows[r].Cells[0].Value.ToString();
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
                    dbDiem.XoaDiem(txtMaSV.Text, cbMon.Text,txtdiemGK.Text,txtdiemCK.Text);
                    // Cập nhật lại DataGridView 
                    LoadDiem(txtMaSV.Text);
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
            resettextDiem();

            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAdd.Enabled = true;
            this.btnEdit.Enabled = true;
            this.btnDel.Enabled = true;
            this.btnExit.Enabled = true;
            this.groupBox5.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.groupBox2.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaSV.Checked == true)
            {

                dgvSV.DataSource = dbSV.TimMaSinhVien(txtSearch.Text.Trim());
                dgvSV.Columns.Remove("ngaySinh");
                dgvSV.Columns.Remove("gioiTinh");
                dgvSV.Columns.Remove("diaChi");
                dgvSV.Columns["Lop"].Visible = false;
                dgvSV.Columns["maLop"].Visible = false;
            }

            if (rdbHoTen.Checked == true)
            {

                dgvSV.DataSource = dbSV.TimTenSinhVien(txtSearch.Text.Trim());
                dgvSV.Columns.Remove("ngaySinh");
                dgvSV.Columns.Remove("gioiTinh");
                dgvSV.Columns.Remove("diaChi");
                dgvSV.Columns["Lop"].Visible = false;
                dgvSV.Columns["maLop"].Visible = false;
            }
        }
    }
}
