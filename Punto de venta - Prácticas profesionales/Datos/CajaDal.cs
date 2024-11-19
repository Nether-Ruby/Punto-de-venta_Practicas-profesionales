using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

//public static class DatosCaja
//{
//    private static readonly string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
//    public static string ConnectionString { get; } = $"URI=file:{databasePath}";

//    public static void InitializeDatabase()
//    {
//        try
//        {
//            if (!File.Exists(databasePath))
//            {
//                SQLiteConnection.CreateFile(databasePath);
//            }

//            using (var connection = new SQLiteConnection(ConnectionString))
//            {
//                connection.Open();

//                string checkTableSql = "SELECT name FROM sqlite_master WHERE type='table' AND name='Caja';";
//                using (var checkCommand = new SQLiteCommand(checkTableSql, connection))
//                using (var reader = checkCommand.ExecuteReader())
//                {
//                    if (!reader.HasRows)
//                    {
//                        string createTableSql = @"
//                            CREATE TABLE Caja (
//                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
//                                Fecha_Hora TEXT NOT NULL,
//                                Efectivo REAL DEFAULT 0,
//                                Tarjeta REAL DEFAULT 0,
//                                Ingresos REAL DEFAULT 0,
//                                Egresos REAL DEFAULT 0,
//                                Total REAL DEFAULT 0
//                            )";
//                        using (var createCommand = new SQLiteCommand(createTableSql, connection))
//                        {
//                            createCommand.ExecuteNonQuery();
//                        }
//                    }
//                }
//            }

//            InsertarVentasFicticias();
//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show($"Error al inicializar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }
//    }

//    private static void InsertarVentasFicticias()
//    {
//        using (var connection = new SQLiteConnection(ConnectionString))
//        {
//            connection.Open();
//            string verificarQuery = "SELECT COUNT(*) FROM Caja WHERE date(Fecha_Hora) = date('now') AND Ingresos = 0 AND Egresos = 0";
//            using (var command = new SQLiteCommand(verificarQuery, connection))
//            {
//                int count = Convert.ToInt32(command.ExecuteScalar());

//                if (count == 0)
//                {
//                    string insertQuery = @"
//                        INSERT INTO Caja (Fecha_Hora, Efectivo, Tarjeta, Ingresos, Egresos, Total) 
//                        VALUES 
//                            (datetime('now', '-8 hours'), 100.0, 50.0, 0, 0, 150.0),
//                            (datetime('now', '-6 hours'), 80.0, 20.0, 0, 0, 100.0),
//                            (datetime('now', '-4 hours'), 200.0, 100.0, 0, 0, 300.0)";

//                    using (var insertCommand = new SQLiteCommand(insertQuery, connection))
//                    {
//                        insertCommand.ExecuteNonQuery();
//                    }
//                }
//            }
//        }
//    }

//    // Método para obtener transacciones del día
//    public static DataTable ObtenerTransaccionesDelDia()
//    {
//        using (var connection = new SQLiteConnection(ConnectionString))
//        {
//            connection.Open();
//            string query = "SELECT * FROM Caja WHERE date(Fecha_Hora) = date('now')";
//            using (var command = new SQLiteCommand(query, connection))
//            using (var adapter = new SQLiteDataAdapter(command))
//            {
//                DataTable transacciones = new DataTable();
//                adapter.Fill(transacciones);
//                return transacciones;
//            }
//        }
//    }

//    // Método para registrar movimiento
//    public static void RegistrarMovimiento(DateTime fechaHora, double efectivo, double tarjeta, double ingresos, double egresos, double total)
//    {
//        using (var connection = new SQLiteConnection(ConnectionString))
//        {
//            connection.Open();
//            string query = "INSERT INTO Caja (Fecha_Hora, Efectivo, Tarjeta, Ingresos, Egresos, Total) VALUES (@Fecha_Hora, @Efectivo, @Tarjeta, @Ingresos, @Egresos, @Total)";
//            using (var command = new SQLiteCommand(query, connection))
//            {
//                command.Parameters.AddWithValue("@Fecha_Hora", fechaHora.ToString("yyyy-MM-dd HH:mm:ss"));
//                command.Parameters.AddWithValue("@Efectivo", efectivo);
//                command.Parameters.AddWithValue("@Tarjeta", tarjeta);
//                command.Parameters.AddWithValue("@Ingresos", ingresos);
//                command.Parameters.AddWithValue("@Egresos", egresos);
//                command.Parameters.AddWithValue("@Total", total);
//                command.ExecuteNonQuery();
//            }
//        }
//    }
//}

