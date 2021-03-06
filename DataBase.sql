USE [master]
GO
/****** Object:  Database [XoomUniversityDB]    Script Date: 12/18/2018 10:30:04 PM ******/
CREATE DATABASE [XoomUniversityDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'XoomUniversityDB', FILENAME = N'G:\Project\ASPDOTNET\Database\XoomUniversityDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'XoomUniversityDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.CHOTON\MSSQL\DATA\XoomUniversityDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [XoomUniversityDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [XoomUniversityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [XoomUniversityDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [XoomUniversityDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [XoomUniversityDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [XoomUniversityDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [XoomUniversityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [XoomUniversityDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [XoomUniversityDB] SET  MULTI_USER 
GO
ALTER DATABASE [XoomUniversityDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [XoomUniversityDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [XoomUniversityDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [XoomUniversityDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [XoomUniversityDB]
GO
/****** Object:  Table [dbo].[AssignCourses]    Script Date: 12/18/2018 10:30:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignCourses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NULL,
	[CourseId] [int] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_AssignCourses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassRoomsAllocation]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassRoomsAllocation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[DayId] [int] NULL,
	[StartTime] [varchar](50) NULL,
	[EndTime] [varchar](50) NULL,
	[AssignType] [int] NULL,
 CONSTRAINT [PK_ClassRoomsAllocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](25) NULL,
	[Name] [varchar](55) NULL,
	[Credit] [decimal](2, 1) NULL,
	[Description] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
	[SemesterId] [int] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Days]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Days](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Day] [varchar](15) NULL,
 CONSTRAINT [PK_Days] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](15) NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [varchar](50) NULL,
 CONSTRAINT [PK_Designations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrollCourses]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EnrollCourses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
	[Date] [varchar](50) NULL,
	[GradeId] [int] NULL,
 CONSTRAINT [PK_EnrollCourses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [varchar](15) NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](25) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegNo] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](80) NULL,
	[Email] [varchar](40) NULL,
	[ContactNo] [varchar](25) NULL,
	[DesignationId] [int] NULL,
	[DepartmentId] [int] NULL,
	[CreditBeTaken] [decimal](20, 1) NULL,
	[CreditLeft] [decimal](20, 1) NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[CourseInfo]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CourseInfo] AS
SELECT
Courses.Id As CourseId,
Courses.Code AS CourseCode,
Courses.Name AS CourseName,
Courses.DepartmentId AS CourseDepartementId,
Departments.Name AS DepartmentName,
Courses.SemesterId AS SemesterId,
Semesters.Name AS SemesterName,
AssignCourses.TeacherId AS TeacherId,
Teachers.Name AS TeacherName,
AssignCourses.Type
FROM AssignCourses FULL JOIN Courses ON Courses.Id=AssignCourses.CourseId INNER JOIN Departments ON Courses.DepartmentId=Departments.Id INNER JOIN Semesters ON Courses.SemesterId=Semesters.Id LEFT JOIN Teachers ON AssignCourses.TeacherId=Teachers.Id
GO
/****** Object:  View [dbo].[CourseTeacherInfo]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CourseTeacherInfo] AS

select 
Departments.Id AS DepartmentId,
Departments.Code,
Departments.Name,
Courses.Id AS CourseId,
Courses.Code AS CourseCode,
Courses.Name AS CourseName,
Courses.Credit AS CourseCredit,
Teachers.Id AS TeacherId,
Teachers.Name AS TeacherName,
Teachers.Email AS TeacherEmail,
Teachers.CreditBeTaken,
Teachers.CreditLeft
 from Departments inner join Courses on Departments.Id=Courses.DepartmentId inner join Teachers on Departments.Id=Teachers.DepartmentId
GO
/****** Object:  View [dbo].[RoomAllocationInfo]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[RoomAllocationInfo] AS

SELECT
ClassRoomsAllocation.Id AS AllocationId,
Courses.Code,
Courses.Name,
Courses.DepartmentId AS DepartmentId,
Departments.Name AS DepartmentName,
Rooms.RoomNo,
Days.Day,
ClassRoomsAllocation.StartTime,
ClassRoomsAllocation.EndTime,
Courses.Type,
ClassRoomsAllocation.AssignType
FROM Courses LEFT JOIN ClassRoomsAllocation On Courses.Id=ClassRoomsAllocation.CourseId LEFT JOIN Departments ON ClassRoomsAllocation.DepartmentId=Departments.Id LEFT JOIN Rooms ON ClassRoomsAllocation.RoomId=Rooms.Id LEFT JOIN Days ON ClassRoomsAllocation.DayId=Days.Id
GO
/****** Object:  View [dbo].[StudentInfo]    Script Date: 12/18/2018 10:30:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentInfo] AS
SELECT 
Students.Id,
Students.RegNo,
Students.Name,
Students.Email,
Students.ContactNo,
Students.Date,
Students.Address,
Students.DepartmentId,
Departments.Name AS DepartmentName
 FROM Students LEFT JOIN Departments ON Students.DepartmentId=Departments.Id
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Semesters] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Semesters]
GO
USE [master]
GO
ALTER DATABASE [XoomUniversityDB] SET  READ_WRITE 
GO
