using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Punto_de_venta___Prácticas_profesionales.Datos
{
    internal class clientesDatos
    {
        // Configuración de la ruta de la base de datos para mayor portabilidad
        private readonly string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

        // Método para verificar si el correo ya existe en la base de datos
        public bool VerificarCorreoExistente(string email, long? cuil = null)
        {
            string connectionString = $"Data Source={databasePath}; Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = cuil.HasValue
                        ? "SELECT COUNT(*) FROM Clientes WHERE email = @Email AND CUIL != @CUIL"
                        : "SELECT COUNT(*) FROM Clientes WHERE email = @Email";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        if (cuil.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@CUIL", cuil.Value);
                        }

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0; // Retorna true si el correo ya existe en la base de datos
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar correo: " + ex.Message);
                return false;
            }
        }

        // Método para validar el correo (expresión regular)
        private bool ValidarCorreo(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        // Método para insertar una persona (cliente)
        public void InsertarPersona(long cuil, string nombre, string apellido, long telefono, string domicilio, string email)
        {
            // Validar correo
            if (!ValidarCorreo(email))
            {
                MessageBox.Show("Error: El correo proporcionado no es válido.");
                return;
            }

            // Verificar si el correo ya está registrado
            if (VerificarCorreoExistente(email))
            {
                MessageBox.Show("Error: El correo ya está registrado en la base de datos.");
                return;
            }

            // Verificar si el CUIL ya está registrado
            if (VerificarCuilExistente(cuil))
            {
                MessageBox.Show("Error: El CUIL ya está registrado en la base de datos.");
                return;
            }

            // Cadena de conexión
            string connectionString = $"Data Source={databasePath}; Version=3;";

            if (!File.Exists(databasePath))
            {
                MessageBox.Show("Error: La base de datos no se encuentra en la ruta especificada: " + databasePath);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Clientes (CUIL, nombres, apellido, telefono, domicilio, email) VALUES (@cuil, @nombre, @apellido, @telefono, @domicilio, @email)";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cuil", cuil);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@domicilio", domicilio);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        // Método para verificar si el CUIL ya existe en la base de datos
        public bool VerificarCuilExistente(long cuil)
        {
            string connectionString = $"Data Source={databasePath}; Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Clientes WHERE CUIL = @CUIL";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CUIL", cuil);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0; // Retorna true si el CUIL ya existe en la base de datos
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar CUIL: " + ex.Message);
                return false;
            }
        }


        // Método para obtener todas las personas (clientes)
        public DataTable ObtenerPersonas()
        {
            string connectionString = $"Data Source={databasePath}; Version=3;";
            DataTable tablaPersonas = new DataTable();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Clientes";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                        {
                            adapter.Fill(tablaPersonas);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener personas: " + ex.Message);
            }

            return tablaPersonas;
        }
        // Método para obtener el correo de un cliente dado su CUIL
        public string ObtenerCorreoPorCuil(long cuilOriginal)
        {
            string connectionString = $"Data Source={databasePath}; Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT email FROM Clientes WHERE CUIL = @CUIL";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CUIL", cuilOriginal);

                        object result = cmd.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el correo: " + ex.Message);
                return null;
            }
        }



        // Método para actualizar los datos de una persona
        public void ActualizarPersona(long cuil, string nombre, string apellido, long telefono, string domicilio, string email)
        {
            // Validar correo
            if (!ValidarCorreo(email))
            {
                MessageBox.Show("Error: El correo proporcionado no es válido.");
                return;
            }

            // Verificar si el correo ya existe, pero excluyendo al cliente actual (el que se está actualizando)
            if (VerificarCorreoExistente(email, cuil))  // Se pasa cuil para que no se verifique al propio cliente
            {
                MessageBox.Show("Error: El correo ya está registrado en la base de datos.");
                return;
            }

            string connectionString = $"Data Source={databasePath}; Version=3;";

            if (!File.Exists(databasePath))
            {
                MessageBox.Show("Error: La base de datos no se encuentra en la ruta especificada: " + databasePath);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "UPDATE Clientes SET nombres = @nombre, apellido = @apellido, telefono = @telefono, domicilio = @domicilio, email = @email WHERE CUIL = @cuil";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cuil", cuil);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@domicilio", domicilio);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
        }

    }
}
