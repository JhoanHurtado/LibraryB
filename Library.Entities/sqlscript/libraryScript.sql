CREATE DATABASE library
GO

USE [library]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](60) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[CiudadProcedencia] [nvarchar](60) NOT NULL,
	[Email] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_Autors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editorials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](60) NOT NULL,
	[Telefono] [nvarchar](11) NOT NULL,
	[Email] [nvarchar](70) NOT NULL,
	[NLibros] [int] NOT NULL,
 CONSTRAINT [PK_Editorials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AutorId] [int] NOT NULL,
	[EditorialId] [int] NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Ano] [int] NOT NULL,
	[Genero] [nvarchar](60) NOT NULL,
	[Paginas] [int] NOT NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Editorials] ADD  CONSTRAINT [DF_Editorials_NLibros]  DEFAULT ((-1)) FOR [NLibros]
GO
ALTER TABLE [dbo].[Libros]  WITH CHECK ADD  CONSTRAINT [FK_Libros_Autors] FOREIGN KEY([AutorId])
REFERENCES [dbo].[Autors] ([Id])
GO
ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [FK_Libros_Autors]
GO
ALTER TABLE [dbo].[Libros]  WITH CHECK ADD  CONSTRAINT [FK_Libros_Editorials] FOREIGN KEY([EditorialId])
REFERENCES [dbo].[Editorials] ([Id])
GO
ALTER TABLE [dbo].[Libros] CHECK CONSTRAINT [FK_Libros_Editorials]
GO