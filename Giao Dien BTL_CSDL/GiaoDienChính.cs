using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ChamCongRFID
{
    public partial class Form1 : Form
    {
        // Khai báo các biến lưu trữ toàn cục của Form1
        private string lastNV = "";
        private DateTime lastTime = DateTime.MinValue;

        public Form1()
        {
            InitializeComponent();
        }

        // Khởi tạo cấu trúc dữ liệu JSON nhận về từ API
        public class RFIDData
        {
            public bool success { get; set; }
            public string name { get; set; }
            public string maNV { get; set; }
            public string status { get; set; }
            public DateTime time { get; set; }
        }

        // Hàm xử lý nạp dữ liệu quẹt thẻ RFID từ API Server
        private async Task LoadRFID()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://192.168.1.5:3000/api/latest";
                    string json = await client.GetStringAsync(url);

                    var data = JsonConvert.DeserializeObject<RFIDData>(json, new JsonSerializerSettings
                    {
                        DateTimeZoneHandling = DateTimeZoneHandling.Local
                    });

                    if (data != null && data.success)
                    {
                        DateTime localTime = data.time.ToLocalTime();
                        string currentTimeStr = localTime.ToString("HH:mm:ss");

                        // Kiểm tra trùng lặp lượt quẹt trong vòng 5 giây
                        if (data.maNV == lastNV && (localTime - lastTime.ToLocalTime()).TotalSeconds < 5) return;

                        lastNV = data.maNV;
                        lastTime = localTime;

                        bool isUpdated = false;

                        // Tìm kiếm nhân viên trong DataGridView để cập nhật Giờ Ra
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.Cells["colMaNV"].Value != null && row.Cells["colMaNV"].Value.ToString() == data.maNV)
                            {
                                if (row.Cells["colGioRa"].Value.ToString() == "-")
                                {
                                    row.Cells["colGioRa"].Value = currentTimeStr;

                                    TimeSpan gioRaThucTe = localTime.TimeOfDay;
                                    TimeSpan mocKetThucCa = new TimeSpan(17, 30, 0);

                                    // Đánh giá trạng thái Về Sớm hay Đủ Công
                                    if (gioRaThucTe < mocKetThucCa)
                                    {
                                        row.Cells["colTrangThai"].Value = "Về sớm";
                                        row.Cells["colTrangThai"].Style.ForeColor = Color.FromArgb(230, 126, 34);
                                    }
                                    else
                                    {
                                        row.Cells["colTrangThai"].Value = "Đủ công";
                                        row.Cells["colTrangThai"].Style.ForeColor = Color.FromArgb(39, 174, 96);
                                    }

                                    // Tính toán tổng thời gian làm việc thực tế
                                    DateTime timeIn = DateTime.Parse(row.Cells["colGioVao"].Value.ToString());
                                    DateTime timeOutFull = new DateTime(timeIn.Year, timeIn.Month, timeIn.Day, localTime.Hour, localTime.Minute, localTime.Second);
                                    TimeSpan diff = timeOutFull - timeIn;

                                    row.Cells["colTongGio"].Value = $"{(int)diff.TotalHours}h {diff.Minutes}m {diff.Seconds}s";
                                }
                                isUpdated = true;
                                break;
                            }
                        }

                        // Nếu chưa có thông tin (Lượt quẹt đầu tiên trong ngày -> Ghi nhận Giờ Vào)
                        if (!isUpdated)
                        {
                            TimeSpan gioVaoThucTe = localTime.TimeOfDay;
                            TimeSpan mocBatDauCa = new TimeSpan(7, 30, 0);

                            string tinhTrangVao = "Đúng giờ";
                            Color mauTinhTrang = Color.FromArgb(39, 174, 96);

                            // Đánh giá trạng thái Đi Muộn hay Đúng Giờ
                            if (gioVaoThucTe > mocBatDauCa)
                            {
                                tinhTrangVao = "Đi muộn";
                                mauTinhTrang = Color.FromArgb(231, 76, 60);
                            }

                            int newRowIdx = dgv.Rows.Add();
                            DataGridViewRow newRow = dgv.Rows[newRowIdx];

                            newRow.Cells["colMaNV"].Value = data.maNV;
                            newRow.Cells["colHoTen"].Value = data.name;
                            newRow.Cells["colCaLam"].Value = "Ca Hành Chính";
                            newRow.Cells["colGioVao"].Value = currentTimeStr;
                            newRow.Cells["colGioRa"].Value = "-";
                            newRow.Cells["colTongGio"].Value = "-";
                            newRow.Cells["colTrangThai"].Value = tinhTrangVao;

                            newRow.Cells["colTrangThai"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                            newRow.Cells["colTrangThai"].Style.ForeColor = mauTinhTrang;
                        }

                        // Tự động cuộn lưới hiển thị xuống dòng mới nhất
                        if (dgv.RowCount > 0)
                        {
                            dgv.FirstDisplayedScrollingRowIndex = dgv.RowCount - 1;
                        }

                        lblStatus.Text = $" Vừa quét: {data.name} lúc {currentTimeStr} -> Trạng thái: {lastNV}";
                        lblStatus.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = " Mất kết nối API Server";
                lblStatus.ForeColor = Color.Red;
                Console.WriteLine("Lỗi LoadRFID: " + ex.Message);
            }
        }

        // Sự kiện bộ đếm thời gian lặp lại sau mỗi chu kỳ
        private async void timer1_Tick(object sender, EventArgs e)
        {
            await LoadRFID();
        }

        // Sự kiện kích hoạt khi Form bắt đầu được tải lên hệ thống
        private async void Form1_Load(object sender, EventArgs e)
        {
            dtpNgay.Value = DateTime.Now;

            try
            {
                // Đọc nháp bản ghi cuối cùng đang kẹt trên server để đưa vào bộ nhớ đệm chống lặp
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://192.168.1.5:3000/api/latest";
                    string json = await client.GetStringAsync(url);
                    var data = JsonConvert.DeserializeObject<RFIDData>(json);

                    if (data != null && data.success)
                    {
                        // Gán vào biến chặn để khi bật app lên, lượt quẹt cũ này không bị nạp vào bảng nữa
                        lastNV = data.maNV;
                        lastTime = data.time.ToLocalTime();
                    }
                }
            }
            catch { }

            // Sau khi đã chặn dữ liệu cũ, mới bắt đầu chạy bộ đếm quét thẻ thực tế
            timer1.Interval = 3000;
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void lblStatus_Click(object sender, EventArgs e) { }

        private void dtpNgay_ValueChanged(object sender, EventArgs e) { }

        // Tính năng Xuất dữ liệu ra báo cáo Excel
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Tính năng xuất Excel đang được phát triển...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}