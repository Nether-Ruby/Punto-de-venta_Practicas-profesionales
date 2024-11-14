using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Punto_de_venta___Prácticas_profesionales.Datos
{

    internal class clientesDatos
    {
        // Configuramos la ruta de la base de datos desde el directorio base de la aplicación para mayor portabilidad
        private readonly string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

        public void InsertarPersona(long cuil, string nombre, string apellido, long telefono, string domicilio, string email)
        {
            // Cadena de conexión usando una ruta relativa para SQLite
            string connectionString = $"Data Source={databasePath}; Version=3;";

            // Verificamos si el archivo de base de datos existe antes de proceder
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

                        MessageBox.Show("Guardado en la base de datos exitosamente.");
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
        }

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

        public void ActualizarPersona(long cuil, string nombre, string apellido, long telefono, string domicilio, string email)
        {
            // Cadena de conexión usando una ruta relativa para SQLite
            string connectionString = $"Data Source={databasePath}; Version=3;";

            // Verificamos si el archivo de base de datos existe antes de proceder
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
                    string sql = "UPDATE Clientes SET nombres = @nombre, apellido = @apellido, telefono = @telefono, domicilio = @domicilio, email = @email WHERE CUIL = @cuil ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cuil", cuil);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@domicilio", domicilio);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Cliente actualizado.");
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
