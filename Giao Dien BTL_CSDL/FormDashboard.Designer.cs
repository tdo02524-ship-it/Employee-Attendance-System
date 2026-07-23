namespace ChamCongRFID
{
    partial class FormDashboard
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnThuongPhat = new System.Windows.Forms.Button();
            this.btnLuong = new System.Windows.Forms.Button();
            this.btnChamCong = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.panelTopbar = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelTopbar.SuspendLayout();
            this.SuspendLayout();

            // panelSidebar: Nền trắng tinh
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.panelSidebar.Controls.Add(this.btnThoat);
            this.panelSidebar.Controls.Add(this.btnBaoCao);
            this.panelSidebar.Controls.Add(this.btnThuongPhat);
            this.panelSidebar.Controls.Add(this.btnLuong);
            this.panelSidebar.Controls.Add(this.btnChamCong);
            this.panelSidebar.Controls.Add(this.btnNhanVien);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 720);

            // Thiết lập chung các nút Menu (Tông Trắng - Đen mượt mà)
            System.Windows.Forms.Button[] navButtons = { btnNhanVien, btnChamCong, btnLuong, btnThuongPhat, btnBaoCao };
            int startY = 50;
            foreach (var btn in navButtons)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(255, 255, 255); // Nền nút màu trắng trùng sidebar
                btn.ForeColor = System.Drawing.Color.Black; // Chữ Đen
                btn.FlatAppearance.BorderSize = 0;
                // Hiệu ứng di chuột đổi sang màu xám nhạt để giao diện tinh tế hơn
                btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 255, 0);
                btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 255, 0);
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.Size = new System.Drawing.Size(220, 55);
                btn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Location = new System.Drawing.Point(0, startY);
                btn.Font = new System.Drawing.Font("Segoe UI", 11F);
                startY += 55;
            }

            this.btnNhanVien.Text = "Nhân Viên";
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);

            this.btnChamCong.Text = "Chấm Công RFID";
            this.btnChamCong.Click += new System.EventHandler(this.btnChamCong_Click);

            this.btnLuong.Text = "Quản Lý Lương";
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);

            this.btnThuongPhat.Text = "Thưởng / Phạt";
            this.btnThuongPhat.Click += new System.EventHandler(this.btnThuongPhat_Click);

            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);

            // btnThoat (Đăng Xuất): Đồng bộ nền trắng chữ đen, đẩy xuống góc dưới cùng
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 255, 0);
            this.btnThoat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 255, 0);
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Location = new System.Drawing.Point(0, 670);
            this.btnThoat.Size = new System.Drawing.Size(220, 50);
            this.btnThoat.Text = "Đăng Xuất";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // panelTopbar: Thanh tiêu đề trên cùng nền trắng tinh
            this.panelTopbar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTopbar.Controls.Add(this.lblHeader);
            this.panelTopbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopbar.Location = new System.Drawing.Point(220, 0);
            this.panelTopbar.Size = new System.Drawing.Size(1060, 65);

            // lblHeader: Chữ tiêu đề Đen rõ nét
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(25, 18);
            this.lblHeader.Text = "HỆ THỐNG QUẢN LÍ VÀ CHẤM CÔNG NHÂN VIÊN";

            // panelDesktop: Vùng hiển thị form con (Màu xám siêu nhẹ để phân biệt với sidebar trắng)
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 65);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1060, 655);

            // Cấu hình Form chính
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTopbar);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao dien btl csdl";

            this.panelSidebar.ResumeLayout(false);
            this.panelTopbar.ResumeLayout(false);
            this.panelTopbar.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnThuongPhat;
        private System.Windows.Forms.Button btnLuong;
        private System.Windows.Forms.Button btnChamCong;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Panel panelTopbar;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panelDesktop;
    }
}