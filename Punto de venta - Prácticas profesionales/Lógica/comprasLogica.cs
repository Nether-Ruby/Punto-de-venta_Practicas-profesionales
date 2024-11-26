using Punto_de_venta___Prácticas_profesionales.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    internal class comprasLogica
    {
        private int id;
        private int articulo;
        private int proveedor;
        private int cantidad;
        private double monto;
        private DateTime fecha_hora;

        public int Id { get => id; set => id = value; }
        public int Articulo { get => articulo; set => articulo = value; }
        public int Proveedor { get => proveedor; set => proveedor = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Monto { get => monto; set => monto = value; }
        public DateTime Fecha_hora { get => fecha_hora; set => fecha_hora = value; }

        public static DataTable mostrarCompras()
        {
            DataTable tabla = new DataTable();
            comprasDatos datos = new comprasDatos();
            tabla = datos.refrescarCompras();
            return tabla;
        }

        public void registrar(comprasLogica compra)
        {
            comprasDatos datos = new comprasDatos();
            datos.agregarCompra(compra);
        }
        public static DataTable mostrarArticulos()
        {
            DataTable tabla = new DataTable();
            tabla = comprasDatos.getArticulos();
            return tabla;
        }
        public static DataTable mostrarProveedores()
        {
            DataTable tabla = new DataTable();
            tabla = comprasDatos.getProveedores();
            return tabla;
        }
    }
}
