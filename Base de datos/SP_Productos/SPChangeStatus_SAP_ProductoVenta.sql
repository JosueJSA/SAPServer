USE [SAP]
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
CREATE PROCEDURE SPChangeStatus_SAP_ProductoVenta
	-- Add the parameters for the stored procedure here
	@Codigo INT,
	@Status NVARCHAR (100),
	@Key INT OUT,
	@Message NVARCHAR (MAX) OUT
AS
BEGIN TRY
	IF EXISTS (SELECT * FROM [ProductoVenta] WHERE Codigo = @Codigo)
	BEGIN
		BEGIN TRANSACTION;
			UPDATE [ProductoVenta] SET
				Status = @Status
			WHERE Codigo = @Codigo;
			SET @Key = @Codigo;
			SET @Message = 'Correcto'
		COMMIT TRANSACTION;
	END
	ELSE
	BEGIN
		SET @Key = -2;
		SET @Message = 'Producto no encontrado en la base de datos'
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
