USE [SAPDataBase]
GO  
CREATE VIEW PedidosDomicilio 
AS  
	SELECT Pedido.Codigo CodigoPedido, Pedido.CostoTotal, Pedido.Status StatusPedido, Pedido.Solicitud, Pedido.Entrega, Subquery.*, 
	(SELECT COUNT(*) FROM Orden WHERE CodigoPedido = Pedido.Codigo) NumeroProductos FROM Pedido 
	INNER JOIN (SELECT *, CONCAT(Cliente.Nombre, ' ', Cliente.Apellido) NombreCompleto FROM Cliente 
	INNER JOIN PedidoCliente ON Cliente.Id = PedidoCliente.IdCliente) Subquery ON Pedido.Codigo = Subquery.Codigo;
GO  
