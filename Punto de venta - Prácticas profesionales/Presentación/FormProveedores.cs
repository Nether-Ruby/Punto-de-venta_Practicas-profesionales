using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_venta___Prácticas_profesionales.Lógica;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            InitializeComponent();
            actualizar();
            dataGridView1.Columns[0].ReadOnly = true;
        }
        private void actualizar()
        {
            proveedoresLogica tabla = new proveedoresLogica();
            dataGridView1.DataSource = tabla.mostrarProveedores();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void FormProveedores_Resize(object sender, EventArgs e)
        {

            int baseWidth = 800; // Your base form width
            int baseHeight = 600; // Your base form height

            float widthRatio = (float)this.Width / baseWidth;
            float heightRatio = (float)this.Height / baseHeight;

            foreach (Control control in this.Controls)
            {
                control.Width = (int)(control.Width * widthRatio);
                control.Height = (int)(control.Height * heightRatio);
                control.Left = (int)(control.Left * widthRatio);
                control.Top = (int)(control.Top * heightRatio);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string param = textBox1.Text;
            proveedoresLogica coincidencias = new proveedoresLogica();
            dataGridView1.DataSource = coincidencias.buscarProveedores(param);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        { // Permitir dígitos, caracteres de control y un único punto decimal
          if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.') 
            { 
                e.Handled = true; 
            } // Asegurarse de que solo haya un punto decimal
          if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1) { e.Handled = true; } }

            private void button2_Click(object sender, EventArgs e)
        {
            string nombre = textBox2.Text;
            string email = textBox4.Text; // Asegúrate de que se toma el valor correcto del TextBox

            // Manejo de teléfono
            string telefono = textBox3.Text;
            // Manejo de deuda
            string deudaTexto = textBox5.Text;
            if (!double.TryParse(deudaTexto, out double deuda))
            {
                MessageBox.Show("Error en la deuda: Debe ser un número válido.");
                return;
            }

            proveedoresLogica NuevoProveedor = new proveedoresLogica
            {
                Nombre = nombre,
                Telefono = telefono,
                Email = email, // Asignar el email correctamente
                Deuda = deuda
            };

            if (!proveedoresLogica.ValidarProveedor(NuevoProveedor, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            try
            {
                NuevoProveedor.agregarProveedor(NuevoProveedor);
                MessageBox.Show("Proveedor agregado con éxito.");
                actualizar(); // Asumimos que este método está definido y actualiza la UI o los datos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el proveedor: " + ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Obtener el ID del proveedor
                    int proveedorId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["proveedor_id"].Value);

                    // Obtener los valores de las celdas editadas
                    string currentNombre = dataGridView1.Rows[e.RowIndex].Cells["nombre"].Value?.ToString();
                    string currentTelefono = dataGridView1.Rows[e.RowIndex].Cells["telefono"].Value?.ToString();
                    string currentEmail = dataGridView1.Rows[e.RowIndex].Cells["email"].Value?.ToString();
                    double currentDeuda = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["deuda"].Value ?? 0.0);

                    // Obtener el nombre de la columna editada
                    string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                    var newValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                    // Verificar el valor de la deuda si se edita
                    double? deuda = null;
                    if (columnName == "deuda")
                    {
                        if (double.TryParse(newValue, out double parsedDeuda))
                        {
                            deuda = parsedDeuda;
                        }
                        else
                        {
                            MessageBox.Show("Error en la deuda: Debe ser un número válido.");
                            return;
                        }
                    }
                    else
                    {
                        deuda = currentDeuda;
                    }

                    // Crear una instancia del proveedor con la información actualizada
                    proveedoresLogica proveedor = new proveedoresLogica
                    {
                        Id = proveedorId, // Usar proveedor_id como clave primaria
                        Nombre = columnName == "nombre" ? newValue : currentNombre,
                        Telefono = columnName == "telefono" ? newValue : currentTelefono,
                        Email = columnName == "email" ? newValue : currentEmail,
                        Deuda = deuda.HasValue ? deuda.Value : currentDeuda
                    };

                    // Validar y actualizar la base de datos
                    if (proveedoresLogica.ValidarProveedor(proveedor, out string errorMessage))
                    {
                        try
                        {
                            proveedor.modificarProveedor(proveedor);
                            MessageBox.Show("Proveedor actualizado con éxito.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al actualizar el proveedor: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        /*
         * 
         */



    }
}
