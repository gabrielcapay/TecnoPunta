CREATE PROCEDURE sp_ValidarProducto
    @Modelo_Producto VARCHAR(100),
    @Nombre_Producto VARCHAR(100),
    @SistemaOperativo_Producto VARCHAR(100),
    @Almacenamiento_Producto VARCHAR(100),
    @Ram_Producto VARCHAR(100),
    @Stock_Producto INT,
    @Precio_Producto DECIMAL(10, 2),
    @Id_Marca INT = NULL,
    @Id_Condicion INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Validaciones de tipo y contenido

    IF @Modelo_Producto IS NULL OR LEN(@Modelo_Producto) = 0
    BEGIN
        RAISERROR('Campo "Modelo_Producto" es obligatorio.', 16, 1);
        RETURN;
    END

    IF @Nombre_Producto IS NULL OR LEN(@Nombre_Producto) = 0
    BEGIN
        RAISERROR('Campo "Nombre_Producto" es obligatorio. Debe contener letras y numeros', 16, 1);
        RETURN;
    END

    IF @SistemaOperativo_Producto IS NULL OR LEN(@SistemaOperativo_Producto) = 0
    BEGIN
        RAISERROR('Campo "SistemaOperativo_Producto" es obligatorio.', 16, 1);
        RETURN;
    END

    IF @Almacenamiento_Producto IS NULL OR LEN(@Almacenamiento_Producto) = 0
    BEGIN
        RAISERROR('Campo "Almacenamiento_Producto" es obligatorio. Tipo esperado: numero.', 16, 1);
        RETURN;
    END

    IF @Ram_Producto IS NULL OR LEN(@Ram_Producto) = 0
    BEGIN
        RAISERROR('Campo "Ram_Producto" es obligatorio. Tipo esperado: numero.', 16, 1);
        RETURN;
    END

    IF @Stock_Producto IS NULL OR @Stock_Producto < 0
    BEGIN
        RAISERROR('Campo "Stock_Producto" inválido. Debe ser numero y mayor o igual a 0.', 16, 1);
        RETURN;
    END

    IF @Precio_Producto IS NULL OR @Precio_Producto <= 0
    BEGIN
        RAISERROR('Campo "Precio_Producto" inválido. Debe ser un numero y mayor que 0.', 16, 1);
        RETURN;
    END

    IF @Id_Marca IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Marcas WHERE Id_Marca = @Id_Marca)
    BEGIN
        RAISERROR('El valor de "Id_Marca" no es válido.', 16, 1);
        RETURN;
    END


    PRINT 'Los datos del producto son válidos.';
END;
GO