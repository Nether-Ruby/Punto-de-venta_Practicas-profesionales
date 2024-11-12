////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;


////using System.Data;
////using System.Data.SQLite;
////using System.Windows.Forms;
////using Punto_de_venta___Prácticas_profesionales.Datos;

////namespace Punto_de_venta___Prácticas_profesionales.Logica
////{
////    public class ArticulosLogica
////    {



////        //public bool AgregarArticulo(string codigo, string nombre, string marca, string rubro, double precio, int stock)
////        //{
////        //    string checkQuery = "SELECT COUNT(*) FROM Articulos WHERE Codigo = @Codigo AND Activo = 0";

////        //    using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
////        //    {
////        //        connection.Open();

////        //        // Verificar si el artículo ya existe pero está desactivado
////        //        using (var checkCommand = new SQLiteCommand(checkQuery, connection))
////        //        {
////        //            checkCommand.Parameters.AddWithValue("@Codigo", codigo);
////        //            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

////        //            if (count > 0)
////        //            {
////        //                // Mostrar un cuadro de diálogo para confirmar si se desea reactivar el artículo
////        //                var result = MessageBox.Show(
////        //                    "El artículo con este código ya existe pero está desactivado. ¿Desea reactivarlo?",
////        //                    "Confirmar Reactivación",
////        //                    MessageBoxButtons.YesNo,
////        //                    MessageBoxIcon.Question);

////        //                if (result == DialogResult.Yes)
////        //                {
////        //                    // Reactivar el artículo si el usuario confirma
////        //                    string reactivateQuery = "UPDATE Articulos SET Activo = 1, Nombre = @Nombre, Marca = @Marca, Rubro = @Rubro, Precio = @Precio, Stock = @Stock WHERE Codigo = @Codigo";
////        //                    using (var reactivateCommand = new SQLiteCommand(reactivateQuery, connection))
////        //                    {
////        //                        reactivateCommand.Parameters.AddWithValue("@Codigo", codigo);
////        //                        reactivateCommand.Parameters.AddWithValue("@Nombre", nombre);
////        //                        reactivateCommand.Parameters.AddWithValue("@Marca", marca);
////        //                        reactivateCommand.Parameters.AddWithValue("@Rubro", rubro);
////        //                        reactivateCommand.Parameters.AddWithValue("@Precio", precio);
////        //                        reactivateCommand.Parameters.AddWithValue("@Stock", stock);
////        //                        reactivateCommand.ExecuteNonQuery();
////        //                    }
////        //                    return true;
////        //                }
////        //                else
////        //                {
////        //                    // Si el usuario elige no reactivar el artículo, no hacer nada
////        //                    return false;
////        //                }
////        //            }
////        //        }

////        //        // Si el artículo no existe o está activo, se inserta como un nuevo artículo
////        //        string insertQuery = "INSERT INTO Articulos (Codigo, Nombre, Marca, Rubro, Precio, Stock, Activo) VALUES (@Codigo, @Nombre, @Marca, @Rubro, @Precio, @Stock, 1)";
////        //        using (var insertCommand = new SQLiteCommand(insertQuery, connection))
////        //        {
////        //            insertCommand.Parameters.AddWithValue("@Codigo", codigo);
////        //            insertCommand.Parameters.AddWithValue("@Nombre", nombre);
////        //            insertCommand.Parameters.AddWithValue("@Marca", marca);
////        //            insertCommand.Parameters.AddWithValue("@Rubro", rubro);
////        //            insertCommand.Parameters.AddWithValue("@Precio", precio);
////        //            insertCommand.Parameters.AddWithValue("@Stock", stock);
////        //            insertCommand.ExecuteNonQuery();
////        //        }
////        //        return true;
////        //    }
////        //}

////        //public bool AgregarArticulo(string codigo, string nombre, string marca, string rubro, double precio, int stock)
////        //{
////        //    // Consulta para verificar si el artículo ya existe pero está desactivado, basado en Nombre y Marca
////        //    string checkQuery = "SELECT COUNT(*) FROM Articulos WHERE Nombre = @Nombre AND Marca = @Marca AND Activo = 0";

////        //    using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
////        //    {
////        //        connection.Open();

