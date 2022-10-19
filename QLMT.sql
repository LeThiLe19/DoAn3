USE [QLMT1]
GO
---Tạo bảng loại sản phẩm máy tính

CREATE TABLE LoaiMT(
MaLoai NVARCHAR (10) PRIMARY KEY,
TenLoai NVARCHAR (50)
)
---Tạo bảng nhà cung cấp
CREATE TABLE NCC(
MaNCC NVARCHAR (10) PRIMARY KEY,
TenNCC NVARCHAR(50),
Diachi NVARCHAR(50),
Sdt NVARCHAR(10)
)
----Tạo bảng khách hàng
CREATE TABLE KhachHang(
MaKH NVARCHAR (10) PRIMARY KEY,
TenKH NVARCHAR(50),
Diachi NVARCHAR(50),
Sdt NVARCHAR(10)
)
----Tạo bảng nhân viên
CREATE TABLE NhanVien(
MaNV NVARCHAR (10) PRIMARY KEY,
TenNV NVARCHAR(50),
Diachi NVARCHAR(50),
Sdt NVARCHAR(10)
)
----Tạo bảng sản phẩm máy tính
CREATE TABLE MayTinh(
MaMT NVARCHAR (10) PRIMARY KEY,
TenMT NVARCHAR(50),
Soluong INT,
Gianhap INT,
Giaban INT,
MaLoai NVARCHAR(10) CONSTRAINT L_LoaiMT FOREIGN KEY REFERENCES LoaiMT(MaLoai) ON DELETE CASCADE ON UPDATE CASCADE
)
--tạo bảng hóa đơn bán
CREATE TABLE HoaDonBan(
MaHDB NVARCHAR (10) PRIMARY KEY,
MaKH NVARCHAR(10) CONSTRAINT N_KhachHang FOREIGN KEY REFERENCES Khachhang(MaKH) ON DELETE CASCADE ON UPDATE CASCADE,
MaNV NVARCHAR(10) CONSTRAINT N_NhanVien FOREIGN KEY REFERENCES NhanVien(MaNV) ON DELETE CASCADE ON UPDATE CASCADE,
TongTien FLOAT,
ThoigianB DateTime
)

--tạo bảng chi tiết hóa đơn bán
CREATE TABLE ChiTietHDB(
MaHDB NVARCHAR(10) ,
MaMT NVARCHAR(10),
Soluong INT,
Giaban INT,
TongTien INT
CONSTRAINT PK_ChiTietHDB PRIMARY KEY(MaHDB,MaMT)
CONSTRAINT FK_MaHDB_ChiTietHDB FOREIGN KEY(MaHDB) REFERENCES HoaDonBan(MaHDB),
CONSTRAINT FK_MaMT_ChiTietHDB FOREIGN KEY(MaMT) REFERENCES Maytinh(MaMT)
)
--tạo bảng hóa đơn nhập
CREATE TABLE HoaDonNhap(
MaHDN NVARCHAR(10) PRIMARY KEY,
maNCC NVARCHAR(10) CONSTRAINT N_NCC FOREIGN KEY REFERENCES NCC(MaNCC),
MaNV NVARCHAR(10) CONSTRAINT f_NhanVien FOREIGN KEY REFERENCES NhanVien(MaNV),
Tongtien int,
ThoigianN DateTime,
)

--tạo bảng chi tiết hóa đơn nhập
create table ChiTietHDN(
MaHDN NVARCHAR(10)  ,
MaMT NVARCHAR(10) ,
Soluong int,
Gianhap int,
Tongtien int
constraint P_ChiTietHDN primary key(MaHDN,MaMT)
constraint F_MaHDN_ChiTietHDN foreign key(MaHDN) references HoaDonNhap(MaHDN),
constraint F_MaMT_ChiTietHDN foreign key(maMT) references MayTinh(MaMT)
)

