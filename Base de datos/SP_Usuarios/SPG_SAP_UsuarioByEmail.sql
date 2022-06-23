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
CREATE PROCEDURE [dbo].[SPG_SAP_UsuarioEmail] 
	@Email NVARCHAR (MAX),
	@Password NVARCHAR (max)
AS
BEGIN
	Select * from Empleado where Email = @Email and Password = @Password;
END
