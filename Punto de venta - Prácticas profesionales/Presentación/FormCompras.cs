using Punto_de_venta___Prácticas_profesionales.Lógica;
using System;
using System.Data;
using System.Windows.Forms;

namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    public partial class FormCompras : Form
    {
        comprasLogica compra = new comprasLogica();
        int cantidad;
        DataTable articulosTable; // Declaración de articulos
        DataTable proveedoresTable;
        private bool isComboBox1Changing = false; // Bandera para controlar la ejecución


        public FormCompras()
        {
            InitializeComponent();
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;


         

            cargarCombobox();
            actualizar();
        }

       

        private void actualizar()
        {
            dataGridView1.DataSource = comprasLogica.mostrarCompras();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void FormCompras_Resize(object sender, EventArgs e)
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

        private void cargarCombobox()
        {
            articulosTable = comprasLogica.mostrarArticulos();
            comboBox1.DataSource = articulosTable;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "codigo";

            proveedoresTable = comprasLogica.mostrarProveedores();
            comboBox2.DataSource = proveedoresTable;
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "proveedor_id";
        }


        private void button_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 &&
                !string.IsNullOrEmpty(textbox.Text) && int.TryParse(textbox.Text, out int cantidad))
            {
                int indiceSeleccionado = comboBox1.SelectedIndex;

                if (indiceSeleccionado >= 0 && indiceSeleccionado < articulosTable.Rows.Count)
                {
                    double precio_lista = Convert.ToDouble(articulosTable.Rows[indiceSeleccionado]["precio_lista"]);
                    double total = precio_lista * cantidad;

                    // Mostrar el total en textboxTotal
                    textboxTotal.Text = total.ToString("F2");

                    // Realizar las acciones si todos los controles tienen valores válidos
                    compra.Articulo = Convert.ToInt32(comboBox1.SelectedValue);
                    compra.Proveedor = Convert.ToInt32(comboBox2.SelectedValue);
                    compra.Cantidad = cantidad; // Ya se validó y parseó antes
                    compra.Monto = total;
                    compra.Fecha_hora = DateTime.Now;
                    compra.registrar(compra);
                    actualizar();
                    button.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se pudo acceder al precio unitario");
                }
            }
            else
            {
                MessageBox.Show("Por favor, asegúrese de que todos los campos están llenos correctamente.");
            }
        }



        private void VerificarValores()
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 &&
                !string.IsNullOrEmpty(textbox.Text) && int.TryParse(textbox.Text, out int cantidad))
            {
                DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                    double precio_lista = Convert.ToDouble(selectedRow["precio_lista"]);
                    double total = precio_lista * cantidad;

                    textboxTotal.Text = total.ToString("F2");
                    button.Enabled = true; // Habilitar el botón si todos los controles tienen valores válidos
                }
                else
                {
                    button.Enabled = false; // Deshabilitar el botón si algún control está vacío o no es válido
                    textboxTotal.Text = "0.00";
                }
            }
            else
            {
                button.Enabled = false; // Deshabilitar el botón si algún control está vacío o no es válido
                textboxTotal.Text = "0.00";
            }
        }


        private void FormCompras_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged; // Evitar múltiple suscripción
            comboBox2.SelectedIndexChanged -= comboBox2_SelectedIndexChanged; // Evitar múltiple suscripción
            textbox.TextChanged -= textbox__TextChanged; // Evitar múltiple suscripción

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            textbox.TextChanged += textbox__TextChanged;

            button.Enabled = false; // Inicialmente deshabilitar el botón
        }



        private void textbox__TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textbox.Text, out int nuevaCantidad))
            {
                cantidad = nuevaCantidad;

                // Solo actualizar el textboxTotal si hay un artículo seleccionado en comboBox1
                if (comboBox1.SelectedIndex != -1)
                {
                    DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;

                    if (selectedRow != null)
                    {
                        double precio_lista = Convert.ToDouble(selectedRow["precio_lista"]);
                        double total = precio_lista * cantidad;

                        textboxTotal.Text = total.ToString("F2"); // Actualizar el textboxTotal con el nuevo total
                        button.Enabled = true; // Habilitar el botón si todos los controles tienen valores válidos
                    }
                    else
                    {
                        button.Enabled = false; // Deshabilitar el botón si algún control está vacío o no es válido
                        textboxTotal.Text = "0.00";
                    }
                }
            }
            else
            {
                button.Enabled = false; // Deshabilitar el botón si el texto no es un número válido
                textboxTotal.Text = "0.00";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                int indiceSeleccionado = comboBox1.SelectedIndex;
                DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
                VerificarValores();

                if (selectedRow != null)
                {
                    double precio_lista = Convert.ToDouble(selectedRow["precio_lista"]);
                    double total = precio_lista * cantidad;

                    textboxTotal.Text = total.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Selección inválida en comboBox1");
                }
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarValores();
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.DroppedDown)
            {
                comboBox1.DroppedDown = false;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb != null)
            {
                // Desconectar temporalmente el evento para evitar ciclo de eventos
                cb.TextChanged -= comboBox1_TextChanged;

                string searchText = cb.Text;

                DataTable tabla = comprasLogica.mostrarArticulos();
                DataView vista = tabla.DefaultView;
                vista.RowFilter = string.Format("nombre LIKE '%{0}%'", searchText);

                string previousText = cb.Text; // Guardar el texto actual antes de cambiar el DataSource
                cb.DataSource = vista.ToTable();
                cb.DisplayMember = "nombre";
                cb.ValueMember = "codigo";

                // Restaurar el texto ingresado por el usuario
                cb.Text = previousText;
                cb.SelectionStart = previousText.Length; // Restaurar el cursor al final del texto ingresado
                cb.SelectionLength = 0;

                // Reconectar el evento después de la actualización
                cb.TextChanged += comboBox1_TextChanged;
            }
        }


        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            // Desconectar temporalmente el evento para evitar ciclo de eventos
            cb.TextChanged -= comboBox2_TextChanged;

            string searchText = cb.Text;

            DataTable tabla = comprasLogica.mostrarProveedores();
            DataView vista = tabla.DefaultView;
            vista.RowFilter = string.Format("nombre LIKE '%{0}%'", searchText);

            string previousText = cb.Text; // Guardar el texto actual antes de cambiar el DataSource
            cb.DataSource = vista.ToTable();
            cb.DisplayMember = "nombre";
            cb.ValueMember = "proveedor_id";

            // Restaurar el texto ingresado por el usuario
            cb.Text = previousText;
            cb.SelectionStart = previousText.Length; // Restaurar el cursor al final del texto ingresado
            cb.SelectionLength = 0;

            // Reconectar el evento después de la actualización
            cb.TextChanged += comboBox2_TextChanged;

        }

        // Restaura el evento DateTimePicker_ValueChanged
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            DataGridViewRow closestRow = null;
            double minDifference = double.MaxValue;

            // Ensure the DataGridView has at least 1 column (adjust if needed)
            if (dataGridView1.Columns.Count == 0)
            {
                MessageBox.Show("The DataGridView has no columns.");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Check if the cell value is not null
                if (row.Cells[5].Value == null) // Use index 5 for the 6th column
                {
                    continue; // Skip this row if the cell value is null
                }

                // Safely convert the cell value to DateTime
                DateTime rowDate;
                try
                {
                    rowDate = Convert.ToDateTime(row.Cells[5].Value); // Use index 5 for the 6th column
                }
                catch (Exception ex)
                {
                    // Handle invalid date format
                    MessageBox.Show($"Invalid date format in row {row.Index}: {ex.Message}");
                    continue;
                }

                double difference = Math.Abs((rowDate - selectedDate).TotalDays);

                if (difference == 0)
                {
                    // If there's an exact match, select and scroll to that row
                    row.Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
                else if (difference < minDifference)
                {
                    // Find the row with the smallest day difference
                    minDifference = difference;
                    closestRow = row;
                }
            }

            if (closestRow != null)
            {
                // Select and scroll to the closest row
                closestRow.Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = closestRow.Index;
            }
            else
            {
                MessageBox.Show("No se encontraron fechas coincidentes ni cercanas.");
            }
        }
    }
}
