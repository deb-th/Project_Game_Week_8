USE [master]
GO
/****** Object:  Database [Game]    Script Date: 19/03/2021 15:21:20 ******/
CREATE DATABASE [Game]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Game', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Game.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Game_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Game_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Game] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Game].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Game] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Game] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Game] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Game] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Game] SET ARITHABORT OFF 
GO
ALTER DATABASE [Game] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Game] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Game] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Game] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Game] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Game] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Game] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Game] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Game] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Game] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Game] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Game] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Game] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Game] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Game] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Game] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Game] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Game] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Game] SET  MULTI_USER 
GO
ALTER DATABASE [Game] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Game] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Game] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Game] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Game] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Game] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Game] SET QUERY_STORE = OFF
GO
USE [Game]
GO
/****** Object:  Table [dbo].[Arma]    Script Date: 19/03/2021 15:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arma](
	[Classe] [varchar](255) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[PuntiDanno] [int] NOT NULL,
 CONSTRAINT [PK_Arma] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classe]    Script Date: 19/03/2021 15:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classe](
	[Nome] [varchar](255) NOT NULL,
	[Hero] [bit] NOT NULL,
 CONSTRAINT [PK_Classe] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Giocatore]    Script Date: 19/03/2021 15:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Giocatore](
	[Nome] [varchar](255) NOT NULL,
	[Ruolo] [varchar](6) NOT NULL,
 CONSTRAINT [PK_Giocatore] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hero]    Script Date: 19/03/2021 15:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hero](
	[Nome] [varchar](255) NOT NULL,
	[Classe] [varchar](255) NOT NULL,
	[Arma] [varchar](255) NULL,
	[PuntiVita] [int] NOT NULL,
	[Livello] [int] NOT NULL,
	[PuntiAccumulati] [int] NOT NULL,
	[Giocatore] [varchar](255) NULL,
 CONSTRAINT [PK__Hero__7D8FE3B3177E4AA9] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Level]    Script Date: 19/03/2021 15:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[Livello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Livello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mostro]    Script Date: 19/03/2021 15:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostro](
	[Nome] [varchar](255) NOT NULL,
	[Classe] [varchar](255) NOT NULL,
	[Arma] [varchar](255) NULL,
	[PuntiVita] [int] NOT NULL,
	[Livello] [int] NOT NULL,
 CONSTRAINT [PK__Mostro__7D8FE3B34776B776] PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Guerriero', N'Arco', 5)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'SignoreDElMale', N'Ascetta', 5)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Guerriero', N'Ascia', 10)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Orco', N'Balestra', 20)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'SignoreDelMale', N'Balista', 15)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Orco', N'Clava', 5)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Guerriero', N'Fionda', 5)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'SignoreDelMale', N'FrecciaInfuocata', 20)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Guerriero', N'Fucile', 20)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Guerriero', N'Lancia', 15)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Cultista', N'Lanciagranate', 25)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Orco', N'Mazza', 10)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Cultista', N'MazzaChiodata', 20)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Cultista', N'OlioBollente', 15)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Mago', N'Pugnale', 15)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Cultista', N'Razzo', 15)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Mago', N'Sfera', 5)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Mago', N'Spada', 20)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'Mago', N'Spadone', 10)
INSERT [dbo].[Arma] ([Classe], [Nome], [PuntiDanno]) VALUES (N'SignoreDelMale', N'Trabucco', 10)
GO
INSERT [dbo].[Classe] ([Nome], [Hero]) VALUES (N'Cultista', 0)
INSERT [dbo].[Classe] ([Nome], [Hero]) VALUES (N'Guerriero', 1)
INSERT [dbo].[Classe] ([Nome], [Hero]) VALUES (N'Mago', 1)
INSERT [dbo].[Classe] ([Nome], [Hero]) VALUES (N'Orco', 0)
INSERT [dbo].[Classe] ([Nome], [Hero]) VALUES (N'SignoreDelMale', 0)
GO
INSERT [dbo].[Giocatore] ([Nome], [Ruolo]) VALUES (N'Carlo', N'Utente')
INSERT [dbo].[Giocatore] ([Nome], [Ruolo]) VALUES (N'Claude', N'Utente')
INSERT [dbo].[Giocatore] ([Nome], [Ruolo]) VALUES (N'Debo', N'Utente')
INSERT [dbo].[Giocatore] ([Nome], [Ruolo]) VALUES (N'Flo', N'Utente')
INSERT [dbo].[Giocatore] ([Nome], [Ruolo]) VALUES (N'Gino', N'Utente')
INSERT [dbo].[Giocatore] ([Nome], [Ruolo]) VALUES (N'Luca', N'Utente')
GO
INSERT [dbo].[Hero] ([Nome], [Classe], [Arma], [PuntiVita], [Livello], [PuntiAccumulati], [Giocatore]) VALUES (N'Ares', N'Mago', N'Spada', 20, 1, 0, N'Luca')
INSERT [dbo].[Hero] ([Nome], [Classe], [Arma], [PuntiVita], [Livello], [PuntiAccumulati], [Giocatore]) VALUES (N'Cagliostro', N'Mago', N'Spada', 20, 1, 0, N'Luca')
INSERT [dbo].[Hero] ([Nome], [Classe], [Arma], [PuntiVita], [Livello], [PuntiAccumulati], [Giocatore]) VALUES (N'Crocc', N'Guerriero', N'Lancia', 20, 1, 0, N'Luca')
INSERT [dbo].[Hero] ([Nome], [Classe], [Arma], [PuntiVita], [Livello], [PuntiAccumulati], [Giocatore]) VALUES (N'Fiona', N'Guerriero', N'Arco', 20, 1, 0, N'Carlo')
INSERT [dbo].[Hero] ([Nome], [Classe], [Arma], [PuntiVita], [Livello], [PuntiAccumulati], [Giocatore]) VALUES (N'Flora', N'Mago', N'Spadone', 20, 1, 0, N'Carlo')
INSERT [dbo].[Hero] ([Nome], [Classe], [Arma], [PuntiVita], [Livello], [PuntiAccumulati], [Giocatore]) VALUES (N'Frack', N'Mago', N'Sfera', 20, 1, 0, N'Carlo')
GO
INSERT [dbo].[Level] ([Livello], [PuntiVita]) VALUES (1, 20)
INSERT [dbo].[Level] ([Livello], [PuntiVita]) VALUES (2, 40)
INSERT [dbo].[Level] ([Livello], [PuntiVita]) VALUES (3, 60)
INSERT [dbo].[Level] ([Livello], [PuntiVita]) VALUES (4, 80)
INSERT [dbo].[Level] ([Livello], [PuntiVita]) VALUES (5, 100)
GO
INSERT [dbo].[Mostro] ([Nome], [Classe], [Arma], [PuntiVita], [Livello]) VALUES (N'Akuz', N'Orco', N'Balestra', 20, 1)
INSERT [dbo].[Mostro] ([Nome], [Classe], [Arma], [PuntiVita], [Livello]) VALUES (N'Khazad', N'SignoreDelMale', N'Balista', 20, 1)
INSERT [dbo].[Mostro] ([Nome], [Classe], [Arma], [PuntiVita], [Livello]) VALUES (N'Strong', N'Cultista', N'Razzo', 20, 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Arma]    Script Date: 19/03/2021 15:21:20 ******/
CREATE NONCLUSTERED INDEX [IX_Arma] ON [dbo].[Arma]
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Arma]  WITH CHECK ADD  CONSTRAINT [FK__Arma__Classe__286302EC] FOREIGN KEY([Classe])
REFERENCES [dbo].[Classe] ([Nome])
GO
ALTER TABLE [dbo].[Arma] CHECK CONSTRAINT [FK__Arma__Classe__286302EC]
GO
ALTER TABLE [dbo].[Hero]  WITH CHECK ADD  CONSTRAINT [FK__Hero__Classe__31EC6D26] FOREIGN KEY([Classe])
REFERENCES [dbo].[Classe] ([Nome])
GO
ALTER TABLE [dbo].[Hero] CHECK CONSTRAINT [FK__Hero__Classe__31EC6D26]
GO
ALTER TABLE [dbo].[Hero]  WITH CHECK ADD  CONSTRAINT [FK__Hero__Livello__33D4B598] FOREIGN KEY([Livello])
REFERENCES [dbo].[Level] ([Livello])
GO
ALTER TABLE [dbo].[Hero] CHECK CONSTRAINT [FK__Hero__Livello__33D4B598]
GO
ALTER TABLE [dbo].[Hero]  WITH CHECK ADD  CONSTRAINT [FK_Hero_Arma] FOREIGN KEY([Arma])
REFERENCES [dbo].[Arma] ([Nome])
GO
ALTER TABLE [dbo].[Hero] CHECK CONSTRAINT [FK_Hero_Arma]
GO
ALTER TABLE [dbo].[Hero]  WITH CHECK ADD  CONSTRAINT [FK_Hero_Giocatore] FOREIGN KEY([Giocatore])
REFERENCES [dbo].[Giocatore] ([Nome])
GO
ALTER TABLE [dbo].[Hero] CHECK CONSTRAINT [FK_Hero_Giocatore]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK__Mostro__Classe__2D27B809] FOREIGN KEY([Classe])
REFERENCES [dbo].[Classe] ([Nome])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK__Mostro__Classe__2D27B809]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK__Mostro__Livello__2F10007B] FOREIGN KEY([Livello])
REFERENCES [dbo].[Level] ([Livello])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK__Mostro__Livello__2F10007B]
GO
USE [master]
GO
ALTER DATABASE [Game] SET  READ_WRITE 
GO
