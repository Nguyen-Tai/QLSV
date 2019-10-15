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
    public partial class frmMonHoc : Form
    {
        BLMonhoc mh = new BLMonhoc();
        BLKhoa k = new BLKhoa();
        bool Them;
        public frmMonHoc()
        {
            InitializeComponent();
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
            txtMaMon.Focus();
        }
        private void Enabletxt(bool t)
        {
            txtMaMon.Enabled = t;
            txtTenMon.Enabled = t;
            txtSTC.Enabled = t;
            txtHocKy.Enabled = t;
            cboKhoa.Enabled = t;
        }
        private void resettext()
        {
            txtMaMon.ResetText();
            txtTenMon.ResetText();
            txtSTC.ResetText();
            txtHocKy.ResetText();
            cboKhoa.ResetText();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Mở kết nối        
            // Thêm dữ liệu     
            if (Them)
            {
                if ((!txtMaMon.Text.Trim().Equals("")))
                {
                    try
                    {
                        if (mh.InsertMonhoc(this.txtMaMon.Text, this.txtTenMon.Text, this.cboKhoa.Text, this.txtSTC.Text, this.txtHocKy.Text))
                        {
                            // Load lại dữ liệu trên DataGridView     
                            dgrMON.DataSource = mh.GetMonhoc();
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
                if (mh.UpdateMonhoc(this.txtMaMon.Text, this.txtTenMon.Text, this.cboKhoa.Text, this.txtSTC.Text, this.txtHocKy.Text))
                {
                    // Load lại dữ liệu trên DataGridView      
                    dgrMON.DataSource = mh.GetMonhoc();
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
            txtMaMon.Enabled = false;
            txtTenMon.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh    
                // Lấy thứ tự record hiện hành     
                int r = dgrMON.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành       
                string str = dgrMON.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL  

                // Hiện thông báo xác nhận việc xóa mẫu tin       
                // Khai báo biến traloi            
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp    
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?           
                if (traloi == DialogResult.Yes)
                {
                    if (mh.DeleteMonhoc(str))
                    {
                        // Cập nhật lại DataGridView                
                        dgrMON.DataSource = mh.GetMonhoc();
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

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            dgrMON.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgrMON.AllowUserToAddRows = false;
            dgrMON.ReadOnly = true;       
            dgrMON.DataSource = mh.GetMonhoc();
            cboKhoa.DataSource = k.GetKhoa();
            cboKhoa.ValueMember = "maKhoa";
            cboKhoa.DisplayMember = "maKhoa";
            rdbMaMon.Checked = true;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdbMaMon.Checked) //tìm theo mã môn
            {
                dgrMON.DataSource = mh.SearchMonByMaMon(txtSearch.Text.Trim());
            }
            else   //tìm theo tên khoa
            {
                dgrMON.DataSource = mh.SearchMonByTenMon(txtSearch.Text.Trim());
            }
        }

        private void dgrMON_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgrMON.CurrentCell.RowIndex;
            this.txtMaMon.Text = dgrMON.Rows[r].Cells["maMon"].Value.ToString();
            this.txtTenMon.Text = dgrMON.Rows[r].Cells["tenMon"].Value.ToString();
            this.txtSTC.Text = dgrMON.Rows[r].Cells["soTinChi"].Value.ToString();
            this.txtHocKy.Text = dgrMON.Rows[r].Cells["hocKi"].Value.ToString();
            this.cboKhoa.Text = dgrMON.Rows[r].Cells["maKhoa"].Value.ToString();
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
    }
}
