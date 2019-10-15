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
    public partial class fReportDiem : Form
    {
        private string maSV;
        public fReportDiem()
        {
            InitializeComponent();
        }
        public fReportDiem(string masv):this()
        {
            this.maSV = masv;
        }
        private void ReportDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.ReportDiem' table. You can move, or remove it, as needed.
            this.ReportDiemTableAdapter.Fill(this.DataSet1.ReportDiem,maSV);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
