CREATE DATABASE [QL_GVHS_THPT]
GO

USE [QL_GVHS_THPT]
GO

-- Tạo bảng tblPhanQuyen
IF OBJECT_ID('dbo.tblPhanQuyen', 'U') IS NOT NULL
 DROP TABLE [dbo].[tblPhanQuyen]
GO
CREATE TABLE [dbo].[tblPhanQuyen] 
( 
	[MaQuyen] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[TenQuyen] [nvarchar](50) NOT NULL
)
ON [PRIMARY]
GO
-- Tạo bảng tblUser
IF OBJECT_ID('dbo.tblUser', 'U') IS NOT NULL
 DROP TABLE [dbo].[tblUser]
GO
CREATE TABLE [dbo].[tblUser] 
( 
	[Username] [varchar](50) PRIMARY KEY NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[MaGV] [varchar](10) NULL,
	[MaQuyen] [int] NOT NULL REFERENCES tblPhanQuyen(MaQuyen)
)
ON [PRIMARY]
GO

INSERT [dbo].[tblPhanquyen] ([TenQuyen]) VALUES (N'Administrator')
INSERT [dbo].[tblPhanquyen] ([TenQuyen]) VALUES (N'Hiệu Trưởng')
INSERT [dbo].[tblPhanquyen] ([TenQuyen]) VALUES (N'Giáo Viên')
INSERT [dbo].[tblPhanquyen] ([TenQuyen]) VALUES (N'Học Sinh')

INSERT [dbo].[tblUser] ([Username], [Password], [MaGV], [MaQuyen]) VALUES (N'admin', N'123456', N'', 1)
INSERT [dbo].[tblUser] ([Username], [Password], [MaGV], [MaQuyen]) VALUES (N'phanhuydung', N'123456', N'', 4)
INSERT [dbo].[tblUser] ([Username], [Password], [MaGV], [MaQuyen]) VALUES (N'headteacher', N'123456', N'', 2)
INSERT [dbo].[tblUser] ([Username], [Password], [MaGV], [MaQuyen]) VALUES (N'teacher', N'123456', N'', 3)


-- Tạo bảng tblMonHoc
IF OBJECT_ID('dbo.tblMonHoc', 'U') IS NOT NULL
 DROP TABLE [dbo].[tblMonHoc]
GO
CREATE TABLE [dbo].[tblMonHoc] 
( 
	[MaMon] [INT] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[TenMon] [nvarchar](50) NULL
)
ON [PRIMARY]
GO
-- Tạo bảng tblGiaoVien
IF OBJECT_ID('dbo.tblGiaoVien', 'U') IS NOT NULL
 DROP TABLE [dbo].[tblGiaoVien]
GO
CREATE TABLE [dbo].[tblGiaoVien] 
( 
	[MaGV] [INT] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[GT] [nvarchar](11) NULL,
	[NgaySinh] [date] NULL,
	[SDT] [varchar](11) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[Luong] [int] NULL,
	[MaMon] [INT] REFERENCES tblMonHoc(MaMon)
)
ON [PRIMARY]
GO

INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Toán học')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Ngữ văn')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Anh văn')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Hóa học')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Vật lý')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Sinh học')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Tin học')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Địa lý')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'GDCD')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Thể dục')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Công nghệ')
INSERT [dbo].[tblMonhoc] ([TenMon]) VALUES (N'Lịch sử')


INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Phạm Văn Công', N'Nam', '1980-11-11', N'0168904569', N'Diễn Đồng, Diễn Châu, Nghệ An', 7000000, 1)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Nguyễn Duy Hùng', N'Nam', '1981-12-12', N'', N'Bắc Giang', 4000000, 2)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Lê Vũ Minh Quân', N'Nam', '1980-10-10', N'091232323', N'Bến Tre', 3500000, 3)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Lê Thị Quỳnh Nga', N'Nữ', '1984-09-09', N'987654321', N'Ngũ Hành Sơn, Đà Nẵng', 7500000, 4)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Hoàng Thùy Linh', N'Nữ', '1982-08-08', N'098983092', N'Hà Nội', 3000000, 5)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Phạm Văn Công', N'Nam', '1980-07-07', N'01689045691', N'Diễn Đồng, Diễn Châu, Nghệ An', 7000000, 1)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Trần Mạnh Linh', N'Nam', '1980-06-06', N'01234567898', N'Tây Tiến, Tiền Hải, Thái Bình', 6500000, 2)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Nguyễn Duy Hùng', N'Nam', '1983-05-05', N'091232323', N'Cầu Gồ, Yên Thế, Bắc Giang', 8000000, 3)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Nguyễn Thanh Hà', N'Nữ', '1980-04-04', N'01234567890', N'Cầu Giấy, Hà Nội',10000000,6)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Nguyễn Thị Hải', N'Nữ',	'1980-03-03', N'01234567891', N'Thái Bình', 11000000,7)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Nguyễn Minh Khai', N'Nam', '1980-02-02', N'01234567892', N'Thái Nguyên', 9000000, 8)
INSERT [dbo].[tblGiaovien] ([HoTen], [GT], [NgaySinh], [SDT], [DiaChi], [Luong], [MaMon]) VALUES (N'Trần Thái Binh', N'Nam', '1980-01-01', N'01234567893', N'Hải Phòng', 8500000, 1)

