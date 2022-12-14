USE [master]
GO
/****** Object:  Database [CompanyTask1]    Script Date: 28-07-2022 13:09:28 ******/
CREATE DATABASE [CompanyTask1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CompanyTask1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\CompanyTask1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CompanyTask1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\CompanyTask1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CompanyTask1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CompanyTask1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CompanyTask1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CompanyTask1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CompanyTask1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CompanyTask1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CompanyTask1] SET ARITHABORT OFF 
GO
ALTER DATABASE [CompanyTask1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CompanyTask1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompanyTask1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompanyTask1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompanyTask1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CompanyTask1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CompanyTask1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompanyTask1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CompanyTask1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompanyTask1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CompanyTask1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompanyTask1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompanyTask1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompanyTask1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompanyTask1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompanyTask1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CompanyTask1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompanyTask1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CompanyTask1] SET  MULTI_USER 
GO
ALTER DATABASE [CompanyTask1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompanyTask1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CompanyTask1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompanyTask1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CompanyTask1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CompanyTask1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CompanyTask1] SET QUERY_STORE = OFF
GO
USE [CompanyTask1]
GO
/****** Object:  Table [dbo].[tblRegister]    Script Date: 28-07-2022 13:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRegister](
	[RegisterId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nchar](10) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [nvarchar](16) NULL,
	[EmailId] [nvarchar](300) NULL,
	[Password] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CompanyTask1]    Script Date: 28-07-2022 13:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[CompanyTask1]
(
@FirstName nvarchar(50)=null,
@LastName nvarchar(50)=null,
@DateOfBirth nvarchar(16)=null,
@EmailId nvarchar(300)=null,
@Password nvarchar(20)=null,
@ConfirmPassword nvarchar(20)=null,
@Flag nvarchar(50),
@RegisterId int =null
)
as
begin

if(@Flag='Login')
begin
select * from tblRegister where EmailId=@EmailId and Password=@Password
end


if(@Flag='AddRegister')
begin
insert into tblRegister values (@FirstName,@LastName,@DateOfBirth, @EmailId,@Password,@ConfirmPassword)
end


if(@Flag='ShowData')
begin
select * from tblRegister
end

if(@Flag='ShowSingleEmployee')
begin
select * from tblRegister where RegisterId=@RegisterId
end


if(@Flag='EditEmployee')
begin
update tblRegister set FirstName=@FirstName,LastName=@LastName,DateOfBirth=@DateOfBirth where RegisterId=@RegisterId
end


if(@Flag='DeleteEmployee')
begin
delete from tblRegister where RegisterId=@RegisterId
end



--if(@Flag='CalculateAge')
--begin
--SELECT DATEDIFF(hour,@DateOfBirth,GETDATE())/8766.0 AS AgeYearsDecimal
    
--end


end
GO
USE [master]
GO
ALTER DATABASE [CompanyTask1] SET  READ_WRITE 
GO
