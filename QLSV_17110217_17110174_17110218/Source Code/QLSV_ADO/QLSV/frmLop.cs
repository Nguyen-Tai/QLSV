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
    public partial class frmLop : Form
    {
        bool Them;
        BLLop l = new BLLop();
        BLKhoa k = new BLKhoa();
        public frmLop()
        {
            InitializeComponent();
        }
        private void Enabletxt(bool t)
        {
            txtMaLop.Enabled = t;
            txtTenlop.Enabled = t;
            cboMaKhoa.Enabled = t;
        }
        private void resettext()
        {
            txtMaLop.ResetText();
            txtTenlop.ResetText();
            cboMaKhoa.ResetText();
        }

        private void dgrLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgrLop.CurrentCell.RowIndex;
            this.txtMaLop.Text = dgrLop.Rows[r].Cells["maLop"].Value.ToString();
            this.txtTenlop.Text = dgrLop.Rows[r].Cells["tenLop"].Value.ToString();
            this.cboMaKhoa.Text = dgrLop.Rows[r].Cells["maKhoa"].Value.ToString();
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            dgrLop.DataSource = l.GetLop();
            dgrLop.AllowUserToAddRows = false;
            dgrLop.ReadOnly = true;
            dgrLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            rdbMaLop.Checked = true;
            cboMaKhoa.DataSource = k.GetKhoa();
            cboMaKhoa.ValueMember = "maKhoa";
            cboMaKhoa.DisplayMember = "maKhoa";
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbMaLop.Checked) //tìm theo mã khoa
            {
                dgrLop.DataSource = l.SearchLopByMaLop(txtSearch.Text.Trim());
            }
            else   //tìm theo tên khoa
            {
                dgrLop.DataSource = l.SearchLopByTenLop(txtSearch.Text.Trim());
            }
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
            txtMaLop.Enabled = false;
            txtTenlop.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Mở kết nối        
            // Thêm dữ liệu     
            if (Them)
            {
                if ((!txtMaLop.Text.Trim().Equals("")))
                {
                    try
                    {
                        if (l.InsertLop(this.txtMaLop.Text, this.txtTenlop.Text, this.cboMaKhoa.Text))
                        {
                            // Load lại dữ liệu trên DataGridView     
                            dgrLop.DataSource = l.GetLop();
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
                else MessageBox.Show("Vui lòng điền thông tin");
            }
            else
            {
                if (l.UpdateLop(this.txtMaLop.Text, this.txtTenlop.Text, this.cboMaKhoa.Text))
                {
                    // Load lại dữ liệu trên DataGridView      
                    dgrLop.DataSource = l.GetLop();
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh    
                // Lấy thứ tự record hiện hành     
                int r = dgrLop.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành       
                string str = dgrLop.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL  

                // Hiện thông báo xác nhận việc xóa mẫu tin       
                // Khai báo biến traloi            
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp    
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?           
                if (traloi == DialogResult.Yes)
                {
                    if (l.DeleteLop(str))
                    {
                        // Cập nhật lại DataGridView                
                        dgrLop.DataSource = l.GetLop();
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
            txtMaLop.Focus();
        }
    }
}
