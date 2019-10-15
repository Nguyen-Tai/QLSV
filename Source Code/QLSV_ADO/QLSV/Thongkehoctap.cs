using QLSV.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class Thongkehoctap : Form
    {
        string user; string pass; string quyen;
        BLThongKe tk = new BLThongKe();
        BLSinhvien sv = new BLSinhvien();
        public Thongkehoctap()
        {
            InitializeComponent();
        }
        public Thongkehoctap(string user, string pass, string quyen)
        {
            InitializeComponent();
            this.user = user;
            this.pass = pass;
            this.quyen = quyen;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbMaSV.Checked) //tìm theo mã SV
                {
                    dgvSV.DataSource = sv.SearchSVByMaSV(txtSearch.Text.Trim());
                    dgvSV.Columns.Remove("maLop");
                    dgvSV.Columns["ngaySinh"].Visible = false;
                    dgvSV.Columns["gioiTinh"].Visible = false;
                    dgvSV.Columns.Remove("diaChi");
                }
                else   //tìm theo Họ Tên SV
                {
                    dgvSV.DataSource = sv.SearchSVByHoTenSV(txtSearch.Text.Trim());
                    dgvSV.Columns.Remove("maLop");
                    dgvSV.Columns["ngaySinh"].Visible = false;
                    dgvSV.Columns["gioiTinh"].Visible = false;
                    dgvSV.Columns.Remove("diaChi");
                }
            }
            catch { }
        }
        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvSV.CurrentCell.RowIndex;
            this.txtMaSV.Text = dgvSV.Rows[r].Cells["maSV"].Value.ToString();
            this.txttenSV.Text = dgvSV.Rows[r].Cells["hoTen"].Value.ToString();
            this.dateTimePicker1.Text = dgvSV.Rows[r].Cells["ngaySinh"].Value.ToString();
            this.txtGT.Text = dgvSV.Rows[r].Cells["gioiTinh"].Value.ToString();
            chartTC.DataSource = tk.GetTC(txtMaSV.Text);

            chartTC.ChartAreas["ChartArea1"].AxisX.Title = "Học Kì";
            chartTC.ChartAreas["ChartArea1"].AxisY.Title = "Số tín chỉ";
            chartTC.Series["Đăng kí"].XValueMember = "hocKi";
            chartTC.Series["Đăng kí"].YValueMembers = "stcHoc";
            chartTC.Series["Tích lũy"].XValueMember = "hocKi";
            chartTC.Series["Tích lũy"].YValueMembers = "stcdau";
        }

        private void Thongkehoctap_Load(object sender, EventArgs e)
        {
            rdbMaSV.Checked = true;
            if (quyen == "Member")
            {
                groupBox5.Enabled = false;
                dgvSV.DataSource = sv.SearchSVByMaSV(user);
                dgvSV.Columns.Remove("maLop");
                dgvSV.Columns["ngaySinh"].Visible = false;
                dgvSV.Columns["gioiTinh"].Visible = false;
                dgvSV.Columns.Remove("diaChi");
                dgvSV.AllowUserToAddRows = false;
                dgvSV.ReadOnly = true;
                dgvSV.AutoGenerateColumns = false;
                rdbMaSV.Checked = true;
                dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                dgvSV.DataSource = sv.GetSinhvien();
                dgvSV.Columns.Remove("maLop");
                dgvSV.Columns["ngaySinh"].Visible = false;
                dgvSV.Columns["gioiTinh"].Visible = false;
                dgvSV.Columns.Remove("diaChi");
                dgvSV.AllowUserToAddRows = false;
                dgvSV.ReadOnly = true;
                dgvSV.AutoGenerateColumns = false;
                rdbMaSV.Checked = true;
                dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
