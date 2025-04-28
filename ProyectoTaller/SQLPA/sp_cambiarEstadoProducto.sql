CREATE PROCEDURE sp_cambiarEstadoProducto
    @Modelo_Producto NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Productos WHERE Modelo_Producto = @Modelo_Producto)
    BEGIN
      
        UPDATE Productos
        SET id_Condicion= 
            CASE 
                WHEN id_Condicion= 1 THEN 2 
                WHEN id_Condicion= 2 THEN 1  
                ELSE id_Condicion
            END
        WHERE Modelo_Producto = @Modelo_Producto;
    END
    ELSE
    BEGIN
        RAISERROR('No se encontró el producto con el modelo proporcionado.', 16, 1);
    END
END
GO