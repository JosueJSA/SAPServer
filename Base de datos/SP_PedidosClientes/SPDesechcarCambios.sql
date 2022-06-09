-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SPU_SAP_CantidadInsumoIncremento
	@IdInsumo INT,
	@Cantidad INT,
	@Key INT OUT,
	@Message NVARCHAR (MAX) OUT
AS
BEGIN TRY
	IF EXISTS (SELECT * FROM Insumo WHERE Codigo = @IdInsumo)	
	BEGIN
		BEGIN TRANSACTION;
		UPDATE Insumo SET
			Cantidad = Cantidad + @Cantidad
		WHERE Codigo = @IdInsumo;
		COMMIT TRANSACTION;
		set @Key = @IdInsumo;
		set @Message = 'Isnumo actualizado'
	END
	ELSE
	BEGIN
		SET @Key = -1;
		SET @Message = 'El insumo no existe en el sistema'
	END
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION;
	SET @Key = -1;
	SET @Message = 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10)) + '; ' + Char(10) +
		'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10)) + '; ' + Char(10) +
		'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10)) + '; ' + Char(10) +
		'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10)) + '; ' + Char(10) +
		'Error Message: ' + ERROR_MESSAGE()
END CATCH
GO