////        //        // Verificar si el artículo ya existe pero está desactivado
////        //        using (var checkCommand = new SQLiteCommand(checkQuery, connection))
////        //        {
////        //            checkCommand.Parameters.AddWithValue("@Nombre", nombre);
////        //            checkCommand.Parameters.AddWithValue("@Marca", marca);
////        //            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

////        //            if (count > 0)
////        //            {
////        //                // Mostrar un cuadro de diálogo para confirmar si se desea reactivar el artículo
////        //                var result = MessageBox.Show(
////        //                    "El artículo con este nombre y marca ya existe pero está desactivado. ¿Desea reactivarlo?",
////        //                    "Confirmar Reactivación",
////        //                    MessageBoxButtons.YesNo,
////        //                    MessageBoxIcon.Question);

////        //                if (result == DialogResult.Yes)
////        //                {
////        //                    // Reactivar el artículo si el usuario confirma
////        //                    string reactivateQuery = "UPDATE Articulos SET Activo = 1, Codigo = @Codigo, Rubro = @Rubro, Precio = @Precio, Stock = @Stock WHERE Nombre = @Nombre AND Marca = @Marca";
////        //                    using (var reactivateCommand = new SQLiteCommand(reactivateQuery, connection))
////        //                    {
////        //                        reactivateCommand.Parameters.AddWithValue("@Codigo", codigo);
////        //                        reactivateCommand.Parameters.AddWithValue("@Nombre", nombre);
////        //                        reactivateCommand.Parameters.AddWithValue("@Marca", marca);
////        //                        reactivateCommand.Parameters.AddWithValue("@Rubro", rubro);
////        //                        reactivateCommand.Parameters.AddWithValue("@Precio", precio);
////        //                        reactivateCommand.Parameters.AddWithValue("@Stock", stock);
////        //                        reactivateCommand.ExecuteNonQuery();
////        //                    }
////        //                    return true;
////        //                }
////        //                else
////        //                {
////        //                    // Si el usuario elige no reactivar el artículo, no hacer nada
////        //                    return false;
////        //                }
////        //            }
////        //        }

////        //        // Si el artículo no existe o ya está activo, se inserta como un nuevo artículo
////        //        string insertQuery = "INSERT INTO Articulos (Codigo, Nombre, Marca, Rubro, Precio, Stock, Activo) VALUES (@Codigo, @Nombre, @Marca, @Rubro, @Precio, @Stock, 1)";
////        //        using (var insertCommand = new SQLiteCommand(insertQuery, connection))
////        //        {
////        //            insertCommand.Parameters.AddWithValue("@Codigo", codigo);
////        //            insertCommand.Parameters.AddWithValue("@Nombre", nombre);
////        //            insertCommand.Parameters.AddWithValue("@Marca", marca);
////        //            insertCommand.Parameters.AddWithValue("@Rubro", rubro);
////        //            insertCommand.Parameters.AddWithValue("@Precio", precio);
////        //            insertCommand.Parameters.AddWithValue("@Stock", stock);
////        //            insertCommand.ExecuteNonQuery();
////        //        }
////        //        return true;
////        //    }
////        //}


////        public bool AgregarArticulo(string codigo, string nombre, string marca, string rubro, double precio, int stock)
////        {
////            // Consulta para verificar si el artículo ya existe pero está desactivado, basado en Nombre y Marca
////            string checkQuery = "SELECT Codigo FROM Articulos WHERE Nombre = @Nombre AND Marca = @Marca AND Activo = 0";

////            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
////            {
////                connection.Open();

////                // Verificar si el artículo ya existe pero está desactivado
////                using (var checkCommand = new SQLiteCommand(checkQuery, connection))
////                {
////                    checkCommand.Parameters.AddWithValue("@Nombre", nombre);
////                    checkCommand.Parameters.AddWithValue("@Marca", marca);
////                    object result = checkCommand.ExecuteScalar();

////                    if (result != null)
////                    {
////                        // El artículo existe y está desactivado, obtener el código original
////                        string codigoExistente = result.ToString();

