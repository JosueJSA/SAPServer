USE SAP;   
GO  
CREATE VIEW Ingredientes  
AS  
	SELECT Aux.*, Insumo.Nombre NombreInsumo, Insumo.Cantidad CantidadInsumo, Insumo.Status StatusInsumo, Insumo.PrecioCompra PrecioInsumo, Insumo.UnidadMedida Unidad
	FROM [Insumo] INNER JOIN (SELECT AuxQuery.*, Ingrediente.CodigoInsumo CodigoInsumo, Ingrediente.Cantidad CantidadIngrediente 
	FROM [Ingrediente] INNER JOIN (Select Clave ClaveReceta, Codigo CodigoProducto, Cantidad CantidadProducto, Nombre NombreProducto  
	FROM [Receta] INNER JOIN [ProductoVenta] ON Receta.Clave = ProductoVenta.CodigoReceta) AuxQuery ON AuxQuery.ClaveReceta = Ingrediente.ClaveReceta) Aux ON Aux.CodigoInsumo = Insumo.Codigo;   
GO  
