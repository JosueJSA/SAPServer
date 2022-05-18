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
CREATE PROCEDURE SPI_SAP_ProductoVenta
	-- Add the parameters for the stored procedure 
	@CodigoReceta INT = NULL,
	@PrecioVenta FLOAT,
	@PrecioCompra FLOAT,
	@Cantidad INT,
    @Nombre NVARCHAR (100),
    @Foto NVARCHAR (500),
    @Descripcion NVARCHAR (500),
    @Restricciones NVARCHAR (500),
	@Key INT OUT,
	@Message NVARCHAR (MAX) OUT
AS
BEGIN TRY
	IF NOT EXISTS (SELECT * FROM [ProductoVenta] WHERE Nombre = @Nombre)
	BEGIN
		BEGIN TRANSACTION;
			SET @CodigoReceta = ISNULL(@CodigoReceta, -1);
			IF @CodigoReceta >= 0 
			BEGIN
				IF EXISTS (SELECT * FROM [Receta] WHERE Clave = @CodigoReceta)
				BEGIN
					INSERT INTO [ProductoVenta] VALUES (
						@CodigoReceta,
						@PrecioVenta,
						@PrecioCompra,
						1,
						@Nombre,
						@Foto,
						@Descripcion,
						@Restricciones,
						'Activo',
						GETDATE()
					)
					SET @Key = @@IDENTITY;
					SET @Message = 'Correcto'
				END
				ELSE
				BEGIN
					SET @Key = -1;
					SET @Message = 'No se encontró la receta para guardar el producto'
				END
				
			END
			ELSE
			BEGIN
				INSERT INTO [ProductoVenta] VALUES (
					-1,
					@PrecioVenta,
					@PrecioCompra,
					@Cantidad,
					@Nombre,
					@Foto,
					@Descripcion,
					@Restricciones,
					'Activo',
					GETDATE()
				)
				SET @Key = @@IDENTITY;
				SET @Message = 'Correcto sin receta'
			END
		COMMIT TRANSACTION;
	END
	ELSE 
	BEGIN 
		SET @Key = -1;
		SET @Message = 'El nombre del producto ya ha sido utilizado'
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
