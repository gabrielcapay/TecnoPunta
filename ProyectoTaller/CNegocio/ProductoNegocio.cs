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
        public List<ProductoDTO> listarProductos() { 
            List<ProductoDTO> listaProductos = new List<ProductoDTO>();
            productosDatos = new ProductoDatosPA();

            foreach (var p in productosDatos.ObtenerProductos())
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

            foreach (var p in productosDatos.ObtenerProductos())
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
            productosDatos.ActualizarProducto(producto);   

        }

        public void guardarProducto(Producto producto)
        {
            productosDatos = new ProductoDatosPA();
            productosDatos.guardarProducto(producto);
            
        }

        public Producto buscarProductoBYID(string modelo)
        {
            productosDatos = new ProductoDatosPA();
            return productosDatos.buscarProductoByID(modelo);
        }
    }
}
