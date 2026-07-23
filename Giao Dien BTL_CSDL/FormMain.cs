using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ChamCongRFID
{
    public partial class FormMain : Form
    {
        private string connectionString = @"Data Source=LAPTOP-QJKQ1GTV;Initial Catalog=CHAM_CONG_NHAN_VIEN;Integrated Security=True";

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            if (cboPhongBan.Items.Count > 0) cboPhongBan.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            timerClock.Interval = 1000;
            timerClock.Start();
            txtMaNV.Text = LayMaNhanVienTuDong();
        }

        private string LayMaNhanVienTuDong()
        {
            int soTiepTheo = 1;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MAX(CAST(SUBSTRING(MaNhanVien, 3, LEN(MaNhanVien) - 2) AS INT)) FROM NhanVien WHERE MaNhanVien LIKE 'NV%'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            soTiepTheo = Convert.ToInt32(result) + 1;
                        }
                    }
                }

                while (KiemTraTrungMaNV("NV" + soTiepTheo.ToString("D4")))
                {
                    soTiepTheo++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tự động sinh mã nhân viên: " + ex.Message);
            }

            return "NV" + soTiepTheo.ToString("D4");
        }

        private void LoadData(string timKiem = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT nv.MaNhanVien AS MaNV, nv.HoTen, nv.GioiTinh, nv.NgaySinh, 
                                            nv.SoDienThoai AS SDT, nv.Email, nv.DiaChi, nv.LuongCoBan AS LuongCB, 
                                            nv.MaPhongBan AS PhongBan, cl.TenCa AS CaLam, nv.MaTheRFID AS MaTheRFID,
                                            CASE WHEN nv.TrangThai = 1 THEN N'Đang làm' ELSE N'Nghỉ việc' END AS TrangThai 
                                     FROM NhanVien nv
                                     LEFT JOIN CaLam cl ON nv.MaCa = cl.MaCa";

                    if (!string.IsNullOrEmpty(timKiem))
                    {
                        query += " WHERE nv.MaNhanVien LIKE @Search OR nv.HoTen LIKE @Search OR nv.MaTheRFID LIKE @Search";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(timKiem))
                        {
                            cmd.Parameters.AddWithValue("@Search", "%" + timKiem + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvNhanVien.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã nhân viên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên nhân viên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ Email!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ nơi ở!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLuongCB.Text))
            {
                MessageBox.Show("Vui lòng nhập Lương cơ bản hợp đồng!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLuongCB.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMaTheRFID.Text))
            {
                MessageBox.Show("Vui lòng nhập/quẹt Mã thẻ RFID UID!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaTheRFID.Focus();
                return false;
            }
            return true;
        }

        private bool KiemTraTrungMaNV(string maNV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool KiemTraTrungMaRFID(string maRFID, string maNVHienTai)
        {

            if (string.IsNullOrWhiteSpace(maRFID)) return false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaTheRFID = @MaRFID AND MaNhanVien != @MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaRFID", maRFID);
                    cmd.Parameters.AddWithValue("@MaNV", maNVHienTai);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString() ?? "";
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString() ?? "Nam";

                if (row.Cells["NgaySinh"].Value != DBNull.Value && row.Cells["NgaySinh"].Value != null)
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

                txtSDT.Text = row.Cells["SDT"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
                txtLuongCB.Text = row.Cells["LuongCB"].Value?.ToString() ?? "";
                txtMaTheRFID.Text = row.Cells["MaTheRFID"].Value?.ToString() ?? "";

                cboPhongBan.Text = row.Cells["PhongBan"].Value?.ToString() ?? "";
                cboTrangThai.Text = row.Cells["TrangThai"].Value?.ToString() ?? "Đang làm";

                txtMaNV.Enabled = false;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtLuongCB.Clear();
            txtMaTheRFID.Clear();
            txtTimKiem.Clear();
            dtpNgaySinh.Value = DateTime.Now;

            if (cboGioiTinh.Items.Count > 0) cboGioiTinh.SelectedIndex = 0;
            if (cboPhongBan.Items.Count > 0) cboPhongBan.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;

            txtMaNV.Text = LayMaNhanVienTuDong();
            txtHoTen.Focus();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            string maMoi = txtMaNV.Text.Trim();
            string rfidMoi = txtMaTheRFID.Text.Trim();
            try
            {
                if (KiemTraTrungMaNV(maMoi))
                {
                    MessageBox.Show($"Mã nhân viên [{maMoi}] đã tồn tại trong hệ thống!", "Trùng mã nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNV.Focus();
                    return;
                }
                if (!string.IsNullOrEmpty(rfidMoi) && KiemTraTrungMaRFID(rfidMoi, maMoi))
                {
                    MessageBox.Show($"Mã thẻ RFID UID [{rfidMoi}] đã được cấp cho một nhân viên khác!", "Trùng mã thẻ RFID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra trùng dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO NhanVien (MaNhanVien, HoTen, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, LuongCoBan, MaPhongBan, MaCa, TrangThai, MaTheRFID) 
                                     VALUES (@MaNV, @HoTen, @GioiTinh, @NgaySinh, @SDT, @Email, @DiaChi, @LuongCB, @PhongBan, @CaLam, @TrangThaiBIT, @MaTheRFID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        AddParameters(cmd);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm nhân viên mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLamMoi_Click(sender, e);
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show($"Mã nhân viên hoặc Mã thẻ RFID (UID) đã tồn tại dữ liệu trùng trong hệ thống!", "Lỗi Trùng Khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string maNV = txtMaNV.Text.Trim();
            string rfidCapNhat = txtMaTheRFID.Text.Trim();

            if (!string.IsNullOrEmpty(rfidCapNhat) && KiemTraTrungMaRFID(rfidCapNhat, maNV))
            {
                MessageBox.Show($"Mã thẻ RFID UID [{rfidCapNhat}] đã tồn tại ở hồ sơ nhân viên khác!", "Lỗi liên kết RFID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE NhanVien SET HoTen=@HoTen, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, 
                                     SoDienThoai=@SDT, Email=@Email, DiaChi=@DiaChi, LuongCoBan=@LuongCB, 
                                     MaPhongBan=@PhongBan, MaCa=@CaLam, TrangThai=@TrangThaiBIT, MaTheRFID=@MaTheRFID  
                                     WHERE MaNhanVien=@MaNV";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        AddParameters(cmd);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thông tin nhân viên và Thẻ RFID thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNVXoa = "";

            if (dgvNhanVien.CurrentRow != null && dgvNhanVien.CurrentRow.Cells[0].Value != null)
            {
                maNVXoa = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            }
            else
            {
                maNVXoa = txtMaNV.Text.Trim();
            }

            if (string.IsNullOrWhiteSpace(maNVXoa))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {maNVXoa}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM NhanVien WHERE MaNhanVien=@MaNV";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", maNVXoa);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLamMoi_Click(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuyTheRFID_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV) || txtMaNV.Enabled == true)
            {
                MessageBox.Show("Vui lòng kích chọn một nhân viên cụ thể từ danh sách để thực hiện hủy thẻ RFID!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có thực sự muốn xóa/hủy liên kết thẻ RFID của nhân viên [{maNV}] không?", "Xác nhận hủy thẻ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE NhanVien SET MaTheRFID = NULL WHERE MaNhanVien = @MaNV";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaNV", maNV);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Đã hủy và xóa thông tin liên kết thẻ RFID thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtMaTheRFID.Clear();
                            LoadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy liên kết thẻ RFID: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text.Trim());
        }

        private void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text.Trim());
            cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
            cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
            cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);

            cmd.Parameters.AddWithValue("@CaLam", "HC");

            string maPhongBanThucTe = "PB01";
            if (cboPhongBan.Text.Contains("02") || cboPhongBan.Text.Contains("Kế toán")) maPhongBanThucTe = "PB02";
            else if (cboPhongBan.Text.Contains("03") || cboPhongBan.Text.Contains("Nhân sự")) maPhongBanThucTe = "PB03";
            cmd.Parameters.AddWithValue("@PhongBan", maPhongBanThucTe);

            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());

            if (!string.IsNullOrWhiteSpace(txtMaTheRFID.Text))
                cmd.Parameters.AddWithValue("@MaTheRFID", txtMaTheRFID.Text.Trim());
            else
                cmd.Parameters.AddWithValue("@MaTheRFID", DBNull.Value);

            decimal luongCB = 0;
            string cleanSalary = txtLuongCB.Text.Replace(",", "").Replace(".", "").Trim();
            decimal.TryParse(cleanSalary, out luongCB);
            cmd.Parameters.AddWithValue("@LuongCB", luongCB);

            int trangThaiBIT = (cboTrangThai.Text == "Đang làm") ? 1 : 0;
            cmd.Parameters.AddWithValue("@TrangThaiBIT", trangThaiBIT);
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblRealTime.Text = "Thời gian hệ thống: " + DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void lblRealTime_Click(object sender, EventArgs e) { }
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e) { }
        private void txtMaNV_TextChanged(object sender, EventArgs e) { }
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }
        private void lblGioiTinh_Click(object sender, EventArgs e) { }
        private void lblDiaChi_Click(object sender, EventArgs e) { }
        private void lblSDT_Click(object sender, EventArgs e) { }
        private void lblPhongBan_Click(object sender, EventArgs e) { }
        private void cboCaLam_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboPhongBan_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtSDT_TextChanged(object sender, EventArgs e) { }
        private void txtMaTheRFID_TextChanged(object sender, EventArgs e) { }
        private void lblLuong_Click(object sender, EventArgs e) { }
        private void txtTimKiem_TextChanged(object sender, EventArgs e) { }
    }
}