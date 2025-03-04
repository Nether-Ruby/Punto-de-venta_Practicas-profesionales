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
        //private readonly string connectionString = @"Data Source=C:\Users\Acer\Desktop\nuevoProyecto\Punto-de-venta_Practicas-profesionales\Punto de venta - Prácticas profesionales\database.db; Version=3;";

        // Obtener todos los datos de Caja
        public DataTable ObtenerTodosLosDatosCaja()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT id, fecha_hora_apertura, fecha_hora_cierre, efectivo, tarjeta, total, ingresos, egresos FROM Caja";

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
            string query = @"SELECT id, fecha_hora_apertura, fecha_hora_cierre, efectivo, tarjeta, total, ingresos, egresos 
                     FROM Caja 
                     WHERE fecha_hora_apertura BETWEEN @fechaInicio AND @fechaFin";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin.ToString("yyyy-MM-dd HH:mm:ss"));

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        /////////////////////////////////////////// Reportes de Ventas ///////////////////////////////////////////

        // Obtener todas las ventas (sin filtro)
        public DataTable ObtenerTodasLasVentas()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT id_venta, fecha_hora, vendedor, cliente, metodo, metodo_tipo, total, activa FROM Ventas WHERE activa = 1";

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

        // Obtener las ventas por rango de fechas (últimos 7 días, 30 días o fecha personalizada)
        public DataTable ObtenerVentasPorRango(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable tabla = new DataTable();
            string query = @"SELECT id_venta, fecha_hora, vendedor, cliente, metodo, metodo_tipo, total, activa 
                             FROM Ventas 
                             WHERE fecha_hora BETWEEN @fechaInicio AND @fechaFin AND activa = 1";

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

        // Obtener ventas de un mes específico
        public DataTable ObtenerVentasPorMes(int mes, int anio)
        {
            DataTable tabla = new DataTable();
            var primerDiaDelMes = new DateTime(anio, mes, 1);
            var ultimoDiaDelMes = primerDiaDelMes.AddMonths(1).AddDays(-1);

            string query = @"SELECT id_venta, fecha_hora, vendedor, cliente, metodo, metodo_tipo, total, activa 
                             FROM Ventas 
                             WHERE fecha_hora BETWEEN @primerDiaDelMes AND @ultimoDiaDelMes AND activa = 1";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@primerDiaDelMes", primerDiaDelMes);
                    cmd.Parameters.AddWithValue("@ultimoDiaDelMes", ultimoDiaDelMes);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        // Obtener los detalles de una venta específica
        public DataTable ObtenerDetallesVenta(int idVenta)
        {
            DataTable tabla = new DataTable();
            string query = @"
        SELECT 
            a.nombre AS articulo, -- Selecciona el nombre del artículo
            dv.cantidad
        FROM 
            Detalles_ventas dv
        INNER JOIN 
            Articulos a
        ON 
            dv.articulo = a.codigo -- Relaciona por el código del artículo
        WHERE 
            dv.id_venta = @idVenta";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idVenta", idVenta);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        public DataTable ObtenerArticulosVendidos()
        {
            DataTable tabla = new DataTable();
            string query = @"
        SELECT 
            a.nombre AS articulo,
            SUM(dv.cantidad) AS cantidad_vendida
        FROM 
            Detalles_ventas dv
        INNER JOIN 
            Articulos a
        ON 
            dv.articulo = a.codigo
        GROUP BY 
            a.nombre
        ORDER BY 
            cantidad_vendida DESC";

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


    }
}
