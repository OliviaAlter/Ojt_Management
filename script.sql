USE
[master]
GO
/****** Object:  Database [OJT5]    Script Date: 7/20/2022 2:27:34 AM ******/
CREATE
DATABASE [OJT5]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OJT5', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OJT5.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OJT5_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OJT5_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OJT5].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER
DATABASE [OJT5] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER
DATABASE [OJT5] SET ANSI_NULLS OFF 
GO
ALTER
DATABASE [OJT5] SET ANSI_PADDING OFF 
GO
ALTER
DATABASE [OJT5] SET ANSI_WARNINGS OFF 
GO
ALTER
DATABASE [OJT5] SET ARITHABORT OFF 
GO
ALTER
DATABASE [OJT5] SET AUTO_CLOSE OFF 
GO
ALTER
DATABASE [OJT5] SET AUTO_SHRINK OFF 
GO
ALTER
DATABASE [OJT5] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER
DATABASE [OJT5] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER
DATABASE [OJT5] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER
DATABASE [OJT5] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER
DATABASE [OJT5] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER
DATABASE [OJT5] SET QUOTED_IDENTIFIER OFF 
GO
ALTER
DATABASE [OJT5] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER
DATABASE [OJT5] SET  ENABLE_BROKER 
GO
ALTER
DATABASE [OJT5] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER
DATABASE [OJT5] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER
DATABASE [OJT5] SET TRUSTWORTHY OFF 
GO
ALTER
DATABASE [OJT5] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER
DATABASE [OJT5] SET PARAMETERIZATION SIMPLE 
GO
ALTER
DATABASE [OJT5] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER
DATABASE [OJT5] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER
DATABASE [OJT5] SET RECOVERY FULL 
GO
ALTER
DATABASE [OJT5] SET  MULTI_USER 
GO
ALTER
DATABASE [OJT5] SET PAGE_VERIFY CHECKSUM  
GO
ALTER
DATABASE [OJT5] SET DB_CHAINING OFF 
GO
ALTER
DATABASE [OJT5] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER
DATABASE [OJT5] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER
DATABASE [OJT5] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OJT5', N'ON'
GO
USE [OJT5]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/20/2022 2:27:34 AM ******/
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
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/20/2022 2:27:34 AM ******/
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
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED
(
[
    AccountId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Company]    Script Date: 7/20/2022 2:27:34 AM ******/
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
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED
(
[
    CompanyId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[JobApplication]    Script Date: 7/20/2022 2:27:34 AM ******/
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
    [StudentId] [int] NULL,
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
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Major]    Script Date: 7/20/2022 2:27:34 AM ******/
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
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/20/2022 2:27:34 AM ******/
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
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Semester]    Script Date: 7/20/2022 2:27:34 AM ******/
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
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[SemesterCompany]    Script Date: 7/20/2022 2:27:34 AM ******/
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
    [SemesterId] [int] NULL,
    [CompanyId] [int] NULL,
    CONSTRAINT [PK_SemesterCompany] PRIMARY KEY CLUSTERED
(
[
    SemesterCompanyId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY]
    )
  ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Student]    Script Date: 7/20/2022 2:27:34 AM ******/
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
    [Email] [nvarchar]
(
    max
) NOT NULL,
    [PhoneNumber] [int] NOT NULL,
    [Score] [int] NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED
(
[
    StudentId] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
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
    N'20220716210604_Test1',
    N'5.0.15'
)
    INSERT [dbo].[__EFMigrationsHistory]
(
    [
    MigrationId],
[
    ProductVersion]
) VALUES
(
    N'20220717221945_test2',
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
    Password],
[
    RoleId]
) VALUES
(
    3,
    N'test2',
    N'123',
    1
)
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password],
[
    RoleId]
) VALUES
(
    4,
    N'test3',
    N'123',
    1
)
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password],
[
    RoleId]
) VALUES
(
    5,
    N'test4',
    N'123',
    2
)
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password],
[
    RoleId]
) VALUES
(
    6,
    N'trrwfr',
    N'123',
    2
)
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password],
[
    RoleId]
) VALUES
(
    7,
    N'trwer',
    N'111',
    1
)
    INSERT [dbo].[Account]
(
    [
    AccountId], [
    Username], [
    Password],
[
    RoleId]
) VALUES
(
    8,
    N'tert',
    N'11',
    1
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
    Address],
[
    Email]
) VALUES
(
    1,
    N'F',
    N'Test',
    N'V',
    N'E'
)
    INSERT [dbo].[Company]
(
    [
    CompanyId], [
    CompanyName], [
    Description], [
    Address],
[
    Email]
) VALUES
(
    2,
    N'FS',
    N'E',
    N'e',
    N'e'
)
    INSERT [dbo].[Company]
(
    [
    CompanyId], [
    CompanyName], [
    Description], [
    Address],
[
    Email]
) VALUES
(
    3,
    N'A',
    N'A',
    N'a',
    N'a'
)
    INSERT [dbo].[Company]
(
    [
    CompanyId], [
    CompanyName], [
    Description], [
    Address],
[
    Email]
) VALUES
(
    4,
    N'B',
    N'B',
    N'B',
    N'B'
)
    INSERT [dbo].[Company]
(
    [
    CompanyId], [
    CompanyName], [
    Description], [
    Address],
[
    Email]
) VALUES
(
    5,
    N'string',
    N'string',
    N'string',
    N'string'
)
    SET IDENTITY_INSERT [dbo].[Company] OFF
    GO
    SET IDENTITY_INSERT [dbo].[JobApplication]
  ON
    INSERT [dbo].[JobApplication]
