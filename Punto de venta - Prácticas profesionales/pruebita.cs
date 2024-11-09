


///////
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Data.SQLite;
//using System.IO;
//using Punto_de_venta___Prácticas_profesionales.Datos;
////using CrudArticulosApp;

//namespace Punto_de_venta___Prácticas_profesionales
////namespace Punto_de_venta.Presentacion
//{
//    public partial class FormArticulos : Form
//    {
//        public FormArticulos()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            if (!double.TryParse(txtPrecio.Texts, out double precio))
//            {
//                MessageBox.Show("Por favor ingrese un número válido para el Precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (string.IsNullOrEmpty(txtStock.Texts) || !int.TryParse(txtStock.Texts, out int stock))
//            {
//                MessageBox.Show("Por favor ingrese un número válido para el Stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Verificar si el artículo ya existe pero está inactivo
//            string checkQuery = "SELECT COUNT(*) FROM Articulos WHERE Codigo = @Codigo AND Activo = 0";
//            using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
//            {
//                connection.Open();
//                using (var checkCommand = new SQLiteCommand(checkQuery, connection))
//                {
//                    checkCommand.Parameters.AddWithValue("@Codigo", txtCodigo.Texts);
//                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

//                    if (count > 0)
//                    {
//                        // Si existe como inactivo, se reactiva
//                        string reactivateQuery = "UPDATE Articulos SET Activo = 1, Nombre = @Nombre, Marca = @Marca, Rubro = @Rubro, Precio = @Precio, Stock = @Stock WHERE Codigo = @Codigo";
//                        using (var reactivateCommand = new SQLiteCommand(reactivateQuery, connection))
//                        {
//                            reactivateCommand.Parameters.AddWithValue("@Codigo", txtCodigo.Texts);
//                            reactivateCommand.Parameters.AddWithValue("@Nombre", txtNombre.Texts);
//                            reactivateCommand.Parameters.AddWithValue("@Marca", txtMarca.Texts);
//                            reactivateCommand.Parameters.AddWithValue("@Rubro", txtRubro.Texts);
//                            reactivateCommand.Parameters.AddWithValue("@Precio", precio);
//                            reactivateCommand.Parameters.AddWithValue("@Stock", stock);
//                            reactivateCommand.ExecuteNonQuery();
//                            MessageBox.Show("Artículo reactivado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        }
//                    }
//                    else
//                    {
//                        // Si no existe, se inserta como nuevo
//                        string insertQuery = "INSERT INTO Articulos (Codigo, Nombre, Marca, Rubro, Precio, Stock, Activo) VALUES (@Codigo, @Nombre, @Marca, @Rubro, @Precio, @Stock, 1)";
//                        using (var insertCommand = new SQLiteCommand(insertQuery, connection))
//                        {
//                            insertCommand.Parameters.AddWithValue("@Codigo", txtCodigo.Texts);
//                            insertCommand.Parameters.AddWithValue("@Nombre", txtNombre.Texts);
//                            insertCommand.Parameters.AddWithValue("@Marca", txtMarca.Texts);
//                            insertCommand.Parameters.AddWithValue("@Rubro", txtRubro.Texts);
//                            insertCommand.Parameters.AddWithValue("@Precio", precio);
//                            insertCommand.Parameters.AddWithValue("@Stock", stock);
//                            insertCommand.ExecuteNonQuery();
//                            MessageBox.Show("Artículo agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        }
//                    }
//                }
//            }

//            CargarArticulos(); // Recargar la grilla con los artículos activos
//            LimpiarCampos();
//        }






//        //
//        private void CargarArticulos()
//        {
//            string query = "SELECT * FROM Articulos WHERE Activo = 1";
//            try
//            {
//                using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
//                {
//                    var dataAdapter = new SQLiteDataAdapter(query, connection);
//                    var dataTable = new DataTable();
//                    dataAdapter.Fill(dataTable);
//                    dataGridView1.DataSource = dataTable;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error al cargar artículos activos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void CargarArticulosInactivos()
//        {
//            string query = "SELECT * FROM Articulos WHERE Activo = 0";
//            try
//            {
//                using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
//                {
//                    var dataAdapter = new SQLiteDataAdapter(query, connection);
//                    var dataTable = new DataTable();
//                    dataAdapter.Fill(dataTable);
//                    dataGridViewInactivos.DataSource = dataTable;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error al cargar artículos inactivos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }




