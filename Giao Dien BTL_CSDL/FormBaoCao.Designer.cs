namespace ChamCongRFID
{
    partial class FormBaoCao
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
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.cboLoaiBC = new System.Windows.Forms.ComboBox();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.pnlCardNhanVien = new System.Windows.Forms.Panel();
            this.pnlCardLuong = new System.Windows.Forms.Panel();
            this.pnlCardThuong = new System.Windows.Forms.Panel();
            this.pnlCardPhat = new System.Windows.Forms.Panel();
            this.dgvTopLuong = new System.Windows.Forms.DataGridView();
            this.lblTopTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopLuong)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black; // Chuyển sang chữ đen
            this.lblTitle.Location = new System.Drawing.Point(25, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(286, 37);
            this.lblTitle.Text = "BÁO CÁO THỐNG KÊ";
             
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.ForeColor = System.Drawing.Color.Black; // Chuyển sang chữ đen
            this.lblTuNgay.Location = new System.Drawing.Point(30, 70);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(71, 23);
            this.lblTuNgay.Text = "Từ ngày";
            
            this.dtpTuNgay.Location = new System.Drawing.Point(105, 65);
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 30);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.ForeColor = System.Drawing.Color.Black; // Chuyển sang chữ đen
            this.lblDenNgay.Location = new System.Drawing.Point(245, 70);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(83, 23);
            this.lblDenNgay.Text = "Đến ngày";
           
            this.dtpDenNgay.Location = new System.Drawing.Point(330, 65);
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 30);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            
            this.cboLoaiBC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBC.Items.AddRange(new object[] { "Tổng hợp", "Theo phòng ban" });
            this.cboLoaiBC.Location = new System.Drawing.Point(470, 65);
            this.cboLoaiBC.Size = new System.Drawing.Size(150, 31);
           
            this.btnXemBaoCao.BackColor = System.Drawing.Color.LightBlue; // Nền trắng
            this.btnXemBaoCao.FlatAppearance.BorderColor = System.Drawing.Color.Black; // Viền đen
            this.btnXemBaoCao.FlatAppearance.BorderSize = 1;
            this.btnXemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.Black; // Chữ đen
            this.btnXemBaoCao.Location = new System.Drawing.Point(635, 64);
            this.btnXemBaoCao.Size = new System.Drawing.Size(120, 33);
            this.btnXemBaoCao.Text = " Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
             
            this.btnXuatExcel.BackColor = System.Drawing.Color.DarkGreen; // Nền trắng
            this.btnXuatExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black; // Viền đen
            this.btnXuatExcel.FlatAppearance.BorderSize = 1;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.ForeColor = System.Drawing.Color.Black; // Chữ đen
            this.btnXuatExcel.Location = new System.Drawing.Point(820, 64);
            this.btnXuatExcel.Size = new System.Drawing.Size(110, 33);
            this.btnXuatExcel.Text = " Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            
            SetupCard(pnlCardNhanVien, "TỔNG NHÂN VIÊN", "0 người", System.Drawing.Color.Black, 30, 110);
            SetupCard(pnlCardLuong, "TỔNG LƯƠNG THỰC TRẢ", "0 đ", System.Drawing.Color.Black, 260, 110);
            SetupCard(pnlCardThuong, "TỔNG TIỀN THƯỞNG", "0 đ", System.Drawing.Color.Black, 490, 110);
            SetupCard(pnlCardPhat, "TỔNG TIỀN PHẠT", "0 đ", System.Drawing.Color.Black, 720, 110);
            
            this.lblTopTitle.AutoSize = true;
            this.lblTopTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTopTitle.ForeColor = System.Drawing.Color.Black; // Chuyển sang chữ đen
            this.lblTopTitle.Location = new System.Drawing.Point(30, 230);
            this.lblTopTitle.Name = "lblTopTitle";
            this.lblTopTitle.Size = new System.Drawing.Size(430, 25);
            this.lblTopTitle.Text = " BẢNG XẾP HẠNG TOP 5 NHÂN VIÊN CÓ LƯƠNG CAO NHẤT";
          
            this.dgvTopLuong.AllowUserToAddRows = false;
            this.dgvTopLuong.AllowUserToDeleteRows = false;
            this.dgvTopLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopLuong.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopLuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black; // Chữ tiêu đề bảng màu đen
            this.dgvTopLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTopLuong.ColumnHeadersHeight = 35;
            this.dgvTopLuong.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(230, 230, 230); // Khi chọn dòng đổi sang xám nhạt tinh tế
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTopLuong.DefaultCellStyle = dataGridViewCellStyle2;

            this.dgvTopLuong.Location = new System.Drawing.Point(30, 265);
            this.dgvTopLuong.Name = "dgvTopLuong";
            this.dgvTopLuong.ReadOnly = true;
            this.dgvTopLuong.RowHeadersVisible = false;
            this.dgvTopLuong.RowTemplate.Height = 38;
            this.dgvTopLuong.Size = new System.Drawing.Size(900, 260);
            this.dgvTopLuong.TabIndex = 0;

            // FormBaoCao cấu hình tổng quan nền trắng
            this.BackColor = System.Drawing.Color.White; // Đổi nền Form sang màu trắng tinh
            this.ClientSize = new System.Drawing.Size(960, 560);
            this.Controls.Add(this.lblTopTitle);
            this.Controls.Add(this.dgvTopLuong);
            this.Controls.Add(this.pnlCardPhat);
            this.Controls.Add(this.pnlCardThuong);
            this.Controls.Add(this.pnlCardLuong);
            this.Controls.Add(this.pnlCardNhanVien);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.cboLoaiBC);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBaoCao";
            this.Text = "Báo Cáo";
            this.Load += new System.EventHandler(this.FormBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupCard(System.Windows.Forms.Panel pnl, string title, string value, System.Drawing.Color accentColor, int x, int y)
        {
            pnl.Size = new System.Drawing.Size(210, 95);
            pnl.Location = new System.Drawing.Point(x, y);
            pnl.BackColor = System.Drawing.Color.White; // Nền card trắng tinh
            pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; // Viền mỏng bao quanh gọn gàng
            pnl.Controls.Clear();

            // Đường chỉ mỏng bên trái chuyển sang màu đen đặc làm điểm nhấn flat tinh tế
            System.Windows.Forms.Panel pnlLine = new System.Windows.Forms.Panel();
            pnlLine.BackColor = System.Drawing.Color.Black;
            pnlLine.Dock = System.Windows.Forms.DockStyle.Left;
            pnlLine.Width = 5;
            pnl.Controls.Add(pnlLine);

            System.Windows.Forms.Label lblT = new System.Windows.Forms.Label
            {
                Text = title,
                Location = new System.Drawing.Point(15, 15),
                AutoSize = true,
                ForeColor = System.Drawing.Color.DimGray, // Tiêu đề phụ màu xám đậm dễ nhìn
                Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold)
            };

            System.Windows.Forms.Label lblV = new System.Windows.Forms.Label
            {
                Name = "lblVal_" + pnl.Name,
                Text = value,
                Location = new System.Drawing.Point(15, 45),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Black, // Giá trị hiển thị chữ đen đậm nét cực kỳ tương phản
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold)
            };

            pnl.Controls.Add(lblT);
            pnl.Controls.Add(lblV);
            this.Controls.Add(pnl);
        }

        private System.Windows.Forms.Label lblTitle, lblTuNgay, lblDenNgay, lblTopTitle;
        private System.Windows.Forms.DateTimePicker dtpTuNgay, dtpDenNgay;
        private System.Windows.Forms.ComboBox cboLoaiBC;
        private System.Windows.Forms.Button btnXemBaoCao, btnXuatExcel;
        private System.Windows.Forms.Panel pnlCardNhanVien, pnlCardLuong, pnlCardThuong, pnlCardPhat;
        private System.Windows.Forms.DataGridView dgvTopLuong;
    }
}