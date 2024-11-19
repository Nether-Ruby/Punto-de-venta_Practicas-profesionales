using System;
using System.Data;
using System.Text.RegularExpressions;
using Punto_de_venta___Prácticas_profesionales.Datos;

namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    internal class clientesLogica
    {
        private readonly clientesDatos _clientesDatos = new clientesDatos();

        // Validación de los datos de la persona
        public string ValidarDatosPersona(string cuilStr, string nombre, string apellido, string telefonoStr, string domicilio, string email, out long cuil, out long telefono)
        {
            cuil = 0;
            telefono = 0;

            // Validaciones de CUIL, nombre, apellido, teléfono y domicilio
            if (string.IsNullOrEmpty(cuilStr))
                return "El CUIL es obligatorio";
            if (cuilStr.Length != 11 || !long.TryParse(cuilStr, out cuil))
                return "El CUIL debe contener 11 dígitos";
            if (string.IsNullOrEmpty(nombre))
                return "El Nombre es obligatorio";
            if (string.IsNullOrEmpty(apellido))
                return "El Apellido es obligatorio";
            if (string.IsNullOrEmpty(telefonoStr))
                return "El Teléfono es obligatorio";
            if (telefonoStr.Length != 10 || !long.TryParse(telefonoStr, out telefono))
                return "El Teléfono debe contener 10 dígitos";
            if (string.IsNullOrEmpty(domicilio))
                return "El Domicilio es obligatorio";
            if (string.IsNullOrEmpty(email))
                return "El Email es obligatorio";

            // Validación del formato del correo electrónico
            if (!EsCorreoValido(email))
                return "El Email no tiene un formato válido.";

            return string.Empty;
        }

        // Método para guardar una persona
        public void GuardarPersona(long cuil, string nombre, string apellido, long telefono, string domicilio, string email)
        {
            // Verificamos si el correo ya está registrado antes de guardarlo
            if (_clientesDatos.VerificarCorreoExistente(email))  // Usar _clientesDatos para llamar al método
            {
                throw new Exception("Este correo ya está registrado en la base de datos.");
            }

            _clientesDatos.InsertarPersona(cuil, nombre, apellido, telefono, domicilio, email);
        }


        // Método para validar el formato del correo
        public bool EsCorreoValido(string email)
        {
            // Expresión regular para validar el formato del correo
            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);
        }

        // Método para obtener todos los clientes
        public DataTable ObtenerPersonas()
        {
            return _clientesDatos.ObtenerPersonas();
        }

        // Método para actualizar los datos de una persona
        public string ValidarYActualizarPersona(string cuilStr, string nombre, string apellido, string telefonoStr, string domicilio, string email, long cuilOriginal, out long cuil, out long telefono)
        {
            // Inicializamos los valores de salida en cero por defecto
            cuil = 0;
            telefono = 0;

            // Validaciones de los campos
            string error = ValidarDatosPersona(cuilStr, nombre, apellido, telefonoStr, domicilio, email, out cuil, out telefono);
            if (!string.IsNullOrEmpty(error))
                return error;

            // En este caso, eliminamos la validación de correo duplicado
            // Si todo es válido, actualizamos la persona en la base de datos
            _clientesDatos.ActualizarPersona(cuil, nombre, apellido, telefono, domicilio, email);

            // Retornar vacío si no hay errores
            return string.Empty;
        }
        public bool VerificarCorreoExistente(string correo)
        {
            return _clientesDatos.VerificarCorreoExistente(correo); // Llamar al método de la capa de datos
        }

    }
}
