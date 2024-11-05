using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using Punto_de_venta___Prácticas_profesionales.Lógica;
using System.Security.Cryptography;

namespace Punto_de_venta___Prácticas_profesionales.Datos
{

    internal class proveedoresDatos
    {
        string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
        
        public DataTable refrescarProveedores()
        {
            string connectionString = @"URI=file:" + databasePath;
            using var conn = new SQLiteConnection(connectionString);
            DataTable tabla = new DataTable();
            string query = "SELECT * FROM proveedores";
            conn.Open();
            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            tabla.Load(reader);
            return tabla;
        }
        public DataTable buscarProveedores(string param)
        {
            string connectionString = @"URI=file:" + databasePath;
            using var conn = new SQLiteConnection(connectionString);
            DataTable tabla = new DataTable();
            string query = " SELECT * FROM proveedores WHERE nombre LIKE @param OR telefono LIKE @param OR email LIKE @param OR deuda LIKE @param";
            conn.Open();
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@param", "%" + param + "%");
            using var reader = cmd.ExecuteReader();
            tabla.Load(reader);
            return tabla;
        }
        public void agregarProveedor(proveedoresLogica proveedor)
        {
            string connectionString = @"URI=file:" + databasePath;
            using var conn = new SQLiteConnection(connectionString);
            string query = "INSERT into proveedores(nombre, telefono, email, deuda) VALUES (@nombre, @telefono, @email, @deuda)";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
            cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);
            cmd.Parameters.AddWithValue("@email", proveedor.Email);
            cmd.Parameters.AddWithValue("@deuda", proveedor.Deuda);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void modificarProveedor(proveedoresLogica modificado)
        {
            string connectionString = @"URI=file:" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
            using var conn = new SQLiteConnection( connectionString);
            string query = " UPDATE proveedores SET nombre = @nombre, telefono = @telefono, email = @correo, deuda = @deuda WHERE IdColumn = @id";
            using var cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@nombre", modificado.Nombre);
            cmd.Parameters.AddWithValue("@telefono", modificado.Telefono);
            cmd.Parameters.AddWithValue("@email", modificado.Email);
            cmd.Parameters.AddWithValue("@deuda", modificado.Deuda);
            cmd.Parameters.AddWithValue("@id", modificado.Id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }  
    }
}
