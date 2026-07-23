using System;
using System.Data;
using System.Data.SqlClient; 
using System.Drawing;      
using System.Windows.Forms;

namespace ChamCongRFID
{
    
    public partial class FormLuong : Form
    {
        private string connectionString = @"Data Source=LAPTOP-QJKQ1GTV;Initial Catalog=CHAM_CONG_NHAN_VIEN;Integrated Security=True";

        public FormLuong()
        {
            InitializeComponent(); // Khởi tạo các thành phần giao diện kéo thả trên Form
        }
        // Sự kiện xảy ra khi Form bắt đầu được tải lên (Load) màn hình
        private void FormLuong_Load(object sender, EventArgs e)
        {
            cboThang.Items.Clear(); // Xóa các mục cũ nếu có trong ComboBox Tháng
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i.ToString()); 
            }
            cboThang.SelectedItem = DateTime.Now.Month.ToString();
            // === BƯỚC 2: NẠP DỮ LIỆU CHO COMBOBOX NĂM ===
            cboNam.Items.Clear(); 
            int currentYear = DateTime.Now.Year; 
            for (int i = 2020; i <= currentYear + 1; i++)
            {
                cboNam.Items.Add(i.ToString()); 
            }
            cboNam.SelectedItem = currentYear.ToString();
        }

        // Sự kiện xảy ra khi người dùng click vào nút "Tính Lương"
        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboThang.Text) || string.IsNullOrEmpty(cboNam.Text))
            {
                MessageBox.Show("Vui lòng chọn tháng và năm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            int thang = Convert.ToInt32(cboThang.Text);
            int nam = Convert.ToInt32(cboNam.Text);
            // DataTable này hoạt động như một bảng ảo trong bộ nhớ RAM để chứa kết quả tính toán trước khi đẩy lên lưới hiển thị
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã nhân viên");                
            dt.Columns.Add("Họ và tên");                   
            dt.Columns.Add("Lương cơ bản", typeof(decimal)); 
            dt.Columns.Add("Số ngày công", typeof(int));     
            dt.Columns.Add("Lương ngày", typeof(decimal));   
            dt.Columns.Add("Thưởng", typeof(decimal));      
            dt.Columns.Add("Phạt", typeof(decimal));        
            dt.Columns.Add("Tổng lương", typeof(decimal));   

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Mở cổng kết nối tới SQL Server
                    string query = @"
                        SELECT 
                            nv.MaNhanVien,
                            nv.HoTen,
                            nv.LuongCoBan,
                            
                            -- [LOGIC 1] ĐẾM NGÀY CÔNG CHUẨN:
                            -- Đếm số ngày phân biệt (DISTINCT) mà nhân viên đó có dòng trạng thái 'CheckIn'
                            -- VÀ đồng thời (EXISTS) trong ngày đó phải có ít nhất 1 dòng trạng thái 'CheckOut' đi kèm.
                            ISNULL((SELECT COUNT(DISTINCT CAST(ccIn.ThoiGian AS DATE)) 
                                    FROM ChamCong ccIn
                                    WHERE ccIn.MaNhanVien = nv.MaNhanVien 
                                      AND ccIn.Loai = 'CheckIn'
                                      AND MONTH(ccIn.ThoiGian) = @Thang 
                                      AND YEAR(ccIn.ThoiGian) = @Nam
                                      AND EXISTS (
                                          SELECT 1 FROM ChamCong ccOut 
                                          WHERE ccOut.MaNhanVien = nv.MaNhanVien 
                                            AND ccOut.Loai = 'CheckOut'
                                            -- So sánh phần ngày tháng năm của CheckOut phải trùng với CheckIn
                                            AND CAST(ccOut.ThoiGian AS DATE) = CAST(ccIn.ThoiGian AS DATE)
                                      )), 0) AS SoNgayCong,

                            -- [LOGIC 2] TÍNH TỔNG TIỀN THƯỞNG TRONG THÁNG:
                            -- Lấy tổng cột SoTien trong bảng ThuongPhat với điều kiện Loại là 'Thưởng'
                            ISNULL((SELECT SUM(SoTien) 
                                    FROM ThuongPhat 
                                    WHERE MaNhanVien = nv.MaNhanVien 
                                      AND Loai = N'Thưởng'
                                      AND MONTH(Ngay) = @Thang 
                                      AND YEAR(Ngay) = @Nam), 0) AS Thuong,

                            -- [LOGIC 3] TÍNH TỔNG TIỀN PHẠT TRONG THÁNG:
                            -- Lấy tổng tiền Phạt, bọc hàm ABS() để lấy trị tuyệt đối (luôn trả về số dương để hiển thị lên lưới trực quan hơn)
                            ABS(ISNULL((SELECT SUM(SoTien) 
                                        FROM ThuongPhat 
                                        WHERE MaNhanVien = nv.MaNhanVien 
                                          AND Loai = N'Phạt'
                                          AND MONTH(Ngay) = @Thang 
                                          AND YEAR(Ngay) = @Nam), 0)) AS Phat
                        FROM NhanVien nv
                        WHERE nv.TrangThai = 1"; // Chỉ lấy những nhân viên đang làm việc (TrangThai = 1)

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Truyền giá trị an toàn từ lập trình vào các biến tham số @Thang, @Nam trong SQL để tránh lỗi SQL Injection
                        cmd.Parameters.AddWithValue("@Thang", thang);
                        cmd.Parameters.AddWithValue("@Nam", nam);

                        // Thực thi câu lệnh và trả về trình đọc dữ liệu SqlDataReader theo từng dòng
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                
                                string maNV = reader["MaNhanVien"].ToString();
                                string hoTen = reader["HoTen"].ToString();
                                decimal luongCB = Convert.ToDecimal(reader["LuongCoBan"]);
                                int soNgayCong = Convert.ToInt32(reader["SoNgayCong"]);
                                decimal thuong = Convert.ToDecimal(reader["Thuong"]);
                                decimal phat = Convert.ToDecimal(reader["Phat"]);

                                decimal luongNgay = luongCB / 26;
                                decimal tongLuong = (luongNgay * soNgayCong) + thuong - phat;

                                
                                if (tongLuong < 0) tongLuong = 0;

                                
                                dt.Rows.Add(maNV, hoTen, luongCB, soNgayCong, Math.Round(luongNgay, 0), thuong, phat, Math.Round(tongLuong, 0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Lỗi khi truy vấn và tính toán dữ liệu lương: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            // === BƯỚC 5: TÍNH DÒNG TỔNG CỘNG CHO TOÀN BỘ CÔNG TY ===
            
            decimal sumLuongCB = 0, sumThuong = 0, sumPhat = 0, sumTong = 0;

            foreach (DataRow row in dt.Rows)
            {
                sumLuongCB += Convert.ToDecimal(row["Lương cơ bản"]);
                sumThuong += Convert.ToDecimal(row["Thưởng"]);
                sumPhat += Convert.ToDecimal(row["Phạt"]);
                sumTong += Convert.ToDecimal(row["Tổng lương"]);
            }

            dt.Rows.Add("Tổng cộng", "", sumLuongCB, DBNull.Value, DBNull.Value, sumThuong, sumPhat, sumTong);

            // === BƯỚC 6: ĐẨY DỮ LIỆU LÊN GIAO DIỆN & ĐỊNH DẠNG HÀNG/CỘT ===
            dgvLuong.DataSource = dt;
            // Định dạng hiển thị tiền tệ: Định dạng định danh "N0" giúp phân tách hàng nghìn bằng dấu phẩy hoặc chấm (Ví dụ: 10,000,000)
            dgvLuong.Columns["Lương cơ bản"].DefaultCellStyle.Format = "N0";
            dgvLuong.Columns["Lương ngày"].DefaultCellStyle.Format = "N0";
            dgvLuong.Columns["Thưởng"].DefaultCellStyle.Format = "N0";
            dgvLuong.Columns["Phạt"].DefaultCellStyle.Format = "N0";
            dgvLuong.Columns["Tổng lương"].DefaultCellStyle.Format = "N0";

            int lastRowIndex = dgvLuong.Rows.Count - 1;
            if (lastRowIndex >= 0)
            {
                
                dgvLuong.Rows[lastRowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                
                dgvLuong.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
        }

        // Sự kiện xảy ra khi người dùng click vào nút "Xuất Excel"
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
           
            if (dgvLuong.Rows.Count == 0)
            {
                
                MessageBox.Show("Không có dữ liệu hiển thị để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Tính năng xuất Excel đang được phát triển...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}