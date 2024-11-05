using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    internal class proveedoresLogica
    {
        private int id;
        private string nombre;
        private int telefono;
        private string email;
        private int deuda;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public int Deuda { get => deuda; set => deuda = value; }
        public int Id { get => id; }
    }
}
