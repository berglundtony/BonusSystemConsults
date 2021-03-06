USE [master]
GO
/****** Object:  Database [ConsultBonusSystemDB]    Script Date: 2019-05-07 20:18:18 ******/
CREATE DATABASE [ConsultBonusSystemDB]
GO
ALTER DATABASE [ConsultBonusSystemDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ConsultBonusSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ConsultBonusSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ConsultBonusSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ConsultBonusSystemDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ConsultBonusSystemDB', N'ON'
GO
USE [ConsultBonusSystemDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2019-05-07 20:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[Bonus]    Script Date: 2019-05-07 20:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bonus](
	[BonusID] [int] IDENTITY(1,1) NOT NULL,
	[ConsultID] [int] NOT NULL,
	[ChargedHours] [int] NOT NULL,
	[ChargedHoursWithBonus] [int] NOT NULL,
	[BonusPot] [decimal](18, 0) NOT NULL,
	[NetResult] [int] NOT NULL,
	[PeriodOfEmployment] [int] NULL,
	[BonusDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_BonusID] PRIMARY KEY CLUSTERED 
(
	[BonusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consults]    Script Date: 2019-05-07 20:18:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consults](
	[ConsultID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[EmploymentDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Consults] PRIMARY KEY CLUSTERED 
(
	[ConsultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bonus] ON 
GO
INSERT [dbo].[Bonus] ([BonusID], [ConsultID], [ChargedHours], [ChargedHoursWithBonus], [BonusPot], [NetResult], [PeriodOfEmployment], [BonusDate]) VALUES (60, 6, 150, 195, CAST(5000 AS Decimal(18, 0)), 100000, 3, CAST(N'2019-05-06T10:51:46.0072461' AS DateTime2))
GO
INSERT [dbo].[Bonus] ([BonusID], [ConsultID], [ChargedHours], [ChargedHoursWithBonus], [BonusPot], [NetResult], [PeriodOfEmployment], [BonusDate]) VALUES (79, 9, 160, 176, CAST(5000 AS Decimal(18, 0)), 100000, 1, CAST(N'2019-05-07T19:48:55.7047627' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Bonus] OFF
GO
SET IDENTITY_INSERT [dbo].[Consults] ON 
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (6, N'Gudrun', N'Skylman', CAST(N'2016-04-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (7, N'Per', N'Centerkvist', CAST(N'2017-04-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (8, N'Henrik', N'Rydén', CAST(N'2014-04-22T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (9, N'Kurt ', N'Olsson', CAST(N'2018-04-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (10, N'Lars', N'Winnerbäck', CAST(N'2011-04-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (11, N'Ulf', N'Svensson', CAST(N'2015-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (12, N'Göran', N'Svensson', CAST(N'2013-03-31T22:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (14, N'Janne', N'Chaffer', CAST(N'2014-05-30T22:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (15, N'Göran', N'Sölscher', CAST(N'2015-05-30T22:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (16, N'Roland', N'Regamey', CAST(N'2016-05-12T22:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (19, N'Jesper', N'Grankvist', CAST(N'2018-05-01T22:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (22, N'Stefan', N'Olsson', CAST(N'2017-04-30T22:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (23, N'Johnny', N'Rocker', CAST(N'2016-04-30T22:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (24, N'Anna', N'Book', CAST(N'2012-04-30T22:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (25, N'Tony', N'Berglund', CAST(N'2016-04-30T22:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (26, N'Ragnar', N'Andersson', CAST(N'2010-04-30T22:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Consults] ([ConsultID], [FirstName], [LastName], [EmploymentDate]) VALUES (27, N'Anna', N'Högberg', CAST(N'2015-05-30T22:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Consults] OFF
GO
USE [master]
GO
ALTER DATABASE [ConsultBonusSystemDB] SET  READ_WRITE 
GO
