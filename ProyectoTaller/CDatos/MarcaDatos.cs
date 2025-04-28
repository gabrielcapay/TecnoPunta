using ProyectoTaller.CModelos;
using ProyectoTaller.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTaller.CDatos
{
    public class MarcaDatos
    {
        private ConexionBD conexion = new ConexionBD();

        public List<Marca> buscarMarcas()
        {
            List<Marca> marcas = new List<Marca>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                string query = "SELECT Id_Marca, Nombre_Marca FROM Marcas"; 
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    marcas.Add(new Marca
                    {
                        Id_Marca = (int)reader["Id_Marca"],
                        Nombre_Marca = reader["Nombre_Marca"].ToString()
                    });
                }
            }

            return marcas;
        }
        public List<MarcaDTO> buscarMarcasMasVendidaPorFecha(DateTime desde, DateTime hasta)
        {
            List<MarcaDTO> marcasVendidas = new List<MarcaDTO>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                string query = @"
                        SELECT 
                            m.Nombre_Marca,
                            SUM(vd.Cantidad) AS TotalVendidas
                        FROM 
                            Venta v
                        JOIN 
                            VentaDetalle vd ON v.idVenta = vd.idVenta
                        JOIN 
                            Productos p ON vd.Producto = p.Modelo_Producto
                        JOIN 
                            Marcas m ON p.Id_Marca = m.Id_Marca
                        WHERE 
                            v.FechaVenta >= @FechaDesde 
                            AND v.FechaVenta < @FechaHasta 
                        GROUP BY 
                            m.Nombre_Marca
                        ORDER BY 
                            TotalVendidas DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Modificar para asegurar el rango correcto
                    command.Parameters.AddWithValue("@FechaDesde", desde);
                    command.Parameters.AddWithValue("@FechaHasta", hasta.AddDays(1)); 

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            marcasVendidas.Add(new MarcaDTO
                            {
                                nombre = reader["Nombre_Marca"].ToString(),
                                cantidad = Convert.ToInt32(reader["TotalVendidas"])
                            });
                        }
                    }
                }
            }

            return marcasVendidas;
        }
    }
}
