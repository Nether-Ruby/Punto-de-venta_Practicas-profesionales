using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Punto_de_venta___Prácticas_profesionales.Datos;


namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    internal class reportesLogica
    {


        private readonly reportesDatos datos = new reportesDatos();

        public DataTable ObtenerTodosLosDatosCaja()
        {
            return datos.ObtenerTodosLosDatosCaja();
        }

        public DataTable ObtenerDatosCajaPorRango(DateTime fechaInicio, DateTime fechaFin)
        {
            return datos.ObtenerDatosCajaPorRango(fechaInicio, fechaFin);
        }


        // Obtener todas las ventas
        public DataTable ObtenerTodasLasVentas()
        {
            return datos.ObtenerTodasLasVentas();
        }

        // Obtener ventas por un rango de fechas
        public DataTable ObtenerVentasPorRango(DateTime fechaInicio, DateTime fechaFin)
        {
            return datos.ObtenerVentasPorRango(fechaInicio, fechaFin);
        }

        // Obtener ventas de un mes específico
        public DataTable ObtenerVentasPorMes(int mes, int anio)
        {
            return datos.ObtenerVentasPorMes(mes, anio);
        }

        // Obtener detalles de una venta específica
        public DataTable ObtenerDetallesVenta(int idVenta)
        {
            return datos.ObtenerDetallesVenta(idVenta);
        }

        public DataTable ObtenerArticulosVendidos()
        {
            reportesDatos datos = new reportesDatos();
            return datos.ObtenerArticulosVendidos();
        }

    }
}