--*)Nhập dữ liệu vào bảng loại sản phẩm
INSERT INTO LoaiMT (MaLoai, TenLoai)
VALUES ('ML001', 'ACER')
INSERT INTO LoaiMT (MaLoai, TenLoai)
VALUES ('ML002', 'MSI')
INSERT INTO LoaiMT (MaLoai, TenLoai)
VALUES ('ML003', 'ASUS')
INSERT INTO LoaiMT (MaLoai, TenLoai)
VALUES ('ML004', 'MACBOOK')
INSERT INTO LoaiMT (MaLoai, TenLoai)
VALUES ('ML005', 'SAMSUNG')
INSERT INTO LoaiMT (MaLoai, TenLoai)
VALUES ('ML006', 'HP')
INSERT INTO LoaiMT (MaLoai, TenLoai)
VALUES ('ML007', 'DELL')
INSERT INTO LoaiMT (MaLoai, TenLoai)
VALUES ('ML008', 'TOSHIBA')
INSERT INTO LoaiMT (MaLoai, TenLoai)
VALUES ('ML009', 'LENOVO')
INSERT INTO LoaiMT (MaLoai, TenLoai)
VALUES ('ML010', 'RAZER')
SELECT * FROM LoaiMT

--*)Nhập dữ liệu vào bảng máy tính
INSERT INTO MayTinh (MaMT, TenMT, Soluong, Gianhap, Giaban, MaLoai)
VALUES ('MT001', 'Laptop Acer Aspire 3 A315', '8', '12000000', '13500000', 'ML001')
INSERT INTO MayTinh (MaMT, TenMT, Soluong, Gianhap, Giaban, MaLoai)
VALUES ('MT002', 'Laptop MSI Prestige 14 A10RAS-234VN Rose Pink', '5', '25000000', '27000000', 'ML002')
INSERT INTO MayTinh (MaMT, TenMT, Soluong, Gianhap, Giaban, MaLoai)
VALUES ('MT003', 'Laptop Asus Zenbook 14 Q407IQ ', '11', '15000000', '16500000', 'ML003')
INSERT INTO MayTinh (MaMT, TenMT, Soluong, Gianhap, Giaban, MaLoai)
VALUES ('MT004', 'Laptop Macbook Pro 13 inch 2019', '15', '20000000', '21500000', 'ML004')
INSERT INTO MayTinh (MaMT, TenMT, Soluong, Gianhap, Giaban, MaLoai)
VALUES ('MT005', 'Laptop Samsung Galaxy Book Flex Alpha ', '10', '19000000', '20500000', 'ML005')
INSERT INTO MayTinh (MaMT, TenMT, Soluong, Gianhap, Giaban, MaLoai)
VALUES ('MT006', 'Laptop HP EliteBook', '10', '17000000', '18500000', 'ML006')
INSERT INTO MayTinh (MaMT, TenMT, Soluong, Gianhap, Giaban, MaLoai)
VALUES ('MT007', 'Laptop Dell XPS 9360', '12', '18000000', '18900000', 'ML007')
INSERT INTO MayTinh (MaMT, TenMT, Soluong, Gianhap, Giaban, MaLoai)
VALUES ('MT008', 'Laptop Toshiba Portege', '10', '7000000', '8500000', 'ML008')
INSERT INTO MayTinh (MaMT, TenMT, Soluong, Gianhap, Giaban, MaLoai)
VALUES ('MT009', 'Laptop Lenovo IdeaPad S340', '10', '12000000', '12800000', 'ML009')
INSERT INTO MayTinh (MaMT, TenMT, Soluong, Gianhap, Giaban, MaLoai)
VALUES ('MT010', 'Laptop Razer Blade 15 Advanced 2020 ', '10', '60000000', '62000000', 'ML010')
SELECT *FROM MayTinh


