
///
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Punto_de_venta___Prácticas_profesionales.Datos;

namespace Punto_de_venta___Prácticas_profesionales.Logica
{
    public class logicaArticulos
    {
        // Método para agregar un nuevo artículo


        public bool AgregarArticulo(string nombre, string marca, string rubro, double precio, int stock)
        {
            string insertQuery = "INSERT INTO Articulos (Nombre, Marca, Rubro, precio_unitario, Stock, Activo) VALUES (@Nombre, @Marca, @Rubro, @precio_unitario, @Stock, 1)";

            using (var connection = new SQLiteConnection(DatosArticuloscs.ConnectionString))
            {
                connection.Open();
                using (var insertCommand = new SQLiteCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@Nombre", nombre);
                    insertCommand.Parameters.AddWithValue("@Marca", marca);
                    insertCommand.Parameters.AddWithValue("@Rubro", rubro);
                    insertCommand.Parameters.AddWithValue("@precio_unitario", precio);
                    insertCommand.Parameters.AddWithValue("@Stock", stock);

                    try
                    {
                        insertCommand.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al agregar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }



        // Método para actualizar un artículo existente
        //public bool ActualizarArticulo(int codigo, string nombre, string marca, string rubro, double precio, int stock)
        //{
        //    string query = "UPDATE Articulos SET Nombre=@Nombre, Marca=@Marca, Rubro=@Rubro, precio_unitario=@precio_unitario, Stock=@Stock WHERE Codigo=@Codigo";

        //    using (var connection = new SQLiteConnection(DatosArticuloscs.ConnectionString))
        //    {
        //        connection.Open();
        //        using (var command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Codigo", codigo);
        //            command.Parameters.AddWithValue("@Nombre", nombre);
        //            command.Parameters.AddWithValue("@Marca", marca);
        //            command.Parameters.AddWithValue("@Rubro", rubro);
        //            command.Parameters.AddWithValue("@precio_unitario", precio);
        //            command.Parameters.AddWithValue("@Stock", stock);

        //            try
        //            {
        //                return command.ExecuteNonQuery() > 0;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Error al actualizar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }
        //        }
        //    }
        //}
        public bool ActualizarArticulo(int codigo, string? nombre, string? marca, string? rubro, double precio, int stock)
        {
            if (codigo <= 0)
            {
                return false; // Evitar actualizaciones con un código inválido
            }

            // Query para actualizar solo los campos permitidos (excepto "Codigo")
            string query = "UPDATE Articulos SET Nombre=@Nombre, Marca=@Marca, Rubro=@Rubro, Precio_Unitario=@Precio, Stock=@Stock WHERE Codigo=@Codigo";

            using (var connection = new SQLiteConnection(DatosArticuloscs.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    command.Parameters.AddWithValue("@Nombre", nombre ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Marca", marca ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Rubro", rubro ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Precio", precio);
                    command.Parameters.AddWithValue("@Stock", stock);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }




        // Método para deshabilitar un artículo
        public bool DeshabilitarArticulo(int codigo)
        {
            string query = "UPDATE Articulos SET Activo = 0 WHERE Codigo = @Codigo";

            using (var connection = new SQLiteConnection(DatosArticuloscs.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigo);

                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al deshabilitar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        // Método para habilitar un artículo
        public bool HabilitarArticulo(int codigo)
        {
            string query = "UPDATE Articulos SET Activo = 1 WHERE Codigo = @Codigo AND Activo = 0";

            using (var connection = new SQLiteConnection(DatosArticuloscs.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigo);

                    try
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al habilitar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        // Método para buscar artículos por criterio general
        public DataTable BuscarArticulos(string criterio)
        {
            string query = @"SELECT * FROM Articulos WHERE (Codigo LIKE @Criterio OR Nombre LIKE @Criterio) AND Activo = 1";

            using (var connection = new SQLiteConnection(DatosArticuloscs.ConnectionString))
            {
                var dataAdapter = new SQLiteDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        // Método para buscar artículos por un campo específico
        public DataTable BuscarArticulosPorCampo(string criterio, string campo)
        {
            string query = string.Empty;

            switch (campo)
            {
                case "Nombre":
                    query = "SELECT * FROM Articulos WHERE Nombre LIKE @Criterio AND Activo = 1";
                    break;
                case "Marca":
                    query = "SELECT * FROM Articulos WHERE Marca LIKE @Criterio AND Activo = 1";
                    break;
                case "Rubro":
                    query = "SELECT * FROM Articulos WHERE Rubro LIKE @Criterio AND Activo = 1";
                    break;
                default:
                    return new DataTable();
            }

            using (var connection = new SQLiteConnection(DatosArticuloscs.ConnectionString))
            {
                var dataAdapter = new SQLiteDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        // Método para buscar en todos los campos
        public DataTable BuscarArticulosEnTodosLosCampos(string criterio)
        {
            string query = @"SELECT * FROM Articulos 
                             WHERE (Nombre LIKE @Criterio OR Marca LIKE @Criterio OR Rubro LIKE @Criterio) 
                             AND Activo = 1";

            using (var connection = new SQLiteConnection(DatosArticuloscs.ConnectionString))
            {
                var dataAdapter = new SQLiteDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        //
        public bool ArticuloDeshabilitadoExiste(string nombre, string marca, out int codigo)
        {
            string query = "SELECT Codigo FROM Articulos WHERE Nombre = @Nombre AND Marca = @Marca AND Activo = 0";
            codigo = 0;

            using (var connection = new SQLiteConnection(DatosArticuloscs.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Marca", marca);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        codigo = Convert.ToInt32(result); // Obtener el código del artículo deshabilitado
                        return true;
                    }
                }
            }
            return false;
        }


        // Método para cargar los artículos (activos o inactivos)
        public DataTable CargarArticulos(bool activos = true)
        {
            string query = activos ? "SELECT * FROM Articulos WHERE Activo = 1" : "SELECT * FROM Articulos WHERE Activo = 0";

            using (var connection = new SQLiteConnection(DatosArticuloscs.ConnectionString))
            {
                var dataAdapter = new SQLiteDataAdapter(query, connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
