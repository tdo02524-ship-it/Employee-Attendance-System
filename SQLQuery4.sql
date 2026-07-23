USE CHAM_CONG_NHAN_VIEN;
GO

ALTER PROCEDURE ChamCong_RFID
@UID VARCHAR(50)
AS
BEGIN
SET NOCOUNT ON;
DECLARE @MaNV VARCHAR(50);
DECLARE @HoTen NVARCHAR(100);
DECLARE @Last NVARCHAR(10);
DECLARE @LastTime DATETIME;
DECLARE @UserMaCa VARCHAR(50);
DECLARE @NewLoai NVARCHAR(10);

SET @UID = LTRIM(RTRIM(@UID));

-- Lấy thông tin nhân viên
SELECT @MaNV = MaNhanVien, @HoTen = HoTen, @UserMaCa = MaCa 
FROM NhanVien 
WHERE LTRIM(RTRIM(MaTheRFID)) = @UID;

-- TH1: Thẻ không hợp lệ
IF @MaNV IS NULL
BEGIN
    SELECT CAST(0 AS BIT) AS success, N'Thẻ không hợp lệ' AS [message], NULL AS maNV, NULL AS [name], NULL AS [status], GETDATE() AS [time];
    RETURN;
END

-- Lấy trạng thái quẹt gần nhất
SELECT TOP 1 @Last = Loai, @LastTime = ThoiGian
FROM ChamCong
WHERE MaNhanVien = @MaNV
ORDER BY ThoiGian DESC;

-- TH2: Quẹt quá nhanh (Chống trùng lặp thẻ dưới 10 giây)
IF @LastTime IS NOT NULL AND DATEDIFF(SECOND, @LastTime, GETDATE()) < 10
BEGIN
    SELECT CAST(0 AS BIT) AS success, N'Quẹt quá nhanh' AS [message], @MaNV AS maNV, @HoTen AS [name], @Last AS [status], GETDATE() AS [time];
    RETURN;
END

-- Tự động đảo trạng thái CheckIn / CheckOut
IF @Last IS NULL OR @Last = 'CheckOut'
    SET @NewLoai = 'CheckIn';
ELSE
    SET @NewLoai = 'CheckOut';

-- Chèn vào bảng chấm công
INSERT INTO ChamCong(MaNhanVien, Loai, MaCa) VALUES (@MaNV, @NewLoai, @UserMaCa);

-- TH3: Trả về kết quả CHUẨN để Node.js biến thành JSON gửi cho C#
SELECT CAST(1 AS BIT) AS success, N'OK' AS [message], @MaNV AS maNV, @HoTen AS [name], @NewLoai AS [status], GETDATE() AS [time];
END
GO
ALTER TABLE NhanVien ADD PhuCap DECIMAL(18, 0) NULL;