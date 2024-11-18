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

        
    }
}
