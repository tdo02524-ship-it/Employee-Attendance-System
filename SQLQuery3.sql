USE master;
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CHAM_CONG_NHAN_VIEN')
BEGIN
    CREATE DATABASE CHAM_CONG_NHAN_VIEN;
END
GO

USE CHAM_CONG_NHAN_VIEN;
GO

IF OBJECT_ID('Luong', 'U') IS NOT NULL DROP TABLE Luong;
IF OBJECT_ID('ThuongPhat', 'U') IS NOT NULL DROP TABLE ThuongPhat;
IF OBJECT_ID('ChamCong', 'U') IS NOT NULL DROP TABLE ChamCong;
IF OBJECT_ID('TaiKhoan', 'U') IS NOT NULL DROP TABLE TaiKhoan;
IF OBJECT_ID('TheTamThoi', 'U') IS NOT NULL DROP TABLE TheTamThoi;
IF OBJECT_ID('NhanVien', 'U') IS NOT NULL DROP TABLE NhanVien;
IF OBJECT_ID('CaLam', 'U') IS NOT NULL DROP TABLE CaLam;
GO


-- 1. Bảng Ca Làm Việc
CREATE TABLE CaLam (
    MaCa VARCHAR(50) PRIMARY KEY,
    TenCa NVARCHAR(50) NOT NULL,
    GioBatDau TIME NOT NULL,     
    GioKetThuc TIME NOT NULL     
);

-- 2. Bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10) NOT NULL,
    NgaySinh DATE,
    SoDienThoai VARCHAR(20),
    Email VARCHAR(100) UNIQUE,
    DiaChi NVARCHAR(255),
    LuongCoBan DECIMAL(12,2) DEFAULT 0,
    PhucCap DECIMAL(12,2) DEFAULT 0, 
    MaPhongBan NVARCHAR(50),
    MaCa VARCHAR(50),                  
    TrangThai BIT DEFAULT 1,
    MaTheRFID VARCHAR(50) UNIQUE NULL, 
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaCa) REFERENCES CaLam(MaCa) ON DELETE SET NULL
);

-- 3. Bảng Tài Khoản Hệ Thống
CREATE TABLE TaiKhoan (
    Username VARCHAR(50) PRIMARY KEY,
    PasswordHash VARCHAR(255) NOT NULL,
    MaNhanVien VARCHAR(50),
    Role NVARCHAR(20) DEFAULT 'User',
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien) ON DELETE CASCADE
);

-- 4. Bảng Thẻ Tạm Thời
CREATE TABLE TheTamThoi (
    MaTheTam VARCHAR(50) PRIMARY KEY,
    MaNhanVien VARCHAR(50) NOT NULL,
    NgayMuon DATETIME DEFAULT GETDATE(),
    NgayTra DATETIME NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien) ON DELETE CASCADE
);

-- 5. Bảng Chấm Công
CREATE TABLE ChamCong (
    MaChamCong INT IDENTITY PRIMARY KEY,
    MaNhanVien VARCHAR(50),
    ThoiGian DATETIME DEFAULT GETDATE(),
    Loai NVARCHAR(10),            
    MaCa VARCHAR(50) NULL,
    SoGioOT DECIMAL(4,2) DEFAULT 0, 
    IsManual BIT DEFAULT 0, 
    GhiChu NVARCHAR(255) NULL, 
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien) ON DELETE CASCADE,
    FOREIGN KEY (MaCa) REFERENCES CaLam(MaCa) ON DELETE SET NULL
);

-- 6. Bảng Thưởng Phạt
CREATE TABLE ThuongPhat (
    MaTP INT IDENTITY PRIMARY KEY,
    Ngay DATE DEFAULT GETDATE(),
    Loai NVARCHAR(20),            
    MaNhanVien VARCHAR(50),
    LyDo NVARCHAR(255),
    SoTien DECIMAL(12,2),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien) ON DELETE CASCADE
);

-- 7. Bảng Lương
CREATE TABLE Luong (
    MaLuong INT IDENTITY PRIMARY KEY,
    MaNhanVien VARCHAR(50),
    Thang INT,
    Nam INT,
    SoNgayCong INT,               
    TongGioOT DECIMAL(6,2),       
    LuongCoBan DECIMAL(12,2),
    TongPhucCap DECIMAL(12,2),
    TienLuongOT DECIMAL(12,2),    
    TongThuong DECIMAL(12,2),
    TongPhat DECIMAL(12,2),
    TongLuong DECIMAL(12,2),      
    NgayTinhLuong DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien) ON DELETE CASCADE
);
GO


