namespace ChamCongRFID
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSectionTitle = new System.Windows.Forms.Label();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblLuong = new System.Windows.Forms.Label();
            this.txtLuongCB = new System.Windows.Forms.TextBox();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.cboPhongBan = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.lblRealTime = new System.Windows.Forms.Label();
            this.lblMaTheRFID = new System.Windows.Forms.Label();
            this.txtMaTheRFID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSectionTitle
            // 
            this.lblSectionTitle.AutoSize = true;
            this.lblSectionTitle.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionTitle.Location = new System.Drawing.Point(30, 20);
            this.lblSectionTitle.Name = "lblSectionTitle";
            this.lblSectionTitle.Size = new System.Drawing.Size(253, 27);
            this.lblSectionTitle.TabIndex = 29;
            this.lblSectionTitle.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // lblMaNV
            // 
            this.lblMaNV.Location = new System.Drawing.Point(31, 150);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(89, 23);
            this.lblMaNV.TabIndex = 28;
            this.lblMaNV.Text = "Mã nhân viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(123, 143);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(112, 30);
            this.txtMaNV.TabIndex = 27;
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtMaNV_TextChanged);
            // 
            // lblHoTen
            // 
            this.lblHoTen.Location = new System.Drawing.Point(328, 150);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(100, 23);
            this.lblHoTen.TabIndex = 26;
            this.lblHoTen.Text = "Họ và tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(416, 143);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(112, 30);
            this.txtHoTen.TabIndex = 25;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Location = new System.Drawing.Point(328, 187);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(75, 23);
            this.lblGioiTinh.TabIndex = 24;
            this.lblGioiTinh.Text = "Giới tính";
            this.lblGioiTinh.Click += new System.EventHandler(this.lblGioiTinh_Click);
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioiTinh.Location = new System.Drawing.Point(416, 179);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(112, 31);
            this.cboGioiTinh.TabIndex = 23;
            this.cboGioiTinh.SelectedIndexChanged += new System.EventHandler(this.cboGioiTinh_SelectedIndexChanged);
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Location = new System.Drawing.Point(31, 187);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(89, 23);
            this.lblNgaySinh.TabIndex = 22;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(123, 181);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(112, 30);
            this.dtpNgaySinh.TabIndex = 21;
            this.dtpNgaySinh.ValueChanged += new System.EventHandler(this.dtpNgaySinh_ValueChanged);
            // 
            // lblSDT
            // 
            this.lblSDT.Location = new System.Drawing.Point(328, 223);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(59, 23);
            this.lblSDT.TabIndex = 20;
            this.lblSDT.Text = "Số ĐT:";
            this.lblSDT.Click += new System.EventHandler(this.lblSDT_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(415, 220);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(113, 30);
            this.txtSDT.TabIndex = 19;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(31, 223);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(75, 23);
            this.lblEmail.TabIndex = 18;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(123, 220);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(112, 30);
            this.txtEmail.TabIndex = 17;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Location = new System.Drawing.Point(31, 260);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(75, 29);
            this.lblDiaChi.TabIndex = 16;
            this.lblDiaChi.Text = "Địa chỉ";
            this.lblDiaChi.Click += new System.EventHandler(this.lblDiaChi_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(123, 257);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(305, 30);
            this.txtDiaChi.TabIndex = 15;
            // 
            // lblLuong
            // 
            this.lblLuong.Location = new System.Drawing.Point(737, 187);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(88, 23);
            this.lblLuong.TabIndex = 14;
            this.lblLuong.Text = "Lương CB";
            this.lblLuong.Click += new System.EventHandler(this.lblLuong_Click);
            // 
            // txtLuongCB
            // 
            this.txtLuongCB.Location = new System.Drawing.Point(843, 184);
            this.txtLuongCB.Name = "txtLuongCB";
            this.txtLuongCB.Size = new System.Drawing.Size(100, 30);
            this.txtLuongCB.TabIndex = 13;
            // 
            // lblPhongBan
            // 
            this.lblPhongBan.Location = new System.Drawing.Point(737, 150);
            this.lblPhongBan.Name = "lblPhongBan";
            this.lblPhongBan.Size = new System.Drawing.Size(100, 23);
            this.lblPhongBan.TabIndex = 12;
            this.lblPhongBan.Text = "Phòng ban";
            this.lblPhongBan.Click += new System.EventHandler(this.lblPhongBan_Click);
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.Items.AddRange(new object[] {
            "PB01",
            "PB02",
            "PB03"});
            this.cboPhongBan.Location = new System.Drawing.Point(843, 142);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.Size = new System.Drawing.Size(100, 31);
            this.cboPhongBan.TabIndex = 11;
            this.cboPhongBan.SelectedIndexChanged += new System.EventHandler(this.cboPhongBan_SelectedIndexChanged);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Location = new System.Drawing.Point(737, 223);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(100, 23);
            this.lblTrangThai.TabIndex = 8;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Items.AddRange(new object[] {
            "Đang làm",
            "Nghỉ việc",
            "Tăng ca"});
            this.cboTrangThai.Location = new System.Drawing.Point(843, 220);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(100, 31);
            this.cboTrangThai.TabIndex = 7;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Location = new System.Drawing.Point(525, 104);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 30);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(631, 104);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 30);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(737, 103);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 32);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = " Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.White;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.Black;
            this.btnLamMoi.Location = new System.Drawing.Point(843, 103);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 32);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(35, 103);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 30);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.Text = "Tìm kiếm nhân viên ...";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Location = new System.Drawing.Point(241, 103);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(85, 30);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNhanVien.ColumnHeadersHeight = 29;
            this.dgvNhanVien.EnableHeadersVisualStyles = false;
            this.dgvNhanVien.Location = new System.Drawing.Point(35, 312);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(908, 299);
            this.dgvNhanVien.TabIndex = 0;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            this.dgvNhanVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 19);
            this.label1.TabIndex = 30;
            this.label1.Text = "Quản lí thông tin nhân viên trong hệ thống ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // lblRealTime
            // 
            this.lblRealTime.AutoSize = true;
            this.lblRealTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRealTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblRealTime.Location = new System.Drawing.Point(626, 17);
            this.lblRealTime.Name = "lblRealTime";
            this.lblRealTime.Size = new System.Drawing.Size(219, 28);
            this.lblRealTime.TabIndex = 0;
            this.lblRealTime.Text = "Thời gian hệ thống: ...";
            this.lblRealTime.Click += new System.EventHandler(this.lblRealTime_Click);
            // 
            // lblMaTheRFID
            // 
            this.lblMaTheRFID.Location = new System.Drawing.Point(443, 260);
            this.lblMaTheRFID.Name = "lblMaTheRFID";
            this.lblMaTheRFID.Size = new System.Drawing.Size(85, 23);
            this.lblMaTheRFID.TabIndex = 33;
            this.lblMaTheRFID.Text = "Mã RFID";
            // 
            // txtMaTheRFID
            // 
            this.txtMaTheRFID.Location = new System.Drawing.Point(525, 257);
            this.txtMaTheRFID.Name = "txtMaTheRFID";
            this.txtMaTheRFID.Size = new System.Drawing.Size(113, 30);
            this.txtMaTheRFID.TabIndex = 34;
            this.txtMaTheRFID.TextChanged += new System.EventHandler(this.txtMaTheRFID_TextChanged);
            // 
            // FormMain
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(980, 660);
            this.Controls.Add(this.lblRealTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cboTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cboPhongBan);
            this.Controls.Add(this.lblPhongBan);
            this.Controls.Add(this.txtLuongCB);
            this.Controls.Add(this.lblLuong);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.lblSectionTitle);
            this.Controls.Add(this.lblMaTheRFID);
            this.Controls.Add(this.txtMaTheRFID);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "HRM System";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblSectionTitle;
        private System.Windows.Forms.Label lblMaNV, lblHoTen, lblGioiTinh, lblNgaySinh, lblSDT, lblEmail, lblDiaChi, lblLuong, lblPhongBan, lblTrangThai;
        private System.Windows.Forms.TextBox txtMaNV, txtHoTen, txtSDT, txtEmail, txtDiaChi, txtLuongCB, txtTimKiem;
        private System.Windows.Forms.ComboBox cboGioiTinh, cboPhongBan, cboTrangThai;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnLamMoi, btnTimKiem;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Label lblRealTime;
        private System.Windows.Forms.Label lblMaTheRFID;
        private System.Windows.Forms.TextBox txtMaTheRFID;
    }
}