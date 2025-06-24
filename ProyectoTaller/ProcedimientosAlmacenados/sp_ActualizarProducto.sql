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
CREATE PROCEDURE sp_ActualizarProducto
    @Modelo_Producto NVARCHAR(50),
    @Nombre_Producto NVARCHAR(100),
    @SistemaOperativo_Producto NVARCHAR(100),
    @Almacenamiento_Producto NVARCHAR(50),
    @Ram_Producto NVARCHAR(50),
    @Stock_Producto INT,
    @Precio_Producto DECIMAL(18, 2),
    @Id_Marca INT,
    @Id_Condicion INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Productos
    SET 
        Nombre_Producto = @Nombre_Producto,
        SistemaOperativo_Producto = @SistemaOperativo_Producto,
        Almacenamiento_Producto = @Almacenamiento_Producto,
        Ram_Producto = @Ram_Producto,
        Stock_Producto = @Stock_Producto,
        Precio_Producto = @Precio_Producto,
        Id_Marca = @Id_Marca,
        Id_Condicion = @Id_Condicion
    WHERE 
        Modelo_Producto = @Modelo_Producto;
END;
GO