//        private void btnActualizar_Click(object sender, EventArgs e)
//        {
//            // Validaciones para los campos de precio y stock
//            if (!double.TryParse(txtPrecio.Texts, out double precio))
//            {
//                MessageBox.Show("Por favor ingrese un número válido para el Precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (!int.TryParse(txtStock.Texts, out int stock))
//            {
//                MessageBox.Show("Por favor ingrese un número válido para el Stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Verificar que el campo de Codigo no esté vacío
//            if (string.IsNullOrWhiteSpace(txtCodigo.Texts))
//            {
//                MessageBox.Show("Por favor ingrese un código de producto para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            string query = "UPDATE Articulos SET Nombre=@Nombre, Marca=@Marca, Rubro=@Rubro, Precio=@Precio, Stock=@Stock WHERE Codigo=@Codigo";

//            try
//            {
//                using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
//                {
//                    connection.Open();
//                    using (var command = new SQLiteCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@Codigo", txtCodigo.Texts);
//                        command.Parameters.AddWithValue("@Nombre", txtNombre.Texts);
//                        command.Parameters.AddWithValue("@Marca", txtMarca.Texts);
//                        command.Parameters.AddWithValue("@Rubro", txtRubro.Texts);
//                        command.Parameters.AddWithValue("@Precio", precio);
//                        command.Parameters.AddWithValue("@Stock", stock);

//                        // Ejecutar y verificar si se afectó alguna fila
//                        int rowsAffected = command.ExecuteNonQuery();
//                        if (rowsAffected == 0)
//                        {
//                            MessageBox.Show("No se encontró el artículo con el código especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        }
//                        else
//                        {
//                            MessageBox.Show("Artículo actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        }
//                    }
//                }
//                CargarArticulos(); // Recargar los artículos en la grilla
//                LimpiarCampos();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error al actualizar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnEliminar_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtCodigo.Texts))
//            {
//                MessageBox.Show("Por favor ingrese un código de producto para deshabilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            string query = "UPDATE Articulos SET Activo = 0 WHERE Codigo = @Codigo";
//            try
//            {
//                using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
//                {
//                    connection.Open();
//                    using (var command = new SQLiteCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@Codigo", txtCodigo.Texts);
//                        int rowsAffected = command.ExecuteNonQuery();
//                        if (rowsAffected == 0)
//                        {
//                            MessageBox.Show("No se encontró el artículo para deshabilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        }
//                        else
//                        {
//                            MessageBox.Show("Artículo deshabilitado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        }
//                    }
//                }
//                CargarArticulos();          // Recargar los artículos activos en el DataGridView principal
//                CargarArticulosInactivos();  // Recargar los artículos inactivos en el DataGridView secundario
//                LimpiarCampos();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error al deshabilitar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }



//        private void LimpiarCampos()
//        {
//            txtCodigo.Clear();
//            txtNombre.Clear();
//            txtMarca.Clear();
//            txtRubro.Clear();
//            txtPrecio.Clear();
//            txtStock.Clear();
//        }

//        //private void FormArtic_Load(object sender, EventArgs e)
//        //{
//        //    DatabaseHelper.InitializeDatabase();
//        //    CargarArticulos();

//        //    // Suscribirse al evento CellEndEdit para detectar cambios en las celdas
//        //    dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
//        //}

//        private void FormArtic_Load(object sender, EventArgs e)
//        {
//            DatabaseHelper.InitializeDatabase();
//            CargarArticulos();         // Cargar los artículos activos
//            CargarArticulosInactivos(); // Cargar los artículos inactivos

//            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
//        }

//        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
//        {
//            // Obtener el nombre de la columna y el valor editado
//            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
//            object newValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

//            // Obtener el valor de "Codigo" de la fila seleccionada
//            string codigo = dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value?.ToString();

//            if (string.IsNullOrEmpty(codigo))
//            {
//                MessageBox.Show("No se puede actualizar porque el código es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Armar la consulta SQL dinámica para actualizar solo la columna editada
//            string query = $"UPDATE Articulos SET {columnName} = @newValue WHERE Codigo = @Codigo";

//            try
//            {
//                using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
//                {
//                    connection.Open();
//                    using (var command = new SQLiteCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@newValue", newValue);
//                        command.Parameters.AddWithValue("@Codigo", codigo);
//                        int rowsAffected = command.ExecuteNonQuery();

//                        if (rowsAffected == 0)
//                        {
//                            MessageBox.Show("No se encontró el artículo para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        }
//                        else
//                        {
//                            MessageBox.Show("Artículo actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error al actualizar el artículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//            // Recargar la grilla para reflejar los cambios en la base de datos
//            CargarArticulos();
//        }

//        private void txtCodigo_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {

//        }

//        private void txtCodigo__TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void btnLimpiar_Click(object sender, EventArgs e)
//        {
//            txtCodigo.Clear();
//            txtNombre.Clear();
//            txtMarca.Clear();
//            txtRubro.Clear();
//            txtPrecio.Clear();
//            txtStock.Clear();
//        }
//    }
//}