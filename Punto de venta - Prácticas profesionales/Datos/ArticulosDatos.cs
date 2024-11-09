using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Punto_de_venta___Prácticas_profesionales.Datos
{
    public static class ArticulosDatos
    {
        private static readonly string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
        public static string ConnectionString { get; } = $"URI=file:{databasePath}";

        public static void InitializeDatabase()
        {
            try
            {
                // Crear el archivo de base de datos si no existe
                if (!File.Exists(databasePath))
                {
                    SQLiteConnection.CreateFile(databasePath);
                }

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Verificar si la tabla "Articulos" tiene la estructura correcta
                    string checkTableSql = "PRAGMA table_info(Articulos);";
                    bool hasAllColumns = false;
                    int columnCount = 0;

                    using (var command = new SQLiteCommand(checkTableSql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader["name"].ToString();
                            if (columnName == "Precio" || columnName == "Stock")
                            {
                                columnCount++;
                            }
                        }
                    }

                    // Verificar si las columnas "Precio" y "Stock" están presentes
                    hasAllColumns = (columnCount >= 2);

                    // Si la tabla no existe o le faltan columnas, recrearla
                    if (!hasAllColumns)
                    {
                        string dropTableSql = "DROP TABLE IF EXISTS Articulos";
                        using (var dropCommand = new SQLiteCommand(dropTableSql, connection))
                        {
                            dropCommand.ExecuteNonQuery();
                        }

                        // Crear la tabla con la estructura correcta
                        string createTableSql = @"CREATE TABLE Articulos (
                                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                    Codigo TEXT NOT NULL UNIQUE,
                                                    Nombre TEXT NOT NULL,
                                                    Marca TEXT,
                                                    Rubro TEXT,
                                                    Precio REAL,
                                                    Stock INTEGER,
                                                    Activo INTEGER DEFAULT 1
                                                )";
                        using (var createCommand = new SQLiteCommand(createTableSql, connection))
                        {
                            createCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
