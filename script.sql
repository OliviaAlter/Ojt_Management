USE
[master]
GO
/****** Object:  Database [OJT6]    Script Date: 7/22/2022 8:15:51 PM ******/
CREATE
DATABASE [OJT6]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OJT6', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OJT6.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OJT6_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OJT6_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER
DATABASE [OJT6] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OJT6].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER
DATABASE [OJT6] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER
DATABASE [OJT6] SET ANSI_NULLS OFF 
GO
ALTER
DATABASE [OJT6] SET ANSI_PADDING OFF 
GO
ALTER
DATABASE [OJT6] SET ANSI_WARNINGS OFF 
GO
ALTER
DATABASE [OJT6] SET ARITHABORT OFF 
GO
ALTER
DATABASE [OJT6] SET AUTO_CLOSE OFF 
GO
ALTER
DATABASE [OJT6] SET AUTO_SHRINK OFF 
GO
ALTER
DATABASE [OJT6] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER
DATABASE [OJT6] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER
DATABASE [OJT6] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER
DATABASE [OJT6] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER
DATABASE [OJT6] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER
DATABASE [OJT6] SET QUOTED_IDENTIFIER OFF 
GO
ALTER
DATABASE [OJT6] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER
DATABASE [OJT6] SET  ENABLE_BROKER 
GO
ALTER
DATABASE [OJT6] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER
DATABASE [OJT6] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER
DATABASE [OJT6] SET TRUSTWORTHY OFF 
GO
ALTER
DATABASE [OJT6] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER
DATABASE [OJT6] SET PARAMETERIZATION SIMPLE 
GO
ALTER
DATABASE [OJT6] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER
DATABASE [OJT6] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER
DATABASE [OJT6] SET RECOVERY FULL 
GO
ALTER
DATABASE [OJT6] SET  MULTI_USER 
GO
ALTER
DATABASE [OJT6] SET PAGE_VERIFY CHECKSUM  
GO
ALTER
DATABASE [OJT6] SET DB_CHAINING OFF 
GO
ALTER
DATABASE [OJT6] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER
DATABASE [OJT6] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER
DATABASE [OJT6] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER
DATABASE [OJT6] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OJT6', N'ON'
GO
ALTER
DATABASE [OJT6] SET QUERY_STORE = OFF
GO
USE [OJT6]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/22/2022 8:15:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory]
(
    [
    MigrationId] [
    nvarchar]
(
    150
) NOT NULL,
    [ProductVersion] [nvarchar]
(
    32
) NOT NULL,
    CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED
(
[
    MigrationId] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/22/2022 8:15:51 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[Account]
(
    [
    AccountId] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [Username] [nvarchar]
(
    max
) NOT NULL,
    [Password] [nvarchar]
(
    max
) NOT NULL,
    [RoleId] [int] NOT NULL,
    [Email] [nvarchar]
(
    max
) NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED
(
[
    AccountId] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Company]    Script Date: 7/22/2022 8:15:51 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[Company]
(
    [
    CompanyId] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [CompanyName] [nvarchar]
(
    max
) NOT NULL,
    [Description] [nvarchar]
(
    max
) NOT NULL,
    [Address] [nvarchar]
(
    max
) NOT NULL,
    [Email] [nvarchar]
(
    max
) NOT NULL,
    [AccountId] [int] NOT NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED
(
[
    CompanyId] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[JobApplication]    Script Date: 7/22/2022 8:15:51 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[JobApplication]
(
    [
    JobApplicationId] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [StudentId] [int] NOT NULL,
    [ImageUrl] [nvarchar]
(
    max
) NOT NULL,
    [ApplicationStatus] [int] NULL,
    [CompanyId] [int] NULL,
    CONSTRAINT [PK_JobApplication] PRIMARY KEY CLUSTERED
(
[
    JobApplicationId] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Major]    Script Date: 7/22/2022 8:15:51 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[Major]
(
    [
    MajorId] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [MajorName] [nvarchar]
(
    max
) NOT NULL,
    CONSTRAINT [PK_Major] PRIMARY KEY CLUSTERED
(
[
    MajorId] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/22/2022 8:15:51 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[Role]
(
    [
    RoleId] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [RoleName] [nvarchar]
(
    max
) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED
(
[
    RoleId] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Semester]    Script Date: 7/22/2022 8:15:51 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[Semester]
(
    [
    SemesterId] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [SemesterName] [nvarchar]
(
    max
) NOT NULL,
    CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED
(
[
    SemesterId] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[SemesterCompany]    Script Date: 7/22/2022 8:15:51 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[SemesterCompany]
(
    [
    SemesterCompanyId] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [SemesterId] [int] NOT NULL,
    [CompanyId] [int] NOT NULL,
    CONSTRAINT [PK_SemesterCompany] PRIMARY KEY CLUSTERED
(
[
    SemesterCompanyId] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Student]    Script Date: 7/22/2022 8:15:51 PM ******/
    SET ANSI_NULLS
    ON
    GO
    SET QUOTED_IDENTIFIER
    ON
    GO
CREATE TABLE [dbo].[Student]
(
    [
    StudentId] [
    int]
    IDENTITY
(
    1,
    1
) NOT NULL,
    [AccountId] [int] NOT NULL,
    [StudentCode] [int] NOT NULL,
    [Name] [nvarchar]
(
    max
) NOT NULL,
    [MajorId] [int] NOT NULL,
    [SemesterId] [int] NOT NULL,
    [PhoneNumber] [int] NOT NULL,
    [Score] [int] NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED
(
[
    StudentId] ASC
)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF)
    ON [PRIMARY]
    )
    ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
    INSERT [dbo].[__EFMigrationsHistory]
(
    [
    MigrationId],
[
    ProductVersion]
) VALUES
(
    N'20220722041240_InitialCreation',
    N'5.0.15'
)
    GO
    SET IDENTITY_INSERT [dbo].[Account]
    ON
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password], [
    RoleId],
[
    Email]
) VALUES
(
    1,
    N'test',
    N'123',
    1,
    N'E1'
)
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password], [
    RoleId],
[
    Email]
) VALUES
(
    2,
    N'abc',
    N'123',
    2,
    N'E2'
)
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password], [
    RoleId],
[
    Email]
) VALUES
(
    3,
    N'def',
    N'123',
    3,
    N'E3'
)
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password], [
    RoleId],
[
    Email]
) VALUES
(
    4,
    N'ewq',
    N'123',
    2,
    N'E4'
)
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password], [
    RoleId],
[
    Email]
) VALUES
(
    5,
    N'qeqw',
    N'123',
    1,
    N'E5'
)
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password], [
    RoleId],
