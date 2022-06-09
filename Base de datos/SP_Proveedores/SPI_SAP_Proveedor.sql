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
CREATE PROCEDURE SPI_SAP_Proveedor
	-- Add the parameters for the stored procedure here
	@Email NVARCHAR (500) = NULL,
	@Nombre NVARCHAR (100),
	@RFC NVARCHAR (100),
	@CategoriaInsumo NVARCHAR (100),
	@Telefono NVARCHAR (100),
	@Key INT OUT,
	@Message NVARCHAR (MAX) OUT
AS
BEGIN TRY
	IF NOT EXISTS (SELECT * FROM [Proveedor] WHERE Rfc = ISNULL(@RFC, 'null'))
	BEGIN
		BEGIN TRANSACTION;
			INSERT INTO [Proveedor] VALUES (
				@Email,
				@Nombre,
				ISNULL(@RFC,'None'),
				@CategoriaInsumo,
				'Activo',
				@Telefono 
			)
			SET @Key = @@IDENTITY;
			SET @Message = 'Correcto'
		COMMIT TRANSACTION;
	END
	ELSE 
	BEGIN 
		SET @Key = -1;
		SET @Message = 'El RFC del Proveedor ya ha sido utilizado'
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
