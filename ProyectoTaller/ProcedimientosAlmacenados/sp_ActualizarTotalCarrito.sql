CREATE PROCEDURE sp_ActualizarTotalCarrito
    @DNI_Vendedor INT
AS
BEGIN
    UPDATE Carrito
    SET Total = (SELECT SUM(SubTotal) FROM CarritoDetalle WHERE DNI_Vendedor = @DNI_Vendedor)
    WHERE DNI_Vendedor = @DNI_Vendedor
END
GO