
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

using Punto_de_venta___Prácticas_profesionales.Datos;

using Punto_de_venta___Prácticas_profesionales.Lógica;
//public class CajaLogica
//{
//    // Cargar todas las transacciones del día
//    public DataTable CargarTransaccionesDelDia()
//    {
//        return DatosCaja.ObtenerTransaccionesDelDia();
//    }

//    // Registrar un ingreso o egreso
//    public void RegistrarMovimiento(string tipo, double monto)
//    {
//        double ingresos = tipo == "Ingresos" ? monto : 0;
//        double egresos = tipo == "Egresos" ? monto : 0;

//        double total = ingresos - egresos;

//        DatosCaja.RegistrarMovimiento(DateTime.Now, 0, 0, ingresos, egresos, total);
//    }
//}

///////
///////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////
////////////////////////////////////////////////////////
///
//public class CajaLogica
//{
//    public DataRow ObtenerResumenDelDia()
//    {
//        return DatosCaja.ObtenerResumenDelDia();
//    }

//    public void RegistrarMovimiento(string tipo, double monto)
//    {
//        double ingresos = tipo == "Ingresos" ? monto : 0;
//        double egresos = tipo == "Egresos" ? monto : 0;

//        DatosCaja.ActualizarResumenDelDia(ingresos, egresos);
//    }
//    //
//    public class Movimiento
//    {
//        public string FechaHora { get; set; }
//        public double Ingreso { get; set; }
//        public double Egreso { get; set; }
//        public double TotalIngresos { get; set; }
//        public double TotalEgresos { get; set; }
//        public double Total { get; set; }
//    }

//    public List<Movimiento> ObtenerMovimientosDelDia()
//    {
//        var movimientos = new List<Movimiento>();

//        using (var connection = new SQLiteConnection(DatosCaja.ConnectionString))
//        {
//            connection.Open();

//            string query = @"
//            SELECT Fecha_Hora, 
//                   Ingresos AS Ingreso, 
//                   Egresos AS Egreso,
//                   SUM(Ingresos) OVER () AS TotalIngresos,
//                   SUM(Egresos) OVER () AS TotalEgresos,
//                   (SUM(Ingresos) OVER () - SUM(Egresos) OVER ()) AS Total
//            FROM Caja
//            WHERE date(Fecha_Hora) = date('now');";

//            using (var command = new SQLiteCommand(query, connection))
//            using (var reader = command.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    movimientos.Add(new Movimiento
//                    {
//                        FechaHora = reader["Fecha_Hora"].ToString(),
//                        Ingreso = Convert.ToDouble(reader["Ingreso"]),
//                        Egreso = Convert.ToDouble(reader["Egreso"]),
//                        TotalIngresos = Convert.ToDouble(reader["TotalIngresos"]),
//                        TotalEgresos = Convert.ToDouble(reader["TotalEgresos"]),
//                        Total = Convert.ToDouble(reader["Total"])
//                    });
//                }
//            }
//        }

//        return movimientos;
//    }

//}

//


//supuuesto codigo viejo (abajo

public class CajaLogica
{
    /// <summary>
    /// Obtiene el resumen del día desde la tabla "Caja".
    /// Incluye Efectivo, Tarjeta y el Total general.
    /// </summary>
    /// <returns>DataRow con el resumen del día.</returns>
    public DataRow ObtenerResumenDelDia()
    {
        return DatosCaja.ObtenerResumenDelDia();
    }
    //public void RegistrarCierreDeCaja(DataGridViewRow filaTransacciones)
    //{
    //    string fechaHora = filaTransacciones.Cells["Fecha"].Value.ToString();
    //    double efectivo = Convert.ToDouble(filaTransacciones.Cells["Efectivo"].Value);
    //    double tarjeta = Convert.ToDouble(filaTransacciones.Cells["Tarjeta"].Value);
    //    double ingresos = Convert.ToDouble(filaTransacciones.Cells["Ingresos"].Value);
    //    double egresos = Convert.ToDouble(filaTransacciones.Cells["Egresos"].Value);
    //    double total = Convert.ToDouble(filaTransacciones.Cells["Total"].Value);

    //    // Guardar en la base de datos
    //    DatosCaja.RegistrarCierreDeCaja(fechaHora, efectivo, tarjeta, ingresos, egresos, total);
    //}


    //
    public void RegistrarCierreDeCaja(DataGridViewRow filaTransacciones)
    {
        string fechaHora = filaTransacciones.Cells["Fecha"].Value.ToString();
        double efectivo = Convert.ToDouble(filaTransacciones.Cells["Efectivo"].Value);
        double tarjeta = Convert.ToDouble(filaTransacciones.Cells["Tarjeta"].Value);
        double ingresos = Convert.ToDouble(filaTransacciones.Cells["Ingresos"].Value);
        double egresos = Convert.ToDouble(filaTransacciones.Cells["Egresos"].Value);
        double total = Convert.ToDouble(filaTransacciones.Cells["Total"].Value);

        // Guardar en la base de datos
        DatosCaja.RegistrarCierreDeCaja(fechaHora, efectivo, tarjeta, ingresos, egresos, total);

        // Reiniciar todos los datos acumulados
        DatosCaja.ReiniciarTotales();
    }


