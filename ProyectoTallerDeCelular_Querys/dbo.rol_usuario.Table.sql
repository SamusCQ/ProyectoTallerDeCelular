USE [DbCelular]
GO
/****** Object:  Table [dbo].[rol_usuario]    Script Date: 22/11/2024 17:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol_usuario](
	[idUsuario] [int] NULL,
	[idRol] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[rol_usuario]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[ROL] ([idRol])
GO
ALTER TABLE [dbo].[rol_usuario]  WITH CHECK ADD  CONSTRAINT [FK__rol_usuar__idUsu__282DF8C2] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[USUARIO] ([idUsuario])
GO
ALTER TABLE [dbo].[rol_usuario] CHECK CONSTRAINT [FK__rol_usuar__idUsu__282DF8C2]
GO
