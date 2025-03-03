USE [DbCelular]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarCliente]    Script Date: 22/11/2024 17:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarCliente]
    @idCliente INT,
    @nombre NVARCHAR(50),
    @apellido NVARCHAR(50),
    @nu_cedula NVARCHAR(10),
    @nu_celular NVARCHAR(10),
    @correo NVARCHAR(50)
AS
BEGIN
    UPDATE CLIENTE 
    SET nombre = @nombre, apellido = @apellido, nu_cedula = @nu_cedula, nu_celular = @nu_celular, correo = @correo 
    WHERE idCliente = @idCliente;
END
GO
