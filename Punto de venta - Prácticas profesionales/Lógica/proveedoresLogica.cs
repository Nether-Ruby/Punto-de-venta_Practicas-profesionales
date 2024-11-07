using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Punto_de_venta___Prácticas_profesionales.Datos;
using System.Windows.Forms;

namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    internal class proveedoresLogica
    {
        private int id;
        private string nombre;
        private string telefono;
        private string email;
        private double deuda;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public double Deuda { get => deuda; set => deuda = value; }
        public int Id { get => id; set => id = value; }

        public DataTable mostrarProveedores()
        {
            proveedoresDatos datos = new proveedoresDatos();
            DataTable tabla = new DataTable();
            tabla = datos.refrescarProveedores();
            return tabla;
        }
        public DataTable buscarProveedores(string param)
        {
            DataTable tabla = new DataTable();
            proveedoresDatos datos = new proveedoresDatos();
            tabla = datos.buscarProveedores(param);
            return tabla;
        }
        public static bool ValidarProveedor(proveedoresLogica proveedor, out string errorMessage)
        {
            errorMessage = string.Empty;


            if (string.IsNullOrWhiteSpace(proveedor.Nombre))
            {
                errorMessage = "El nombre no puede estar vacío.";
                return false;
            }

            if (!ValidarTelefono(proveedor.Telefono))
            {
                errorMessage = "El número de teléfono no es válido.";
                return false;
            }

            if (!ValidarEmail(proveedor.Email))
            {
                errorMessage = "El correo electrónico no es válido.";
                return false;
            }

            return true;
        }

        private static bool ValidarTelefono(string telefono)
        { // Si el teléfono es null o una cadena vacía, se considera válido (opcional)
          if (string.IsNullOrWhiteSpace(telefono)) 
            { 
                return true; 
            } // Validar la longitud y los caracteres del teléfono
          return telefono.All(char.IsDigit) && telefono.Length == 10; 
        }

            private static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) 
            { 
                return true; 
            }
            // Usa expresión regular para validar el formato del correo electrónico
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public void agregarProveedor(proveedoresLogica proveedor)
        {
            proveedoresDatos datos = new proveedoresDatos();
            if (!ValidarProveedor(proveedor, out string errormessage))
            {
                MessageBox.Show(errormessage); return;
            }
            datos.agregarProveedor(proveedor);
            MessageBox.Show("Se ha agregado el proveedor con éxito");

        }
        public void modificarProveedor(proveedoresLogica modificado)
        {
            proveedoresDatos datos = new proveedoresDatos();
            if (!ValidarProveedor(modificado, out string errormessage))
            {
                MessageBox.Show(errormessage); return;
            }
            try 
            { 
                datos.modificarProveedor(modificado); 
                MessageBox.Show("Se ha modificado el proveedor con éxito"); 
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show("Error al modificar el proveedor: " + ex.Message);
            }
        }
    }
}
