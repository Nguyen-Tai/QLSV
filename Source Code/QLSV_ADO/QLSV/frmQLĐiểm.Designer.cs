namespace QLSV
{
    partial class frmQLDiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLDiem));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvSV = new System.Windows.Forms.DataGridView();
            this.maSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.cbMon = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbKQ = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdiemGK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiemTB = new System.Windows.Forms.TextBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtdiemCK = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.maMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTinChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemGiuaKi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemCuoiKi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hocKi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ketQua = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.cboSLop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdbHoTen = new System.Windows.Forms.RadioButton();
            this.rdbMaSV = new System.Windows.Forms.RadioButton();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSV)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvSV);
            this.groupBox4.Location = new System.Drawing.Point(239, 40);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 476);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách sinh viên";
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
            this.dgvSV.Size = new System.Drawing.Size(244, 455);
            this.dgvSV.TabIndex = 0;
            this.dgvSV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSV_CellClick);
            // 
            // maSV
            // 
            this.maSV.DataPropertyName = "maSV";
            this.maSV.HeaderText = "Mã SV";
            this.maSV.Name = "maSV";
            this.maSV.Width = 80;
            // 
            // hoTen
            // 
            this.hoTen.DataPropertyName = "hoTen";
            this.hoTen.HeaderText = "Họ Tên SV";
            this.hoTen.Name = "hoTen";
            this.hoTen.Width = 120;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbLop);
            this.groupBox2.Controls.Add(this.cbMon);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbKQ);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtdiemGK);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDiemTB);
            this.groupBox2.Controls.Add(this.txtMaSV);
            this.groupBox2.Controls.Add(this.txtdiemCK);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtHoTen);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(495, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 212);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin điểm chi tiết";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(401, 171);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 13);
            this.label20.TabIndex = 51;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(310, 171);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 50;
            this.label18.Text = "Số tín chỉ :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(231, 143);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(0, 13);
            this.label21.TabIndex = 49;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(120, 143);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 13);
            this.label19.TabIndex = 47;
            this.label19.Text = "Điểm TB toàn khóa :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(73, 171);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 13);
            this.label17.TabIndex = 45;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(73, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 13);
            this.label16.TabIndex = 44;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 171);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 43;
            this.label15.Text = "STC Rớt :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "STC Đậu :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 41;
            // 
            // cbLop
            // 
            this.cbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(76, 81);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(185, 21);
            this.cbLop.TabIndex = 39;
            // 
            // cbMon
            // 
            this.cbMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMon.FormattingEnabled = true;
            this.cbMon.Location = new System.Drawing.Point(76, 109);
            this.cbMon.Name = "cbMon";
            this.cbMon.Size = new System.Drawing.Size(185, 21);
            this.cbMon.TabIndex = 37;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Lớp";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(314, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Học Kì";
            // 
            // cbKQ
            // 
            this.cbKQ.AutoSize = true;
            this.cbKQ.Enabled = false;
            this.cbKQ.Location = new System.Drawing.Point(415, 116);
            this.cbKQ.Name = "cbKQ";
            this.cbKQ.Size = new System.Drawing.Size(15, 14);
            this.cbKQ.TabIndex = 30;
            this.cbKQ.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Kết quả";
            // 
            // txtdiemGK
            // 
            this.txtdiemGK.Location = new System.Drawing.Point(390, 20);
            this.txtdiemGK.Name = "txtdiemGK";
            this.txtdiemGK.Size = new System.Drawing.Size(72, 20);
            this.txtdiemGK.TabIndex = 27;
            this.txtdiemGK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdiemGK_KeyPress);
            this.txtdiemGK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdiemGK_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Điểm TB";
            // 
            // txtDiemTB
            // 
            this.txtDiemTB.Enabled = false;
            this.txtDiemTB.Location = new System.Drawing.Point(390, 85);
            this.txtDiemTB.Name = "txtDiemTB";
            this.txtDiemTB.ReadOnly = true;
            this.txtDiemTB.Size = new System.Drawing.Size(74, 20);
            this.txtDiemTB.TabIndex = 8;
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(76, 24);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(99, 20);
            this.txtMaSV.TabIndex = 5;
            // 
            // txtdiemCK
            // 
            this.txtdiemCK.Location = new System.Drawing.Point(390, 56);
            this.txtdiemCK.Name = "txtdiemCK";
            this.txtdiemCK.Size = new System.Drawing.Size(72, 20);
            this.txtdiemCK.TabIndex = 9;
            this.txtdiemCK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdiemCK_KeyPress);
            this.txtdiemCK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdiemCK_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Mã sinh viên";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(310, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Điểm giữa kì";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Họ và tên";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(310, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Điểm cuối kì";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(76, 55);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(164, 20);
            this.txtHoTen.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Mã môn";
            // 
            // dgvDiem
            // 
            this.dgvDiem.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maMon,
            this.tenMon,
            this.soTinChi,
            this.diemGiuaKi,
            this.diemCuoiKi,
            this.diemTB,
            this.hocKi,
            this.ketQua});
            this.dgvDiem.Location = new System.Drawing.Point(495, 258);
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.Size = new System.Drawing.Size(512, 252);
            this.dgvDiem.TabIndex = 26;
            this.dgvDiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiem_CellClick);
            // 
            // maMon
            // 
            this.maMon.DataPropertyName = "maMon";
            this.maMon.HeaderText = "Mã Môn";
            this.maMon.Name = "maMon";
            this.maMon.Width = 70;
            // 
            // tenMon
            // 
            this.tenMon.DataPropertyName = "tenMon";
            this.tenMon.HeaderText = "Tên Môn";
            this.tenMon.Name = "tenMon";
            this.tenMon.Width = 125;
            // 
            // soTinChi
            // 
            this.soTinChi.DataPropertyName = "soTinChi";
            this.soTinChi.HeaderText = "STC";
            this.soTinChi.Name = "soTinChi";
            this.soTinChi.Width = 40;
            // 
            // diemGiuaKi
            // 
            this.diemGiuaKi.DataPropertyName = "diemGiuaKi";
            this.diemGiuaKi.HeaderText = "Điểm Giữa Kì";
            this.diemGiuaKi.Name = "diemGiuaKi";
            this.diemGiuaKi.Width = 50;
            // 
            // diemCuoiKi
            // 
            this.diemCuoiKi.DataPropertyName = "diemCuoiKi";
            this.diemCuoiKi.HeaderText = "Điểm Cuối Kì";
            this.diemCuoiKi.Name = "diemCuoiKi";
            this.diemCuoiKi.Width = 50;
            // 
            // diemTB
            // 
            this.diemTB.DataPropertyName = "diemTB";
            this.diemTB.HeaderText = "Điểm Trung Bình";
            this.diemTB.Name = "diemTB";
            this.diemTB.Width = 50;
            // 
            // hocKi
            // 
            this.hocKi.DataPropertyName = "hocKi";
            this.hocKi.HeaderText = "Học Kì";
            this.hocKi.Name = "hocKi";
            this.hocKi.Width = 40;
            // 
            // ketQua
            // 
            this.ketQua.DataPropertyName = "ketQua";
            this.ketQua.HeaderText = "Kết Quả";
            this.ketQua.Name = "ketQua";
            this.ketQua.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ketQua.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ketQua.Width = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHienThi);
            this.groupBox1.Controls.Add(this.cboSLop);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboKhoaHoc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 129);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lựa chọn";
            // 
            // btnHienThi
            // 
            this.btnHienThi.Location = new System.Drawing.Point(156, 88);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(58, 23);
            this.btnHienThi.TabIndex = 10;
            this.btnHienThi.Text = "Hiển Thị";
            this.btnHienThi.UseVisualStyleBackColor = true;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // cboSLop
            // 
            this.cboSLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSLop.FormattingEnabled = true;
            this.cboSLop.Location = new System.Drawing.Point(57, 55);
            this.cboSLop.Name = "cboSLop";
            this.cboSLop.Size = new System.Drawing.Size(157, 21);
            this.cboSLop.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lớp";
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaHoc.FormattingEnabled = true;
            this.cboKhoaHoc.Location = new System.Drawing.Point(57, 20);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(157, 21);
            this.cboKhoaHoc.TabIndex = 1;
            this.cboKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.cboKhoaHoc_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Khoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(349, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "THÔNG TIN ĐIỂM SINH VIÊN ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnTim);
            this.groupBox5.Controls.Add(this.txtSearch);
            this.groupBox5.Controls.Add(this.rdbHoTen);
            this.groupBox5.Controls.Add(this.rdbMaSV);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(10, 175);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(223, 93);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tìm kiếm";
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
            // btnHuy
            // 
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(132, 329);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(92, 39);
            this.btnHuy.TabIndex = 35;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDel
            // 
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(31, 374);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(92, 39);
            this.btnDel.TabIndex = 34;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(132, 284);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 39);
            this.btnUpdate.TabIndex = 31;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(31, 419);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 39);
            this.btnExit.TabIndex = 33;
            this.btnExit.Text = "Thoát ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(31, 329);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 39);
            this.btnEdit.TabIndex = 32;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(31, 284);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(92, 39);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Nhập";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.Blue;
            this.btnXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnXuat.Image")));
            this.btnXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuat.Location = new System.Drawing.Point(132, 376);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(92, 37);
            this.btnXuat.TabIndex = 36;
            this.btnXuat.Text = "Report Điểm";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // frmQLĐiểm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1007, 515);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvDiem);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frmQLĐiểm";
            this.Text = "Quản lý điểm sinh viên";
            this.Load += new System.EventHandler(this.frmQLDiem_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiemTB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtdiemCK;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSLop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdiemGK;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdbHoTen;
        private System.Windows.Forms.RadioButton rdbMaSV;
        private System.Windows.Forms.CheckBox cbKQ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.DataGridView dgvSV;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbMon;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn maMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn soTinChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemGiuaKi;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemCuoiKi;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn hocKi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ketQua;
    }
}