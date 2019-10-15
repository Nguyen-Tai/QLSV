namespace QLSVLinq
{
    partial class frmThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnExit = new System.Windows.Forms.Button();
            this.hoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSV = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdbHoTen = new System.Windows.Forms.RadioButton();
            this.rdbMaSV = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtGT = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txttenSV = new System.Windows.Forms.TextBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chartTC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSV)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTC)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(813, 382);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 39);
            this.btnExit.TabIndex = 39;
            this.btnExit.Text = "Thoát ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // hoTen
            // 
            this.hoTen.DataPropertyName = "hoTen";
            this.hoTen.HeaderText = "Họ Tên SV";
            this.hoTen.Name = "hoTen";
            this.hoTen.Width = 120;
            // 
            // maSV
            // 
            this.maSV.DataPropertyName = "maSV";
            this.maSV.HeaderText = "Mã SV";
            this.maSV.Name = "maSV";
            this.maSV.Width = 80;
            // 
            // dgvSV
            // 
            this.dgvSV.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSV,
            this.hoTen});
            this.dgvSV.Location = new System.Drawing.Point(6, 15);
            this.dgvSV.Name = "dgvSV";
            this.dgvSV.Size = new System.Drawing.Size(241, 342);
            this.dgvSV.TabIndex = 0;
            this.dgvSV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSV_CellClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvSV);
            this.groupBox4.Location = new System.Drawing.Point(12, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 363);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách sinh viên";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(156, 54);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(58, 23);
            this.btnTim.TabIndex = 9;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(10, 55);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(143, 20);
            this.txtSearch.TabIndex = 2;
            // 
            // rdbHoTen
            // 
            this.rdbHoTen.AutoSize = true;
            this.rdbHoTen.Location = new System.Drawing.Point(107, 23);
            this.rdbHoTen.Name = "rdbHoTen";
            this.rdbHoTen.Size = new System.Drawing.Size(106, 17);
            this.rdbHoTen.TabIndex = 1;
            this.rdbHoTen.TabStop = true;
            this.rdbHoTen.Text = "Theo Họ Tên SV";
            this.rdbHoTen.UseVisualStyleBackColor = true;
            // 
            // rdbMaSV
            // 
            this.rdbMaSV.AutoSize = true;
            this.rdbMaSV.Location = new System.Drawing.Point(16, 23);
            this.rdbMaSV.Name = "rdbMaSV";
            this.rdbMaSV.Size = new System.Drawing.Size(85, 17);
            this.rdbMaSV.TabIndex = 0;
            this.rdbMaSV.TabStop = true;
            this.rdbMaSV.Text = "Theo Mã SV";
            this.rdbMaSV.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(353, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 26);
            this.label9.TabIndex = 38;
            this.label9.Text = "Biểu đồ số tín chỉ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnTim);
            this.groupBox5.Controls.Add(this.txtSearch);
            this.groupBox5.Controls.Add(this.rdbHoTen);
            this.groupBox5.Controls.Add(this.rdbMaSV);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(13, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 93);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tìm kiếm";
            // 
            // txtGT
            // 
            this.txtGT.Enabled = false;
            this.txtGT.Location = new System.Drawing.Point(94, 108);
            this.txtGT.Name = "txtGT";
            this.txtGT.Size = new System.Drawing.Size(100, 20);
            this.txtGT.TabIndex = 35;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(94, 82);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // txttenSV
            // 
            this.txttenSV.Enabled = false;
            this.txttenSV.Location = new System.Drawing.Point(94, 53);
            this.txttenSV.Name = "txttenSV";
            this.txttenSV.Size = new System.Drawing.Size(137, 20);
            this.txttenSV.TabIndex = 34;
            // 
            // txtMaSV
            // 
            this.txtMaSV.Enabled = false;
            this.txtMaSV.Location = new System.Drawing.Point(94, 26);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(100, 20);
            this.txtMaSV.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGT);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.txttenSV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMaSV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(711, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 149);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên SV :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giới tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã SV :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày sinh";
            // 
            // chartTC
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTC.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTC.Legends.Add(legend1);
            this.chartTC.Location = new System.Drawing.Point(318, 104);
            this.chartTC.Name = "chartTC";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTC.Series.Add(series1);
            this.chartTC.Size = new System.Drawing.Size(300, 300);
            this.chartTC.TabIndex = 40;
            this.chartTC.Text = "chart1";
            this.chartTC.Click += new System.EventHandler(this.chartTC_Click);
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(998, 483);
            this.Controls.Add(this.chartTC);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSV)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSV;
        private System.Windows.Forms.DataGridView dgvSV;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdbHoTen;
        private System.Windows.Forms.RadioButton rdbMaSV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtGT;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txttenSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTC;
    }
}