(
    [
    JobApplicationId], [
    StudentId], [
    ImageUrl], [
    ApplicationStatus],
[
    CompanyId]
) VALUES
(
    2,
    2,
    N'url2',
    2,
    2
)
    INSERT [dbo].[JobApplication]
(
    [
    JobApplicationId], [
    StudentId], [
    ImageUrl], [
    ApplicationStatus],
[
    CompanyId]
) VALUES
(
    3,
    3,
    N'url3',
    3,
    3
)
    SET IDENTITY_INSERT [dbo].[JobApplication] OFF
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
    N'hello world'
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
    N'IS'
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
    N'string'
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
    N'SS'
)
    INSERT [dbo].[Major]
(
    [
    MajorId],
[
    MajorName]
) VALUES
(
    1002,
    N'jobbbbbbbbb'
)
    INSERT [dbo].[Major]
(
    [
    MajorId],
[
    MajorName]
) VALUES
(
    1003,
    N'testtttttt'
)
    INSERT [dbo].[Major]
(
    [
    MajorId],
[
    MajorName]
) VALUES
(
    1004,
    N'231'
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
    N'student'
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
    N'admin'
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
    N'company'
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
    N'FA'
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
    N'SP'
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
    2,
    2,
    3
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
    1,
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
    Email], [
    PhoneNumber],
[
    Score]
) VALUES
(
    2,
    3,
    2,
    N'test123',
    1,
    2,
    N'test43',
    123,
    7
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
    Email], [
    PhoneNumber],
[
    Score]
) VALUES
(
    3,
    4,
    3,
    N'test12342',
    2,
    3,
    N'tease2314',
    3031,
    8
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
    Email], [
    PhoneNumber],
[
    Score]
) VALUES
(
    6,
    5,
    4,
    N'test123',
    3,
    3,
    N'rewrw',
    123,
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
    Email], [
    PhoneNumber],
[
    Score]
) VALUES
(
    7,
    6,
    6,
    N'tertre',
    3,
    2,
    N'312',
    312,
    1
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
    Email], [
    PhoneNumber],
[
    Score]
) VALUES
(
    9,
    7,
    8,
    N'3231',
    2,
    1,
    N'1',
    3,
    3
)
    SET IDENTITY_INSERT [dbo].[Student] OFF
    GO
/****** Object:  Index [IX_Account_RoleId]    Script Date: 7/20/2022 2:27:35 AM ******/
CREATE
NONCLUSTERED INDEX [IX_Account_RoleId] ON [dbo].[Account]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobApplication_CompanyId]    Script Date: 7/20/2022 2:27:35 AM ******/
CREATE
NONCLUSTERED INDEX [IX_JobApplication_CompanyId] ON [dbo].[JobApplication]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JobApplication_StudentId]    Script Date: 7/20/2022 2:27:35 AM ******/
CREATE
NONCLUSTERED INDEX [IX_JobApplication_StudentId] ON [dbo].[JobApplication]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SemesterCompany_CompanyId]    Script Date: 7/20/2022 2:27:35 AM ******/
CREATE
NONCLUSTERED INDEX [IX_SemesterCompany_CompanyId] ON [dbo].[SemesterCompany]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SemesterCompany_SemesterId]    Script Date: 7/20/2022 2:27:35 AM ******/
CREATE
NONCLUSTERED INDEX [IX_SemesterCompany_SemesterId] ON [dbo].[SemesterCompany]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_AccountId]    Script Date: 7/20/2022 2:27:35 AM ******/
CREATE UNIQUE
NONCLUSTERED INDEX [IX_Student_AccountId] ON [dbo].[Student]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_MajorId]    Script Date: 7/20/2022 2:27:35 AM ******/
CREATE
NONCLUSTERED INDEX [IX_Student_MajorId] ON [dbo].[Student]
(
	[MajorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_SemesterId]    Script Date: 7/20/2022 2:27:35 AM ******/
CREATE
NONCLUSTERED INDEX [IX_Student_SemesterId] ON [dbo].[Student]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] WITH CHECK ADD CONSTRAINT [FK_Account_Role_RoleId] FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role] ([RoleId])
    ON
DELETE
CASCADE
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Role_RoleId]
    GO
ALTER TABLE [dbo].[JobApplication] WITH CHECK ADD CONSTRAINT [FK_JobApplication_Company_CompanyId] FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Company] ([CompanyId])
    GO
ALTER TABLE [dbo].[JobApplication] CHECK CONSTRAINT [FK_JobApplication_Company_CompanyId]
    GO
ALTER TABLE [dbo].[JobApplication] WITH CHECK ADD CONSTRAINT [FK_JobApplication_Student_StudentId] FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Student] ([StudentId])
    GO
ALTER TABLE [dbo].[JobApplication] CHECK CONSTRAINT [FK_JobApplication_Student_StudentId]
    GO
ALTER TABLE [dbo].[SemesterCompany] WITH CHECK ADD CONSTRAINT [FK_SemesterCompany_Company_CompanyId] FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Company] ([CompanyId])
    GO
ALTER TABLE [dbo].[SemesterCompany] CHECK CONSTRAINT [FK_SemesterCompany_Company_CompanyId]
    GO
ALTER TABLE [dbo].[SemesterCompany] WITH CHECK ADD CONSTRAINT [FK_SemesterCompany_Semester_SemesterId] FOREIGN KEY ([SemesterId])
    REFERENCES [dbo].[Semester] ([SemesterId])
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
DATABASE [OJT5] SET  READ_WRITE 
GO
