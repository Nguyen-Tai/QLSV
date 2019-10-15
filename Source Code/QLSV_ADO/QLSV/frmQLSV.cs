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
    public partial class frmQLSV : Form
    {
        BLKhoa k = new BLKhoa();
        BLLop l = new BLLop();
        BLSinhvien sv = new BLSinhvien();
        bool Them;
        private void Enabletxt(bool t)
        {
            txtMaSV.Enabled = t;
            txtHoTen.Enabled = t;
            dtpNS.Enabled = t;
            rdbNam.Enabled = t;
            rdbNu.Enabled = t;
            txtDiaChi.Enabled = t;
            cboMalop.Enabled = t;
        }
        private void resettext()
        {
            txtMaSV.ResetText();
            txtHoTen.ResetText();
            dtpNS.ResetText();
            rdbNam.ResetText();
            rdbNu.ResetText();
            txtDiaChi.ResetText();
            cboKhoahoc.ResetText();
        }
        public frmQLSV()
        {
            InitializeComponent();
        }
        private void LoadComboboxKhoa()
        {
            DataTable table = new DataTable();
            table = k.GetKhoa();
            DataRow r = table.NewRow();
            r["maKhoa"] = "Tất cả";
            table.Rows.InsertAt(r, 0);

            cboKhoahoc.DataSource = table;
            cboKhoahoc.ValueMember = "maKhoa";
            cboKhoahoc.DisplayMember = "maKhoa";
        }
        private void LoadComboboxLop(string Khoahoc)
        {
            DataTable table = new DataTable();
            table = l.GetLopByKhoa(Khoahoc);
            DataRow r = table.NewRow();
            r["maLop"] = "Tất cả";
            table.Rows.InsertAt(r, 0);
     
            cboLop.DataSource = table;
            cboLop.ValueMember = "maLop";
            cboLop.DisplayMember = "maLop";
        }
        private void frmQLSV_Load(object sender, EventArgs e)
        {
            dgrDSSV.DataSource = sv.GetSinhvien();
            dgrDSSV.AllowUserToAddRows = false;
            dgrDSSV.ReadOnly = true;
            rdbMaSV.Checked = true;
            dgrDSSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgrDSSV.Columns["ngaySinh"].DefaultCellStyle.Format = "MM/dd/yyyy";
            LoadComboboxKhoa();
            LoadComboboxLop(cboKhoahoc.Text);
            cboMalop.DataSource = l.GetLop();
            cboMalop.ValueMember = "maLop";
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

        private void cboKhoahoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboboxLop(cboKhoahoc.Text);            
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaSV.Checked) //tìm theo mã SV
            {
                dgrDSSV.DataSource = sv.SearchSVByMaSVKL(txtSearch.Text.Trim(), cboKhoahoc.SelectedValue.ToString(), cboLop.SelectedValue.ToString());
            }
            else   //tìm theo Họ Tên SV
            {
                dgrDSSV.DataSource = sv.SearchSVByHoTenSVKL(txtSearch.Text.Trim(), cboKhoahoc.SelectedValue.ToString(), cboLop.SelectedValue.ToString());
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            dgrDSSV.DataSource = sv.GetSVByKhoaandLop(cboKhoahoc.SelectedValue.ToString(), cboLop.SelectedValue.ToString());
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
            txtMaSV.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh    
                // Lấy thứ tự record hiện hành     
                int r = dgrDSSV.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành       
                string str = dgrDSSV.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL  

                // Hiện thông báo xác nhận việc xóa mẫu tin       
                // Khai báo biến traloi            
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp    
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?           
                if (traloi == DialogResult.Yes)
                {
                    if (sv.DeleteSV(str))
                    {
                        // Cập nhật lại DataGridView                
                        dgrDSSV.DataSource = sv.GetSinhvien();
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
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Xóa không được,Vui lòng chọn môn muốn xóa");
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi");
            }
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
                        if (sv.InsertSV(this.txtMaSV.Text, this.txtHoTen.Text,this.dtpNS.Text, rdbNam.Checked ? "Nam" : "Nữ",txtDiaChi.Text,cboMalop.Text))
                        {
                            // Load lại dữ liệu trên DataGridView     
                            dgrDSSV.DataSource = sv.GetSinhvien();
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
                    if (sv.UpdateSV(this.txtMaSV.Text, this.txtHoTen.Text, this.dtpNS.Text, (rdbNam.Checked) ? "Nam" : "Nữ", txtDiaChi.Text, cboMalop.Text))
                    {
                        // Load lại dữ liệu trên DataGridView      
                        dgrDSSV.DataSource = sv.GetSinhvien();
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
            txtMaSV.Enabled = false;
            txtHoTen.Focus();
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

        private void dgrDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgrDSSV.CurrentCell.RowIndex;
            this.txtMaSV.Text = dgrDSSV.Rows[r].Cells["maSV"].Value.ToString();
            this.txtHoTen.Text = dgrDSSV.Rows[r].Cells["hoTen"].Value.ToString();
            this.dtpNS.Text = dgrDSSV.Rows[r].Cells["ngaySinh"].Value.ToString();
            this.txtDiaChi.Text = dgrDSSV.Rows[r].Cells["diaChi"].Value.ToString();
            this.cboMalop.Text= dgrDSSV.Rows[r].Cells["maLop"].Value.ToString();
            if (dgrDSSV.Rows[r].Cells["gioiTinh"].Value.ToString() == "Nam") rdbNam.Checked = true; else rdbNam.Checked = false;
            if (dgrDSSV.Rows[r].Cells["gioiTinh"].Value.ToString() == "Nữ") rdbNu.Checked = true; else rdbNu.Checked = false;

        }
    }
}
