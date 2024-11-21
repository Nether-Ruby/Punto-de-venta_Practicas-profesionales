
using Punto_de_venta___Prácticas_profesionales.Lógica;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;



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



        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al inicializar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


   
    public static DataRow ObtenerResumenDelDia()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string query = @"
            SELECT 
                COALESCE(SUM(Efectivo), 0) as Efectivo, 
                COALESCE(SUM(Tarjeta), 0) as Tarjeta, 
                COALESCE(SUM(Ingresos), 0) as Ingresos, 
                COALESCE(SUM(Egresos), 0) as Egresos, 
                COALESCE((SUM(Efectivo) + SUM(Tarjeta) + SUM(Ingresos) - SUM(Egresos)), 0) as Total
            FROM Caja
            WHERE date(Fecha_Hora) = date('now')"; // Filtrar solo los datos del día actual

            using (var command = new SQLiteCommand(query, connection))
            using (var adapter = new SQLiteDataAdapter(command))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    return table.Rows[0];
                }

                throw new Exception("No hay datos disponibles para el resumen del día.");
            }
        }
    }
 
    public static List<Dictionary<string, object>> ObtenerMovimientosDelDia()
    {
        var movimientos = new List<Dictionary<string, object>>();

        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string query = @"
                SELECT Fecha_Hora, Ingresos, Egresos,
                       SUM(Ingresos) OVER () AS TotalIngresos,
                       SUM(Egresos) OVER () AS TotalEgresos,
                       (SUM(Ingresos) OVER () - SUM(Egresos) OVER ()) AS Total
                FROM Caja
                WHERE date(Fecha_Hora) = date('now')";

            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    movimientos.Add(new Dictionary<string, object>
                    {
                        { "FechaHora", reader["Fecha_Hora"].ToString() },
                        { "Ingreso", Convert.ToDouble(reader["Ingresos"]) },
                        { "Egreso", Convert.ToDouble(reader["Egresos"]) },
                        { "TotalIngresos", Convert.ToDouble(reader["TotalIngresos"]) },
                        { "TotalEgresos", Convert.ToDouble(reader["TotalEgresos"]) },
                        { "Total", Convert.ToDouble(reader["Total"]) }
                    });
                }
            }
        }

        return movimientos;
    }


    public static void RegistrarCierreDeCaja(int idCaja, DateTime fechaHora)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            //        // Crear la tabla si no existe
            string crearTablaSql = @"
        CREATE TABLE IF NOT EXISTS Cierre_caja (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            id_caja INTEGER NOT NULL,
            fecha_hora TEXT NOT NULL
        )";
            using (var command = new SQLiteCommand(crearTablaSql, connection))
{
    command.ExecuteNonQuery();
}

// Insertar el cierre de caja
string insertarSql = @"
        INSERT INTO Cierre_caja (id_caja, fecha_hora)
        VALUES (@IdCaja, @FechaHora)";
using (var command = new SQLiteCommand(insertarSql, connection))
{
    command.Parameters.AddWithValue("@IdCaja", idCaja);
    command.Parameters.AddWithValue("@FechaHora", fechaHora.ToString("yyyy-MM-dd HH:mm:ss"));
    command.ExecuteNonQuery();
}
        }
    }
    public static void GuardarCierreDeCaja(DateTime fecha, double efectivo, double tarjeta, double ingresos, double egresos, double total)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            // Crear la tabla Cierre_caja si no existe
            string crearTablaSql = @"
            CREATE TABLE IF NOT EXISTS Cierre_caja (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                fecha_hora TEXT NOT NULL,
                efectivo REAL DEFAULT 0,
                tarjeta REAL DEFAULT 0,
                ingresos REAL DEFAULT 0,
                egresos REAL DEFAULT 0,
                total REAL DEFAULT 0
            )";
            using (var command = new SQLiteCommand(crearTablaSql, connection))
            {
                command.ExecuteNonQuery();
            }

            // Insertar los datos del cierre
            string insertarCierreSql = @"
            INSERT INTO Cierre_caja (fecha_hora, efectivo, tarjeta, ingresos, egresos, total)
            VALUES (@FechaHora, @Efectivo, @Tarjeta, @Ingresos, @Egresos, @Total)";
            using (var command = new SQLiteCommand(insertarCierreSql, connection))
            {
                command.Parameters.AddWithValue("@FechaHora", fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@Efectivo", efectivo);
                command.Parameters.AddWithValue("@Tarjeta", tarjeta);
                command.Parameters.AddWithValue("@Ingresos", ingresos);
                command.Parameters.AddWithValue("@Egresos", egresos);
                command.Parameters.AddWithValue("@Total", total);
                command.ExecuteNonQuery();
            }

            // Eliminar los datos de la tabla Caja
            string eliminarCajaSql = "DELETE FROM Caja";
            using (var command = new SQLiteCommand(eliminarCajaSql, connection))
            {
                command.ExecuteNonQuery();
            }

            // Reiniciar la tabla Caja con un registro inicial
            string reiniciarCajaSql = @"
            INSERT INTO Caja (Fecha_Hora, Efectivo, Tarjeta, Ingresos, Egresos, Total)
            VALUES (@FechaHora, 0, 0, 0, 0, 0)";
            using (var command = new SQLiteCommand(reiniciarCajaSql, connection))
            {
                command.Parameters.AddWithValue("@FechaHora", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                command.ExecuteNonQuery();
            }
        }
    }

    public static int ObtenerIdCajaActual()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string query = @"
            SELECT Id
            FROM Caja
            WHERE date(Fecha_Hora) = date('now')
            ORDER BY Fecha_Hora DESC
            LIMIT 1";

            using (var command = new SQLiteCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int idCaja))
                {
                    return idCaja;
                }
                return -1; // No hay caja activa
            }
        }
    }



