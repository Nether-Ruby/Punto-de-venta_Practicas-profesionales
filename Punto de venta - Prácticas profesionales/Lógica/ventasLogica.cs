using Punto_de_venta___Prácticas_profesionales.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
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

        public  int ObtenerNroFact ()
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
        public class TicketPrintDocument : PrintDocument
        {
            private string _cliente;
            private string _vendedor;
            private string _metodoPago;
            private double _total;
            private List<Tuple<string, string, string>> _detallesImp;

            public TicketPrintDocument(string cliente, string vendedor, string metodoPago, double total, List<Tuple<string, string, string>> detallesImp)
            {
                _cliente = cliente;
                _vendedor = vendedor;
                _metodoPago = metodoPago;
                _total = total;
                _detallesImp = detallesImp;
            }

            protected override void OnPrintPage(PrintPageEventArgs e)
            {
                base.OnPrintPage(e);

                // Fuente y color para el texto
                Font font = new Font("Arial", 12);
                Brush brush = Brushes.Black;

                // Margen izquierdo
                float marginLeft = 50;
                float y = 50; // Posición vertical inicial

                // Dibujar el encabezado del ticket
                e.Graphics.DrawString("TICKET DE VENTA", new Font("Arial", 20, FontStyle.Bold), brush, marginLeft, y);
                y += 40;

                // Dibujar los datos del cliente
                e.Graphics.DrawString($"Cliente: {_cliente}", font, brush, marginLeft, y);
                y += 30;

                // Dibujar los datos del vendedor
                e.Graphics.DrawString($"Vendedor: {_vendedor}", font, brush, marginLeft, y);
                y += 30;

                // Dibujar el método de pago
                e.Graphics.DrawString($"Método de pago: {_metodoPago}", font, brush, marginLeft, y);
                y += 30;

                // Dibujar los detalles de la venta
                e.Graphics.DrawString("Detalles de la venta:", font, brush, marginLeft, y);
                y += 20;

                foreach (var detalle in _detallesImp)
                {
                    string nroFact = detalle.Item1; // Número de factura
                    string nombre = detalle.Item2; // Nombre del producto
                    string cantidad = detalle.Item3; // Cantidad

                    // Dibujar cada detalle en una nueva línea
                    e.Graphics.DrawString($"{nroFact} - {nombre} x {cantidad}", font, brush, marginLeft, y);
                    y += 20;
                }

                // Dibujar el total
                e.Graphics.DrawString($"Total: {_total:C2}", font, brush, marginLeft, y);
                y += 30;

                // Dibujar un mensaje de agradecimiento
                e.Graphics.DrawString("¡Gracias por su compra!", font, brush, marginLeft, y);
            }
        }
    }
}
