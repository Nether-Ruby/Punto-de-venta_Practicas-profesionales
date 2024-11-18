using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Punto_de_venta___Prácticas_profesionales.Datos
{
    internal class reportesDatos
    {
        private readonly string connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}database.db; Version=3;";

        public DataTable ObtenerTodosLosDatosCaja()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT fecha_hora, efectivo, tarjeta, total, ingresos, egresos FROM Caja";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        public DataTable ObtenerDatosCajaPorRango(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable tabla = new DataTable();
            string query = @"SELECT fecha_hora, efectivo, tarjeta, total, ingresos, egresos 
                             FROM Caja 
                             WHERE fecha_hora BETWEEN @fechaInicio AND @fechaFin";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
    }


}
