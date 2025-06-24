CREATE PROCEDURE sp_ActualizarCantidadProductoEnCarrito
    @DNI_Vendedor INT,
    @Modelo_Producto VARCHAR(50)
AS
BEGIN
    UPDATE CarritoDetalle 
    SET Cantidad = Cantidad + 1,
        SubTotal = (Cantidad + 1) * (SELECT Precio_Producto FROM Productos WHERE Modelo_Producto = @Modelo_Producto)
    WHERE DNI_Vendedor = @DNI_Vendedor AND Producto = @Modelo_Producto
END
GO