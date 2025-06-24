CREATE PROCEDURE sp_AgregarProductoAlCarrito
    @DNI_Vendedor INT,
    @Modelo_Producto VARCHAR(50)
AS
BEGIN
    INSERT INTO CarritoDetalle (Cantidad, SubTotal, DNI_Vendedor, Producto)
    VALUES (
        1, 
        (SELECT Precio_Producto FROM Productos WHERE Modelo_Producto = @Modelo_Producto),
        @DNI_Vendedor, 
        @Modelo_Producto
    )
END
GO