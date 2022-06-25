USE [master]
GO
/****** Object:  Database [PetCareApp2]    Script Date: 5/21/2022 8:12:55 PM ******/
CREATE DATABASE [PetCareApp2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PetCareApp2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PetCareApp2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PetCareApp2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PetCareApp2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PetCareApp2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PetCareApp2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PetCareApp2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PetCareApp2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PetCareApp2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PetCareApp2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PetCareApp2] SET ARITHABORT OFF 
GO
ALTER DATABASE [PetCareApp2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PetCareApp2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PetCareApp2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PetCareApp2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PetCareApp2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PetCareApp2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PetCareApp2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PetCareApp2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PetCareApp2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PetCareApp2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PetCareApp2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PetCareApp2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PetCareApp2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PetCareApp2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PetCareApp2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PetCareApp2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PetCareApp2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PetCareApp2] SET RECOVERY FULL 
GO
ALTER DATABASE [PetCareApp2] SET  MULTI_USER 
GO
ALTER DATABASE [PetCareApp2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PetCareApp2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PetCareApp2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PetCareApp2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PetCareApp2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PetCareApp2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PetCareApp2', N'ON'
GO
ALTER DATABASE [PetCareApp2] SET QUERY_STORE = OFF
GO
USE [PetCareApp2]
GO
/****** Object:  User [DESKTOP-CLCPQT7\mataj]    Script Date: 5/21/2022 8:12:55 PM ******/
CREATE USER [DESKTOP-CLCPQT7\mataj] FOR LOGIN [DESKTOP-CLCPQT7\mataj] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[AdListing]    Script Date: 5/21/2022 8:12:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdListing](
	[AdlistingId] [int] NOT NULL,
	[startDate] [datetime] NULL,
	[endDate] [datetime] NULL,
	[idAdress] [int] NULL,
	[AdlistingDescription] [varchar](max) NULL,
	[isActive] [bit] NULL,
	[Price] [float] NULL,
	[Title] [varchar](50) NULL,
	[petId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdlistingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Adress]    Script Date: 5/21/2022 8:12:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adress](
	[AdressId] [int] NOT NULL,
	[Adress] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[PostalCode] [nchar](10) NULL,
	[IsHouse] [bit] NULL,
	[Floor] [int] NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[AdressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hasPet]    Script Date: 5/21/2022 8:12:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hasPet](
	[personId] [int] NOT NULL,
	[petId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 5/21/2022 8:12:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] NOT NULL,
	[PersonFirstName] [varchar](50) NOT NULL,
	[PersonLastName] [varchar](50) NOT NULL,
	[OIB] [nchar](11) NOT NULL,
	[PersonEmail] [varchar](50) NULL,
	[PersonMobile] [nchar](13) NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[SessionId] [varchar](max) NULL,
 CONSTRAINT [PK_Person2] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonRole]    Script Date: 5/21/2022 8:12:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonRole](
	[PersonId] [int] NOT NULL,
	[AdlistingId] [int] NOT NULL,
	[AssigmentDate] [datetime] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_PersonRole] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pet]    Script Date: 5/21/2022 8:12:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pet](
	[petId] [int] NOT NULL,
	[petName] [varchar](50) NULL,
	[Sex] [bit] NULL,
	[Size] [varchar](50) NULL,
	[PetType] [varchar](50) NULL,
	[Breed] [varchar](50) NULL,
 CONSTRAINT [PK_Pet] PRIMARY KEY CLUSTERED 
(
	[petId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/21/2022 8:12:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdListing]  WITH CHECK ADD  CONSTRAINT [FK_AdListing_Adress] FOREIGN KEY([idAdress])
REFERENCES [dbo].[Adress] ([AdressId])
GO
ALTER TABLE [dbo].[AdListing] CHECK CONSTRAINT [FK_AdListing_Adress]
GO
ALTER TABLE [dbo].[AdListing]  WITH CHECK ADD  CONSTRAINT [FK_AdListing_Pet] FOREIGN KEY([petId])
REFERENCES [dbo].[Pet] ([petId])
GO
ALTER TABLE [dbo].[AdListing] CHECK CONSTRAINT [FK_AdListing_Pet]
GO
ALTER TABLE [dbo].[PersonRole]  WITH CHECK ADD  CONSTRAINT [FK_PersonRole_AdListing] FOREIGN KEY([AdlistingId])
REFERENCES [dbo].[AdListing] ([AdlistingId])
GO
ALTER TABLE [dbo].[PersonRole] CHECK CONSTRAINT [FK_PersonRole_AdListing]
GO
ALTER TABLE [dbo].[PersonRole]  WITH CHECK ADD  CONSTRAINT [FK_PersonRole_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[PersonRole] CHECK CONSTRAINT [FK_PersonRole_Person]
GO
ALTER TABLE [dbo].[PersonRole]  WITH CHECK ADD  CONSTRAINT [FK_PersonRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[PersonRole] CHECK CONSTRAINT [FK_PersonRole_Role]
GO
USE [master]
GO
ALTER DATABASE [PetCareApp2] SET  READ_WRITE 
GO
