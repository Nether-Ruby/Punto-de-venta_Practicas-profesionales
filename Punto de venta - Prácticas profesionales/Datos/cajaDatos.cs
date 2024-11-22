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
    internal class cajaDatos
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
                using var cmd = conn.CreateCommand();
                string query = "SELECT vendedor, cliente, metodo, TOTAL, fecha_hora\r\nFROM Ventas \r\nWHERE DATE(fecha_hora) = DATE('now', 'start of day');";
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
        public bool insertarCierreCaja (double efectivo, double tarjeta, double total, double ingresos, double egresos, DateTime horaCierre)
        {
            try
            {
                string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
                string connectionString = @"URI=file:" + databasePath;
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Caja (efectivo, tarjeta, total, ingresos, egresos, fecha_hora) " +
                                   "VALUES (@efectivo, @tarjeta, @total, @ingresos, @egresos, @hora_cierre)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@efectivo", efectivo);
                        cmd.Parameters.AddWithValue("@tarjeta", tarjeta);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@ingresos", ingresos);
                        cmd.Parameters.AddWithValue("@egresos", egresos);
                        cmd.Parameters.AddWithValue("@hora_cierre", horaCierre.ToString("yyyy-MM-dd HH:mm:ss"));

                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Si todo fue exitoso
            }
            catch (Exception ex)
            {
                // Loguear el error (opcional) y devolver false
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
