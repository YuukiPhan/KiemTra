-- Tạo cơ sở dữ liệu
CREATE DATABASE De02;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
GO

-- Tạo bảng LoaiSP
CREATE TABLE LoaiSP (
    MaLoai char(2) PRIMARY KEY,
    TenLoai nvarchar(30)
);

-- Tạo bảng Sanpham
CREATE TABLE Sanpham (
    MaSP char(6) PRIMARY KEY,
    TenSP nvarchar(30),
    Ngaynhap DateTime,
    MaLoai char(2),
    FOREIGN KEY (MaLoai) REFERENCES LoaiSP(MaLoai)
);

-- Nhập dữ liệu mẫu cho bảng LoaiSP
INSERT INTO LoaiSP (MaLoai, TenLoai) VALUES
('DT', N'Điện thoại'),
('LT', N'Laptop'),
('TV', N'Tivi'),
('TL', N'Tủ lạnh');

-- Nhập dữ liệu mẫu cho bảng Sanpham
INSERT INTO Sanpham (MaSP, TenSP, Ngaynhap, MaLoai) VALUES
('SP0001', N'iPhone 13', '2023-01-15', 'DT'),
('SP0002', N'Samsung Galaxy S21', '2023-02-20', 'DT'),
('SP0003', N'MacBook Pro', '2023-03-10', 'LT'),
('SP0004', N'Dell XPS 13', '2023-04-05', 'LT'),
('SP0005', N'Sony Bravia 55"', '2023-05-12', 'TV'),
('SP0006', N'LG OLED 65"', '2023-06-18', 'TV'),
('SP0007', N'Panasonic Inverter 300L', '2023-07-22', 'TL'),
('SP0008', N'Samsung Side-by-Side 620L', '2023-08-30', 'TL');

-- Kiểm tra dữ liệu đã nhập
SELECT * FROM LoaiSP;
SELECT * FROM Sanpham;