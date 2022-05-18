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
CREATE PROCEDURE [dbo].[SPG_SAP_PedidosCliente] 
	@Criterio NVARCHAR (100) = NULL,
	@Fecha DATETIME = NULL
AS
BEGIN
	IF @Criterio = 'Todos'
	BEGIN
		SELECT * FROM [Pedidos] WHERE [Solicitud] >= ISNULL(@Fecha, Solicitud) ORDER BY Pedidos.Solicitud DESC;
	END
	ELSE
	BEGIN
		SELECT * FROM [Pedidos] WHERE [TipoPedido] = @Criterio AND [Solicitud] >= ISNULL(@Fecha, Solicitud) ORDER BY Pedidos.Solicitud DESC;
	END
END