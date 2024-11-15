using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Punto_de_venta___Prácticas_profesionales.Datos;

namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    internal class clientesLogica
    {
        private readonly clientesDatos _clientesDatos = new clientesDatos();

        public string ValidarDatosPersona(string cuilStr, string nombre, string apellido, string telefonoStr, string domicilio, string email, out long cuil, out long telefono)
        {
            cuil = 0;
            telefono = 0;

            if (string.IsNullOrEmpty(cuilStr))
                return "El Cuil es obligatorio";
            if (cuilStr.Length != 11 || !long.TryParse(cuilStr, out cuil))
                return "El Cuil debe contener 11 digitos";
            if (string.IsNullOrEmpty(nombre))
                return "El Nombre es obligatorio";
            if (string.IsNullOrEmpty(apellido))
                return "El Apellido es obligatorio";
            if (string.IsNullOrEmpty(telefonoStr))
                return "El Telefono es obligatorio";
            if (telefonoStr.Length != 10 || !long.TryParse(telefonoStr, out telefono))
                return "El Telefono debe contener 10 digitos";
            if (string.IsNullOrEmpty(domicilio))
                return "El Domicilio es obligatorio";
            if (string.IsNullOrEmpty(email))
                return "El Email es obligatorio";
            if (!email.EndsWith("@gmail.com"))
                return "El Email debe ser valido y terminar en '@gmail.com' ";

            return string.Empty;
        }

        public void GuardarPersona(long cuil, string nombre, string apellido, long telefono, string domicilio, string email)
        {
            _clientesDatos.InsertarPersona(cuil, nombre, apellido, telefono, domicilio, email);

        }

        public DataTable ObtenerPersonas()
        {
            return _clientesDatos.ObtenerPersonas();

        }
          
        public string ValidarYActualizarPersona(string cuilStr, string nombre, string apellido, string telefonoStr, string domicilio, string email, out long cuil, out long telefono)
        {
            // Inicializamos los valores de salida en cero por defecto
            cuil = 0;
            telefono = 0;

            // Validación de CUIL
            if (string.IsNullOrEmpty(cuilStr)) 
                return "El CUIL es obligatorio.";
            if (cuilStr.Length != 11 || !long.TryParse(cuilStr, out cuil))
                return "El CUIL debe contener 11 dígitos.";

            // Validación de nombre
            if (string.IsNullOrEmpty(nombre))
                return "El Nombre es obligatorio.";

            // Validación de apellido
            if (string.IsNullOrEmpty(apellido))
                return "El Apellido es obligatorio.";

            // Validación de teléfono
            if (string.IsNullOrEmpty(telefonoStr))
                return "El Teléfono es obligatorio.";
            if (telefonoStr.Length != 10 || !long.TryParse(telefonoStr, out telefono))
                return "El Teléfono debe contener 10 dígitos.";

            // Validación de domicilio
            if (string.IsNullOrEmpty(domicilio))
                return "El Domicilio es obligatorio.";

            // Validación de email
            if (string.IsNullOrEmpty(email))
                return "El Email es obligatorio.";
            if (!email.Contains("@") || !email.EndsWith("@gmail.com"))
                return "El Email debe ser válido y terminar en '@gmail.com'.";

            // Si todo es válido, actualizamos la persona en la base de datos
            _clientesDatos.ActualizarPersona(cuil, nombre, apellido, telefono, domicilio, email);

            // Si no hay errores, retornamos una cadena vacía
            return string.Empty;
        }

    }

}