////                        // Mostrar un cuadro de diálogo para confirmar si se desea reactivar el artículo
////                        var confirmResult = MessageBox.Show(
////                            "El artículo con este nombre y marca ya existe pero está desactivado. ¿Desea reactivarlo?",
////                            "Confirmar Reactivación",
////                            MessageBoxButtons.YesNo,
////                            MessageBoxIcon.Question);

////                        if (confirmResult == DialogResult.Yes)
////                        {
////                            // Reactivar el artículo sin cambiar el código
////                            string reactivateQuery = "UPDATE Articulos SET Activo = 1, Rubro = @Rubro, Precio = @Precio, Stock = @Stock WHERE Codigo = @Codigo";
////                            using (var reactivateCommand = new SQLiteCommand(reactivateQuery, connection))
////                            {
////                                reactivateCommand.Parameters.AddWithValue("@Codigo", codigoExistente);
////                                reactivateCommand.Parameters.AddWithValue("@Rubro", rubro);
////                                reactivateCommand.Parameters.AddWithValue("@Precio", precio);
////                                reactivateCommand.Parameters.AddWithValue("@Stock", stock);
////                                reactivateCommand.ExecuteNonQuery();
////                            }
////                            return true;
////                        }
////                        else
////                        {
////                            // Si el usuario elige no reactivar el artículo, no hacer nada
////                            return false;
////                        }
////                    }
////                }

////                // Si el artículo no existe o ya está activo, se inserta como un nuevo artículo
////                string insertQuery = "INSERT INTO Articulos (Codigo, Nombre, Marca, Rubro, Precio, Stock, Activo) VALUES (@Codigo, @Nombre, @Marca, @Rubro, @Precio, @Stock, 1)";
////                using (var insertCommand = new SQLiteCommand(insertQuery, connection))
////                {
////                    insertCommand.Parameters.AddWithValue("@Codigo", codigo);
////                    insertCommand.Parameters.AddWithValue("@Nombre", nombre);
////                    insertCommand.Parameters.AddWithValue("@Marca", marca);
////                    insertCommand.Parameters.AddWithValue("@Rubro", rubro);
////                    insertCommand.Parameters.AddWithValue("@Precio", precio);
////                    insertCommand.Parameters.AddWithValue("@Stock", stock);
////                    insertCommand.ExecuteNonQuery();
////                }
////                return true;
////            }
////        }

////        public bool ActualizarArticulo(string codigo, string nombre, string marca, string rubro, double precio, int stock)
////        {
////            string query = "UPDATE Articulos SET Nombre=@Nombre, Marca=@Marca, Rubro=@Rubro, Precio=@Precio, Stock=@Stock WHERE Codigo=@Codigo";

////            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
////            {
////                connection.Open();
////                using (var command = new SQLiteCommand(query, connection))
////                {
////                    command.Parameters.AddWithValue("@Codigo", codigo);
////                    command.Parameters.AddWithValue("@Nombre", nombre);
////                    command.Parameters.AddWithValue("@Marca", marca);
////                    command.Parameters.AddWithValue("@Rubro", rubro);
////                    command.Parameters.AddWithValue("@Precio", precio);
////                    command.Parameters.AddWithValue("@Stock", stock);

////                    int rowsAffected = command.ExecuteNonQuery();
////                    return rowsAffected > 0;
////                }
////            }
////        }

////        public bool DeshabilitarArticulo(string codigo)
////        {
////            string query = "UPDATE Articulos SET Activo = 0 WHERE Codigo = @Codigo";

////            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
////            {
////                connection.Open();
////                using (var command = new SQLiteCommand(query, connection))
////                {
////                    command.Parameters.AddWithValue("@Codigo", codigo);
////                    int rowsAffected = command.ExecuteNonQuery();
////                    return rowsAffected > 0;
////                }
////            }
////        }


////        public bool HabilitarArticulo(string codigo)
////        {

////            string query = "UPDATE Articulos SET Activo = 1 WHERE Codigo = @Codigo AND Activo = 0";

////            try
////            {
////                using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
////                {
////                    connection.Open();

////                    using (var command = new SQLiteCommand(query, connection))
////                    {

////                        command.Parameters.AddWithValue("@Codigo", codigo);


////                        int rowsAffected = command.ExecuteNonQuery();


////                        return rowsAffected > 0;
////                    }
////                }
////            }
////            catch (Exception ex)
////            {

