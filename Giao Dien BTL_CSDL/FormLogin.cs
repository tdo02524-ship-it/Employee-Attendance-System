using System;
using System.Windows.Forms;

namespace ChamCongRFID
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();
            if (user == "68686868" && pass == "68686868")
            {
                FormDashboard dashboard = new FormDashboard();
                this.Hide(); // Ẩn form đăng nhập đi
                dashboard.ShowDialog(); // Mở Dashboard dưới dạng cửa sổ chính
                this.Close(); // Khi tắt Dashboard thì tắt luôn ứng dụng
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}