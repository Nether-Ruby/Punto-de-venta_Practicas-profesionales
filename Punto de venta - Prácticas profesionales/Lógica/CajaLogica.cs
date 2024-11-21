

//using System;
//using System.Data;
//using System.Data.SQLite;
//using System.Windows.Forms;
//namespace Punto_de_venta___Prácticas_profesionales.Lógica;

//using Punto_de_venta___Prácticas_profesionales.Datos;

//using Punto_de_venta___Prácticas_profesionales.Lógica;

//public class CajaLogica
//{
//    /// <summary>
//    /// Obtiene el resumen del día desde la tabla "Caja".
//    /// Incluye Efectivo, Tarjeta y el Total general.
//    /// </summary>
//    /// <returns>DataRow con el resumen del día.</returns>
//    public DataRow ObtenerResumenDelDia()
//    {
//        return DatosCaja.ObtenerResumenDelDia();
//    }


//    public static int ObtenerIdCajaActual()
//    {
//        return DatosCaja.ObtenerIdCajaActual();
//    }

//    public static void RegistrarCierreDeCaja(int idCaja)
//    {
//        DateTime fechaHoraCierre = DateTime.Now;
//        DatosCaja.RegistrarCierreDeCaja(idCaja, fechaHoraCierre);
//    }
//    public static void GuardarCierreDeCaja(DateTime fecha, double efectivo, double tarjeta, double ingresos, double egresos, double total)
//    {
//        DatosCaja.GuardarCierreDeCaja(fecha, efectivo, tarjeta, ingresos, egresos, total);
//    }






//    internal static (double TotalEfectivo, double TotalTarjeta) FiltrarVentasPorUltimoCierre(int idCaja)
//    {
//        // Obtener todas las transacciones posteriores al último cierre
//        var transacciones = VentasLogica.ObtenerTransaccionesPosterioresAlUltimoCierre(idCaja);

//        // Calcular totales de efectivo y tarjeta
//        double totalEfectivo = 0;
//        double totalTarjeta = 0;

//        foreach (var transaccion in transacciones)
//        {
//            string metodoPago = transaccion.MetodoPago?.ToLower().Trim();
//            if (metodoPago == "efectivo")
//            {
//                totalEfectivo += transaccion.Total;
//            }
//            else if (metodoPago == "tarjeta de crédito" || metodoPago == "tarjeta de débito")
//            {
//                totalTarjeta += transaccion.Total;
//            }
//        }

//        return (totalEfectivo, totalTarjeta);
//    }




//    public static List<Dictionary<string, object>> ObtenerMovimientosDelDia()
//    {
//        return DatosCaja.ObtenerMovimientosDelDia();
//    }
//    internal static (double totalEfectivo, double totalTarjeta) CalcularTotalesDesdeVentas(List<VentasLogica.Transaccion> ventas)
//    {
//        double totalEfectivo = 0;
//        double totalTarjeta = 0;

//        foreach (var venta in ventas)
//        {
//            string metodoPago = venta.MetodoPago?.ToLower().Trim(); // Normaliza el texto del método de pago

//            if (metodoPago == "efectivo")
//            {
//                totalEfectivo += venta.Total;
//            }
//            else if (metodoPago == "tarjeta de crédito" || metodoPago == "tarjeta de débito")
//            {
//                totalTarjeta += venta.Total;
//            }
//        }

//        return (totalEfectivo, totalTarjeta);
//    }

//}
////porfa san expedito, porfa virgencita. suplico e imploro.
///
using System;
using System.Collections.Generic;
using System.Data;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;


//using Punto_de_venta___Prácticas_profesionales.Datos;

using Punto_de_venta___Prácticas_profesionales.Lógica;

namespace Punto_de_venta___Prácticas_profesionales.Lógica;

using Punto_de_venta___Prácticas_profesionales.Datos;

public class CajaLogica
{
    /// <summary>
    /// Obtiene el resumen del día desde la tabla "Caja".
    /// </summary>
    /// <returns>DataRow con el resumen del día.</returns>
    public DataRow ObtenerResumenDelDia()
    {
        return DatosCaja.ObtenerResumenDelDia();
    }

    //public static int ObtenerIdCajaActual()
    //{
    //    return DatosCaja.ObtenerIdCajaActual();
    //}

    public static void RegistrarCierreDeCaja(int idCaja)
    {
        DateTime fechaHoraCierre = DateTime.Now;
        DatosCaja.RegistrarCierreDeCaja(idCaja, fechaHoraCierre);
    }
    public static int ObtenerIdCajaActual()
    {
        return DatosCaja.ObtenerIdCajaActual();
    }

    public static void GuardarCierreDeCaja(DateTime fecha, double efectivo, double tarjeta, double ingresos, double egresos, double total)
    {
        DatosCaja.GuardarCierreDeCaja(fecha, efectivo, tarjeta, ingresos, egresos, total);
    }

    //public static void GuardarCierreDeCaja(DateTime fecha, double efectivo, double tarjeta, double ingresos, double egresos, double total)
    //{
    //    DatosCaja.GuardarCierreDeCaja(fecha, efectivo, tarjeta, ingresos, egresos, total);
    //}

    /// <summary>
    /// Calcula los totales de ventas (efectivo y tarjeta) posteriores al último cierre.
    /// </summary>
    /// <param name="idCaja">ID de la caja actual.</param>
    /// <returns>Totales de efectivo y tarjeta.</returns>
    internal static (double TotalEfectivo, double TotalTarjeta) FiltrarVentasPorUltimoCierre(int idCaja)
    {
        // Obtener todas las transacciones posteriores al último cierre
        var transacciones = VentasLogica.ObtenerTransaccionesPosterioresAlUltimoCierre(idCaja);

        // Calcular totales de efectivo y tarjeta
        double totalEfectivo = 0;
        double totalTarjeta = 0;

        foreach (var transaccion in transacciones)
        {
            string metodoPago = transaccion.MetodoPago?.ToLower().Trim();
            if (metodoPago == "efectivo")
            {
                totalEfectivo += transaccion.Total;
            }
            else if (metodoPago == "tarjeta de crédito" || metodoPago == "tarjeta de débito")
            {
                totalTarjeta += transaccion.Total;
            }
        }

        return (totalEfectivo, totalTarjeta);
    }

    public static List<Dictionary<string, object>> ObtenerMovimientosDelDia()
    {
        return DatosCaja.ObtenerMovimientosDelDia();
    }

    /// <summary>
    /// Calcula los totales desde una lista de ventas.
    /// </summary>
    /// <param name="ventas">Lista de transacciones.</param>
    /// <returns>Totales de efectivo y tarjeta.</returns>
    internal static (double TotalEfectivo, double TotalTarjeta) CalcularTotalesDesdeVentas(List<VentasLogica.Transaccion> ventas)
    {
        double totalEfectivo = 0;
        double totalTarjeta = 0;

        foreach (var venta in ventas)
        {
            string metodoPago = venta.MetodoPago?.ToLower().Trim();

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

