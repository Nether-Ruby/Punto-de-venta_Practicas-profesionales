


using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Punto_de_venta___Prácticas_profesionales.Lógica
{
    public static class DatabaseHelper
    {
        public static string ConnectionString { get; } = "Data Source=Datos/articulos.db;Version=3;";


        public static void InitializeDatabase()
        {
            try
            {
                // Crear el directorio "Database" si no existe
                if (!Directory.Exists("Datos"))
                {
                    Directory.CreateDirectory("Datos");
                }

                // Crear el archivo de base de datos si no existe
                if (!File.Exists("Datos/articulos.db"))
                {
                    SQLiteConnection.CreateFile("Database/articulos.db");
                }

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Crear la tabla Articulos si no existe
                    string createTableSql = @"CREATE TABLE IF NOT EXISTS Articulos (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Codigo TEXT NOT NULL UNIQUE,
                                        Nombre TEXT NOT NULL,
                                        Marca TEXT,
                                        Rubro TEXT,
                                        Precio REAL,
                                        Stock INTEGER
                                      )";
                    using (var command = new SQLiteCommand(createTableSql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Verificar si la columna "Activo" ya existe
                    string checkColumnSql = "PRAGMA table_info(Articulos);";
                    bool columnExists = false;

                    using (var command = new SQLiteCommand(checkColumnSql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["name"].ToString().Equals("Activo", StringComparison.OrdinalIgnoreCase))
                            {
                                columnExists = true;
                                break;
                            }
                        }
                    }

                    // Si la columna "Activo" no existe, la agregamos
                    if (!columnExists)
                    {
                        string addColumnSql = "ALTER TABLE Articulos ADD COLUMN Activo INTEGER DEFAULT 1";
                        using (var command = new SQLiteCommand(addColumnSql, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
