USE [DbCelular]
GO
/****** Object:  Table [dbo].[NEGOCIO]    Script Date: 22/11/2024 17:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NEGOCIO](
	[idNegocio] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[correo] [varchar](100) NOT NULL,
	[bd_est] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[NEGOCIO] ADD  DEFAULT ((1)) FOR [bd_est]
GO
