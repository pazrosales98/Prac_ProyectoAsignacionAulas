CREATE DATABASE [Unicah]
go
USE [Unicah]
GO
/****** Object:  Table [dbo].[Aulas]    Script Date: 8/19/2022 9:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aulas](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](8) NOT NULL,
	[Ubicacion] [nvarchar](50) NOT NULL,
	[Estado] [char](3) NOT NULL,
 CONSTRAINT [PK_Aulas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaseDia]    Script Date: 8/19/2022 9:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaseDia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FkClasePeriodoId] [int] NOT NULL,
	[FkDiaId] [tinyint] NOT NULL,
 CONSTRAINT [PK_ClaseDia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClasePeriodo]    Script Date: 8/19/2022 9:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClasePeriodo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoraInicio] [time](4) NOT NULL,
	[HoraFin] [time](4) NOT NULL,
	[Dias] [nvarchar](170) NULL,
	[FKMaestroId] [smallint] NOT NULL,
	[FKPeriodoId] [int] NOT NULL,
	[FKClaseId] [int] NOT NULL,
	[FkAulaId] [smallint] NOT NULL,
 CONSTRAINT [PK_ClasePeriodo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clases]    Script Date: 8/19/2022 9:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](15) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Estado] [char](3) NOT NULL,
 CONSTRAINT [PK_Clases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dias]    Script Date: 8/19/2022 9:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dias](
	[Id] [tinyint] NOT NULL,
	[Dia] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Dias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maestros]    Script Date: 8/19/2022 9:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maestros](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Identidad] [nvarchar](20) NULL,
	[Estado] [char](3) NOT NULL,
 CONSTRAINT [PK_Maestros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periodos]    Script Date: 8/19/2022 9:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFin] [date] NOT NULL,
	[Estado] [char](3) NOT NULL,
 CONSTRAINT [PK_Periodos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 8/19/2022 9:47:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](30) NOT NULL,
	[Usuario] [nvarchar](15) NOT NULL,
	[Contrasenia] [nvarchar](max) NOT NULL,
	[EsAdmin] [bit] NOT NULL,
	[Estado] [char](3) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Clases]    Script Date: 8/19/2022 9:47:02 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Clases] ON [dbo].[Clases]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios]    Script Date: 8/19/2022 9:47:02 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Usuarios] ON [dbo].[Usuarios]
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClaseDia]  WITH CHECK ADD  CONSTRAINT [FK_ClaseDia_ClasePeriodo] FOREIGN KEY([FkClasePeriodoId])
REFERENCES [dbo].[ClasePeriodo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClaseDia] CHECK CONSTRAINT [FK_ClaseDia_ClasePeriodo]
GO
ALTER TABLE [dbo].[ClaseDia]  WITH CHECK ADD  CONSTRAINT [FK_ClaseDia_Dias] FOREIGN KEY([FkDiaId])
REFERENCES [dbo].[Dias] ([Id])
GO
ALTER TABLE [dbo].[ClaseDia] CHECK CONSTRAINT [FK_ClaseDia_Dias]
GO
ALTER TABLE [dbo].[ClasePeriodo]  WITH CHECK ADD  CONSTRAINT [FK_ClasePeriodo_Aulas] FOREIGN KEY([FkAulaId])
REFERENCES [dbo].[Aulas] ([Id])
GO
ALTER TABLE [dbo].[ClasePeriodo] CHECK CONSTRAINT [FK_ClasePeriodo_Aulas]
GO
ALTER TABLE [dbo].[ClasePeriodo]  WITH CHECK ADD  CONSTRAINT [FK_ClasePeriodo_Clases] FOREIGN KEY([FKClaseId])
REFERENCES [dbo].[Clases] ([Id])
GO
ALTER TABLE [dbo].[ClasePeriodo] CHECK CONSTRAINT [FK_ClasePeriodo_Clases]
GO
ALTER TABLE [dbo].[ClasePeriodo]  WITH CHECK ADD  CONSTRAINT [FK_ClasePeriodo_Maestros] FOREIGN KEY([FKMaestroId])
REFERENCES [dbo].[Maestros] ([Id])
GO
ALTER TABLE [dbo].[ClasePeriodo] CHECK CONSTRAINT [FK_ClasePeriodo_Maestros]
GO
ALTER TABLE [dbo].[ClasePeriodo]  WITH CHECK ADD  CONSTRAINT [FK_ClasePeriodo_Periodos] FOREIGN KEY([FKPeriodoId])
REFERENCES [dbo].[Periodos] ([Id])
GO
ALTER TABLE [dbo].[ClasePeriodo] CHECK CONSTRAINT [FK_ClasePeriodo_Periodos]
GO
INSERT INTO [dbo].[Dias] (Id,Dia) 
VALUES
	(1,'Lunes'),
	(2,'Martes'),
	(3,'Miércoles'),
	(4,'Jueves'), 
	(5,'Viernes'), 
	(7,'Sábado')
GO
INSERT INTO Usuarios (Nombre, Usuario, Contrasenia, EsAdmin, Estado)
VALUES ('Administrador', 'admin', '65acc365dadfe4ddb230e4c4cc2618ca6d4c64c6040847e89065d8908b7f2020', 1, 'ACT') 