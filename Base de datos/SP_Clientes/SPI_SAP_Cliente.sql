USE [SAPDataBase]
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
CREATE PROCEDURE SPI_SAP_Cliente
	-- Add the parameters for the stored procedure here
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
	IF NOT EXISTS (SELECT * FROM [Cliente] WHERE Email = ISNULL(@Email, 'null'))
	BEGIN
		BEGIN TRANSACTION;
			INSERT INTO [Cliente] VALUES (
				ISNULL(@Email,'None'),
				@CodigoPostal,
				@Nombre,
				@Apellido,
				'Activo',
				@Telefono, 
				@Ciudad,
				@Nacimiento,
				DATEDIFF(YEAR, @Nacimiento, GETDATE())
			)
			SET @Key = @@IDENTITY;
			SET @Message = 'Correcto'
		COMMIT TRANSACTION;
	END
	ELSE 
	BEGIN 
		SET @Key = -1;
		SET @Message = 'El Email del Cliente ya ha sido utilizado'
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
