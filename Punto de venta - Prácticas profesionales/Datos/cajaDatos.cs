using Punto_de_venta___Prácticas_profesionales.Lógica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta___Prácticas_profesionales.Datos
{
    public class cajaDatos
    {
        string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

        public static DataTable mostrarVentas()
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
            string connectionString = @"URI=file:" + databasePath;
            DataTable tabla = new DataTable();

            using var conn = new SQLiteConnection(connectionString);
            try
            {
                conn.Open();

                // Obtener la última hora de cierre
                DateTime ultimaHoraCierre;
                using (var cmdUltimaCierre = conn.CreateCommand())
                {
                    cmdUltimaCierre.CommandText = "SELECT MAX(fecha_hora_cierre) FROM Caja;";
                    var result = cmdUltimaCierre.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        // Si no hay registros de cierre, usar una fecha predeterminada (por ejemplo, inicio del día)
                        ultimaHoraCierre = DateTime.Now.Date; // Inicio del día actual
                    }
                    else
                    {
                        ultimaHoraCierre = Convert.ToDateTime(result);
                    }
                }

                // Obtener las ventas desde la última hora de cierre en adelante
                using var cmd = conn.CreateCommand();
                string query = @"
            SELECT vendedor, cliente, metodo, TOTAL, fecha_hora
            FROM Ventas
            WHERE fecha_hora >= @ultimaHoraCierre;";

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@ultimaHoraCierre", ultimaHoraCierre.ToString("yyyy-MM-dd HH:mm:ss"));

                using SQLiteDataReader reader = cmd.ExecuteReader();
                tabla.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return tabla;
        }

        public bool AbrirTurno(DateTime horaApertura)
        {
            try
            {
                string connectionString = @"URI=file:" + databasePath;
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Caja (fecha_hora_apertura) " +
                                   "VALUES (@fecha_hora_apertura)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fecha_hora_apertura", horaApertura.ToString("yyyy-MM-dd HH:mm:ss"));
                        

                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Si todo fue exitoso
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool CerrarTurno(int id, DateTime horaCierre, double efectivo, double tarjeta, double total, double ingresos, double egresos)
        {
            try
            {
                string connectionString = @"URI=file:" + databasePath;
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE Caja SET fecha_hora_cierre = @fecha_hora_cierre, " +
                                   "efectivo = @efectivo, tarjeta = @tarjeta, " +
                                   "total = @total, ingresos = @ingresos, egresos = @egresos " +
                                   "WHERE id = @id";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fecha_hora_cierre", horaCierre.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@efectivo", efectivo);
                        cmd.Parameters.AddWithValue("@tarjeta", tarjeta);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@ingresos", ingresos);
                        cmd.Parameters.AddWithValue("@egresos", egresos);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Si todo fue exitoso
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public DataTable ObtenerRegistrosCajaDelDia()
        {
            string connectionString = @"URI=file:" + databasePath;
            DataTable tabla = new DataTable();
            using var conn = new SQLiteConnection(connectionString);
            try
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                string query = "SELECT * FROM Caja WHERE DATE(fecha_hora_apertura) = DATE('now', 'start of day')";
                cmd.CommandText = query;
                using SQLiteDataReader reader = cmd.ExecuteReader();
                tabla.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return tabla;
        }

        public int ObtenerIdTurnoAbierto()
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
            string connectionString = @"URI=file:" + databasePath;

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    // Consulta para obtener el ID del último turno abierto
                    cmd.CommandText = "SELECT id FROM Caja WHERE fecha_hora_cierre IS NULL;";
                    var result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                    {
                        return -1; // No hay turnos abiertos
                    }
                    else
                    {
                        return Convert.ToInt32(result); // Devuelve el ID del turno abierto
                    }
                }
            }
        }
    }
}