--*) Nhập dữ liệu vào bảng khách hàng 
INSERT INTO KhachHang (MaKH, TenKH, Diachi, Sdt)
VALUES ('Kh001', N'Nguyễn Thu Hường', N'Hưng Yên', '0858859459')
INSERT INTO KhachHang (MaKH, TenKH, Diachi, Sdt)
VALUES ('Kh002', N'Nguyễn Hồng Hà', N'Thái Bình', '0984954844')
INSERT INTO KhachHang (MaKH, TenKH, Diachi, Sdt)
VALUES ('Kh003', N'Lê Thu Trang', N'Hải Dương', '0532577477')
INSERT INTO KhachHang (MaKH, TenKH, Diachi, Sdt)
VALUES ('Kh004', N'Trần Kim Anh', N'Hà Nội', '0372687472')
INSERT INTO KhachHang (MaKH, TenKH, Diachi, Sdt)
VALUES ('Kh005', N'Phạm Thị Thu Trang', N'Hà Nội', '0351526584')
INSERT INTO KhachHang (MaKH, TenKH, Diachi, Sdt)
VALUES ('Kh006', N'Vương Văn Vũ', N'Nam Định', '0367523674')
INSERT INTO KhachHang (MaKH, TenKH, Diachi, Sdt)
VALUES ('Kh007', N'Phạm Hoa Lan', N'Quảng Ninh', '0373624578')
INSERT INTO KhachHang (MaKH, TenKH, Diachi, Sdt)
VALUES ('Kh008', N'Đinh Trang Anh', N'Hưng Yên', '0385884328')
INSERT INTO KhachHang (MaKH, TenKH, Diachi, Sdt)
VALUES ('Kh009', N'Lê Thái An', N'Hà Nội', '0326746347')
INSERT INTO KhachHang (MaKH, TenKH, Diachi, Sdt)
VALUES ('Kh010', N'Trịnh Khánh Huyền', N'Hải Dương', '0382314785')
SELECT *FROM KhachHang

--*) Nhập dữ liệu vào bảng nhân viên 
INSERT INTO NhanVien (MaNV, TenNV, Diachi, Sdt)
VALUES ('Nv001', N'Nguyễn Ngọc Duyên', N'Hà Nội', '0251423658')
INSERT INTO NhanVien (MaNV, TenNV, Diachi, Sdt)
VALUES ('Nv002', N'Lê Lan Anh', N'Nghệ An', '0934762313')
INSERT INTO NhanVien (MaNV, TenNV, Diachi, Sdt)
VALUES ('Nv003', N'Dương Phương Anh', N'Hưng Yên', '097537733')
INSERT INTO NhanVien (MaNV, TenNV, Diachi, Sdt)
VALUES ('Nv004', N'Tạ Thị Hà', N'Thanh Hoá', '092374721')
INSERT INTO NhanVien (MaNV, TenNV, Diachi, Sdt)
VALUES ('Nv005', N'Lê Thu Thuỷ', N'Hà Nội', '0227663753')
INSERT INTO NhanVien (MaNV, TenNV, Diachi, Sdt)
VALUES ('Nv006', N'Hoàng Ngọc Hải', N'Đà Lạt', '0364732726')
INSERT INTO NhanVien (MaNV, TenNV, Diachi, Sdt)
VALUES ('Nv007', N'Lê Văn Hoàng', N'Bắc Giang', '093747771')
INSERT INTO NhanVien (MaNV, TenNV, Diachi, Sdt)
VALUES ('Nv008', N'Hoàng Việt Anh', N'Hưng Yên', '097647342')
INSERT INTO NhanVien (MaNV, TenNV, Diachi, Sdt)
VALUES ('Nv009', N'Phạm Trung Hiếu', N'Nam Định', '037438786')
INSERT INTO NhanVien (MaNV, TenNV, Diachi, Sdt)
VALUES ('Nv010', N'Bạch Huy Hoàng', N'Hưng Yên', '037894375')
SELECT * FROM NhanVien


