USE [master]
GO
/****** Object:  Database [PBL3_1]    Script Date: 4/23/2023 12:59:08 PM ******/
CREATE DATABASE [PBL3_1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PBL3_1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PBL3_1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PBL3_1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PBL3_1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PBL3_1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PBL3_1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PBL3_1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PBL3_1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PBL3_1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PBL3_1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PBL3_1] SET ARITHABORT OFF 
GO
ALTER DATABASE [PBL3_1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PBL3_1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PBL3_1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PBL3_1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PBL3_1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PBL3_1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PBL3_1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PBL3_1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PBL3_1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PBL3_1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PBL3_1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PBL3_1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PBL3_1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PBL3_1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PBL3_1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PBL3_1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PBL3_1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PBL3_1] SET RECOVERY FULL 
GO
ALTER DATABASE [PBL3_1] SET  MULTI_USER 
GO
ALTER DATABASE [PBL3_1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PBL3_1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PBL3_1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PBL3_1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PBL3_1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PBL3_1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PBL3_1', N'ON'
GO
ALTER DATABASE [PBL3_1] SET QUERY_STORE = OFF
GO
USE [PBL3_1]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 4/23/2023 12:59:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID_Bill] [varchar](50) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[TransactionTime] [datetime] NOT NULL,
	[TotalBill] [int] NULL,
	[ID_Staff] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Bill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailBill]    Script Date: 4/23/2023 12:59:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailBill](
	[ID_DetailBill] [varchar](50) NOT NULL,
	[ID_Product] [varchar](50) NOT NULL,
	[NSX] [date] NOT NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailOrder]    Script Date: 4/23/2023 12:59:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailOrder](
	[ID_Order] [varchar](50) NOT NULL,
	[ID_Product] [varchar](50) NOT NULL,
	[NSX] [date] NOT NULL,
	[Quantity] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguyenLieu]    Script Date: 4/23/2023 12:59:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguyenLieu](
	[ID_NguyenLieu] [varchar](50) NOT NULL,
	[TenNguyenLieu] [nvarchar](50) NULL,
	[Soluong] [int] NULL,
	[LoHang] [nvarchar](50) NULL,
	[NoiCungCap] [nvarchar](50) NULL,
	[HanSuDung] [date] NOT NULL,
	[ID_Staff] [varchar](50) NOT NULL,
	[NgayNhapKho] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_NguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orderr]    Script Date: 4/23/2023 12:59:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orderr](
	[ID_Order] [varchar](50) NOT NULL,
	[ID_Staff] [varchar](50) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Shipper] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/23/2023 12:59:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID_Product] [varchar](50) NOT NULL,
	[Product_Name] [nvarchar](50) NULL,
	[NSX] [date] NOT NULL,
	[HSD] [date] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC,
	[NSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 4/23/2023 12:59:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[ID_Staff] [varchar](50) NOT NULL,
	[Staff_Name] [nvarchar](50) NULL,
	[BirthDay] [date] NULL,
	[Sex] [nvarchar](50) NULL,
	[CCCD] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Shift] [nvarchar](50) NULL,
	[Salary] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/23/2023 12:59:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
	[Role] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Bill] ([ID_Bill], [CustomerName], [PhoneNumber], [TransactionTime], [TotalBill], [ID_Staff]) VALUES (N'210423001', N'', N'', CAST(N'2023-04-21T00:00:00.000' AS DateTime), 116000, N'NV10001')
