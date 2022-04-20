USE [SAP]
GO
/****** Object:  StoredProcedure [dbo].[SPG_SAP_Insumo]    Script Date: 4/4/2022 22:59:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SPG_SAP_ProductoVenta] 
	@Criterio NVARCHAR (50) = NULL,
	@Valor NVARCHAR (100) = NULL,
	@Fecha DATETIME = NULL,
	@Status NVARCHAR (100)
AS
BEGIN
	IF @Criterio = 'Código'
	BEGIN
		SELECT * FROM [ProductoVenta] WHERE (
			[Codigo] = CAST(@Valor AS INT) AND 
			[Registro] >= ISNULL(@Fecha, Registro) AND 
			[Status] = @Status
		);
	END
	ELSE
	BEGIN
		SELECT * FROM [ProductoVenta] WHERE (
			[Nombre] like ISNULL(@Valor, Nombre) AND 
			[Registro] >= ISNULL(@Fecha, Registro) AND 
			[Status] = @Status
		);
	END;
END