--*)Nhập dữ liệu vào bảng Nhà cung cấp
INSERT INTO NCC (MaNCC, TenNCC, Diachi, Sdt)
VALUES ('Ncc001', N'Hoàng Phát', N'Hà Nội', '022202222')
INSERT INTO NCC (MaNCC, TenNCC, Diachi, Sdt)
VALUES ('Ncc002', N'Hoàng Gia', N'Hà Nội', '0568584264')
INSERT INTO NCC (MaNCC, TenNCC, Diachi, Sdt)
VALUES ('Ncc003', N'Hoàng Hà', N'Hà Nội', '0162558464')
INSERT INTO NCC (MaNCC, TenNCC, Diachi, Sdt)
VALUES ('Ncc004', N'Hoàng Tuyền', N'Hà Nội', '0169584264')
INSERT INTO NCC (MaNCC, TenNCC, Diachi, Sdt)
VALUES ('Ncc005', N'Đại Nam', N'Hải Phòng', '0162585464')
INSERT INTO NCC (MaNCC, TenNCC, Diachi, Sdt)
VALUES ('Ncc006', N'Đông Á', N'Quảng Ninh', '0166954264')
INSERT INTO NCC (MaNCC, TenNCC, Diachi, Sdt)
VALUES ('Ncc007', N'Hoàng Phát', N'Hà Nội', '022202222')
INSERT INTO NCC (MaNCC, TenNCC, Diachi, Sdt)
VALUES ('Ncc008', N'Phân Phối', N'Hà Nội', '0162968264')
INSERT INTO NCC (MaNCC, TenNCC, Diachi, Sdt)
VALUES ('Ncc009', N'Thanh Mai', N'Hà Nội', '0972347723')
INSERT INTO NCC (MaNCC, TenNCC, Diachi, Sdt)
VALUES ('Ncc010', N'Thanh Hà', N'Hà Nội', '033458194')
SELECT *FROM NCC

--*) Thêm dữ liệu vào bảng hoá đơn bán
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, TongTien, ThoigianB)
VALUES ('HDB001', 'Kh001', 'Nv001', '14000000', '01/27/2021')
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, TongTien, ThoigianB)
VALUES ('HDB002', 'Kh002', 'Nv002', '21000000', '02/14/2021')
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, TongTien, ThoigianB)
VALUES ('HDB003', 'Kh003', 'Nv003', '23000000', '02/25/2021')
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, TongTien, ThoigianB)
VALUES ('HDB004', 'Kh004', 'Nv004', '15000000', '03/12/2021')
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, TongTien, ThoigianB)
VALUES ('HDB005', 'Kh005', 'Nv005', '24000000', '01/27/2020')
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, TongTien, ThoigianB)
VALUES ('HDB006', 'Kh006', 'Nv006', '16500000', '01/30/2021')
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, TongTien, ThoigianB)
VALUES ('HDB007', 'Kh007', 'Nv007', '24000000', '04/10/2021')
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, TongTien, ThoigianB)
VALUES ('HDB008', 'Kh008', 'Nv008', '14000000', '03/25/2021')
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, TongTien, ThoigianB)
VALUES ('HDB009', 'Kh009', 'Nv009', '25000000', '04/27/2020')
INSERT INTO HoaDonBan (MaHDB, MaKH, MaNV, TongTien, ThoigianB)
VALUES ('HDB010', 'Kh010', 'Nv010', '14000000', '02/27/2021')
SELECT *FROM HoaDonBan

--*)Nhập dữ liệu vào bảng chi tiết hoá đơn bán
INSERT INTO ChiTietHDB(MaHDB, MaMT, Soluong, Giaban, TongTien)
VALUES ('HDB001', 'MT001', '1', '12800000', '12800000')
INSERT INTO ChiTietHDB (MaHDB, MaMT, Soluong, Giaban, TongTien)
VALUES ('HDB002', 'MT002', '1', '8500000', '8500000')
INSERT INTO ChiTietHDB (MaHDB, MaMT, Soluong, Giaban, TongTien)
VALUES ('HDB003', 'MT003', '2', '20500000', '41000000')
INSERT INTO ChiTietHDB (MaHDB, MaMT, Soluong, Giaban, TongTien)
VALUES ('HDB004', 'MT004', '2', '21500000', '43000000')
INSERT INTO ChiTietHDB (MaHDB, MaMT, Soluong, Giaban, TongTien)
VALUES ('HDB005', 'MT005', '1', '27000000', '27000000')
INSERT INTO ChiTietHDB (MaHDB, MaMT, Soluong, Giaban, TongTien)
VALUES ('HDB006', 'MT006','1', '18500000', '18500000')


INSERT INTO ChiTietHDB (MaHDB, MaMT, Soluong, Giaban, TongTien)
VALUES ('HDB007', 'MT007', '1', '13500000', '13500000')
INSERT INTO ChiTietHDB (MaHDB, MaMT, Soluong, Giaban, TongTien)
VALUES ('HDB008', 'MT008', '1', '128000000', '128000000')
INSERT INTO ChiTietHDB (MaHDB, MaMT, Soluong, Giaban, TongTien)
VALUES ('HDB009', 'MT009', '1', '20500000', '20500000')
INSERT INTO ChiTietHDB (MaHDB, MaMT, Soluong, Giaban, TongTien)
VALUES ('HDB010', 'MT010', '1', '21500000', '21500000')
SELECT *FROM ChiTietHDB


