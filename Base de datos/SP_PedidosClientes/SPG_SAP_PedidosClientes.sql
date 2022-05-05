USE SAP;
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
CREATE PROCEDURE [dbo].[SPG_SAP_PedidosClientes] 
	@Criterio NVARCHAR (100) = NULL,
	@Valor NVARCHAR (100) = NULL,
	@Fecha DATETIME = NULL,
	@Status NVARCHAR (100)
AS
BEGIN
	IF @Criterio = 'Código'
	BEGIN
		SELECT * FROM [Pedidos] WHERE (
			[CodigoPedido] = CAST(@Valor AS INT) AND 
			[Solicitud] >= ISNULL(@Fecha, Solicitud) AND 
			[StatusPedido] = @Status
		);
	END
	ELSE IF @Criterio = 'Nombre/Apellidos'
	BEGIN
		SELECT * FROM [Pedidos] WHERE (
			[NombreCompleto] like ISNULL(@Valor, NombreCompleto) AND 
			[Solicitud] >= ISNULL(@Fecha, Solicitud) AND 
			[StatusPedido] = @Status
		);
	END
	ELSE IF @Criterio = 'Email' 
	BEGIN 
		SELECT * FROM [Pedidos] WHERE (
			[Email] like ISNULL (@Valor, Email) AND
			[Solicitud] >= ISNULL (@Fecha, Solicitud) AND
			[StatusPedido] = @Status
		);
	END
	ELSE IF @Criterio = 'Teléfono'
	BEGIN
		SELECT * FROM [Pedidos] WHERE (
			[Telefono] like ISNULL (@Valor, Telefono) AND
			[Solicitud] >= ISNULL (@Fecha, Solicitud) AND
			[StatusPedido] = @Status
		);
	END
	ELSE
	BEGIN
		SELECT * FROM [Pedidos] WHERE (
			[Solicitud] >= ISNULL (@Fecha, Solicitud) AND
			[StatusPedido] = @Status
		);
	END
END