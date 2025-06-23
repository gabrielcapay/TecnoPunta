using ProyectoTaller.CDatos;
using ProyectoTaller.CModelos;
using ProyectoTaller.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller.CNegocio
{
    public class ProductoNegocio
    {
        private ProductoDatosPA productosDatos;

        public bool stockDisponible(string modelo)
        {
            productosDatos = new ProductoDatosPA();
            
            return productosDatos.stockDisponible(modelo);
        }

        public void DisminuirStock(string modeloProducto)
        {
            productosDatos = new ProductoDatosPA();

            productosDatos.DisminuirStock(modeloProducto);
        }

        public List<ProductoDTO> cargarProductos() { 
            List<ProductoDTO> listaProductos = new List<ProductoDTO>();
            productosDatos = new ProductoDatosPA();

            foreach (var p in productosDatos.buscarProductos())
            {
                ProductoDTO productoDTO = new ProductoDTO
                {
                    Modelo = p.Modelo_Producto,
                    Nombre = p.Nombre_Producto,
                    SistemaOperativo = p.SistemaOperativo_Producto,
                    Almacenamiento = p.Almacenamiento_Producto,
                    Ram = p.Ram_Producto,
                    Precio = p.Precio_Producto,
                    Stock = p.Stock_Producto,
                    Marca = p.Marca?.Nombre_Marca,
                    Condicion = p.Condicion?.Descripcion_Condicion
                };

                listaProductos.Add(productoDTO); 
            }

            return listaProductos;

        }

        public List<ProductoDTO> listarProductosConStock()
        {
            List<ProductoDTO> listaProductos = new List<ProductoDTO>();
            productosDatos = new ProductoDatosPA();

            foreach (var p in productosDatos.buscarProductos())
            {
                if (p.Stock_Producto > 0 && p.Condicion.Descripcion_Condicion == "ACTIVO")
                {
                    ProductoDTO productoDTO = new ProductoDTO
                    {
                        Modelo = p.Modelo_Producto,
                        Nombre = p.Nombre_Producto,
                        SistemaOperativo = p.SistemaOperativo_Producto,
                        Almacenamiento = p.Almacenamiento_Producto,
                        Ram = p.Ram_Producto,
                        Precio = p.Precio_Producto,
                        Stock = p.Stock_Producto,
                        Marca = p.Marca?.Nombre_Marca,
                        
                    };

                    listaProductos.Add(productoDTO);
                }
                
            }

            return listaProductos;

        }

        public void actualizarProducto(Producto producto)
        {
            productosDatos = new ProductoDatosPA();
            productosDatos.modificarProducto(producto);   

        }

        public void guardarProducto(Producto producto)
        {
            productosDatos = new ProductoDatosPA();
            productosDatos.registrarProducto(producto);
            
        }

        public Producto buscarProductoBYID(string modelo)
        {
            productosDatos = new ProductoDatosPA();
            return productosDatos.buscarProductoByID(modelo);
        }

        public void validarDatos(Producto producto)
        {
            ProductoDatosPA productoDatos = new ProductoDatosPA();
            productoDatos.validarProducto(producto);
        }

        public void modificarEstadoProducto(string modeloProducto)
        {
            ProductoDatosPA productoDatos = new ProductoDatosPA();
            productoDatos.cambiarEstadoProducto(modeloProducto);
        }
    }
}