INSERT [dbo].[Bill] ([ID_Bill], [CustomerName], [PhoneNumber], [TransactionTime], [TotalBill], [ID_Staff]) VALUES (N'210423002', N'', N'', CAST(N'2023-04-21T00:00:00.000' AS DateTime), 110000, N'NV10001')
GO
INSERT [dbo].[DetailBill] ([ID_DetailBill], [ID_Product], [NSX], [Quantity]) VALUES (N'210423001', N'10001', CAST(N'2023-03-04' AS Date), 2)
INSERT [dbo].[DetailBill] ([ID_DetailBill], [ID_Product], [NSX], [Quantity]) VALUES (N'210423001', N'10003', CAST(N'2023-04-21' AS Date), 2)
INSERT [dbo].[DetailBill] ([ID_DetailBill], [ID_Product], [NSX], [Quantity]) VALUES (N'210423001', N'10007', CAST(N'2023-04-21' AS Date), 2)
INSERT [dbo].[DetailBill] ([ID_DetailBill], [ID_Product], [NSX], [Quantity]) VALUES (N'210423002', N'10001', CAST(N'2023-03-04' AS Date), 5)
INSERT [dbo].[DetailBill] ([ID_DetailBill], [ID_Product], [NSX], [Quantity]) VALUES (N'210423002', N'10007', CAST(N'2023-04-21' AS Date), 2)
GO
INSERT [dbo].[NguyenLieu] ([ID_NguyenLieu], [TenNguyenLieu], [Soluong], [LoHang], [NoiCungCap], [HanSuDung], [ID_Staff], [NgayNhapKho]) VALUES (N'ID10001', N'Tương ớt', 50, N'2023-04-01', N'Winmart+', CAST(N'2025-05-04' AS Date), N'NV10001', CAST(N'2023-04-02' AS Date))
INSERT [dbo].[NguyenLieu] ([ID_NguyenLieu], [TenNguyenLieu], [Soluong], [LoHang], [NoiCungCap], [HanSuDung], [ID_Staff], [NgayNhapKho]) VALUES (N'ID10002', N'Xì dầu', 20, N'2023-04-01', N'Winmart+', CAST(N'2025-05-04' AS Date), N'NV10001', CAST(N'2021-04-02' AS Date))
INSERT [dbo].[NguyenLieu] ([ID_NguyenLieu], [TenNguyenLieu], [Soluong], [LoHang], [NoiCungCap], [HanSuDung], [ID_Staff], [NgayNhapKho]) VALUES (N'ID10003', N'Rau Salad', 15, N'2023-05-04', N'Winmart+', CAST(N'2023-05-04' AS Date), N'NV10001', CAST(N'2023-05-02' AS Date))
INSERT [dbo].[NguyenLieu] ([ID_NguyenLieu], [TenNguyenLieu], [Soluong], [LoHang], [NoiCungCap], [HanSuDung], [ID_Staff], [NgayNhapKho]) VALUES (N'ID10004', N'Thịt bò', 50, N'2023-04-01', N'Winmart+', CAST(N'2023-04-02' AS Date), N'NV10001', CAST(N'2023-04-11' AS Date))
INSERT [dbo].[NguyenLieu] ([ID_NguyenLieu], [TenNguyenLieu], [Soluong], [LoHang], [NoiCungCap], [HanSuDung], [ID_Staff], [NgayNhapKho]) VALUES (N'ID10005', N'Thịt lợn', 15, N'2023-04-01', N'Winmart+', CAST(N'2023-04-02' AS Date), N'NV10001', CAST(N'2023-04-11' AS Date))
INSERT [dbo].[NguyenLieu] ([ID_NguyenLieu], [TenNguyenLieu], [Soluong], [LoHang], [NoiCungCap], [HanSuDung], [ID_Staff], [NgayNhapKho]) VALUES (N'ID10006', N'Thịt gà', 15, N'2023-04-01', N'Winmart+', CAST(N'2023-04-02' AS Date), N'NV10001', CAST(N'2023-04-11' AS Date))
INSERT [dbo].[NguyenLieu] ([ID_NguyenLieu], [TenNguyenLieu], [Soluong], [LoHang], [NoiCungCap], [HanSuDung], [ID_Staff], [NgayNhapKho]) VALUES (N'ID10007', N'Xúc xích', 20, N'2023-04-01', N'Winmart+', CAST(N'2023-04-04' AS Date), N'NV10001', CAST(N'2024-04-02' AS Date))
INSERT [dbo].[NguyenLieu] ([ID_NguyenLieu], [TenNguyenLieu], [Soluong], [LoHang], [NoiCungCap], [HanSuDung], [ID_Staff], [NgayNhapKho]) VALUES (N'ID10008', N'Thịt lợn xông khói', 20, N'2023-04-01', N'Winmart+', CAST(N'2025-04-04' AS Date), N'NV10001', CAST(N'2023-05-02' AS Date))
INSERT [dbo].[NguyenLieu] ([ID_NguyenLieu], [TenNguyenLieu], [Soluong], [LoHang], [NoiCungCap], [HanSuDung], [ID_Staff], [NgayNhapKho]) VALUES (N'ID10009', N'Tương ớt', 50, N'2023-04-01', N'Winmart+', CAST(N'2025-05-04' AS Date), N'NV10001', CAST(N'2023-04-02' AS Date))
GO
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10001', N'Bánh mì', CAST(N'2023-03-04' AS Date), CAST(N'2023-04-04' AS Date), 39, 8000)
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10002', N'Bánh mì thập cẩm', CAST(N'2023-04-21' AS Date), CAST(N'2023-04-23' AS Date), 30, 15000)
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10003', N'Bánh mì trứng', CAST(N'2023-04-21' AS Date), CAST(N'2023-04-23' AS Date), 18, 15000)
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10004', N'Bánh mì chả', CAST(N'2023-04-04' AS Date), CAST(N'2023-04-10' AS Date), 48, 15000)
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10005', N'Bánh bao kim sa', CAST(N'2023-04-21' AS Date), CAST(N'2023-04-30' AS Date), 20, 25000)
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10006', N'Bánh mì C1', CAST(N'2023-04-21' AS Date), CAST(N'2023-05-10' AS Date), 10, 35000)
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10007', N'Bánh mì C2', CAST(N'2023-04-21' AS Date), CAST(N'2023-05-10' AS Date), 6, 35000)
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10008', N'Bánh mì Pháp', CAST(N'2023-04-21' AS Date), CAST(N'2023-06-10' AS Date), 20, 55000)
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10009', N'Bánh mì Croissant ', CAST(N'2023-04-21' AS Date), CAST(N'2023-04-28' AS Date), 18, 25000)
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10010', N'Bánh mì Baguette', CAST(N'2023-04-21' AS Date), CAST(N'2023-04-27' AS Date), 48, 18000)
INSERT [dbo].[Product] ([ID_Product], [Product_Name], [NSX], [HSD], [Quantity], [Price]) VALUES (N'10011', N'Bánh mì thịt ', CAST(N'2023-04-04' AS Date), CAST(N'2023-04-05' AS Date), 28, 15000)
GO
INSERT [dbo].[Staff] ([ID_Staff], [Staff_Name], [BirthDay], [Sex], [CCCD], [PhoneNumber], [Address], [Shift], [Salary]) VALUES (N'NV10001', N'Trần Minh Quân', CAST(N'2003-08-05' AS Date), N'nam', N'123456789', N'0948628477', N'Ðà Nẵng', N'Chiều', 2000000)
INSERT [dbo].[Staff] ([ID_Staff], [Staff_Name], [BirthDay], [Sex], [CCCD], [PhoneNumber], [Address], [Shift], [Salary]) VALUES (N'NV10002', N'Trương Lê Quốc Minh', CAST(N'2003-04-30' AS Date), N'Nữ', N'123456788', N'0123456789', N'Đà Nẵng', N'Sáng', 2000000)
INSERT [dbo].[Staff] ([ID_Staff], [Staff_Name], [BirthDay], [Sex], [CCCD], [PhoneNumber], [Address], [Shift], [Salary]) VALUES (N'NV10003', N'Đặng Ngọc Khánh', CAST(N'2002-01-01' AS Date), N'Nam', N'123456787', N'0123456784', N'Đà Nẵng', N'Sáng', 2000000)
INSERT [dbo].[Staff] ([ID_Staff], [Staff_Name], [BirthDay], [Sex], [CCCD], [PhoneNumber], [Address], [Shift], [Salary]) VALUES (N'NV10004', N'Nguyễn Đức Thắng', CAST(N'2003-01-01' AS Date), N'nam', N'987654321', N'0987654321', N'Đà Nẵng', N'Chiều', 2000000)
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([ID_Staff])
REFERENCES [dbo].[Staff] ([ID_Staff])
GO
ALTER TABLE [dbo].[DetailBill]  WITH CHECK ADD FOREIGN KEY([ID_DetailBill])
REFERENCES [dbo].[Bill] ([ID_Bill])
GO
ALTER TABLE [dbo].[DetailBill]  WITH CHECK ADD FOREIGN KEY([ID_Product], [NSX])
REFERENCES [dbo].[Product] ([ID_Product], [NSX])
GO
ALTER TABLE [dbo].[DetailOrder]  WITH CHECK ADD FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Orderr] ([ID_Order])
GO
ALTER TABLE [dbo].[DetailOrder]  WITH CHECK ADD FOREIGN KEY([ID_Product], [NSX])
REFERENCES [dbo].[Product] ([ID_Product], [NSX])
GO
ALTER TABLE [dbo].[NguyenLieu]  WITH CHECK ADD FOREIGN KEY([ID_Staff])
REFERENCES [dbo].[Staff] ([ID_Staff])
GO
ALTER TABLE [dbo].[Orderr]  WITH CHECK ADD FOREIGN KEY([ID_Staff])
REFERENCES [dbo].[Staff] ([ID_Staff])
GO
/****** Object:  StoredProcedure [dbo].[addStaff]    Script Date: 4/23/2023 12:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[addStaff]
	@id varchar(50), @name nvarchar(50), @birth date, @sex nvarchar(50), @cccd varchar(50), @sdt varchar(50), @address nvarchar(50), @shift nvarchar(50), @salary int
as 
begin
	insert into Staff values(@id, @name, @birth, @sex, @cccd, @sdt, @address, @shift, @salary)
end
GO
/****** Object:  StoredProcedure [dbo].[CapNhatTTNhanVien]    Script Date: 4/23/2023 12:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CapNhatTTNhanVien]
	@id varchar(50), @name nvarchar(50), @birth date, @sex nvarchar(50), @cccd varchar(50), @sdt varchar(50), @address nvarchar(50), @shift nvarchar(50), @salary int
as
begin 
	update Staff
	set Staff_Name = @name, BirthDay = @birth, Sex = @sex, CCCD = @cccd, PhoneNumber = @sdt, Address = @address, Shift = @shift, Salary = @salary
	where ID_Staff = @id
end
GO
/****** Object:  StoredProcedure [dbo].[ThemNguyenLieu]    Script Date: 4/23/2023 12:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemNguyenLieu]
	@id varchar(50), @tenNL nvarchar(50), @soluong int, @loHang nvarchar(50), @noiCC nvarchar(50), @ngayNhap date, @hsd date, @idNV varchar(50) 
as 
begin 
	insert into NguyenLieu values(@id, @tenNL, @soluong, @loHang, @noiCC, @hsd, @idNV, @ngayNhap) 
end
GO
USE [master]
GO
ALTER DATABASE [PBL3_1] SET  READ_WRITE 
GO