[
    Email]
) VALUES
(
    6,
    N'edsfs',
    N'123',
    3,
    N'E6'
)
    SET IDENTITY_INSERT [dbo].[Account] OFF
    GO
    SET IDENTITY_INSERT [dbo].[Company]
    ON
    INSERT [dbo].[Company]
(
    [
    CompanyId], [
    CompanyName], [
    Description], [
    Address], [
    Email],
[
    AccountId]
) VALUES
(
    1,
    N'FPT',
    N'ER',
    N'VN',
    N'mail',
    3
)
    INSERT [dbo].[Company]
(
    [
    CompanyId], [
    CompanyName], [
    Description], [
    Address], [
    Email],
[
    AccountId]
) VALUES
(
    2,
    N'FSoft',
    N'ERC',
    N'VN',
    N'mail',
    6
)
    SET IDENTITY_INSERT [dbo].[Company] OFF
    GO
    SET IDENTITY_INSERT [dbo].[Major]
    ON
    INSERT [dbo].[Major]
(
    [
    MajorId],
[
    MajorName]
) VALUES
(
    1,
    N'SE'
)
    INSERT [dbo].[Major]
(
    [
    MajorId],
[
    MajorName]
) VALUES
(
    2,
    N'SP'
)
    INSERT [dbo].[Major]
(
    [
    MajorId],
[
    MajorName]
) VALUES
(
    3,
    N'AI'
)
    INSERT [dbo].[Major]
(
    [
    MajorId],
[
    MajorName]
) VALUES
(
    4,
    N'SI'
)
    SET IDENTITY_INSERT [dbo].[Major] OFF
    GO
    SET IDENTITY_INSERT [dbo].[Role]
    ON
    INSERT [dbo].[Role]
(
    [
    RoleId],
[
    RoleName]
) VALUES
(
    1,
    N'Student'
)
    INSERT [dbo].[Role]
(
    [
    RoleId],
[
    RoleName]
) VALUES
(
    2,
    N'Admin'
)
    INSERT [dbo].[Role]
(
    [
    RoleId],
[
    RoleName]
) VALUES
(
    3,
    N'Company'
)
    SET IDENTITY_INSERT [dbo].[Role] OFF
    GO
    SET IDENTITY_INSERT [dbo].[Semester]
    ON
    INSERT [dbo].[Semester]
(
    [
    SemesterId],
[
    SemesterName]
) VALUES
(
    1,
    N'SU'
)
    INSERT [dbo].[Semester]
(
    [
    SemesterId],
[
    SemesterName]
) VALUES
(
    2,
    N'SP'
)
    INSERT [dbo].[Semester]
(
    [
    SemesterId],
[
    SemesterName]
) VALUES
(
    3,
    N'WT'
)
    SET IDENTITY_INSERT [dbo].[Semester] OFF
    GO
    SET IDENTITY_INSERT [dbo].[SemesterCompany]
    ON
    INSERT [dbo].[SemesterCompany]
(
    [
    SemesterCompanyId], [
    SemesterId],
[
    CompanyId]
) VALUES
(
    1,
    1,
    1
)
    INSERT [dbo].[SemesterCompany]
(
    [
    SemesterCompanyId], [
    SemesterId],
[
    CompanyId]
) VALUES
(
    3,
    2,
    2
)
    INSERT [dbo].[SemesterCompany]
(
    [
    SemesterCompanyId], [
    SemesterId],
[
    CompanyId]
) VALUES
(
    6,
    3,
    2
)
    SET IDENTITY_INSERT [dbo].[SemesterCompany] OFF
    GO
    SET IDENTITY_INSERT [dbo].[Student]
    ON
    INSERT [dbo].[Student]
