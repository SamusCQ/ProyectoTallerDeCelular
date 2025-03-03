USE [DbCelular]
GO
/****** Object:  Table [dbo].[TECNICO]    Script Date: 22/11/2024 17:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TECNICO](
	[idTecnico] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[nu_cedula] [varchar](10) NOT NULL,
	[nu_celular] [varchar](10) NULL,
	[correo] [varchar](100) NOT NULL,
	[bd_est] [int] NOT NULL,
	[nombre_completo]  AS (([apellido]+' ')+[nombre]),
PRIMARY KEY CLUSTERED 
(
	[idTecnico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__TECNICO__nu_cedula] UNIQUE NONCLUSTERED 
(
	[nu_cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TECNICO] ADD  DEFAULT ((1)) FOR [bd_est]
GO
