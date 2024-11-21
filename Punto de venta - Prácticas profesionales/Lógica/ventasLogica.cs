using Punto_de_venta___Prácticas_profesionales.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
