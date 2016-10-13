USE [master]
GO
/****** Object:  Database [FortuneTeller]    Script Date: 10/13/2016 2:06:59 PM ******/
CREATE DATABASE [FortuneTeller]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FortuneTeller', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\FortuneTeller.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FortuneTeller_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\FortuneTeller_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FortuneTeller] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FortuneTeller].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FortuneTeller] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FortuneTeller] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FortuneTeller] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FortuneTeller] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FortuneTeller] SET ARITHABORT OFF 
GO
ALTER DATABASE [FortuneTeller] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FortuneTeller] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FortuneTeller] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FortuneTeller] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FortuneTeller] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FortuneTeller] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FortuneTeller] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FortuneTeller] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FortuneTeller] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FortuneTeller] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FortuneTeller] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FortuneTeller] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FortuneTeller] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FortuneTeller] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FortuneTeller] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FortuneTeller] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FortuneTeller] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FortuneTeller] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FortuneTeller] SET  MULTI_USER 
GO
ALTER DATABASE [FortuneTeller] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FortuneTeller] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FortuneTeller] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FortuneTeller] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FortuneTeller] SET DELAYED_DURABILITY = DISABLED 
GO
USE [FortuneTeller]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 10/13/2016 2:06:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 10/13/2016 2:06:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerFirstName] [nvarchar](50) NOT NULL,
	[CustomerLastName] [nvarchar](50) NOT NULL,
	[CustomerAge] [int] NOT NULL,
	[CustomerBirthMonth] [int] NOT NULL,
	[CustomerColor] [int] NOT NULL,
	[CustomerSiblings] [int] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Months]    Script Date: 10/13/2016 2:06:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Months](
	[MonthID] [int] IDENTITY(1,1) NOT NULL,
	[MonthName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Months] PRIMARY KEY CLUSTERED 
(
	[MonthID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Siblings]    Script Date: 10/13/2016 2:06:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Siblings](
	[SibilingID] [int] IDENTITY(1,1) NOT NULL,
	[SiblingCount] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Siblings] PRIMARY KEY CLUSTERED 
(
	[SibilingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Colors] FOREIGN KEY([CustomerColor])
REFERENCES [dbo].[Colors] ([ColorID])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Colors]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Months] FOREIGN KEY([CustomerBirthMonth])
REFERENCES [dbo].[Months] ([MonthID])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Months]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Siblings] FOREIGN KEY([CustomerSiblings])
REFERENCES [dbo].[Siblings] ([SibilingID])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Siblings]
GO
USE [master]
GO
ALTER DATABASE [FortuneTeller] SET  READ_WRITE 
GO
