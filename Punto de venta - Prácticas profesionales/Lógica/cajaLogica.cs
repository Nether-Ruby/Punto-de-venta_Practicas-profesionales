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
        int id;
        string fecha_hora;
        double efectivo;
        double tarjeta;
        double total;
        double ingreso;
        double egreso;

        public static DataTable ventasHoy()
        {
            DataTable dt = new DataTable();
            dt = cajaDatos.mostrarVentas();
            return dt;
        }

    }

    
}