//////////////
///codigo viejo 
public static class DatosCaja
{
    private static readonly string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
    public static string ConnectionString { get; } = $"URI=file:{databasePath}";

    public static void InitializeDatabase()
    {
        try
        {
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
            }

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string checkTableSql = "SELECT name FROM sqlite_master WHERE type='table' AND name='Caja';";
                using (var checkCommand = new SQLiteCommand(checkTableSql, connection))
                using (var reader = checkCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        string createTableSql = @"
                            CREATE TABLE Caja (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Fecha_Hora TEXT NOT NULL,
                                Efectivo REAL DEFAULT 0,
                                Tarjeta REAL DEFAULT 0,
                                Ingresos REAL DEFAULT 0,
                                Egresos REAL DEFAULT 0,
                                Total REAL DEFAULT 0
                            )";
                        using (var createCommand = new SQLiteCommand(createTableSql, connection))
                        {
                            createCommand.ExecuteNonQuery();
                        }
                    }
                }
            }

            // Inserta datos ficticios solo si la tabla está vacía
            InsertarVentasFicticias();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al inicializar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static void InsertarVentasFicticias()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string verificarQuery = "SELECT COUNT(*) FROM Caja WHERE date(Fecha_Hora) = date('now')";
            using (var command = new SQLiteCommand(verificarQuery, connection))
            {
                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 0)
                {
                    string insertQuery = @"
                        INSERT INTO Caja (Fecha_Hora, Efectivo, Tarjeta, Ingresos, Egresos, Total) 
                        VALUES (datetime('now'), 200.0, 100.0, 0, 0, 300.0)";
                    using (var insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    //public static DataRow ObtenerResumenDelDia()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();
    //        string query = @"
    //            SELECT SUM(Efectivo) as Efectivo, SUM(Tarjeta) as Tarjeta, 
    //                   SUM(Ingresos) as Ingresos, SUM(Egresos) as Egresos, 
    //                   (SUM(Efectivo) + SUM(Tarjeta) + SUM(Ingresos) - SUM(Egresos)) as Total
    //            FROM Caja 
    //            WHERE date(Fecha_Hora) = date('now')";
    //        using (var command = new SQLiteCommand(query, connection))
    //        using (var adapter = new SQLiteDataAdapter(command))
    //        {
    //            DataTable table = new DataTable();
    //            adapter.Fill(table);
    //            return table.Rows[0];
    //        }
    //    }
    //}
    //public static DataRow ObtenerResumenDelDia()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();
    //        string query = @"
    //        SELECT COALESCE(SUM(Efectivo), 0) as Efectivo, 
    //               COALESCE(SUM(Tarjeta), 0) as Tarjeta, 
    //               COALESCE(SUM(Ingresos), 0) as Ingresos, 
    //               COALESCE(SUM(Egresos), 0) as Egresos, 
    //               (COALESCE(SUM(Efectivo), 0) + COALESCE(SUM(Tarjeta), 0) + COALESCE(SUM(Ingresos), 0) - COALESCE(SUM(Egresos), 0)) as Total
    //        FROM Caja
    //        WHERE date(Fecha_Hora) = date('now')";
    //        using (var command = new SQLiteCommand(query, connection))
    //        using (var adapter = new SQLiteDataAdapter(command))
    //        {
    //            DataTable table = new DataTable();
    //            adapter.Fill(table);
    //            return table.Rows[0];
    //        }
    //    }
    //}
    //este de abjo si
    //public static DataRow ObtenerResumenDelDia()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();
    //        string query = @"
    //        SELECT 
    //            SUM(Efectivo) as Efectivo, 
    //            SUM(Tarjeta) as Tarjeta, 
    //            SUM(Ingresos) as Ingresos, 
    //            SUM(Egresos) as Egresos, 
    //            (SUM(Efectivo) + SUM(Tarjeta) + SUM(Ingresos) - SUM(Egresos)) as Total
    //        FROM Caja
    //        WHERE date(Fecha_Hora) = date('now')"; // Filtrar solo los datos del día actual

    //        using (var command = new SQLiteCommand(query, connection))
    //        using (var adapter = new SQLiteDataAdapter(command))
    //        {
    //            DataTable table = new DataTable();
    //            adapter.Fill(table);
    //            return table.Rows[0];
    //        }
    //    }
    //}
    public static DataRow ObtenerResumenDelDia()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = @"
            SELECT 
                SUM(Efectivo) as Efectivo, 
                SUM(Tarjeta) as Tarjeta, 
                SUM(Ingresos) as Ingresos, 
                SUM(Egresos) as Egresos, 
                (SUM(Efectivo) + SUM(Tarjeta) + SUM(Ingresos) - SUM(Egresos)) as Total
            FROM Caja
            WHERE date(Fecha_Hora) = date('now')"; // Filtrar solo los datos del día actual

            using (var command = new SQLiteCommand(query, connection))
            using (var adapter = new SQLiteDataAdapter(command))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table.Rows[0];
            }
        }
    }

    //no se
    //public static DataRow ObtenerResumenDelDia()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();

    //        string query = @"
    //    SELECT 
    //        COALESCE(SUM(Efectivo), 0) as Efectivo, 
    //        COALESCE(SUM(Tarjeta), 0) as Tarjeta, 
    //        COALESCE(SUM(Ingresos), 0) as Ingresos, 
    //        COALESCE(SUM(Egresos), 0) as Egresos, 
    //        (COALESCE(SUM(Efectivo), 0) + COALESCE(SUM(Tarjeta), 0) + COALESCE(SUM(Ingresos), 0) - COALESCE(SUM(Egresos), 0)) as Total
    //    FROM Caja
    //    WHERE date(Fecha_Hora) = date('now')";

    //        using (var command = new SQLiteCommand(query, connection))
    //        using (var adapter = new SQLiteDataAdapter(command))
    //        {
    //            DataTable table = new DataTable();
    //            adapter.Fill(table);

    //            // Si no hay filas en la tabla, crear una fila con valores predeterminados
    //            if (table.Rows.Count == 0)
    //            {
    //                DataRow row = table.NewRow();
    //                row["Efectivo"] = 0;
    //                row["Tarjeta"] = 0;
    //                row["Ingresos"] = 0;
    //                row["Egresos"] = 0;
    //                row["Total"] = 0;
    //                table.Rows.Add(row);
    //            }

    //            return table.Rows[0];
    //        }
    //    }
    //}
    //.
    //07
    //public static void ReiniciarIngresosYEgresosDelDia()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();
    //        string query = "DELETE FROM Caja WHERE date(Fecha_Hora) = date('now') AND (Ingresos > 0 OR Egresos > 0)";
    //        using (var command = new SQLiteCommand(query, connection))
    //        {
    //            command.ExecuteNonQuery();
    //        }
    //    }
    //}
    //0
    public static void ReiniciarIngresosYEgresosDelDia()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            // Reiniciar ingresos y egresos acumulados del día actual
            string query = @"
            UPDATE Caja
            SET Ingresos = 0, Egresos = 0
            WHERE date(Fecha_Hora) = date('now')";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }


    //tmb
    //public static void ReiniciarIngresosYEgresosDelDia()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();

    //        // Reiniciar los valores de ingresos y egresos para el día actual
    //        string reiniciarQuery = @"
    //        UPDATE Caja
    //        SET Ingresos = 0, 
    //            Egresos = 0
    //        WHERE date(Fecha_Hora) = date('now');";

    //        using (var command = new SQLiteCommand(reiniciarQuery, connection))
    //        {
    //            command.ExecuteNonQuery();
    //        }
    //    }
    //}


    //public static void ReiniciarIngresosYEgresosDelDia()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();
    //        string query = "DELETE FROM Caja WHERE date(Fecha_Hora) = date('now') AND (Ingresos > 0 OR Egresos > 0)";
    //        using (var command = new SQLiteCommand(query, connection))
    //        {
    //            command.ExecuteNonQuery();
    //        }
    //    }
    //}

    public static DataTable ObtenerVentasFicticias()
    {
        var tabla = new DataTable();
        tabla.Columns.Add("Fecha_Hora", typeof(string));
        tabla.Columns.Add("Efectivo", typeof(double));
        tabla.Columns.Add("Tarjeta", typeof(double));

        // Generar datos ficticios
        tabla.Rows.Add(DateTime.Now.AddHours(-3).ToString("yyyy-MM-dd HH:mm:ss"), 50.0, 30.0);
        tabla.Rows.Add(DateTime.Now.AddHours(-2).ToString("yyyy-MM-dd HH:mm:ss"), 100.0, 20.0);
        tabla.Rows.Add(DateTime.Now.AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss"), 70.0, 10.0);

        return tabla;
    }

    //
    public static void RegistrarCierreDeCaja(string fechaHora, double efectivo, double tarjeta, double ingresos, double egresos, double total)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string insertQuery = @"
            INSERT INTO Caja (Fecha_Hora, Efectivo, Tarjeta, Ingresos, Egresos, Total) 
            VALUES (@Fecha_Hora, @Efectivo, @Tarjeta, @Ingresos, @Egresos, @Total)";
            using (var command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Fecha_Hora", fechaHora);
                command.Parameters.AddWithValue("@Efectivo", efectivo);
                command.Parameters.AddWithValue("@Tarjeta", tarjeta);
                command.Parameters.AddWithValue("@Ingresos", ingresos);
                command.Parameters.AddWithValue("@Egresos", egresos);
                command.Parameters.AddWithValue("@Total", total);

                command.ExecuteNonQuery();
            }
        }
    }
    public static void GuardarCierreDeCaja(DateTime fecha, double efectivo, double tarjeta, double ingresos, double egresos, double total)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            // Crear la tabla de cierres de caja si no existe
            string crearTablaSql = @"
            CREATE TABLE IF NOT EXISTS CierresDeCaja (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Fecha_Hora TEXT NOT NULL,
                Efectivo REAL DEFAULT 0,
                Tarjeta REAL DEFAULT 0,
                Ingresos REAL DEFAULT 0,
                Egresos REAL DEFAULT 0,
                Total REAL DEFAULT 0
            )";
            using (var command = new SQLiteCommand(crearTablaSql, connection))
            {
                command.ExecuteNonQuery();
            }

            // Insertar los datos del cierre de caja
            string insertarCierreSql = @"
            INSERT INTO CierresDeCaja (Fecha_Hora, Efectivo, Tarjeta, Ingresos, Egresos, Total)
            VALUES (@Fecha_Hora, @Efectivo, @Tarjeta, @Ingresos, @Egresos, @Total)";
            using (var command = new SQLiteCommand(insertarCierreSql, connection))
            {
                command.Parameters.AddWithValue("@Fecha_Hora", fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@Efectivo", efectivo);
                command.Parameters.AddWithValue("@Tarjeta", tarjeta);
                command.Parameters.AddWithValue("@Ingresos", ingresos);
                command.Parameters.AddWithValue("@Egresos", egresos);
                command.Parameters.AddWithValue("@Total", total);
                command.ExecuteNonQuery();
            }
        }
    }
    //public static void ReiniciarTotales()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();

    //        // Reiniciar los ingresos y egresos para la fecha actual
    //        string updateQuery = @"
    //        UPDATE Caja 
    //        SET Ingresos = 0, 
    //            Egresos = 0
    //        WHERE date(Fecha_Hora) = date('now')";
    //        using (var command = new SQLiteCommand(updateQuery, connection))
    //        {
    //            command.ExecuteNonQuery();
    //        }
    //    }
    //}
    //public static void ReiniciarTotales()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();

    //        // Eliminar ingresos y egresos de la base de datos
    //        string deleteQuery = "DELETE FROM Caja WHERE Ingresos > 0 OR Egresos > 0";
    //        using (var command = new SQLiteCommand(deleteQuery, connection))
    //        {
    //            command.ExecuteNonQuery();
    //        }
    //    }
    //}
    //07
    public static void ReiniciarTotales()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            // Eliminar TODOS los registros para un reinicio completo
            string deleteQuery = "DELETE FROM Caja";
            using (var command = new SQLiteCommand(deleteQuery, connection))
            {
                command.ExecuteNonQuery();
            }

        }
    }
    //tmb
    //public static void ReiniciarTotales()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();
    //        // Eliminar TODOS los registros para un reinicio completo
    //        string deleteQuery = "DELETE FROM Caja";
    //        using (var command = new SQLiteCommand(deleteQuery, connection))
    //        {
    //            command.ExecuteNonQuery();
    //        }
    //    }
    //}
    public static void ActualizarResumenDelDia(double ingresos, double egresos)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            // Actualizamos los ingresos y egresos para la fecha actual
            string updateQuery = @"
                UPDATE Caja 
                SET Ingresos = Ingresos + @Ingresos, 
                    Egresos = Egresos + @Egresos 
                WHERE date(Fecha_Hora) = date('now')";
            using (var command = new SQLiteCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@Ingresos", ingresos);
                command.Parameters.AddWithValue("@Egresos", egresos);
                command.ExecuteNonQuery();
            }
        }
    }
}

