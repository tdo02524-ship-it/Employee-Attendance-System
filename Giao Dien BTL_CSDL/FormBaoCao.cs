using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ChamCongRFID
{
    public partial class FormBaoCao : Form
    {
        private string connectionString = @"Data Source=LAPTOP-QJKQ1GTV;Initial Catalog=CHAM_CONG_NHAN_VIEN;Integrated Security=True";
        public FormBaoCao()
        {
            InitializeComponent();
        }

        private void FormBaoCao_Load(object sender, EventArgs e)
        {
           
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            if (cboLoaiBC.Items.Count > 0) cboLoaiBC.SelectedIndex = 0;

            ThucHienThongKe();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            ThucHienThongKe();
        }

        private void ThucHienThongKe()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc báo cáo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Thống kê tổng số lượng nhân viên hiện có (TrangThai = 1)
                    string qNhanVien = "SELECT COUNT(*) FROM NhanVien WHERE TrangThai = 1";
                    using (SqlCommand cmd = new SqlCommand(qNhanVien, conn))
                    {
                        int tongNV = (int)cmd.ExecuteScalar();
                        CapNhatGiaTriCard(pnlCardNhanVien, $"{tongNV} người");
                    }

                    // 2. Thống kê Tổng tiền thưởng trong giai đoạn
                    string qThuong = "SELECT ISNULL(SUM(SoTien), 0) FROM ThuongPhat WHERE Loai = N'Thưởng' AND Ngay BETWEEN @TuNgay AND @DenNgay";
                    decimal tongThuong = 0;
                    using (SqlCommand cmd = new SqlCommand(qThuong, conn))
                    {
                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                        tongThuong = Convert.ToDecimal(cmd.ExecuteScalar());
                        CapNhatGiaTriCard(pnlCardThuong, tongThuong.ToString("N0") + " đ");
                    }

                    // 3. Thống kê Tổng tiền phạt trong giai đoạn (Lấy trị tuyệt đối)
                    string qPhat = "SELECT ABS(ISNULL(SUM(SoTien), 0)) FROM ThuongPhat WHERE Loai = N'Phạt' AND Ngay BETWEEN @TuNgay AND @DenNgay";
                    decimal tongPhat = 0;
                    using (SqlCommand cmd = new SqlCommand(qPhat, conn))
                    {
                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                        tongPhat = Convert.ToDecimal(cmd.ExecuteScalar());
                        CapNhatGiaTriCard(pnlCardPhat, tongPhat.ToString("N0") + " đ");
                    }

                    // 4. Thống kê Tổng quỹ lương thực tế dựa trên số ngày công CheckIn thực tế
                    string qLuong = @"
                        SELECT 
                            nv.MaNhanVien,
                            nv.LuongCoBan,
                            ISNULL((SELECT COUNT(DISTINCT CAST(ThoiGian AS DATE)) 
                                    FROM ChamCong 
                                    WHERE MaNhanVien = nv.MaNhanVien 
                                      AND Loai = 'CheckIn'
                                      AND CAST(ThoiGian AS DATE) BETWEEN @TuNgay AND @DenNgay), 0) AS SoNgayCong
                        FROM NhanVien nv WHERE nv.TrangThai = 1";

                    decimal tongQuyLuong = 0;
                    using (SqlCommand cmd = new SqlCommand(qLuong, conn))
                    {
                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                decimal luongCB = Convert.ToDecimal(reader["LuongCoBan"]);
                                int cong = Convert.ToInt32(reader["SoNgayCong"]);
                                tongQuyLuong += (luongCB / 26) * cong;
                            }
                        }
                    }

                    // Tính lương thực trả bằng tổng lương gốc + thưởng - phạt
                    decimal tongLuongNet = tongQuyLuong + tongThuong - tongPhat;
                    if (tongLuongNet < 0) tongLuongNet = 0;
                    CapNhatGiaTriCard(pnlCardLuong, tongLuongNet.ToString("N0") + " đ");
                }

                // 5. Tải dữ liệu lên bảng Top 5 Nhân viên lương cao nhất
                LoadTopLuongDatabase(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính toán dữ liệu báo cáo: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTopLuongDatabase(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dtReal = new DataTable();
            dtReal.Columns.Add("#");
            dtReal.Columns.Add("Mã nhân viên");
            dtReal.Columns.Add("Họ và tên");
            dtReal.Columns.Add("Số ngày công", typeof(int));
            dtReal.Columns.Add("Tổng lương", typeof(decimal));

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            nv.MaNhanVien,
                            nv.HoTen,
                            nv.LuongCoBan,
                            ISNULL((SELECT COUNT(DISTINCT CAST(ThoiGian AS DATE)) 
                                    FROM ChamCong 
                                    WHERE MaNhanVien = nv.MaNhanVien 
                                      AND Loai = 'CheckIn'
                                      AND CAST(ThoiGian AS DATE) BETWEEN @TuNgay AND @DenNgay), 0) AS SoNgayCong,
                            ISNULL((SELECT SUM(SoTien) FROM ThuongPhat WHERE MaNhanVien = nv.MaNhanVien AND Loai = N'Thưởng' AND Ngay BETWEEN @TuNgay AND @DenNgay), 0) AS Thuong,
                            ABS(ISNULL((SELECT SUM(SoTien) FROM ThuongPhat WHERE MaNhanVien = nv.MaNhanVien AND Loai = N'Phạt' AND Ngay BETWEEN @TuNgay AND @DenNgay), 0)) AS Phat
                        FROM NhanVien nv WHERE nv.TrangThai = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                        cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtTemp = new DataTable();
                        da.Fill(dtTemp);

                        dtTemp.Columns.Add("CalculatedSalary", typeof(decimal));
                        foreach (DataRow row in dtTemp.Rows)
                        {
                            decimal luongCB = Convert.ToDecimal(row["LuongCoBan"]);
                            int cong = Convert.ToInt32(row["SoNgayCong"]);
                            decimal thuong = Convert.ToDecimal(row["Thuong"]);
                            decimal phat = Convert.ToDecimal(row["Phat"]);

                            decimal tong = ((luongCB / 26) * cong) + thuong - phat;
                            row["CalculatedSalary"] = tong > 0 ? Math.Round(tong, 0) : 0;
                        }

                        DataView dv = dtTemp.DefaultView;
                        dv.Sort = "CalculatedSalary DESC";
                        DataTable sortedTable = dv.ToTable();

                        int stt = 1;
                        int limit = sortedTable.Rows.Count > 5 ? 5 : sortedTable.Rows.Count;
                        for (int i = 0; i < limit; i++)
                        {
                            DataRow r = sortedTable.Rows[i];
                            dtReal.Rows.Add(stt++, r["MaNhanVien"], r["HoTen"], r["SoNgayCong"], r["CalculatedSalary"]);
                        }
                    }
                }

                dgvTopLuong.DataSource = dtReal;
                dgvTopLuong.Columns["Tổng lương"].DefaultCellStyle.Format = "N0";
                if (dgvTopLuong.Columns["#"] != null) dgvTopLuong.Columns["#"].FillWeight = 40;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nạp bảng xếp hạng lương: " + ex.Message);
            }
        }

        private void CapNhatGiaTriCard(Panel pnl, string valueText)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is Label && ctrl.Name == "lblVal_" + pnl.Name)
                {
                    ctrl.Text = valueText;
                    break;
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng xuất báo cáo định dạng Excel đang được phát triển...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}