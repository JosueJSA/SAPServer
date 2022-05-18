USE [SAP]
GO
/****** Object:  StoredProcedure [dbo].[SPG_SAP_Insumo]    Script Date: 5/4/2022 13:09:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SPU_SAP_Cliente
	-- Add the parameters for the stored procedure here
	@Id INT,
	@Nombre NVARCHAR (500),
	@Apellido NVARCHAR (500),
	@CodigoPostal INT,
	@Telefono NVARCHAR (100),
	@Ciudad NVARCHAR (100),
	@Nacimiento DATETIME,
	@Email NVARCHAR (500) = NULL,
	@Key INT OUT,
	@Message NVARCHAR (MAX) OUT
AS
BEGIN TRY
	IF EXISTS (SELECT * FROM [Cliente] WHERE Id = @Id)
	BEGIN
		BEGIN TRANSACTION;
			UPDATE [Cliente] SET 
				Email = ISNULL(@Email,'None'),
				CodigoPostal = @CodigoPostal,
				Nombre = @Nombre,
				Apellido = @Apellido,
				Telefono = @Telefono, 
				Ciudad = @Ciudad,
				Nacimiento = @Nacimiento,
				Edad = DATEDIFF(YEAR, @Nacimiento, GETDATE())
			WHERE Id = @Id;
			SET @Key = @Id;
			SET @Message = 'Correcto'
		COMMIT TRANSACTION;
	END
	ELSE 
	BEGIN 
		SET @Key = -1;
		SET @Message = 'El Cliente no está registrado en la base de datos'
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
