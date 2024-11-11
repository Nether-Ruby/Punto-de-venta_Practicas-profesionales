using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Punto_de_venta___Prácticas_profesionales.Lógica;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Core.Mapping;
using System.Transactions;

namespace Punto_de_venta___Prácticas_profesionales.Datos
{
    internal class comprasDatos
    {
        string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

        public DataTable refrescarCompras()
        {
            string connectionString = @"URI=file:" + databasePath;
            using var conn = new SQLiteConnection(connectionString);
            DataTable tabla = new DataTable();
            string query = "SELECT * FROM compras";
            conn.Open();
            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            tabla.Load(reader);
            return tabla;
        }

        public void agregarCompra(comprasLogica compra)
        {
            string connectionString = @"URI=file:" + databasePath;
            try
            {
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();

                using var transaction = conn.BeginTransaction();
                try
                {
                    string dateTimeString = compra.Fecha_hora.ToString("yyyy-MM-dd HH:mm:ss");

                    
                    string query = "INSERT INTO compras(articulo, proveedor, cantidad, monto, fecha_hora) VALUES (@articulo, @proveedor, @cantidad, @monto, @fecha_hora)";
                    using var cmd = new SQLiteCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@articulo", compra.Articulo);
                    cmd.Parameters.AddWithValue("@proveedor", compra.Proveedor);
                    cmd.Parameters.AddWithValue("@cantidad", compra.Cantidad);
                    cmd.Parameters.AddWithValue("@monto", compra.Monto);
                    cmd.Parameters.AddWithValue("@fecha_hora", dateTimeString);
                    cmd.ExecuteNonQuery();

                    
                    string updateQuery = "UPDATE proveedores SET deuda = deuda + @deuda WHERE proveedor_id = @proveedor";
                    using var updateCmd = new SQLiteCommand(updateQuery, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@deuda", compra.Monto);
                    updateCmd.Parameters.AddWithValue("@proveedor", compra.Proveedor);
                    updateCmd.ExecuteNonQuery();

                   
                    transaction.Commit();
                    MessageBox.Show("Compra registrada y deuda actualizada correctamente.");
                }
                catch (Exception ex)
                {
                    // Revertir la transacción en caso de error
                    transaction.Rollback();
                    MessageBox.Show("No se ha podido registrar la compra. Problema con la base de datos: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la conexión con la base de datos: " + ex.Message);
            }
        }

        public static DataTable getArticulos ()
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
            string connectionString = @"URI=file:" + databasePath;
            DataTable tabla = new DataTable();
            using var conn = new SQLiteConnection(connectionString);
            try
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                string query = "SELECT codigo, nombre, 'precio_unitario' FROM Articulos WHERE activo = 1";
                cmd.CommandText = query;
                using SQLiteDataReader reader = cmd.ExecuteReader();
                tabla.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return tabla;
        }
        
        public static DataTable getProveedores()
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
            string connectionString = @"URI=file:" + databasePath;
            DataTable tabla = new DataTable();
            using var conn = new SQLiteConnection(connectionString);
            try
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                string query = "SELECT proveedor_id, nombre FROM proveedores";
                cmd.CommandText = query;
                using SQLiteDataReader reader = cmd.ExecuteReader();
                tabla.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return tabla;
        }
    }
}
