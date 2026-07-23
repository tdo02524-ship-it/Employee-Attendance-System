namespace ChamCongRFID
{
    partial class FormThuongPhat
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvThuongPhat = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuongPhat)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(305, 27);
            this.lblTitle.TabIndex = 16;
            this.lblTitle.Text = "QUẢN LÝ THƯỞNG / PHẠT";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(475, 78);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(41, 23);
            this.lblLoai.TabIndex = 15;
            this.lblLoai.Text = "Loại";
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.Items.AddRange(new object[] {
            "Thưởng",
            "Phạt"});
            this.cboLoai.Location = new System.Drawing.Point(511, 70);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(100, 31);
            this.cboLoai.TabIndex = 14;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(31, 78);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(114, 23);
            this.lblMaNV.TabIndex = 13;
            this.lblMaNV.Text = "Mã nhân viên";
            this.lblMaNV.Click += new System.EventHandler(this.lblMaNV_Click);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(140, 71);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(100, 30);
            this.txtMaNV.TabIndex = 12;
            this.txtMaNV.TextChanged += new System.EventHandler(this.txtMaNV_TextChanged);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(246, 78);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(84, 23);
            this.lblHoTen.TabIndex = 11;
            this.lblHoTen.Text = "Họ và tên";
            this.lblHoTen.Click += new System.EventHandler(this.lblHoTen_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(326, 71);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(143, 30);
            this.txtHoTen.TabIndex = 10;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(617, 78);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(50, 23);
            this.lblNgay.TabIndex = 9;
            this.lblNgay.Text = "Ngày";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(663, 72);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(100, 30);
            this.dtpNgay.TabIndex = 8;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(31, 113);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(63, 23);
            this.lblSoTien.TabIndex = 7;
            this.lblSoTien.Text = "Số tiền";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(140, 110);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(100, 30);
            this.txtSoTien.TabIndex = 6;
            this.txtSoTien.TextChanged += new System.EventHandler(this.txtSoTien_TextChanged);
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(246, 113);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(50, 23);
            this.lblLyDo.TabIndex = 5;
            this.lblLyDo.Text = "Lý do";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(326, 110);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(285, 30);
            this.txtLyDo.TabIndex = 4;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.LawnGreen;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(744, 107);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = " Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.LightGreen;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.Black;
            this.btnLamMoi.Location = new System.Drawing.Point(830, 107);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 35);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click_1);
            // 
            // dgvThuongPhat
            // 
            this.dgvThuongPhat.AllowUserToAddRows = false;
            this.dgvThuongPhat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuongPhat.BackgroundColor = System.Drawing.Color.White;
            this.dgvThuongPhat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvThuongPhat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThuongPhat.ColumnHeadersHeight = 29;
            this.dgvThuongPhat.EnableHeadersVisualStyles = false;
            this.dgvThuongPhat.Location = new System.Drawing.Point(30, 183);
            this.dgvThuongPhat.Name = "dgvThuongPhat";
            this.dgvThuongPhat.ReadOnly = true;
            this.dgvThuongPhat.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvThuongPhat.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThuongPhat.RowTemplate.Height = 40;
            this.dgvThuongPhat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuongPhat.Size = new System.Drawing.Size(890, 333);
            this.dgvThuongPhat.TabIndex = 0;
            this.dgvThuongPhat.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvThuongPhat_CellFormatting);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.PaleGreen;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Location = new System.Drawing.Point(658, 107);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 35);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // FormThuongPhat
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(960, 560);
            this.Controls.Add(this.dgvThuongPhat);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtLyDo);
            this.Controls.Add(this.lblLyDo);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.lblSoTien);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.cboLoai);
            this.Controls.Add(this.lblLoai);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThuongPhat";
            this.Text = "Thưởng Phạt";
            this.Load += new System.EventHandler(this.FormThuongPhat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuongPhat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle, lblLoai, lblMaNV, lblHoTen, lblNgay, lblSoTien, lblLyDo;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.TextBox txtMaNV, txtHoTen, txtSoTien, txtLyDo;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Button btnXoa, btnLamMoi;
        private System.Windows.Forms.DataGridView dgvThuongPhat;
        private System.Windows.Forms.Button btnThem;
    }
}