namespace QLSV
{
    partial class fReportDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
//            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportDiemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new QLSV.DataSet1();
  //          this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportDiemTableAdapter = new QLSV.DataSet1TableAdapters.ReportDiemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDiemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportDiemBindingSource
            // 
            this.ReportDiemBindingSource.DataMember = "ReportDiem";
            this.ReportDiemBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.EnforceConstraints = false;
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
          //  reportDataSource1.Name = "DataSet1";
           // reportDataSource1.Value = this.ReportDiemBindingSource;
            //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLSV.ReportDiem.rdlc";
            //this.reportViewer1.Location = new System.Drawing.Point(1, 5);
            //this.reportViewer1.Name = "reportViewer1";
            //this.reportViewer1.ServerReport.BearerToken = null;
            //this.reportViewer1.Size = new System.Drawing.Size(831, 557);
            //this.reportViewer1.TabIndex = 0;
            // 
            // ReportDiemTableAdapter
            // 
            this.ReportDiemTableAdapter.ClearBeforeFill = true;
            // 
            // fReportDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 563);
          //  this.Controls.Add(this.reportViewer1);
            this.Name = "fReportDiem";
            this.Text = "Report điểm";
            this.Load += new System.EventHandler(this.ReportDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportDiemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       // private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReportDiemBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.ReportDiemTableAdapter ReportDiemTableAdapter;
    }
}