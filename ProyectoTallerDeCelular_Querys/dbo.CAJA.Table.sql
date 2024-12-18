USE [DbCelular]
GO
/****** Object:  Table [dbo].[CAJA]    Script Date: 22/11/2024 17:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAJA](
	[idNegocio] [int] NOT NULL,
	[nu_movim] [int] NOT NULL,
	[idCliente] [int] NOT NULL,
	[tx_concep] [varchar](100) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[va_saldo] [decimal](18, 0) NOT NULL,
	[bd_est] [int] NOT NULL,
	[fe_elimina] [datetime] NULL,
	[idUsuario_elimina] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[nu_movim] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CAJA] ADD  DEFAULT ((1)) FOR [bd_est]
GO
ALTER TABLE [dbo].[CAJA] ADD  DEFAULT (NULL) FOR [fe_elimina]
GO
ALTER TABLE [dbo].[CAJA]  WITH CHECK ADD  CONSTRAINT [FK__CAJA__idCliente__71D1E811] FOREIGN KEY([idCliente])
REFERENCES [dbo].[CLIENTE] ([idCliente])
GO
ALTER TABLE [dbo].[CAJA] CHECK CONSTRAINT [FK__CAJA__idCliente__71D1E811]
GO
ALTER TABLE [dbo].[CAJA]  WITH CHECK ADD FOREIGN KEY([idNegocio])
REFERENCES [dbo].[NEGOCIO] ([idNegocio])
GO
ALTER TABLE [dbo].[CAJA]  WITH CHECK ADD  CONSTRAINT [FK__CAJA__idUsuario__72C60C4A] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[USUARIO] ([idUsuario])
GO
ALTER TABLE [dbo].[CAJA] CHECK CONSTRAINT [FK__CAJA__idUsuario__72C60C4A]
GO