--*)Nhập dữ liệu vào bảng hoá đơn nhập
INSERT INTO HoaDonNhap (MaHDN, maNCC, MaNV, Tongtien, ThoigianN)
VALUES ('HDN001', 'Ncc001', 'Nv001',  '45000000', '04/10/2021')
INSERT INTO HoaDonNhap (MaHDN, maNCC, MaNV, Tongtien, ThoigianN)
VALUES ('HDN002', 'Ncc002', 'Nv002', '40000000', '03/11/2021')
INSERT INTO HoaDonNhap (MaHDN, maNCC, MaNV, Tongtien, ThoigianN)
VALUES ('HDN003', 'Ncc003', 'Nv003', '75000000', '09/09/2021')
INSERT INTO HoaDonNhap (MaHDN, maNCC, MaNV, Tongtien, ThoigianN)
VALUES ('HDN004', 'Ncc004', 'Nv004', '25000000', '04/04/2021')
INSERT INTO HoaDonNhap (MaHDN, maNCC, MaNV, Tongtien, ThoigianN)
VALUES ('HDN005', 'Ncc005', 'Nv005', '45000000', '08/08/2021')
INSERT INTO HoaDonNhap (MaHDN, maNCC, MaNV, Tongtien, ThoigianN)
VALUES ('HDN006', 'Ncc006', 'Nv006',  '30000000', '10/06/2021')
INSERT INTO HoaDonNhap (MaHDN, maNCC, MaNV, Tongtien, ThoigianN)
VALUES ('HDN007', 'Ncc007', 'Nv007',  '45000000', '10/10/2021')
INSERT INTO HoaDonNhap (MaHDN, maNCC, MaNV, Tongtien, ThoigianN)
VALUES ('HDN008', 'Ncc008', 'Nv008', '40000000','02/09/2021')
INSERT INTO HoaDonNhap (MaHDN, maNCC, MaNV, Tongtien, ThoigianN)
VALUES ('HDN009', 'Ncc009', 'Nv009',  '45000000', '07/07/2021')
INSERT INTO HoaDonNhap (MaHDN, maNCC, MaNV, Tongtien, ThoigianN)
VALUES ('HDN010', 'Ncc010', 'Nv010', '15000000', '12/12/2021')
SELECT *FROM HoaDonNhap


--*)Nhập dữ liệu vào bảng chi tiết hoá đơn nhập
INSERT INTO ChiTietHDN (MaHDN, MaMT, Soluong, Gianhap, Tongtien)
VALUES ('HDN001', 'MT001', '3', '15000000' , '45000000')
INSERT INTO ChiTietHDN (MaHDN, MaMT, Soluong, Gianhap, Tongtien)
VALUES ('HDN002', 'MT002', '2', '20000000' , '40000000')
INSERT INTO ChiTietHDN (MaHDN, MaMT, Soluong, Gianhap, Tongtien)
VALUES ('HDN003', 'MT003', '5', '15000000' , '75000000')
INSERT INTO ChiTietHDN (MaHDN, MaMT, Soluong, Gianhap, Tongtien)
VALUES ('HDN004', 'MT004', '1', '25000000' , '25000000')
INSERT INTO ChiTietHDN (MaHDN, MaMT, Soluong, Gianhap, Tongtien)
VALUES ('HDN005', 'MT005', '2', '25000000' , '5000000')
INSERT INTO ChiTietHDN (MaHDN, MaMT, Soluong, Gianhap, Tongtien)
VALUES ('HDN006', 'MT006', '2', '12000000' , '24000000')
INSERT INTO ChiTietHDN (MaHDN, MaMT, Soluong, Gianhap, Tongtien)
VALUES ('HDN007', 'MT007', '1', '19000000' , '19000000')
INSERT INTO ChiTietHDN (MaHDN, MaMT, Soluong, Gianhap, Tongtien)
VALUES ('HDN008', 'MT008', '4', '60000000' , '240000000')
INSERT INTO ChiTietHDN (MaHDN, MaMT, Soluong, Gianhap, Tongtien)
VALUES ('HDN009', 'MT009', '3', '15000000' , '45000000')
INSERT INTO ChiTietHDN (MaHDN, MaMT, Soluong, Gianhap, Tongtien)
VALUES ('HDN010', 'MT010', '2', '12000000' , '24000000')
SELECT *FROM ChiTietHDN

