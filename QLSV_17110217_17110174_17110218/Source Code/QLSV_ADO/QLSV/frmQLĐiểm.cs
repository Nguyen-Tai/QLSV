using QLSV.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class frmQLĐiểm : Form
    {
        string user; string pass; string quyen;
        BLKhoa k = new BLKhoa();
        BLLop l = new BLLop();
        BLSinhvien sv = new BLSinhvien();
        BLKetQua kq = new BLKetQua();
        BLMonhoc mh = new BLMonhoc();
        Double tong = 0;
        int stc = 0;
        int stcDau = 0;
        int stcRot = 0;
        bool Them;
        public frmQLĐiểm()
        {
            InitializeComponent();
        }
        public frmQLĐiểm(string user, string pass, string quyen)
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
                btnThem.Enabled = false;
                btnTim.Enabled = false;
                btnHuy.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }
        private void EnableSV(bool t)
        {
            txtMaSV.Enabled = t;
            txtHoTen.Enabled = t;
            this.cbMon.Enabled = t;
            this.cbLop.Enabled = t;
        }
        private void EnableDiem(bool t)
        {
            this.txtdiemCK.Enabled = t;
            this.txtdiemGK.Enabled = t;
           // this.txtDiemTB.Enabled = t;
            //this.cbKQ.Enabled = t;
        }
        private void resettextSV()
        {
            txtMaSV.ResetText();
            txtHoTen.ResetText();
            this.cbMon.ResetText();
            this.cbLop.ResetText();
        }
        private void resettextDiem()
        {
            this.txtdiemCK.ResetText();
            this.txtdiemGK.ResetText();
            this.txtDiemTB.ResetText();
            this.label6.ResetText();
            this.label16.ResetText();
            this.label17.ResetText();
            this.label21.ResetText();
            this.cbKQ.ResetText();
        }
        private void LoadComboboxKhoa()
        {
            DataTable table = new DataTable();
            table = k.GetKhoa();
            DataRow r = table.NewRow();
            r["maKhoa"] = "Tất cả";
            table.Rows.InsertAt(r, 0);
            cboKhoaHoc.DataSource = table;
            cboKhoaHoc.ValueMember = "maKhoa";
            cboKhoaHoc.DisplayMember = "maKhoa";
        }
        private void LoadComboboxLop(string Khoahoc)
        {
            DataTable table = new DataTable();
            table = l.GetLopByKhoa(Khoahoc);
            DataRow r = table.NewRow();
            r["maLop"] = "Tất cả";
            table.Rows.InsertAt(r, 0);
            cboSLop.DataSource = table;
            cboSLop.ValueMember = "maLop";
            cboSLop.DisplayMember = "maLop";
        }
        private void frmQLĐiểm_Load(object sender, EventArgs e)
        {         
            if (quyen == "Admin")
            {
                dgvSV.DataSource = sv.GetSinhvien();
            }
            else
            {             
                dgvSV.DataSource = sv.SearchSVByMaSV(user);
            }
            dgvSV.Columns.Remove("ngaySinh");
            dgvSV.Columns.Remove("gioiTinh");
            dgvSV.Columns.Remove("diaChi");
            dgvSV.Columns["maLop"].Visible = false;
            dgvSV.AllowUserToAddRows = false;
            dgvSV.ReadOnly = true;
            dgvSV.AutoGenerateColumns = false;
            rdbMaSV.Checked = true;
            dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.ReadOnly = true;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadComboboxKhoa();
            LoadComboboxLop(cboKhoaHoc.Text);
            cbLop.DataSource = l.GetLop();
            cbLop.ValueMember = "maLop";
            cbMon.DataSource = mh.GetMonhoc();
            cbMon.ValueMember = "maMon";
            EnableSV(false);
            EnableDiem(false);
            resettextSV();
            resettextDiem();
            //// Không cho thao tác trên các nút Lưu / Hủy
            btnUpdate.Enabled = false;
            btnHuy.Enabled = false;
            //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            btnThem.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnExit.Enabled = true;
            phanquyen();
        }


        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboboxLop(cboKhoaHoc.Text);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgvSV.DataSource = sv.GetSVByKhoaandLop(cboKhoaHoc.SelectedValue.ToString(), cboSLop.SelectedValue.ToString());
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaSV.Checked) //tìm theo mã SV
            {
                dgvSV.DataSource = sv.SearchSVByMaSVKL(txtSearch.Text.Trim(), cboKhoaHoc.SelectedValue.ToString(), cboSLop.SelectedValue.ToString());
            }
            else   //tìm theo Họ Tên SV
            {
                dgvSV.DataSource = sv.SearchSVByHoTenSVKL(txtSearch.Text.Trim(), cboKhoaHoc.SelectedValue.ToString(), cboSLop.SelectedValue.ToString());
            }
        }

        private void dgvDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvDiem.CurrentCell.RowIndex;
                this.cbMon.Text = dgvDiem.Rows[r].Cells["maMon"].Value.ToString();
                this.txtdiemGK.Text = dgvDiem.Rows[r].Cells["diemGiuaKi"].Value.ToString();
                this.txtdiemCK.Text = dgvDiem.Rows[r].Cells["diemCuoiKi"].Value.ToString();
                this.txtDiemTB.Text = dgvDiem.Rows[r].Cells["diemTB"].Value.ToString();
                this.label6.Text = dgvDiem.Rows[r].Cells["hocKi"].Value.ToString();
                this.label20.Text = dgvDiem.Rows[r].Cells["soTinChi"].Value.ToString();
                this.cbKQ.Checked = (bool)dgvDiem.Rows[r].Cells["ketQua"].Value;
            }
            catch { }
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
                cbMon.DataSource = mh.LoadMonByMaLop(cbLop.Text);
                dgvDiem.DataSource = kq.SearchKQByMaSV(txtMaSV.Text);
                //cbMon.ValueMember = "maMon";
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
                    label21.Text = t.ToString();
                }
                label16.Text = stcDau.ToString();
                label17.Text = stcRot.ToString();
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Mở kết nối        
            // Thêm dữ liệu     
            if (Them)
            {
                if ((!txtMaSV.Text.Trim().Equals("")))
                {
                    try
                    {
                        if (kq.InsertDiem(this.txtMaSV.Text, cbMon.Text, txtdiemGK.Text.Replace(",", "."), txtdiemCK.Text.Replace(",", "."),
                    txtDiemTB.Text.Replace(",", "."), (cbKQ.Checked ? "1" : "0")))
                        {
                            // Load lại dữ liệu trên DataGridView     
                            dgvDiem.DataSource = kq.SearchKQByMaSV(txtMaSV.Text);
                            EnableSV(false);
                            EnableDiem(false);
                            resettextSV();
                            resettextDiem();
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
                try
                {
                    if (kq.UpdateDiem(this.txtMaSV.Text, cbMon.Text, txtdiemGK.Text.Replace(",", "."), txtdiemCK.Text.Replace(",", "."),
                        txtDiemTB.Text.Replace(",", "."), (cbKQ.Checked ? "1" : "0")))
                    {
                        // Load lại dữ liệu trên DataGridView      
                        dgvDiem.DataSource = kq.SearchKQByMaSV(txtMaSV.Text);
                        EnableSV(false);
                        EnableDiem(false);
                        resettextSV();
                        resettextDiem();
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
                catch { MessageBox.Show("Bị lỗi. Vui lòng kiểm tra lại thông tin"); }
            }
            // Đóng kết nối  
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {

                // Hiện thông báo xác nhận việc xóa mẫu tin       
                // Khai báo biến traloi            
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp    
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?           
                if (traloi == DialogResult.Yes)
                {
                    if (kq.DeleteDiem(txtMaSV.Text, cbMon.Text,txtdiemGK.Text,txtdiemCK.Text))
                    {
                        // Cập nhật lại DataGridView                
                        dgvDiem.DataSource = kq.SearchKQByMaSV(txtMaSV.Text);
                        EnableDiem(false);
                        EnableSV(false);
                        resettextSV();
                        resettextDiem();
                        //// Không cho thao tác trên các nút Lưu / Hủy
                        btnUpdate.Enabled = false;
                        btnHuy.Enabled = false;
                        //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                        btnThem.Enabled = true;
                        btnEdit.Enabled = true;
                        btnDel.Enabled = true;
                        btnExit.Enabled = true;
                        // Thông báo           
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa không được,Vui lòng chọn môn muốn xóa");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không xóa được. Lỗi rồi");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            resettextSV();
            resettextDiem();
            EnableSV(false);
            EnableDiem(false);
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            btnThem.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnExit.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            btnUpdate.Enabled = false;
            btnHuy.Enabled = false;
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
            EnableDiem(true);
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnUpdate.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnExit.Enabled = false;
            // Đưa con trỏ đến TextField 
            txtMaSV.Enabled = false;
            txtdiemGK.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            //EnableSV(true);
            cbMon.Enabled = true;
            EnableDiem(true);

            //resettextSV();
            resettextDiem();
            cbMon.DataSource = mh.LoadMonByMaLop(cbLop.Text);
            cbMon.ValueMember = "maMon";
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnUpdate.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnExit.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            txtMaSV.Focus();
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            fReportDiem rp = new fReportDiem(txtMaSV.Text);
            rp.ShowDialog();
        }


        private void txtdiemGK_KeyUp(object sender, KeyEventArgs e)
        {
            Double t = 0;
            try
            {
                t = Math.Round(((Convert.ToDouble(txtdiemGK.Text) + Convert.ToDouble(txtdiemCK.Text)) / 2), 2);
                txtDiemTB.Text = t.ToString();
                if (t >= 5)
                {
                    cbKQ.Checked = true;
                }
                else
                {
                    cbKQ.Checked = false;
                }
            }
            catch { }
        }

        private void txtdiemCK_KeyUp(object sender, KeyEventArgs e)
        {
            Double t = 0;
            try
            {
                t = Math.Round(((Convert.ToDouble(txtdiemGK.Text) + Convert.ToDouble(txtdiemCK.Text)) / 2), 2);
                txtDiemTB.Text = t.ToString();
                if (t >= 5)
                {
                    cbKQ.Checked = true;
                }
                else
                {
                    cbKQ.Checked = false;
                }
            }
            catch { }
        }

        private void txtdiemGK_KeyPress(object sender, KeyPressEventArgs e)
        {          
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != ',')
                e.Handled = true;
        }

        private void txtdiemCK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != ',' )
                e.Handled = true;
        }
    }
}