-- Tạo bảng tblLop
IF OBJECT_ID('dbo.tblLop', 'U') IS NOT NULL
 DROP TABLE [dbo].[tblLop]
GO
CREATE TABLE [dbo].[tblLop] 
( 
	[MaLop] [INT] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[TenLop] [nvarchar](50) NOT NULL,
	[NienKhoa] [INT] NOT NULL,
	[GVCN] [INT] REFERENCES tblGiaoVien(MaGV),
	[SiSo] [INT] NOT NULL
)
ON [PRIMARY]
GO
-- Tạo bảng tblHocSinh
IF OBJECT_ID('dbo.tblHocSinh', 'U') IS NOT NULL
 DROP TABLE [dbo].[tblHocSinh]
GO
CREATE TABLE [dbo].[tblHocSinh] 
( 
	[MaHS] [INT] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[GT] [nvarchar](11) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DanToc] [nvarchar](50) NULL,
	[TonGiao] [nvarchar](50) NULL,
	[MaLop] [INT] REFERENCES tblLop(MaLop)
)
ON [PRIMARY]
GO

INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'10A1', 51,1,40)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'10A2', 51,2,41)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'10A3', 51,3,42)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'10A4', 51,4,43)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'11A1', 50,5,44)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'11A2', 51,6,45)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'11A3', 51,7,46)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'11A4', 51,8,47)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'12A1', 52,9,48)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'12A2', 52,10,49)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'12A3', 52,11,50)
INSERT [dbo].[tblLop] ([TenLop], [NienKhoa], [GVCN], [SiSo]) VALUES (N'12A4', 52,12,51)

INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Phạm Quang Vẹo', N'Nữ', '1996-01-01', N'Thanh Hóa', N'Kinh', N'Không', 1)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Duy Hùng', N'Nam', '1996-02-01', N'Bắc Giang', N'Tày', N'Phật giáo', 1)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Trần Mạnh Linh', N'Nam', '1996-03-01', N'Thái Bình', N'Nùng', N'Kito giáo', 1)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Lê Vũ Minh Quân', N'Nam', '1996-04-01', N'Bến Tre', N'Kinh', N'Không', 1)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn A', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 1)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn B', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 1)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn C', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 1)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn D', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 1)

INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn E', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn F', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn G', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn H', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn I', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn J', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn K', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn L', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn M', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn N', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn O', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)
INSERT [dbo].[tblHocSinh] ([HoTen], [GT], [NgaySinh], [DiaChi], [DanToc], [TonGiao], [MaLop]) VALUES (N'Nguyễn Văn D', N'Nam', '1996-04-01', N'Hà Nội', N'Kinh', N'Không', 2)

-- Tạo bảng tblGiangDay
IF OBJECT_ID('dbo.tblGiangDay', 'U') IS NOT NULL
 DROP TABLE [dbo].[tblGiangDay]
GO
CREATE TABLE [dbo].[tblGiangDay] 
( 
	[MaGV] [INT] NOT NULL REFERENCES tblGiaoVien(MaGV),
	[MaLop] [INT] NOT NULL REFERENCES tblLop(maLop),
	[Thu] [NVARCHAR](20) NOT NULL ,
	PRIMARY KEY([MaGV],[MaLop],[Thu]),
	[TietBD] [int] NULL,
	[TietKT] [int] NULL
)
ON [PRIMARY]
GO

INSERT [dbo].[tblGiangday] ([MaGV], [MaLop], [Thu], [TietBD], [TietKT]) VALUES (1, 1, N'THỨ HAI', 1, 2)
INSERT [dbo].[tblGiangday] ([MaGV], [MaLop], [Thu], [TietBD], [TietKT]) VALUES (2, 2, N'THỨ BA', 2, 3)
INSERT [dbo].[tblGiangday] ([MaGV], [MaLop], [Thu], [TietBD], [TietKT]) VALUES (3, 3, N'THỨ TƯ', 3, 3)
INSERT [dbo].[tblGiangday] ([MaGV], [MaLop], [Thu], [TietBD], [TietKT]) VALUES (4, 4, N'THỨ NĂM', 4, 5)
INSERT [dbo].[tblGiangday] ([MaGV], [MaLop], [Thu], [TietBD], [TietKT]) VALUES (1, 1, N'THỨ SÁU', 5, 6)
INSERT [dbo].[tblGiangday] ([MaGV], [MaLop], [Thu], [TietBD], [TietKT]) VALUES (2, 3, N'THỨ HAI', 1, 2)
INSERT [dbo].[tblGiangday] ([MaGV], [MaLop], [Thu], [TietBD], [TietKT]) VALUES (4, 3, N'THỨ BA', 4, 5)
INSERT [dbo].[tblGiangday] ([MaGV], [MaLop], [Thu], [TietBD], [TietKT]) VALUES (5, 5, N'THỨ TƯ', 1,2)


USE [master]
GO
ALTER DATABASE [QL_GV_HS_THPT] SET  READ_WRITE 
GO