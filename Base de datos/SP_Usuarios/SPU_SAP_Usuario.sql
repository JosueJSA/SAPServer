USE [SAPDataBase]
GO
/****** Object:  StoredProcedure [dbo].[SGI_SAP_Insumo]    Script Date: 5/4/2022 22:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SPU_SAP_Usuario
	-- Add the parameters for the stored procedure here
	@Clave INT,
	@Email NVARCHAR (500),
	@Password NVARCHAR (100),
	@Nombre NVARCHAR(100),
	@Apellido NVARCHAR (100),
	@TipoUsuario NVARCHAR (100),
	@CodigoPostal NVARCHAR (100), 
	@Status NVARCHAR (100),
	@Salario FLOAT,
	@Telefono NVARCHAR(100),
	@Ciudad NVARCHAR (100),
	@Key INT OUT,
	@Message NVARCHAR (MAX) OUT
AS
BEGIN TRY
	IF EXISTS (SELECT * FROM [Empleado] WHERE Clave = @Clave)
	BEGIN
		IF NOT EXISTS (SELECT * FROM [Empleado] WHERE Email = @Email) 
		BEGIN
		BEGIN TRANSACTION;
			UPDATE [Empleado] SET
				Email = @Email,
				Password = @Password,
				Nombre = @Nombre, 
				Apellidos = @Apellido,
				TipoUsuario = @TipoUsuario,
				CodigoPostal = @CodigoPostal,
				Status = @Status,
				Salario = @Salario,
				Telefono = @Telefono,
				Ciudad = @Ciudad
			WHERE Clave = @Clave;
			SET @Key = @Clave;
			SET @Message = 'Correcto'
		COMMIT TRANSACTION;
		END
		ELSE
		BEGIN
			SET @Key = -1;
			SET @Message = 'El correo utilizado ya ha sido utilizado por alguien mas'
		END
	END
	ELSE 
	BEGIN 
		SET @Key = -1;
		SET @Message = 'El usuario no se ha encontrado en la base de datos'
	END
END TRY
BEGIN CATCH
	SET @Key = -1;
	SET @Message = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + Char(10) +
		'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ' + Char(10) +
		'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10)) + '; ' + Char(10) +
		'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ' + Char(10) +
		'Error Message: ' + ERROR_MESSAGE()
	ROLLBACK TRANSACTION;
END CATCH
GO
