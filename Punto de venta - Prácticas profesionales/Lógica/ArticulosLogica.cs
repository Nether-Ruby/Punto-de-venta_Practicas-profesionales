using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Punto_de_venta___Prácticas_profesionales.Datos;

namespace Punto_de_venta___Prácticas_profesionales.Logica
{
    public class ArticuloService
    {
        public bool AgregarArticulo(string codigo, string nombre, string marca, string rubro, double precio, int stock)
        {
            string checkQuery = "SELECT COUNT(*) FROM Articulos WHERE Codigo = @Codigo AND Activo = 0";

            using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
            {
                connection.Open();
                using (var checkCommand = new SQLiteCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Codigo", codigo);
                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        // Reactivar el artículo si existe y está inactivo
                        string reactivateQuery = "UPDATE Articulos SET Activo = 1, Nombre = @Nombre, Marca = @Marca, Rubro = @Rubro, Precio = @Precio, Stock = @Stock WHERE Codigo = @Codigo";
                        using (var reactivateCommand = new SQLiteCommand(reactivateQuery, connection))
                        {
                            reactivateCommand.Parameters.AddWithValue("@Codigo", codigo);
                            reactivateCommand.Parameters.AddWithValue("@Nombre", nombre);
                            reactivateCommand.Parameters.AddWithValue("@Marca", marca);
                            reactivateCommand.Parameters.AddWithValue("@Rubro", rubro);
                            reactivateCommand.Parameters.AddWithValue("@Precio", precio);
                            reactivateCommand.Parameters.AddWithValue("@Stock", stock);
                            reactivateCommand.ExecuteNonQuery();
                        }
                        return true;
                    }
                    else
                    {
                        // Insertar el artículo si no existe
                        string insertQuery = "INSERT INTO Articulos (Codigo, Nombre, Marca, Rubro, Precio, Stock, Activo) VALUES (@Codigo, @Nombre, @Marca, @Rubro, @Precio, @Stock, 1)";
                        using (var insertCommand = new SQLiteCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@Codigo", codigo);
                            insertCommand.Parameters.AddWithValue("@Nombre", nombre);
                            insertCommand.Parameters.AddWithValue("@Marca", marca);
                            insertCommand.Parameters.AddWithValue("@Rubro", rubro);
                            insertCommand.Parameters.AddWithValue("@Precio", precio);
                            insertCommand.Parameters.AddWithValue("@Stock", stock);
                            insertCommand.ExecuteNonQuery();
                        }
                        return true;
                    }
                }

            }
        }

        //public void AgregarArticulo(string codigo, string nombre, string marca, string rubro, double precio, int stock)
        //{
        //    // Consulta SQL para insertar un artículo en la tabla Articulos
        //    string insertQuery = "INSERT INTO Articulos (Codigo, Nombre, Marca, Rubro, Precio, Stock, Activo) VALUES (@Codigo, @Nombre, @Marca, @Rubro, @Precio, @Stock, 1)";

        //    // Crear la conexión con la base de datos
        //    using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
        //    {
        //        try
        //        {
        //            // Abrir la conexión a la base de datos
        //            connection.Open();

        //            // Preparar el comando para la inserción
        //            using (var insertCommand = new SQLiteCommand(insertQuery, connection))
        //            {
        //                // Asignar valores a cada parámetro del comando SQL
        //                insertCommand.Parameters.AddWithValue("@Codigo", codigo);
        //                insertCommand.Parameters.AddWithValue("@Nombre", nombre);
        //                insertCommand.Parameters.AddWithValue("@Marca", marca);
        //                insertCommand.Parameters.AddWithValue("@Rubro", rubro);
        //                insertCommand.Parameters.AddWithValue("@Precio", precio);
        //                insertCommand.Parameters.AddWithValue("@Stock", stock);

        //                // Ejecutar el comando y verificar que se haya insertado una fila
        //                int rowsAffected = insertCommand.ExecuteNonQuery();
        //                if (rowsAffected > 0)
        //                {
        //                    MessageBox.Show("Artículo agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No se pudo agregar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //        }
        //        catch (SQLiteException ex)
        //        {
        //            // Manejo específico de errores de SQLite
        //            if (ex.Message.Contains("no such table"))
        //            {
        //                MessageBox.Show("Error: La tabla 'Articulos' no existe en la base de datos. Verifica la estructura de la base de datos.", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            else if (ex.Message.Contains("has no column named"))
        //            {
        //                MessageBox.Show("Error: Falta alguna columna en la tabla 'Articulos'. Verifica que todas las columnas estén definidas.", "Error de Estructura de Tabla", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            else if (ex.Message.Contains("UNIQUE constraint failed"))
        //            {
        //                MessageBox.Show("Error: Ya existe un artículo con el mismo código. Verifica el código del artículo.", "Error de Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                // Error genérico de SQLite
        //                MessageBox.Show($"Error al insertar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Manejo de cualquier otra excepción general
        //            MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        finally
        //        {
        //            // Cerrar la conexión si aún está abierta
        //            if (connection.State == ConnectionState.Open)
        //            {
        //                connection.Close();
        //            }
        //        }
        //    }
        //}


