using Punto_de_venta___Prácticas_profesionales.Lógica;
using System;
using System.Data;
using System.Windows.Forms;

namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    public partial class FormCompras : Form
    {
        comprasLogica compra = new comprasLogica();

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
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = comprasLogica.mostrarArticulos();
            comboBox1.DataSource = bindingSource;
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "codigo";
            DataTable tabla2 = new DataTable();
            tabla2 = comprasLogica.mostrarProveedores();
            comboBox2.DataSource = tabla2;
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "proveedor_id";
        }

        private void button_Click(object sender, EventArgs e)
        {
            // Obtener el DataTable asignado como DataSource del comboBox
            DataTable tabla = (DataTable)comboBox1.DataSource;

            // Obtener el índice seleccionado
            int indiceSeleccionado = comboBox1.SelectedIndex;

            // Acceder al valor de precio_unitario en la fila seleccionada
            if (indiceSeleccionado >= 0 && indiceSeleccionado < tabla.Rows.Count)
            {
                double precioUnitario = Convert.ToDouble(tabla.Rows[indiceSeleccionado]["precio_unitario"]);
                MessageBox.Show("Precio Unitario: " + precioUnitario);

                compra.Articulo = Convert.ToInt32(comboBox1.SelectedValue);
                compra.Proveedor = Convert.ToInt32(comboBox2.SelectedValue);
                compra.Cantidad = int.Parse(textbox.Text);
                compra.Monto = precioUnitario * Convert.ToDouble(compra.Cantidad);
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

        private void VerificarValores()
        {
            // Verificar si ambos ComboBox tienen un valor seleccionado y si el TextBox no está vacío y es un número
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 &&
                !string.IsNullOrEmpty(textbox.Text) && int.TryParse(textbox.Text, out int cantidad))
            {
                DataTable tabla = (DataTable)comboBox1.DataSource;
                int indiceSeleccionado = comboBox1.SelectedIndex;

                if (indiceSeleccionado >= 0 && indiceSeleccionado < tabla.Rows.Count)
                {
                    double precioUnitario = Convert.ToDouble(tabla.Rows[indiceSeleccionado]["precio_unitario"]);
                    double total = precioUnitario * cantidad;

                    textboxTotal.Text = total.ToString("F2");
                    button.Enabled = true; // Habilitar el botón si todos los controles tienen valores válidos
                }
                else
                {
                    button.Enabled = false; // Deshabilitar si no se encuentra precio unitario
                }
            }
            else
            {
                button.Enabled = false; // Si no hay valores válidos, deshabilitar el botón
                textboxTotal.Text = ""; // Limpiar el total
            }
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            // Suscribir los eventos
            comboBox1.SelectedIndexChanged += (s, args) => VerificarValores();
            comboBox2.SelectedIndexChanged += (s, args) => VerificarValores();
            textbox.TextChanged += textbox__TextChanged;

            // Asegurar que el botón esté deshabilitado al inicio
            button.Enabled = false;
        }

        private void textbox__TextChanged(object sender, EventArgs e)
        {
            VerificarValores();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerificarValores();
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

            VerificarValores();
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

            VerificarValores();
        }

        // Restaura el evento DateTimePicker_ValueChanged
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            DataGridViewRow closestRow = null;
            double minDifference = double.MaxValue;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Asume que la columna de la fecha es la primera columna (index 0)
                DateTime rowDate = Convert.ToDateTime(row.Cells[6].Value);
                double difference = Math.Abs((rowDate - selectedDate).TotalDays);

                if (difference == 0)
                {
                    // Si hay una coincidencia exacta, selecciona y desplázate a esa fila
                    row.Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
                else if (difference < minDifference)
                {
                    // Encuentra la fila con la menor diferencia de días
                    minDifference = difference;
                    closestRow = row;
                }
            }

            if (closestRow != null)
            {
                // Selecciona y desplázate a la fila más cercana
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