(
    [
    StudentId], [
    AccountId], [
    StudentCode], [
    Name], [
    MajorId], [
    SemesterId], [
    PhoneNumber],
[
    Score]
) VALUES
(
    5,
    1,
    231,
    N'Test',
    1,
    1,
    993213,
    32
)
    INSERT [dbo].[Student]
(
    [
    StudentId], [
    AccountId], [
    StudentCode], [
    Name], [
    MajorId], [
    SemesterId], [
    PhoneNumber],
[
    Score]
) VALUES
(
    6,
    5,
    1234,
    N'Tescg',
    2,
    3,
    213545,
    21
)
    SET IDENTITY_INSERT [dbo].[Student] OFF
    GO
/****** Object:  Index [IX_Account_RoleId]    Script Date: 7/22/2022 8:15:51 PM ******/
CREATE
NONCLUSTERED INDEX [IX_Account_RoleId] ON [dbo].[Account]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Company_AccountId]    Script Date: 7/22/2022 8:15:51 PM ******/
CREATE
NONCLUSTERED INDEX [IX_Company_AccountId] ON [dbo].[Company]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobApplication_CompanyId]    Script Date: 7/22/2022 8:15:51 PM ******/
CREATE
NONCLUSTERED INDEX [IX_JobApplication_CompanyId] ON [dbo].[JobApplication]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobApplication_StudentId]    Script Date: 7/22/2022 8:15:51 PM ******/
CREATE
NONCLUSTERED INDEX [IX_JobApplication_StudentId] ON [dbo].[JobApplication]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SemesterCompany_CompanyId]    Script Date: 7/22/2022 8:15:51 PM ******/
CREATE
NONCLUSTERED INDEX [IX_SemesterCompany_CompanyId] ON [dbo].[SemesterCompany]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SemesterCompany_SemesterId]    Script Date: 7/22/2022 8:15:51 PM ******/
CREATE
NONCLUSTERED INDEX [IX_SemesterCompany_SemesterId] ON [dbo].[SemesterCompany]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_AccountId]    Script Date: 7/22/2022 8:15:51 PM ******/
CREATE UNIQUE
NONCLUSTERED INDEX [IX_Student_AccountId] ON [dbo].[Student]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_MajorId]    Script Date: 7/22/2022 8:15:51 PM ******/
CREATE
NONCLUSTERED INDEX [IX_Student_MajorId] ON [dbo].[Student]
(
	[MajorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_SemesterId]    Script Date: 7/22/2022 8:15:51 PM ******/
CREATE
NONCLUSTERED INDEX [IX_Student_SemesterId] ON [dbo].[Student]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] WITH CHECK ADD CONSTRAINT [FK_Account_Role_RoleId] FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role] ([RoleId])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role_RoleId]
    GO
ALTER TABLE [dbo].[Company] WITH CHECK ADD CONSTRAINT [FK_Company_Account_AccountId] FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Account] ([AccountId])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Account_AccountId]
    GO
ALTER TABLE [dbo].[JobApplication] WITH CHECK ADD CONSTRAINT [FK_JobApplication_Company_CompanyId] FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Company] ([CompanyId])
    GO
ALTER TABLE [dbo].[JobApplication] CHECK CONSTRAINT [FK_JobApplication_Company_CompanyId]
    GO
ALTER TABLE [dbo].[JobApplication] WITH CHECK ADD CONSTRAINT [FK_JobApplication_Student_StudentId] FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Student] ([StudentId])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[JobApplication] CHECK CONSTRAINT [FK_JobApplication_Student_StudentId]
    GO
ALTER TABLE [dbo].[SemesterCompany] WITH CHECK ADD CONSTRAINT [FK_SemesterCompany_Company_CompanyId] FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Company] ([CompanyId])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[SemesterCompany] CHECK CONSTRAINT [FK_SemesterCompany_Company_CompanyId]
    GO
ALTER TABLE [dbo].[SemesterCompany] WITH CHECK ADD CONSTRAINT [FK_SemesterCompany_Semester_SemesterId] FOREIGN KEY ([SemesterId])
    REFERENCES [dbo].[Semester] ([SemesterId])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[SemesterCompany] CHECK CONSTRAINT [FK_SemesterCompany_Semester_SemesterId]
    GO
ALTER TABLE [dbo].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_Account_AccountId] FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Account] ([AccountId])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Account_AccountId]
    GO
ALTER TABLE [dbo].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_Major_MajorId] FOREIGN KEY ([MajorId])
    REFERENCES [dbo].[Major] ([MajorId])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Major_MajorId]
    GO
ALTER TABLE [dbo].[Student] WITH CHECK ADD CONSTRAINT [FK_Student_Semester_SemesterId] FOREIGN KEY ([SemesterId])
    REFERENCES [dbo].[Semester] ([SemesterId])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Semester_SemesterId]
    GO
    USE [master]
    GO
ALTER
DATABASE [OJT6] SET  READ_WRITE 
GO
