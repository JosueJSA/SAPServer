USE SAP;   
GO  
CREATE VIEW Pedidos
AS  
	SELECT Pedido.*, PedidoCliente.Cantidad, PedidoCliente.TipoPedido, 
	(SELECT SUM(Cantidad) FROM Orden WHERE CodigoPedido = PedidoCliente.Codigo) NumeroProductos 
	FROM PedidoCliente INNER JOIN Pedido ON PedidoCliente.Codigo = Pedido.Codigo;
GO  
