using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_de_venta___Prácticas_profesionales.Datos
{
    internal class vendedoresDatos
    {
        string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

        public bool ExisteCuil(string cuil)
        {
            string connectionString = @"URI=file:" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Vendedores WHERE CUIL = @CUIL";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CUIL", cuil);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; // Devuelve true si el CUIL ya existe
                }
            }
        }
        public DataTable consultaVendedores()
        {
            string connectionString = @"URI=file:" + databasePath;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Vendedores";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command))
                    {
                        DataTable tabla = new DataTable();
                        dataAdapter.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }
        public void insertarVendedor(string cuil, string nombre, string apellido, string telefono, string domicilio)
        {
            if (ExisteCuil(cuil))
            {
                throw new Exception("El CUIL ya está registrado.");
            }

            string connectionString = @"URI=file:" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Vendedores (CUIL, nombres, apellido, telefono, domicilio) VALUES (@CUIL, @Nombre, @Apellido, @Telefono, @Domicilio)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CUIL", cuil);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Domicilio", domicilio);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void modificarVendedor(string cuil, string nombre, string apellido, string telefono, string domicilio)
        {
            string connectionString = @"URI=file:" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Vendedores SET nombres = @Nombre, apellido = @Apellido, telefono = @Telefono, domicilio = @Domicilio WHERE CUIL = @CUIL";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CUIL", cuil);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Domicilio", domicilio);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void borrarVendedor(string cuil)
        {
            string connectionString = @"URI=file:" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Vendedores WHERE CUIL = @CUIL";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CUIL", cuil);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se encontró un vendedor con el CUIL especificado.");
                    }
                }
            }
        }

    }

}