    ///// <summary>
    ///// Registra un movimiento (Ingreso o Egreso) en la base de datos y actualiza los totales del día.
    ///// </summary>
    ///// <param name="tipo">"Ingreso" o "Egreso".</param>
    ///// <param name="monto">Monto del movimiento.</param>
    //public void RegistrarMovimiento(string tipo, double monto)
    //{
    //    // Determinar si es un ingreso o egreso
    //    double ingresos = tipo == "Ingreso" ? monto : 0;
    //    double egresos = tipo == "Egreso" ? monto : 0;

    //    // Actualizar el resumen del día
    //    DatosCaja.ActualizarResumenDelDia(ingresos, egresos);
    //}
    public void RegistrarMovimiento(string tipo, double monto)
    {
        double ingresos = tipo == "Ingreso" ? monto : 0;
        double egresos = tipo == "Egreso" ? monto : 0;

        DatosCaja.ActualizarResumenDelDia(ingresos, egresos);
    }
    /// <summary>
    /// Obtiene la lista de movimientos del día desde la base de datos.
    /// Cada movimiento incluye información detallada (Fecha, Ingresos, Egresos, Totales).
    /// </summary>
    /// <returns>Lista de diccionarios representando los movimientos.</returns>
    //public List<Dictionary<string, object>> ObtenerMovimientosDelDia()
    //{
    //    var movimientos = new List<Dictionary<string, object>>();

    //    using (var connection = new SQLiteConnection(DatosCaja.ConnectionString))
    //    {
    //        connection.Open();

    //        string query = @"
    //        SELECT Fecha_Hora, 
    //               Ingresos, 
    //               Egresos,
    //               SUM(Ingresos) OVER () AS TotalIngresos,
    //               SUM(Egresos) OVER () AS TotalEgresos,
    //               (SUM(Ingresos) OVER () - SUM(Egresos) OVER ()) AS Total
    //        FROM Caja
    //        WHERE date(Fecha_Hora) = date('now');";

    //        using (var command = new SQLiteCommand(query, connection))
    //        using (var reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                var movimiento = new Dictionary<string, object>
    //                {
    //                    { "FechaHora", reader["Fecha_Hora"].ToString() },
    //                    { "Ingreso", Convert.ToDouble(reader["Ingresos"]) },
    //                    { "Egreso", Convert.ToDouble(reader["Egresos"]) },
    //                    { "TotalIngresos", Convert.ToDouble(reader["TotalIngresos"]) },
    //                    { "TotalEgresos", Convert.ToDouble(reader["TotalEgresos"]) },
    //                    { "Total", Convert.ToDouble(reader["Total"]) }
    //                };

    //                movimientos.Add(movimiento);
    //            }
    //        }
    //    }

    //    return movimientos;
    //}
    //07
    public List<Dictionary<string, object>> ObtenerMovimientosDelDia()
    {
        var movimientos = new List<Dictionary<string, object>>();

        using (var connection = new SQLiteConnection(DatosCaja.ConnectionString))
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

    //tmb
    //public List<Dictionary<string, object>> ObtenerMovimientosDelDia()
    //{
    //    var movimientos = new List<Dictionary<string, object>>();

    //    using (var connection = new SQLiteConnection(DatosCaja.ConnectionString))
    //    {
    //        connection.Open();
    //        string query = @"
    //            SELECT Fecha_Hora, Ingresos, Egresos,
    //                   SUM(Ingresos) OVER () AS TotalIngresos,
    //                   SUM(Egresos) OVER () AS TotalEgresos,
    //                   (SUM(Ingresos) OVER () - SUM(Egresos) OVER ()) AS Total
    //            FROM Caja
    //            WHERE date(Fecha_Hora) = date('now')";

    //        using (var command = new SQLiteCommand(query, connection))
    //        using (var reader = command.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                movimientos.Add(new Dictionary<string, object>
    //                {
    //                    { "FechaHora", reader["Fecha_Hora"].ToString() },
    //                    { "Ingreso", Convert.ToDouble(reader["Ingresos"]) },
    //                    { "Egreso", Convert.ToDouble(reader["Egresos"]) },
    //                    { "TotalIngresos", Convert.ToDouble(reader["TotalIngresos"]) },
    //                    { "TotalEgresos", Convert.ToDouble(reader["TotalEgresos"]) },
    //                    { "Total", Convert.ToDouble(reader["Total"]) }
    //                });
    //            }
    //        }
    //    }

    //    return movimientos;

    //}
}