INSERT INTO CaLam(MaCa, TenCa, GioBatDau, GioKetThuc)
VALUES 
('HC', N'Ca Hành Chính Cố Định', '07:30:00', '17:30:00');

INSERT INTO NhanVien(MaNhanVien, HoTen, GioiTinh, NgaySinh, SoDienThoai, Email, DiaChi, LuongCoBan, PhucCap, MaPhongBan, MaCa, TrangThai, MaTheRFID)
VALUES
('NV0001', N'Nguyễn Văn An', N'Nam', '1995-05-12', '0912345678', 'an@gmail.com', N'Hồ Chí Minh', 10400000, 600000, 'PB01', 'HC', 1, 'F40EAC39'),
('NV0002', N'Trần Thị Bình', N'Nữ', '1997-08-22', '0987654321', 'binh@gmail.com', N'Hà Nội', 7800000, 500000, 'PB02', 'HC', 1, '25AB1005'),   
('NV0003', N'Lê Minh Cường', N'Nam', '1993-11-02', '0905123456', 'cuong@gmail.com', N'Đà Nẵng', 13000000, 800000, 'PB01', 'HC', 1, '67F21496'), 
('NV0004', N'Phạm Hoàng Đức', N'Nam', '1994-02-15', '0933344555', 'duc@gmail.com', N'Bình Dương', 11000000, 700000, 'PB03', 'HC', 1, '09363107'), 
('NV0005', N'Nguyễn Thị Dung', N'Nữ', '1996-07-20', '0944455566', 'dung@gmail.com', N'Vũng Tàu', 8500000, 500000, 'PB02', 'HC', 1, '37343895'),   
('NV0006', N'Vũ Quốc Đạt', N'Nam', '1992-09-30', '0955566677', 'dat@gmail.com', N'Đồng Nai', 12500000, 750000, 'PB01', 'HC', 1, 'DDD81207');   

INSERT INTO ThuongPhat(Ngay, Loai, MaNhanVien, LyDo, SoTien)
VALUES
('2026-06-03', N'Thưởng', 'NV0001', N'Thưởng hoàn thành tiến độ', 500000);
GO

