
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