public static DateTime? ObtenerUltimoCierreDeCaja(int idCaja)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string query = @"
        SELECT MAX(fecha_hora) AS UltimoCierre
        FROM Cierre_caja
        WHERE id_caja = @IdCaja";

            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdCaja", idCaja);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    return DateTime.Parse(result.ToString());
                }
            }
        }

        return null; // No hay cierres registrados
    }

  
   

    //public static int ObtenerIdCajaActual()
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();
    //        string query = @"
    //        SELECT Id
    //        FROM Caja
    //        WHERE date(Fecha_Hora) = date('now')
    //        ORDER BY Fecha_Hora DESC
    //        LIMIT 1";

    //        using (var command = new SQLiteCommand(query, connection))
    //        {
    //            object result = command.ExecuteScalar();

    //            if (result != null && int.TryParse(result.ToString(), out int idCaja))
    //            {
    //                return idCaja;
    //            }

    //            // Si no hay caja activa, retornamos un valor especial
    //            return -1;
    //        }
    //    }
    //}


    //public static void GuardarCierreDeCaja(DateTime fecha, double efectivo, double tarjeta, double ingresos, double egresos, double total)
    //{
    //    using (var connection = new SQLiteConnection(ConnectionString))
    //    {
    //        connection.Open();

    //        string crearTablaSql = @"
    //        CREATE TABLE IF NOT EXISTS Cierre_caja (
    //            Id INTEGER PRIMARY KEY AUTOINCREMENT,
    //            Fecha_Hora TEXT NOT NULL,
    //            Efectivo REAL DEFAULT 0,
    //            Tarjeta REAL DEFAULT 0,
    //            Ingresos REAL DEFAULT 0,
    //            Egresos REAL DEFAULT 0,
    //            Total REAL DEFAULT 0
    //        )";
    //        using (var command = new SQLiteCommand(crearTablaSql, connection))
    //        {
    //            command.ExecuteNonQuery();
    //        }

    //        string insertarCierreSql = @"
    //        INSERT INTO Cierre_Caja (Fecha_Hora, Efectivo, Tarjeta, Ingresos, Egresos, Total)
    //        VALUES (@Fecha_Hora, @Efectivo, @Tarjeta, @Ingresos, @Egresos, @Total)";
    //        using (var command = new SQLiteCommand(insertarCierreSql, connection))
    //        {
    //            command.Parameters.AddWithValue("@Fecha_Hora", fecha.ToString("yyyy-MM-dd HH:mm:ss"));
    //            command.Parameters.AddWithValue("@Efectivo", efectivo);
    //            command.Parameters.AddWithValue("@Tarjeta", tarjeta);
    //            command.Parameters.AddWithValue("@Ingresos", ingresos);
    //            command.Parameters.AddWithValue("@Egresos", egresos);
    //            command.Parameters.AddWithValue("@Total", total);
    //            command.ExecuteNonQuery();
    //        }
    //    }
    //}

public static (double totalEfectivo, double totalTarjeta) ObtenerTotalesVentasReales()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string query = @"
            SELECT 
                SUM(CASE WHEN metodo = 'Efectivo' THEN total ELSE 0 END) AS TotalEfectivo,
                SUM(CASE WHEN metodo = 'Tarjeta' THEN total ELSE 0 END) AS TotalTarjeta
            FROM Ventas
            WHERE date(fecha_hora) = date('now')";

            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    double totalEfectivo = reader["TotalEfectivo"] != DBNull.Value ? Convert.ToDouble(reader["TotalEfectivo"]) : 0;
                    double totalTarjeta = reader["TotalTarjeta"] != DBNull.Value ? Convert.ToDouble(reader["TotalTarjeta"]) : 0;

                    return (totalEfectivo, totalTarjeta);
                }
            }
        }

        return (0, 0); // Si no hay datos, devolvemos 0
    }

    public static List<string> DiagnosticoVentas()
    {
        var resultado = new List<string>();

        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Ventas ORDER BY fecha_hora DESC"; // Traer todas las ventas
            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Concatenar datos de la venta en formato legible
                    resultado.Add($"Fecha: {reader["fecha_hora"]}, Método: {reader["metodo"]}, Total: {reader["total"]}");
                }
            }
        }

        return resultado; // Devuelve una lista con los datos de las ventas
    }



    //07
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
    //porfa san 
    public static void ReiniciarTotales()
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            // Guardar los totales actuales en la tabla "Cerrar_caja"
            string insertCierreQuery = @"
            INSERT INTO Cierre_caja (id_caja, fecha_hora)
            SELECT Id, datetime('now')
            FROM Caja
            WHERE date(Fecha_Hora) = date('now')
            ORDER BY Fecha_Hora DESC
            LIMIT 1";

            using (var insertCommand = new SQLiteCommand(insertCierreQuery, connection))
            {
                insertCommand.ExecuteNonQuery();
            }

            // Eliminar TODOS los registros de la tabla "Caja"
            string deleteQuery = "DELETE FROM Caja";
            using (var deleteCommand = new SQLiteCommand(deleteQuery, connection))
            {
                deleteCommand.ExecuteNonQuery();
            }

            // Crear un registro inicial desde 0
            string insertResetQuery = @"
            INSERT INTO Caja (Fecha_Hora, Efectivo, Tarjeta, Ingresos, Egresos, Total)
            VALUES (@FechaHora, 0, 0, 0, 0, 0)";
            using (var resetCommand = new SQLiteCommand(insertResetQuery, connection))
            {
                resetCommand.Parameters.AddWithValue("@FechaHora", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                resetCommand.ExecuteNonQuery();
            }
        }
    }


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
