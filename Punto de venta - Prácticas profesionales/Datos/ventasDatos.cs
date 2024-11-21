using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Punto_de_venta___Prácticas_profesionales.Lógica.VentasLogica;

namespace Punto_de_venta___Prácticas_profesionales.Datos
{
    internal class VentasDatos
    {

        string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

        // Método para obtener artículos filtrados por nombre
        public List<string> ObtenerArticulosPorFiltro(string filtro)
        {
            string connectionString = @"URI=file:" + databasePath;
            using var conn = new SQLiteConnection(connectionString);
            List<string> articulos = new List<string>();
            string query = "SELECT nombre FROM Articulos WHERE nombre LIKE @Filtro || '%'";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Filtro", filtro);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                articulos.Add(reader["nombre"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los artículos", ex);
            }

            return articulos;
        }

        public List<string> ObtenerVendedoresPorFiltro(string filtro)
        {
            string connectionString = @"URI=file:" + databasePath;
            using var conn = new SQLiteConnection(connectionString);
            List<string> vendedores = new List<string>();
            string query = "SELECT nombres FROM Vendedores WHERE nombres LIKE @Filtro || '%'";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Filtro", filtro);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vendedores.Add(reader["nombres"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los vendedores", ex);
            }

            return vendedores;
        }

        public List<string> ObtenerClientesPorFiltro(string filtro)
        {
            string connectionString = @"URI=file:" + databasePath;
            using var conn = new SQLiteConnection(connectionString);
            List<string> clientes = new List<string>();
            string query = "SELECT nombres FROM Clientes WHERE nombres LIKE @Filtro || '%'";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Filtro", filtro);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clientes.Add(reader["nombres"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los clientes", ex);
            }

            return clientes;
        }

        public bool ValidarStock(string nombre, int cantidad)
        {
            string connectionString = @"URI=file:" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Articulos WHERE nombre = @Nombre AND stock >= @Cantidad";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Cantidad", cantidad);

                    // Si el conteo es mayor a 0, significa que hay suficiente stock
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public Tuple<string, string, string, string> consulta_dgv(string nombre)
        {
            string connectionString = @"URI=file:" + databasePath;
            string query = "SELECT codigo, marca, rubro, precio_unitario FROM Articulos WHERE nombre LIKE @Filtro";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Agrega el parámetro con un patrón para la búsqueda
                        command.Parameters.AddWithValue("@Filtro", nombre + "%");

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Lee una fila
                            {
                                // Devuelve una tupla con los resultados
                                return Tuple.Create(reader["codigo"].ToString(), reader["marca"].ToString(), reader["rubro"].ToString(), reader["precio_unitario"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los datos", ex);
            }

            // Si no se encuentra ningún resultado, devuelve null
            return null;
        }

        public void RegistrarTransaccion(Transaccion transaccion)
        {
            string connectionString = @"URI=file:" + databasePath;
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO Ventas (fecha_hora, vendedor, cliente, metodo, total, activa) 
                             VALUES (@FechaHora, (SELECT CUIL FROM Vendedores WHERE nombres = @Vendedor), (SELECT CUIL FROM Clientes WHERE nombres = @Cliente), @MetodoPago, @Total, 1)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FechaHora", transaccion.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Vendedor", transaccion.Vendedor);
                    cmd.Parameters.AddWithValue("@Cliente", transaccion.Cliente);
                    cmd.Parameters.AddWithValue("@MetodoPago", transaccion.MetodoPago);
                    cmd.Parameters.AddWithValue("@Total", transaccion.Total);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int ObtenerNroFact()
        {
            string connectionString = @"URI=file:" + databasePath;
            using var conn = new SQLiteConnection(connectionString);
            string query = @"SELECT COALESCE((SELECT id_venta FROM Ventas ORDER BY id_venta DESC LIMIT 1), 0) + 1 AS siguiente_id_venta;";
            
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int siguienteId))
                        {
                            return siguienteId;
                        }
                        else
                        {
                            throw new Exception("Error al calcular el siguiente ID de venta.");
                        }
                    }
                }
            
            

        }

        //public void RegistrarDetallesVenta(List<detallesVenta> F)
        //{
        //    string connectionString = @"URI=file:" + databasePath;
        //    using (var conn = new SQLiteConnection(connectionString))
        //    {
        //        conn.Open();
        //        foreach (detallesVenta detallesVenta in F) {
        //            string query = @"INSERT INTO Detalles_ventas (id_venta, articulo, cantidad) 
        //                     VALUES ("+ Convert.ToInt32(detallesVenta.nroFact)+", "+ Convert.ToInt32(detallesVenta.codigo)+", "+ Convert.ToInt32(detallesVenta.cantidad)+")";
        //            SQLiteCommand command = new SQLiteCommand(query, conn);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}
        public void RegistrarDetallesVenta(List<detallesVenta> F)
        {
            string connectionString = @"URI=file:" + databasePath;
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();
                foreach (detallesVenta detallesVenta in F)
                {
                    using var transaction = conn.BeginTransaction();
                    try
                    {
                        string query = @"INSERT INTO Detalles_ventas (id_venta, articulo, cantidad) 
                             VALUES (" + Convert.ToInt32(detallesVenta.nroFact) + ", " + Convert.ToInt32(detallesVenta.codigo) + ", " + Convert.ToInt32(detallesVenta.cantidad) + ")";
                        SQLiteCommand command = new SQLiteCommand(query, conn);
                        command.ExecuteNonQuery();

                        string articulosquery = @"UPDATE Articulos SET stock = stock - " + Convert.ToInt32(detallesVenta.cantidad) + " WHERE codigo = " + Convert.ToInt32(detallesVenta.codigo) + "";
                        using var articuoscommand = new SQLiteCommand(articulosquery, conn, transaction);
                        articuoscommand.ExecuteNonQuery();

                        transaction.Commit();
                    }

                    catch (Exception ex)
                    {
                        // Revertir la transacción en caso de error
                        transaction.Rollback();
                        MessageBox.Show("No se ha podido registrar la venta. Problema con la base de datos: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión con la base de datos: " + ex.Message);
            }
        }


    }


}