CREATE OR ALTER PROCEDURE ChamCong_RFID
    @UID VARCHAR(50),
    @ThoiGianQuet DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @MaNV VARCHAR(50);
    DECLARE @HoTen NVARCHAR(100);
    DECLARE @LastTime DATETIME;
    DECLARE @CheckInTime DATETIME;
    DECLARE @CheckOutTime DATETIME;
    DECLARE @UserMaCa VARCHAR(50);
    DECLARE @NewLoai NVARCHAR(10);
    DECLARE @RealTime DATETIME;
    
    DECLARE @GioKetThucCa TIME;
    DECLARE @NgayKetThucCa DATETIME;
    DECLARE @SoPhutLamThem INT = 0;
    DECLARE @SoGioOT DECIMAL(4,2) = 0;
    DECLARE @GhiChuTongGio NVARCHAR(255) = NULL;

    SET @UID = LTRIM(RTRIM(@UID));
    SET @RealTime = ISNULL(@ThoiGianQuet, GETDATE());

    -- Tìm nhân viên theo mã RFID
    SELECT @MaNV = MaNhanVien, @HoTen = HoTen, @UserMaCa = MaCa 
    FROM NhanVien 
    WHERE LTRIM(RTRIM(MaTheRFID)) = @UID;

    -- Tìm thẻ tạm thời nếu không thấy ở bảng chính
    IF @MaNV IS NULL
    BEGIN
        SELECT @MaNV = t.MaNhanVien, @HoTen = nv.HoTen, @UserMaCa = nv.MaCa
        FROM TheTamThoi t
        JOIN NhanVien nv ON t.MaNhanVien = nv.MaNhanVien
        WHERE LTRIM(RTRIM(t.MaTheTam)) = @UID AND t.NgayTra IS NULL;
    END

    -- Báo lỗi nếu thẻ không đăng ký thành viên nào
    IF @MaNV IS NULL
    BEGIN
        SELECT CAST(0 AS BIT) AS success, N'Thẻ không hợp lệ' AS [message], NULL AS maNV, NULL AS [name], NULL AS [status], @RealTime AS [time];
        RETURN;
    END

    -- Kiểm tra bản ghi quẹt thẻ gần nhất chống spam thiết bị (< 10 giây)
    SELECT TOP 1 @LastTime = ThoiGian
    FROM ChamCong
    WHERE MaNhanVien = @MaNV AND CAST(ThoiGian AS DATE) = CAST(@RealTime AS DATE)
    ORDER BY ThoiGian DESC;

    IF @LastTime IS NOT NULL AND DATEDIFF(SECOND, @LastTime, @RealTime) < 10
    BEGIN
        SELECT CAST(0 AS BIT) AS success, N'Quẹt quá nhanh' AS [message], @MaNV AS maNV, @HoTen AS [name], N'Ignored' AS [status], @RealTime AS [time];
        RETURN;
    END

    
    -- Trường hợp 1: Quẹt thẻ vào BUỔI SÁNG (Trước 12h00) -> Xử lý CheckIn độc quyền
    IF CAST(@RealTime AS TIME) < '22:00:00'
    BEGIN
        -- Tìm xem sáng nay đã có dòng CheckIn nào chưa
        SELECT TOP 1 @CheckInTime = ThoiGian 
        FROM ChamCong 
        WHERE MaNhanVien = @MaNV AND Loai = 'CheckIn' AND CAST(ThoiGian AS DATE) = CAST(@RealTime AS DATE)
        ORDER BY ThoiGian ASC;

        -- Nếu đã có dòng cũ -> Từ chối quẹt thêm và gửi kèm thông tin giờ cũ về màn hình
        IF @CheckInTime IS NOT NULL
        BEGIN
            SELECT CAST(0 AS BIT) AS success, 
                   N'Bạn đã CheckIn rồi! Giờ ghi nhận cũ: ' + CONVERT(VARCHAR(8), @CheckInTime, 108) AS [message], 
                   @MaNV AS maNV, @HoTen AS [name], N'CheckedIn_Before' AS [status], @CheckInTime AS [time];
            RETURN;
        END

        -- Nếu chưa có dòng -> Thực hiện ghi nhận mới lần đầu
        SET @NewLoai = 'CheckIn';
        SET @GhiChuTongGio = N'Quét vào đầu ca sáng thực tế';
    END
    
    -- Trường hợp 2: Quẹt thẻ vào BUỔI CHIỀU/TỐI (Từ 12h00 trở đi) -> Xử lý CheckOut độc quyền
    ELSE
    BEGIN
        -- Tìm xem chiều/tối nay đã có dòng CheckOut nào chưa
        SELECT TOP 1 @CheckOutTime = ThoiGian 
        FROM ChamCong 
        WHERE MaNhanVien = @MaNV AND Loai = 'CheckOut' AND CAST(ThoiGian AS DATE) = CAST(@RealTime AS DATE)
        ORDER BY ThoiGian ASC;

        -- Nếu đã có dòng cũ -> Từ chối quẹt thêm và gửi kèm thông tin giờ cũ về màn hình
        IF @CheckOutTime IS NOT NULL
        BEGIN
            SELECT CAST(0 AS BIT) AS success, 
                   N'Bạn đã CheckOut rồi! Giờ ghi nhận cũ: ' + CONVERT(VARCHAR(8), @CheckOutTime, 108) AS [message], 
                   @MaNV AS maNV, @HoTen AS [name], N'CheckedOut_Before' AS [status], @CheckOutTime AS [time];
            RETURN;
        END

        -- Nếu chưa có dòng -> Bắt đầu tiến hành CheckOut và tính toán giờ làm việc công
        SET @NewLoai = 'CheckOut';
        
        -- Tìm mốc CheckIn buổi sáng cùng ngày
        SELECT TOP 1 @CheckInTime = ThoiGian 
        FROM ChamCong 
        WHERE MaNhanVien = @MaNV AND Loai = 'CheckIn' AND CAST(ThoiGian AS DATE) = CAST(@RealTime AS DATE)
        ORDER BY ThoiGian ASC;

        -- Nếu tìm thấy giờ vào, thực hiện tính toán tổng số giờ làm việc thực tế trong ngày hôm đó
        IF @CheckInTime IS NOT NULL
        BEGIN
            DECLARE @TongSoPhutLamThucTe INT = DATEDIFF(MINUTE, @CheckInTime, @RealTime);
            DECLARE @TongSoGioDecimal DECIMAL(5,2) = CAST(@TongSoPhutLamThucTe AS DECIMAL(5,2)) / 60.0;
            SET @GhiChuTongGio = N'Tổng giờ làm trong ngày: ' + CAST(@TongSoGioDecimal AS VARCHAR(10)) + N' Giờ';
        END
        ELSE
        BEGIN
            SET @GhiChuTongGio = N'Không tìm thấy dữ liệu CheckIn buổi sáng';
        END

        -- Logic tính toán số giờ tăng ca OT thời gian thực (Mốc ca kết thúc cố định: 17:30:00)
        SELECT @GioKetThucCa = GioKetThuc FROM CaLam WHERE MaCa = @UserMaCa;
        SET @NgayKetThucCa = CAST(CAST(@RealTime AS DATE) AS DATETIME) + CAST(@GioKetThucCa AS DATETIME);
        
        IF @RealTime > @NgayKetThucCa
        BEGIN
            SET @SoPhutLamThem = DATEDIFF(MINUTE, @NgayKetThucCa, @RealTime);
            IF @SoPhutLamThem >= 30 -- Nếu thời gian làm thêm từ 30 phút trở lên thì bắt đầu tính tăng ca
            BEGIN
                SET @SoGioOT = CAST(@SoPhutLamThem AS DECIMAL(6,2)) / 60.0;
            END
        END
    END

    -- Thực hiện thêm mới dữ liệu chấm công thời gian thực (chỉ chạy đến đây khi đạt yêu cầu duy nhất)
    INSERT INTO ChamCong(MaNhanVien, ThoiGian, Loai, MaCa, SoGioOT, IsManual, GhiChu) 
    VALUES (@MaNV, @RealTime, @NewLoai, @UserMaCa, @SoGioOT, 0, @GhiChuTongGio);

    SELECT CAST(1 AS BIT) AS success, N'OK' AS [message], @MaNV AS maNV, @HoTen AS [name], @NewLoai AS [status], @RealTime AS [time];