////                MessageBox.Show($"Error al habilitar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
////                return false;
////            }
////        }





////        public DataTable BuscarArticulos(string criterio)
////        {
////            string query = @"SELECT * FROM Articulos 
////                     WHERE (Codigo LIKE @Criterio OR Nombre LIKE @Criterio) AND Activo = 1";

////            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
////            {
////                var dataAdapter = new SQLiteDataAdapter(query, connection);
////                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

////                var dataTable = new DataTable();
////                dataAdapter.Fill(dataTable);
////                return dataTable;
////            }
////        }




////        public DataTable BuscarArticulosEnTodosLosCampos(string criterio)
////        {
////            string query = @"SELECT * FROM Articulos 
////                     WHERE (Codigo LIKE @Criterio OR Nombre LIKE @Criterio OR Marca LIKE @Criterio) 
////                     AND Activo = 1";

////            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
////            {
////                var dataAdapter = new SQLiteDataAdapter(query, connection);
////                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

////                var dataTable = new DataTable();
////                dataAdapter.Fill(dataTable);
////                return dataTable;
////            }
////        }
////        public DataTable BuscarArticulosPorCampo(string criterio, string campo)
////        {
////            string query = string.Empty;


////            switch (campo)
////            {
////                case "Código":
////                    query = "SELECT * FROM Articulos WHERE Codigo LIKE @Criterio AND Activo = 1";
////                    break;
////                case "Nombre":
////                    query = "SELECT * FROM Articulos WHERE Nombre LIKE @Criterio AND Activo = 1";
////                    break;
////                case "Marca":
////                    query = "SELECT * FROM Articulos WHERE Marca LIKE @Criterio AND Activo = 1";
////                    break;
////                case "Rubro":
////                    query = "SELECT * FROM Articulos WHERE Rubro LIKE @Criterio AND Activo = 1";
////                    break;
////                default:
////                    return new DataTable(); 
////            }

////            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
////            {
////                var dataAdapter = new SQLiteDataAdapter(query, connection);
////                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

////                var dataTable = new DataTable();
////                dataAdapter.Fill(dataTable);
////                return dataTable;
////            }
////        }



////        public DataTable CargarArticulos(bool activos = true)
////        {
////            string query = activos ? "SELECT * FROM Articulos WHERE Activo = 1" : "SELECT * FROM Articulos WHERE Activo = 0";

////            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
////            {
////                var dataAdapter = new SQLiteDataAdapter(query, connection);
////                var dataTable = new DataTable();
////                dataAdapter.Fill(dataTable);
////                return dataTable;
////            }
////        }
////    }
////}
////////////////////////////////////////
/////

////////

////using System;
////using System.Data;
////using System.Data.SQLite;
////using System.Windows.Forms;
//////using System.Data.SQLite;
//////using System.Windows.Forms;
////using Punto_de_venta___Prácticas_profesionales.Datos;
////´j
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//using System.Data;
//using System.Data.SQLite;
//using System.Windows.Forms;
//using Punto_de_venta___Prácticas_profesionales.Datos;


//namespace Punto_de_venta___Prácticas_profesionales.Logica
//{
//    public class ArticulosLogica
//    {
//        public bool AgregarArticulo(string nombre, string marca, string rubro, double precio, int stock)
//        {
//            string insertQuery = "INSERT INTO Articulos (Nombre, Marca, Rubro, Precio, Stock, Activo) VALUES (@Nombre, @Marca, @Rubro, @Precio, @Stock, 1)";

//            using (var connection = new SQLiteConnection(.ConnectionString))
//            {
//                connection.Open();
//                using (var insertCommand = new SQLiteCommand(insertQuery, connection))
//                {
//                    insertCommand.Parameters.AddWithValue("@Nombre", nombre);
//                    insertCommand.Parameters.AddWithValue("@Marca", marca);
//                    insertCommand.Parameters.AddWithValue("@Rubro", rubro);
//                    insertCommand.Parameters.AddWithValue("@Precio", precio);
//                    insertCommand.Parameters.AddWithValue("@Stock", stock);
//                    insertCommand.ExecuteNonQuery();
//                }
//                return true;
//            }
//        }



