
CREATE DATABASE QuanLyNhanVien_LT2_Premium;
GO
USE QuanLyNhanVien_LT2_Premium;

CREATE TABLE TaiKhoan
(
    TenDN VARCHAR(20) PRIMARY KEY,
    TenHT NVARCHAR(100) NOT NULL,
    MatKhau VARCHAR(20) NOT NULL,
    Quyen INT
);
GO

CREATE TABLE phongban
(
    Maphong VARCHAR(20) PRIMARY KEY,
    Tenphong NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE NhanVien
(
    MaNV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NamSinh INT,
    GioiTinh NVARCHAR(5),
    DiaChi NVARCHAR(100),
    DienThoai VARCHAR(15),
    Maphong VARCHAR(20),
    FOREIGN KEY (Maphong) REFERENCES phongban(Maphong)
);
GO

CREATE TABLE NhaCungCap
(
    MaNCC VARCHAR(20) PRIMARY KEY,
    TenNCC NVARCHAR(100) NOT NULL,
    DiaChiNCC NVARCHAR(100),
    DienThoaiNCC VARCHAR(15)
);
GO

CREATE TABLE HangHoa
(
    MaHang VARCHAR(20) PRIMARY KEY,
    TenHang NVARCHAR(100) NOT NULL,
    DonViTinh NVARCHAR(20),
    SoLuongTon INT,
    DonGia DECIMAL(18, 2),
    MaNCC VARCHAR(20),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);
GO

CREATE TABLE HoaDon
(
    MaHD VARCHAR(20) PRIMARY KEY,
    HoTenKH NVARCHAR(100) NOT NULL,
    SDTKH VARCHAR(15),
    DiaChiKH NVARCHAR(100)
);
GO

CREATE TABLE CTBan
(
    MaHD VARCHAR(20),
    MaHang VARCHAR(20),
    SoLuongBan INT,
    PRIMARY KEY (MaHD, MaHang),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaHang) REFERENCES HangHoa(MaHang)
);
GO

INSERT INTO TaiKhoan VALUES('phong', N'Hữu Phong', '123456', 1);
INSERT INTO TaiKhoan VALUES('Binh', N'Thiên Bình', '123456', 0);
INSERT INTO TaiKhoan VALUES('An', N'Thanh An', '123456', 0);
INSERT INTO TaiKhoan VALUES('anh', N'Hà Anh', '123456', 0);
INSERT INTO TaiKhoan VALUES('quoc', N'Hữu Quốc', '123456', 0);
INSERT INTO TaiKhoan VALUES('quoc1', N'Hữu Quốc', '123456', 0);

INSERT INTO phongban VALUES('TC', N'Tài Chính');
INSERT INTO phongban VALUES('CN', N'Công Nghệ');
INSERT INTO phongban VALUES('NS', N'Nhân Sự');
INSERT INTO phongban VALUES('KD', N'Kinh Doanh');

INSERT INTO NhanVien VALUES('NV0001', N'Hữu Phong', 1990, N'Nam', N'Vĩnh Long', '0988994450', 'TC');
INSERT INTO NhanVien VALUES('NV0002', N'Minh Thanh', 1987, N'Nam', N'Bạc Liêu', '0988993450', 'CN');
INSERT INTO NhanVien VALUES('NV0003', N'Thúy Liễu', 1984, N'Nữ', N'Trà Vinh', '0988994460', 'NS');
INSERT INTO NhanVien VALUES('NV0004', N'Nam Bình', 1979, N'Nam', N'An Giang', '0988994457', 'KD');
INSERT INTO NhanVien VALUES('NV0005', N'Ngọc Bình', 1981, N'Nữ', N'Cà Mau', '0988994750', 'CN');
INSERT INTO NhanVien VALUES('NV0006', N'Hoàng Phú', 1982, N'Nam', N'Hậu Giang', '0987994450', 'KD');

INSERT INTO NhaCungCap VALUES('NCC01', N'Công ty A', N'Hà Nội', '0241234567');
INSERT INTO NhaCungCap VALUES('NCC02', N'Công ty B', N'Đà Nẵng', '0236123456');
INSERT INTO NhaCungCap VALUES('NCC03', N'Công ty C', N'Sài Gòn', '0281234567');
INSERT INTO NhaCungCap VALUES('NCC04', N'Công ty D', N'Hải Phòng', '0225123456');
INSERT INTO NhaCungCap VALUES('NCC05', N'Công ty E', N'Bình Dương', '0274123456');

INSERT INTO HangHoa VALUES('HH01', N'Sữa tươi', N'Hộp', 100, 15000, 'NCC01');
INSERT INTO HangHoa VALUES('HH02', N'Mỳ gói', N'Gói', 200, 3000, 'NCC02');
INSERT INTO HangHoa VALUES('HH03', N'Nước ngọt', N'Lon', 150, 10000, 'NCC03');
INSERT INTO HangHoa VALUES('HH04', N'Bánh mì', N'Cái', 50, 5000, 'NCC04');
INSERT INTO HangHoa VALUES('HH05', N'Gạo', N'Kg', 300, 20000, 'NCC05');

INSERT INTO HoaDon VALUES('HD01', N'Nguyễn Văn A', '0901234567', N'Hà Nội');
INSERT INTO HoaDon VALUES('HD02', N'Trần Thị B', '0912345678', N'Hải Phòng');
INSERT INTO HoaDon VALUES('HD03', N'Lê Văn C', '0934567890', N'Hồ Chí Minh');
INSERT INTO HoaDon VALUES('HD04', N'Phạm Thị D', '0921234567', N'Đà Nẵng');
INSERT INTO HoaDon VALUES('HD05', N'Ngô Văn E', '0976543210', N'Bình Dương');

INSERT INTO CTBan VALUES('HD01', 'HH01', 2);
INSERT INTO CTBan VALUES('HD01', 'HH03', 1);
INSERT INTO CTBan VALUES('HD02', 'HH02', 5);
INSERT INTO CTBan VALUES('HD03', 'HH04', 3);
INSERT INTO CTBan VALUES('HD04', 'HH01', 1);
INSERT INTO CTBan VALUES('HD05', 'HH05', 10);

SELECT * FROM TaiKhoan;
SELECT * FROM phongban;
SELECT * FROM NhanVien;
SELECT * FROM NhaCungCap;
SELECT * FROM HangHoa;
SELECT * FROM HoaDon;
SELECT * FROM CTBan;