END
GO


CREATE OR ALTER PROCEDURE SP_CapTheTamThoi
    @MaNhanVien VARCHAR(50),
    @MaTheTam VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE TheTamThoi SET NgayTra = GETDATE() WHERE MaNhanVien = @MaNhanVien AND NgayTra IS NULL;
    INSERT INTO TheTamThoi(MaTheTam, MaNhanVien, NgayMuon) VALUES (LTRIM(RTRIM(@MaTheTam)), @MaNhanVien, GETDATE());
    PRINT N'Đã cấp thẻ tạm thành công';
END
GO

CREATE OR ALTER PROCEDURE SP_ThuHoiTheTamThoi
    @MaTheTam VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE TheTamThoi SET NgayTra = GETDATE() WHERE MaTheTam = LTRIM(RTRIM(@MaTheTam)) AND NgayTra IS NULL;
    PRINT N'Đã xử lý thu hồi thẻ tạm thành công';
END
GO

CREATE OR ALTER PROCEDURE SP_BaoMatVaCapTheMoi
    @MaNhanVien VARCHAR(50),
    @MaTheMoi VARCHAR(50),
    @TienPhat DECIMAL(12,2) = 50000
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE NhanVien SET MaTheRFID = LTRIM(RTRIM(@MaTheMoi)) WHERE MaNhanVien = @MaNhanVien;
    INSERT INTO ThuongPhat(Ngay, Loai, MaNhanVien, LyDo, SoTien) VALUES (CAST(GETDATE() AS DATE), N'Phạt', @MaNhanVien, N'Phạt mất thẻ RFID', -@TienPhat);
    SELECT CAST(1 AS BIT) AS success, N'Đã cấp lại thẻ mới' AS [message];
END
GO

CREATE OR ALTER PROCEDURE SP_ChinhSuaCongThuCong
    @MaNhanVien VARCHAR(50),
    @ThoiGian DATETIME,
    @Loai NVARCHAR(10), 
    @GhiChu NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @MaCa VARCHAR(50);
    SELECT @MaCa = MaCa FROM NhanVien WHERE MaNhanVien = @MaNhanVien;
    INSERT INTO ChamCong(MaNhanVien, ThoiGian, Loai, MaCa, IsManual, GhiChu) VALUES (@MaNhanVien, @ThoiGian, @Loai, @MaCa, 1, @GhiChu);
    SELECT CAST(1 AS BIT) AS success, N'Đã bổ sung công thủ công thành công' AS [message];
END
GO

