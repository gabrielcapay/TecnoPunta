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
-- Author:		<Author,,Mac Lean Juan Manuel>
-- Create date: <Create Date,4/25/2025,>
-- Description:	<Description,GuardarProducto,>
-- =============================================
CREATE PROCEDURE sp_GuardarProducto
    @Modelo NVARCHAR(50),
    @Nombre NVARCHAR(100),
    @SistemaOperativo NVARCHAR(100),
    @Almacenamiento NVARCHAR(50),
    @Ram NVARCHAR(50),
    @Stock INT,
    @Precio DECIMAL(18, 2),
    @IdMarca INT,
    @IdCondicion INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO Productos (
            Modelo_Producto,
            Nombre_Producto,
            SistemaOperativo_Producto,
            Almacenamiento_Producto,
            Ram_Producto,
            Stock_Producto,
            Precio_Producto,
            Id_Marca,
            Id_Condicion
        )
        VALUES (
            @Modelo,
            @Nombre,
            @SistemaOperativo,
            @Almacenamiento,
            @Ram,
            @Stock,
            @Precio,
            @IdMarca,
            @IdCondicion
        );
    END TRY
    BEGIN CATCH
        -- Manejo básico del error
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
