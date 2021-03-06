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
CREATE PROCEDURE [dbo].[SPG_SAP_Usuario] 
	@Valor NVARCHAR (100) = NULL,
	@Status NVARCHAR (100)
AS
BEGIN
	IF @Valor IS NULL
	BEGIN
		Select * from [Empleado] where Status = @Status;
	END
	ELSE
	BEGIN
		Select * from [Empleado] where CONCAT(Nombre, Apellidos) like @Valor AND Status = @Status;
	END
END
