using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVLinq
{
    public partial class frmRP : Form
    {
        private string maSV;
        public frmRP()
        {
            InitializeComponent();
        }
        public frmRP(string masv) : this()
        {
            this.maSV = masv;
        }
        private void frmRP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Report.ReportDiem' table. You can move, or remove it, as needed.
            this.ReportDiemTableAdapter.Fill(this.Report.ReportDiem,maSV);

            this.reportViewer1.RefreshReport();
        }
    }
}