//        public bool ActualizarArticulo(int codigo, string nombre, string marca, string rubro, double precio, int stock)
//        {
//            string query = "UPDATE Articulos SET Nombre=@Nombre, Marca=@Marca, Rubro=@Rubro, Precio=@Precio, Stock=@Stock WHERE Codigo=@Codigo";

//            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
//            {
//                connection.Open();
//                using (var command = new SQLiteCommand(query, connection))
//                {
//                    command.Parameters.AddWithValue("@Codigo", codigo);
//                    command.Parameters.AddWithValue("@Nombre", nombre);
//                    command.Parameters.AddWithValue("@Marca", marca);
//                    command.Parameters.AddWithValue("@Rubro", rubro);
//                    command.Parameters.AddWithValue("@Precio", precio);
//                    command.Parameters.AddWithValue("@Stock", stock);
//                    return command.ExecuteNonQuery() > 0;
//                }
//            }
//        }

//        public bool DeshabilitarArticulo(int codigo)
//        {
//            string query = "UPDATE Articulos SET Activo = 0 WHERE Codigo = @Codigo";

//            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
//            {
//                connection.Open();
//                using (var command = new SQLiteCommand(query, connection))
//                {
//                    command.Parameters.AddWithValue("@Codigo", codigo);
//                    return command.ExecuteNonQuery() > 0;
//                }
//            }
//        }

//        public bool HabilitarArticulo(int codigo)
//        {
//            string query = "UPDATE Articulos SET Activo = 1 WHERE Codigo = @Codigo AND Activo = 0";

//            try
//            {
//                using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
//                {
//                    connection.Open();
//                    using (var command = new SQLiteCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@Codigo", codigo);
//                        return command.ExecuteNonQuery() > 0;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error al habilitar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return false;
//            }
//        }

//        public DataTable BuscarArticulos(string criterio)
//        {
//            string query = @"SELECT * FROM Articulos WHERE (Codigo LIKE @Criterio OR Nombre LIKE @Criterio) AND Activo = 1";

//            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
//            {
//                var dataAdapter = new SQLiteDataAdapter(query, connection);
//                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

//                var dataTable = new DataTable();
//                dataAdapter.Fill(dataTable);
//                return dataTable;
//            }
//        }

//        public DataTable BuscarArticulosPorCampo(string criterio, string campo)
//        {
//            string query = string.Empty;

//            switch (campo)
//            {
//                case "Nombre":
//                    query = "SELECT * FROM Articulos WHERE Nombre LIKE @Criterio AND Activo = 1";
//                    break;
//                case "Marca":
//                    query = "SELECT * FROM Articulos WHERE Marca LIKE @Criterio AND Activo = 1";
//                    break;
//                case "Rubro":
//                    query = "SELECT * FROM Articulos WHERE Rubro LIKE @Criterio AND Activo = 1";
//                    break;
//                default:
//                    return new DataTable();
//            }

//            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
//            {
//                var dataAdapter = new SQLiteDataAdapter(query, connection);
//                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

//                var dataTable = new DataTable();
//                dataAdapter.Fill(dataTable);
//                return dataTable;
//            }
//        }
//        public DataTable BuscarArticulosEnTodosLosCampos(string criterio)
//        {
//            string query = @"SELECT * FROM Articulos 
//                     WHERE (Nombre LIKE @Criterio OR Marca LIKE @Criterio OR Rubro LIKE @Criterio) 
//                     AND Activo = 1";

//            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
//            {
//                var dataAdapter = new SQLiteDataAdapter(query, connection);
//                dataAdapter.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

//                var dataTable = new DataTable();
//                dataAdapter.Fill(dataTable);
//                return dataTable;
//            }
//        }

//        public DataTable CargarArticulos(bool activos = true)
//        {
//            string query = activos ? "SELECT * FROM Articulos WHERE Activo = 1" : "SELECT * FROM Articulos WHERE Activo = 0";

//            using (var connection = new SQLiteConnection(ArticulosDatos.ConnectionString))
//            {
//                var dataAdapter = new SQLiteDataAdapter(query, connection);
//                var dataTable = new DataTable();
//                dataAdapter.Fill(dataTable);
//                return dataTable;
//            }
//        }
//    }
//}
