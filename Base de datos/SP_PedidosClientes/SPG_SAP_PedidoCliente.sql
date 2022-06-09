USE SAPDataBase
GO
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
CREATE PROCEDURE SPG_SAP_PedidoCliente
	@CodigoPedido INT
AS
BEGIN
	SELECT P.Codigo, P.CostoTotal, P.Status StatusPedido, P.Solicitud, P.Entrega, PC.Cantidad, PC.TipoPedido, PC.IdCliente IdClientePedido, PC.IdDireccion, PC.MotivoCancelacion, 
	C.Id IdClientePropio, C.Email, C.CodigoPostal, C.Nombre, C.Apellido, C.Status StatusCliente, C.Telefono, C.Ciudad,
	C.Nacimiento, C.Edad,  CD.* FROM Pedido P INNER JOIN PedidoCliente PC ON P.Codigo = PC.Codigo
	LEFT JOIN Cliente C ON PC.IdCliente = C.Id LEFT JOIN [Cliente.Direccion] CD
	ON PC.IdCliente = CD.Id WHERE P.Codigo = ISNULL(@CodigoPedido, P.Codigo);
END
GO
