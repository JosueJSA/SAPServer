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
CREATE PROCEDURE SPI_SAP_PedidoCliente
	-- Add the parameters for the stored procedure here
	@CostoTotal FLOAT,
	@Cantidad INT,
	@TipoPedido NVARCHAR(100),
	@IdCliente INT = NULL,
	@IdDireccion INT = NULL,
	@Key INT OUT,
	@Message NVARCHAR (MAX) OUT
AS
BEGIN TRY
	
	BEGIN TRANSACTION;
		INSERT INTO [Pedido] VALUES (
			@CostoTotal,
			'Ordenado',
			GETDATE(),
			GETDATE()
		)
		SET @Key = @@IDENTITY;
		SET @Message = 'Correcto'

		IF @TipoPedido = 'En establecimiento' 
		BEGIN
			INSERT INTO [PedidoCliente] VALUES (
				@Key,
				@Cantidad,
				@TipoPedido,
				NULL,
				NULL
			)
		END
		ELSE
		BEGIN 
			INSERT INTO [PedidoCliente] VALUES (
				@Key,
				@Cantidad,
				@TipoPedido,
				@IdCliente,
				@IdDireccion
			)
		END

	COMMIT TRANSACTION;
	
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
