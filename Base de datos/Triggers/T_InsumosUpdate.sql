USE [SAPDataBase]
GO
/****** Object:  Trigger [dbo].[SAP_Productos]    Script Date: 16/4/2022 18:26:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[SAP_ProductosQuantity] ON [dbo].[Insumo]
AFTER UPDATE
AS
DECLARE @Cantidad INT = 0;
DECLARE @Recorridos INT = 0;
DECLARE @id INT = 0;
SELECT @Recorridos = COUNT(*) FROM [ProductoVenta] WHERE CodigoReceta >= 0;

BEGIN TRANSACTION;
	CREATE TABLE #ProductoIDClone
	(
		IDProducto INT
	)
	INSERT INTO #ProductoIDClone SELECT Codigo FROM [ProductoVenta] WHERE CodigoReceta >= 0;
	SELECT @Recorridos = COUNT(*) FROM [#ProductoIDClone];
COMMIT TRANSACTION;

WHILE @Recorridos > 0
BEGIN
	SELECT TOP(1) @id = IDProducto FROM #ProductoIDClone;
	SELECT @Cantidad = MIN(QUERY.aux) FROM (SELECT FLOOR(CantidadInsumo/CantidadIngrediente) aux FROM [Ingredientes] WHERE CodigoProducto = @id) QUERY;
	UPDATE [ProductoVenta] set
		Cantidad = @Cantidad
	WHERE Codigo = @id;
	DELETE TOP (1) FROM #ProductoIDClone;
	SET @Recorridos -= 1;
END

DROP TABLE #ProductoIDClone;



