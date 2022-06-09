USE [SAPDataBase]
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
CREATE PROCEDURE [dbo].[SPG_SAP_Proveedor] 
	@Criterio NVARCHAR (50) = NULL,
	@Valor NVARCHAR (100) = NULL,
	@Status NVARCHAR (100)
AS
BEGIN
	IF @Criterio = 'Nombre'
	BEGIN
		SELECT * FROM [Proveedor] WHERE (
			[Nombre] = CAST(@Valor AS INT) AND 
			[Status] = @Status
		);
	END
	IF @Criterio = 'Categoria Insumo'
	BEGIN
		SELECT * FROM [Proveedor] WHERE (
			[CategoriaInsumo] = CAST(@Valor AS INT) AND 
			[Status] = @Status
		);
	END
	IF @Criterio = 'RFC'
	BEGIN
		SELECT * FROM [Proveedor] WHERE (
			[Rfc] = CAST(@Valor AS INT) AND 
			[Status] = @Status
		);
	END
	ELSE
	BEGIN
		SELECT * FROM [Proveedor] WHERE (
			[Nombre] like ISNULL(@Valor, Nombre) AND 
			[Status] = @Status
		);
	END;
END
