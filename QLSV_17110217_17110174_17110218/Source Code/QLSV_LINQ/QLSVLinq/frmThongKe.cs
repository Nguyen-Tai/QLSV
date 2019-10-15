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
    public partial class frmThongKe : Form
    {
        string user; string pass; string quyen;
        bool Add;
        string err;
        BLKhoa dbKhoa = new BLKhoa();
        BLLop dbLop = new BLLop();
        BLSV dbSV = new BLSV();
        BLThongKe dbThongKe = new BLThongKe();
        

        public frmThongKe()
        {
            InitializeComponent();
        }
        public frmThongKe(string user, string pass, string quyen)
        {
            InitializeComponent();
            this.user = user;
            this.pass = pass;
            this.quyen = quyen;
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            rdbMaSV.Checked = true;
            if (quyen == "Member")
            {
                groupBox5.Enabled = false;
                dgvSV.DataSource = dbSV.TimMaSinhVien(user);
                dgvSV.AllowUserToAddRows = false;
                dgvSV.ReadOnly = true;
                dgvSV.AutoGenerateColumns = false;
                rdbMaSV.Checked = true;
                dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                dgvSV.DataSource = dbSV.LaySinhVien();
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

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvSV.CurrentCell.RowIndex;
            this.txtMaSV.Text = dgvSV.Rows[r].Cells["maSV"].Value.ToString();
            this.txttenSV.Text = dgvSV.Rows[r].Cells["hoTen"].Value.ToString();
            this.dateTimePicker1.Text = dgvSV.Rows[r].Cells["ngaySinh"].Value.ToString();
            this.txtGT.Text = dgvSV.Rows[r].Cells["gioiTinh"].Value.ToString();
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.Mons
                           from up in qlSV.KetQuas
                           where tp.maMon == up.maMon && up.maSV == txtMaSV.Text
                           orderby up.maSV, tp.hocKi
                           select tp).ToList();
            chartTC.DataSource = tpQuery;

            chartTC.ChartAreas["ChartArea1"].AxisX.Title = "Học Kì";
            chartTC.ChartAreas["ChartArea1"].AxisY.Title = "Số tín chỉ";
            chartTC.Series["Đăng kí"].XValueMember = "hocKi";
            chartTC.Series["Đăng kí"].YValueMembers = "stcHoc";
            chartTC.Series["Tích lũy"].XValueMember = "hocKi";
            chartTC.Series["Tích lũy"].YValueMembers = "stcdau";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbMaSV.Checked) //tìm theo mã SV
                {
                    dgvSV.DataSource = dbSV.TimMaSinhVien(txtSearch.Text.Trim());
                    dgvSV.Columns.Remove("maLop");
                    dgvSV.Columns["ngaySinh"].Visible = false;
                    dgvSV.Columns["gioiTinh"].Visible = false;
                    dgvSV.Columns.Remove("diaChi");
                    //dgvSV.AllowUserToAddRows = false;
                    //dgvSV.ReadOnly = true;
                    //dgvSV.AutoGenerateColumns = false;
                    //rdbMaSV.Checked = true;
                    //dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
                else   //tìm theo Họ Tên SV
                {
                    dgvSV.DataSource = dbSV.TimTenSinhVien(txtSearch.Text.Trim());
                    dgvSV.Columns.Remove("maLop");
                    dgvSV.Columns["ngaySinh"].Visible = false;
                    dgvSV.Columns["gioiTinh"].Visible = false;
                    dgvSV.Columns.Remove("diaChi");

                    //dgvSV.AllowUserToAddRows = false;
                    //dgvSV.ReadOnly = true;
                    //dgvSV.AutoGenerateColumns = false;
                    //rdbMaSV.Checked = true;
                    //dgvSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch { }
        }

        private void chartTC_Click(object sender, EventArgs e)
        {

        }
    }
}
