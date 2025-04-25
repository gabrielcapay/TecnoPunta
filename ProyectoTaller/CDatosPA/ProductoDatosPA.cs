using ProyectoTaller.CModelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTaller.CDatos
{
    public class ProductoDatosPA
    {
        private ConexionBD conexion = new ConexionBD();
        public List<Producto> ObtenerProductos(){

            List<Producto> listaProducto = new List<Producto>();
            
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                string query = "sp_ObtenerProductos";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        Modelo_Producto = reader["Modelo_Producto"].ToString(),
                        Nombre_Producto = reader["Nombre_Producto"].ToString(),
                        SistemaOperativo_Producto = reader["SistemaOperativo_Producto"].ToString(),
                        Almacenamiento_Producto = reader["Almacenamiento_Producto"].ToString(),
                        Ram_Producto = reader["Ram_Producto"].ToString(),
                        Stock_Producto = Convert.ToInt32(reader["Stock_Producto"]),
                        Precio_Producto = Convert.ToDecimal(reader["Precio_Producto"]),

                        // Asignar las propiedades de Marca y Condicion
                        Marca = new Marca
                        {
                            Id_Marca = Convert.ToInt32(reader["Id_Marca"]),
                            Nombre_Marca = reader["Nombre_Marca"]?.ToString()
                        },
                        Condicion = new Condicion
                        {
                            Id_Condicion = Convert.ToInt32(reader["Id_Condicion"]),
                            Descripcion_Condicion = reader["Descripcion_Estado"]?.ToString()
                        }
                    };
                    listaProducto.Add(producto);
                }
            }

             return listaProducto;
        }

        public void guardarProducto(Producto producto)
        {


            try
            {
                using (SqlConnection connection = conexion.ObtenerConexion())
                {
                    string query = "sp_GuardarProducto";

                    SqlCommand command = new SqlCommand(query, connection);         
                    command.CommandType= CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Modelo", producto.Modelo_Producto);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre_Producto);
                    command.Parameters.AddWithValue("@SistemaOperativo", producto.SistemaOperativo_Producto);
                    command.Parameters.AddWithValue("@Almacenamiento", producto.Almacenamiento_Producto + " GB");
                    command.Parameters.AddWithValue("@Ram", producto.Ram_Producto);
                    command.Parameters.AddWithValue("@Stock", producto.Stock_Producto);
                    command.Parameters.AddWithValue("@Precio", producto.Precio_Producto);
                    command.Parameters.AddWithValue("@IdMarca", producto.Marca.Id_Marca);
                    command.Parameters.AddWithValue("@IdCondicion", producto.Condicion.Id_Condicion);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            } catch (SqlException ex)
            {
                MessageBox.Show("No se puede guardar el producto. Ya existe un producto con el mismo modelo.",
                              "Error de inserción",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);


            }
        }

        public void ActualizarProducto(Producto producto)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                string query = "sp_ActualizarProducto";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre_Producto", producto.Nombre_Producto);
                    command.Parameters.AddWithValue("@SistemaOperativo_Producto", producto.SistemaOperativo_Producto);
                    command.Parameters.AddWithValue("@Almacenamiento_Producto", producto.Almacenamiento_Producto + "GB");
                    command.Parameters.AddWithValue("@Ram_Producto", producto.Ram_Producto + "GB");
                    command.Parameters.AddWithValue("@Stock_Producto", producto.Stock_Producto);
                    command.Parameters.AddWithValue("@Precio_Producto", producto.Precio_Producto);
                    command.Parameters.AddWithValue("@Id_Marca", producto.Marca?.Id_Marca);
                    command.Parameters.AddWithValue("@Id_Condicion", producto.Condicion?.Id_Condicion); 
                    command.Parameters.AddWithValue("@Modelo_Producto", producto.Modelo_Producto);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }   

        }

        public Producto buscarProductoByID(string modelo)
        {
            Producto producto = null;

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                string query = "sp_BuscarProductoPorModelo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@modelo", modelo);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            producto = new Producto
                            {
                                Modelo_Producto = reader["Modelo_Producto"].ToString(),
                                Nombre_Producto = reader["Nombre_Producto"].ToString(),
                                SistemaOperativo_Producto = reader["SistemaOperativo_Producto"].ToString(),
                                Almacenamiento_Producto = reader["Almacenamiento_Producto"].ToString(),
                                Ram_Producto = reader["Ram_Producto"].ToString(),
                                Stock_Producto = Convert.ToInt32(reader["Stock_Producto"]),
                                Precio_Producto = Convert.ToDecimal(reader["Precio_Producto"]),

                        
                                Marca = new Marca
                                {
                                    Id_Marca = Convert.ToInt32(reader["Id_Marca"]),
                                    Nombre_Marca = reader["Nombre_Marca"]?.ToString()
                                },
                                Condicion = new Condicion
                                {
                                    Id_Condicion = Convert.ToInt32(reader["Id_Condicion"]),
                                    Descripcion_Condicion = reader["Descripcion_Estado"]?.ToString()
                                }
                            };
                        }
                    }
                }
            }

            return producto;

        }
    }
}

