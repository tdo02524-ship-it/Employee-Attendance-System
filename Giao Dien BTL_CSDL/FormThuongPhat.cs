using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ChamCongRFID
{
    public partial class FormThuongPhat : Form
    {
        private string connectionString = @"Data Source=LAPTOP-QJKQ1GTV;Initial Catalog=CHAM_CONG_NHAN_VIEN;Integrated Security=True";

        public FormThuongPhat()
        {
            InitializeComponent();
        }

        private void FormThuongPhat_Load(object sender, EventArgs e)
        {
            if (cboLoai.Items.Count > 0) cboLoai.SelectedIndex = 0;

            // Đăng ký các sự kiện tương tác trực tiếp bằng code để giữ nguyên file Designer
            this.dgvThuongPhat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThuongPhat_CellClick);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            LoadData(); // Gọi hàm tải dữ liệu thật từ SQL Server
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Lệnh SQL kết hợp (JOIN) giữa bảng ThuongPhat và NhanVien để hiển thị Họ tên lên lưới
                    string query = @"SELECT tp.MaTP, 
                                            tp.Ngay AS [Ngày], 
                                            tp.Loai AS [Loại], 
                                            tp.MaNhanVien AS [Mã nhân viên], 
                                            nv.HoTen AS [Họ và tên], 
                                            tp.LyDo AS [Lý do], 
                                            tp.SoTien AS [Số tiền]
                                     FROM ThuongPhat tp
                                     INNER JOIN NhanVien nv ON tp.MaNhanVien = nv.MaNhanVien
                                     ORDER BY tp.Ngay DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvThuongPhat.DataSource = dt;
                    }
                }

                // Định dạng hiển thị dấu phẩy hàng nghìn cho cột tiền
                if (dgvThuongPhat.Columns["Số tiền"] != null)
                    dgvThuongPhat.Columns["Số tiền"].DefaultCellStyle.Format = "N0";

                // Ẩn cột mã tăng tự động MaTP khỏi giao diện nhưng giữ lại để phục vụ xóa dữ liệu
                if (dgvThuongPhat.Columns["MaTP"] != null)
                    dgvThuongPhat.Columns["MaTP"].Visible = false;

                // Cấu hình tỷ lệ độ rộng các cột phẳng theo chuẩn cũ của bạn
                if (dgvThuongPhat.Columns["Lý do"] != null) dgvThuongPhat.Columns["Lý do"].FillWeight = 200;
                if (dgvThuongPhat.Columns["Ngày"] != null) dgvThuongPhat.Columns["Ngày"].FillWeight = 80;
                if (dgvThuongPhat.Columns["Loại"] != null) dgvThuongPhat.Columns["Loại"].FillWeight = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu thưởng phạt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvThuongPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThuongPhat.Rows[e.RowIndex];

                dtpNgay.Value = Convert.ToDateTime(row.Cells["Ngày"].Value);
                cboLoai.Text = row.Cells["Loại"].Value.ToString();
                txtMaNV.Text = row.Cells["Mã nhân viên"].Value.ToString();
                txtHoTen.Text = row.Cells["Họ và tên"].Value.ToString();
                txtLyDo.Text = row.Cells["Lý do"].Value.ToString();

                // Lấy trị tuyệt đối của số tiền hiển thị lên ô nhập (loại bỏ dấu âm tự động)
                decimal sotien = Convert.ToDecimal(row.Cells["Số tiền"].Value);
                txtSoTien.Text = Math.Abs(sotien).ToString("F0");

                txtMaNV.Enabled = false; // Tạm khóa mã nhân viên lại khi đang chọn hàng
                txtHoTen.Enabled = false; // Họ tên tự sinh theo CSDL không được chỉnh sửa tay
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            txtMaNV.Clear();
            txtHoTen.Clear();
            txtSoTien.Clear();
            txtLyDo.Clear();
            dtpNgay.Value = DateTime.Now;
            if (cboLoai.Items.Count > 0) cboLoai.SelectedIndex = 0;

            txtMaNV.Focus();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã nhân viên và Số tiền!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal valueSotien = Convert.ToDecimal(txtSoTien.Text.Trim());
                // Nếu loại cấu hình chọn là "Phạt" thì tự động quy đổi thành số âm để khớp logic đổi màu của bạn
                if (cboLoai.Text == "Phạt" && valueSotien > 0)
                {
                    valueSotien = -valueSotien;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO ThuongPhat (Ngay, Loai, MaNhanVien, LyDo, SoTien) 
                                     VALUES (@Ngay, @Loai, @MaNV, @LyDo, @SoTien)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ngay", dtpNgay.Value.Date);
                        cmd.Parameters.AddWithValue("@Loai", cboLoai.Text);
                        cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text.Trim());
                        cmd.Parameters.AddWithValue("@LyDo", txtLyDo.Text.Trim());
                        cmd.Parameters.AddWithValue("@SoTien", valueSotien);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ghi nhận thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLamMoi_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThuongPhat.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng kích chọn dòng cần xóa trên bảng dữ liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idXoa = dgvThuongPhat.CurrentRow.Cells["MaTP"].Value.ToString();
            string nvId = dgvThuongPhat.CurrentRow.Cells["Mã nhân viên"].Value.ToString();

            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa bản ghi của nhân viên {nvId}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM ThuongPhat WHERE MaTP = @MaTP";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaTP", idXoa);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Xóa bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLamMoi_Click(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa bản ghi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaNV.Enabled && txtMaNV.Text.Trim().Length >= 4)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT HoTen FROM NhanVien WHERE MaNhanVien = @MaNV";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text.Trim());
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                txtHoTen.Text = result.ToString();
                            }
                        }
                    }
                }
                catch { }
            }
        }

        // Giữ nguyên sự kiện định dạng màu sắc lưới của bạn 100%
        private void dgvThuongPhat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (dgvThuongPhat.Columns[e.ColumnIndex].Name == "Loại")
                {
                    e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    if (e.Value.ToString() == "Thưởng")
                        e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96);
                    else if (e.Value.ToString() == "Phạt")
                        e.CellStyle.ForeColor = Color.FromArgb(231, 76, 60);
                }

                if (dgvThuongPhat.Columns[e.ColumnIndex].Name == "Số tiền")
                {
                    e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    decimal tien = Convert.ToDecimal(e.Value);
                    if (tien > 0)
                        e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96);
                    else
                        e.CellStyle.ForeColor = Color.FromArgb(231, 76, 60);
                }
            }
        }

        private void lblHoTen_Click(object sender, EventArgs e) { }
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMaNV_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {

        }
    }
}