namespace QLSVLinq
{
    partial class frmRP
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Report = new QLSVLinq.Report();
            this.ReportDiemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportDiemTableAdapter = new QLSVLinq.ReportTableAdapters.ReportDiemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDiemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "RP";
            reportDataSource1.Value = this.ReportDiemBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLSVLinq.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(769, 424);
            this.reportViewer1.TabIndex = 0;
            // 
            // Report
            // 
            this.Report.DataSetName = "Report";
            this.Report.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportDiemBindingSource
            // 
            this.ReportDiemBindingSource.DataMember = "ReportDiem";
            this.ReportDiemBindingSource.DataSource = this.Report;
            // 
            // ReportDiemTableAdapter
            // 
            this.ReportDiemTableAdapter.ClearBeforeFill = true;
            // 
            // frmRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 426);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRP";
            this.Text = "frmRP";
            this.Load += new System.EventHandler(this.frmRP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDiemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReportDiemBindingSource;
        private Report Report;
        private ReportTableAdapters.ReportDiemTableAdapter ReportDiemTableAdapter;
    }
}