using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChamCongRFID
{
    public partial class FormDashboard : Form
    {

        private Form activeForm = null;
        public FormDashboard()
        {
            InitializeComponent(); 
        }

        private void OpenChildForm(Form childForm, Button senderBtn)
        {
            // === BƯỚC 1: XỬ LÝ FORM CŨ ĐANG MỞ ===
            if (activeForm != null)
            {
                activeForm.Close();
            }
            // === BƯỚC 2: ĐỔI MÀU NÚT ĐỂ ĐÁNH DẤU TRẠNG THÁI ===
            ResetMenuButtons(); 
            // Đổi màu nền của nút vừa được click thành màu xám nhạt để người dùng biết họ đang ở tab nào
            senderBtn.BackColor = Color.FromArgb(200, 230, 200);

            // === BƯỚC 3: CẤU HÌNH BIẾN VÀ THUỘC TÍNH CHO FORM CON MỚI ===
            activeForm = childForm; 
            childForm.TopLevel = false; 
            childForm.FormBorderStyle = FormBorderStyle.None; 
            childForm.Dock = DockStyle.Fill; 

            // === BƯỚC 4: NHÚNG FORM CON VÀO PANEL TRÊN GIAO DIỆN CHÍNH ===
            panelDesktop.Controls.Clear();          
            panelDesktop.Controls.Add(childForm);  
            panelDesktop.Tag = childForm;           
            childForm.BringToFront();               
            childForm.Show();                      

            // === BƯỚC 5: CẬP NHẬT TIÊU ĐỀ LÊN THANH HEADER ===
            // Đoạn này dùng để cắt bỏ các ký tự icon/số thứ tự ở đầu chữ của Button (nếu có) để lấy tên chức năng thuần túy
            if (senderBtn.Text.Length > 3)
                // Cắt chuỗi từ ký tự thứ 3 trở đi, xóa khoảng trắng thừa ở hai đầu và chuyển thành chữ IN HOA
                lblHeader.Text = senderBtn.Text.Substring(3).Trim().ToUpper();
            else
                // Nếu chuỗi quá ngắn thì lấy toàn bộ chữ trên Button và chuyển thành chữ IN HOA
                lblHeader.Text = senderBtn.Text.ToUpper();
        }

        private void ResetMenuButtons()
        {
            btnNhanVien.BackColor = Color.FromArgb(255, 255, 255);
            btnChamCong.BackColor = Color.FromArgb(255, 255, 255);
            btnLuong.BackColor = Color.FromArgb(255, 255, 255);
            btnThuongPhat.BackColor = Color.FromArgb(255, 255, 255);
            btnBaoCao.BackColor = Color.FromArgb(255, 255, 255);
        }


        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMain(), btnNhanVien);
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form1(), btnChamCong);
        }
        private void btnLuong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormLuong(), btnLuong);
        }
        private void btnThuongPhat_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormThuongPhat(), btnThuongPhat);
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormBaoCao(), btnBaoCao);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}