        public bool ActualizarArticulo(string codigo, string nombre, string marca, string rubro, double precio, int stock)
        {
            string query = "UPDATE Articulos SET Nombre=@Nombre, Marca=@Marca, Rubro=@Rubro, Precio=@Precio, Stock=@Stock WHERE Codigo=@Codigo";

            using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Marca", marca);
                    command.Parameters.AddWithValue("@Rubro", rubro);
                    command.Parameters.AddWithValue("@Precio", precio);
                    command.Parameters.AddWithValue("@Stock", stock);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeshabilitarArticulo(string codigo)
        {
            string query = "UPDATE Articulos SET Activo = 0 WHERE Codigo = @Codigo";

            using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        //public bool HabilitarArticulo(string codigo)
   public bool HabilitarArticulo(string codigo)
        {
            string query = "UPDATE Articulos SET Activo = 1 WHERE Codigo = @Codigo AND Activo = 0";

            try
            {
                using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Añade el valor del parámetro
                        command.Parameters.AddWithValue("@Codigo", codigo);

                        // Ejecuta la consulta de actualización
                        int rowsAffected = command.ExecuteNonQuery();

                        // Devuelve 'true' si se actualizó al menos una fila
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                MessageBox.Show($"Error al habilitar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public DataTable BuscarArticulos(string criterio)
        {
            string query = @"SELECT * FROM Articulos 
                     WHERE (Codigo LIKE @Criterio OR Nombre LIKE @Criterio) AND Activo = 1";

            using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
            {
                var dataAdapter = new SQLiteDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }



        //public DataTable BuscarArticulosPorCampo(string criterio, string campo)
        //{
        //    string query = string.Empty;

        //    // Determinar el campo de búsqueda basado en el criterio seleccionado
        //    switch (campo)
        //    {
        //        case "Código":
        //            // Asegúrate de que el campo Código se compare como un texto
        //            query = "SELECT * FROM Articulos WHERE Codigo = @Criterio AND Activo = 1";
        //            break;
        //        case "Nombre":
        //            query = "SELECT * FROM Articulos WHERE Nombre LIKE @Criterio AND Activo = 1";
        //            break;
        //        case "Marca":
        //            query = "SELECT * FROM Articulos WHERE Marca LIKE @Criterio AND Activo = 1";
        //            break;
        //        case "Rubro":
        //            query = "SELECT * FROM Articulos WHERE Rubro LIKE @Criterio AND Activo = 1";
        //            break;
        //        default:
        //            return new DataTable(); // Devuelve una tabla vacía si el campo no es válido
        //    }

        //    using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
        //    {
        //        var dataAdapter = new SQLiteDataAdapter(query, connection);

        //        // Usar un operador de comparación exacta para Código
        //        if (campo == "Código")
        //        {
        //            dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", criterio);
        //        }
        //        else
        //        {
        //            dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");
        //        }

        //        var dataTable = new DataTable();
        //        dataAdapter.Fill(dataTable);
        //        return dataTable;
        //    }
        //}

        public DataTable BuscarArticulosEnTodosLosCampos(string criterio)
        {
            string query = @"SELECT * FROM Articulos 
                     WHERE (Codigo LIKE @Criterio OR Nombre LIKE @Criterio OR Marca LIKE @Criterio) 
                     AND Activo = 1";

            using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
            {
                var dataAdapter = new SQLiteDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable BuscarArticulosPorCampo(string criterio, string campo)
        {
            string query = string.Empty;

            // Determinar el campo de búsqueda basado en el criterio seleccionado
            switch (campo)
            {
                case "Código":
                    query = "SELECT * FROM Articulos WHERE Codigo LIKE @Criterio AND Activo = 1";
                    break;
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
                    return new DataTable(); // Devuelve una tabla vacía si el campo no es válido
            }

            using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
            {
                var dataAdapter = new SQLiteDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }



        public DataTable CargarArticulos(bool activos = true)
        {
            string query = activos ? "SELECT * FROM Articulos WHERE Activo = 1" : "SELECT * FROM Articulos WHERE Activo = 0";

            using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
            {
                var dataAdapter = new SQLiteDataAdapter(query, connection);
                var dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
