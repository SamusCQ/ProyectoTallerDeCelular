USE [DbCelular]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetClientes]    Script Date: 22/11/2024 17:10:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetClientes]
AS
BEGIN
    SELECT idCliente, nombre, apellido, nu_cedula, nu_celular, correo, bd_est, nombre_completo 
    FROM CLIENTE 
    WHERE bd_est = 1;
END
GO
