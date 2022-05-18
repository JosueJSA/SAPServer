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
CREATE PROCEDURE SPU_SAP_Producto
	-- Add the parameters for the stored procedure here
	@Codigo INT,
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
	IF EXISTS (SELECT * FROM [ProductoVenta] WHERE Codigo = @Codigo)
	BEGIN
		SET @CodigoReceta = ISNULL(@CodigoReceta, -1);
		BEGIN TRANSACTION;
			IF @CodigoReceta >= 0
			BEGIN 
				IF EXISTS (SELECT * FROM [Receta] WHERE Clave = @CodigoReceta)
				BEGIN
					UPDATE [ProductoVenta] SET
						CodigoReceta = @CodigoReceta,
						PrecioVenta = @PrecioVenta,
						PrecioCompra = @PrecioCompra,
						Cantidad = 1,
						Nombre = @Nombre,
						Foto = @Foto,
						Descripcion = @Descripcion,
						Restricciones = @Restricciones
					WHERE Codigo = @Codigo;
					SET @Key = @Codigo;
					SET @Message = 'Correcto'
				END
				ELSE
				BEGIN
					SET @Key = -1;
					SET @Message = 'La receta no se encontró registrada en el sistema'
				END
			END 
			ELSE
			BEGIN
				UPDATE [ProductoVenta] SET
					CodigoReceta = -1,
					PrecioVenta = @PrecioVenta,
					PrecioCompra = @PrecioCompra,
					Cantidad = @Cantidad,
					Nombre = @Nombre,
					Foto = @Foto,
					Descripcion = @Descripcion,
					Restricciones = @Restricciones
				WHERE Codigo = @Codigo;
				SET @Key = @Codigo;
				SET @Message = 'Correcto sin receta'
			END
		COMMIT TRANSACTION;
	END
	ELSE
	BEGIN
		SET @Key = -1;
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
