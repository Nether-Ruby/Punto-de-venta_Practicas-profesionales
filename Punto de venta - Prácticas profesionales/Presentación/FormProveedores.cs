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
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = textBox2.Text;
            string telefono = textBox3.Text;
            string email = textBox4.Text;
            if (!int.TryParse(textBox5.Text, out int deuda))
            {
                MessageBox.Show("Error en la deuda: Debe ser un número válido.");
                return;
            }
            proveedoresLogica NuevoProveedor = new proveedoresLogica();
            NuevoProveedor.Nombre = nombre;
            NuevoProveedor.Telefono = telefono;
            NuevoProveedor.Email = email;
            NuevoProveedor.Deuda = deuda;
            if (!proveedoresLogica.ValidarProveedor(NuevoProveedor, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
            NuevoProveedor.agregarProveedor(NuevoProveedor);
            MessageBox.Show("Proveedor agregado con éxito.");
            actualizar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            actualizar();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Obtener los valores de la celda editada
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                var newValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value?.ToString(); // Convertir a string

                // Obtener el nombre del proveedor, que es la clave primaria
                var primaryKey = dataGridView1.Rows[rowIndex].Cells["nombre"].Value?.ToString();

                // Obtener el nombre de la columna editada
                string columnName = dataGridView1.Columns[columnIndex].Name;

                // Inicializar variables para los valores actuales
                string currentTelefono = dataGridView1.Rows[rowIndex].Cells["telefono"].Value?.ToString();
                string currentEmail = dataGridView1.Rows[rowIndex].Cells["email"].Value?.ToString();
                int currentDeuda = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["deuda"].Value ?? 0);

                // Verificar el valor de la deuda si se edita
                int? deuda = null;
                if (columnName == "deuda")
                {
                    if (int.TryParse(newValue, out int parsedDeuda))
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
                    Nombre = primaryKey, // Clave primaria
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




    }
}
