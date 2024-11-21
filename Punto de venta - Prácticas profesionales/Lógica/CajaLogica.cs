

using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
namespace Punto_de_venta___Prácticas_profesionales.Lógica;

using Punto_de_venta___Prácticas_profesionales.Datos;

using Punto_de_venta___Prácticas_profesionales.Lógica;

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


    public void RegistrarMovimiento(string tipo, double monto)
    {
        double ingresos = tipo == "Ingreso" ? monto : 0;
        double egresos = tipo == "Egreso" ? monto : 0;

        DatosCaja.ActualizarResumenDelDia(ingresos, egresos);
    }
   
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


    internal static (double totalEfectivo, double totalTarjeta) CalcularTotalesDesdeVentas(List<VentasLogica.Transaccion> ventas)
    {
        double totalEfectivo = 0;
        double totalTarjeta = 0;

        foreach (var venta in ventas)
        {
            string metodoPago = venta.MetodoPago?.ToLower().Trim(); // Normaliza el texto del método de pago

            if (metodoPago == "efectivo")
            {
                totalEfectivo += venta.Total;
            }
            else if (metodoPago == "tarjeta de crédito" || metodoPago == "tarjeta de débito")
            {
                totalTarjeta += venta.Total;
            }
        }

        return (totalEfectivo, totalTarjeta);
    }

}
