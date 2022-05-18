USE [SAPDataBase]
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
CREATE PROCEDURE [dbo].[SPG_SAP_ProductosComprados] 
	@IDPedido INT
AS
BEGIN
	SELECT Orden.*, ProductoVenta.Codigo, ProductoVenta.CodigoReceta, ProductoVenta.PrecioCompra, ProductoVenta.PrecioVenta, ProductoVenta.Cantidad stock, ProductoVenta.Nombre, ProductoVenta.Foto, ProductoVenta.Descripcion, ProductoVenta.Restricciones FROM [Orden] INNER JOIN [ProductoVenta] ON Orden.CodigoProductoVenta = ProductoVenta.Codigo AND Orden.CodigoPedido = @IDPedido;
END