CREATE PROCEDURE sp_ActualizarStockProducto
    @Modelo_Producto VARCHAR(50)
AS
BEGIN
    UPDATE Productos
    SET Stock_Producto = Stock_Producto - 1
    WHERE Modelo_Producto = @Modelo_Producto AND Stock_Producto > 0
END
GO