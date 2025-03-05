using Punto_de_venta___Prácticas_profesionales.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    public class cajaLogica
    {
        private cajaDatos cd = new cajaDatos();

        public bool AbrirTurno(DateTime horaApertura)
        {
            return cd.AbrirTurno(horaApertura);
        }

        public bool CerrarTurno(int id, DateTime horaCierre, double efectivo, double tarjeta, double total, double ingresos, double egresos)
        {
            return cd.CerrarTurno(id, horaCierre, efectivo, tarjeta, total, ingresos, egresos);
        }

        public DataTable ObtenerRegistrosCajaDelDia()
        {
            return cd.ObtenerRegistrosCajaDelDia();
        }

        public int ObtenerIdTurnoAbierto()
        {
            return cd.ObtenerIdTurnoAbierto();
        }
        public static DataTable ventasHoy()
        {
            DataTable dt = new DataTable();
            dt = cajaDatos.mostrarVentas();
            return dt;
        }


    }

    
}
