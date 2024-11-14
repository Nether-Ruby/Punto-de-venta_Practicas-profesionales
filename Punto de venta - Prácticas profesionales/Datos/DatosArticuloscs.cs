using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Punto_de_venta___Prácticas_profesionales.Datos
{
    public static class DatosArticuloscs
    {
        private static readonly string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
        public static string ConnectionString { get; } = $"URI=file:{databasePath}";

        public static void InitializeDatabase()
        {
            try
            {
                if (!File.Exists(databasePath))
                {
                    SQLiteConnection.CreateFile(databasePath);
                }

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Verificar si la tabla "Articulos" existe
                    string checkTableSql = "SELECT name FROM sqlite_master WHERE type='table' AND name='Articulos';";
                    using (var checkCommand = new SQLiteCommand(checkTableSql, connection))
                    using (var reader = checkCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            // Crear la tabla "Articulos" con todas las columnas necesarias si no existe
                            string createTableSql = @"
                                CREATE TABLE Articulos (
                                    Codigo INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Nombre TEXT NOT NULL,
                                    Marca TEXT,
                                    Rubro TEXT,
                                    precio_unitario REAL,
                                    Stock INTEGER,
                                    Activo INTEGER DEFAULT 1
                                )";
                            using (var createCommand = new SQLiteCommand(createTableSql, connection))
                            {
                                createCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Verificar y agregar las columnas que puedan faltar
                            VerifyAndAddColumn(connection, "precio_unitario", "REAL");
                            VerifyAndAddColumn(connection, "Stock", "INTEGER");
                            VerifyAndAddColumn(connection, "Activo", "INTEGER DEFAULT 1");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void VerifyAndAddColumn(SQLiteConnection connection, string columnName, string columnType)
        {
            string checkColumnSql = $"PRAGMA table_info(Articulos);";
            bool columnExists = false;

            using (var checkCommand = new SQLiteCommand(checkColumnSql, connection))
            using (var reader = checkCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["name"].ToString() == columnName)
                    {
                        columnExists = true;
                        break;
                    }
                }
            }

            if (!columnExists)
            {
                string alterTableSql = $"ALTER TABLE Articulos ADD COLUMN {columnName} {columnType};";
                using (var alterCommand = new SQLiteCommand(alterTableSql, connection))
                {
                    alterCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
