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
                string query = "SELECT vendedor, cliente, metodo, TOTAL, fecha_hora\r\nFROM Ventas \r\nWHERE DATE(fecha_hora) = DATE('now', '-1 day');";
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
        public void insertarCaja (cajaLogica caja)
        {
            
        }
    }
}
