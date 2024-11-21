using Punto_de_venta___Prácticas_profesionales.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    internal class VentasLogica
    {
        private VentasDatos ventasdatos = new VentasDatos();

        // Método para obtener artículos filtrados
        public List<string> FiltrarArticulos(string filtro)
        {
            // Validar el filtro
            if (string.IsNullOrEmpty(filtro))
            {
                return new List<string>();
            }

            return ventasdatos.ObtenerArticulosPorFiltro(filtro);
        }
        public List<string> FiltrarVendedores(string filtro)
        {
            // Validar el filtro
            if (string.IsNullOrEmpty(filtro))
            {
                return new List<string>();
            }

            return ventasdatos.ObtenerVendedoresPorFiltro(filtro);
        }
        public List<string> FiltrarClientes(string filtro)
        {
            // Validar el filtro
            if (string.IsNullOrEmpty(filtro))
            {
                return new List<string>();
            }

            return ventasdatos.ObtenerClientesPorFiltro(filtro);
        }

        public Tuple<string, string, string, string> consulta_dgv(string nombre)
        {

            return ventasdatos.consulta_dgv(nombre);
        }

    
        public class Transaccion
        {
            public DateTime FechaHora { get; set; }
            public string Vendedor { get; set; }
            public string Cliente { get; set; }
            public string MetodoPago { get; set; }
            public double Total { get; set; }
        }
        //sof

        //internal static List<Transaccion> ObtenerTransaccionesDelDia()
        //{
        //    var transacciones = new List<Transaccion>();
        //    string connectionString = @"URI=file:" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

        //    using (var connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = @"
        //    SELECT fecha_hora, metodo, total
        //    FROM Ventas
        //    WHERE date(fecha_hora) = date('now')";

        //        using (var command = new SQLiteCommand(query, connection))
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                transacciones.Add(new Transaccion
        //                {
        //                    FechaHora = DateTime.Parse(reader["fecha_hora"].ToString()),
        //                    MetodoPago = reader["metodo"].ToString(),
        //                    Total = Convert.ToDouble(reader["total"])
        //                });
        //            }
        //        }
        //    }

        //    return transacciones;
        //}
        //chat anterior / original
        //internal static List<Transaccion> ObtenerTransaccionesDelDia()
        //{
        //    var transacciones = new List<Transaccion>();
        //    string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
        //    string connectionString = @"URI=file:" + databasePath;

        //    using (var connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        string query = @"
        //    SELECT fecha_hora, metodo, total
        //    FROM Ventas
        //    WHERE date(fecha_hora) = date('now')";

        //        using (var command = new SQLiteCommand(query, connection))
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                transacciones.Add(new Transaccion
        //                {
        //                    FechaHora = DateTime.Parse(reader["fecha_hora"].ToString()),
        //                    MetodoPago = reader["metodo"].ToString(),
        //                    Total = Convert.ToDouble(reader["total"])
        //                });
        //            }
        //        }
        //    }

        //    return transacciones;
        //}

        //chat nuevo 
        //internal static List<Transaccion> ObtenerTransaccionesDelDia()
        //{
        //    var transacciones = new List<Transaccion>();
        //    string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
        //    string connectionString = @"URI=file:" + databasePath;

        //    using (var connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        string query = @"
        //    SELECT fecha_hora, metodo, total
        //    FROM Ventas
        //    WHERE date(fecha_hora) = date('now')";

        //        using (var command = new SQLiteCommand(query, connection))
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                transacciones.Add(new Transaccion
        //                {
        //                    FechaHora = DateTime.Parse(reader["fecha_hora"].ToString()),
        //                    MetodoPago = reader["metodo"].ToString(),
        //                    Total = Convert.ToDouble(reader["total"])
        //                });
        //            }
        //        }
        //    }

        //    return transacciones;
        //}
        //internal static List<Transaccion> ObtenerTransaccionesPosterioresAlUltimoCierre(int idCaja)
        //{
        //    var transacciones = new List<Transaccion>();
        //    string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
        //    string connectionString = $"URI=file:{databasePath}";

        //    using (var connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        // Obtener la última fecha de cierre de caja
        //        DateTime? ultimoCierre = DatosCaja.ObtenerUltimoCierreDeCaja(idCaja);

        //        string query = @"
        //    SELECT fecha_hora, metodo, total
        //    FROM Ventas
        //    WHERE date(fecha_hora) = date('now')
        //    AND (@UltimoCierre IS NULL OR datetime(fecha_hora) > datetime(@UltimoCierre))";

        //        using (var command = new SQLiteCommand(query, connection))
        //        {
        //            // Parámetro para la fecha del último cierre
        //            command.Parameters.AddWithValue("@UltimoCierre", ultimoCierre.HasValue ? ultimoCierre.Value.ToString("yyyy-MM-dd HH:mm:ss") : (object)DBNull.Value);

        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    transacciones.Add(new Transaccion
        //                    {
        //                        FechaHora = DateTime.Parse(reader["fecha_hora"].ToString()),
        //                        MetodoPago = reader["metodo"].ToString(),
        //                        Total = Convert.ToDouble(reader["total"])
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    return transacciones;
        //}

        //internal static List<Transaccion> ObtenerTransaccionesPosterioresAlUltimoCierre(int idCaja)
        //{
        //    var transacciones = new List<Transaccion>();
        //    string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
        //    string connectionString = $"URI=file:{databasePath}";

        //    using (var connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        // Obtener la última fecha de cierre de caja
        //        DateTime? ultimoCierre = DatosCaja.ObtenerUltimoCierreDeCaja(idCaja);

        //        string query = @"
        //    SELECT fecha_hora, metodo, total
        //    FROM Ventas
        //    WHERE (@UltimoCierre IS NULL OR datetime(fecha_hora) > datetime(@UltimoCierre))";

        //        using (var command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@UltimoCierre", ultimoCierre.HasValue ? ultimoCierre.Value.ToString("yyyy-MM-dd HH:mm:ss") : (object)DBNull.Value);

        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    transacciones.Add(new Transaccion
        //                    {
        //                        FechaHora = DateTime.Parse(reader["fecha_hora"].ToString()),
        //                        MetodoPago = reader["metodo"].ToString(),
        //                        Total = Convert.ToDouble(reader["total"])
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    return transacciones;
        //}

        internal static List<Transaccion> ObtenerTransaccionesPosterioresAlUltimoCierre(int idCaja)
        {
            var transacciones = new List<Transaccion>();
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
            string connectionString = $"URI=file:{databasePath}";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Obtener la última fecha de cierre de caja
                DateTime? ultimoCierre = DatosCaja.ObtenerUltimoCierreDeCaja(idCaja);

                string query = @"
            SELECT fecha_hora, metodo, total
            FROM Ventas
            WHERE (@UltimoCierre IS NULL OR datetime(fecha_hora) > datetime(@UltimoCierre))";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UltimoCierre", ultimoCierre.HasValue ? ultimoCierre.Value.ToString("yyyy-MM-dd HH:mm:ss") : (object)DBNull.Value);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transacciones.Add(new Transaccion
                            {
                                FechaHora = DateTime.Parse(reader["fecha_hora"].ToString()),
                                MetodoPago = reader["metodo"].ToString(),
                                Total = Convert.ToDouble(reader["total"])
                            });
                        }
                    }
                }
            }
            return transacciones;
        }
    
    public int ObtenerNroFact ()
        {

            return ventasdatos.ObtenerNroFact();
        }

        public class detallesVenta
        {
            public string nroFact { get; set; }

            public string codigo { get; set; }

            public string cantidad { get; set; }
        }
      


        public void RegistrarDetallesVenta (List<detallesVenta> F)
        {
            ventasdatos.RegistrarDetallesVenta(F);
        }

        public bool VerificarYRegistrarVenta(string nombre, int cantidad, out string mensaje)
        {
            if (!ventasdatos.ValidarStock(nombre, cantidad))
            {
                mensaje = "No hay suficiente stock para realizar la venta.";
                return false;
            }
            else
            {
                mensaje = "Articulo agregado con exito";
                return true;

            }
        }
    }
}