CREATE OR ALTER PROCEDURE SP_TinhLuongThang
    @Thang INT,
    @Nam INT,
    @SoNgayCongChuan INT = 26 
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Luong WHERE Thang = @Thang AND Nam = @Nam;

    INSERT INTO Luong (MaNhanVien, Thang, Nam, SoNgayCong, TongGioOT, LuongCoBan, TongPhucCap, TienLuongOT, TongThuong, TongPhat, TongLuong)
    SELECT 
        nv.MaNhanVien,
        @Thang AS Thang,
        @Nam AS Nam,
        ISNULL(cc.SoNgayCongThucTe, 0) AS SoNgayCong,
        ISNULL(cc.TongGioOTThucTe, 0) AS TongGioOT,
        nv.LuongCoBan,
        nv.PhucCap AS TongPhucCap,
        
        CAST((ISNULL(cc.TongGioOTThucTe, 0) * 100000.00) AS DECIMAL(12,2)) AS TienLuongOT,

        ISNULL(tp.TongThuong, 0) AS TongThuong,
        ISNULL(tp.TongPhat, 0) AS TongPhat,
        
        CAST(
            ((nv.LuongCoBan / @SoNgayCongChuan) * ISNULL(cc.SoNgayCongThucTe, 0)) 
            + nv.PhucCap 
            + (ISNULL(cc.TongGioOTThucTe, 0) * 100000.00) 
            + ISNULL(tp.TongThuong, 0) 
            + ISNULL(tp.TongPhat, 0)
        AS DECIMAL(12,2)) AS TongLuong
    FROM NhanVien nv
    LEFT JOIN (
        SELECT 
            MaNhanVien, 
            COUNT(DISTINCT CAST(ThoiGian AS DATE)) AS SoNgayCongThucTe,
            SUM(SoGioOT) AS TongGioOTThucTe
        FROM ChamCong
        WHERE MONTH(ThoiGian) = @Thang AND YEAR(ThoiGian) = @Nam
        GROUP BY MaNhanVien
    ) cc ON nv.MaNhanVien = cc.MaNhanVien
    LEFT JOIN (
        SELECT 
            MaNhanVien,
            SUM(CASE WHEN Loai = N'Thưởng' THEN SoTien ELSE 0 END) AS TongThuong,
            SUM(CASE WHEN Loai = N'Phạt' THEN SoTien ELSE 0 END) AS TongPhat
        FROM ThuongPhat
        WHERE MONTH(Ngay) = @Thang AND YEAR(Ngay) = @Nam
        GROUP BY MaNhanVien
    ) tp ON nv.MaNhanVien = tp.MaNhanVien
    WHERE nv.TrangThai = 1;

    PRINT N'==> HỆ THỐNG: Đã chốt và tính toán bảng lương thành công cho Tháng ' + CAST(@Thang AS VARCHAR(2)) + '/' + CAST(@Nam AS VARCHAR(4));
END
GO


PRINT '--- BẮT ĐẦU KIỂM THỬ HỆ THỐNG THỜI GIAN THỰC CHÍNH XÁC ---';

-- Ngày 01: Nguyễn Văn An (F40EAC39) đến cơ quan sớm, về đúng giờ hành chính
EXEC ChamCong_RFID @UID = 'F40EAC39', @ThoiGianQuet = '2026-06-01 07:25:00'; -- Thử nghiệm CheckIn thành công lần đầu.
EXEC ChamCong_RFID @UID = 'F40EAC39', @ThoiGianQuet = '2026-06-01 07:28:00'; -- Thử nghiệm cố tình quẹt lặp sáng -> BÁO TRÙNG & TRẢ VỀ GIỜ CŨ (07:25:00)
EXEC ChamCong_RFID @UID = 'F40EAC39', @ThoiGianQuet = '2026-06-01 17:30:00'; -- Thử nghiệm CheckOut thành công lần đầu.
EXEC ChamCong_RFID @UID = 'F40EAC39', @ThoiGianQuet = '2026-06-01 17:35:00'; -- Thử nghiệm cố tình quẹt lặp chiều -> BÁO TRÙNG & TRẢ VỀ GIỜ CŨ (17:30:00)

-- Ngày 02: An đi làm bình thường, buổi chiều tăng ca về muộn 2 tiếng
EXEC ChamCong_RFID @UID = 'F40EAC39', @ThoiGianQuet = '2026-06-02 07:20:00'; -- CheckIn thực tế
EXEC ChamCong_RFID @UID = 'F40EAC39', @ThoiGianQuet = '2026-06-02 19:30:00'; -- CheckOut thực tế (Làm thêm 2h tăng ca)