---Thủ tục thống kê bán:
CREATE PROC [dbo].[thongkeB]
@thoigian1 date,
@thoigian2 date
as
BEGIN
 SELECT H.MaHDB as [Mã HĐB],H.ThoigianB as[Ngày bán], COUNT(C.MaMT) as[Số máy tính bán],C.Giaban as [Giá bán],
 C.TongTien as [Thành tiền], SUM(C.Soluong*C.Giaban) as [Tổng tiền]
 FROM HoaDonBan H INNER JOIN ChiTietHDB C ON H.MaHDB=C.MaHDB INNER JOIN MayTinh A ON A.MaMT=C.MaMT
 WHERE ThoigianB between @thoigian1 and @thoigian2
 GROUP BY  H.MaHDB, H.ThoigianB,C.Giaban,C.TongTien
END


---Thủ tục thống kê nhập:
CREATE PROC [dbo].[thongkeN]
@thoigian1 date,
@thoigian2 date
as
BEGIN
 SELECT H.MaHDN as [HĐN],H.ThoigianN as[Ngày nhập], COUNT(C.MaMT) as[Số Máy tính nhập],C.Gianhap as [Giá nhập],
 C.Tongtien as [Thành tiền], SUM(C.Soluong*C.Gianhap) as [Tổng tiền]
 FROM HoaDonNhap H INNER JOIN ChiTietHDN C ON H.MaHDN=C.MaHDN INNER JOIN MayTinh A ON A.MaMT=C.MaMT
 WHERE ThoigianN between @thoigian1 and @thoigian2
 GROUP BY  H.MaHDN, H.ThoigianN,C.Gianhap,C.Tongtien
END


-----Tạo trigger để tự động giảm số lượng còn trong bảng MayTinh mỗi khi thêm mới dữ liệu trong bảng CTHDB:
--CREATE TRIGGER T_CNSL ON ChiTietHDB
--FOR INSERT 
--AS
--BEGIN
--  DECLARE @soluongcon int
--  DECLARE @soluongban int
--  SELECT @soluongban=inserted.Soluong FROM inserted
--  SELECT @soluongcon=dbo.MayTinh.Soluong FROM inserted, MayTinh WHERE inserted.MaMT=MayTinh.MaMT
--  IF(@soluongban>@soluongcon)
--    BEGIN
--	  RAISERROR('loi',16,1)
--	  ROLLBACK TRAN
--	END
--  ELSE
--    BEGIN
--	  UPDATE MayTinh SET MayTinh.Soluong=MayTinh.Soluong-@soluongban
--	  FROM MayTinh, inserted WHERE inserted.MaMT=MayTinh.MaMT
--	END
--END


-----Tạo trigger để tự động tăng số lượng trong bảng MayTinh mỗi khi thêm mới dữ liệu trong bảng CTHDN:
--CREATE TRIGGER T_CNG ON ChiTietHDN
--FOR INSERT 
--AS
--BEGIN
--  DECLARE @soluongcon int
--  DECLARE @soluongnhap int
--  SELECT @soluongnhap=inserted.Soluong FROM inserted
--  SELECT @soluongcon=dbo.MayTinh.Soluong FROM inserted, MayTinh WHERE inserted.MaMT=MayTinh.MaMT
--  IF(@soluongcon>500)
--    BEGIN
--	  PRINT N'Số lượng máy tính này đã vượt quá 500 chiếc trong kho'
--	  ROLLBACK TRAN
--	END
--  ELSE
--    BEGIN
--	  UPDATE MayTinh SET MayTinh.Soluong=MayTinh.Soluong+@soluongnhap
--	  FROM MayTinh, inserted WHERE inserted.MaMT=MayTinh.MaMT
--	END
--END
