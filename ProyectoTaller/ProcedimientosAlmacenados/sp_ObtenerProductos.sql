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
CREATE PROCEDURE sp_ObtenerProductos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Modelo_Producto,
        p.Nombre_Producto,
        p.SistemaOperativo_Producto,
        p.Almacenamiento_Producto,
        p.Ram_Producto,
        p.Stock_Producto,
        p.Precio_Producto,
        m.Id_Marca,
        m.Nombre_Marca,
        c.Id_Condicion,
        c.Descripcion_Estado
    FROM 
        Productos p
    LEFT JOIN Marcas m ON p.Id_Marca = m.Id_Marca
    LEFT JOIN Condicion c ON p.Id_Condicion = c.Id_Condicion
    ORDER BY 
        m.Nombre_Marca;
END;
GO
