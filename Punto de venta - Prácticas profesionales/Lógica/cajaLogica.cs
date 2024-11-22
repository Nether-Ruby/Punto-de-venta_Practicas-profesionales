using Punto_de_venta___Prácticas_profesionales.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    internal class cajaLogica
    {
        private cajaDatos cd = new cajaDatos();

        public bool CerrarCaja(double efectivo, double tarjeta, double totalCaja, double ingresos, double egresos, DateTime horaCierre)
        {
            return cd.insertarCierreCaja(efectivo, tarjeta, totalCaja, ingresos, egresos, horaCierre);
        }
        public static DataTable ventasHoy()
        {
            DataTable dt = new DataTable();
            dt = cajaDatos.mostrarVentas();
            return dt;
        }

    }

    
}
