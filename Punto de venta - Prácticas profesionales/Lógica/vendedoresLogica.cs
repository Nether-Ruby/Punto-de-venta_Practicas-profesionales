using Punto_de_venta___Prácticas_profesionales.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    internal class vendedoresLogica
    {
        vendedoresDatos cn = new vendedoresDatos();

        public DataTable consultaVendedores()
        {
            return cn.consultaVendedores();
        }

        public bool registrarVendedor(string cuil, string nombre, string apellido, string telefono, string domicilio, out string mensaje)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(cuil) || cuil.Length != 11)
            {
                mensaje = "El CUIL debe contener 11 caracteres.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                mensaje = "El nombre y apellido son obligatorios.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(telefono) || telefono.Length < 7)
            {
                mensaje = "El teléfono es inválido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(domicilio))
            {
                mensaje = "El domicilio es obligatorio.";
                return false;
            }

            // Intentar insertar el vendedor
            try
            {
                cn.insertarVendedor(cuil, nombre, apellido, telefono, domicilio);
                mensaje = "Vendedor registrado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message; // Mensaje del error (ejemplo: "El CUIL ya está registrado.")
                return false;
            }
        }

        public bool ModificarVendedorDesdeGrid(string cuil, string nombre, string apellido, string telefono, string domicilio, out string mensaje)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(cuil) || cuil.Length != 11)
            {
                mensaje = "El CUIL debe contener 11 caracteres.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                mensaje = "El nombre y apellido son obligatorios.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(telefono) || telefono.Length < 7)
            {
                mensaje = "El teléfono es inválido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(domicilio))
            {
                mensaje = "El domicilio es obligatorio.";
                return false;
            }

            // Llamar a la capa de datos para actualizar
            try
            {
                cn.modificarVendedor(cuil, nombre, apellido, telefono, domicilio);
                mensaje = "Vendedor modificado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al modificar el vendedor: {ex.Message}";
                return false;
            }
        }
        public bool eliminarVendedor(string cuil, out string mensaje)
        {
            // Validación del CUIL
            if (string.IsNullOrWhiteSpace(cuil) || cuil.Length != 11)
            {
                mensaje = "El CUIL debe contener 11 caracteres.";
                return false;
            }

            try
            {
                // Llamar a la capa de datos para eliminar
                cn.borrarVendedor(cuil);
                mensaje = "Vendedor eliminado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al eliminar el vendedor: {ex.Message}";
                return false;
            }
        }
    }
}