-- Ngày 03: An đi làm muộn một chút, ở lại tăng ca muộn đến 21:00 đêm
EXEC ChamCong_RFID @UID = 'F40EAC39', @ThoiGianQuet = '2026-06-03 07:45:00'; -- CheckIn thực tế
EXEC ChamCong_RFID @UID = 'F40EAC39', @ThoiGianQuet = '2026-06-03 21:00:00'; -- CheckOut thực tế (Làm thêm 3.5h tăng ca)

-- KIỂM THỬ ĐỒNG LOẠT CHO CÁC THÀNH VIÊN KHÁC TRONG NGÀY 01:
-- Quẹt thẻ đầu ca sáng (Hệ thống ghi nhận thời gian thực làm mốc CheckIn)
EXEC ChamCong_RFID @UID = '09363107', @ThoiGianQuet = '2026-06-01 07:15:00'; -- Phạm Hoàng Đức -> CheckIn
EXEC ChamCong_RFID @UID = '37343895', @ThoiGianQuet = '2026-06-01 07:22:00'; -- Nguyễn Thị Dung -> CheckIn
EXEC ChamCong_RFID @UID = '67F21496', @ThoiGianQuet = '2026-06-01 07:25:00'; -- Lê Minh Cường -> CheckIn
EXEC ChamCong_RFID @UID = '25AB1005', @ThoiGianQuet = '2026-06-01 07:29:00'; -- Trần Thị Bình -> CheckIn
EXEC ChamCong_RFID @UID = 'DDD81207', @ThoiGianQuet = '2026-06-01 07:31:00'; -- Vũ Quốc Đạt -> CheckIn

-- Quẹt thẻ đầu ca chiều/tối về (Hệ thống tính tổng giờ từ mốc sáng và xuất OT nếu trễ sau 17:30)
EXEC ChamCong_RFID @UID = '09363107', @ThoiGianQuet = '2026-06-01 17:35:00'; -- Phạm Hoàng Đức -> CheckOut
EXEC ChamCong_RFID @UID = '37343895', @ThoiGianQuet = '2026-06-01 17:30:00'; -- Nguyễn Thị Dung -> CheckOut
EXEC ChamCong_RFID @UID = '67F21496', @ThoiGianQuet = '2026-06-01 18:30:00'; -- Lê Minh Cường -> CheckOut (OT 1.00 giờ)
EXEC ChamCong_RFID @UID = '25AB1005', @ThoiGianQuet = '2026-06-01 17:30:00'; -- Trần Thị Bình -> CheckOut
EXEC ChamCong_RFID @UID = 'DDD81207', @ThoiGianQuet = '2026-06-01 17:45:00'; -- Vũ Quốc Đạt -> CheckOut


EXEC SP_TinhLuongThang @Thang = 6, @Nam = 2026, @SoNgayCongChuan = 26;
GO

PRINT '--- BẢNG CHI TIẾT GIỜ CÔNG THỜI GIAN THỰC & TỔNG GIỜ LÀM VIỆC TỰ ĐỘNG ---';
SELECT cc.MaChamCong, cc.MaNhanVien, nv.HoTen, cc.ThoiGian, cc.Loai, cc.SoGioOT, cc.GhiChu 
FROM ChamCong cc
JOIN NhanVien nv ON cc.MaNhanVien = nv.MaNhanVien;

PRINT '--- BẢNG LƯƠNG PAYSLIP XUẤT RA CHO KẾ TOÁN (KIỂM TRA CỘT TIỀN OT) ---';
SELECT 
    l.MaLuong,
    nv.MaNhanVien,
    nv.HoTen,
    l.SoNgayCong AS [Ngày Công Thực Tế],
    l.TongGioOT AS [Tổng Giờ Tăng Ca],
    l.LuongCoBan AS [Lương Hợp Đồng],
    l.TongPhucCap AS [Phụ Cấp Cố Định],
    l.TienLuongOT AS [Tiền Thêm Giờ (Tổng Giờ OT x 100K)],
    l.TongThuong AS [Thưởng],
    l.TongPhat AS [Phạt],
    l.TongLuong AS [THỰC LĨNH CHUYỂN KHOẢN]
FROM Luong l
JOIN NhanVien nv ON l.MaNhanVien = nv.MaNhanVien;