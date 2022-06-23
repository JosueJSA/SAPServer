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
	@Codigo INT = NULL,
	@Fecha DATETIME = NULL
AS
BEGIN
	SELECT * FROM Pedidos WHERE Codigo = ISNULL(@Codigo, Codigo) AND Solicitud >= ISNULL(@Fecha, Solicitud);
END