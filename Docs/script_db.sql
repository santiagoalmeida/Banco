USE [master]
GO
/****** Object:  Database [dbBanco]    Script Date: 12/12/2022 2:13:53 ******/
CREATE DATABASE [dbBanco]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbBanco', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbBanco.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbBanco_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbBanco_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbBanco] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbBanco].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbBanco] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbBanco] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbBanco] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbBanco] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbBanco] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbBanco] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [dbBanco] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbBanco] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbBanco] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbBanco] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbBanco] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbBanco] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbBanco] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbBanco] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbBanco] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbBanco] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbBanco] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbBanco] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbBanco] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbBanco] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbBanco] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [dbBanco] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbBanco] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbBanco] SET  MULTI_USER 
GO
ALTER DATABASE [dbBanco] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbBanco] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbBanco] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbBanco] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbBanco] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbBanco] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbBanco] SET QUERY_STORE = OFF
GO
USE [dbBanco]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/12/2022 2:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 12/12/2022 2:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[NumeroCuenta] [nvarchar](8) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[TipoCuenta] [int] NOT NULL,
	[SaldoInicial] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[NumeroCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 12/12/2022 2:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[IdMovimiento] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[TipoMovimiento] [int] NOT NULL,
	[Valor] [int] NOT NULL,
	[NumeroCuenta] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_cliente]    Script Date: 12/12/2022 2:13:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Contrasena] [nvarchar](16) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Genero] [int] NOT NULL,
	[Edad] [int] NOT NULL,
	[Identificacion] [nvarchar](15) NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tbl_cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220712064342_InitialMigration', N'6.0.6')
GO
INSERT [dbo].[Cuentas] ([NumeroCuenta], [IdCliente], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (N'225487', 5, 0, 100, 1)
INSERT [dbo].[Cuentas] ([NumeroCuenta], [IdCliente], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (N'478758', 4, 1, 2000, 1)
INSERT [dbo].[Cuentas] ([NumeroCuenta], [IdCliente], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (N'495878', 6, 1, 0, 1)
INSERT [dbo].[Cuentas] ([NumeroCuenta], [IdCliente], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (N'496825', 5, 1, 540, 1)
INSERT [dbo].[Cuentas] ([NumeroCuenta], [IdCliente], [TipoCuenta], [SaldoInicial], [Estado]) VALUES (N'585545', 4, 0, 1000, 1)
GO
SET IDENTITY_INSERT [dbo].[Movimientos] ON 

INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [TipoMovimiento], [Valor], [NumeroCuenta]) VALUES (1, CAST(N'2022-07-12T03:23:43.8894610' AS DateTime2), 1, 2000, N'478758')
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [TipoMovimiento], [Valor], [NumeroCuenta]) VALUES (2, CAST(N'2022-07-12T03:24:25.6835031' AS DateTime2), 1, 100, N'225487')
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [TipoMovimiento], [Valor], [NumeroCuenta]) VALUES (3, CAST(N'2022-07-12T03:24:50.1934380' AS DateTime2), 1, 0, N'495878')
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [TipoMovimiento], [Valor], [NumeroCuenta]) VALUES (4, CAST(N'2022-07-12T03:25:13.3057920' AS DateTime2), 1, 540, N'496825')
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [TipoMovimiento], [Valor], [NumeroCuenta]) VALUES (5, CAST(N'2022-07-12T03:26:23.7197070' AS DateTime2), 1, 100, N'585545')
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [TipoMovimiento], [Valor], [NumeroCuenta]) VALUES (6, CAST(N'2022-07-12T03:51:00.0000000' AS DateTime2), 0, -575, N'478758')
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [TipoMovimiento], [Valor], [NumeroCuenta]) VALUES (8, CAST(N'2022-07-12T04:17:00.0000000' AS DateTime2), 1, 600, N'225487')
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [TipoMovimiento], [Valor], [NumeroCuenta]) VALUES (9, CAST(N'2022-07-12T04:19:00.0000000' AS DateTime2), 1, 150, N'495878')
INSERT [dbo].[Movimientos] ([IdMovimiento], [Fecha], [TipoMovimiento], [Valor], [NumeroCuenta]) VALUES (10, CAST(N'2022-07-12T04:20:00.0000000' AS DateTime2), 0, -540, N'496825')
SET IDENTITY_INSERT [dbo].[Movimientos] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_cliente] ON 

INSERT [dbo].[tbl_cliente] ([IdCliente], [Contrasena], [Estado], [Nombres], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (4, N'1234', 1, N'Jose Lema', 0, 35, N'098254785', N'Otavalo sn y principal', N'098254785')
INSERT [dbo].[tbl_cliente] ([IdCliente], [Contrasena], [Estado], [Nombres], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (5, N'5678', 1, N'Marianela Montalvo', 1, 41, N'097548965', N'Amazonas y NNUU ', N'097548965')
INSERT [dbo].[tbl_cliente] ([IdCliente], [Contrasena], [Estado], [Nombres], [Genero], [Edad], [Identificacion], [Direccion], [Telefono]) VALUES (6, N'1245', 1, N'Juan Osorio ', 0, 28, N'098874587', N'13 junio y Equinoccial', N'098874587')
SET IDENTITY_INSERT [dbo].[tbl_cliente] OFF
GO
/****** Object:  Index [IX_Cuentas_IdCliente]    Script Date: 12/12/2022 2:13:54 ******/
CREATE NONCLUSTERED INDEX [IX_Cuentas_IdCliente] ON [dbo].[Cuentas]
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Movimientos_NumeroCuenta]    Script Date: 12/12/2022 2:13:54 ******/
CREATE NONCLUSTERED INDEX [IX_Movimientos_NumeroCuenta] ON [dbo].[Movimientos]
(
	[NumeroCuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_tbl_cliente_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[tbl_cliente] ([IdCliente])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_tbl_cliente_IdCliente]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuentas_NumeroCuenta] FOREIGN KEY([NumeroCuenta])
REFERENCES [dbo].[Cuentas] ([NumeroCuenta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuentas_NumeroCuenta]
GO
USE [master]
GO
ALTER DATABASE [dbBanco] SET  READ_WRITE 
GO
